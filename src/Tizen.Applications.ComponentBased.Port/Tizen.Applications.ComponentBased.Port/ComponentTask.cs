/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.Collections.Generic;
using System.Threading;

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// Provides a task class for the ComponentPort class.
    /// This is a convenience class to manage ComponentPort communication in a separate thread.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ComponentTask
    {
        private Thread _thread;
        private object _threadLock = new object();
        private static List<ComponentTask> _holder = new List<ComponentTask>();

        /// <summary>
        /// Initializes the instance of the ComponentTask class.
        /// </summary>
        /// <param name="port">The component port object</param>
        /// <since_tizen> 9 </since_tizen>
        public ComponentTask(ComponentPort port)
        {
            Port = port;
        }

        private void OnThread()
        {
            lock (_holder)
            {
                _holder.Add(this);
            }

            IsRunning = true;
            Port?.WaitForEvent();
            IsRunning = false;

            lock (_holder)
            {
                _holder.Remove(this);
            }
        }

        /// <summary>
        /// Starts the task.
        /// <remark>
        /// This method calls ComponentPort.WaitForEvent() in the thread.
        /// </remark>
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Start()
        {
            lock (_threadLock)
            {
                if (_thread == null)
                {
                    _thread = new Thread(new ThreadStart(OnThread));
                    _thread.Start();
                    IsRunning = true;
                }
            }
        }

        /// <summary>
        /// Stops the task.
        /// </summary>
        /// <remarks>
        /// This method calls ComponentPort.Cancel() before stopping the thread.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public void Stop()
        {
            lock (_threadLock)
            {
                if (_thread != null)
                {
                    Port?.Cancel();
                    _thread.Join();
                    _thread = null;
                }
            }
        }

        /// <summary>
        /// Checks whether the component task is running.
        /// </summary>
        /// <value>If the task is running, true; otherwise, false</value>
        /// <since_tizen> 9 </since_tizen>
        public bool IsRunning
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the component port.
        /// </summary>
        /// <value>The instance of the component port</value>
        /// <since_tizen> 9 </since_tizen>
        public ComponentPort Port
        {
            get;
            private set;
        }
    }
}
