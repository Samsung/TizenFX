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
    internal class UICoreBackend : DefaultCoreBackend
    {
        private Interop.Application.UIAppLifecycleCallbacks _callbacks;
        private IntPtr _lowMemoryEventHandle = IntPtr.Zero;
        private IntPtr _lowBatteryEventHandle = IntPtr.Zero;
        private IntPtr _localeChangedEventHandle = IntPtr.Zero;
        private IntPtr _regionChangedEventHandle = IntPtr.Zero;
        private IntPtr _deviceOrientationChangedEventHandle = IntPtr.Zero;
        private IntPtr _timeZoneChangedEventHandle = IntPtr.Zero;
        private bool _disposedValue = false;
        private Interop.Application.AppEventCallback _onLowMemoryNative;
        private Interop.Application.AppEventCallback _onLowBatteryNative;
        private Interop.Application.AppEventCallback _onLocaleChangedNative;
        private Interop.Application.AppEventCallback _onRegionChangedNative;
        private Interop.Application.AppEventCallback _onDeviceOrientationChangedNative;
        private Interop.Application.AppEventCallback _onTimeZoneChangedNative;

        public UICoreBackend()
        {
            _callbacks.OnCreate = new Interop.Application.AppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Application.AppTerminateCallback(OnTerminateNative);
            _callbacks.OnAppControl = new Interop.Application.AppControlCallback(OnAppControlNative);
            _callbacks.OnResume = new Interop.Application.AppResumeCallback(OnResumeNative);
            _callbacks.OnPause = new Interop.Application.AppPauseCallback(OnPauseNative);

            _onLowMemoryNative = new Interop.Application.AppEventCallback(OnLowMemoryNative);
            _onLowBatteryNative = new Interop.Application.AppEventCallback(OnLowBatteryNative);
            _onLocaleChangedNative = new Interop.Application.AppEventCallback(OnLocaleChangedNative);
            _onRegionChangedNative = new Interop.Application.AppEventCallback(OnRegionChangedNative);
            _onDeviceOrientationChangedNative = new Interop.Application.AppEventCallback(OnDeviceOrientationChangedNative);
            _onTimeZoneChangedNative = new Interop.Application.AppEventCallback(OnTimeZoneChangedNative);
        }

        public override void Exit()
        {
            Interop.Application.Exit();
        }

        public override void Run(string[] args)
        {
            base.Run(args);

            ErrorCode err = ErrorCode.None;
            err = Interop.Application.AddEventHandler(out _lowMemoryEventHandle, AppEventType.LowMemory, _onLowMemoryNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowMemory event. Err = " + err);
            }
            err = Interop.Application.AddEventHandler(out _lowBatteryEventHandle, AppEventType.LowBattery, _onLowBatteryNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowBattery event. Err = " + err);
            }

            err = Interop.Application.AddEventHandler(out _localeChangedEventHandle, AppEventType.LanguageChanged, _onLocaleChangedNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LocaleChanged event. Err = " + err);
            }

            err = Interop.Application.AddEventHandler(out _regionChangedEventHandle, AppEventType.RegionFormatChanged, _onRegionChangedNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for RegionFormatChanged event. Err = " + err);
            }

            err = Interop.Application.AddEventHandler(out _deviceOrientationChangedEventHandle, AppEventType.DeviceOrientationChanged, _onDeviceOrientationChangedNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for DeviceOrientationChanged event. Err = " + err);
            }

            err = Interop.Application.AddEventHandler(out _timeZoneChangedEventHandle, AppEventType.TimeZoneChanged, _onTimeZoneChangedNative, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for TimeZoneChanged event. Err = " + err);
            }

            err = Interop.Application.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
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
                    Interop.Application.RemoveEventHandler(_lowMemoryEventHandle);
                }
                if (_lowBatteryEventHandle != IntPtr.Zero)
                {
                    Interop.Application.RemoveEventHandler(_lowBatteryEventHandle);
                }
                if (_localeChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Application.RemoveEventHandler(_localeChangedEventHandle);
                }
                if (_regionChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Application.RemoveEventHandler(_regionChangedEventHandle);
                }
                if (_deviceOrientationChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Application.RemoveEventHandler(_deviceOrientationChangedEventHandle);
                }
                if (_timeZoneChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Application.RemoveEventHandler(_timeZoneChangedEventHandle);
                }

                _disposedValue = true;
            }
        }

        private bool OnCreateNative(IntPtr data)
        {
            if (Handlers.ContainsKey(EventType.PreCreated))
            {
                var handler = Handlers[EventType.PreCreated] as Action;
                handler?.Invoke();
            }

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
                using SafeAppControlHandle safeHandle = new SafeAppControlHandle(appControlHandle, false);
                var handler = Handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
                handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(safeHandle)));
            }
        }

        private void OnResumeNative(IntPtr data)
        {
            if (Handlers.ContainsKey(EventType.Resumed))
            {
                var handler = Handlers[EventType.Resumed] as Action;
                handler?.Invoke();
            }
        }

        private void OnPauseNative(IntPtr data)
        {
            if (Handlers.ContainsKey(EventType.Paused))
            {
                var handler = Handlers[EventType.Paused] as Action;
                handler?.Invoke();
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

        protected override void OnDeviceOrientationChangedNative(IntPtr infoHandle, IntPtr data)
        {
            base.OnDeviceOrientationChangedNative(infoHandle, data);
        }

        protected override void OnTimeZoneChangedNative(IntPtr infoHandle, IntPtr data)
        {
            base.OnTimeZoneChangedNative(infoHandle, data);
        }
    }
}
