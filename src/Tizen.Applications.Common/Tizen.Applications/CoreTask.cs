/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading;
using static Tizen.Applications.TizenSynchronizationContext;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the CoreTask interface.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CoreTask : ICoreTask
    {
        static SynchronizationContext _context;

        /// <summary>
        /// Initializes the CoreTask class. 
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public CoreTask()
        {
        }

        /// <summary>
        /// This method is to handle behavior when the task of the application is created.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnCreate()
        {
            _context = SynchronizationContext.Current;
        }

        /// <summary>
        /// This method is to handle behavior when the task of the application is terminated.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnTerminate()
        {
        }

        /// <summary>
        /// This method is to handle behavior when the task of the application receives the appcontrol message.
        /// </summary>
        /// <param name="e"></param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnLowMemory(LowMemoryEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low battery event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnLowBattery(LowBatteryEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the device orientation is changed.
        /// </summary>
        /// <param name="e">The device orientation changed event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the application is resumed or paused.
        /// </summary>
        /// <param name="e"></param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnUIEvent(UIEventArgs e)
        {
        }

        /// <summary>
        /// Runner callback for dispatching a message to the main loop of the CoreTask.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <since_tizen> 10 </since_tizen>
        public delegate void Runner<T>(T msg);

        /// <summary>
        /// Dispatches an asynchronous message to the main loop of the CoreTask.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="runner"></param>
        /// <param name="msg"></param>
        /// <since_tizen> 10 </since_tizen>
        public void Post<T>(Runner<T> runner, T msg)
        {
            _context.Post((o) => { runner(msg); }, null);
        }
    }
}
