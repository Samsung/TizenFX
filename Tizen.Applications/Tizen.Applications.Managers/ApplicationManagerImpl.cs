/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Applications.Managers
{
    internal class ApplicationManagerImpl : IDisposable
    {
        private static ApplicationManagerImpl _instance = new ApplicationManagerImpl();

        private bool _disposed = false;
        private Interop.ApplicationManager.AppManagerAppContextEventCallback _applicationChangedEventCallback;

        private ApplicationManagerImpl()
        {
            Console.WriteLine("ApplicationManagerImpl()");
            RegisterApplicationChangedEvent();
        }


        ~ApplicationManagerImpl()
        {
            Console.WriteLine("~ApplicationManagerImpl()");
            UnRegisterApplicationChangedEvent();
            Dispose(false);
        }

        internal event EventHandler<ApplicationChangedEventArgs> ApplicationLaunched;
        internal event EventHandler<ApplicationChangedEventArgs> ApplicationTerminated;        

        internal static ApplicationManagerImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            //Free unmanaged objects
            _disposed = true;
        }

        internal async Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync()
        {
            Console.WriteLine("GetInstalledAppsAsync()");
            return await Task.Run(() =>
            {
                List<InstalledApplication> Result = new List<InstalledApplication>();

                Interop.ApplicationManager.AppManagerAppInfoCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle;
                        Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };
                Interop.ApplicationManager.AppManagerForeachAppInfo(cb, IntPtr.Zero);
                return Result;
            });
        }

        internal async Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync(InstalledApplicationFilter filter)
        {
            Console.WriteLine("GetInstalledAppsAsync(InstalledApplicationFilter filter)");
            return await Task.Run(() =>
            {
                List<InstalledApplication> Result = new List<InstalledApplication>();

                Interop.ApplicationManager.AppInfoFilterCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    Console.WriteLine("AppInfoFilterCallback");
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle;
                        Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                Interop.ApplicationManager.AppInfoFilterForeachAppinfo(filter.Handle, cb, IntPtr.Zero);
                return Result;
            });
        }

        internal async Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync(InstalledApplicationMetadataFilter filter)
        {
            Console.WriteLine("GetInstalledAppsAsync(InstalledApplicationMetadataFilter filter)");

            return await Task.Run(() =>
            {
                List<InstalledApplication> Result = new List<InstalledApplication>();

                Interop.ApplicationManager.AppInfoFilterCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    Console.WriteLine("AppInfoFilterCallback");
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle;
                        Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                Interop.ApplicationManager.AppInfoMetadataFilterForeach(filter.Handle, cb, IntPtr.Zero);
                return Result;
            });
        }

        internal async Task<IEnumerable<RunningApplication>> GetRunningAppsAsync()
        {
            Console.WriteLine("GetRunningAppsAsync()");

            return await Task.Run(() =>
            {
                List<RunningApplication> Result = new List<RunningApplication>();

                Interop.ApplicationManager.AppManagerAppContextCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    Console.WriteLine("AppManagerAppContextCallback");
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr ptr = IntPtr.Zero;
                        Interop.ApplicationManager.AppContextGetAppId(handle, out ptr);
                        string appid = Marshal.PtrToStringAuto(ptr);
                        int pid = 0;
                        Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                        RunningApplication app = new RunningApplication(appid, pid);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                Interop.ApplicationManager.AppManagerForeachAppContext(cb, IntPtr.Zero);
                return Result;
            });
        }

        internal InstalledApplication GetInstalledApp(string applicationId)
        {
            Console.WriteLine("GetInstalledApp(appid)");
            IntPtr info = IntPtr.Zero;
            Interop.ApplicationManager.AppManagerGetAppInfo(applicationId, out info);
            if (info != IntPtr.Zero)
            {
                InstalledApplication app = new InstalledApplication(info);
                return app;
            }
            return null;
        }

        internal RunningApplication GetRunningApp(string applicationId)
        {
            Console.WriteLine("GetRunningApp(appid)");
            IntPtr context = IntPtr.Zero;
            Interop.ApplicationManager.AppManagerGetAppContext(applicationId, out context);

            if (context != IntPtr.Zero)
            {
                int pid = 0;
                Interop.ApplicationManager.AppContextGetPid(context, out pid);
                Interop.ApplicationManager.AppContextDestroy(context);
                RunningApplication app = new RunningApplication(applicationId, pid);
                return app;
            }
            return null;
        }

        internal RunningApplication GetRunningApp(int processId)
        {
            Console.WriteLine("GetRunningApp(pid)");
            string appid = "";
            Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            RunningApplication app = new RunningApplication(appid, processId);
            return app;
        }

        internal bool IsRunningApp(string applicationId)
        {
            Console.WriteLine("IsRunningApp(appid)");
            bool running = false;
            Interop.ApplicationManager.AppManagerIsRunning(applicationId, out running);
            return running;
        }

        internal bool IsRunningApp(int processId)
        {
            Console.WriteLine("IsRunningApp(pid)");
            string appid = "";
            Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            bool running = false;
            Interop.ApplicationManager.AppManagerIsRunning(appid, out running);
            return running;
        }

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
