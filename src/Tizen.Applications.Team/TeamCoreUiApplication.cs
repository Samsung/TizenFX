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
using Tizen.NUI;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a base class for Team UI applications that own a NUI <see cref="Window"/> and expose
    /// <see cref="Resumed"/> and <see cref="Paused"/> lifecycle events.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TeamCoreUiApplication : TeamCoreApplication
    {
        public enum WindowMode
        {
            /// <summary>
            /// Opaque
            /// </summary>
            Opaque = 0,
            /// <summary>
            /// Transparent
            /// </summary>
            Transparent = 1
        }
        /// <summary>
        /// Initializes the <see cref="TeamCoreUiApplication"/> class.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TeamCoreUiApplication(TeamCoreBackend backend) : base(backend)
        {
        }

        /// <summary>
        /// Gets the default window of this application.
        /// </summary>
        /// <returns>The default <see cref="Window"/> associated with this application.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window GetDefaultWindow()
        {
            return ((TeamUICoreBackend)Backend).GetDefaultWindow();
        }

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Paused;

        /// <summary>
        /// Occurs before the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler PreCreated;

        /// <summary>
        /// Runs the Team UI application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);

            base.Run(args);
        }

        /// <summary>
        /// Invoked before OnCreate() callback invoked, with default window
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPreCreate()
        {
            PreCreated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invoked when the application is created.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnCreate()
        {
            base.OnCreate();
        }

        /// <summary>
        /// Invoked when the application is resumed. Raises the <see cref="Resumed"/> event.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invoked when the application is paused. Raises the <see cref="Paused"/> event.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }
    }
}
