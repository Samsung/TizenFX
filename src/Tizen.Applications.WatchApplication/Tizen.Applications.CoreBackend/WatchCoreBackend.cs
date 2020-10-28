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
    internal class WatchCoreBackend : ICoreBackend
    {
        private const string LOGTAG = "Tizen.Applications.WatchApplication";

        private Dictionary<EventType, object> _handlers = new Dictionary<EventType, object>();

        private bool _disposedValue = false;

        private Interop.Watch.AppEventCallback _lowMemoryCallback;
        private Interop.Watch.AppEventCallback _lowBatteryCallback;
        private Interop.Watch.AppEventCallback _localeChangedCallback;
        private Interop.Watch.AppEventCallback _regionChnagedCallback;

        private IntPtr _lowMemoryEventHandle = IntPtr.Zero;
        private IntPtr _lowBatteryEventHandle = IntPtr.Zero;
        private IntPtr _localeChangedEventHandle = IntPtr.Zero;
        private IntPtr _regionChnagedEventHandle = IntPtr.Zero;

        private Interop.Watch.WatchAppLifecycleCallbacks _callbacks;

        public WatchCoreBackend()
        {
            _lowMemoryCallback = new Interop.Watch.AppEventCallback(OnLowMemoryNative);
            _lowBatteryCallback = new Interop.Watch.AppEventCallback(OnLowBatteryNative);
            _localeChangedCallback = new Interop.Watch.AppEventCallback(OnLocaleChangedNative);
            _regionChnagedCallback = new Interop.Watch.AppEventCallback(OnRegionChangedNative);

            _callbacks.OnCreate = new Interop.Watch.WatchAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Watch.WatchAppTerminateCallback(OnTerminateNative);
            _callbacks.OnResume = new Interop.Watch.WatchAppResumeCallback(OnResumeNative);
            _callbacks.OnPause = new Interop.Watch.WatchAppPauseCallback(OnPauseNative);
            _callbacks.OnAppControl = new Interop.Watch.WatchAppControlCallback(OnAppControlNative);

            _callbacks.OnTick = new Interop.Watch.WatchAppTimeTickCallback(OnTimeTickNative);
            _callbacks.OnAmbientTick = new Interop.Watch.WatchAppAmbientTickCallback(OnAmbientTickNative);
            _callbacks.OnAmbientChanged = new Interop.Watch.WatchAppAmbientChangedCallback(OnAmbientChangedNative);
        }

        ~WatchCoreBackend()
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
                    Interop.Watch.RemoveEventHandler(_lowMemoryEventHandle);
                }
                if (_lowBatteryEventHandle != IntPtr.Zero)
                {
                    Interop.Watch.RemoveEventHandler(_lowBatteryEventHandle);
                }
                if (_localeChangedEventHandle != IntPtr.Zero)
                {
                    Interop.Watch.RemoveEventHandler(_localeChangedEventHandle);
                }
                if (_regionChnagedEventHandle != IntPtr.Zero)
                {
                    Interop.Watch.RemoveEventHandler(_regionChnagedEventHandle);
                }

                _disposedValue = true;
            }
        }

        public void Exit()
        {
            Interop.Watch.Exit();
        }

        public void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();

            Interop.Watch.ErrorCode err = Interop.Watch.ErrorCode.None;

            err = Interop.Watch.AddEventHandler(out _lowMemoryEventHandle, Interop.Watch.AppEventType.LowMemory, _lowMemoryCallback, IntPtr.Zero);
            if (err != Interop.Watch.ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to add event handler for LowMemory event, Err = " + err);
            }

            err = Interop.Watch.AddEventHandler(out _lowBatteryEventHandle, Interop.Watch.AppEventType.LowBattery, _lowBatteryCallback, IntPtr.Zero);
            if (err != Interop.Watch.ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to add event handler for LowBattery event, Err = " + err);
            }

            err = Interop.Watch.AddEventHandler(out _localeChangedEventHandle, Interop.Watch.AppEventType.LanguageChanged, _localeChangedCallback, IntPtr.Zero);
            if (err != Interop.Watch.ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to add event handler for LocaleChanged event, Err = " + err);
            }

            err = Interop.Watch.AddEventHandler(out _regionChnagedEventHandle, Interop.Watch.AppEventType.RegionFormatChanged, _regionChnagedCallback, IntPtr.Zero);
            if (err != Interop.Watch.ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to add event handler for RegionFormatChanged event, Err = " + err);
            }

            err = Interop.Watch.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != Interop.Watch.ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to run the Watch application, Err = " + err);
            }
        }

        private void OnLowMemoryNative(IntPtr infoHandle, IntPtr data)
        {
            LowMemoryStatus status = LowMemoryStatus.None;
            ErrorCode err = Interop.Watch.AppEventGetLowMemoryStatus(infoHandle, out status);
            if (err != ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to get memory status, Err = " + err);
            }
            if (_handlers.ContainsKey(WatchEventType.LowMemory))
            {
                var handler = _handlers[WatchEventType.LowMemory] as Action<LowMemoryEventArgs>;
                handler?.Invoke(new LowMemoryEventArgs(status));
            }
        }

        private void OnLowBatteryNative(IntPtr infoHandle, IntPtr data)
        {
            LowBatteryStatus status = LowBatteryStatus.None;
            ErrorCode err = Interop.Watch.AppEventGetLowBatteryStatus(infoHandle, out status);
            if (err != Tizen.Internals.Errors.ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to get battery status, Err = " + err);
            }
            if (_handlers.ContainsKey(WatchEventType.LowBattery))
            {
                var handler = _handlers[WatchEventType.LowBattery] as Action<LowBatteryEventArgs>;
                handler?.Invoke(new LowBatteryEventArgs(status));
            }
        }
        private void OnLocaleChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string lang;
            ErrorCode err = Interop.Watch.AppEventGetLanguage(infoHandle, out lang);
            if (err != ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to get changed language. Err = " + err);
            }
            if (_handlers.ContainsKey(WatchEventType.LocaleChanged))
            {
                var handler = _handlers[WatchEventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
                handler?.Invoke(new LocaleChangedEventArgs(lang));
            }
        }
        private void OnRegionChangedNative(IntPtr infoHandle, IntPtr data)
        {
            string region;
            ErrorCode err = Interop.Watch.AppEventGetRegionFormat(infoHandle, out region);
            if (err != ErrorCode.None)
            {
                Log.Error(LOGTAG, "Failed to get changed region format. Err = " + err);
            }
            if (_handlers.ContainsKey(WatchEventType.RegionFormatChanged))
            {
                var handler = _handlers[WatchEventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
                handler?.Invoke(new RegionFormatChangedEventArgs(region));
            }
        }
        private bool OnCreateNative(int width, int height, IntPtr data)
        {
            if (_handlers.ContainsKey(WatchEventType.PreCreated))
            {
                var handler = _handlers[WatchEventType.PreCreated] as Action;
                handler?.Invoke();
            }

            if (_handlers.ContainsKey(WatchEventType.Created))
            {
                var handler = _handlers[WatchEventType.Created] as Action;
                handler?.Invoke();
            }
            return true;
        }

        private void OnTerminateNative(IntPtr data)
        {
            if (_handlers.ContainsKey(WatchEventType.Terminated))
            {
                var handler = _handlers[WatchEventType.Terminated] as Action;
                handler?.Invoke();
            }
        }

        private void OnAppControlNative(IntPtr appControlHandle, IntPtr data)
        {
            if (_handlers.ContainsKey(WatchEventType.AppControlReceived))
            {
                SafeAppControlHandle safeHandle = new SafeAppControlHandle(appControlHandle, false);

                var handler = _handlers[WatchEventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;

                handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(safeHandle)));
            }
        }

        private void OnResumeNative(IntPtr data)
        {
            if (_handlers.ContainsKey(WatchEventType.Resumed))
            {
                var handler = _handlers[WatchEventType.Resumed] as Action;
                handler?.Invoke();
            }
        }

        private void OnPauseNative(IntPtr data)
        {
            if (_handlers.ContainsKey(WatchEventType.Paused))
            {
                var handler = _handlers[WatchEventType.Paused] as Action;
                handler?.Invoke();
            }
        }

        private void OnTimeTickNative(IntPtr watchTime, IntPtr userData)
        {
            if (_handlers.ContainsKey(WatchEventType.TimeTick))
            {
                var handler = _handlers[WatchEventType.TimeTick] as Action<TimeEventArgs>;
                handler?.Invoke(new TimeEventArgs()
                {
                    Time = new WatchTime(new SafeWatchTimeHandle(watchTime, false))
                });
            }
        }

        private void OnAmbientTickNative(IntPtr watchTime, IntPtr userData)
        {
            if (_handlers.ContainsKey(WatchEventType.AmbientTick))
            {
                var handler = _handlers[WatchEventType.AmbientTick] as Action<TimeEventArgs>;
                handler?.Invoke(new TimeEventArgs()
                {
                    Time = new WatchTime(new SafeWatchTimeHandle(watchTime, false))
                });
            }
        }

        private void OnAmbientChangedNative(bool ambientMode, IntPtr userData)
        {
            if (_handlers.ContainsKey(WatchEventType.AmbientChanged))
            {
                var handler = _handlers[WatchEventType.AmbientChanged] as Action<AmbientEventArgs>;
                handler?.Invoke(new AmbientEventArgs()
                {
                    Enabled = ambientMode
                });
            }
        }
    }
}
