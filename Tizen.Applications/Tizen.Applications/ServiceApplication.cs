// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

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

            TizenSynchronizationContext.Initialize();
            Interop.Service.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
        }

        /// <summary>
        /// Exits the main loop of the service application. 
        /// </summary>
        public override void Exit()
        {
            Interop.Service.Exit();
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
