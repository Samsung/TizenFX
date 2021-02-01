/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Interop.ApplicationManager;

namespace Tizen.Applications
{
    /// <summary>
    /// This class has the methods and events of the ApplicationManager.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class ApplicationManager
    {
        private const string LogTag = "Tizen.Applications";
        private static EventHandler<ApplicationLaunchedEventArgs> s_launchedHandler;
        private static EventHandler<ApplicationTerminatedEventArgs> s_terminatedHandler;
        private static Interop.ApplicationManager.AppManagerAppContextEventCallback s_applicationChangedEventCallback;
        private static EventHandler<ApplicationEnabledEventArgs> s_enabledHandler;
        private static EventHandler<ApplicationDisabledEventArgs> s_disabledHandler;
        private static Interop.ApplicationManager.AppManagerEventCallback s_eventCallback;
        private static IntPtr _eventHandle = IntPtr.Zero;
        private static readonly object s_eventLock = new object();
        private static readonly object s_applicationChangedEventLock = new object();

        /// <summary>
        /// Occurs whenever the installed application is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<ApplicationEnabledEventArgs> ApplicationEnabled
        {
            add
            {
                lock (s_eventLock)
                {
                    if (s_eventCallback == null)
                    {
                        RegisterApplicationEvent();
                    }
                    s_enabledHandler += value;
                }
            }
            remove
            {
                lock (s_eventLock)
                {
                    s_enabledHandler -= value;
                    if (s_enabledHandler == null && s_disabledHandler == null && s_eventCallback != null)
                    {
                        UnRegisterApplicationEvent();
                        s_eventCallback = null;
                    }
                }
            }
        }

        /// <summary>
        /// Occurs whenever the installed application is disabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<ApplicationDisabledEventArgs> ApplicationDisabled
        {
            add
            {
                lock (s_eventLock)
                {
                    if (s_eventCallback == null)
                    {
                        RegisterApplicationEvent();
                    }
                    s_disabledHandler += value;
                }
            }
            remove
            {
                lock (s_eventLock)
                {
                    s_disabledHandler -= value;
                    if (s_enabledHandler == null && s_disabledHandler == null && s_eventCallback != null)
                    {
                        UnRegisterApplicationEvent();
                        s_eventCallback = null;
                    }
                }
            }
        }

        /// <summary>
        /// Occurs whenever the installed applications get launched.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<ApplicationLaunchedEventArgs> ApplicationLaunched
        {
            add
            {
                lock (s_applicationChangedEventLock)
                {
                    if (s_applicationChangedEventCallback == null)
                    {
                        RegisterApplicationChangedEvent();
                    }
                    s_launchedHandler += value;
                }
            }
            remove
            {
                lock (s_applicationChangedEventLock)
                {
                    s_launchedHandler -= value;
                    if (s_launchedHandler == null && s_terminatedHandler == null && s_applicationChangedEventCallback != null)
                    {
                        UnRegisterApplicationChangedEvent();
                        s_applicationChangedEventCallback = null;
                    }
                }
            }
        }

        /// <summary>
        /// Occurs whenever the installed applications get terminated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<ApplicationTerminatedEventArgs> ApplicationTerminated
        {
            add
            {
                lock (s_applicationChangedEventLock)
                {
                    if (s_applicationChangedEventCallback == null)
                    {
                        RegisterApplicationChangedEvent();
                    }
                    s_terminatedHandler += value;
                }
            }
            remove
            {
                lock (s_applicationChangedEventLock)
                {
                    s_terminatedHandler -= value;
                    if (s_launchedHandler == null && s_terminatedHandler == null && s_applicationChangedEventCallback != null)
                    {
                        UnRegisterApplicationChangedEvent();
                        s_applicationChangedEventCallback = null;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the information of the installed applications asynchronously.
        /// </summary>
        /// <returns>The installed application info list.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<IEnumerable<ApplicationInfo>> GetInstalledApplicationsAsync()
        {
            return await Task.Run(() =>
            {
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
                List<ApplicationInfo> result = new List<ApplicationInfo>();

                Interop.ApplicationManager.AppManagerAppInfoCallback cb = (IntPtr infoHandle, IntPtr userData) =>
                {
                    if (infoHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        err = Interop.ApplicationManager.AppInfoClone(out clonedHandle, infoHandle);
                        if (err != Interop.ApplicationManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the appinfo. err = " + err);
                            return false;
                        }
                        ApplicationInfo app = new ApplicationInfo(clonedHandle);
                        result.Add(app);
                        return true;
                    }
                    return false;
                };
                err = Interop.ApplicationManager.AppManagerForeachAppInfo(cb, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to retrieve the application Info. err " + err.ToString());
                }
                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Terminates the application if it is running on background.
        /// </summary>
        /// <param name="app">ApplicationRunningContext object</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.kill.bgapp</privilege>
        /// <remarks>
        /// This function returns after it just sends a request for terminating a background application.
        /// Platform will decide if the target application could be terminated or not according to the state of the target application.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public static void TerminateBackgroundApplication(ApplicationRunningContext app)
        {
            ErrorCode err = Interop.ApplicationManager.AppManagerRequestTerminateBgApp(app._contextHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.ApplicationManager.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid argument.");
                    case Interop.ApplicationManager.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException("Permission denied.");
                    default:
                        throw new InvalidOperationException("Invalid Operation.");
                }
            }
        }

        /// <summary>
        /// Gets the information of the installed applications with the ApplicationInfoFilter asynchronously.
        /// </summary>
        /// <param name="filter">Key-value pairs for filtering.</param>
        /// <returns>The installed application info list.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<IEnumerable<ApplicationInfo>> GetInstalledApplicationsAsync(ApplicationInfoFilter filter)
        {
            return await Task.Run(() =>
            {
                List<ApplicationInfo> result = new List<ApplicationInfo>();

                Interop.ApplicationManager.AppInfoFilterCallback cb = (IntPtr infoHandle, IntPtr userData) =>
                {
                    if (infoHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoClone(out clonedHandle, infoHandle);
                        if (err != Interop.ApplicationManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the appinfo. err = " + err);
                            return false;
                        }
                        ApplicationInfo app = new ApplicationInfo(clonedHandle);
                        result.Add(app);
                        return true;
                    }
                    return false;
                };

                try
                {
                    filter.Fetch(cb);
                }
                catch (InvalidOperationException)
                {
                    Log.Error(LogTag, "InvalidOperationException occurs");
                }
                catch (ArgumentException)
                {
                    Log.Error(LogTag, "ArgumentException occurs");
                }

                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information of the installed applications with the ApplicationInfoMetadataFilter asynchronously.
        /// </summary>
        /// <param name="filter">Key-value pairs for filtering.</param>
        /// <returns>The installed application info list.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<IEnumerable<ApplicationInfo>> GetInstalledApplicationsAsync(ApplicationInfoMetadataFilter filter)
        {
            return await Task.Run(() =>
            {
                List<ApplicationInfo> result = new List<ApplicationInfo>();

                Interop.ApplicationManager.AppInfoFilterCallback cb = (IntPtr infoHandle, IntPtr userData) =>
                {
                    if (infoHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoClone(out clonedHandle, infoHandle);
                        if (err != Interop.ApplicationManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the appinfo. err = " + err);
                            return false;
                        }
                        ApplicationInfo app = new ApplicationInfo(clonedHandle);
                        result.Add(app);
                        return true;
                    }
                    return false;
                };

                try
                {
                    filter.Fetch(cb);
                }
                catch (InvalidOperationException)
                {
                    Log.Error(LogTag, "InvalidOperationException occurs");
                }
                catch (ArgumentException)
                {
                    Log.Error(LogTag, "ArgumentException occurs");
                }

                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information of the running applications asynchronously.
        /// </summary>
        /// <returns>The application running context list.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<IEnumerable<ApplicationRunningContext>> GetRunningApplicationsAsync()
        {
            return await Task.Run(() =>
            {
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
                List<ApplicationRunningContext> result = new List<ApplicationRunningContext>();

                Interop.ApplicationManager.AppManagerAppContextCallback cb = (IntPtr contextHandle, IntPtr userData) =>
                {
                    if (contextHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        err = Interop.ApplicationManager.AppContextClone(out clonedHandle, contextHandle);
                        if (err != Interop.ApplicationManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the app context. err = " + err);
                            return false;
                        }
                        ApplicationRunningContext context = new ApplicationRunningContext(clonedHandle);
                        result.Add(context);
                        return true;
                    }
                    return false;
                };

                err = Interop.ApplicationManager.AppManagerForeachAppContext(cb, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to retrieve the running app context. err " + err.ToString());
                }
                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information of the running applications including subapp asynchronously.
        /// </summary>
        /// <returns>The application running context list.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<IEnumerable<ApplicationRunningContext>> GetAllRunningApplicationsAsync()
        {
            return await Task.Run(() =>
            {
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
                List<ApplicationRunningContext> result = new List<ApplicationRunningContext>();

                Interop.ApplicationManager.AppManagerAppContextCallback cb = (IntPtr contextHandle, IntPtr userData) =>
                {
                    if (contextHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        err = Interop.ApplicationManager.AppContextClone(out clonedHandle, contextHandle);
                        if (err != Interop.ApplicationManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the app context. err = " + err);
                            return false;
                        }
                        ApplicationRunningContext context = new ApplicationRunningContext(clonedHandle);
                        result.Add(context);
                        return true;
                    }
                    return false;
                };

                err = Interop.ApplicationManager.AppManagerForeachRunningAppContext(cb, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to retrieve the running app context. err " + err.ToString());
                }
                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information of the specified application with the application ID.
        /// </summary>
        /// <param name="applicationId">Application ID.</param>
        /// <returns>The application info.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static ApplicationInfo GetInstalledApplication(string applicationId)
        {
            IntPtr infoHandle = IntPtr.Zero;
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppManagerGetAppInfo(applicationId, out infoHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to get the installed application information of " + applicationId + ".");
            }
            ApplicationInfo app = new ApplicationInfo(infoHandle);
            return app;
        }

        /// <summary>
        /// Returns if the specified application is running or not.
        /// </summary>
        /// <param name="applicationId">The application ID.</param>
        /// <returns>Returns true if the given application is running, otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown when the given parameter is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool IsRunning(string applicationId)
        {
            bool isRunning = false;
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppManagerIsRunning(applicationId, out isRunning);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(Interop.ApplicationManager.ErrorCode.InvalidParameter, "Invalid parameter");
            }
            return isRunning;
        }

        /// <summary>
        /// Returns the application id.
        /// </summary>
        /// <param name="processId">The application pid.</param>
        /// <returns>Returns the application id.</returns>
        /// <exception cref="ArgumentException">Thrown when the given parameter is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static string GetAppId(int processId)
        {
            string appid;
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppManagerGetAppId(processId, out appid);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "fail to get appid(" + processId + ")");
            }
            return appid;
        }

        private static void RegisterApplicationChangedEvent()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            s_applicationChangedEventCallback = (IntPtr contextHandle, Interop.ApplicationManager.AppContextEvent state, IntPtr userData) =>
            {
                if (contextHandle == IntPtr.Zero) return;

                IntPtr clonedHandle = IntPtr.Zero;
                err = Interop.ApplicationManager.AppContextClone(out clonedHandle, contextHandle);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to register the application context event.");
                }
                using (ApplicationRunningContext context = new ApplicationRunningContext(clonedHandle))
                {
                    lock (s_applicationChangedEventLock)
                    {
                        if (state == Interop.ApplicationManager.AppContextEvent.Launched)
                        {
                            s_launchedHandler?.Invoke(null, new ApplicationLaunchedEventArgs { ApplicationRunningContext = context });
                        }
                        else if (state == Interop.ApplicationManager.AppContextEvent.Terminated)
                        {
                            s_terminatedHandler?.Invoke(null, new ApplicationTerminatedEventArgs { ApplicationRunningContext = context });
                        }
                    }
                }
            };
            err = Interop.ApplicationManager.AppManagerSetAppContextEvent(s_applicationChangedEventCallback, IntPtr.Zero);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to register the application context event.");
            }
        }

        private static void UnRegisterApplicationChangedEvent()
        {
            Interop.ApplicationManager.AppManagerUnSetAppContextEvent();
        }

        private static void RegisterApplicationEvent()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            err = Interop.ApplicationManager.AppManagerEventCreate(out _eventHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to create the application event handle");
            }

            err = Interop.ApplicationManager.AppManagerEventSetStatus(_eventHandle, Interop.ApplicationManager.AppManagerEventStatusType.All);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                Interop.ApplicationManager.AppManagerEventDestroy(_eventHandle);
                _eventHandle = IntPtr.Zero;
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to set the application event");
            }

            s_eventCallback = (string appType, string appId, Interop.ApplicationManager.AppManagerEventType eventType, Interop.ApplicationManager.AppManagerEventState eventState, IntPtr eventHandle, IntPtr UserData) =>
            {
                lock (s_eventLock)
                {
                    if (eventType == Interop.ApplicationManager.AppManagerEventType.Enable)
                    {
                        s_enabledHandler?.Invoke(null, new ApplicationEnabledEventArgs(appId, (ApplicationEventState)eventState));
                    }
                    else if (eventType == Interop.ApplicationManager.AppManagerEventType.Disable)
                    {
                        s_disabledHandler?.Invoke(null, new ApplicationDisabledEventArgs(appId, (ApplicationEventState)eventState));
                    }
                }
            };
            err = Interop.ApplicationManager.AppManagerSetEventCallback(_eventHandle, s_eventCallback, IntPtr.Zero);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                Interop.ApplicationManager.AppManagerEventDestroy(_eventHandle);
                _eventHandle = IntPtr.Zero;
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to set the application event callback");
            }
        }

        private static void UnRegisterApplicationEvent()
        {
            if (_eventHandle != IntPtr.Zero)
            {
                Interop.ApplicationManager.AppManagerUnSetEventCallback(_eventHandle);
                Interop.ApplicationManager.AppManagerEventDestroy(_eventHandle);
                _eventHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the information of the recent applications.
        /// </summary>
        /// <returns>Returns a dictionary containing all the recent application info.</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IEnumerable<RecentApplicationInfo> GetRecentApplications()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

            List<RecentApplicationInfo> result = new List<RecentApplicationInfo>();
            IntPtr table;
            int nrows, ncols;

            err = Interop.ApplicationManager.RuaHistoryLoadDb(out table, out nrows, out ncols);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to load a table for the recent application list.");
            }

            for (int row = 0; row < nrows; ++row)
            {
                Interop.ApplicationManager.RuaRec record;

                err = Interop.ApplicationManager.RuaHistoryGetRecord(out record, table, nrows, ncols, row);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to get record.");
                }

                RecentApplicationInfo info = new RecentApplicationInfo(record);
                result.Add(info);
            }

            err = Interop.ApplicationManager.RuaHistoryUnLoadDb(ref table);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to unload a table for the recent application list.");
            }

            return result;
        }

        /// <summary>
        /// Attaches the window of the child application to the window of the parent application.
        /// </summary>
        /// <remarks>
        /// This method is only available for platform level signed applications.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AttachWindow(string parentAppId, string childAppId)
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

            err = Interop.ApplicationManager.AppManagerAttachWindow(parentAppId, childAppId);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.ApplicationManager.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid argument.");
                    case Interop.ApplicationManager.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException("Permission denied.");
                    case Interop.ApplicationManager.ErrorCode.IoError:
                        throw new InvalidOperationException("IO error at unmanaged code.");
                    case Interop.ApplicationManager.ErrorCode.OutOfMemory:
                        throw new InvalidOperationException("Out-of-memory at unmanaged code.");
                    case Interop.ApplicationManager.ErrorCode.NoSuchApp:
                        throw new InvalidOperationException("No such application.");
                }
            }

        }

        /// <summary>
        /// Detaches the window of the application from its parent window.
        /// </summary>
        /// <remarks>
        /// This method is only available for platform level signed applications.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DetachWindow(string applicationId)
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

            err = Interop.ApplicationManager.AppManagerDetachWindow(applicationId);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.ApplicationManager.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid argument.");
                    case Interop.ApplicationManager.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException("Permission denied.");
                    case Interop.ApplicationManager.ErrorCode.IoError:
                        throw new InvalidOperationException("IO error at unmanaged code.");
                    case Interop.ApplicationManager.ErrorCode.OutOfMemory:
                        throw new InvalidOperationException("Out-of-memory at unmanaged code.");
                    case Interop.ApplicationManager.ErrorCode.NoSuchApp:
                        throw new InvalidOperationException("No such application.");
                }
            }
        }
    }

    internal static class FilterExtension
    {
        private const string LogTag = "Tizen.Applications";
        internal static void Fetch(this ApplicationInfoFilter filter, Interop.ApplicationManager.AppInfoFilterCallback callback)
        {
            if (filter is ApplicationInfoMetadataFilter)
            {
                ApplicationInfoMetadataFilter metaFilter = (ApplicationInfoMetadataFilter)filter;
                metaFilter.Fetch(callback);
                return;
            }

            IntPtr nativeHandle = MakeNativeAppInfoFilter(filter.Filter);
            if (nativeHandle == IntPtr.Zero)
            {
                throw ApplicationManagerErrorFactory.NativeFilterHandleIsInvalid();
            }
            try
            {
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoFilterForeachAppinfo(nativeHandle, callback, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to get application information list with filter.");
                }
            }
            finally
            {
                Interop.ApplicationManager.AppInfoFilterDestroy(nativeHandle);
            }
        }

        internal static void Fetch(this ApplicationInfoMetadataFilter filter, Interop.ApplicationManager.AppInfoFilterCallback callback)
        {
            IntPtr nativeHandle = MakeNativeAppMetadataFilter(filter.Filter);
            if (nativeHandle == IntPtr.Zero)
            {
                throw ApplicationManagerErrorFactory.NativeFilterHandleIsInvalid();
            }
            try
            {
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoMetadataFilterForeach(nativeHandle, callback, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to get metadata list with filter.");
                }
            }
            finally
            {
                Interop.ApplicationManager.AppInfoMetadataFilterDestroy(nativeHandle);
            }
        }

        private static IntPtr MakeNativeAppInfoFilter(IDictionary<string, string> filter)
        {
            if (filter == null || filter.Count == 0)
            {
                throw ApplicationManagerErrorFactory.FilterIsInvalid();
            }

            IntPtr infoHandle = IntPtr.Zero;
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoFilterCreate(out infoHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to create the filter handle.");
            }

            foreach (var item in filter)
            {
                if ((item.Key == ApplicationInfoFilter.Keys.Id) ||
                    (item.Key == ApplicationInfoFilter.Keys.Type) ||
                    (item.Key == ApplicationInfoFilter.Keys.Category) ||
                    (item.Key == ApplicationInfoFilter.Keys.InstalledStorage))
                {
                    err = Interop.ApplicationManager.AppInfoFilterAddString(infoHandle, item.Key, item.Value);
                }
                else if ((item.Key == ApplicationInfoFilter.Keys.NoDisplay) ||
                         (item.Key == ApplicationInfoFilter.Keys.TaskManage))
                {
                    err = Interop.ApplicationManager.AppInfoFilterAddBool(infoHandle, item.Key, Convert.ToBoolean(item.Value));
                }
                else
                {
                    Log.Warn(LogTag, string.Format("'{0}' is not supported key for the filter.", item.Key));
                }
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Interop.ApplicationManager.AppInfoFilterDestroy(infoHandle);
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to add item to the filter.");
                }
            }
            return infoHandle;
        }

        private static IntPtr MakeNativeAppMetadataFilter(IDictionary<string, string> filter)
        {
            if (filter == null || filter.Count == 0)
            {
                throw ApplicationManagerErrorFactory.FilterIsInvalid();
            }

            IntPtr infoHandle = IntPtr.Zero;
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoMetadataFilterCreate(out infoHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to create the filter for searching with metadata.");
            }
            foreach (var item in filter)
            {
                err = Interop.ApplicationManager.AppInfoMetadataFilterAdd(infoHandle, item.Key, item.Value);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Interop.ApplicationManager.AppInfoMetadataFilterDestroy(infoHandle);
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to add the item to the filter.");
                }
            }
            return infoHandle;
        }
    }

    internal static class ApplicationManagerErrorFactory
    {
        internal static Exception NativeFilterHandleIsInvalid()
        {
            return new InvalidOperationException("The native handle for filtering is invalid.");
        }

        internal static Exception FilterIsInvalid()
        {
            return new ArgumentException("The filter is invalid.");
        }

        internal static Exception GetException(Interop.ApplicationManager.ErrorCode err, string message)
        {
            string errMessage = String.Format("{0} err = {1}", message, err);
            switch (err)
            {
                case Interop.ApplicationManager.ErrorCode.InvalidParameter:
                    return new ArgumentException(errMessage);
                default:
                    return new InvalidOperationException(errMessage);
            }
        }
    }
}
