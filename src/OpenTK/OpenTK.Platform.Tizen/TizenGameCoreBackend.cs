/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using Tizen.Applications;
using Tizen.Applications.CoreBackend;

namespace OpenTK.Platform.Tizen
{
    internal class TizenGameCoreBackend : DefaultCoreBackend
    {
        internal readonly static string WindowCreationEventType = "WindowCreation";

        private readonly SDL2.EventFilter EventFilterDelegate_GCUnsafe;
        private readonly IntPtr EventFilterDelegate;
        private bool disposed = false;

        public TizenGameCoreBackend()
        {
            EventFilterDelegate_GCUnsafe = new SDL2.EventFilter(OnHandleSDLAppEvent);
            EventFilterDelegate = Marshal.GetFunctionPointerForDelegate(EventFilterDelegate_GCUnsafe);
        }

        public override void Run(string[] args)
        {
            lock (SDL2.SDL.Sync)
            {
                SDL2.SDL.AddEventWatch(EventFilterDelegate, IntPtr.Zero);
                OnCreateNative();
            }
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
           if (!disposed)
            {
                if (disposing)
                {
                    // release disposable objects
                }
                lock (SDL2.SDL.Sync)
                {
                    SDL2.SDL.DelEventWatch(EventFilterDelegate, IntPtr.Zero);
                }
                disposed = true;
            }
        }

        private bool OnCreateNative()
        {
            if (Handlers.ContainsKey(EventType.PreCreated))
            {
                var handler = Handlers[EventType.PreCreated] as Action;
                handler?.Invoke();
            }

            if (Handlers.ContainsKey(WindowCreationEventType))
            {
                var handler = Handlers[WindowCreationEventType] as Action;
                handler?.Invoke();
            }

            if (Handlers.ContainsKey(EventType.Created))
            {
                var handler = Handlers[EventType.Created] as Action;
                handler?.Invoke();
            }
            return true;
        }

        private unsafe int OnHandleSDLAppEvent(IntPtr data, IntPtr e)
        {
            try
            {
                SDL2.Event ev = *(SDL2.Event*)e;
                switch (ev.Type)
                {
                    case SDL2.EventType.APPDIDENTERBACKGROUND:
                        OnPauseNative();
                        break;
                    case SDL2.EventType.APPDIDENTERFOREGROUND:
                        OnResumeNative();
                        break;
                    case SDL2.EventType.APPCONTROL:
                        OnAppControlNative(ev.User.data1);
                        break;
                    case SDL2.EventType.APPTERMINATING:
                        OnTerminateNative();
                        break;
                    case SDL2.EventType.APPLOWBATTERY:
                        OnLowBatteryNative(ev.User.data1, IntPtr.Zero);
                        break;
                    case SDL2.EventType.APPLOWMEMORY:
                        OnLowMemoryNative(ev.User.data1, IntPtr.Zero);
                        break;
                    case SDL2.EventType.APPLANGUAGECHANGED:
                        OnLocaleChangedNative(ev.User.data1, IntPtr.Zero);
                        break;
                    case SDL2.EventType.APPREGIONCHANGED:
                        OnRegionChangedNative(ev.User.data1, IntPtr.Zero);
                        break;
                    case SDL2.EventType.ROTATEEVENT:
                        OnDeviceOrientationChangedNative(ev.User.data1, IntPtr.Zero);
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }

            return 0;
        }

        private void OnTerminateNative()
        {
            if (Handlers.ContainsKey(EventType.Terminated))
            {
                var handler = Handlers[EventType.Terminated] as Action;
                handler?.Invoke();
            }
        }

        private void OnAppControlNative(IntPtr appControlHandle)
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

        private void OnResumeNative()
        {
            if (Handlers.ContainsKey(EventType.Resumed))
            {
                var handler = Handlers[EventType.Resumed] as Action;
                handler?.Invoke();
            }
        }

        private void OnPauseNative()
        {
            if (Handlers.ContainsKey(EventType.Paused))
            {
                var handler = Handlers[EventType.Paused] as Action;
                handler?.Invoke();
            }
        }
    }
}
