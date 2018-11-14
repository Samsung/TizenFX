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
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// A constructor of ApplicationRunningContext that takes the application ID.
        /// </summary>
        /// <param name="applicationId">Application ID.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the "application not exist" error or the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <since_tizen> 3 </since_tizen>
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
        /// A constructor of ApplicationRunningContext that takes the application id.
        /// </summary>
        /// <param name="applicationId">application id.</param>
        /// <param name="instanceId">instance id.</param>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of application not exist error or system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationRunningContext(string applicationId, string instanceId)
        {
            IntPtr contextHandle = IntPtr.Zero;
            err = Interop.ApplicationManager.AppManagerGetAppContextByInstanceId(applicationId, instanceId, out contextHandle);
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
        /// Destructor of the class.
        /// </summary>
        ~ApplicationRunningContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Enumeration for the application state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum AppState
        {
            /// <summary>
            /// The undefined state.
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
            /// The service application is running.
            /// </summary>
            Service,

            /// <summary>
            /// The application is terminated.
            /// </summary>
            Terminated,
        }

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the package ID of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the application's process ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// Terminates the application.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.kill</privilege>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Terminate()
        {
            err = Interop.ApplicationManager.AppManagerTerminateApp(_contextHandle);
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
        /// Terminates the background application.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.kill</privilege>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TerminateBgApp()
        {
            err = Interop.ApplicationManager.AppManagerRequestTerminateBgApp(_contextHandle);
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
        /// Resumes the running application.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed of invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 4 </since_tizen>
        public void Resume()
        {
            err = Interop.ApplicationManager.AppManagerResumeApp(_contextHandle);
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
        /// Releases all resources used by the ApplicationRunningContext class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
