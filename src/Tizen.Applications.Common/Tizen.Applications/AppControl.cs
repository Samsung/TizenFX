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
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the control message to exchange between applications.
    /// </summary>
    /// <example>
    /// <code>
    /// public class AppControlExample : UIApplication
    /// {
    ///     /// ...
    ///     protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
    ///     {
    ///         AppControl appControl = new AppControl();
    ///         appControl.ApplicationId = "org.tizen.calculator";
    ///         AppControl.SendLaunchRequest(appControl, (launchRequest, replyRequest, result) => {
    ///             // ...
    ///         });
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
    public class AppControl
    {
        private const string LogTag = "Tizen.Applications";

        private static Dictionary<int, Interop.AppControl.ResultCallback> s_resultNativeCallbackMaps = new Dictionary<int, Interop.AppControl.ResultCallback>();
        private static Dictionary<int, AppControlReplyCallback> s_replyCallbackMaps = new Dictionary<int, AppControlReplyCallback>();
        private static int s_reaustId = 0;

        private readonly SafeAppControlHandle _handle;

        private string _operation = null;
        private string _mime = null;
        private string _uri = null;
        private string _category = null;
        private string _applicationId = null;
        private ExtraDataCollection _extraData = null;
        private string _componentId = null;

        /// <summary>
        /// Initializes the instance of the AppControl class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when failed to create the AppControl handle.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AppControl()
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.Create(out _handle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
            }
        }

        /// <summary>
        /// Initializes the instance of the AppControl class with a parameter.
        /// </summary>
        /// <param name="enableAppStartedResultEvent">The flag value to receive an additional launch result event on the launch request.</param>
        /// <exception cref="InvalidOperationException">Thrown when failed to create the AppControl handle.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AppControl(bool enableAppStartedResultEvent)
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.Create(out _handle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
            }

            if (enableAppStartedResultEvent)
            {
                err = Interop.AppControl.EnableAppStartedResultEvent(_handle);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    throw new InvalidOperationException("Failed to set EnableAppStartedResultEvent");
                }
            }
        }

        /// <summary>
        /// Initializes the instance of the AppControl class with the SafeAppControlHandle.
        /// </summary>
        /// <param name="handle"></param>
        /// <since_tizen> 3 </since_tizen>
        public AppControl(SafeAppControlHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            if (handle.IsInvalid)
            {
                throw new ArgumentNullException(nameof(handle), "handle is invalid");
            }

            bool mustRelease = false;
            try
            {
                handle.DangerousAddRef(ref mustRelease);
                Interop.AppControl.ErrorCode err = Interop.AppControl.DangerousClone(out _handle, handle.DangerousGetHandle());
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    throw new InvalidOperationException("Failed to clone the appcontrol handle. Err = " + err);
                }
            }
            catch (ObjectDisposedException e)
            {
                throw new ArgumentNullException(nameof(handle), e.Message);
            }
            finally
            {
                if (mustRelease)
                {
                    handle.DangerousRelease();
                }
            }
        }

        private AppControl(IntPtr handle)
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.DangerousClone(out _handle, handle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to clone the appcontrol handle. Err = " + err);
            }
        }

        private static Interop.AppControl.ReplyCallback s_replyNativeCallback = (launchHandle, replyHandle, result, userData) =>
        {
            int requestId = (int)userData;
            lock (s_replyCallbackMaps)
            {
                if (s_replyCallbackMaps.ContainsKey(requestId))
                {
                    s_replyCallbackMaps[requestId](new AppControl(launchHandle), new AppControl(replyHandle), (AppControlReplyResult)result);
                    if (result != Interop.AppControl.AppStartedStatus)
                    {
                        s_replyCallbackMaps.Remove(requestId);
                    }
                }
            }
        };

#region Public Properties

        /// <summary>
        /// Gets the SafeAppControlHandle instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SafeAppControlHandle SafeAppControlHandle
        {
            get
            {
                return _handle;
            }
        }

        /// <summary>
        /// Gets and sets the operation to be performed.
        /// </summary>
        /// <value>
        /// The operation is the mandatory information for the launch request. If the operation is not specified,
        /// AppControlOperations.Default is used for the launch request. If the operation is AppControlOperations.Default,
        /// the package information is mandatory to explicitly launch the application.
        /// (if the operation is null for setter, it clears the previous value.)
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.Operation = AppControlOperations.Default;
        /// Log.Debug(LogTag, "Operation: " + appControl.Operation);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public string Operation
        {
            get
            {
                if (String.IsNullOrEmpty(_operation))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetOperation(_handle, out _operation);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the operation from the appcontrol. Err = " + err);
                    }
                }
                return _operation;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetOperation(_handle, value);
                if (err == Interop.AppControl.ErrorCode.None)
                {
                    _operation = value;
                }
                else
                {
                    Log.Warn(LogTag, "Failed to set the operation to the appcontrol. Err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets and sets the explicit MIME type of the data.
        /// </summary>
        /// <value>
        /// (if the mime is null for setter, it clears the previous value.)
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.Mime = "image/jpg";
        /// Log.Debug(LogTag, "Mime: " + appControl.Mime);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public string Mime
        {
            get
            {
                if (String.IsNullOrEmpty(_mime))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetMime(_handle, out _mime);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the mime from the appcontrol. Err = " + err);
                    }
                }
                return _mime;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetMime(_handle, value);
                if (err == Interop.AppControl.ErrorCode.None)
                {
                    _mime = value;
                }
                else
                {
                    Log.Warn(LogTag, "Failed to set the mime to the appcontrol. Err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets and sets the URI of the data.
        /// </summary>
        /// <value>
        /// Since Tizen 2.4, if the parameter 'uri' is started with 'file://' and
        /// it is a regular file in this application's data path, which can be obtained
        /// by property DataPath in ApplicationInfo class,
        /// it will be shared to the callee application.
        /// Framework will grant a temporary permission to the callee application for this file and
        /// revoke it when the callee application is terminated.
        /// The callee application can just read it.
        /// (if the uri is null for setter, it clears the previous value.)
        /// </value>
        /// <example>
        /// <code>
        /// public class AppControlExample : UIApplication
        /// {
        ///     ...
        ///     protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        ///     {
        ///         ...
        ///         AppControl appControl = new AppControl();
        ///         appContrl.Uri = this.ApplicationInfo.DataPath + "image.jpg";
        ///         Log.Debug(LogTag, "Set Uri: " + appControl.Uri);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
#pragma warning disable CA1056
        public string Uri
#pragma warning restore CA1056
        {
            get
            {
                if (String.IsNullOrEmpty(_uri))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetUri(_handle, out _uri);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the uri from the appcontrol. Err = " + err);
                    }
                }
                return _uri;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetUri(_handle, value);
                if (err == Interop.AppControl.ErrorCode.None)
                {
                    _uri = value;
                }
                else
                {
                    Log.Warn(LogTag, "Failed to set the uri to the appcontrol. Err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets and sets the explicit category.
        /// </summary>
        /// <value>
        /// (if the category is null for setter, it clears the previous value.)
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public string Category
        {
            get
            {
                if (String.IsNullOrEmpty(_category))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetCategory(_handle, out _category);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the category from the appcontrol. Err = " + err);
                    }
                }
                return _category;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetCategory(_handle, value);
                if (err == Interop.AppControl.ErrorCode.None)
                {
                    _category = value;
                }
                else
                {
                    Log.Warn(LogTag, "Failed to set the category to the appcontrol. Err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets and sets the application ID to explicitly launch.
        /// </summary>
        /// <value>
        /// (if the application ID is null for setter, it clears the previous value.)
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// Log.Debug(LogTag, "ApplicationId: " + appControl.ApplicationId);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public string ApplicationId
        {
            get
            {
                if (String.IsNullOrEmpty(_applicationId))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetAppId(_handle, out _applicationId);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the application id from the AppControl. Err = " + err);
                    }
                }
                return _applicationId;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetAppId(_handle, value);
                if (err == Interop.AppControl.ErrorCode.None)
                {
                    _applicationId = value;
                }
                else
                {
                    Log.Warn(LogTag, "Failed to set the application id to the AppControl. Err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets and sets the launch mode of the application.
        /// </summary>
        /// <value>
        /// Although, LaunchMode were set as AppControlLaunchMode.Group, the
        /// callee application would be launched as a single mode
        /// if the manifest file of callee application defined the launch mode as "single".
        /// This property can just set the preference of the caller application to launch an application.
        /// Sub-applications, which were launched as a group mode always have own process.
        /// Since Tizen 3.0, if launch mode is not set in the caller application control,
        /// this property returns the AppControlLaunchMode.Single launch mode.
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.LaunchMode = AppControlLaunchMode.Group;
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public AppControlLaunchMode LaunchMode
        {
            get
            {
                int value = 0;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetLaunchMode(_handle, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the LaunchMode from the AppControl. Err = " + err);
                }
                return (AppControlLaunchMode)value;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetLaunchMode(_handle, (int)value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to set the LaunchMode to the AppControl. Err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets the collection of the extra data.
        /// </summary>
        /// <value>
        /// Extra data for communication between AppControls.
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ExtraData.Add("key", "value");
        /// ...
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public ExtraDataCollection ExtraData
        {
            get
            {
                if (_extraData == null)
                    _extraData = new ExtraDataCollection(_handle);
                return _extraData;
            }
        }

        /// <summary>
        /// Gets and sets the component ID to explicitly launch a component.
        /// </summary>
        /// <value>
        /// (if the component ID is null for setter, it clears the previous value.)
        /// From Tizen 5.5, a new application model is supported that is component-based application.
        /// This property is for launching component-based application. If it's not set, the main component of component-based application will be launched.
        /// If the target app is not component-based application, setting property is meaningless.
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.component-based-app"; // component-based application
        /// appControl.ComponentId = "org.tizen.frame-component";
        /// AppControl.SendLaunchRequest(appControl);
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public string ComponentId
        {
            get
            {
                if (String.IsNullOrEmpty(_componentId))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetComponentId(_handle, out _componentId);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the component id from the AppControl. Err = " + err);
                    }
                }
                return _componentId;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetComponentId(_handle, value);
                if (err == Interop.AppControl.ErrorCode.None)
                {
                    _componentId = value;
                }
                else
                {
                    Log.Warn(LogTag, "Failed to set the component id to the AppControl. Err = " + err);
                }
            }
        }

#endregion // Public Properties

        /// <summary>
        /// Retrieves all applications that can be launched to handle the given app_control request.
        /// </summary>
        /// <param name="control">The AppControl.</param>
        /// <returns>ApplicationIds.</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid parameter.</exception>
        /// <example>
        /// <code>
        /// IEnumerable&lt;string&gt; applicationIds = AppControl.GetMatchedApplicationIds(control);
        /// if (applicationIds != null)
        /// {
        ///     foreach (string id in applicationIds)
        ///     {
        ///         // ...
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<string> GetMatchedApplicationIds(AppControl control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            List<string> ids = new List<string>();
            Interop.AppControl.AppMatchedCallback callback = (handle, applicationId, userData) =>
            {
                if (applicationId == null)
                {
                        return false;
                }

                ids.Add(applicationId);
                return true;
            };

            Interop.AppControl.ErrorCode err = Interop.AppControl.ForeachAppMatched(control._handle, callback, IntPtr.Zero);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                    throw new InvalidOperationException("Failed to get matched application ids. err = " + err);
            }

            return ids;
        }

        /// <summary>
        /// Sends the launch request.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform.
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4.
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="launchRequest">The AppControl.</param>
        /// <exception cref="ArgumentNullException">Thrown when failed because of a null argument.</exception>
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchFailedException">Thrown when the request failed to launch the application.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <exception cref="Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// AppControl.SendLaunchRequest(appControl);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static void SendLaunchRequest(AppControl launchRequest)
        {
            SendLaunchRequest(launchRequest, null);
        }

        /// <summary>
        /// Sends the launch request with setting timeout.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.<br/>
        /// It can set receiving timeout interval using timeout parameter.
        /// If there is an error that is not related to timeout, the error is returned immediately regardless of the timeout value.
        /// </remarks>
        /// <param name="launchRequest">The AppControl.</param>
        /// <param name="timeout">The timeout in milliseconds, the timeout range is 5000 to 30000.</param>
        /// <exception cref="ArgumentNullException">Thrown when failed because of a null argument.</exception>
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchFailedException">Thrown when the request failed to launch the application.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <exception cref="Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// AppControl.SendLaunchRequest(appControl, 10000);
        /// </code>
        /// </example>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SendLaunchRequest(AppControl launchRequest, uint timeout)
        {
            SendLaunchRequest(launchRequest, timeout, null);
        }

        /// <summary>
        /// Sends the launch request.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform.
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4.
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="launchRequest">The AppControl.</param>
        /// <param name="replyAfterLaunching">The callback function to be called when the reply is delivered.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchFailedException">Thrown when the request failed to launch the application.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <exception cref="Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// AppControl.SendLaunchRequest(appControl, (launchRequest, replyRequest, result) => {
        ///     // ...
        /// });
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static void SendLaunchRequest(AppControl launchRequest, AppControlReplyCallback replyAfterLaunching)
        {
            if (launchRequest == null)
            {
                throw new ArgumentNullException(nameof(launchRequest));
            }

            Interop.AppControl.ErrorCode err;

            if (replyAfterLaunching != null)
            {
                int id = 0;
                lock (s_replyCallbackMaps)
                {
                    id = s_reaustId++;
                    s_replyCallbackMaps[id] = replyAfterLaunching;
                }
                err = Interop.AppControl.SendLaunchRequest(launchRequest._handle, s_replyNativeCallback, (IntPtr)id);
            }
            else
            {
                err = Interop.AppControl.SendLaunchRequest(launchRequest._handle, null, IntPtr.Zero);
            }

            if (err != Interop.AppControl.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.AppControl.ErrorCode.TimedOut:
                        throw new TimeoutException("Timed out");
                    case Interop.AppControl.ErrorCode.OutOfMemory:
                        throw new Exceptions.OutOfMemoryException("Out-of-memory");
                    case Interop.AppControl.ErrorCode.AppNotFound:
                        throw new Exceptions.AppNotFoundException("App(" + launchRequest.ApplicationId + ") not found. Operation(" + launchRequest.Operation + ")");
                    case Interop.AppControl.ErrorCode.LaunchRejected:
                        throw new Exceptions.LaunchRejectedException("Launch rejected");
                    case Interop.AppControl.ErrorCode.LaunchFailed:
                        throw new Exceptions.LaunchFailedException("Launch failed");
                    case Interop.AppControl.ErrorCode.PermissionDenied:
                        throw new Exceptions.PermissionDeniedException("Permission denied");

                    default:
                        throw new Exceptions.LaunchRejectedException("Launch rejected");
                }
            }
        }

        /// <summary>
        /// Sends the launch request with setting timeout
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.<br/>
        /// It can set receiving timeout interval using timeout parameter.
        /// If there is an error that is not related to timeout, the error is returned immediately regardless of the timeout value.
        /// </remarks>
        /// <param name="launchRequest">The AppControl.</param>
        /// <param name="timeout">The timeout in milliseconds, the timeout range is 5000 to 30000.</param>
        /// <param name="replyAfterLaunching">The callback function to be called when the reply is delivered.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchFailedException">Thrown when the request failed to launch the application.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <exception cref="Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout. The timeout interval is set by timeout parameter.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// AppControl.SendLaunchRequest(appControl, 10000, (launchRequest, replyRequest, result) => {
        ///     // ...
        /// });
        /// </code>
        /// </example>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SendLaunchRequest(AppControl launchRequest, uint timeout, AppControlReplyCallback replyAfterLaunching)
        {
            if (launchRequest == null)
            {
                throw new ArgumentNullException(nameof(launchRequest));
            }

            Interop.AppControl.ErrorCode err;

            if (replyAfterLaunching != null)
            {
                int id = 0;
                lock (s_replyCallbackMaps)
                {
                    id = s_reaustId++;
                    s_replyCallbackMaps[id] = replyAfterLaunching;
                }
                err = Interop.AppControl.SendLaunchRequestWithTimeout(launchRequest._handle, timeout, s_replyNativeCallback, (IntPtr)id);
            }
            else
            {
                err = Interop.AppControl.SendLaunchRequestWithTimeout(launchRequest._handle, timeout, null, IntPtr.Zero);
            }

            if (err != Interop.AppControl.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.AppControl.ErrorCode.TimedOut:
                        throw new TimeoutException("Timed out");
                    case Interop.AppControl.ErrorCode.OutOfMemory:
                        throw new Exceptions.OutOfMemoryException("Out-of-memory");
                    case Interop.AppControl.ErrorCode.AppNotFound:
                        throw new Exceptions.AppNotFoundException("App(" + launchRequest.ApplicationId + ") not found. Operation(" + launchRequest.Operation + ")");
                    case Interop.AppControl.ErrorCode.LaunchRejected:
                        throw new Exceptions.LaunchRejectedException("Launch rejected");
                    case Interop.AppControl.ErrorCode.LaunchFailed:
                        throw new Exceptions.LaunchFailedException("Launch failed");
                    case Interop.AppControl.ErrorCode.PermissionDenied:
                        throw new Exceptions.PermissionDeniedException("Permission denied");

                    default:
                        throw new Exceptions.LaunchRejectedException("Launch rejected");
                }
            }
        }

        /// <summary>
        /// Sends the terminate request to the application that is launched by AppControl.
        /// </summary>
        /// <remarks>
        /// You are not allowed to terminate other general applications using this API.
        /// This API can be used to terminate sub-applications, which were launched as a group mode by the caller application.
        /// Once the callee application is being terminated by this API,
        /// other applications, which were launched by the callee application as a group mode will be terminated as well.
        /// </remarks>
        /// <param name="terminateRequest">The AppControl.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        /// <example>
        /// <code>
        /// AppControl terminateRequest = new AppControl();
        /// terminateRequest.ApplicationId = "org.tizen.calculator";
        /// AppControl.SendTerminateRequest(terminateRequest);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static void SendTerminateRequest(AppControl terminateRequest)
        {
            if (terminateRequest == null)
            {
                throw new ArgumentNullException(nameof(terminateRequest));
            }
            Interop.AppControl.ErrorCode err;

            err = Interop.AppControl.SendTerminateRequest(terminateRequest._handle);

            if (err != Interop.AppControl.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.AppControl.ErrorCode.TimedOut:
                        throw new TimeoutException("Timed out");
                    default:
                        throw new InvalidOperationException("Error = " + err);
                }
            }
        }

        /// <summary>
        /// Sends the launch request asynchronously.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform.
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4.
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="launchRequest">The AppControl.</param>
        /// <param name="replyAfterLaunching">The callback function to be called when the reply is delivered.</param>
        /// <returns>A task with the result of the launch request.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 6 </since_tizen>
        public static Task<AppControlResult> SendLaunchRequestAsync(AppControl launchRequest, AppControlReplyCallback replyAfterLaunching)
        {
            if (launchRequest == null)
            {
                throw new ArgumentNullException(nameof(launchRequest));
            }

            var task = new TaskCompletionSource<AppControlResult>();
            Interop.AppControl.ErrorCode err;
            int requestId = 0;

            lock (s_resultNativeCallbackMaps)
            {
                requestId = s_reaustId++;
                s_resultNativeCallbackMaps[requestId] = (handle, result, userData) =>
                {
                    task.SetResult((AppControlResult)result);
                    lock (s_resultNativeCallbackMaps)
                    {
                        s_resultNativeCallbackMaps.Remove((int)userData);
                    }
                };
            }

            if (replyAfterLaunching != null)
            {
                lock (s_replyCallbackMaps)
                {
                    s_replyCallbackMaps[requestId] = replyAfterLaunching;
                }
                err = Interop.AppControl.SendLaunchRequestAsync(launchRequest.SafeAppControlHandle, s_resultNativeCallbackMaps[requestId], s_replyNativeCallback, (IntPtr)requestId);
            }
            else
            {
                err = Interop.AppControl.SendLaunchRequestAsync(launchRequest.SafeAppControlHandle, s_resultNativeCallbackMaps[requestId], null, (IntPtr)requestId);
            }

            if (err != Interop.AppControl.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.AppControl.ErrorCode.AppNotFound:
                        throw new Exceptions.AppNotFoundException("App(" + launchRequest.ApplicationId + ") not found. Operation(" + launchRequest.Operation + ")");
                    case Interop.AppControl.ErrorCode.LaunchRejected:
                        throw new Exceptions.LaunchRejectedException("Launch rejected");
                    case Interop.AppControl.ErrorCode.PermissionDenied:
                        throw new Exceptions.PermissionDeniedException("Permission denied");

                    default:
                        throw new Exceptions.LaunchRejectedException("Launch rejected");
                }
            }

            return task.Task;
        }

        /// <summary>
        /// Sets the auto restart.
        /// </summary>
        /// <remarks>
        /// The functionality of this method only applies to the caller application.
        /// The auto restart cannot be applied to other applications. The application ID set in the AppControl is ignored.
        /// This method is only available for platform level signed applications.
        /// </remarks>
        /// <param name="appControl">The AppControl.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <exception cref="Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the memory is insufficient.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAutoRestart(AppControl appControl)
        {
            if (appControl == null)
            {
                throw new ArgumentNullException(nameof(appControl));
            }

            Interop.AppControl.ErrorCode err = Interop.AppControl.SetAutoRestart(appControl.SafeAppControlHandle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid arguments");
                    case Interop.AppControl.ErrorCode.PermissionDenied:
                        throw new Exceptions.PermissionDeniedException("Permission denied");
                    case Interop.AppControl.ErrorCode.OutOfMemory:
                        throw new Exceptions.OutOfMemoryException("Out of memory");
                    default:
                        throw new InvalidOperationException("err = " + err);
                }
            }
        }

        /// <summary>
        /// Unsets the auto restart.
        /// </summary>
        /// <remarks>
        /// The functionality of this method only applies to the caller application.
        /// This method is only available for platform level signed applications.
        /// </remarks>
        /// <exception cref="Exceptions.PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <exception cref="Exceptions.OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the memory is insufficient.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void UnsetAutoRestart()
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.UnsetAutoRestart();
            if (err != Interop.AppControl.ErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.PermissionDenied:
                        throw new Exceptions.PermissionDeniedException("Permission denied");
                    case Interop.AppControl.ErrorCode.OutOfMemory:
                        throw new Exceptions.OutOfMemoryException("Out of memory");
                    default:
                        throw new InvalidOperationException("err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets all default applications.
        /// </summary>
        /// <returns>ApplicationIds.</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// <code>
        /// IEnumerable&lt;string&gt; applicationIds = AppControl.GetDefaultApplicationIds();
        /// if (applicationIds != null)
        /// {
        ///     foreach (string id in applicationIds)
        ///     {
        ///         // ...
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IEnumerable<string> GetDefaultApplicationIds()
        {
            List<string> ids = new List<string>();
            Interop.AppControl.DefaultApplicationCallback callback = (applicationId, userData) =>
            {
                if (applicationId == null)
                {
                    return false;
                }

                ids.Add(applicationId);
                return true;
            };

            Interop.AppControl.ErrorCode err = Interop.AppControl.ForeachDefaultApplication(callback, IntPtr.Zero);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to get default application Ids. err = " + err);
            }

            return ids;
        }

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="windowPosition">The window position object.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the invalid operation error occurs.</exception>
        /// <since_tizen> 11 </since_tizen>
        public void SetWindowPosition(WindowPosition windowPosition)
        {
            if (windowPosition == null)
            {
                throw new ArgumentNullException(nameof(windowPosition));
            }

            Interop.AppControl.ErrorCode err = Interop.AppControl.SetWindowPosition(this.SafeAppControlHandle, windowPosition.PositionX, windowPosition.PositionY, windowPosition.Width, windowPosition.Height);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                if (err == Interop.AppControl.ErrorCode.InvalidParameter)
                {
                    throw new ArgumentException("Invalid arguments");
                }
                else
                {
                    throw new InvalidOperationException("err = " + err);
                }
            }
        }

        /// <summary>
        /// Gets the window position.
        /// </summary>
        /// <returns>The window position.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the invalid operation error occurs.</exception>
        /// <since_tizen> 11 </since_tizen>
        public WindowPosition GetWindowPosition()
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.GetWindowPosition(this.SafeAppControlHandle, out int x, out int y, out int w, out int h);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("err = " + err);
            }

            return new WindowPosition(x, y, w, h);
        }

        /// <summary>
        /// Class for extra data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
#pragma warning disable CA1034
        public class ExtraDataCollection
#pragma warning restore CA1034
        {
            private readonly SafeAppControlHandle _handle;

            internal ExtraDataCollection(SafeAppControlHandle handle)
            {
                _handle = handle;
            }

            /// <summary>
            /// Adds extra data.
            /// </summary>
            /// <remarks>
            /// The function replaces any existing value for the given key.
            /// </remarks>
            /// <param name="key">The name of the extra data.</param>
            /// <param name="value">The value associated with the given key.</param>
            /// <exception cref="ArgumentNullException">Thrown when a key or a value is a zero-length string.</exception>
            /// <exception cref="ArgumentException">Thrown when the application tries to use the same key with the system-defined key.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// appControl.ExtraData.Add("myKey", "myValue");
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public void Add(string key, string value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                Interop.AppControl.ErrorCode err = Interop.AppControl.AddExtraData(_handle, key, value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    switch (err)
                    {
                        case Interop.AppControl.ErrorCode.InvalidParameter:
                            throw new ArgumentException("Invalid parameter: key or value is a zero-length string");
                        case Interop.AppControl.ErrorCode.KeyRejected:
                            throw new ArgumentException("Key is rejected: the key is system-defined key.");
                        default:
                            throw new InvalidOperationException("Error = " + err);
                    }
                }
            }

            /// <summary>
            /// Adds extra data.
            /// </summary>
            /// <remarks>
            /// The function replaces any existing value for the given key.
            /// </remarks>
            /// <param name="key">The name of the extra data.</param>
            /// <param name="value">The value associated with the given key.</param>
            /// <exception cref="ArgumentNullException">Thrown when key or value is a zero-length string.</exception>
            /// <exception cref="ArgumentException">Thrown when the application tries to use the same key with the system-defined key.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// string[] myValues = new string[] { "first", "second", "third" };
            /// appControl.ExtraData.Add("myKey", myValues);
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public void Add(string key, IEnumerable<string> value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                string[] valueArray = value.ToArray();
                Interop.AppControl.ErrorCode err = Interop.AppControl.AddExtraDataArray(_handle, key, valueArray, valueArray.Length);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    switch (err)
                    {
                        case Interop.AppControl.ErrorCode.InvalidParameter:
                            throw new ArgumentException("Invalid parameter: key or value is a zero-length string");
                        case Interop.AppControl.ErrorCode.KeyRejected:
                            throw new ArgumentException("Key is rejected: the key is system-defined key.");
                        default:
                            throw new InvalidOperationException("Error = " + err);
                    }
                }
            }

            /// <summary>
            /// Gets the extra data.
            /// </summary>
            /// <typeparam name="T">Only string and IEnumerable&lt;string&gt;</typeparam>
            /// <param name="key">The name of extra data.</param>
            /// <returns>The value associated with the given key.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is an invalid parameter.</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found.</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// string myValue = appControl.ExtraData.Get&lt;string&gt;("myKey");
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public T Get<T>(string key)
            {
                object ret = Get(key);
                return (T)ret;
            }

            /// <summary>
            /// Gets the extra data.
            /// </summary>
            /// <param name="key">The name of extra data.</param>
            /// <returns>The value associated with the given key.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is an invalid parameter.</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found.</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// string myValue = appControl.ExtraData.Get("myKey") as string;
            /// if (myValue != null)
            /// {
            ///     // ...
            /// }
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public object Get(string key)
            {
                if (IsCollection(key))
                {
                    return GetDataCollection(key);
                }
                else
                {
                    return GetData(key);
                }
            }

            /// <summary>
            /// Gets all keys in extra data.
            /// </summary>
            /// <returns>The keys in the AppControl.</returns>
            /// <exception cref="InvalidOperationException">Thrown when the key is an invalid parameter.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// IEnumerable&lt;string&gt; keys = appControl.GetKeys();
            /// if (keys != null)
            /// {
            ///     foreach (string key in keys)
            ///     {
            ///         // ...
            ///     }
            /// }
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public IEnumerable<string> GetKeys()
            {
                List<string> keys = new List<string>();
                Interop.AppControl.ExtraDataCallback callback = (handle, key, userData) =>
                {
                    if (key == null)
                    {
                        return false;
                    }

                    keys.Add(key);
                    return true;
                };

                Interop.AppControl.ErrorCode err = Interop.AppControl.ForeachExtraData(_handle, callback, IntPtr.Zero);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    throw new InvalidOperationException("Failed to get keys. err = " + err);
                }

                return keys;
            }

            /// <summary>
            /// Tries getting the extra data.
            /// </summary>
            /// <param name="key">The name of extra data.</param>
            /// <param name="value">The value associated with the given key.</param>
            /// <returns>The result whether getting the value is done.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is an invalid parameter.</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found.</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// string myValue = string.Empty;
            /// bool result = appControl.ExtraData.TryGet("myKey", out myValue);
            /// if (result != null)
            /// {
            ///     // ...
            /// }
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public bool TryGet(string key, out string value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                Interop.AppControl.GetExtraData(_handle, key, out value);
                if (value != null)
                {
                    return true;
                }
                else
                {
                    value = default(string);
                    return false;
                }
            }

            /// <summary>
            /// Tries getting the extra data.
            /// </summary>
            /// <param name="key">The name of extra data.</param>
            /// <param name="value">The value associated with the given key.</param>
            /// <returns>The result whether getting the value is done.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is an invalid parameter.</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found.</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// IEnumerable&lt;string&gt; myValue = null;
            /// bool result = appControl.ExtraData.TryGet("myKey", out myValue);
            /// if (result)
            /// {
            ///     foreach (string value in myValue)
            ///     {
            ///         // ...
            ///     }
            /// }
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public bool TryGet(string key, out IEnumerable<string> value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                IntPtr valuePtr = IntPtr.Zero;
                int len = -1;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetExtraDataArray(_handle, key, out valuePtr, out len);
                if (err == Interop.AppControl.ErrorCode.None && valuePtr != IntPtr.Zero)
                {
                    List<string> stringList = new List<string>();
                    for (int i = 0; i < len; ++i)
                    {
                        IntPtr charArr = Marshal.ReadIntPtr(valuePtr, IntPtr.Size * i);
                        stringList.Add(Marshal.PtrToStringAnsi(charArr));
                        Marshal.FreeHGlobal(charArr);
                    }
                    Marshal.FreeHGlobal(valuePtr);
                    value = stringList;
                    return true;
                }
                else
                {
                    value = default(IEnumerable<string>);
                    return false;
                }
            }

            /// <summary>
            /// Removes the extra data.
            /// </summary>
            /// <param name="key">The name of the extra data.</param>
            /// <exception cref="ArgumentNullException">Thrown when the key is a zero-length string.</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found.</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// appControl.ExtraData.Remove("myKey");
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public void Remove(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                Interop.AppControl.ErrorCode err = Interop.AppControl.RemoveExtraData(_handle, key);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    switch (err)
                    {
                        case Interop.AppControl.ErrorCode.InvalidParameter:
                            throw new ArgumentException("Invalid parameter: key is a zero-length string");
                        case Interop.AppControl.ErrorCode.KeyNotFound:
                            throw new KeyNotFoundException("Key is not found"); ;
                        case Interop.AppControl.ErrorCode.KeyRejected:
                            throw new ArgumentException("Key is rejected: the key is system-defined key.");
                        default:
                            throw new InvalidOperationException("Error = " + err);
                    }
                }
            }

            /// <summary>
            /// Counts keys in the extra data.
            /// </summary>
            /// <returns>The number of counting keys.</returns>
            /// <exception cref="InvalidOperationException">Thrown when the key is an invalid parameter.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// int numberOfKeys = appControl.ExtraData.Count();
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public int Count()
            {
                return GetKeys().Count();
            }

            /// <summary>
            /// Checks whether the extra data associated with the given key is of the collection data type.
            /// </summary>
            /// <param name="key">The name of the extra data.</param>
            /// <returns>If true, the extra data is of the array data type, otherwise false.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is a zero-length string.</exception>
            /// <exception cref="InvalidOperationException">Thrown when failed to check the key.</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// bool result = appControl.ExtraData.IsCollection("myKey");
            /// </code>
            /// </example>
            /// <since_tizen> 3 </since_tizen>
            public bool IsCollection(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                bool isArray = false;
                Interop.AppControl.ErrorCode err = Interop.AppControl.IsExtraDataArray(_handle, key, out isArray);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    throw new InvalidOperationException("Error = " + err);
                }
                return isArray;
            }

            private string GetData(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                string value = string.Empty;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetExtraData(_handle, key, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    switch (err)
                    {
                        case Interop.AppControl.ErrorCode.InvalidParameter:
                            throw new ArgumentException("Invalid parameter: key is a zero-length string");
                        case Interop.AppControl.ErrorCode.KeyNotFound:
                            throw new KeyNotFoundException("Key is not found"); ;
                        case Interop.AppControl.ErrorCode.InvalidDataType:
                            throw new ArgumentException("Invalid data type: value is data collection type");
                        case Interop.AppControl.ErrorCode.KeyRejected:
                            throw new ArgumentException("Key is rejected: the key is system-defined key.");
                        default:
                            throw new InvalidOperationException("Error = " + err);
                    }
                }
                return value;
            }

            private IEnumerable<string> GetDataCollection(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                IntPtr valuePtr = IntPtr.Zero;
                int len = -1;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetExtraDataArray(_handle, key, out valuePtr, out len);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    switch (err)
                    {
                        case Interop.AppControl.ErrorCode.InvalidParameter:
                            throw new ArgumentException("Invalid parameter: key is a zero-length string");
                        case Interop.AppControl.ErrorCode.KeyNotFound:
                            throw new KeyNotFoundException("Key is not found"); ;
                        case Interop.AppControl.ErrorCode.InvalidDataType:
                            throw new ArgumentException("Invalid data type: value is data collection type");
                        case Interop.AppControl.ErrorCode.KeyRejected:
                            throw new ArgumentException("Key is rejected: the key is system-defined key.");
                        default:
                            throw new InvalidOperationException("Error = " + err);
                    }
                }

                List<string> valueArray = new List<string>();
                if (valuePtr != IntPtr.Zero)
                {
                    for (int i = 0; i < len; ++i)
                    {
                        IntPtr charArr = Marshal.ReadIntPtr(valuePtr, IntPtr.Size * i);
                        valueArray.Add(Marshal.PtrToStringAnsi(charArr));
                        Marshal.FreeHGlobal(charArr);
                    }
                    Marshal.FreeHGlobal(valuePtr);
                }
                return valueArray;
            }
        }
    }
}
