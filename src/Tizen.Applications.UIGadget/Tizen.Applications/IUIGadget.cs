﻿/*
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
        object MainView { get; set; }

        string ClassName { get; set; }

        UIGadgetInfo UIGadgetInfo { get; set; }

        UIGadgetResourceManager UIGadgetResourceManager { get; set; }

        UIGadgetLifecycleState State { get; set; }

        event EventHandler<UIGadgetLifecycleChangedEventArgs> LifecycleChanged;

        void HandleAppControlReceivedEvent(AppControlReceivedEventArgs args);

        void HandleLocaleChangedEvent(LocaleChangedEventArgs args);

        void HandleRegionFormatChangedEvent(RegionFormatChangedEventArgs args);

        void HandleLowMemoryEvent(LowMemoryEventArgs args);

        void HandleLowBatteryEvent(LowBatteryEventArgs args);

        void HandleDeviceOrientationChangedEvent(DeviceOrientationEventArgs args);

        void PreCreate();

        bool Create();

        void Resume();

        void Pause();

        void Destroy();

        void Finish();

        void SendMessage(Bundle message);
    }
}
