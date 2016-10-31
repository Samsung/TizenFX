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
using System.Collections.Generic;

using Tizen.Internals.Errors;

namespace Tizen.Applications.CoreBackend
{
    internal abstract class DefaultCoreBackend : ICoreBackend
    {
        protected static readonly string LogTag = typeof(DefaultCoreBackend).Namespace;

        protected Dictionary<EventType, object> _handlers = new Dictionary<EventType, object>();

        private bool _disposedValue = false;

        private Interop.AppCommon.AppEventCallback _lowMemoryCallback;
        private Interop.AppCommon.AppEventCallback _lowBatteryCallback;
        private Interop.AppCommon.AppEventCallback _localeChangedCallback;
        private Interop.AppCommon.AppEventCallback _regionChangedCallback;

        private IntPtr _lowMemoryEventHandle = IntPtr.Zero;
        private IntPtr _lowBatteryEventHandle = IntPtr.Zero;
        private IntPtr _localeChangedEventHandle = IntPtr.Zero;
        private IntPtr _regionChangedEventHandle = IntPtr.Zero;

        public DefaultCoreBackend()
        {
            _lowMemoryCallback = new Interop.AppCommon.AppEventCallback(OnLowMemoryNative);
            _lowBatteryCallback = new Interop.AppCommon.AppEventCallback(OnLowBatteryNative);
            _localeChangedCallback = new Interop.AppCommon.AppEventCallback(OnLocaleChangedNative);
            _regionChangedCallback = new Interop.AppCommon.AppEventCallback(OnRegionChangedNative);
        }

        ~DefaultCoreBackend()
        {
            Dispose(false);
        }

        public void AddEventHandler(EventType evType, Action handler)
        {
            _handlers.Add(evType, handler);
        }

        public void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            _handlers.Add(evType, handler);
        }

        public virtual void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();

            ErrorCode err = ErrorCode.None;
            err = AddAppEventCallback(out _lowMemoryEventHandle, Interop.AppCommon.AppEventType.LowMemory, _lowMemoryCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowMemory event. Err = " + err);
            }
            err = AddAppEventCallback(out _lowBatteryEventHandle, Interop.AppCommon.AppEventType.LowBattery, _lowBatteryCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowBattery event. Err = " + err);
            }

            err = AddAppEventCallback(out _localeChangedEventHandle, Interop.AppCommon.AppEventType.LanguageChanged, _localeChangedCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LocaleChanged event. Err = " + err);
            }

            err = AddAppEventCallback(out _regionChangedEventHandle, Interop.AppCommon.AppEventType.RegionFormatChanged, _regionChangedCallback);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for RegionFormatChanged event. Err = " + err);
            }
        }

        public abstract void Exit();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Release disposable objects
                }

                if (_lowMemoryEventHandle != IntPtr.Zero)
                {
                    RemoveAppEventCallback(_lowMemoryEventHandle);
                }
                if (_lowBatteryEventHandle != IntPtr.Zero)
                {
                    RemoveAppEventCallback(_lowBatteryEventHandle);
                }
                if (_localeChangedEventHandle != IntPtr.Zero)
                {
                    RemoveAppEventCallback(_localeChangedEventHandle);
                }
                if (_regionChangedEventHandle != IntPtr.Zero)
                {
                    RemoveAppEventCallback(_regionChangedEventHandle);
                }

                _disposedValue = true;
            }
        }

        internal abstract ErrorCode AddAppEventCallback(out IntPtr handle, Interop.AppCommon.AppEventType type, Interop.AppCommon.AppEventCallback callback);

        internal abstract void RemoveAppEventCallback(IntPtr handle);

        private void OnLowMemoryNative(IntPtr infoHandle, IntPtr data)
        {
            LowMemoryStatus status = LowMemoryStatus.None;
            ErrorCode err = Interop.AppCommon.AppEventGetLowMemoryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get memory status. Err = " + err);
            }
            if (_handlers.ContainsKey(EventType.LowMemory))
            {
                var handler = _handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;
                handler?.Invoke(new LowMemoryEventArgs(status));
            }
        }

        private void OnLowBatteryNative(IntPtr infoHandle, IntPtr data)
        {
            LowBatteryStatus status = LowBatteryStatus.None;
            ErrorCode err = Interop.AppCommon.AppEventGetLowBatteryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get battery status. Err = " + err);
            }
            if (_handlers.ContainsKey(EventType.LowBattery))
            {
                var handler = _handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
                handler?.Invoke(new LowBatteryEventArgs(status));
            }
        }

        private void OnLocaleChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string lang;
            ErrorCode err = Interop.AppCommon.AppEventGetLanguage(infoHandle, out lang);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get changed language. Err = " + err);
            }
            if (_handlers.ContainsKey(EventType.LocaleChanged))
            {
                var handler = _handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
                handler?.Invoke(new LocaleChangedEventArgs(lang));
            }
        }

        private void OnRegionChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string region;
            ErrorCode err = Interop.AppCommon.AppEventGetRegionFormat(infoHandle, out region);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get changed region format. Err = " + err);
            }
            if (_handlers.ContainsKey(EventType.RegionFormatChanged))
            {
                var handler = _handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
                handler?.Invoke(new RegionFormatChangedEventArgs(region));
            }
        }
    }
}
