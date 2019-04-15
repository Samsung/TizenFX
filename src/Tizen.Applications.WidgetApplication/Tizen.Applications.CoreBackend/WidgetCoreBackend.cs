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
    internal class WidgetCoreBackend : ICoreBackend
    {
        protected static readonly string LogTag = typeof(WidgetCoreBackend).Namespace;

        private Dictionary<EventType, object> _handlers = new Dictionary<EventType, object>();

        private bool _disposedValue = false;

        private Interop.Widget.AppEventCallback _lowMemoryCallback;
        private Interop.Widget.AppEventCallback _lowBatteryCallback;
        private Interop.Widget.AppEventCallback _localeChangedCallback;
        private Interop.Widget.AppEventCallback _regionChangedCallback;

        private IntPtr _lowMemoryEventHandle = IntPtr.Zero;
        private IntPtr _lowBatteryEventHandle = IntPtr.Zero;
        private IntPtr _localeChangedEventHandle = IntPtr.Zero;
        private IntPtr _regionChangedEventHandle = IntPtr.Zero;

        private Interop.Widget.WidgetAppLifecycleCallbacks _callbacks;

        internal IList<WidgetType> WidgetTypes = new List<WidgetType>();

        public WidgetCoreBackend()
        {
            _lowMemoryCallback = new Interop.Widget.AppEventCallback(OnLowMemoryNative);
            _lowBatteryCallback = new Interop.Widget.AppEventCallback(OnLowBatteryNative);
            _localeChangedCallback = new Interop.Widget.AppEventCallback(OnLocaleChangedNative);
            _regionChangedCallback = new Interop.Widget.AppEventCallback(OnRegionChangedNative);

            _callbacks.OnCreate = new Interop.Widget.WidgetAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Widget.WidgetAppTerminateCallback(OnTerminateNative);
        }

        ~WidgetCoreBackend()
        {
            Dispose(false);
        }

        internal void CreateWidgetTypes(IDictionary<Type, string> typeInfo)
        {
            foreach (Type w in typeInfo.Keys)
            {
                WidgetTypes.Add(new WidgetType(w, typeInfo[w]));
            }
        }

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
                    Interop.Widget.RemoveEventHandler(_lowMemoryEventHandle);
                }
                if (_lowBatteryEventHandle != IntPtr.Zero)
                {
                    Interop.Widget.RemoveEventHandler(_lowBatteryEventHandle);
                }
                if (_localeChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Widget.RemoveEventHandler(_localeChangedEventHandle);
                }
                if (_regionChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Widget.RemoveEventHandler(_regionChangedEventHandle);
                }

                _disposedValue = true;
            }
        }

        public void Exit()
        {
            Interop.Widget.Exit();
        }

        public void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();

            Interop.Widget.ErrorCode err = Interop.Widget.ErrorCode.None;
            err = Interop.Widget.AddEventHandler(out _lowMemoryEventHandle, Interop.Widget.AppEventType.LowMemory, _lowMemoryCallback, IntPtr.Zero);
            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowMemory event. Err = " + err);
            }
            err = Interop.Widget.AddEventHandler(out _lowBatteryEventHandle, Interop.Widget.AppEventType.LowBattery, _lowBatteryCallback, IntPtr.Zero);
            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LowBattery event. Err = " + err);
            }

            err = Interop.Widget.AddEventHandler(out _localeChangedEventHandle, Interop.Widget.AppEventType.LanguageChanged, _localeChangedCallback, IntPtr.Zero);
            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for LocaleChanged event. Err = " + err);
            }

            err = Interop.Widget.AddEventHandler(out _regionChangedEventHandle, Interop.Widget.AppEventType.RegionFormatChanged, _regionChangedCallback, IntPtr.Zero);
            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to add event handler for RegionFormatChanged event. Err = " + err);
            }

            err = Interop.Widget.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
            }
        }

        private IntPtr OnCreateNative(IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.Created))
            {
                var handler = _handlers[EventType.Created] as Action;
                handler?.Invoke();
            }

            IntPtr h = IntPtr.Zero;
            foreach (WidgetType type in WidgetTypes)
                h = type.Bind(h);

            return h;
        }

        private void OnTerminateNative(IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.Terminated))
            {
                var handler = _handlers[EventType.Terminated] as Action;
                handler?.Invoke();
            }
        }

        public void AddEventHandler(EventType evType, Action handler)
        {
            _handlers.Add(evType, handler);
        }

        public void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            _handlers.Add(evType, handler);
        }

        private void OnLowMemoryNative(IntPtr infoHandle, IntPtr data)
        {
            LowMemoryStatus status = LowMemoryStatus.None;
            ErrorCode err = Interop.Widget.AppEventGetLowMemoryStatus(infoHandle, out status);
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
            ErrorCode err = Interop.Widget.AppEventGetLowBatteryStatus(infoHandle, out status);
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
            ErrorCode err = Interop.Widget.AppEventGetLanguage(infoHandle, out lang);
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
            ErrorCode err = Interop.Widget.AppEventGetRegionFormat(infoHandle, out region);
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
