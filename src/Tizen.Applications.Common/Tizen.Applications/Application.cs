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

namespace Tizen.Applications
{
    /// <summary>
    /// The class that represents a Tizen application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Application : IDisposable
    {
        internal const string LogTag = "Tizen.Applications";

        private static Application s_CurrentApplication = null;

        private object _lock = new object();

        private DirectoryInfo _directoryInfo;
        private ApplicationInfo _applicationInfo;

        /// <summary>
        /// Gets the instance of the current application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Application Current { get { return s_CurrentApplication; } }

        /// <summary>
        /// Gets the class representing directory information of the current application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DirectoryInfo DirectoryInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_directoryInfo == null)
                    {
                        _directoryInfo = new DirectoryInfo();
                    }
                }
                return _directoryInfo;
            }
        }

        /// <summary>
        /// Gets the class representing information of the current application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ApplicationInfo ApplicationInfo
        {
            get
            {
                lock (_lock)
                {
                    if (_applicationInfo == null)
                    {
                        string appId = string.Empty;
                        Interop.AppCommon.AppGetId(out appId);
                        if (!string.IsNullOrEmpty(appId))
                        {
                            _applicationInfo = new ApplicationInfo(appId);
                        }
                    }
                }
                return _applicationInfo;
            }
        }

        /// <summary>
        /// Gets the name of current application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Name
        {
            get
            {
                string name;
                Interop.AppCommon.AppGetName(out name);
                return name;
            }
        }

        /// <summary>
        /// Gets the version of current application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Version
        {
            get
            {
                string version;
                Interop.AppCommon.AppGetVersion(out version);
                return version;
            }
        }


        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Run(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }
            s_CurrentApplication = this;
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public abstract void Exit();

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 3 </since_tizen>
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
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the application class.
        /// </summary>
        ~Application()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the application class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
