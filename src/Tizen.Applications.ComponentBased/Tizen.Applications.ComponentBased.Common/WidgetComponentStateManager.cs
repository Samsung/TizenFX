/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;

namespace Tizen.Applications.ComponentBased.Common
{
    internal class WidgetComponentStateManager : ComponentStateManger
    {
        private Interop.CBApplication.WidgetLifecycleCallbacks _callbacks;
        private const string LogTag = "Tizen.Applications";
        private IDictionary<string, IWindowProxy> _winDic = new Dictionary<string, IWindowProxy>();

        internal WidgetComponentStateManager(Type ctype, string id, ComponentBasedApplication parent) : base(ctype, id, parent)
        {
            _callbacks.OnDeviceOrientationChanged = new Interop.CBApplication.WidgetDeviceOrientationChangedCallback(OnDeviceOrientationChangedCallback);
            _callbacks.OnLanguageChanged = new Interop.CBApplication.WidgetLanguageChangedCallback(OnLanguageChangedCallback);
            _callbacks.OnLowBattery = new Interop.CBApplication.WidgetLowBatteryCallback(OnLowBatteryCallback);
            _callbacks.OnLowMemory = new Interop.CBApplication.WidgetLowMemoryCallback(OnLowMemoryCallback);
            _callbacks.OnRegionFormatChanged = new Interop.CBApplication.WidgetRegionFormatChangedCallback(OnRegionFormatChangedCallback);
            _callbacks.OnRestore = new Interop.CBApplication.WidgetRestoreCallback(OnRestoreCallback);
            _callbacks.OnSave = new Interop.CBApplication.WidgetSaveCallback(OnSaveCallback);
            _callbacks.OnSuspendedState = new Interop.CBApplication.WidgetSuspendedStateCallback(OnSuspendedStateCallback);
            _callbacks.OnCreate = new Interop.CBApplication.WidgetCreateCallback(OnCreateCallback);
            _callbacks.OnDestroy = new Interop.CBApplication.WidgetDestroyCallback(OnDestroyCallback);
            _callbacks.OnPause = new Interop.CBApplication.WidgetPauseCallback(OnPauseCallback);
            _callbacks.OnResume = new Interop.CBApplication.WidgetResumeCallback(OnResumeCallback);
            _callbacks.OnStart = new Interop.CBApplication.WidgetStartCallback(OnStartCallback);
            _callbacks.OnStop = new Interop.CBApplication.WidgetStopCallback(OnStopCallback);
            Parent = parent;
        }

        private IntPtr OnCreateCallback(IntPtr context, int width, int height, IntPtr userData)
        {
            WidgetComponent fc = Activator.CreateInstance(ComponentClassType) as WidgetComponent;
            if (fc == null)
            {
                Log.Error(LogTag, "Fail to create instance");
                return IntPtr.Zero;
            }

            string id;
            Interop.CBApplication.GetInstanceId(context, out id);
            fc.Bind(context, ComponentId, id, Parent);

            IntPtr winHandle;
            IWindowProxy win = fc.CreateWindowInfo(width, height);
            if (win == null)
                return IntPtr.Zero;

            win.InitializeWindow(width, height);
            _winDic.Add(id, win);
            if (!fc.OnCreate(width, height))
            {
                Log.Error(LogTag, "OnCreate fail");
                return IntPtr.Zero;
            }
            Interop.CBApplication.BaseWidgetCreateWindow(out winHandle, win.ResourceId, IntPtr.Zero);

            AddComponent(fc);
            return winHandle;
        }

        private void OnStartCallback(IntPtr context, bool restarted, IntPtr userData)
        {
            foreach (WidgetComponent fc in Instances)
            {
                if (fc.Handle == context)
                {
                    fc.OnStart(restarted);
                    break;
                }
            }
        }

        private void OnResumeCallback(IntPtr context, IntPtr userData)
        {
            foreach (WidgetComponent fc in Instances)
            {
                if (fc.Handle == context)
                {
                    fc.OnResume();
                    break;
                }
            }
        }

        private void OnPauseCallback(IntPtr context, IntPtr userData)
        {
            foreach (WidgetComponent fc in Instances)
            {
                if (fc.Handle == context)
                {
                    fc.OnPause();
                    break;
                }
            }
        }

        private void OnStopCallback(IntPtr context, IntPtr userData)
        {
            foreach (WidgetComponent fc in Instances)
            {
                if (fc.Handle == context)
                {
                    fc.OnStop();
                    break;
                }
            }
        }

        private void OnDestroyCallback(IntPtr context, bool permanent, IntPtr userData)
        {
            foreach (WidgetComponent fc in Instances)
            {
                if (fc.Handle == context)
                {
                    fc.OnDestroy(permanent);
                    _winDic[fc.Id].Dispose();
                    RemoveComponent(fc);
                    break;
                }
            }
            return;
        }

        internal override IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddWidgetComponent(h, ComponentId, ref _callbacks, IntPtr.Zero);
        }
    }
}
