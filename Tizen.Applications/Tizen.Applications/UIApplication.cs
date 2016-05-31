// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using Tizen.UI;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents an application that have UI screen. It has additional events for handling 'Resumed' and 'Paused' states.
    /// </summary>
    public class UIApplication : Application
    {
        private Interop.Application.UIAppLifecycleCallbacks _callbacks;

        /// <summary>
        /// Initializes UIApplication class.
        /// </summary>
        public UIApplication()
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
        /// The main window instance of the UIApplication.
        /// </summary>
        /// <remarks>
        /// This window is created before OnCreate() or created event. And the UIApplication will be terminated when this window is closed.
        /// </remarks>
        public Window Window { get; private set; }

        /// <summary>
        /// Runs the UI application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);

            TizenSynchronizationContext.Initialize();
            Interop.Application.Main(args.Length, args, ref _callbacks, IntPtr.Zero);
        }

        /// <summary>
        /// Exits the main loop of the UI application. 
        /// </summary>
        public override void Exit()
        {
            Interop.Application.Exit();
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

        private bool OnCreateNative(IntPtr data)
        {
            Window = new Window("C# UI Application");
            Window.Closed += (s, e) =>
            {
                Exit();
            };
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
