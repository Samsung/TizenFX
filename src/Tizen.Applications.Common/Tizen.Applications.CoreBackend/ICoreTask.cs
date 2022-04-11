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

using System.ComponentModel;
using System.Threading;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the CoreTask interface.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICoreTask
    {
        /// <summary>
        /// This method is to handle behavior when the task of the application is created.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        void OnCreate();

        /// <summary>
        /// This method is to handle behavior when the task of the application is terminated.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        void OnTerminate();

        /// <summary>
        /// This method is to handle behavior when the task of the application receives the appcontrol message.
        /// </summary>
        /// <param name="e">The received app control event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnAppControlReceived(AppControlReceivedEventArgs e);

        /// <summary>
        /// This method is to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnLowMemory(LowMemoryEventArgs e);

        /// <summary>
        /// This method is to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low battery event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnLowBattery(LowBatteryEventArgs e);

        /// <summary>
        /// This method is to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnLocaleChanged(LocaleChangedEventArgs e);

        /// <summary>
        /// This method is to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnRegionFormatChanged(RegionFormatChangedEventArgs e);

        /// <summary>
        /// This method is to handle behavior when the device orientation is changed.
        /// </summary>
        /// <param name="e">The device orientation changed event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnDeviceOrientationChanged(DeviceOrientationEventArgs e);

        /// <summary>
        /// This method is to handle behavior when the application is resumed or paused.
        /// </summary>
        /// <param name="e">The UI event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        void OnUIEvent(UIEventArgs e);
    }
}
