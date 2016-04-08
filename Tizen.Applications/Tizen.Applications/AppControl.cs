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
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// The AppControl to launch other application or an actor or a service.
    /// </summary>
    public class AppControl
    {
        private const string LogTag = "Tizen.Applications";

        internal Interop.AppControl.SafeAppControlHandle _handle;

        private string _operation = null;
        private string _mime = null;
        private string _uri = null;
        private string _category = null;
        private string _applicationId = null;

        private ExtraDataCollection _extraData = null;

        static private Dictionary<int, Interop.AppControl.ReplyCallback>  _replyNativeCallbackMaps = new Dictionary<int, Interop.AppControl.ReplyCallback>();
        static private int _replyNativeCallbackId = 0;

        /// <summary>
        ///
        /// </summary>
        public AppControl()
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.Create(out _handle);
            if (err != Interop.AppControl.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
            }
        }

        internal AppControl(IntPtr handle)
        {
            Interop.AppControl.ErrorCode err = Interop.AppControl.DangerousClone(out _handle, handle);
            if (err != Interop.AppControl.ErrorCode.None)
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
        }

        #region Public Properties

        /// <summary>
        /// The operation to be performed.
        /// </summary>
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
        /// The explicit MIME type of the data.
        /// </summary>
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
        /// The URI of the data.
        /// </summary>
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
        ///
        /// </summary>
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
        ///
        /// </summary>
        public string ApplicationId
        {
            get
            {
                if (String.IsNullOrEmpty(_applicationId))
                {
                    Interop.AppControl.ErrorCode err = Interop.AppControl.GetAppId(_handle, out _applicationId);
                    if (err != Interop.AppControl.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the appId from the appcontrol. Err = " + err);
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
                    Log.Warn(LogTag, "Failed to set the appId to the appcontrol. Err = " + err);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public AppControlLaunchMode LaunchMode
        {
            get
            {
                int value = 0;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetLaunchMode(_handle, out value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the launchMode from the appcontrol. Err = " + err);
                }
                return (AppControlLaunchMode)value;
            }
            set
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.SetLaunchMode(_handle, (int)value);
                if (err != Interop.AppControl.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to set the launchMode to the appcontrol. Err = " + err);
                }
            }
        }

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
        ///
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetMatchedApplicationIds(AppControl control)
        {
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
                    throw new InvalidOperationException("Failed to get matched appids. err = " + err);
                }
                return ids;
            }

            return ids;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="launchRequest"></param>
        /// <param name="replyAfterLaunching"></param>
        public static void SendLaunchRequest(AppControl launchRequest, AppControlReplyCallback replyAfterLaunching = null)
        {
            Interop.AppControl.ErrorCode err;

            err = Interop.AppControl.EnableAppStartedResultEvent(launchRequest._handle);
            if (err == Interop.AppControl.ErrorCode.InvalidParameter)
                throw new ArgumentException("Invalid parameter of EnableAppStartedResultEvent()");

            if (replyAfterLaunching != null)
            {
                int id = 0;
                lock (_replyNativeCallbackMaps)
                {
                    id = _replyNativeCallbackId++;
                    _replyNativeCallbackMaps[id] = (launchRequestHandle, replyRequestHandle, result, userData) =>
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
                            lock (_replyNativeCallbackMaps)
                            {
                                _replyNativeCallbackMaps.Remove(id);
                            }
                        }
                    };
                }
                err = Interop.AppControl.SendLaunchRequest(launchRequest._handle, _replyNativeCallbackMaps[id], IntPtr.Zero);
            }
            else
            {
                err = Interop.AppControl.SendLaunchRequest(launchRequest._handle, null, IntPtr.Zero);
            }

            switch (err)
            {
                case Interop.AppControl.ErrorCode.InvalidParameter:
                throw new ArgumentNullException("Invalid parameter: key is a zero-length string");
                case Interop.AppControl.ErrorCode.AppNotFound:
                throw new InvalidOperationException("App not found");
                case Interop.AppControl.ErrorCode.LaunchRejected:
                throw new InvalidOperationException("Launch rejected");
                case Interop.AppControl.ErrorCode.LaunchFailed:
                throw new InvalidOperationException("Launch failed");
                case Interop.AppControl.ErrorCode.TimedOut:
                throw new TimeoutException("Timed out");
                case Interop.AppControl.ErrorCode.PermissionDenied:
                throw new InvalidOperationException("Permission denied");
            }
        }

        /// <summary>
        ///
        /// </summary>
        public class ExtraDataCollection
        {
            private readonly Interop.AppControl.SafeAppControlHandle _handle;

            internal ExtraDataCollection(Interop.AppControl.SafeAppControlHandle handle)
            {
                _handle = handle;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void Add(string key, string value)
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.AddExtraData(_handle, key, value);
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                    throw new ArgumentNullException("Invalid parameter: key or value is a zero-length string");
                    case Interop.AppControl.ErrorCode.KeyRejected:
                    throw new ArgumentException("Key is rejected: the key is system-defined key.");
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void Add(string key, IEnumerable<string> value)
            {
                string[] valueArray = value.ToArray();
                Interop.AppControl.ErrorCode err = Interop.AppControl.AddExtraDataArray(_handle, key, valueArray, valueArray.Length);
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                    throw new ArgumentNullException("Invalid parameter: key or value is a zero-length string");
                    case Interop.AppControl.ErrorCode.KeyRejected:
                    throw new ArgumentException("Key is rejected: the key is system-defined key.");
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public T Get<T>(string key)
            {
                object ret = Get(key);
                return (T)ret;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
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
            ///
            /// </summary>
            /// <returns></returns>
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
            ///
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public bool TryGet(string key, out string value)
            {
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
            ///
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public bool TryGet(string key, out IEnumerable<string> value)
            {
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
            ///
            /// </summary>
            /// <param name="key"></param>
            public void Remove(string key)
            {
                Interop.AppControl.ErrorCode err = Interop.AppControl.RemoveExtraData(_handle, key);
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                    throw new ArgumentNullException("Invalid parameter: key is a zero-length string");
                    case Interop.AppControl.ErrorCode.KeyNotFound:
                    throw new KeyNotFoundException("Key is not found"); ;
                    case Interop.AppControl.ErrorCode.KeyRejected:
                    throw new ArgumentException("Key is rejected: the key is system-defined key.");
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public int Count()
            {
                return GetKeys().Count();
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public bool IsCollection(string key)
            {
                bool isArray = false;
                Interop.AppControl.ErrorCode err = Interop.AppControl.IsExtraDataArray(_handle, key, out isArray);
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                    throw new ArgumentNullException("Invalid parameter: key is a zero-length string");
                }
                return isArray;
            }

            private string GetData(string key)
            {
                string value = string.Empty;
                Interop.AppControl.ErrorCode err = Interop.AppControl.GetExtraData(_handle, key, out value);
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                    throw new ArgumentNullException("Invalid parameter: key is a zero-length string");
                    case Interop.AppControl.ErrorCode.KeyNotFound:
                    throw new KeyNotFoundException("Key is not found"); ;
                    case Interop.AppControl.ErrorCode.InvalidDataType:
                    throw new ArgumentException("Invalid data type: value is data collection type");
                    case Interop.AppControl.ErrorCode.KeyRejected:
                    throw new ArgumentException("Key is rejected: the key is system-defined key.");
                }
                return value;
            }

            private IEnumerable<string> GetDataCollection(string key)
            {
                IntPtr valuePtr = IntPtr.Zero;
                int len = -1;

                Interop.AppControl.ErrorCode err = Interop.AppControl.GetExtraDataArray(_handle, key, out valuePtr, out len);
                switch (err)
                {
                    case Interop.AppControl.ErrorCode.InvalidParameter:
                    throw new ArgumentNullException("Invalid parameter: key is a zero-length string");
                    case Interop.AppControl.ErrorCode.KeyNotFound:
                    throw new KeyNotFoundException("Key is not found"); ;
                    case Interop.AppControl.ErrorCode.InvalidDataType:
                    throw new ArgumentException("Invalid data type: value is data collection type");
                    case Interop.AppControl.ErrorCode.KeyRejected:
                    throw new ArgumentException("Key is rejected: the key is system-defined key.");
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
