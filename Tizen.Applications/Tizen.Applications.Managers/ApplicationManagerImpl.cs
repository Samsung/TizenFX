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
        private static ApplicationManagerImpl s_instance = new ApplicationManagerImpl();

        private bool _disposed = false;
        private Interop.ApplicationManager.AppManagerAppContextEventCallback _applicationChangedEventCallback;

        private const string LogTag = "Tizen.Applications.Managers";
        private int _ret = 0;

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
                return s_instance;
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
                        _ret = Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        if (_ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(_ret, clonedHandle, "GetInstalledAppsAsync() failed.");
                        }
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };
                _ret = Interop.ApplicationManager.AppManagerForeachAppInfo(cb, IntPtr.Zero);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, IntPtr.Zero, "GetInstalledAppsAsync() failed.");
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
                        _ret = Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        if (_ret != 0)
                        {
                            ApplicationManagerErrorFactory.ExceptionChecker(_ret, clonedHandle, "GetInstalledAppsAsync(InstalledApplicationFilter) failed.");
                        }
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                IntPtr appInfoFilter = MakeNativeAppInfoFilter(filter.Filter);
                _ret = Interop.ApplicationManager.AppInfoFilterForeachAppinfo(appInfoFilter, cb, IntPtr.Zero);
                if (appInfoFilter != IntPtr.Zero)
                    Interop.ApplicationManager.AppInfoFilterDestroy(appInfoFilter);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, IntPtr.Zero, "GetInstalledAppsAsync(InstalledApplicationFilter) failed.");
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
                        _ret = Interop.ApplicationManager.AppInfoClone(out clonedHandle, handle);
                        if (_ret != 0)
                        {
                            return false;
                        }
                        InstalledApplication app = new InstalledApplication(clonedHandle);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };
                IntPtr appMedataFilter = MakeNativeAppMetadataFilter(filter.Filter);
                _ret = Interop.ApplicationManager.AppInfoMetadataFilterForeach(appMedataFilter, cb, IntPtr.Zero);
                if (appMedataFilter != IntPtr.Zero)
                    Interop.ApplicationManager.AppInfoMetadataFilterDestroy(appMedataFilter);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, appMedataFilter, "GetInstalledAppsAsync(InstalledApplicationMetadataFilter) failed.");
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
                        _ret = Interop.ApplicationManager.AppContextGetAppId(handle, out ptr);
                        if (_ret != 0)
                        {
                            return false;
                        }
                        string appid = Marshal.PtrToStringAuto(ptr);
                        int pid = 0;
                        _ret = Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                        if (_ret != 0)
                        {
                            return false;
                        }
                        RunningApplication app = new RunningApplication(appid, pid);
                        Result.Add(app);
                        return true;
                    }
                    return false;
                };

                _ret = Interop.ApplicationManager.AppManagerForeachAppContext(cb, IntPtr.Zero);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, IntPtr.Zero, "GetRunningAppsAsync() failed.");
                }
                return Result;
            });
        }

        internal InstalledApplication GetInstalledApp(string applicationId)
        {
            Log.Debug(LogTag, "GetInstalledApp(applicationId)");
            IntPtr handle = IntPtr.Zero;
            _ret = Interop.ApplicationManager.AppManagerGetAppInfo(applicationId, out handle);
            if (_ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(_ret, handle, "GetInstalledApp(applicationId) failed.");
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
            _ret = Interop.ApplicationManager.AppManagerGetAppContext(applicationId, out handle);
            if (_ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(_ret, handle, "GetRunningApp(applicationId) failed.");
            }
            if (handle != IntPtr.Zero)
            {
                int pid = 0;
                _ret = Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, handle, "GetRunningApp(applicationId) failed.");
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
            _ret = Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            if (_ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(_ret, IntPtr.Zero, "GetRunningApp(processId) failed.");
            }
            RunningApplication app = new RunningApplication(appid, processId);
            return app;
        }

        internal bool IsRunningApp(string applicationId)
        {
            Log.Debug(LogTag, "IsRunningApp(applicationId)");
            bool running = false;
            _ret = Interop.ApplicationManager.AppManagerIsRunning(applicationId, out running);
            if (_ret != 0)
            {
                Log.Warn(LogTag, "IsRunningApp(applicationId) failed.");
            }
            return running;
        }

        internal bool IsRunningApp(int processId)
        {
            Log.Debug(LogTag, "IsRunningApp(processId)");
            string appid = "";
            _ret = Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            if (_ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(_ret, IntPtr.Zero, "IsRunningApp(processId) failed.");
            }
            bool running = false;
            _ret = Interop.ApplicationManager.AppManagerIsRunning(appid, out running);
            if (_ret != 0)
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
                _ret = Interop.ApplicationManager.AppContextGetAppId(handle, out ptr);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, handle, "RegisterApplicationChangedEvent() failed.");
                }
                string appid = Marshal.PtrToStringAuto(ptr);
                int pid = 0;
                _ret = Interop.ApplicationManager.AppContextGetPid(handle, out pid);
                if (_ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(_ret, handle, "RegisterApplicationChangedEvent() failed.");
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
            _ret = Interop.ApplicationManager.AppManagerSetAppContextEvent(_applicationChangedEventCallback, IntPtr.Zero);
            if (_ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(_ret, IntPtr.Zero, "RegisterApplicationChangedEvent() register failed.");
            }
        }

        private void UnRegisterApplicationChangedEvent()
        {
            Log.Debug(LogTag, "UnRegisterApplicationChangedEvent()");
            Interop.ApplicationManager.AppManagerUnSetAppContextEvent();
        }

        private static IntPtr MakeNativeAppInfoFilter(IDictionary<string, string> filter)
        {
            if (filter == null)
                throw new ArgumentException("Filter dose not added");
            IntPtr handle;
            int ret = Interop.ApplicationManager.AppInfoFilterCreate(out handle);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "AppInfoFilter creation failed.");
            }

            foreach (var item in filter)
            {
                if ((item.Key == InstalledApplicationFilter.Keys.Id) ||
                    (item.Key == InstalledApplicationFilter.Keys.Type) ||
                    (item.Key == InstalledApplicationFilter.Keys.Category))
                {
                    ret = Interop.ApplicationManager.AppInfoFilterAddString(handle, item.Key, item.Value);
                }
                else if ((item.Key == InstalledApplicationFilter.Keys.NoDisplay) ||
                         (item.Key == InstalledApplicationFilter.Keys.TaskManage))
                {
                    ret = Interop.ApplicationManager.AppInfoFilterAddBool(handle, item.Key, Convert.ToBoolean(item.Value));
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplicationFilter is NOT supported " + item.Key + " key.");
                }
                if (ret != 0)
                {
                    Interop.ApplicationManager.AppInfoFilterDestroy(handle);
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "InstalledApplicationFilter item add failed.");
                }
            }
            return handle;
        }

        private static IntPtr MakeNativeAppMetadataFilter(IDictionary<string, string> filter)
        {
            if (filter == null)
                throw new ArgumentException("Filter dose not added");
            IntPtr handle;
            int ret = Interop.ApplicationManager.AppInfoMetadataFilterCreate(out handle);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "InstalledApplicationMetadataFilter creation failed.");
            }
            foreach (var item in filter)
            {
                ret = Interop.ApplicationManager.AppInfoMetadataFilterAdd(handle, item.Key, item.Value);
                if (ret != 0)
                {
                    Interop.ApplicationManager.AppInfoMetadataFilterDestroy(handle);
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, handle, "InstalledApplicationMetadataFilter item add failed.");
                }
            }
            return handle;
        }
    }
}
