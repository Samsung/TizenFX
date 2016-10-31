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

        public UICoreBackend()
        {
            _callbacks.OnCreate = new Interop.Application.AppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Application.AppTerminateCallback(OnTerminateNative);
            _callbacks.OnAppControl = new Interop.Application.AppControlCallback(OnAppControlNative);
            _callbacks.OnResume = new Interop.Application.AppResumeCallback(OnResumeNative);
            _callbacks.OnPause = new Interop.Application.AppPauseCallback(OnPauseNative);
        }

        public override void Exit()
        {
            Interop.Application.Exit();
        }

        public override void Run(string[] args)
        {
            base.Run(args);

            ErrorCode err = Interop.Application.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
            }
        }

        private bool OnCreateNative(IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.PreCreated))
            {
                var handler = _handlers[EventType.PreCreated] as Action;
                handler?.Invoke();
            }

            if (_handlers.ContainsKey(EventType.Created))
            {
                var handler = _handlers[EventType.Created] as Action;
                handler?.Invoke();
            }
            return true;
        }

        private void OnTerminateNative(IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.Terminated))
            {
                var handler = _handlers[EventType.Terminated] as Action;
                handler?.Invoke();
            }
        }

        private void OnAppControlNative(IntPtr appControlHandle, IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.AppControlReceived))
            {
                // Create a SafeAppControlHandle but the ownsHandle is false,
                // because the appControlHandle will be closed by native appfw after this method automatically.
                SafeAppControlHandle safeHandle = new SafeAppControlHandle(appControlHandle, false);

                var handler = _handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
                handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(safeHandle)));
            }
        }

        private void OnResumeNative(IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.Resumed))
            {
                var handler = _handlers[EventType.Resumed] as Action;
                handler?.Invoke();
            }
        }

        private void OnPauseNative(IntPtr data)
        {
            if (_handlers.ContainsKey(EventType.Paused))
            {
                var handler = _handlers[EventType.Paused] as Action;
                handler?.Invoke();
            }
        }

        internal override ErrorCode AddAppEventCallback(out IntPtr handle, Interop.AppCommon.AppEventType type, Interop.AppCommon.AppEventCallback callback)
        {
            return Interop.Application.AddEventHandler(out handle, type, callback, IntPtr.Zero);
        }

        internal override void RemoveAppEventCallback(IntPtr handle)
        {
            Interop.Application.RemoveEventHandler(handle);
        }
    }
}
