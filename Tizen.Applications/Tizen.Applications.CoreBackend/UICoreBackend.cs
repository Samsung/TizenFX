// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
                var handler = _handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
                handler.Invoke(new AppControlReceivedEventArgs { ReceivedAppControl = new ReceivedAppControl(appControlHandle) });
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
