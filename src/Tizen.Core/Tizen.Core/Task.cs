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
    /// Represents the task used for creating, running and terminating the thread with the main loop. 
    /// The state of the task can be changed as follows: Constructed -> Running -> Terminated. 
    /// To start the task, use 'Task.Run()' method. Once started, the task enters into 'Running' state. To terminate the task, use 'Task.Quit()' method. 
    /// After termination, the task returns back to 'Constructed' state.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class Task : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private static readonly ConcurrentDictionary<string, Task> _coreTaskMap = new ConcurrentDictionary<string, Task>();
        private static readonly ConcurrentDictionary<int, Func<System.Threading.Tasks.Task>> _taskMap = new ConcurrentDictionary<int, Func<System.Threading.Tasks.Task>>();
        private static readonly ConcurrentDictionary<int, Action> _actionkMap = new ConcurrentDictionary<int, Action>();
        private static readonly ConcurrentDictionary<int, TimerSource> _timerMap = new ConcurrentDictionary<int, TimerSource>();
        private static readonly ConcurrentDictionary<int, ChannelReceiver> _channelMap = new ConcurrentDictionary<int, ChannelReceiver>();
        private static readonly ConcurrentDictionary<int, Event> _eventMap = new ConcurrentDictionary<int, Event>(); 
        private static Object _idLock = new Object();
        private static int _id = 1;
        private static Interop.LibTizenCore.TizenCore.TaskCallback _nativeTaskHandler = new Interop.LibTizenCore.TizenCore.TaskCallback(NativeTaskCallback);
        private static Interop.LibTizenCore.TizenCore.TaskCallback _nativeActionHandler = new Interop.LibTizenCore.TizenCore.TaskCallback(NativeActionCallback);
        private static Interop.LibTizenCore.TizenCore.TaskCallback _nativeTimerHandler = new Interop.LibTizenCore.TizenCore.TaskCallback(NativeTimerCallback);
        private static Interop.LibTizenCore.TizenCore.ChannelReceiveCallback _nativeChannelReceiveHandler = new Interop.LibTizenCore.TizenCore.ChannelReceiveCallback(NativeChannelReceiveCallback);

        /// <summary>
        /// Initializes the Task class with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier for the task.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="id"/> is invalid or a Task with that ID already exists.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <remarks>
        /// The constructor throws an exception when the ID already exists.
        /// By default, the task creates a separate thread. However, if the <paramref name="id"/> is set to "main", no separate thread is created.
        /// In such case, the 'main' task will operate on the main application thread instead.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// TizenCore.Initialize();
        /// var task = new Task("Worker");
        /// task.Run();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public Task(string id)
        {
            bool useThread = (id == "main") ? false : true;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.TaskCreate(id, useThread, out  _handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to create task");
            _coreTaskMap[id] = this;
        }

        internal Task(IntPtr handle)
        {
            _handle = handle;
            _disposed = true;
        }

        /// <summary>
        /// Finalizes the Task class.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        ~Task()
        {
             Dispose(false);
        }

        /// <summary>
        /// Posts an action to be executed later.
        /// </summary>
        /// <param name="action">The action callback to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when the action argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <remarks>
        /// The action callback will be executed by the main loop of the task.
        /// If there was any error during this process, an appropriate exception will be thrown.
        /// In order to prevent the <paramref name="action"/> from throwing an exception, you should add a try/catch block. If not, it may cause the application to crash or terminate.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var task = TizenCore.Find("Test") ?? TizenCore.Spawn("Test");
        /// task.Post(() =>
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
                if (_id + 1 < 0) _id = 1;
                id = _id++;
            }
            _actionkMap[id] = action;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddIdleJob(_handle, _nativeActionHandler, (IntPtr)id, out IntPtr handle);
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                if (error == Interop.LibTizenCore.ErrorCode.InvalidParameter)
                {
                    error = Interop.LibTizenCore.ErrorCode.InvalidContext;
                }
                TCoreErrorFactory.CheckAndThrownException(error, "Failed to add idle job");
            }
        }

        /// <summary>
        /// Posts a task to be executed later.
        /// </summary>
        /// <param name="task">The task to post.</param>
        /// <exception cref="ArgumentNullException">Thrown when the task argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <remarks>
        /// The task will be stored in the internal map using its unique identifier.
        /// Then it will be added as an idle job to the main loop of the task.
        /// If there was any error during this process, the task will be removed from the map and an appropriate exception will be thrown.
        /// In order to prevent the <paramref name="task"/> from throwing an exception, you should add a try/catch block. If not, it may cause the application to crash or terminate.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var channel = new Channel();
        /// var task = TizenCore.Find("Sender") ?? TizenCore.Spawn("Sender");
        /// 
        /// int id = 0;
        /// task.Post(async () =>
        /// {
        ///   var channelObject = await channel.Receiver.Receive();
        ///   var message = (string)channelObject.Data;
        ///   Console.WriteLine("Received message = " + message);
        /// });
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Post(Func<System.Threading.Tasks.Task> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            int id;
            lock (_idLock)
            {
                if (_id + 1 < 0) _id = 1;
                id = _id++;
            }
            _taskMap[id] = task;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddIdleJob(_handle, _nativeTaskHandler, (IntPtr)id, out IntPtr handle);
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                _taskMap.TryRemove(id, out var _);
                if (error == Interop.LibTizenCore.ErrorCode.InvalidParameter)
                {
                    error = Interop.LibTizenCore.ErrorCode.InvalidContext;
                }
                TCoreErrorFactory.CheckAndThrownException(error, "Failed to add idle job");
            }            
        }

        /// <summary>
        /// Adds a recurring timer to a main loop of the task.
        /// </summary>
        /// <param name="interval">The interval of the timer in milliseconds.</param>
        /// <param name="callback">The recurring timer callback function which returns whether or not to continue triggering the timer.</param>
        /// <returns>The registered timer ID to be used with <see cref="RemoveTimer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the callback argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <remarks>
        /// The callback function will be called every time the specified interval elapses. It should return true to keep the timer running, otherwise the timer will be stopped.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var task = TizenCore.Find("TimerTask") ?? TizenCore.Spawn("TimerTask");
        /// var timerId = task.AddTimer(1000, () => {
        ///   Console.WriteLine("Timer callback is invoked");
        ///   return true;
        /// });
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public int AddTimer(uint interval, Func<bool> callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            int id;
            lock (_idLock)
            {
                if (_id + 1 < 0) _id = 1;
                id = _id++;
            }
            var timerSource = new TimerSource(id, IntPtr.Zero, callback);
            _timerMap[id] = timerSource;
            lock (timerSource)
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddTimer(_handle, interval, _nativeTimerHandler, (IntPtr)id, out IntPtr handle);
                if (error != Interop.LibTizenCore.ErrorCode.None)
                {
                    _timerMap.TryRemove(id, out var _);
                    throw new InvalidOperationException("Failed to add timer");
                }

                timerSource.Handle = handle;
            }
            return id;
        }

        /// <summary>
        /// Removes the registered timer from the main loop of the task.
        /// If the specified timer was already stopped, no action occurs.
        /// </summary>
        /// <param name="id">The registered timer ID.</param>
        /// <example>
        /// <code>
        /// 
        /// var task = TizenCore.Find("TimerTask") ?? TizenCore.Spawn("TimerTask");
        /// var timerId = task.AddTimer(1000, () => {
        ///   Console.WriteLine("Timer handler is invoked");
        ///   return true;
        /// });
        /// ...
        /// task.RemoveTimer(timerId);
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
        /// Adds a channel receiver to a main loop of the task.
        /// </summary>
        /// <param name="receiver">The channel receiver instance that needs to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// In the following code snippet, we create a channel, find or spawn a task named "ReceivingTask", and then add the channel receiver to the task's main loop by calling the 'AddChannelReceiver' method.
        ///
        /// <code>
        /// 
        /// var channel = new Channel();
        /// var task = TizenCore.Find("ReceivingTask") ?? TizenCore.Spawn("ReceivingTask");
        /// var receiver = channel.Receiver;
        /// receiver.Received += (sender, args) => {
        ///   Console.WriteLine("OnChannelMessageReceived. Message = " + (string)args.Data);
        /// };
        /// task.AddChannelReceiver(receiver);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void AddChannelReceiver(ChannelReceiver receiver)
        {
            if (receiver == null) { throw new ArgumentNullException(nameof(receiver)); }

            if (receiver.Handle == IntPtr.Zero)
            {
                if (receiver.Source != IntPtr.Zero)
                {
                    throw new ArgumentException("The receiver is already added");
                }

                throw new ArgumentException("Invalid argument");
            }

            int id;
            lock (_idLock)
            {
                if (_id + 1 < 0) _id = 1;
                id = _id++;
            }
            receiver.Id = id;
            _channelMap[id] = receiver;
            lock (receiver)
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddChannel(_handle, receiver.Handle, _nativeChannelReceiveHandler, (IntPtr)id, out IntPtr handle);
                if (error != Interop.LibTizenCore.ErrorCode.None)
                {
                    _channelMap.TryRemove(id, out var _);
                    if (error == Interop.LibTizenCore.ErrorCode.InvalidParameter)
                    {
                        error = Interop.LibTizenCore.ErrorCode.InvalidContext;
                    }
                    TCoreErrorFactory.CheckAndThrownException(error, "Failed to add a channel to the task");
                }

                receiver.Source = handle;
                receiver.Handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Removes the registered channel receiver from the main loop of the task.
        /// </summary>
        /// <param name="receiver">The channel receiver instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <example>
        /// <code>
        /// 
        /// var channel = new Channel();
        /// var task = TizenCore.Find("ReceivingTask") ?? TizenCore.Spawn("ReceivingTask");
        /// var receiver = channel.Receiver;
        /// receiver.Received += (sender, args) => {
        ///   Console.WriteLine("OnChannelMessageReceived. Message = " + (string)args.Data);
        /// };
        /// 
        /// task.AddChannelReceiver(receiver);
        /// task.RemoveChannelReceiver(receiver);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void RemoveChannelReceiver(ChannelReceiver receiver)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException(nameof(receiver));
            }

            if (receiver.Id == 0 || receiver.Source == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid argument");
            }

            if (_channelMap.TryRemove(receiver.Id, out var _))
            {
                lock (receiver)
                {
                    if (receiver.Source != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCore.RemoveSource(_handle, receiver.Source);
                        receiver.Source = IntPtr.Zero;
                        receiver.Id = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Adds an event to a main loop of the task.
        /// If the event is successfully added, its unique identifier is assigned to the event. The identifier can then be used later to identify the specific event among others. 
        /// </summary>
        /// <param name="coreEvent">The event instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <remarks>
        /// This method allows you to associate an event with a specific task. By adding an event to a task's main loop, other threads can utilize this event to communicate with the task.
        /// However, note that once an event is attached to a task, it cannot be reused or attached to another task. 
        /// If the argument passed to this method is null, an exception will be thrown. Additionally, if the event has been previously added, an argument exception will be raised.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new Event();
        /// coreEvent.EventReceived += (sender, args) => {
        ///   Console.WriteLine("OnEventReceived. ID = {}, Message = {}", args.Id, (string)args.Data);
        /// };
        /// 
        /// var task = TizenCore.Find("EventTask") ?? TizenCore.Spawn("EventTask");
        /// task.AddEvent(coreEvent);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void AddEvent(Event coreEvent)
        {
            if (coreEvent == null)
            {
                throw new ArgumentNullException(nameof(coreEvent));
            }

            if (coreEvent.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid argument");
            }

            if (coreEvent.Source != IntPtr.Zero)
            {
                throw new ArgumentException("The event is already added");
            }

            int id;
            lock (_idLock)
            {
                if (_id + 1 < 0)
                {
                    _id = 1;
                }
                id = _id++;
            }
            coreEvent.Id = id;
            _eventMap[id] = coreEvent;
            lock (coreEvent)
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.AddEvent(_handle, coreEvent.Handle, out IntPtr handle);
                if (error != Interop.LibTizenCore.ErrorCode.None)
                {
                    _eventMap.TryRemove(id, out var _);
                    if (error == Interop.LibTizenCore.ErrorCode.InvalidParameter)
                    {
                        error = Interop.LibTizenCore.ErrorCode.InvalidContext;
                    }
                    TCoreErrorFactory.CheckAndThrownException(error, "Failed to add an event to the task");
                }

                coreEvent.Source = handle;
            }
        }

        /// <summary>
        /// Removes the registered event from the main loop of the task.
        /// </summary>
        /// <param name="coreEvent">The event instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new Event();
        /// coreEvent.EventReceived += (sender, args) => {
        ///   Console.WriteLine("OnEventReceived. ID = {}, Message = {}", args.Id, (string)args.Data);
        /// };
        /// 
        /// var task = TizenCore.Find("EventTask") ?? TizenCore.Spawn("EventTask");
        /// task.AddEvent(coreEvent);
        /// task.RemoveEvent(coreEvent);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void RemoveEvent(Event coreEvent)
        {
            if (coreEvent == null)
            {
                throw new ArgumentNullException(nameof(coreEvent));
            }

            if (coreEvent.Id == 0 || coreEvent.Source == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid argument");
            }

            if (_eventMap.TryRemove(coreEvent.Id, out var _))
            {
                lock (coreEvent)
                {
                    if (coreEvent.Source != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCore.RemoveSource(_handle, coreEvent.Source);
                        coreEvent.Source = IntPtr.Zero;
                        coreEvent.Id = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Emits the event object to all registered event handlers of the task. 
        /// It's similar to Event.Emit(), but EmitAllEvent() sends the event object to every event handler of the task while Event.Emit() sends the event object only to the target event's event handler.
        /// </summary>
        /// <param name="eventObject">The event object instance to be sent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// <code>
        /// 
        /// int id = 0;
        /// string message = "Test Event";
        /// using (var eventObject = new TCoreEventObject(id++, message))
        /// {
        ///   var task = TizenCore.Find("EventTask") ?? TizenCore.Spawn("EventTask");
        ///   task.EmitEvent(eventObject);
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void EmitEvent(EventObject eventObject)
        {
            if (eventObject == null)
            {
                throw new ArgumentNullException(nameof(eventObject));
            }

            if (eventObject.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid argument");
            }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.EmitEvent(_handle, eventObject.Handle);
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to emit event");
            }

            eventObject.Handle = IntPtr.Zero;
        }

        private static bool NativeTaskCallback(IntPtr userData)
        {
            int taskId = (int)userData;
            if (_taskMap.TryRemove(taskId, out Func<System.Threading.Tasks.Task> task))
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
            if (_channelMap.TryGetValue(channelId, out ChannelReceiver receiver))
            {
                lock (receiver)
                {
                    if (receiver.Source != IntPtr.Zero)
                    {
                        using (var channelObject = new ChannelObject(nativeObject))
                        {
                            var eventArgs = new ChannelReceivedEventArgs(channelObject);
                            receiver.InvokeEventHandler(null, eventArgs);
                            channelObject.IsDestroyable = false;
                        }
                    }
                }
            }
        }

        internal static Task Find(string id)
        {
            if (_coreTaskMap.TryGetValue(id, out Task task)) { return task; }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.Find(id, out IntPtr handle);
            if (error == Interop.LibTizenCore.ErrorCode.None)
            {
                return new Task(handle);
            }

            return null;
        }

        internal static Task Spawn(string id)
        {
            if (id == "main")
            {
                Log.Error("Invalid argument. id = {}", id);
                return null;
            }

            try
            {
                var task = new Task(id);
                task.Run();
                return task;
            }
            catch (ArgumentException)
            {
                Log.Error("ArgumentException occurs");
            }
            catch (OutOfMemoryException)
            {
                Log.Error("OutOfMemoryException occurs");
            }
            catch (InvalidOperationException)
            {
                Log.Error("InvalidOperationException occurs");
            }

            return null;
        }

        /// <summary>
        /// Checks whether the task is running or not.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public bool Running {
            get
            {
                Interop.LibTizenCore.TizenCore.TaskIsRunning(_handle, out bool running);
                return running;
            }
        }

        /// <summary>
        /// Runs the main loop of the task.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// Here's an example that demonstrates how to create a Core Task and run its main loop:
        /// <code>
        /// // Create a Core Task named "Runner"
        /// var coreTask = new TCoreTask("Runner");
        /// 
        /// // Start the main loop of the task
        /// coreTask.Run();
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Run()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.TaskRun(_handle);
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to run task");
            }
        }

        /// <summary>
        /// Quits the main loop of the task.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <remarks>
        /// This function can be called from any thread.
        /// It requests the task to finish the current iteration of its loop and stop running.
        /// All pending events in the event queue will be processed before quitting. Once the task quits, it's finished.
        /// To start another task, you need to create a new one and call the <see cref="Run"/> method on it.
        /// </remarks>
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
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to quit task");
            }
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
    }
}
