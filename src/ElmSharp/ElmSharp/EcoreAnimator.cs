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
using System.Collections.Generic;

namespace ElmSharp
{
    /// <summary>
    /// EcoreAnimator is a helper class. It provides the functions to manage animations.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class EcoreAnimator
    {
        static readonly Dictionary<int, Func<bool>> _taskMap = new Dictionary<int, Func<bool>>();
        static readonly Object _taskLock = new Object();
        static int _newTaskId = 0;

        static Interop.Ecore.EcoreTaskCallback _nativeHandler;

        static EcoreAnimator()
        {
            _nativeHandler = NativeHandler;
        }

        /// <summary>
        /// Gets the current system time as a floating point value in seconds.
        /// </summary>
        /// <returns>Current system time</returns>
        /// <since_tizen> preview </since_tizen>
        public static double GetCurrentTime()
        {
            return Interop.Ecore.ecore_time_get();
        }

        /// <summary>
        /// Adds an animator to call <paramref name="handler"/> at every animation tick during the main loop execution.
        /// </summary>
        /// <param name="handler">The function to call when it ticks off.</param>
        /// <returns>A handle to the new animator.</returns>
        /// <since_tizen> preview </since_tizen>
        public static IntPtr AddAnimator(Func<bool> handler)
        {
            int id = RegistHandler(handler);
            return Interop.Ecore.ecore_animator_add(_nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Removes the specified animator from the animator list.
        /// </summary>
        /// <param name="anim">The specified animator handle.</param>
        /// <since_tizen> preview </since_tizen>
        public static void RemoveAnimator(IntPtr anim)
        {
            int taskId = (int)Interop.Ecore.ecore_animator_del(anim);
            _taskMap.Remove(taskId);
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

        static bool NativeHandler(IntPtr userData)
        {
            int task_id = (int)userData;
            Func<bool> userAction = null;
            _taskMap.TryGetValue(task_id, out userAction);
            return (userAction != null) ? userAction() : false;
        }

    }
}
