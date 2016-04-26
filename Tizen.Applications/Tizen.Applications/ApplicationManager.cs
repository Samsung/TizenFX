// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// This class has the methods and events of the ApplicationManager.
    /// </summary>
    public static class ApplicationManager
    {
        private const string LogTag = "Tizen.Applications";

        private static EventHandler<ApplicationLaunchedEventArgs> s_launchedHandler;
        private static EventHandler<ApplicationTerminatedEventArgs> s_terminatedHandler;

        private static Interop.ApplicationManager.AppManagerAppContextEventCallback s_applicationChangedEventCallback;

        /// <summary>
        /// Occurs whenever the installed applications get launched.
        /// </summary>
        public static event EventHandler<ApplicationLaunchedEventArgs> ApplicationLaunched
        {
            add
            {
                if (s_launchedHandler == null && s_terminatedHandler == null)
                {
                    RegisterApplicationChangedEvent();
                }
                s_launchedHandler += value;
            }
            remove
            {
                s_launchedHandler -= value;
                if (s_launchedHandler == null && s_terminatedHandler == null)
                {
                    UnRegisterApplicationChangedEvent();
                }
            }
        }

        /// <summary>
        /// Occurs whenever the installed applications get terminated.
        /// </summary>
        public static event EventHandler<ApplicationTerminatedEventArgs> ApplicationTerminated
        {
            add
            {
                if (s_launchedHandler == null && s_terminatedHandler == null)
                {
                    RegisterApplicationChangedEvent();
                }
                s_terminatedHandler += value;
            }
            remove
            {
                s_terminatedHandler -= value;
                if (s_launchedHandler == null && s_terminatedHandler == null)
                {
                    UnRegisterApplicationChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets the information of the installed applications asynchronously.
        /// </summary>
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
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to foreach the appinfo.");
                }
                return result;
            });
        }

        /// <summary>
        /// Gets the information of the installed applications with the ApplicationInfoFilter asynchronously.
        /// </summary>
        /// <param name="filter">Key-value pairs for filtering.</param>
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
                filter.Fetch(cb);
                return result;
            });
        }

        /// <summary>
        /// Gets the information of the installed applications with the ApplicationInfoMetadataFilter asynchronously.
        /// </summary>
        /// <param name="filter">Key-value pairs for filtering.</param>
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
                filter.Fetch(cb);
                return result;
            });
        }

        /// <summary>
        /// Gets the information of the running applications asynchronously.
        /// </summary>
        public static async Task<IEnumerable<ApplicationInfo>> GetRunningApplicationsAsync()
        {
            return await Task.Run(() =>
            {
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
                List<ApplicationInfo> result = new List<ApplicationInfo>();

                Interop.ApplicationManager.AppManagerAppContextCallback cb = (IntPtr contextHandle, IntPtr userData) =>
                {
                    if (contextHandle != IntPtr.Zero)
                    {
                        string appid = string.Empty;
                        err = Interop.ApplicationManager.AppContextGetAppId(contextHandle, out appid);
                        if (err != Interop.ApplicationManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to get appid. err = " + err);
                            return false;
                        }
                        ApplicationInfo app = GetInstalledApplication(appid);
                        if (app != null)
                        {
                            result.Add(app);
                            return true;
                        }
                    }
                    return false;
                };

                err = Interop.ApplicationManager.AppManagerForeachAppContext(cb, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    throw ApplicationManagerErrorFactory.GetException(err, "Failed to foreach appcontext.");
                }
                return result;
            });
        }

        /// <summary>
        /// Gets the information of the specified application with the application id.
        /// </summary>
        /// <param name="applicationId">Application id.</param>
        public static ApplicationInfo GetInstalledApplication(string applicationId)
        {
            IntPtr infoHandle = IntPtr.Zero;
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppManagerGetAppInfo(applicationId, out infoHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to get the installed application information.");
            }
            ApplicationInfo app = new ApplicationInfo(infoHandle);
            return app;
        }

        private static void RegisterApplicationChangedEvent()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            s_applicationChangedEventCallback = (IntPtr contextHandle, Interop.ApplicationManager.AppContextEvent state, IntPtr userData) =>
            {
                if (contextHandle == IntPtr.Zero) return;
                try
                {
                    string appid = string.Empty;
                    err = Interop.ApplicationManager.AppContextGetAppId(contextHandle, out appid);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        throw ApplicationManagerErrorFactory.GetException(err, "Failed to get application id.");
                    }

                    ApplicationInfo appInfo = GetInstalledApplication(appid);
                    if (state == Interop.ApplicationManager.AppContextEvent.Launched)
                    {
                        s_launchedHandler?.Invoke(null, new ApplicationLaunchedEventArgs { ApplicationInfo = appInfo });
                    }
                    else if (state == Interop.ApplicationManager.AppContextEvent.Terminated)
                    {
                        s_terminatedHandler?.Invoke(null, new ApplicationTerminatedEventArgs { ApplicationInfo = appInfo });
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(LogTag, e.Message);
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
                    (item.Key == ApplicationInfoFilter.Keys.Category))
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
