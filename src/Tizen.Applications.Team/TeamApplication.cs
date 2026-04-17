/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the abstract base class of a Team application instance.
    /// </summary>
    /// <remarks>
    /// A Team application is a member instance managed by the Team host process. Each instance
    /// owns its own lifecycle, directory information, and application information.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TeamApplication : IDisposable
    {
        internal const string LogTag = "DN_TAM";

        private object _lock = new object();

        private TeamDirectoryInfo _directoryInfo;
        private TeamApplicationInfo _applicationInfo;

        /// <summary>
        /// The backend that drives this Team application instance.
        /// </summary>
        protected readonly TeamCoreBackend _backend;

        /// <summary>
        /// Gets the backend associated with this Team application instance.
        /// </summary>
        protected ICoreBackend Backend => _backend;

        /// <summary>
        /// Initializes the <see cref="TeamApplication"/> class with the given backend.
        /// </summary>
        /// <param name="backend">The backend used to drive this Team application instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="backend"/> is null.</exception>
        protected TeamApplication(TeamCoreBackend backend)
        {
            Log.Info(LogTag, "TeamApplication constructor called");
            _backend = backend ?? throw new ArgumentNullException(nameof(backend));
        }

        /// <summary>
        /// Gets the directory information of the current Team application instance.
        /// </summary>
        /// <value>A <see cref="TeamDirectoryInfo"/> instance, or <c>null</c> if the member handle is not yet available.</value>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TeamDirectoryInfo DirectoryInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_directoryInfo == null)
                    {
                        Log.Info(LogTag, "DirectoryInfo getter called - creating new TeamDirectoryInfo");
                        var memberHandle = _backend.MemberHandle;
                        if (memberHandle != IntPtr.Zero)
                        {
                            _directoryInfo = new TeamDirectoryInfo(memberHandle);
                        }
                    }
                }
                return _directoryInfo;
            }
        }

        /// <summary>
        /// Gets the application information of the current Team application instance.
        /// </summary>
        /// <value>A <see cref="TeamApplicationInfo"/> instance, or <c>null</c> if the member handle or application id cannot be resolved.</value>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TeamApplicationInfo ApplicationInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_applicationInfo == null)
                    {
                        Log.Info(LogTag, "ApplicationInfo getter called - creating new TeamApplicationInfo");
                        var memberHandle = _backend.MemberHandle;
                        if (memberHandle != IntPtr.Zero)
                        {
                            var err = Interop.TeamManager.TeamAppGetAppId(memberHandle, out string appId);
                            if (err == 0 && !string.IsNullOrEmpty(appId))
                            {
                                _applicationInfo = new TeamApplicationInfo(memberHandle, appId);
                            }
                            else
                            {
                                Log.Warn(LogTag, $"Failed to get AppId from memberHandle. err = {err}");
                            }
                        }
                        else
                        {
                            Log.Warn(LogTag, "MemberHandle is zero, cannot get ApplicationInfo");
                        }
                    }
                }
                return _applicationInfo;
            }
        }

        /// <summary>
        /// Gets the current Team application instance.
        /// </summary>
        /// <value>The current <see cref="TeamApplication"/> instance.</value>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TeamApplication Current { get { return this; } }

        /// <summary>
        /// Gets the name of the current Team application instance.
        /// </summary>
        /// <value>The name string, or <see cref="string.Empty"/> if it cannot be retrieved.</value>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                var memberHandle = _backend.MemberHandle;
                if (memberHandle == IntPtr.Zero)
                {
                    Log.Warn(LogTag, "MemberHandle is zero, cannot get Name");
                    return string.Empty;
                }

                var err = Interop.TeamManager.TeamAppGetName(memberHandle, out string name);
                if (err != Interop.TeamManager.TeamAppErrorCode.None)
                {
                    Log.Warn(LogTag, $"Failed to get Name. err = {err}");
                    return string.Empty;
                }

                return name ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets the version of the current Team application instance.
        /// </summary>
        /// <value>The version string, or <see cref="string.Empty"/> if it cannot be retrieved.</value>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Version
        {
            get
            {
                var memberHandle = _backend.MemberHandle;
                if (memberHandle == IntPtr.Zero)
                {
                    Log.Warn(LogTag, "MemberHandle is zero, cannot get Version");
                    return string.Empty;
                }

                var err = Interop.TeamManager.TeamAppGetVersion(memberHandle, out string version);
                if (err != Interop.TeamManager.TeamAppErrorCode.None)
                {
                    Log.Warn(LogTag, $"Failed to get Version. err = {err}");
                    return string.Empty;
                }

                return version ?? string.Empty;
            }
        }

        /// <summary>
        /// Runs the Team application's main loop and registers this instance with the Team manager.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="args"/> is null.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Run(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            TeamManager.RegisterRunningTeamApp(this);
        }

        /// <summary>
        /// Exits the main loop of this Team application instance and unregisters it from the Team manager.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Exit()
        {
            TeamManager.UnRegisterRunningTeamApp(this);
            _backend.Exit();
        }

        private bool _disposedValue = false;

        /// <summary>
        /// Releases the resources used by this Team application instance.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_applicationInfo != null)
                    {
                        _applicationInfo.Dispose();
                    }
                    Exit();
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes the <see cref="TeamApplication"/> instance.
        /// </summary>
        ~TeamApplication()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by this Team application instance.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Log.Info(LogTag, "TeamApplication.Dispose() called");
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
