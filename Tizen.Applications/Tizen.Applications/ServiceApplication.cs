// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a service application.
    /// </summary>
    public class ServiceApplication : Application
    {
        private Interop.Service.ServiceAppLifecycleCallbacks _callbacks;

        /// <summary>
        /// Initializes ServiceApplication class.
        /// </summary>
        public ServiceApplication()
        {
            _callbacks.OnCreate = new Interop.Service.ServiceAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Service.ServiceAppTerminateCallback(OnTerminateNative);
            _callbacks.OnAppControl = new Interop.Service.ServiceAppControlCallback(OnAppControlNative);
        }

        /// <summary>
        /// Runs the service application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);

            ErrorCode err = Interop.Service.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the service. Err = " + err);
            }
        }

        /// <summary>
        /// Exits the main loop of the service application. 
        /// </summary>
        public override void Exit()
        {
            Interop.Service.Exit();
        }

        internal override ErrorCode AddEventHandler(out IntPtr handle, Interop.AppCommon.AppEventType type, Interop.AppCommon.AppEventCallback callback)
        {
            return Interop.Service.AddEventHandler(out handle, type, callback, IntPtr.Zero);
        }

        internal override void RemoveEventHandler(IntPtr handle)
        {
            Interop.Service.RemoveEventHandler(handle);
        }

        private bool OnCreateNative(IntPtr data)
        {
            OnCreate();
            return true;
        }

        private void OnTerminateNative(IntPtr data)
        {
            OnTerminate();
        }

        private void OnAppControlNative(IntPtr appControlHandle, IntPtr data)
        {
            OnAppControlReceived(new AppControlReceivedEventArgs { ReceivedAppControl = new ReceivedAppControl(appControlHandle) });
        }
    }
}
