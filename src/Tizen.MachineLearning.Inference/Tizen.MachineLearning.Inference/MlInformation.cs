/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd. All Rights Reserved.
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

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The MlInformation class manages information based on key-value.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class MlInformation : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private InfoType _type;
        private bool _fromList = false;

        internal enum InfoType
        {
            Option = 0,
            Information = 1,
        }

        /// <summary>
        /// Creates a MlInformation instance.
        /// </summary>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 13 </since_tizen>
        public MlInformation() {
            NNStreamer.CheckNNStreamerSupport();

            NNStreamerError ret = Interop.Util.CreateOption(out _handle);
            NNStreamer.CheckException(ret, "Failed to create information handle");

            _type = InfoType.Option;
        }

        /// <summary>
        /// Creates a MlInformation instance from native handle.
        /// </summary>
        /// <param name="handle">Native handle of MlInformation.</param>
        /// <param name="type">Types of MlInformation.</param>
        /// <param name="fromList">Created from MlInformationList, no need to release native handle.</param>
        /// <since_tizen> 13 </since_tizen>
        internal MlInformation(IntPtr handle, InfoType type, bool fromList) {
            NNStreamer.CheckNNStreamerSupport();

            if (handle == IntPtr.Zero)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The information handle is null");

            _handle = handle;
            _type = type;
            _fromList = fromList;
        }

        /// <summary>
        /// Destroys the MlInformation resource.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        ~MlInformation() {
            Dispose(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // release managed object
            }

            // release unmanaged objects
            if (_handle != IntPtr.Zero)
            {
                NNStreamerError ret = NNStreamerError.InvalidParameter;

                switch(_type)
                {
                    case InfoType.Option:
                        ret = Interop.Util.DestroyOption(_handle);
                        break;
                    case InfoType.Information:
                        if (!_fromList) {
                            ret = Interop.Util.DestroyInformation(_handle);
                        } else {
                            /* Information handle is from MlInformationList should not be released */
                            ret = NNStreamerError.None;
                        }
                        break;
                }

                NNStreamer.CheckException(ret, "Failed to destroy the information");

                _handle = IntPtr.Zero;
            }

            _disposed = true;
        }

        /// <summary>
        /// Internal method to get the native handle of MlInformation.
        /// </summary>
        /// <returns>The native handle</returns>
        /// <since_tizen> 13 </since_tizen>
        internal IntPtr GetHandle()
        {
            return _handle;
        }

        /// <summary>
        /// Sets a new key-value in MlInformation instance.
        /// </summary>
        /// <param name="key">The key to be set.</param>
        /// <param name="value">The value to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void SetString(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property key is invalid");

            if (string.IsNullOrEmpty(value))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property value is invalid");

            NNStreamerError ret = NNStreamerError.InvalidParameter;

            switch(_type)
            {
                case InfoType.Option:
                    IntPtr valuePtr = Interop.Util.StringToIntPtr(value);
                    ret = Interop.Util.SetOptionValue(_handle, Interop.Util.StringToIntPtr(key), valuePtr, null);
                    break;
                case InfoType.Information:
                    ret = NNStreamerError.NotSupported;
                    Log.Error(NNStreamer.TAG, "InfoType Information does not support set value");
                    break;
            }

            NNStreamer.CheckException(ret, "Failed to set string value");
        }

        /// <summary>
        /// Sets a new key-value in MlInformation instance.
        /// </summary>
        /// <param name="key">The key to be set.</param>
        /// <param name="value">The value to be set.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void SetInteger(string key, int value)
        {
            if (string.IsNullOrEmpty(key))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property key is invalid");

            NNStreamerError ret = NNStreamerError.InvalidParameter;

            switch(_type)
            {
                case InfoType.Option:
                    ret = Interop.Util.SetOptionValue(_handle, Interop.Util.StringToIntPtr(key), Interop.Util.IntToIntPtr(value), null);
                    break;
                case InfoType.Information:
                    ret = NNStreamerError.NotSupported;
                    Log.Error(NNStreamer.TAG, "InfoType Information does not support set value");
                    break;
            }

            NNStreamer.CheckException(ret, "Failed to set integer value");
        }

        private IntPtr GetValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The property key is invalid");

            IntPtr value = IntPtr.Zero;
            NNStreamerError ret = NNStreamerError.InvalidParameter;

            switch(_type)
            {
                case InfoType.Option:
                    ret = Interop.Util.GetOptionValue(_handle, Interop.Util.StringToIntPtr(key), out value);
                    break;
                case InfoType.Information:
                    ret = Interop.Util.GetInformationValue(_handle, Interop.Util.StringToIntPtr(key), out value);
                    break;
            }

            NNStreamer.CheckException(ret, "Failed to get value of key from information handle");

            return value;
        }

        /// <summary>
        /// Gets a string value of key in MlInformation instance.
        /// </summary>
        /// <param name="key">The key to get the corresponding value.</param>
        /// <returns>The string value of the key.</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 13 </since_tizen>
        public string GetString(string key)
        {
            IntPtr value = GetValue(key);
            if (value == IntPtr.Zero)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Could not find value of key from information handle");

            return Interop.Util.IntPtrToString(value);
        }

        /// <summary>
        /// Gets an int value of key in MlInformation instance.
        /// </summary>
        /// <param name="key">The key to get the corresponding value.</param>
        /// <returns>The integer value of the key.</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 13 </since_tizen>
        public int GetInteger(string key)
        {
            IntPtr value = GetValue(key);
            if (value == IntPtr.Zero)
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Could not find value of key from information handle");

            return Interop.Util.IntPtrToInt(value);
        }

        /// <summary>
        /// Gets a TensorsData value of key in MlInformation instance.
        /// </summary>
        /// <param name="key">The key to get TensorsData.</param>
        /// <returns>The TensorsData value of the key.</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 13 </since_tizen>
        public TensorsData GetTensorsData(string key)
        {
            IntPtr value = GetValue(key);
            IntPtr infoHandle = IntPtr.Zero;

            NNStreamerError ret = Interop.Util.GetInfo(value, out infoHandle);
            NNStreamer.CheckException(ret, "Failed to get value of key from information handle");

            TensorsData data = TensorsData.CreateFromNativeHandle(value, infoHandle, true, false);

            return data;
        }
    }
}
