/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;

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

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AppControlReplyReceivedEventArgs> AppControlReplyReceived;

        /// <summary>
        ///
        /// </summary>
        public AppControl()
        {
            ErrorCode err = Interop.AppControl.Create(out _handle);
            if (err != ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to create the appcontrol handle. Err = " + err);
            }
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
                    ErrorCode err = Interop.AppControl.GetOperation(_handle, out _operation);
                    if (err != ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the operation from the appcontrol. Err = " + err);
                    }
                }
                return _operation;
            }
            set
            {
                ErrorCode err = Interop.AppControl.SetOperation(_handle, value);
                if (err == ErrorCode.None)
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
                    ErrorCode err = Interop.AppControl.GetMime(_handle, out _mime);
                    if (err != ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the mime from the appcontrol. Err = " + err);
                    }
                }
                return _mime;
            }
            set
            {
                ErrorCode err = Interop.AppControl.SetMime(_handle, value);
                if (err == ErrorCode.None)
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
                    ErrorCode err = Interop.AppControl.GetUri(_handle, out _uri);
                    if (err != ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the uri from the appcontrol. Err = " + err);
                    }
                }
                return _uri;
            }
            set
            {
                ErrorCode err = Interop.AppControl.SetUri(_handle, value);
                if (err == ErrorCode.None)
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
                    ErrorCode err = Interop.AppControl.GetCategory(_handle, out _category);
                    if (err != ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the category from the appcontrol. Err = " + err);
                    }
                }
                return _category;
            }
            set
            {
                ErrorCode err = Interop.AppControl.SetCategory(_handle, value);
                if (err == ErrorCode.None)
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
                    ErrorCode err = Interop.AppControl.GetAppId(_handle, out _applicationId);
                    if (err != ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the appId from the appcontrol. Err = " + err);
                    }
                }
                return _applicationId;
            }
            set
            {
                ErrorCode err = Interop.AppControl.SetAppId(_handle, value);
                if (err == ErrorCode.None)
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
                ErrorCode err = Interop.AppControl.GetLaunchMode(_handle, out value);
                if (err != ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the launchMode from the appcontrol. Err = " + err);
                }
                return (AppControlLaunchMode)value;
            }
            set
            {
                ErrorCode err = Interop.AppControl.SetLaunchMode(_handle, (int)value);
                if (err != ErrorCode.None)
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
                {
                    _extraData = new ExtraDataCollection();
                }
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
            if (pointerToApplicationIds != null)
            {
                ErrorCode err = Interop.AppControl.ForeachAppMatched(control._handle, callback, pointerToApplicationIds);
                if (err != ErrorCode.None)
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
        /// <param name="request"></param>
        public static void SendLaunchRequest(AppControl request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public static void SendLaunchRequestForReply(AppControl request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public class ExtraDataCollection
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void Add(string key, string value)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void Add(string key, IEnumerable<string> value)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public T Get<T>(string key)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public object Get(string key)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            public void Remove(string key)
            {
                throw new NotImplementedException();
            }
        }

    }
}
