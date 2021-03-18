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
using System.ComponentModel;
using Tizen.Internals.Errors;

namespace Tizen.Applications.CoreBackend
{
    /// <summary>
    /// An abstract class to provide default event handlers for apps.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class DefaultCoreBackend : ICoreBackend
    {
        /// <summary>
        /// Low level event types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum AppEventType
        {
            /// <summary>
            /// The low memory event.
            /// </summary>
            LowMemory = 0,

            /// <summary>
            /// The low battery event.
            /// </summary>
            LowBattery,

            /// <summary>
            /// The system language changed event.
            /// </summary>
            LanguageChanged,

            /// <summary>
            /// The device orientation changed event.
            /// </summary>
            DeviceOrientationChanged,

            /// <summary>
            /// The region format changed event.
            /// </summary>
            RegionFormatChanged,

            /// <summary>
            /// The suspended state changed event of the application.
            /// </summary>
            SuspendedStateChanged
        }

        /// <summary>
        /// Tag string for this class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string LogTag = typeof(DefaultCoreBackend).Namespace;

        /// <summary>
        /// Data structure for event handlers.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

        /// <summary>
        /// Constructor of DefaultCoreBackend class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DefaultCoreBackend()
        {
        }

        /// <summary>
        /// Finalizer of DefaultCoreBackend class.
        /// </summary>
        ~DefaultCoreBackend()
        {
            Dispose(false);
        }

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method without arguments.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void AddEventHandler(EventType evType, Action handler)
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <typeparam name="TEventArgs">The EventArgs type used in arguments of the handler method.</typeparam>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method with a TEventArgs type argument.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// Runs the mainloop of the backend.
        /// </summary>
        /// <param name="args"></param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();
        }

        /// <summary>
        /// Exits the mainloop of the backend.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public abstract void Exit();

        /// <summary>
        /// Releases all resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 3 </since_tizen>
        protected abstract void Dispose(bool disposing);

        /// <summary>
        /// Default implementation for the low memory event.
        /// </summary>
        /// <param name="infoHandle"></param>
        /// <param name="data"></param>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Default implementation for the low battery event.
        /// </summary>
        /// <param name="infoHandle"></param>
        /// <param name="data"></param>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Default implementation for the system language changed event.
        /// </summary>
        /// <param name="infoHandle"></param>
        /// <param name="data"></param>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Default implementation for the region format changed event.
        /// </summary>
        /// <param name="infoHandle"></param>
        /// <param name="data"></param>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Default implementation for the device orientation changed event.
        /// </summary>
        /// <param name="infoHandle"></param>
        /// <param name="data"></param>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnDeviceOrientationChangedNative(IntPtr infoHandle, IntPtr data)
        {
            DeviceOrientation orientation;
            ErrorCode err = Interop.AppCommon.AppEventGetDeviceOrientation(infoHandle, out orientation);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get device orientation. Err = " + err);
            }
            if (Handlers.ContainsKey(EventType.DeviceOrientationChanged))
            {
                var handler = Handlers[EventType.DeviceOrientationChanged] as Action<DeviceOrientationEventArgs>;
                handler?.Invoke(new DeviceOrientationEventArgs(orientation));
            }
        }

        /// <summary>
        /// Default implementation for the device orientation changed event.
        /// </summary>
        /// <param name="infoHandle"></param>
        /// <param name="data"></param>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSuspendedStateChangedNative(IntPtr infoHandle, IntPtr data)
        {
            SuspendedState state;
            ErrorCode err = Interop.AppCommon.AppEventGetSuspendedState(infoHandle, out state);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to get device orientation. Err = " + err);
            }
            if (Handlers.ContainsKey(EventType.SuspendedStateChanged))
            {
                var handler = Handlers[EventType.SuspendedStateChanged] as Action<SuspendedStateEventArgs>;
                handler?.Invoke(new SuspendedStateEventArgs(state));
            }
        }
    }
}
