/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Tizen.Core
{
    /// <summary>
    /// Represents the Tizen Core Task.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class TCoreTask : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private static readonly ConcurrentDictionary<string, TCoreTask> _coreTaskMap = new ConcurrentDictionary<string, TCoreTask>();
        private static readonly ConcurrentDictionary<int, Func<Task>> _taskMap = new ConcurrentDictionary<int, Func<Task>>();
        private static readonly ConcurrentDictionary<int, Action> _actionkMap = new ConcurrentDictionary<int, Action>();
        private static readonly ConcurrentDictionary<int, TimerSource> _timerMap = new ConcurrentDictionary<int, TimerSource>();
        private static readonly ConcurrentDictionary<int, ChannelSource> _channelMap = new ConcurrentDictionary<int, ChannelSource>();
        private static readonly ConcurrentDictionary<int, EventSource> _eventMap = new ConcurrentDictionary<int, EventSource>(); 
        private static Object _idLock = new Object();
        private static int _id = 0;

        /// <summary>
        /// Initializes the TCoreTask class.
        /// </summary>
        /// <param name="id">The ID of the core task.</param>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = new TCoreTask("Worker");
        /// coreTask.Run();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public TCoreTask(string id)
        {
            bool useThread = (id == "main") ? false : true;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.TaskCreate(id, useThread, out  _handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to create task");
            _coreTaskMap[id] = this;
        }

        private TCoreTask(IntPtr handle)
        {
            _handle = handle;
            _disposed = true;
        }

        /// <summary>
        /// Finalizes the TCoreTask class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        ~TCoreTask()
        {
             Dispose(false);
        }

        /// <summary>
        /// Dispatches an asynchronous message to a main loop of the TCoreTask.
        /// </summary>
        /// <remarks>
        /// The asynchronous message will be delivered to the main loop of the TCoreTask.
        /// </remarks>
        /// <param name="action">The action callback.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of the instance is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = TCoreTask.Find("Test");
        /// if (coreTask == null)
        /// {
        ///   coreTask = new TCoreTask("Test");
        ///   coreTask.Run();
        /// }
        /// 
        /// coreTask.Post(() =>
        /// {
        ///   Console.WriteLine("Test task");
        /// });
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Post(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            int id;
            lock (_idLock)
            {
                id = _id++;
            }
            _actionkMap[id] = action;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddIdleJob(_handle, NativeActionCallback, (IntPtr)id, out IntPtr handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to add idle job");
        }

        /// <summary>
        /// Dispatches an asynchronous message to a main loop of the TCoreTask.
        /// </summary>
        /// <remarks>
        /// The asynchronous message will be delivered to the main loop of the TCoreTask.
        /// </remarks>
        /// <param name="task">The task function.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of the instance is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var coreTask = TCoreTask.Find("Sender");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spwan("Sender");
        /// }
        /// 
        /// int id = 0;
        /// coreTask.Send(async () =>
        /// {
        ///   var channelObject = await channel.Receiver.Receive();
        ///   var message = (string)channelObject.Data;
        ///   Console.WriteLine("Received message = " + message);
        /// });
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Send(Func<Task> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            int id;
            lock (_idLock)
            {
                id = _id++;
            }
            _taskMap[id] = task;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddIdleJob(_handle, NativeTaskCallback, (IntPtr)id, out IntPtr handle);
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                _taskMap.TryRemove(id, out var _);
                TCoreErrorFactory.CheckAndThrownException(error, "Failed to add idle job");
            }            
        }

        /// <summary>
        /// Adds a timer to a main loop of the TCoreTask.
        /// </summary>
        /// <param name="interval">The interval of the timer in milliseconds.</param>
        /// <param name="handler">The timer handler.</param>
        /// <returns>The registered timer ID.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when failed because of the instance is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = TCoreTask.Find("TimerTask");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("TimerTask");
        /// }
        /// 
        /// var timerId = coreTask.AddTimer(1000, () => {
        ///   Console.WriteLine("Timer handler is invoked");
        ///   return true;
        /// });
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public int AddTimer(uint interval, Func<bool> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            int id;
            lock (_idLock)
            {
                id = _id++;
            }
            var timerSource = new TimerSource(id, IntPtr.Zero, handler);
            _timerMap[id] = timerSource;
            lock (timerSource)
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddTimer(_handle, interval, NativeTimerCallback, (IntPtr)id, out IntPtr handle);
                if (error != Interop.LibTizenCore.ErrorCode.None)
                {
                    _timerMap.TryRemove(id, out var _);
                    TCoreErrorFactory.CheckAndThrownException(error, "Failed to add a timer");
                }

                timerSource.Handle = handle;
            }
            return id;
        }

        /// <summary>
        /// Removes the registered timer from the main loop of the TCoreTask.
        /// </summary>
        /// <param name="id">The registered timer ID.</param>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = TCoreTask.Find("TimerTask");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("TimerTask");
        /// }
        /// 
        /// var timerId = coreTask.AddTimer(1000, () => {
        ///   Console.WriteLine("Timer handler is invoked");
        ///   return true;
        /// });
        /// ...
        /// coreTask.RemoveTimer(timerId);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void RemoveTimer(int id)
        {
            if (_timerMap.TryRemove(id, out var timerSource))
            {
                lock (timerSource)
                {
                    if (timerSource.Handle != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCore.RemoveSource(_handle, timerSource.Handle);
                        timerSource.Handle = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// Adds a channel receiver to a main loop of the TCoreTask.
        /// </summary>
        /// <param name="receiver">The channel receiver instance.</param>
        /// <returns>The registered source ID.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var coreTask = TCoreTask.Find("ReceivingTask");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("ReceivingThread");
        /// }
        /// 
        /// var receiver = channel.Receiver;
        /// receiver.Received += (sender, args) => {
        ///   Console.WriteLine("OnChannelMessageReceived. Message = " + (string)args.Data);
        /// };
        /// 
        /// var sourceId = coreTask.AddChannelReceiver(receiver);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public int AddChannelReceiver(TCoreChannelReceiver receiver)
        {
            if (receiver == null) { throw new ArgumentNullException(nameof(receiver)); }

            if (receiver.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("The receiver is already added");
            }

            int id;
            lock (_idLock)
            {
                id = _id++;
            }
            var channelSource = new ChannelSource(id, IntPtr.Zero, receiver);
            _channelMap[id] = channelSource;
            lock (channelSource)
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddChannel(_handle, receiver.Handle, NativeChannelReceiveCallback, (IntPtr)id, out IntPtr handle);
                if (error != Interop.LibTizenCore.ErrorCode.None)
                {
                    _channelMap.TryRemove(id, out var _);
                    TCoreErrorFactory.CheckAndThrownException(error, "Failed to add a channel to the task");
                }

                channelSource.Handle = handle;
                receiver.Handle = IntPtr.Zero;
            }
            return id;
        }

        /// <summary>
        /// Removes the registered channel receiver from the main loop of the TCoreTask..
        /// </summary>
        /// <param name="id">The registered source ID.</param>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var coreTask = TCoreTask.Find("ReceivingTask");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("ReceivingThread");
        /// }
        /// 
        /// var receiver = channel.Receiver;
        /// receiver.Received += (sender, args) => {
        ///   Console.WriteLine("OnChannelMessageReceived. Message = " + (string)args.Data);
        /// };
        /// 
        /// var sourceId = coreTask.AddChannelReceiver(receiver);
        /// ...
        /// coreTask.RemoveChannelReceiver(sourceId);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void RemoveChannelReceiver(int id)
        {
            if (_channelMap.TryRemove(id, out var channelSource))
            {
                lock (channelSource)
                {
                    if (channelSource.Handle != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCore.RemoveSource(_handle, channelSource.Handle);
                        channelSource.Handle = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// Adds an event to a main loop of the TCoreTask.
        /// </summary>
        /// <param name="coreEvent">The TCoreEvent instance.</param>
        /// <returns>The registered source ID.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new TCoreEvent();
        /// coreEvent.EventReceived += (sender, args) => {
        ///   Console.WriteLine("OnEventReceived. ID = {}, Message = {}", args.Id, (string)args.Data);
        /// };
        /// 
        /// var coreTask = TCoreTask.Find("EventTask");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("EventTask");
        /// }
        /// 
        /// int sourceId = coreTask.AddEvent(coreEvent);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public int AddEvent(TCoreEvent coreEvent)
        {
            if (coreEvent == null)
            {
                throw new ArgumentNullException(nameof(coreEvent));
            }

            if (coreEvent.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("The event is already added");
            }

            int id;
            lock (_idLock)
            {
                id = _id++;
            }
            var eventSource = new EventSource(id, IntPtr.Zero, coreEvent);
            _eventMap[id] = eventSource;
            lock (eventSource)
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddEvent(_handle, coreEvent.Handle, out IntPtr handle);
                if (error != Interop.LibTizenCore.ErrorCode.None)
                {
                    _eventMap.TryRemove(id, out var _);
                    TCoreErrorFactory.CheckAndThrownException(error, "Failed to add an event to the task");
                }

                eventSource.Handle = handle;
                coreEvent.Handle = IntPtr.Zero;
            }
            return id;
        }

        /// <summary>
        /// Removes the registered event from the main loop of the TCoreTask.
        /// </summary>
        /// <param name="id">The registered source ID.</param>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new TCoreEvent();
        /// coreEvent.EventReceived += (sender, args) => {
        ///   Console.WriteLine("OnEventReceived. ID = {}, Message = {}", args.Id, (string)args.Data);
        /// };
        /// 
        /// var coreTask = TCoreTask.Find("EventTask");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("EventTask");
        /// }
        /// 
        /// int sourceId = coreTask.AddEvent(coreEvent);
        /// ...
        /// coreTask.RemoveEvent(sourceId);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void RemoveEvent(int id)
        {
            if (_eventMap.TryRemove(id, out var eventSource))
            {
                lock (eventSource)
                {
                    if (eventSource.Handle != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCore.RemoveSource(_handle, eventSource.Handle);
                        eventSource.Handle = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// Emits the event object to a main loop of the TCoreTask.
        /// </summary>
        /// <param name="eventObject">The event object instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <example>
        /// <code>
        /// 
        /// int id = 0;
        /// string message = "Test Event";
        /// using (var eventObject = new TCoreEventObject(id++, message))
        /// {
        ///   var coreTask = TCoreTask.Find("EventTask");
        ///   if (coreTask == null)
        ///   {
        ///     coreTask = TCoreTask.Spawn("EventTask");
        ///   }
        ///   coreTask.EmitEvent(eventObject);
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void EmitEvent(TCoreEventObject eventObject)
        {
            if (eventObject == null)
            {
                throw new ArgumentNullException(nameof(eventObject));
            }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.EmitEvent(_handle, eventObject.Handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to emit event");
            eventObject.Handle = IntPtr.Zero;
        }

        private static bool NativeTaskCallback(IntPtr userData)
        {
            int taskId = (int)userData;
            if (_taskMap.TryRemove(taskId, out Func<Task> task))
            {
                task();
            }
            return false;
        }

        private static bool NativeActionCallback(IntPtr userData)
        {
            int actionId = (int)userData;
            if (_actionkMap.TryRemove(actionId, out Action action))
            {
                action();
            }
            return false;
        }

        private static bool NativeTimerCallback(IntPtr userData)
        {
            int timerId = (int)userData;
            if (_timerMap.TryGetValue(timerId, out TimerSource timerSource))
            {
                bool result = false;
                lock (timerSource)
                {
                    if (timerSource.Handle != IntPtr.Zero)
                    {
                        result = timerSource.Handler();
                        if (!result)
                        {
                            _timerMap.TryRemove(timerId, out TimerSource unusedSource);
                        }
                    }
                }
                return result;
            }
            return false;
        }

        private static void NativeChannelReceiveCallback(IntPtr nativeObject, IntPtr userData)
        {
            int channelId = (int)userData;
            if (_channelMap.TryGetValue(channelId, out ChannelSource channelSource))
            {
                lock (channelSource)
                {
                    if (channelSource.Handle != IntPtr.Zero)
                    {
                        using (var channelObject = new TCoreChannelObject(nativeObject))
                        {
                            var eventArgs = new TCoreChannelReceivedEventArgs(channelObject);
                            channelSource.ChannelReceiver.InvokeEventHandler(null, eventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds the TCoreTask instance.
        /// </summary>
        /// <param name="id">The ID of the TCoreTask.</param>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = TCoreTask.Find("Test");
        /// if (coreTask == null)
        /// {
        ///   coreTask = TCoreTask.Spawn("Test");
        /// }
        /// 
        /// </code>
        /// </example>
        /// <returns>On success the TCoreTask instance, othwerwise null.</returns>
        public static TCoreTask Find(string id)
        {
            if (_coreTaskMap.TryGetValue(id, out TCoreTask task)) { return task; }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.Find(id, out IntPtr handle);
            if (error == Interop.LibTizenCore.ErrorCode.None)
            {
                return new TCoreTask(handle);
            }

            return null;
        }

        /// <summary>
        /// Finds the TCoreTask instance from this thread.
        /// </summary>
        /// <returns>On success the TCoreTask instance, othwerwise null.</returns>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = TCoreTask.FindFromThisThread();
        /// if (coreTask != null)
        /// {
        ///   coreTask.Post(() => {
        ///     Console.WriteLine("Idler invoked");
        ///   });
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public static TCoreTask FindFromThisThread()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.FindFromThisThread(out IntPtr handle);
            if (error == Interop.LibTizenCore.ErrorCode.None)
            {
                return new TCoreTask(handle);
            }

            return null;
        }

        /// <summary>
        /// Creates and Runs the TCoreTask.
        /// </summary>
        /// <param name="id">The ID of the TCoreTask.</param>
        /// <returns>On succes the created TCoreTask instance, othwerwise null.</returns>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = TCoreTask.Spawn("Worker");
        /// if (coreTask != null)
        /// {
        ///   coreTask.AddTimer(5000, () => {
        ///     Console.WriteLine("Timer expired");
        ///     return true;
        ///   });
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public static TCoreTask Spawn(string id)
        {
            if (id == "main")
            {
                Log.Error("Invalid argument. id = {}", id);
                return null;
            }

            var task = new TCoreTask(id);
            task.Run();
            return task;
        }

        /// <summary>
        /// Checks whether the task is running or not.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = new TCoreTask("Runner");
        /// coreTask.Run();
        /// bool running = coreTask.Running;
        /// Console.WriteLine("Runner is {}", running ? "running" : "not running");
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public bool Running {
            get
            {
                Interop.LibTizenCore.TizenCore.TaskIsRunning(_handle, out bool running);
                return running;
            }
        }

        /// <summary>
        /// Runs the main loop of the TCoreTask.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the native handle is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = new TCoreTask("Runner");
        /// coreTask.Run();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Run()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.TaskRun(_handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to run task");
        }

        /// <summary>
        /// Quits the main loop of the TCoreTask.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the native handle is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreTask = new TCoreTask("Runner");
        /// coreTask.Run();
        /// if (coreTask.Running)
        /// {
        ///   coreTask.Quit();
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Quit()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.TaskQuit(_handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to quit task");
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 12 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_handle != IntPtr.Zero)
                    {
                        if (Running)
                        {
                            Quit();
                        }

                        Interop.LibTizenCore.TizenCore.TaskDestroy(_handle);
                        _handle = IntPtr.Zero;
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <since_tize> 12 </since_tize>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal class TimerSource
        {
            public TimerSource(int id, IntPtr handle, Func<bool> handler)
            {
                Id = id;
                Handle = handle;
                Handler = handler;
            }

            public int Id { get; set; }

            public IntPtr Handle { get; set; }

            public Func<bool> Handler { get; set; }
        }

        internal class ChannelSource
        {
            public ChannelSource(int id, IntPtr handle, TCoreChannelReceiver channelReceiver)
            {
                Id = id;
                Handle = handle;
                ChannelReceiver = channelReceiver;
            }

            public int Id { get; set; }

            public IntPtr Handle { get; set; }

            public TCoreChannelReceiver ChannelReceiver { get; set; }
        }

        internal class EventSource
        {
            public EventSource(int id, IntPtr handle, TCoreEvent coreEvent)
            {
                Id = id;
                Handle = handle;
                CoreEvent = coreEvent;
            }

            public int Id { get; set; }

            public IntPtr Handle { get; set; }

            public TCoreEvent CoreEvent { get; set; }
        }
    }
}
