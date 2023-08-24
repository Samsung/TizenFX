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

namespace Tizen.Sensor
{
    /// <summary>
    /// The SensorType Enum defintion for all sensor types.
    /// </summary>
    internal enum SensorType
    {
        /// <summary>
        /// All sensors. This can be used to retrieve the Sensor class object for all available sensors.
        /// </summary>
        All = -1,
        /// <summary>
        /// Accelerometer sensor.
        /// </summary>
        Accelerometer = 0,
        /// <summary>
        /// Gravity sensor.
        /// </summary>
        GravitySensor = 1,
        /// <summary>
        /// Linear Acceleration sensor.
        /// </summary>
        LinearAccelerationSensor = 2,
        /// <summary>
        /// Magnetometer sensor.
        /// </summary>
        Magnetometer = 3,
        /// <summary>
        /// Rotation Vector sensor.
        /// </summary>
        RotationVectorSensor = 4,
        /// <summary>
        /// Orientation sensor.
        /// </summary>
        OrientationSensor = 5,
        /// <summary>
        /// The Gyroscope sensor.
        /// </summary>
        Gyroscope = 6,
        /// <summary>
        /// Light sensor.
        /// </summary>
        LightSensor = 7,
        /// <summary>
        /// Proximity sensor.
        /// </summary>
        ProximitySensor = 8,
        /// <summary>
        /// Pressure sensor.
        /// </summary>
        PressureSensor = 9,
        /// <summary>
        /// Ultraviolet sensor.
        /// </summary>
        UltravioletSensor = 10,
        /// <summary>
        /// Temperature sensor.
        /// </summary>
        TemperatureSensor = 11,
        /// <summary>
        /// Humidity sensor.
        /// </summary>
        HumiditySensor = 12,
        /// <summary>
        /// Hear rate monitor sensor.
        /// </summary>
        HeartRateMonitor = 13,
        /// <summary>
        /// The Uncalibrated Gyroscope sensor.
        /// </summary>
        UncalibratedGyroscope = 17,
        /// <summary>
        /// Uncalibrated Geomagnetic sensor.
        /// </summary>
        UncalibratedMagnetometer = 18,
        /// <summary>
        /// The Gyroscope-based rotation vector sensor.
        /// </summary>
        GyroscopeRotationVectorSensor = 19,
        /// <summary>
        /// Geomagnetic-based rotation vector sensor.
        /// </summary>
        MagnetometerRotationVectorSensor = 20,
        /// <summary>
        /// The Gyroscope-based orientation sensor.
        /// </summary>
        GyroscopeOrientationSensor = 100,
        /// <summary>
        /// Geomagnetic-based orientation sensor.
        /// </summary>
        MagnetometerOrientationSensor = 105,
        /// <summary>
        /// Pedometer sensor.
        /// </summary>
        HRMBatch = 0x200,
        /// <summary>
        /// Pedometer sensor.
        /// </summary>
        HRMLEDGreenBatch = 0x201,
        /// <summary>
        /// Pedometer sensor.
        /// </summary>
        Pedometer = 0x300,
        /// <summary>
        /// Sleep monitor sensor.
        /// </summary>
        SleepMonitor = 0x301,
        /// <summary>
        /// Auto-rotation sensor.
        /// </summary>
        AutoRotation = 0x901,
        /// <summary>
        /// Stationary activity detector.
        /// </summary>
        StationaryActivityDetector = 0x1A00,
        /// <summary>
        /// Walking activity detector.
        /// </summary>
        WalkingActivityDetector = 0x1A00,
        /// <summary>
        /// Running activity detector.
        /// </summary>
        RunningActivityDetector = 0x1A00,
        /// <summary>
        /// InVehicle activity detector.
        /// </summary>
        InVehicleActivityDetector = 0x1A00,
        /// <summary>
        /// Wrist up gesture detector.
        /// </summary>
        WristUpGestureDetector = 0x1201,
        /// <summary>
        /// Pick up gesture detector.
        /// </summary>
        PickUpGestureDetector = 0x1204,
        /// <summary>
        /// Face down gesture detector.
        /// </summary>
        FaceDownGestureDetector = 0x1205
    }

    /// <summary>
    /// The sensor attribute.
    /// </summary>
    internal enum SensorAttribute
    {
        /// <summary>
        /// The axis orientation.
        /// </summary>
        AxisOrientation = 1,

        /// <summary>
        /// The pause policy.
        /// </summary>
        PausePolicy
    }

    /// <summary>
    /// The SensorDataAccuracy Enum definition for all possible sensor data accuracy values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SensorDataAccuracy
    {
        /// <summary>
        /// Undefined sensor data accuracy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Undefined = -1,
        /// <summary>
        /// Sensor data not accurate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Bad = 0,
        /// <summary>
        /// Moderately accurate sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Normal = 1,
        /// <summary>
        /// Highly accurate sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Good = 2,
        /// <summary>
        /// Very highly accurate sensor data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        VeryGood = 3
    }

    /// <summary>
    /// The Sensor Option Enum definition for pause policies of sensor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SensorPausePolicy
    {
        /// <summary>
        /// Receives data when the LCD is off and in the power save mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,
        /// <summary>
        /// Does not receive data when the LCD is off.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DisplayOff,
        /// <summary>
        /// Does not receive data in the power save mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        PowerSaveMode,
        /// <summary>
        /// Does not receive data when the LCD is off and in the power save mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        All
    }

    /// <summary>
    /// The pedometer state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PedometerState
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unknown = -1,

        /// <summary>
        /// Stop state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Stop,

        /// <summary>
        /// Walking state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Walk,

        /// <summary>
        /// Running state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Run
    }

    /// <summary>
    /// The sleep monitor state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SleepMonitorState
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unknown = -1,

        /// <summary>
        /// The wake state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Wake,

        /// <summary>
        /// The sleeping state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sleep
    }

    /// <summary>
    /// The proximity sensor state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProximitySensorState
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unknown = -1,

        /// <summary>
        /// Near sate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Near = 0,

        /// <summary>
        /// Far state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Far = 5
    }

    /// <summary>
    /// The detector sensor state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DetectorState
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unknown = -1,

        /// <summary>
        /// None sate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotDetected = 0,

        /// <summary>
        /// Detected state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Detected = 1
    }
    
    /// <summary>
    /// The auto-rotation state.
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum AutoRotationState
    {
        /// <summary>
        /// Degree_0 sate.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        Degree_0 = 1,

        /// <summary>
        /// Degree_90 state.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        Degree_90 = 2,

        /// <summary>
        /// Degree_180 state.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        Degree_180 = 3,

        /// <summary>
        /// Degree_270 state.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        Degree_270 = 4
    }


    /// <summary>
    /// HeartRateMonitorBatchState types.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public enum HeartRateMonitorBatchState
    {
        /// <summary>
        /// Flush but there is no batched data
        /// </summary>
        SENSOR_HRM_BATCH_STATE_NODATA_FLUSH = -99,

        /// <summary>
        /// Very low measurement reliability 
        /// </summary>
        SENSOR_HRM_BATCH_STATE_VERYLOW_RELIABILITY = -10,

        /// <summary>
        ///  Low measurement reliability
        /// </summary>
        SENSOR_HRM_BATCH_STATE_LOW_RELIABILITY = -8,

        /// <summary>
        /// Device detachment is detected during auto measurement
        /// </summary>
        SENSOR_HRM_BATCH_STATE_DETACHED_AUTO = -5,

        /// <summary>
        /// Device detachment is detected
        /// </summary>
        SENSOR_HRM_BATCH_STATE_DETACHED = -3,

        /// <summary>
        /// The Movement is detected during on-demand measurement
        /// </summary>
        SENSOR_HRM_BATCH_STATE_DETECT_MOVE = -2,

        /// <summary>
        /// Device attachment is detected
        /// </summary>
        SENSOR_HRM_BATCH_STATE_ATTACHED = -1,

        /// <summary>
        /// Initial state before measurement
        /// </summary>
        SENSOR_HRM_BATCH_STATE_NONE = 0,

        /// <summary>
        /// SENSOR_HRM_BATCH_STATE_OK
        /// </summary>
        SENSOR_HRM_BATCH_STATE_OK = 1
    }
}
