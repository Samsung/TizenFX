/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.Applications.ThemeManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Theme : IDisposable
    {
        private bool _disposed = false;
        private IntPtr _handle;
        private string _id = String.Empty;
        private string _version = String.Empty;
        private string _toolVersion = String.Empty;
        private string _title = String.Empty;
        private string _resolution = String.Empty;
        private string _preview = String.Empty;
        private string _description = String.Empty;

        /// <summary>
        /// A copy constructor of Theme.
        /// </summary>
        /// <param name="theme">Theme class.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Theme(Theme theme)
        {
            if (theme == null || theme._handle == IntPtr.Zero)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(Interop.ThemeManager.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            var err = Interop.ThemeManager.ErrorCode.None;
            err = Interop.ThemeManager.ThemeClone(theme._handle, out _handle);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to clone handle");
            }
        }

        internal Theme(IntPtr handle)
        {
            _handle = handle;
            var err = Interop.ThemeManager.ErrorCode.None;
            err = Interop.ThemeManager.GetId(handle, out _id);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get id");
            }

            err = Interop.ThemeManager.GetVersion(handle, out _version);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get version");
            }

            err = Interop.ThemeManager.GetToolVersion(handle, out _toolVersion);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get tool version");
            }

            err = Interop.ThemeManager.GetTitle(handle, out _title);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get title");
            }

            err = Interop.ThemeManager.GetResolution(handle, out _resolution);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get resolution");
            }

            err = Interop.ThemeManager.GetPreview(handle, out _preview);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get preview");
            }

            err = Interop.ThemeManager.GetDescription(handle, out _description);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get description");
            }
        }

        /// <summary>
        /// A Theme ID
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id { get { return _id; } }

        /// <summary>
        /// A Theme Version
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Version { get { return _version; } }

        /// <summary>
        /// A Theme ToolVersion
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToolVersion { get { return _toolVersion; } }

        /// <summary>
        /// A Theme Title
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Title { get { return _title; } }

        /// <summary>
        /// A Theme Resolution
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Resolution { get { return _resolution; } }

        /// <summary>
        /// A Theme Preview
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Preview { get { return _preview; } }

        /// <summary>
        /// A Theme Description
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Description { get { return _description; } }


        /// <summary>
        /// Gets the string corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetString(string key)
        {
            string str;
            var err = Interop.ThemeManager.GetString(_handle, key, out str);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get string value of the key");
            }

            return str;
        }

        /// <summary>
        /// Gets the string array corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<string> GetStrings(string key)
        {
            IntPtr val;
            int count;
            string[] strings;
            var err = Interop.ThemeManager.GetStringArray(_handle, key, out val, out count);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get string array value of the key");
            }

            IntPtrToStringArray(val, count, out strings);
            return strings;
        }

        /// <summary>
        /// Gets the integer corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetInt(string key)
        {
            int val;
            var err = Interop.ThemeManager.GetInt(_handle, key, out val);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get integer value of the key");
            }

            return val;
        }

        /// <summary>
        /// Gets the float corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFloat(string key)
        {
            float val;
            var err = Interop.ThemeManager.GetFloat(_handle, key, out val);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get float value of the key");
            }

            return val;
        }

        /// <summary>
        /// Gets the bool corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetBool(string key)
        {
            bool val;
            var err = Interop.ThemeManager.GetBool(_handle, key, out val);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get bool value of the key");
            }

            return val;
        }

        /// <summary>
        /// Gets the path corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetPath(string key)
        {
            string val;
            var err = Interop.ThemeManager.GetPath(_handle, key, out val);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get path value of the key");
            }

            return val;
        }

        /// <summary>
        /// Gets the path array corresponding with given key.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<string> GetPaths(string key)
        {
            IntPtr val;
            int count;
            string[] paths;
            var err = Interop.ThemeManager.GetPathArray(_handle, key, out val, out count);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to get path array value of the key");
            }

            IntPtrToStringArray(val, count, out paths);
            return paths;
        }

        static void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
        {
            managedArray = new string[size];
            IntPtr[] IntPtrArray = new IntPtr[size];
            Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);
            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAnsi(IntPtrArray[iterator]);
            }
        }

        /// <summary>
        /// Check the given key is exist or not.
        /// </summary>
        /// <param name="key">The string key to find information.</param>
        /// <since_tizen> 9 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasKey(string key)
        {
            bool val;
            var err = Interop.ThemeManager.IsKeyExist(_handle, key, out val);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to check existence of the key");
            }

            return val;
        }

        /// <summary>
        /// Releases all resources used by the Theme class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Theme class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (_handle != IntPtr.Zero)
            {
                Interop.ThemeManager.ThemeDestroy(_handle);
                _handle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}
