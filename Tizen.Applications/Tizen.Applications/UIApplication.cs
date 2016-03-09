/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Internals.Errors;

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
                OnTerminate();
            };
            ops.OnAppControl = (appControlHandle, data) =>
            {
                OnStart(new AppControl(appControlHandle));
            };
            ops.OnResume = (data) =>
            {
                OnResume();
            };
            ops.OnPause = (data) =>
            {
                OnPause();
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
        protected virtual void OnResume()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnPause()
        {
        }
    }
}
