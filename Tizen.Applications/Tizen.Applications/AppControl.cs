// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
    public class AppControl
    {
        private const string LogTag = "Tizen.Applications";

        private static Dictionary<int, Interop.AppControl.ReplyCallback> s_replyNativeCallbackMaps = new Dictionary<int, Interop.AppControl.ReplyCallback>();
        private static int s_replyNativeCallbackId = 0;

        private readonly SafeAppControlHandle _handle;

        private string _operation = null;
        private string _mime = null;
        private string _uri = null;
        private string _category = null;
        private string _applicationId = null;
        private ExtraDataCollection _extraData = null;

        /// <summary>
        /// Initializes the instance of the AppControl class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when failed to create AppControl handle.</exception>
        public AppControl()
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.Create(out _handle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
            }
        }

        /// <summary>
        /// Initializes the instance of the AppControl class with the SafeAppControlHandle.
        /// </summary>
        /// <param name="handle"></param>
        public AppControl(SafeAppControlHandle handle)
        {
            _handle = handle;
        }

        internal AppControl(IntPtr handle)
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.DangerousClone(out _handle, handle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to clone the appcontrol handle. Err = " + err);
            }
        }

        #region Public Properties

        /// <summary>
        /// Gets the SafeAppControlHandle instance.
        /// </summary>
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
        /// it is a regular file in this application's data path which can be obtained 
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
        public string Uri
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
        /// Gets and sets the application id to explicitly launch.
        /// </summary>
        /// <value>
        /// (if the application id is null for setter, it clears the previous value.)
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// Log.Debug(LogTag, "ApplicationId: " + appControl.ApplicationId);
        /// </code>
        /// </example>
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
        /// Although LaunchMode were set as AppControlLaunchMode.Group, 
        /// callee application would be launched as single mode 
        /// if the manifest file of callee application defined the launch mode as "single".
        /// This property can just set the preference of caller application to launch an application. 
        /// Sub-applications which were launched as group mode always have own process.
        /// Since Tizen 3.0, if launch mode not set in the caller app control, 
        /// this property returns AppControlLaunchMode.Single launch mode. 
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.LaunchMode = AppControlLaunchMode.Group;
        /// </code>
        /// </example>
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
        /// Extra data for communication between AppControls.
        /// </summary>
        /// <value>
        /// </value>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ExtraData.Add("key", "value");
        /// ...
        /// </code>
        /// </example>
        public ExtraDataCollection ExtraData
        {
            get
            {
                if (_extraData == null)
                    _extraData = new ExtraDataCollection(_handle);
                return _extraData;
            }
        }

        #endregion // Public Properties

        /// <summary>
        /// Retrieves all applications that can be launched to handle the given app_control request.
        /// </summary>
        /// <param name="control">The AppControl</param>
        /// <returns>ApplicationIds</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed because of invalid parameter</exception>
        /// <example>
        /// <code>
        /// IEnumerable<string> applicationIds = AppControl.GetMatchedApplicationIds(control);
        /// if (applicationIds != null)
        /// {
        ///     foreach (string id in applicationIds)
        ///     {
        ///         // ...
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<string> GetMatchedApplicationIds(AppControl control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            List<string> ids = new List<string>();
            Interop.AppControl.AppMatchedCallback callback = new Interop.AppControl.AppMatchedCallback(
                (handle, applicationId, userData) =>
                {
                    List<string> idsList = Marshal.GetObjectForIUnknown(userData) as List<string>;
                    if (idsList != null)
                    {
                        idsList.Add(applicationId);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });

            IntPtr pointerToApplicationIds = Marshal.GetIUnknownForObject(ids);
            if (pointerToApplicationIds != IntPtr.Zero)
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.ForeachAppMatched(control._handle, callback, pointerToApplicationIds);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    throw new InvalidOperationException("Failed to get matched application ids. err = " + err);
                }
                return ids;
            }

            return ids;
        }

        /// <summary>
        /// Sends the launch request.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request. 
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application. \n
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform. 
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4. 
        /// To launch a service application, an explicit launch request with application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="launchRequest">The AppControl</param>
        /// <exception cref="ArgumentNullException">Thrown when failed because of a null arguament</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of invalid operation</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <example>
        /// <code>
        /// AppControl appControl = new AppControl();
        /// appControl.ApplicationId = "org.tizen.calculator";
        /// AppControl.SendLaunchRequest(appControl);
        /// </code>
        /// </example>
        public static void SendLaunchRequest(AppControl launchRequest)
        {
            SendLaunchRequest(launchRequest, null);
        }

        /// <summary>
        /// Sends the launch request.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request. 
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application. \n
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform. 
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4. 
        /// To launch a service application, an explicit launch request with application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="launchRequest">The AppControl</param>
        /// <param name="replyAfterLaunching">The callback function to be called when the reply is delivered</param>
        /// <exception cref="ArgumentException">Thrown when failed because of arguament is invalid</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of invalid operation</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout</exception>
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
        public static void SendLaunchRequest(AppControl launchRequest, AppControlReplyCallback replyAfterLaunching)
        {
            if (launchRequest == null)
            {
                throw new ArgumentNullException("launchRequest");
            }

            Interop.AppControl.ErrorCode err;

            err = Interop.AppControl.EnableAppStartedResultEvent(launchRequest._handle);
            if (err == Interop.AppControl.ErrorCode.InvalidParameter)
                throw new ArgumentException("Invalid parameter of EnableAppStartedResultEvent()");

            if (replyAfterLaunching != null)
            {
                int id = 0;
                lock (s_replyNativeCallbackMaps)
                {
                    id = s_replyNativeCallbackId++;
                    s_replyNativeCallbackMaps[id] = (launchRequestHandle, replyRequestHandle, result, userData) =>
                    {
                        if (result == Interop.AppControl.AppStartedStatus)
                        {
                            Log.Debug(LogTag, "Callee App is started");
                            return;
                        }

                        if (replyAfterLaunching != null)
                        {
                            Log.Debug(LogTag, "Reply Callback is launched");
                            replyAfterLaunching(new AppControl(launchRequestHandle), new AppControl(replyRequestHandle), (AppControlReplyResult)result);
                            lock (s_replyNativeCallbackMaps)
                            {
                                s_replyNativeCallbackMaps.Remove(id);
                            }
                        }
                    };
                }
                err = Interop.AppControl.SendLaunchRequest(launchRequest._handle, s_replyNativeCallbackMaps[id], IntPtr.Zero);
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
                    default:
                        throw new InvalidOperationException("Error = " + err);
                }
            }
        }

        /// <summary>
        /// Class for Extra Data
        /// </summary>
        public class ExtraDataCollection
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
            /// <param name="key">The name of the extra data</param>
            /// <param name="value">The value associated with the given key</param>
            /// <exception cref="ArgumentNullException">Thrown when key or value is a zero-length string</exception>
            /// <exception cref="ArgumentException">Thrown when the application tries to use the same key with system-defined key</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// appControl.ExtraData.Add("myKey", "myValue");
            /// </code>
            /// </example>
            public void Add(string key, string value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
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
            /// <param name="key">The name of the extra data</param>
            /// <param name="value">The value associated with the given key</param>
            /// <exception cref="ArgumentNullException">Thrown when key or value is a zero-length string</exception>
            /// <exception cref="ArgumentException">Thrown when the application tries to use the same key with system-defined key</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// string[] myValues = new string[] { "first", "second", "third" };
            /// appControl.ExtraData.Add("myKey", myValues);
            /// </code>
            /// </example>
            public void Add(string key, IEnumerable<string> value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("value");
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
            /// <typeparam name="T">Only string & IEnumerable<string></typeparam>
            /// <param name="key">The name of extra data</param>
            /// <returns>The value associated with the given key</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is invalid parameter</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// string myValue = appControl.ExtraData.Get<string>("myKey");
            /// </code>
            /// </example>
            public T Get<T>(string key)
            {
                object ret = Get(key);
                return (T)ret;
            }

            /// <summary>
            /// Gets the extra data.
            /// </summary>
            /// <param name="key">The name of extra data</param>
            /// <returns>The value associated with the given key</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is invalid parameter</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected</exception>
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
            /// <returns>The keys in the AppControl</returns>
            /// <exception cref="InvalidOperationException">Thrown when invalid parameter</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// IEnumerable<string> keys = appControl.GetKeys();
            /// if (keys != null)
            /// {
            ///     foreach (string key in keys)
            ///     {
            ///         // ...
            ///     }
            /// }
            /// </code>
            /// </example>
            public IEnumerable<string> GetKeys()
            {
                List<string> keys = new List<string>();
                Interop.AppControl.ExtraDataCallback callback = new Interop.AppControl.ExtraDataCallback(
                    (handle, key, userData) =>
                    {
                        List<string> keysList = Marshal.GetObjectForIUnknown(userData) as List<string>;
                        if (keysList != null)
                        {
                            keysList.Add(key);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });

                IntPtr pointerToKeys = Marshal.GetIUnknownForObject(keys);
                if (pointerToKeys != IntPtr.Zero)
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.ForeachExtraData(_handle, callback, pointerToKeys);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        throw new InvalidOperationException("Failed to get keys. err = " + err);
                    }
                    return keys;
                }

                return keys;
            }

            /// <summary>
            /// Tries getting the extra data.
            /// </summary>
            /// <param name="key">The name of extra data</param>
            /// <param name="value">The value associated with the given key</param>
            /// <returns>The result whether getting the value is done</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is invalid parameter</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected</exception>
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
            public bool TryGet(string key, out string value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
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
            /// <param name="key">The name of extra data</param>
            /// <param name="value">The value associated with the given key</param>
            /// <returns>The result whether getting the value is done</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is invalid parameter</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// IEnumerable<string> myValue = null;
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
            public bool TryGet(string key, out IEnumerable<string> value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
                }
                IntPtr valuePtr = IntPtr.Zero;
                int len = -1;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetExtraDataArray(_handle, key, out valuePtr, out len);
                if (err == Interop.AppControl.ErrorCode.None && valuePtr != IntPtr.Zero && len > 0)
                {
                    string[] stringArray = new string[len];
                    for (int i = 0; i < len; ++i)
                    {
                        IntPtr charArr = Marshal.ReadIntPtr(valuePtr, IntPtr.Size * i);
                        stringArray[i] = Marshal.PtrToStringAuto(charArr);
                        Interop.Libc.Free(charArr);
                    }
                    Interop.Libc.Free(valuePtr);
                    value = stringArray;
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
            /// <param name="key">The name of the extra data</param>
            /// <exception cref="ArgumentNullException">Thrown when the key is a zero-length string</exception>
            /// <exception cref="KeyNotFoundException">Thrown when the key is not found</exception>
            /// <exception cref="ArgumentException">Thrown when the key is rejected</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// appControl.ExtraData.Remove("myKey");
            /// </code>
            /// </example>
            public void Remove(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
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
            /// <returns>The number of counting keys</returns>
            /// <exception cref="InvalidOperationException">Thrown when invalid parameter</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// int numberOfKeys = appControl.ExtraData.Count();
            /// </code>
            /// </example>
            public int Count()
            {
                return GetKeys().Count();
            }

            /// <summary>
            /// Checks whether the extra data associated with the given key is of collection data type.
            /// </summary>
            /// <param name="key">The name of the extra data</param>
            /// <returns>If true the extra data is of array data type, otherwise false</returns>
            /// <exception cref="ArgumentNullException">Thrown when the key is a zero-length string</exception>
            /// <exception cref="InvalidOperationException">Thrown when failed to check the key</exception>
            /// <example>
            /// <code>
            /// AppControl appControl = new AppControl();
            /// bool result = appControl.ExtraData.IsCollection("myKey");
            /// </code>
            /// </example>
            public bool IsCollection(string key)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException("key");
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
                    throw new ArgumentNullException("key");
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
                    throw new ArgumentNullException("key");
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

                string[] valueArray = null;
                if (valuePtr != IntPtr.Zero && len > 0)
                {
                    valueArray = new string[len];
                    for (int i = 0; i < len; ++i)
                    {
                        IntPtr charArr = Marshal.ReadIntPtr(valuePtr, IntPtr.Size * i);
                        valueArray[i] = Marshal.PtrToStringAuto(charArr);
                        Interop.Libc.Free(charArr);
                    }
                    Interop.Libc.Free(valuePtr);
                }

                return valueArray;
            }
        }
    }
}
