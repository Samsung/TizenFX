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
        /// <remarks>
        /// This event is raised whenever the installed application is enabled. It provides information about the application that was enabled through the arguments passed in the event handler.
        /// </remarks>
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
        /// <remarks>
        /// This event is raised whenever the user disables an installed application through the Settings menu.
        /// The event handler receives an argument of type ApplicationDisabledEventArgs which contains information about the disabled application.
        /// </remarks>
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
        /// <remarks>
        /// This event provides information about the application that was just launched, including its package ID, version, and other details.
        /// It is useful for tracking and monitoring application launches in order to gather statistics or perform certain actions based on specific conditions.
        /// </remarks>
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
        /// <remarks>
        /// This event is raised whenever any application gets terminated on the device. It provides information about the terminated application through the arguments passed in the event handler.
        /// </remarks>
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
        /// Asynchronously retrieves information about the installed applications.
        /// </summary>
        /// <returns>An asynchronous task that returns a list containing information about the installed applications.</returns>
        /// <remarks>
        /// By calling this method, you can retrieve details about all the applications currently installed on the device. The returned list contains ApplicationInfo objects, which provide various properties such as package ID, version, and icon.
        /// </remarks>
        /// <example>
        /// To get the information of the installed applications, you can call the following code snippet:
        ///
        /// <code>
        /// var listApp = await ApplicationManager.GetInstalledApplicationsAsync();
        /// Assert.IsNotEmpty(_listApp, "The list of installed app should not be empty.");
        /// foreach (ApplicationInfo instapp in _listApp)
        /// {
        ///     Console.WriteLine(instapp.ApplicationId);
        /// }
        /// </code>
        /// </example>
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
            if (app == null)
            {
                throw new ArgumentException("Invalid argument.");
            }

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
        /// Retrieves the information about installed applications that match the specified filter criteria in an asynchronous manner.
        /// </summary>
        /// <remarks>
        /// By specifying the desired filter criteria through the <paramref name="filter"/> argument, you can retrieve only those applications that meet these conditions. The returned result will contain a list of ApplicationInfo objects representing the matched applications.
        /// </remarks>
        /// <param name="filter">An ApplicationInfoFilter containing the desired filter criteria.</param>
        /// <returns>An IEnumerable&lt;ApplicationInfo&gt; containing the information of the installed applications that match the specified filter.</returns>
        /// <example>
        /// The following code snippet demonstrates how to obtain the information of all installed applications:
        /// <code>
        /// var filter = new ApplicationInfoFilter();
        /// filter.Filter.Add(ApplicationInfoFilter.Keys.Id, "org.exmaple.hello");
        /// var apps = await GetInstalledApplicationsAsync(filter);
        /// foreach (var app in apps)
        /// {
        ///     Console.WriteLine(app.ApplicationId);
        /// }
        /// </code>
        /// </example>
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
        /// Asynchronously retrieves the information about installed applications filtered by the specified criteria in the form of ApplicationInfoMetadataFilter.
        /// </summary>
        /// <remarks>
        /// By providing the filter argument, you can specify various conditions such as package names, types, visibility status, etc., which will help narrow down the search results to only those that match the desired criteria.
        /// The returned result is a list of ApplicationInfo objects containing detailed information about each matched application.
        /// </remarks>
        /// <param name="filter">A dictionary of key-value pairs used to define the specific filtering criteria.</param>
        /// <returns>An enumerable collection of ApplicationInfo objects representing the installed applications that meet the specified filtering criteria.</returns>
        /// <example>
        /// To retrieve all visible applications:
        ///
        /// <code>
        /// var filter = new ApplicationInfoMetadataFilter();
        /// filter.Filter.Add("http://tizen.org/metadata/test-id", "org.exmaple.hello");
        /// var apps = await GetInstalledApplicationsAsync(filter);
        /// foreach (var app in apps)
        /// {
        ///     Console.WriteLine(app.ApplicationId);
        /// }
        /// </code>
        /// </example>
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
        /// Asynchronously retrieves the information about currently running applications.
        /// </summary>
        /// <returns>An enumerable list containing details about the running applications.</returns>
        /// <remarks>
        /// This method provides an efficient way to gather information about all the active apps on the device without blocking the current thread. It returns a task which can be awaited in order to obtain the desired result.
        /// </remarks>
        /// <example>
        /// Here's an example demonstrating how to retrieve the running applications and display their IDs:
        /// <code>
        /// await ApplicationManager.GetRunningApplicationsAsync().ContinueWith((task) => {
        ///     foreach (var app in task.Result) {
        ///         Console.WriteLine(app.ApplicationId);
        ///     }
        /// });
        /// </code>
        /// </example>
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
        /// Asynchronously retrieves the information about all currently running applications, including subapps.
        /// </summary>
        /// <returns>An enumerable list containing details about the running applications.</returns>
        /// <remarks>
        /// This method provides access to the current state of all active applications on the device, allowing you to gather information such as their IDs, types, and states.
        /// By utilizing this functionality, developers can gain insights into the overall system activity and make informed decisions based on the available data.
        /// </remarks>
        /// <example>
        /// Here is an example that demonstrates how to utilize the GetAllRunningApplicationsAsync method in order to obtain information about the currently running applications:
        /// <code>
        /// // Initiate the call to get all running applications
        /// IEnumerable&lt;ApplicationRunningContext&gt; runningApps = await GetAllRunningApplicationsAsync();
        ///
        /// // Iterate through the obtained list of running apps
        /// foreach (var app in runningApps)
        /// {
        ///     Console.WriteLine($"Id: {app.ApplicationId}");
        /// }
        /// </code>
        /// </example>
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
        /// Retrieves the information of the specified application by its application ID.
        /// </summary>
        /// <param name="applicationId">The ID of the target application.</param>
        /// <returns>An object containing detailed information about the requested application.</returns>
        /// <remarks>
        /// This function enables you to obtain specific information about an application based on its application ID.
        /// It returns an object that contains various attributes such as the package name, version, icon URL, etc., which are associated with the identified application.
        /// If the specified application does not exist in the system, an error message will be thrown indicating that the requested application could not be found.
        /// </remarks>
        /// <example>
        /// The following code snippet demonstrates how to retrieve the details of an application with the ID "org.example.app":
        /// <code>
        /// // Retrieve the application details
        /// ApplicationInfo appInfo = ApplicationManager.GetInstalledApplication("org.example.app");
        ///
        /// // Print the package ID of the retrieved application
        /// Console.WriteLine($"Package ID: {appInfo.PackageId}");
        /// </code>
        /// </example>
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
        /// Determines whether the specified application is currently running.
        /// </summary>
        /// <param name="applicationId">The unique identifier of the application to check.</param>
        /// <returns>True if the application identified by the given ID is currently running, otherwise False.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided argument is invalid or missing.</exception>
        /// <example>
        /// The following code snippet demonstrates how to determine if a specific application is currently running:
        ///
        /// <code>
        /// string applicationId = "org.example.app";
        /// if (ApplicationManager.IsRunning(applicationId))
        /// {
        ///     Console.WriteLine("The application with ID '{0}' is currently running.", applicationId);
        /// }
        /// else
        /// {
        ///     Console.WriteLine("The application with ID '{0}' is not currently running.", applicationId);
        /// }
        /// </code>
	/// </example>
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
        /// Retrieves the application ID based on the specified process ID.
        /// </summary>
        /// <remarks>
        /// By providing the process ID as input, this function enables you to obtain the corresponding application ID.
        /// It ensures that the correct application is identified even if multiple applications are running simultaneously.
        /// </remarks>
        /// <param name="processId">The process ID of the target application.</param>
        /// <returns>The application ID associated with the given process ID.</returns>
        /// <exception cref="ArgumentException">If the argument passed in is not valid.</exception>
        /// <example>
        /// The following code snippet demonstrates how to retrieve the application ID by calling the GetAppId() function:
        ///
        /// <code>
        /// int processId = 12345; // Replace with actual process ID
        /// string appId = GetAppId(processId);
        /// Console.WriteLine($"Application ID: {appId}");
        /// </code>
        /// </example>
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

        /// <summary>
        /// Attaches the window of the child application below the window of the parent application.
        /// </summary>
        /// <remarks>
        /// This method is only available for platform level signed applications.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AttachWindowBelow(string parentAppId, string childAppId)
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

            err = Interop.ApplicationManager.AppManagerAttachWindowBelow(parentAppId, childAppId);
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
        /// Requests to remount the application path for the specified subsession to reflect user changes.
        /// </summary>
        /// <details>
        /// This method unmounts and remounts the application's root path for the specified subsession,
        /// updating the mount source to correspond to the current user context.
        /// The application path itself remains unchanged, but the underlying source is replaced to reflect
        /// the user switch. This is typically used to ensure data isolation and consistency when the user
        /// changes while the application is running.
        /// </details>
        /// <remarks>
        /// This method is only available for platform level signed applications.
        /// </remarks>
        /// <param name="subsessionId">The subsession identifier.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <privilege>http://tizen.org/privilege/internal/default/platform</privilege>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void RemountSubsession(string subsessionId)
        {
            if (subsessionId == null)
            {
                throw new ArgumentException("Invalid argument.");
            }

            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppManagerRequestRemountSubsession(subsessionId);
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
            else
            {
                Application.ResetCurrentApplicationDirectoryInfo();
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
