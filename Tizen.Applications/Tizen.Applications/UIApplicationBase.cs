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
    /// Represents an application that have UI screen. It has additional events for handling 'Resumed' and 'Paused' states.
    /// </summary>
    public class UIApplicationBase : Application
    {
        private Interop.Application.UIAppLifecycleCallbacks _callbacks;

        /// <summary>
        /// Initializes UIApplicationBase class.
        /// </summary>
        public UIApplicationBase()
        {
            _callbacks.OnCreate = new Interop.Application.AppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.Application.AppTerminateCallback(OnTerminateNative);
            _callbacks.OnAppControl = new Interop.Application.AppControlCallback(OnAppControlNative);
            _callbacks.OnResume = new Interop.Application.AppResumeCallback(OnResumeNative);
            _callbacks.OnPause = new Interop.Application.AppPauseCallback(OnPauseNative);
        }

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// Runs the UI application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);

            ErrorCode err = Interop.Application.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
            if (err != ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
            }
        }

        /// <summary>
        /// Exits the main loop of the UI application. 
        /// </summary>
        public override void Exit()
        {
            Interop.Application.Exit();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// </summary>
        protected virtual void OnPreCreate()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is resumed.
        /// If base.OnResume() is not called, the event 'Resumed' will not be emitted.
        /// </summary>
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is paused.
        /// If base.OnPause() is not called, the event 'Paused' will not be emitted.
        /// </summary>
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }

        internal override ErrorCode AddEventHandler(out IntPtr handle, Interop.AppCommon.AppEventType type, Interop.AppCommon.AppEventCallback callback)
        {
            return Interop.Application.AddEventHandler(out handle, type, callback, IntPtr.Zero);
        }

        internal override void RemoveEventHandler(IntPtr handle)
        {
            Interop.Application.RemoveEventHandler(handle);
        }

        private bool OnCreateNative(IntPtr data)
        {
            OnPreCreate();
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

        private void OnResumeNative(IntPtr data)
        {
            OnResume();
        }

        private void OnPauseNative(IntPtr data)
        {
            OnPause();
        }
    }
}
