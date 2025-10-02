/*
* Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// An interface that make the UIGadget object.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IUIGadget
    {
        /// <summary>
        /// The main view of the gadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        object MainView { get; set; }

        /// <summary>
        /// The class name of the gadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        string ClassName { get; set; }

        /// <summary>
        /// The information of the gadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        UIGadgetInfo UIGadgetInfo { get; set; }

        /// <summary>
        /// The resource manager of the gadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        UIGadgetResourceManager UIGadgetResourceManager { get; set; }

        /// <summary>
        /// The state of the gadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        UIGadgetLifecycleState State { get; set; }

        /// <summary>
        /// Occurs when the lifecycle of the UIGadget is changed.
        /// </summary>
        /// <remarks>
        /// This event should be raised when the state of UIGadget changes.
        /// It provides information about the current state through the UIGadgeteLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        event EventHandler<UIGadgetLifecycleChangedEventArgs> LifecycleChanged;

        /// <summary>
        /// Overrides this method if want to handle behavior when the UIGadget receives the appcontrol message.
        /// </summary>
        /// <remarks>
        /// This method provides a way to customize the response when the UIGadget receives an appcontrol message.
        /// By overriding this method in your derived class, you can define specific actions based on the incoming arguments.
        /// </remarks>
        /// <param name="e">The appcontrol received event argument containing details about the received message.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnAppControlReceived(AppControlReceivedEventArgs e);

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnLocaleChanged(LocaleChangedEventArgs e);

        /// <summary>
        /// Overrides this method if want to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnRegionFormatChanged(RegionFormatChangedEventArgs e);

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnLowMemory(LowMemoryEventArgs e);

        /// <summary>
        /// Overrides this method if want to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low batter event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnLowBattery(LowBatteryEventArgs e);

        /// <summary>
        /// Overrides this method if want to handle behavior when the device orientation is changed.
        /// </summary>
        /// <param name="e">The device orientation changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnDeviceOrientationChanged(DeviceOrientationEventArgs e);

        /// <summary>
        /// Overrides this method if want to handle behavior when the message is received.
        /// </summary>
        /// <param name="e">The message received event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        void OnMessageReceived(UIGadgetMessageReceivedEventArgs e);

        /// <summary>
        /// Override this method to define the behavior when the UIGadget is pre-created.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        void OnPreCreate();

        /// <summary>
        /// Override this method to define the behavior when the UIGadget is created.
        /// </summary>
        /// <returns>The main view object.</returns>
        /// <since_tizen> 13 </since_tizen>
        object OnCreate();

        /// <summary>
        /// Overrides this method if want to handle behavior when the UIGadget is resumed.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        void OnResume();

        /// <summary>
        /// Overrides this method if want to handle behavior when the UIGadget is paused.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        void OnPause();

        /// <summary>
        /// Override this method to handle the behavior when the UIGadget is destroyed.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        void OnDestroy();

        /// <summary>
        /// Finishes the UIGadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        void Finish();

        /// <summary>
        /// Sends the message to the UIGadget.
        /// The message should be delived to the OnMessageReceived() method.
        /// </summary>
        /// <param name="message">The message</param>
        /// <since_tizen> 13 </since_tizen>
        void SendMessage(Bundle message);
    }
}
