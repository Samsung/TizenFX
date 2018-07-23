//
// TizenGameCoreBackend.cs
//
// Author:
//       WonyoungChoi <wy80.choi@samsung.com>
//
// Copyright (c) 2018
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

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
