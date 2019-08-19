/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the running component.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ComponentRunningContext : IDisposable
    {
        private const string LogTag = "Tizen.Applications";
        private bool _disposed = false;
        internal IntPtr _contextHandle = IntPtr.Zero;
        private string _componentId = string.Empty;

        internal ComponentRunningContext(IntPtr contextHandle)
        {
            _contextHandle = contextHandle;
        }

        /// <summary>
        /// A constructor of ComponentRunningContext that takes the component ID.
        /// </summary>
        /// <param name="componentId">Component ID.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the "component not exist" error or the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 6 </since_tizen>
        public ComponentRunningContext(string componentId)
        {
            _componentId = componentId;
            IntPtr contextHandle = IntPtr.Zero;
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentManagerGetComponentContext(_componentId, out contextHandle);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManager.ComponentManagerErrorFactory.GetException(err, "Failed to create the ComponentRunningContext of " + _componentId + ".");
            }
            _contextHandle = contextHandle;
        }

        /// <summary>
        /// Destructor of the class.
        /// </summary>
        ~ComponentRunningContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Enumeration for the component state.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum ComponentState
        {
            /// <summary>
            /// The Initialized state. This is the state when the component is constructed but OnCreate() is not called yet.
            /// </summary>
            Initialized = 0,

            /// <summary>
            /// The created state. This state is reached after OnCreate() is called.
            /// </summary>
            Created,

            /// <summary>
            /// The started state. This state is reached after OnStart() or OnStartCommand() is called.
            /// </summary>
            Started,

            /// <summary>
            /// The resumed state. This state is reached after OnResume() is called.
            /// </summary>
            Resumed,

            /// <summary>
            /// The paused state. This state is reached after OnPause() is called.
            /// </summary>
            Paused,

            /// <summary>
            /// The destroyed state. This state is reached right before OnDestroy() call.
            /// </summary>
            Destroyed
        }

        /// <summary>
        /// Gets the ID of the component.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ComponentId
        {
            get
            {
                if (!string.IsNullOrEmpty(_componentId))
                    return _componentId;

                string componentId = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentContextGetComponentId(_contextHandle, out componentId);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the ComponentId. err = " + err);
                }
                _componentId = componentId;

                return _componentId;
            }
        }

        /// <summary>
        /// Gets the application ID of the component.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ApplicationId
        {
            get
            {
                string appId = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentContextGetAppId(_contextHandle, out appId);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the ApplicationId of " + _componentId + ". err = " + err);
                }

                return appId;
            }
        }
        
        /// <summary>
        /// Gets the instance ID of the component.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string InstanceId
        {
            get
            {
                string instanceId = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentContextGetInstanceId(_contextHandle, out instanceId);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the InstanceId of " + _componentId + ". err = " + err);
                }

                return instanceId;
            }
        }

        /// <summary>
        /// Gets the state of the component.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ComponentState State
        {
            get
            {
                int state = 0;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentContextGetComponentState(_contextHandle, out state);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the State of " + _componentId + ". err = " + err);
                }

                return (ComponentState)state;
            }
        }

        /// <summary>
        /// Checks whether the component is terminated or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsTerminated
        {
            get
            {
                bool isTerminated = false;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentContextIsTerminated(_contextHandle, out isTerminated);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the IsTerminated of " + _componentId + ". err = " + err);
                }

                return isTerminated;
            }
        }

        /// <summary>
        /// Checks whether the component is running as sub component of the group.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsSubComponent
        {
            get
            {
                bool isSubComponent = false;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentContextIsSubComponent(_contextHandle, out isSubComponent);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the IsSubComponent of " + _componentId + ". err = " + err);
                }

                return isSubComponent;
            }
        }

        /// <summary>
        /// Resumes the running component.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 6 </since_tizen>
        public void Resume()
        {
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentManagerResumeComponent(_contextHandle);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManager.ComponentManagerErrorFactory.GetException(err, "Failed to Send the resume request.");
            }
        }

        /// <summary>
        /// Pauses the running component.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause()
        {
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentManagerPauseComponent(_contextHandle);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManager.ComponentManagerErrorFactory.GetException(err, "Failed to Send the pause request.");
            }
        }

        /// <summary>
        /// Terminates the running component.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Terminate()
        {
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentManagerTerminateComponent(_contextHandle);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManager.ComponentManagerErrorFactory.GetException(err, "Failed to Send the terminate request.");
            }
        }

        /// <summary>
        /// Releases all resources used by the ComponentInfo class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the ComponentInfo class.
        /// </summary>
        /// <param name="disposing">Disposing</param>
        /// <since_tizen> 6 </since_tizen>
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
            }

            if (_contextHandle != IntPtr.Zero)
            {
                Interop.ComponentManager.ComponentContextDestroy(_contextHandle);
                _contextHandle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}
