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
    /// <summary>
    /// Abstract class to provide default event handlers for apps.
    /// </summary>
    public abstract class DefaultCoreBackend : ICoreBackend
    {
        /// <summary>
        /// Low level event types
        /// </summary>
        public enum AppEventType
        {
            LowMemory = 0,
            LowBattery,
            LanguageChanged,
            DeviceOrientationChanged,
            RegionFormatChanged,
            SuspendedStateChanged
        }

        protected static readonly string LogTag = typeof(DefaultCoreBackend).Namespace;

        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

        public DefaultCoreBackend()
        {
        }

        ~DefaultCoreBackend()
        {
            Dispose(false);
        }

        public void AddEventHandler(EventType evType, Action handler)
        {
            Handlers.Add(evType, handler);
        }

        public void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            Handlers.Add(evType, handler);
        }

        public virtual void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();
        }

        public abstract void Exit();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);

        protected virtual void OnLowMemoryNative(IntPtr infoHandle, IntPtr data)
        {
            LowMemoryStatus status = LowMemoryStatus.None;
            ErrorCode err = Interop.AppCommon.AppEventGetLowMemoryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get memory status. Err = " + err);
            }
            if (Handlers.ContainsKey(EventType.LowMemory))
            {
                var handler = Handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;
                handler?.Invoke(new LowMemoryEventArgs(status));
            }
        }

        protected virtual void OnLowBatteryNative(IntPtr infoHandle, IntPtr data)
        {
            LowBatteryStatus status = LowBatteryStatus.None;
            ErrorCode err = Interop.AppCommon.AppEventGetLowBatteryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get battery status. Err = " + err);
            }
            if (Handlers.ContainsKey(EventType.LowBattery))
            {
                var handler = Handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
                handler?.Invoke(new LowBatteryEventArgs(status));
            }
        }

        protected virtual void OnLocaleChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string lang;
            ErrorCode err = Interop.AppCommon.AppEventGetLanguage(infoHandle, out lang);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get changed language. Err = " + err);
            }
            if (Handlers.ContainsKey(EventType.LocaleChanged))
            {
                var handler = Handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
                handler?.Invoke(new LocaleChangedEventArgs(lang));
            }
        }

        protected virtual void OnRegionChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string region;
            ErrorCode err = Interop.AppCommon.AppEventGetRegionFormat(infoHandle, out region);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get changed region format. Err = " + err);
            }
            if (Handlers.ContainsKey(EventType.RegionFormatChanged))
            {
                var handler = Handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
                handler?.Invoke(new RegionFormatChangedEventArgs(region));
            }
        }
    }
}
