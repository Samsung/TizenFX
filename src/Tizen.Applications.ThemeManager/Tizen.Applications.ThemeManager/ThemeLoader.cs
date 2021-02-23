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
    public class ThemeLoader : IDisposable
    {
        private const string LogTag = "Tizen.Applications.ThemeManager";
        private bool _disposed = false;
        private event EventHandler<ThemeEventArgs> _changedEventHandler;
        private Interop.ThemeManager.ThemeLoaderChangedCallback _callback;
        private string _eventId;
        private Theme _currentTheme = null;
        internal IntPtr _loaderHandle = IntPtr.Zero;

        /// <summary>
        /// Creates ThemeLoader.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="OutOfMemoryException">Failed to create handle.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ThemeLoader()
        {
            Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderCreate(out _loaderHandle);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to create themeloader");
            }
        }

        private void OnThemeChanged(IntPtr handle, IntPtr userData)
        {
            Interop.ThemeManager.ThemeClone(handle, out IntPtr cloned);
            _changedEventHandler?.Invoke(this, new ThemeEventArgs(new Theme(cloned)));
        }

        /// <summary>
        /// Adds or removes events for theme changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ThemeEventArgs> ThemeChanged
        {
            add
            {
                if (_changedEventHandler == null)
                {
                    if (_callback == null)
                        _callback = new Interop.ThemeManager.ThemeLoaderChangedCallback(OnThemeChanged);
                    Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderAddEvent(_loaderHandle, _callback, IntPtr.Zero, out _eventId);

                    if (err != Interop.ThemeManager.ErrorCode.None)
                    {
                        throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to add event");
                    }

                }
                _changedEventHandler += value;

            }
            remove
            {
                _changedEventHandler -= value;
                if (_changedEventHandler == null)
                {
                    Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderRemoveEvent(_loaderHandle, _eventId);

                    if (err != Interop.ThemeManager.ErrorCode.None)
                    {
                        throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to remove event");
                    }
                    _callback = null;
                }
            }
        }

        /// <summary>
        /// Sets current theme.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Theme CurrentTheme
        {
            get
            {
                if (_currentTheme != null && _currentTheme.Id.Length > 0)
                    return _currentTheme;

                Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderLoadCurrentTheme(_loaderHandle, out IntPtr _themeHandle);
                if (err != Interop.ThemeManager.ErrorCode.None)
                {
                    throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to load current theme");
                }

                _currentTheme = new Theme(_themeHandle);
                return _currentTheme;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("value is null");

                Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderSetCurrentTheme(_loaderHandle, value.Id);
                if (err != Interop.ThemeManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to set current. Err = " + err);
                    throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to set current theme");
                }

                if(_currentTheme != value)
                    _currentTheme = value;
            }
        }

        /// <summary>
        /// Loads theme.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Theme LoadTheme(string id)
        {
            IntPtr _themeHandle;

            Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderLoadTheme(_loaderHandle, id, out _themeHandle);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to load theme");
            }

            return new Theme(_themeHandle);
        }

        /// <summary>
        /// Gets bundle of theme IDs.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<string> QueryIds()
        {
            IntPtr ids;
            string[] stringArray;
            int count;

            Interop.ThemeManager.ErrorCode err = Interop.ThemeManager.LoaderQueryId(_loaderHandle, out ids, out count);
            if (err != Interop.ThemeManager.ErrorCode.None)
            {
                throw Interop.ThemeManager.ThemeManagerErrorFactory.GetException(err, "Failed to query ids");
            }

            IntPtrToStringArray(ids, count, out stringArray);
            return stringArray;
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
        /// Releases all resources used by the ThemeLoader class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the ThemeLoader class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (_loaderHandle != IntPtr.Zero)
            {
                Interop.ThemeManager.LoaderDestroy(_loaderHandle);
                _loaderHandle = IntPtr.Zero;
            }

            if (disposing && _currentTheme != null)
                _currentTheme.Dispose();

            _disposed = true;
        }
    }
}
