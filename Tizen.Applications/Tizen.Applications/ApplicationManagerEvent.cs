/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    internal partial class ApplicationManagerImpl
    {
        internal event EventHandler<ApplicationChangedEventArgs> ApplicationLaunched;
        internal event EventHandler<ApplicationChangedEventArgs> ApplicationTerminated;
        private Interop.ApplicationManager.AppManagerAppContextEventCallback _applicationChangedEventCallback;

        private void RegisterApplicationChangedEvent()
        {
            Console.WriteLine("RegisterApplicationChangedEvent()");
            _applicationChangedEventCallback = (IntPtr context, int state, IntPtr userData) =>
            {
                Console.WriteLine("ApplicationChangedEventCallback");
                if (context == IntPtr.Zero) return;

                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppContextGetAppId(context, out ptr);
                string appid = Marshal.PtrToStringAuto(ptr);
                int pid = 0;
                Interop.ApplicationManager.AppContextGetPid(context, out pid);

                if (state == 0)
                {
                    var launchedEventCache = ApplicationLaunched;
                    if (launchedEventCache != null)
                    {
                        Console.WriteLine("Raise up ApplicationLaunched");
                        ApplicationChangedEventArgs e = new ApplicationChangedEventArgs(appid, pid, state);
                        launchedEventCache(null, e);
                    }
                }
                else if (state == 1)
                {
                    var terminatedEventCache = ApplicationTerminated;
                    if (terminatedEventCache != null)
                    {
                        Console.WriteLine("Raise up ApplicationTerminated");
                        ApplicationChangedEventArgs e = new ApplicationChangedEventArgs(appid, pid, state);
                        terminatedEventCache(null, e);
                    }
                }
            };

            Interop.ApplicationManager.AppManagerSetAppContextEvent(_applicationChangedEventCallback, IntPtr.Zero);
        }

        private void UnRegisterApplicationChangedEvent()
        {
            Console.WriteLine("UnRegisterApplicationChangedEvent()");
            Interop.ApplicationManager.AppManagerUnSetAppContextEvent();
        }
    }
}

