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
using Tizen.NUI.BaseComponents;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a Team application that provides a default NUI <see cref="View"/>.
    /// </summary>
    /// <remarks>
    /// A view application renders into a shared window supplied by the Team host rather than owning its own window.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TeamViewApplication : TeamCoreApplication
    {
        /// <summary>
        /// Initializes the <see cref="TeamViewApplication"/> class.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TeamViewApplication() : base(new TeamViewCoreBackend())
        {
        }

        /// <summary>
        /// Gets the default view attached to this application.
        /// </summary>
        /// <returns>The default <see cref="View"/> associated with this application.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetDefaultView()
        {
            return ((TeamViewCoreBackend)Backend).GetDefaultView();
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
        /// Runs the Team view application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);

            base.Run(args);
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
