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

namespace Tizen.Applications.CoreBackend
{
    /// <summary>
    /// An interface that represents the backend lifecycles.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public interface ICoreBackend : IDisposable
    {
        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method without arguments.</param>
        /// <since_tizen> 3 </since_tizen>
        void AddEventHandler(EventType evType, Action handler);

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <typeparam name="TEventArgs">The EventArgs type used in arguments of the handler method.</typeparam>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method with a TEventArgs type argument.</param>
        /// <since_tizen> 3 </since_tizen>
        void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs;

        /// <summary>
        /// Runs the mainloop of the backend.
        /// </summary>
        /// <param name="args"></param>
        /// <since_tizen> 3 </since_tizen>
        void Run(string[] args);

        /// <summary>
        /// Exits the mainloop of the backend.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        void Exit();
    }
}
