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

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// Provides methods and properties to retrieve information about a component in a Tizen application.
    /// This class encapsulates details such as component ID, application ID, and other attributes.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ComponentInfo : IDisposable
    {
        private const string LogTag = "Tizen.Applications";
        private bool _disposed = false;
        private IntPtr _infoHandle = IntPtr.Zero;
        private string _componentId = string.Empty;

        internal ComponentInfo(IntPtr infoHandle)
        {
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetComponentId(infoHandle, out _componentId);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManager.ComponentManagerErrorFactory.GetException(err, "Invalid native handle.");
            }
            _infoHandle = infoHandle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentInfo"/> class with the specified component ID.
        /// </summary>
        /// <param name="componentId">The ID of the component.</param>
        /// <exception cref="ArgumentException">Thrown when the component ID is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a system error occurs.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when memory allocation fails.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 6 </since_tizen>
        public ComponentInfo(string componentId)
        {
            _componentId = componentId;
            IntPtr infoHandle = IntPtr.Zero;
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoCreate(_componentId, out infoHandle);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManager.ComponentManagerErrorFactory.GetException(err, "Failed to create the ComponentInfo.");
            }
            _infoHandle = infoHandle;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ComponentInfo"/> class.
        /// </summary>
        ~ComponentInfo()
        {
            Dispose(false);
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

                string compId = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetComponentId(_infoHandle, out compId);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the ComponentId. err = " + err);
                }
                _componentId = compId;

                return _componentId;
            }
        }

        /// <summary>
        /// Gets the application ID associated with the component.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ApplicationId
        {
            get
            {
                string appId = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetAppId(_infoHandle, out appId);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the ApplicationId of " + _componentId + ". err = " + err);
                }

                return appId;
            }
        }

        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ComponentType ComponentType
        {
            get
            {
                Interop.ComponentManager.ComponentInfoComponentType type = 0;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetComponentType(_infoHandle, out type);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the Type of " + _componentId + ". err = " + err);
                }

                return (ComponentType)type;
            }
        }

        /// <summary>
        /// Checks whether the icon of the component should be displayed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsIconDisplayed
        {
            get
            {
                bool iconDisplay = false;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoIsIconDisplay(_infoHandle, out iconDisplay);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the IsIconDisplay of " + _componentId + ". err = " + err);
                }

                return iconDisplay;
            }
        }

        /// <summary>
        /// Checks whether the component is managed by the task manager.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsManagedByTaskManager
        {
            get
            {
                bool managed = false;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoIsManagedByTaskManager(_infoHandle, out managed);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the IsManagedByTaskManager of " + _componentId + ". err = " + err);
                }

                return managed;
            }
        }

        /// <summary>
        /// Gets the absolute path of the component's icon image.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string IconPath
        {
            get
            {
                string path = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetIcon(_infoHandle, out path);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the IconPath of " + _componentId + ". err = " + err);
                }

                return path;
            }
        }

        /// <summary>
        /// Gets the label of the component.
        /// </summary>
        public string Label
        {
            get
            {
                string label = string.Empty;
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetLabel(_infoHandle, out label);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the Label of " + _componentId + ". err = " + err);
                }

                return label;
            }
        }

        /// <summary>
        /// Gets the localized label of the component for a specified locale.
        /// </summary>
        /// <param name="locale">The locale in the format of language and country code (e.g., "en-US").</param>
        /// <remarks>Available values are in the format "[2-letter lowercase language code (ISO 639-1)]-[2-letter lowercase country code (ISO 3166-alpha-2)]".</remarks>
        /// <returns>The localized label corresponding to the specified locale.</returns>
        /// <since_tizen> 6 </since_tizen>
        public string GetLocalizedLabel(string locale)
        {
            string label = string.Empty;
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentInfoGetLocalizedLabel(_infoHandle, locale, out label);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get the GetLocalizedLabel of " + _componentId + ". err = " + err);
                label = Label;
            }
            return label;
        }

        /// <summary>
        /// Releases all resources used by the <see cref="ComponentInfo"/> class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases resources used by the <see cref="ComponentInfo"/> class.
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

            if (_infoHandle != IntPtr.Zero)
            {
                Interop.ComponentManager.ComponentInfoDestroy(_infoHandle);
                _infoHandle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}
