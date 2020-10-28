/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Concurrent;

namespace ElmSharp
{
    /// <summary>
    /// EcoreMainloop is a helper class, which provides the functions relative to Ecore's main loop.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class EcoreMainloop
    {

        static readonly ConcurrentDictionary<int, Func<bool>> _taskMap = new ConcurrentDictionary<int, Func<bool>>();
        static readonly Object _taskLock = new Object();
        static int _newTaskId = 0;

        static Interop.Ecore.EcoreTaskCallback _nativeHandler;

        static EcoreMainloop()
        {
            Interop.Ecore.ecore_init();
            Interop.Ecore.ecore_main_loop_glib_integrate();
            _nativeHandler = NativeHandler;
        }

        /// <summary>
        /// Checks if you are calling this function from the main thread.
        /// </summary>
        /// <remarks>True if the calling function is the same thread, false otherwise.</remarks>
        /// <since_tizen> preview </since_tizen>
        public static bool IsMainThread => Interop.Eina.eina_main_loop_is();

        /// <summary>
        /// Runs the application main loop.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void Begin()
        {
            Interop.Ecore.ecore_main_loop_begin();
        }

        /// <summary>
        /// Quits the main loop, once all the events currently on the queue have been processed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void Quit()
        {
            Interop.Ecore.ecore_main_loop_quit();
        }

        /// <summary>
        /// Adds an idler handler.
        /// </summary>
        /// <param name="task">The action to call when idle.</param>
        /// <since_tizen> preview </since_tizen>
        public static void Post(Action task)
        {
            int id = RegistHandler(() => { task(); return false; });
            Interop.Ecore.ecore_idler_add(_nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Calls the callback asynchronously in the main loop.
        /// </summary>
        /// <param name="task">The action wanted to be called.</param>
        /// <since_tizen> preview </since_tizen>
        public static void PostAndWakeUp(Action task)
        {
            if (IsMainThread)
            {
                Post(task);
            }
            else
            {
                int id = RegistHandler(() => { task(); return false; });
                Interop.Ecore.ecore_main_loop_thread_safe_call_async(_nativeHandler, (IntPtr)id);
            }
        }

        /// <summary>
        /// Calls the callback synchronously in the main loop.
        /// </summary>
        /// <param name="task">The action wanted to be called.</param>
        /// <since_tizen> preview </since_tizen>
        public static void Send(Action task)
        {
            int id = RegistHandler(() => { task(); return false; });
            Interop.Ecore.ecore_main_loop_thread_safe_call_sync(_nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Creates a timer to call the given function in the given period of time.
        /// </summary>
        /// <param name="interval">The interval in seconds.</param>
        /// <param name="handler">The given function.</param>
        /// <returns>A timer object handler on success, or null on failure.</returns>
        /// <since_tizen> preview </since_tizen>
        public static IntPtr AddTimer(double interval, Func<bool> handler)
        {
            int id = RegistHandler(handler);
            return Interop.Ecore.ecore_timer_add(interval, _nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Removes the specified timer from the timer list.
        /// </summary>
        /// <param name="id">The specified timer handler</param>
        /// <since_tizen> preview </since_tizen>
        public static void RemoveTimer(IntPtr id)
        {
            int taskId = (int)Interop.Ecore.ecore_timer_del(id);
            Func<bool> unused;
            _taskMap.TryRemove(taskId, out unused);
        }

        static int RegistHandler(Func<bool> task)
        {
            int taskId;
            lock (_taskLock)
            {
                taskId = _newTaskId++;
            }
            _taskMap[taskId] = task;
            return taskId;
        }

        static bool NativeHandler(IntPtr user_data)
        {
            int task_id = (int)user_data;
            Func<bool> userAction = null;
            if (_taskMap.TryGetValue(task_id, out userAction))
            {
                bool result = false;

                if (userAction != null)
                {
                    result = userAction();
                }

                if (!result)
                {
                    _taskMap.TryRemove(task_id, out userAction);
                }
                return result;
            }
            return false;
        }
    }
}
