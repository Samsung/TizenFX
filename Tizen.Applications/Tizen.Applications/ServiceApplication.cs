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

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceApplication : Application
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void Run(string[] args)
        {
            base.Run(args);

            Interop.Service.ServiceAppLifecycleCallbacks ops;
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

            TizenSynchronizationContext.Initialize();
            Interop.Service.Main(args.Length, args, ref ops, IntPtr.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exit()
        {
            Interop.Service.Exit();
        }
    }
}
