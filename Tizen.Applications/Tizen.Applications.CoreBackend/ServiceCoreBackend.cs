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
    internal class ServiceCoreBackend : DefaultCoreBackend
    {
        private Interop.Service.ServiceAppLifecycleCallbacks _callbacks;

        public ServiceCoreBackend()
        {
            _callbacks.OnCreate = new Interop.Service.ServiceAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Service.ServiceAppTerminateCallback(OnTerminateNative);
            _callbacks.OnAppControl = new Interop.Service.ServiceAppControlCallback(OnAppControlNative);
        }

        public override void Exit()
        {
            Interop.Service.Exit();
        }

        public override void Run(string[] args)
        {
            base.Run(args);

            ErrorCode err = Interop.Service.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
            }
        }

        private bool OnCreateNative(IntPtr data)
        {
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

        internal override ErrorCode AddAppEventCallback(out IntPtr handle, Interop.AppCommon.AppEventType type, Interop.AppCommon.AppEventCallback callback)
        {
            return Interop.Service.AddEventHandler(out handle, type, callback, IntPtr.Zero);
        }

        internal override void RemoveAppEventCallback(IntPtr handle)
        {
            Interop.Service.RemoveEventHandler(handle);
        }
    }
}
