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

namespace Tizen.Applications.ComponentBased.Common
{
    internal class ServiceComponentStateManager : ComponentStateManger
    {
        private Interop.CBApplication.ServiceLifecycleCallbacks _callbacks;

        internal ServiceComponentStateManager(Type ctype, string id, ComponentBasedApplication parent) : base(ctype, id, parent)
        {
            _callbacks.OnAction = new Interop.CBApplication.ServiceActionCallback(OnActionCallback);
            _callbacks.OnDeviceOrientationChanged = new Interop.CBApplication.ServiceDeviceOrientationChangedCallback(OnDeviceOrientationChangedCallback);
            _callbacks.OnLanguageChanged = new Interop.CBApplication.ServiceLanguageChangedCallback(OnLanguageChangedCallback);
            _callbacks.OnLowBattery = new Interop.CBApplication.ServiceLowBatteryCallback(OnLowBatteryCallback);
            _callbacks.OnLowMemory = new Interop.CBApplication.ServiceLowMemoryCallback(OnLowMemoryCallback);
            _callbacks.OnRegionFormatChanged = new Interop.CBApplication.ServiceRegionFormatChangedCallback(OnRegionFormatChangedCallback);
            _callbacks.OnRestore = new Interop.CBApplication.ServiceRestoreCallback(OnRestoreCallback);
            _callbacks.OnSave = new Interop.CBApplication.ServiceSaveCallback(OnSaveCallback);
            _callbacks.OnSuspendedState = new Interop.CBApplication.ServiceSuspendedStateCallback(OnSuspendedStateCallback);
            _callbacks.OnCreate = new Interop.CBApplication.ServiceCreateCallback(OnCreateCallback);
            _callbacks.OnDestroy = new Interop.CBApplication.ServiceDestroyCallback(OnDestroyCallback);
            _callbacks.OnStart = new Interop.CBApplication.ServiceStartCommandCallback(OnStartCallback);
            Parent = parent;
        }

        private bool OnCreateCallback(IntPtr context, IntPtr userData)
        {
            ServiceComponent sc = Activator.CreateInstance(ComponentClassType) as ServiceComponent;
            if (sc == null)
                return false;

            string id;
            Interop.CBApplication.GetInstanceId(context, out id);
            sc.Bind(context, ComponentId, id, Parent);

            if (!sc.OnCreate())
            {
                return false;
            }

            AddComponent(sc);
            return true;
        }

        private void OnStartCallback(IntPtr context, IntPtr appControl, bool restarted, IntPtr userData)
        {
            foreach (ServiceComponent sc in Instances)
            {
                if (sc.Handle == context)
                {
                    SafeAppControlHandle handle = new SafeAppControlHandle(appControl, false);
                    AppControl control = new AppControl(handle);
                    sc.OnStartCommand(control, restarted);
                    break;
                }
            }
        }

        private void OnDestroyCallback(IntPtr context, IntPtr userData)
        {
            foreach (ServiceComponent sc in Instances)
            {
                if (sc.Handle == context)
                {
                    sc.OnDestroy();
                    RemoveComponent(sc);
                    break;
                }
            }
            return;
        }

        private void OnActionCallback(IntPtr context, string action, IntPtr appControl, IntPtr userData)
        {
        }

        internal override IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddServiceComponent(h, ComponentId, ref _callbacks, IntPtr.Zero);
        }
    }
}
