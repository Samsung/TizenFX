/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// The SensorRecorderManager class is used for controlling the sensor recorder(start,stop,optionset). 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class SensorRecorderManager : IDisposable
    {
        private bool _disposed = false;
        internal IntPtr _optionHandle;
        internal SensorType sensorType;
        internal abstract SensorType GetSensorType();
        internal SensorRecorderManager()
        {
            _optionHandle = IntPtr.Zero;
            sensorType = GetSensorType();
            CreateOption();
        }

        /// <summary>
        /// SensorRecorderManager deconstructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~SensorRecorderManager()
        {
            Dispose(false);
        }

        internal IntPtr OptionHandle
        {
            get
            {
                return _optionHandle;
            }

            set
            {
                _optionHandle = value;
            }
        }

        private bool CheckOption()
        {
            bool result = false;
            if (OptionHandle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor Recorder Option is null");
                throw new ArgumentException("Invalid Parameter: Sensor Recorder Option is null");
            }
            return result;
        }

        /// <summary>
        /// Creates a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void CreateOption()
        {
            IntPtr handle;
            int error = Interop.SensorRecoder.CreateOption(out handle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error creating the sensor recorder option");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.CreateOption Failed");
            }

            OptionHandle = handle;
        }

        /// <summary>
        /// Sets a recording option parameter.
        /// </summary>
        /// <param name="recorderOption">
        /// Option parameter.
        /// </param>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void OptionSetInt(RecorderOption recorderOption, int value)
        {
            if (CheckOption())
            {
                int error = Interop.SensorRecoder.OptionSetInt(OptionHandle, recorderOption, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking sensor recorder option set int");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.OptionSetInt Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        ///  Starts to record a given sensor type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Start()
        {
            if (CheckOption())
            {
                int error = Interop.SensorRecoder.Start(sensorType, OptionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in starting recorder");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.Start Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        ///  Stops recording a given sensor type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Stop()
        {
            int error = Interop.SensorRecoder.Stop(sensorType);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in stopping recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.Stop Failed");
            }
        }

        /// <summary>
        /// Destroys a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void DestroyOption()
        {
            if (CheckOption())
            {
                int error = Interop.SensorRecoder.DestroyOption(OptionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder option");
                    throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.DestroyOption Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        /// Destroy the current object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void DestroyHandles()
        {
            if (_optionHandle != IntPtr.Zero)
            {
                DestroyOption();
                _optionHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Releases all resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed
        /// otherwise, false.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            DestroyHandles();
            _disposed = true;
        }
    }
}
