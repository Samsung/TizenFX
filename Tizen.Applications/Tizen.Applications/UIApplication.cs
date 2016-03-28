/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public class UIApplication : Application
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> Resumed;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> Paused;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void Run(string[] args)
        {
            base.Run(args);

            Interop.Application.UIAppLifecycleCallbacks ops;
            ops.OnCreate = (data) =>
            {
                SendCreate();
                return true;
            };
            ops.OnTerminate = (data) =>
            {
                OnTerminate(EventArgs.Empty);
            };
            ops.OnAppControl = (appControlHandle, data) =>
            {
                OnAppControlReceived(new AppControlReceivedEventArgs(new ReceivedAppControl(appControlHandle)));
            };
            ops.OnResume = (data) =>
            {
                OnResume(EventArgs.Empty);
            };
            ops.OnPause = (data) =>
            {
                OnPause(EventArgs.Empty);
            };

            TizenSynchronizationContext.Initialize();
            Interop.Application.Main(args.Length, args, ref ops, IntPtr.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exit()
        {
            Interop.Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnResume(EventArgs e)
        {
            var eh = Resumed as EventHandler<EventArgs>;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnPause(EventArgs e)
        {
            var eh = Paused as EventHandler<EventArgs>;
            if (eh != null)
            {
                eh(this, e);
            }
        }
    }
}
