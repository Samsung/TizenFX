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
    /// An interface for building recorder option
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public interface IOptionBuilder
    {

        /// <summary>
        /// Sets retention period.
        /// </summary>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        void SetRetentionPeriod(int value);

        /// <summary>
        /// Sets interval.
        /// </summary>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        void SetInterval(int value);

        /// <summary>
        /// gets the option object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        RecordOption getOption();
    }

    /// <summary>
    /// This class is used to set recording option parameters
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class OptionBuilder
    {

        private RecordOption option;

        /// <summary>
        /// Initializes a new instance of the OptionBuilder class.
        /// </summary>
        public OptionBuilder()
        {
            option = new RecordOption();
            CreateOption();
        }

        /// <summary>
        /// Destroy the OptionBuilder object.
        /// </summary>
        ~OptionBuilder()
        {
            DestroyOption();
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
                throw SensorErrorFactory.CheckAndThrowException(error, "OptionBuilder.CreateOption Failed");
            }
            option.optionHandle = handle;
        }

        /// <summary>
        /// Destroys a recorder option handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void DestroyOption()
        {
            if (option != null)
            {
                int error = Interop.SensorRecoder.DestroyOption(option.optionHandle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error deleting the sensor recorder option");
                    throw SensorErrorFactory.CheckAndThrowException(error, "OptionBuilder.DestroyOption Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        /// Sets retention period.
        /// </summary>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void SetRetentionPeriod(int value)
        {
            if (option.optionHandle != null)
            {
                int error = Interop.SensorRecoder.OptionSetInt(option.optionHandle, RecorderOption.RetentionPeriod, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking SetRetentionPeriod");
                    throw SensorErrorFactory.CheckAndThrowException(error, "OptionBuilder.SetRetentionPeriod Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        /// Sets Interval.
        /// </summary>
        /// <param name="value">
        /// Value.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void SetInterval(int value)
        {
            if (option.optionHandle != null)
            {
                int error = Interop.SensorRecoder.OptionSetInt(option.optionHandle, RecorderOption.Interval, value);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error checking SetInterval");
                    throw SensorErrorFactory.CheckAndThrowException(error, "OptionBuilder.SetInterval Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Recorder option is not created");
            }
        }

        /// <summary>
        /// gets the OptionHandle object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public RecordOption getOption()
        {
            return option;
        }

    }

    /// <summary>
    /// This class provides the option handle.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class RecordOption
    {

        /// <summary>
        /// Property: Gets the optionHandle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> The option handle </value>
        public IntPtr optionHandle { set; get; }
    }

    /// <summary>
    /// The SensorRecorder class is used for controlling the sensor recorder(start,stop). 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SensorRecorder
    {
        private bool _disposed = false;
        private int sensorType;

        /// <summary>
        /// Initializes a new instance of the SensorRecorder class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name='type'>
        /// type refers to sensor type
        /// </param>
        public SensorRecorder(int type)
        {
            sensorType = type;

            if (IsSupported())
            {
                throw new NotSupportedException(" recorder is not supported.");
            }
        }

        /// <summary>
        /// Checks whether it is supported to record a given sensor type.
        /// </summary>
        /// <returns>
        /// returns true if it is supported to record a given sensor type.
        /// </returns>
        /// <since_tizen> 6 </since_tizen>
        private bool IsSupported()
        {
            bool isSupported;
            int error = Interop.SensorRecoder.IsSupported(sensorType, out isSupported);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error checking if sensor recorder is supported");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.IsSupported Failed");
            }
            return isSupported;
        }

        /// <summary>
        ///  Starts to record a given sensor type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Start(RecordOption option)
        {
            int error = Interop.SensorRecoder.Start(sensorType, option.optionHandle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in starting recorder");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorRecorder.Start Failed");
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
    }
}
