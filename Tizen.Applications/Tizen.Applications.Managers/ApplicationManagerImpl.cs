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

        private const string LogTag = "Tizen.Applications.Managers";
        private int ret = 0;

        private ApplicationManagerImpl()
        {
            Log.Debug(LogTag, "ApplicationManagerImpl()");
            RegisterApplicationChangedEvent();
        }


        ~ApplicationManagerImpl()
        {
            Log.Debug(LogTag, "~ApplicationManagerImpl()");
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
            Log.Debug(LogTag, "GetInstalledAppsAsync()");
            return await Task.Run(() =>
            {
                List<InstalledApplication> Result = new List<InstalledApplication>();

                Interop.ApplicationManager.AppManagerAppInfoCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        ret = Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        if (ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(ret, clonedHandle, "GetInstalledAppsAsync() failed.");
                        }
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };
                ret = Interop.ApplicationManager.AppManagerForeachAppInfo(cb, IntPtr.Zero);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, IntPtr.Zero, "GetInstalledAppsAsync() failed.");
                }
                return Result;
            });
        }

        internal async Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync(InstalledApplicationFilter filter)
        {
            Log.Debug(LogTag, "GetInstalledAppsAsync(InstalledApplicationFilter filter)");
            return await Task.Run(() =>
            {
                List<InstalledApplication> Result = new List<InstalledApplication>();

                Interop.ApplicationManager.AppInfoFilterCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    Log.Debug(LogTag, "AppInfoFilterCallback");
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        ret = Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        if (ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(ret, clonedHandle, "GetInstalledAppsAsync(InstalledApplicationFilter) failed.");
                        }
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                ret = Interop.ApplicationManager.AppInfoFilterForeachAppinfo(filter.Handle, cb, IntPtr.Zero);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, IntPtr.Zero, "GetInstalledAppsAsync(InstalledApplicationFilter) failed.");
                }
                return Result;
            });
        }

        internal async Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync(InstalledApplicationMetadataFilter filter)
        {
            Log.Debug(LogTag, "GetInstalledAppsAsync(InstalledApplicationMetadataFilter filter)");

            return await Task.Run(() =>
            {
                List<InstalledApplication> Result = new List<InstalledApplication>();

                Interop.ApplicationManager.AppInfoFilterCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    Log.Debug(LogTag, "AppInfoFilterCallback");
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        ret = Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        if (ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(ret, clonedHandle, "GetInstalledAppsAsync(InstalledApplicationMetadataFilter) failed.");
                        }
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                ret = Interop.ApplicationManager.AppInfoMetadataFilterForeach(filter.Handle, cb, IntPtr.Zero);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, filter.Handle, "GetInstalledAppsAsync(InstalledApplicationMetadataFilter) failed.");
                }
                return Result;
            });
        }

        internal async Task<IEnumerable<RunningApplication>> GetRunningAppsAsync()
        {
            Log.Debug(LogTag, "GetRunningAppsAsync()");

            return await Task.Run(() =>
            {
                List<RunningApplication> Result = new List<RunningApplication>();

                Interop.ApplicationManager.AppManagerAppContextCallback cb = (IntPtr handle, IntPtr userData) =>
                {
                    Log.Debug(LogTag, "AppManagerAppContextCallback");
                    if (handle != IntPtr.Zero)
                    {
                        IntPtr ptr = IntPtr.Zero;
                        ret = Interop.ApplicationManager.AppContextGetAppId(handle, out ptr);
                        if (ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "GetRunningAppsAsync() failed.");
                        }
                        string appid = Marshal.PtrToStringAuto(ptr);
                        int pid = 0;
                        ret = Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                        if (ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "GetRunningAppsAsync() failed.");
                        }
                        RunningApplication app = new RunningApplication(appid, pid);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                ret = Interop.ApplicationManager.AppManagerForeachAppContext(cb, IntPtr.Zero);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, IntPtr.Zero, "GetRunningAppsAsync() failed.");
                }
                return Result;
            });
        }

        internal InstalledApplication GetInstalledApp(string applicationId)
        {
            Log.Debug(LogTag, "GetInstalledApp(applicationId)");
            IntPtr handle = IntPtr.Zero;
            ret = Interop.ApplicationManager.AppManagerGetAppInfo(applicationId, out handle);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "GetInstalledApp(applicationId) failed.");
            }
            if (handle != IntPtr.Zero)
            {
                InstalledApplication app = new InstalledApplication(handle);
                return app;
            }
            return null;
        }

        internal RunningApplication GetRunningApp(string applicationId)
        {
            Log.Debug(LogTag, "GetRunningApp(applicationId)");
            IntPtr handle = IntPtr.Zero;
            ret = Interop.ApplicationManager.AppManagerGetAppContext(applicationId, out handle);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "GetRunningApp(applicationId) failed.");
            }
            if (handle != IntPtr.Zero)
            {
                int pid = 0;
                ret = Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "GetRunningApp(applicationId) failed.");
                }
                RunningApplication app = new RunningApplication(applicationId, pid);
                return app;
            }
            return null;
        }

        internal RunningApplication GetRunningApp(int processId)
        {
            Log.Debug(LogTag, "GetRunningApp(processId)");
            string appid = "";
            ret = Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, IntPtr.Zero, "GetRunningApp(processId) failed.");
            }
            RunningApplication app = new RunningApplication(appid, processId);
            return app;
        }

        internal bool IsRunningApp(string applicationId)
        {
            Log.Debug(LogTag, "IsRunningApp(applicationId)");
            bool running = false;
            ret = Interop.ApplicationManager.AppManagerIsRunning(applicationId, out running);
            if (ret != 0)
            {
                Log.Warn(LogTag, "IsRunningApp(applicationId) failed.");
            }
            return running;
        }

        internal bool IsRunningApp(int processId)
        {
            Log.Debug(LogTag, "IsRunningApp(processId)");
            string appid = "";
            ret = Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, IntPtr.Zero, "IsRunningApp(processId) failed.");
            }
            bool running = false;
            ret = Interop.ApplicationManager.AppManagerIsRunning(appid, out running);
            if (ret != 0)
            {
                Log.Warn(LogTag, "IsRunningApp(processId) failed.");
            }
            return running;
        }

        private void RegisterApplicationChangedEvent()
        {
            Log.Debug(LogTag, "RegisterApplicationChangedEvent()");
            _applicationChangedEventCallback = (IntPtr handle, int state, IntPtr userData) =>
            {
                Log.Debug(LogTag, "ApplicationChangedEventCallback");
                if (handle == IntPtr.Zero) return;

                IntPtr ptr = IntPtr.Zero;
                ret = Interop.ApplicationManager.AppContextGetAppId(handle, out ptr);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "RegisterApplicationChangedEvent() failed.");
                }
                string appid = Marshal.PtrToStringAuto(ptr);
                int pid = 0;
                ret = Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "RegisterApplicationChangedEvent() failed.");
                }
                if (state == 0)
                {
                    var launchedEventCache = ApplicationLaunched;
                    if (launchedEventCache != null)
                    {
                        Log.Debug(LogTag, "Raise up ApplicationLaunched");
                        ApplicationChangedEventArgs e = new ApplicationChangedEventArgs(appid, pid, state);
                        launchedEventCache(null, e);
                    }
                }
                else if (state == 1)
                {
                    var terminatedEventCache = ApplicationTerminated;
                    if (terminatedEventCache != null)
                    {
                        Log.Debug(LogTag, "Raise up ApplicationTerminated");
                        ApplicationChangedEventArgs e = new ApplicationChangedEventArgs(appid, pid, state);
                        terminatedEventCache(null, e);
                    }
                }
            };
            ret = Interop.ApplicationManager.AppManagerSetAppContextEvent(_applicationChangedEventCallback, IntPtr.Zero);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, IntPtr.Zero, "RegisterApplicationChangedEvent() register failed.");
            }
        }

        private void UnRegisterApplicationChangedEvent()
        {
            Log.Debug(LogTag, "UnRegisterApplicationChangedEvent()");
            Interop.ApplicationManager.AppManagerUnSetAppContextEvent();
        }
    }
}
