/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the application.
    /// </summary>
    public class ApplicationRunningContext : IDisposable
    {
        private const string LogTag = "Tizen.Applications";
        private bool _disposed = false;
        private IntPtr _contextHandle = IntPtr.Zero;
        private Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

        internal ApplicationRunningContext(IntPtr contextHandle)
        {
            _contextHandle = contextHandle;
        }

        /// <summary>
        /// A constructor of ApplicationRunningContext that takes the application id.
        /// </summary>
        /// <param name="applicationId">application id.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of application not exist error or system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        public ApplicationRunningContext(string applicationId)
        {
            IntPtr contextHandle = IntPtr.Zero;
            err = Interop.ApplicationManager.AppManagerGetAppContext(applicationId, out contextHandle);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get the handle of the ApplicationRunningContext. err = " + err);
                switch (err)
                {
                    case Interop.ApplicationManager.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Parameter.");
                    case Interop.ApplicationManager.ErrorCode.NoSuchApp:
                        throw new InvalidOperationException("No such application.");
                    case Interop.ApplicationManager.ErrorCode.OutOfMemory:
                        throw new OutOfMemoryException("Out of memory");
                    default:
                        throw new InvalidOperationException("Invalid Operation.");
                }
            }
            _contextHandle = contextHandle;
        }

        /// <summary>
        /// Destructor of the class
        /// </summary>
        ~ApplicationRunningContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Enumeration for the Application State.
        /// </summary>
        public enum AppState
        {
            /// <summary>
            /// The undefined state
            /// </summary>
            Undefined = 0,

            /// <summary>
            /// The UI application is running in the foreground.
            /// </summary>
            Foreground,

            /// <summary>
            /// The UI application is running in the background.
            /// </summary>
            Background,

            /// <summary>
            /// The Service application is running.
            /// </summary>
            Service,

            /// <summary>
            /// The application is terminated.
            /// </summary>
            Terminated,
        }

        /// <summary>
        /// Gets the application id.
        /// </summary>
        public string ApplicationId
        {
            get
            {
                string appid = string.Empty;
                err = Interop.ApplicationManager.AppContextGetAppId(_contextHandle, out appid);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the application id. err = " + err);
                }
                return appid;
            }
        }

        /// <summary>
        /// Gets the package id of the application.
        /// </summary>
        public string PackageId
        {
            get
            {
                string packageid = string.Empty;
                err = Interop.ApplicationManager.AppContextGetPackageId(_contextHandle, out packageid);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the package id. err = " + err);
                }
                return packageid;
            }
        }

        /// <summary>
        /// Gets the application's process id.
        /// </summary>
        public int ProcessId
        {
            get
            {
                int pid = 0;
                err = Interop.ApplicationManager.AppContextGetPid(_contextHandle, out pid);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the process id. err = " + err);
                }
                return pid;
            }
        }

        /// <summary>
        /// Gets the state of the application.
        /// </summary>
        public AppState State
        {
            get
            {
                int state = 0;

                err = Interop.ApplicationManager.AppContextGetAppState(_contextHandle, out state);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the application state. err = " + err);
                }
                return (AppState)state;
            }
        }

        /// <summary>
        /// Gets whether the application is sub application of the application group.
        /// </summary>
        public bool IsSubApp
        {
            get
            {
                bool subapp = false;
                err = Interop.ApplicationManager.AppContextIsSubApp(_contextHandle, out subapp);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the IsSubApp value. err = " + err);
                }
                return subapp;
            }
        }

        /// <summary>
        /// Releases all resources used by the ApplicationRunningContext class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (_contextHandle != IntPtr.Zero)
            {
                Interop.ApplicationManager.AppContextDestroy(_contextHandle);
                _contextHandle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}