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

using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents an application that has an UI screen. The events for resuming and pausing are provided.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CoreUIApplication : CoreApplication
    {
        /// <summary>
        /// Initializes the CoreUIApplication class.
        /// </summary>
        /// <remarks>
        /// The default backend for the UI application will be used.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public CoreUIApplication() : base(new UICoreBackend())
        {
        }

        /// <summary>
        /// Initializes the CoreUIApplication class.
        /// </summary>
        /// <remarks>
        /// If you want to change the backend, use this constructor.
        /// </remarks>
        /// <param name="backend">The backend instance implementing the ICoreBacked interface.</param>
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
        /// Overrides this method if you want to handle the behavior before calling OnCreate().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPreCreate()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the application is resumed.
        /// If base.OnResume() is not called, the event 'Resumed' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the application is paused.
        /// If base.OnPause() is not called, the event 'Paused' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }
    }
}
