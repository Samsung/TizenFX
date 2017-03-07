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

using Tizen.Internals.Errors;

namespace Tizen.Applications.CoreBackend
{
    internal class ServiceCoreBackend : DefaultCoreBackend
    {
        private Interop.Service.ServiceAppLifecycleCallbacks _callbacks;
        private IntPtr _lowMemoryEventHandle = IntPtr.Zero;
        private IntPtr _lowBatteryEventHandle = IntPtr.Zero;
        private IntPtr _localeChangedEventHandle = IntPtr.Zero;
        private IntPtr _regionChangedEventHandle = IntPtr.Zero;
        private bool _disposedValue = false;
        private Interop.Service.AppEventCallback _onLowMemoryNative;
        private Interop.Service.AppEventCallback _onLowBatteryNative;
        private Interop.Service.AppEventCallback _onLocaleChangedNative;
        private Interop.Service.AppEventCallback _onRegionChangedNative;

        public ServiceCoreBackend()
        {
            _callbacks.OnCreate = new Interop.Service.ServiceAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Service.ServiceAppTerminateCallback(OnTerminateNative);
            _callbacks.OnAppControl = new Interop.Service.ServiceAppControlCallback(OnAppControlNative);

            _onLowMemoryNative = new Interop.Service.AppEventCallback(OnLowMemoryNative);
            _onLowBatteryNative = new Interop.Service.AppEventCallback(OnLowBatteryNative);
            _onLocaleChangedNative = new Interop.Service.AppEventCallback(OnLocaleChangedNative);
            _onRegionChangedNative = new Interop.Service.AppEventCallback(OnRegionChangedNative);
        }

        public override void Exit()
        {
            Interop.Service.Exit();
        }

        public override void Run(string[] args)
        {
            base.Run(args);

            ErrorCode err = ErrorCode.None;
            err = Interop.Service.AddEventHandler(out _lowMemoryEventHandle, AppEventType.LowMemory, _onLowMemoryNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowMemory event. Err = " + err);
            }
            err = Interop.Service.AddEventHandler(out _lowBatteryEventHandle, AppEventType.LowBattery, _onLowBatteryNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowBattery event. Err = " + err);
            }

            err = Interop.Service.AddEventHandler(out _localeChangedEventHandle, AppEventType.LanguageChanged, _onLocaleChangedNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LocaleChanged event. Err = " + err);
            }

            err = Interop.Service.AddEventHandler(out _regionChangedEventHandle, AppEventType.RegionFormatChanged, _onRegionChangedNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for RegionFormatChanged event. Err = " + err);
            }

            err = Interop.Service.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Release disposable objects
                }

                if (_lowMemoryEventHandle != IntPtr.Zero)
                {
                    Interop.Service.RemoveEventHandler(_lowMemoryEventHandle);
                }
                if (_lowBatteryEventHandle != IntPtr.Zero)
                {
                    Interop.Service.RemoveEventHandler(_lowBatteryEventHandle);
                }
                if (_localeChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Service.RemoveEventHandler(_localeChangedEventHandle);
                }
                if (_regionChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Service.RemoveEventHandler(_regionChangedEventHandle);
                }

                _disposedValue = true;
            }
        }

        private bool OnCreateNative(IntPtr data)
        {
            if (Handlers.ContainsKey(EventType.Created))
            {
                var handler = Handlers[EventType.Created] as Action;
                handler?.Invoke();
            }
            return true;
        }

        private void OnTerminateNative(IntPtr data)
        {
            if (Handlers.ContainsKey(EventType.Terminated))
            {
                var handler = Handlers[EventType.Terminated] as Action;
                handler?.Invoke();
            }
        }

        private void OnAppControlNative(IntPtr appControlHandle, IntPtr data)
        {
            if (Handlers.ContainsKey(EventType.AppControlReceived))
            {
                // Create a SafeAppControlHandle but the ownsHandle is false,
                // because the appControlHandle will be closed by native appfw after this method automatically.
                SafeAppControlHandle safeHandle = new SafeAppControlHandle(appControlHandle, false);

                var handler = Handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
                handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(safeHandle)));
            }
        }

        protected override void OnLowMemoryNative(IntPtr infoHandle, IntPtr data)
        {
            base.OnLowMemoryNative(infoHandle, data);
        }

        protected override void OnLowBatteryNative(IntPtr infoHandle, IntPtr data)
        {
            base.OnLowBatteryNative(infoHandle, data);
        }

        protected override void OnLocaleChangedNative(IntPtr infoHandle, IntPtr data)
        {
            base.OnLocaleChangedNative(infoHandle, data);
        }

        protected override void OnRegionChangedNative(IntPtr infoHandle, IntPtr data)
        {
            base.OnRegionChangedNative(infoHandle, data);
        }

    }
}
