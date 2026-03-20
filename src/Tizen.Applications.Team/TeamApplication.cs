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
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    public abstract class TeamApplication : IDisposable
    {
        internal const string LogTag = "DN_TAM";

        private object _lock = new object();

        private TeamDirectoryInfo _directoryInfo;
        private TeamApplicationInfo _applicationInfo;
        protected readonly TeamCoreBackend _backend;

        protected ICoreBackend Backend => _backend;

        protected TeamApplication(TeamCoreBackend backend)
        {
            Log.Info(LogTag, "TeamApplication constructor called");
            _backend = backend ?? throw new ArgumentNullException(nameof(backend));
        }

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

        public TeamApplication Current { get { return this; } }

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

        public virtual void Run(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            TeamManager.RegisterRunningTeamApp(this);
        }

        public virtual void Exit()
        {
            TeamManager.UnRegisterRunningTeamApp(this);
            _backend.Exit();
        }

        private bool _disposedValue = false;

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

        ~TeamApplication()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Log.Info(LogTag, "TeamApplication.Dispose() called");
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
