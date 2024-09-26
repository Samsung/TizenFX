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
using System.ComponentModel;

using Tizen.Applications.CoreBackend;
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents an application that has an UI screen. It provides events for handling resume and pause actions.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CoreUIApplication : CoreApplication
    {
        /// <summary>
        /// Initializes the CoreUIApplication class.
        /// </summary>
        /// <remarks>
        /// By calling this constructor, the default backend for the UI application will be used.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
#pragma warning disable CA2000
        public CoreUIApplication() : base(new UICoreBackend())
#pragma warning restore CA2000
        {
        }

        /// <summary>
        /// Initializes the CoreUIApplication class.
        /// </summary>
        /// <remarks>
        /// This constructor is called if you need to modify the default behavior by providing a custom implementation of the ICoreBackend interface. By passing in your own backend instance, you can customize the application's functionality according to your requirements.
        /// </remarks>
        /// <param name="backend">The custom implementation of the ICoreBackend interface that provides customized functionalities.</param>
        /// <since_tizen> 3 </since_tizen>
        public CoreUIApplication(ICoreBackend backend) : base(backend)
        {
        }

        /// <summary>
        /// Gets the current device orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public DeviceOrientation CurrentDeviceOrientation
        {
            get
            {
                return Interop.Application.AppGetDeviceOrientation();
            }
        }

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Paused;

        /// <summary>
        /// Runs the UI application's main loop.
        /// </summary>
        /// <param name="args">Arguments from the commandline.</param>
        /// <since_tizen> 3 </since_tizen>
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);
            base.Run(args);
        }

        /// <summary>
        /// Overrides this method if you want to handle any specific actions before calling the OnCreate() method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPreCreate()
        {
        }

        /// <summary>
        /// Override this method to define the behavior when the application is resumed.
        /// Calling base.OnResume() is required in order for the Resumed event to be raised.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Override this method to define the behavior when the application is paused.
        /// Calling base.OnPause() is required in order for the Paused event to be raised.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the window position of the application.
        /// </summary>
        /// <returns>The window position.</returns>
        /// <exception cref="InvalidOperationException">Thrown if there is no valid window position available.</exception>
        /// <since_tizen> 11 </since_tizen>
        public WindowPosition GetWindowPosition()
        {
            ErrorCode err = Interop.Application.GetWindowPosition(out int x, out int y, out int w, out int h);
            if (err != ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to get window position");
            }

            return new WindowPosition(x, y, w, h);
        }
    }
}
