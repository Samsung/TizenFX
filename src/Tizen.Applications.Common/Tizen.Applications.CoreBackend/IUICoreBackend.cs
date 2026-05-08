/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications.CoreBackend
{
    /// <summary>
    /// Defines the common contract for NUI-based application backends.
    /// </summary>
    /// <remarks>
    /// This interface abstracts the shared functionality between <c>NUICoreBackend</c>
    /// and <c>TeamUICoreBackend</c>, enabling polymorphic access to event handler registration.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IUICoreBackend : IDisposable
    {
        /// <summary>
        /// Adds an event handler for the specified event type.
        /// </summary>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method without arguments.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void AddEventHandler(EventType evType, Action handler);

        /// <summary>
        /// Adds an event handler for the specified event type with typed event arguments.
        /// </summary>
        /// <typeparam name="TEventArgs">The <see cref="EventArgs"/> type used in the handler method.</typeparam>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method with a <typeparamref name="TEventArgs"/> type argument.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs;
    }
}