/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.CBApplication;

namespace Tizen.Applications.ComponentBased.Common
{
    internal class BaseFactory : ComponentFactoryBase
    {
        private ComponentBasedApplicationBase _parent;
        private Interop.CBApplication.BaseLifecycleCallbacks _callbacks;

        internal BaseFactory(Type ctype, string id, ComponentType compType, ComponentBasedApplicationBase parent) : base(ctype, id, compType, parent)
        {
            _callbacks.OnDeviceOrientationChanged = new Interop.CBApplication.BaseDeviceOrientationChangedCallback(OnDeviceOrientationChangedCallback);
            _callbacks.OnLanguageChanged = new Interop.CBApplication.BaseLanguageChangedCallback(OnLanguageChangedCallback);
            _callbacks.OnLowBattery = new Interop.CBApplication.BaseLowBatteryCallback(OnLowBatteryCallback);
            _callbacks.OnLowMemory = new Interop.CBApplication.BaseLowMemoryCallback(OnLowMemoryCallback);
            _callbacks.OnRegionFormatChanged = new Interop.CBApplication.BaseRegionFormatChangedCallback(OnRegionFormatChangedCallback);
            _callbacks.OnRestore = new Interop.CBApplication.BaseRestoreCallback(OnRestoreCallback);
            _callbacks.OnSave = new Interop.CBApplication.BaseSaveCallback(OnSaveCallback);
            _callbacks.OnSuspendedState = new Interop.CBApplication.BaseSuspendedStateCallback(OnSuspendedStateCallback);
            _parent = parent;
        }

        internal override IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddComponent(h, (NativeComponentType)_compType, _compId, ref _callbacks, IntPtr.Zero);
        }
    }
}
