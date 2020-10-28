using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// The HeartRateMonitorLEDGreenBatchData class is used for storing value of HeartRateMonitorLEDGreenBatch sensor.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class HeartRateMonitorLEDGreenBatchData : BatchData
    {
        /// <summary>
        /// Initializes a new instance of the HeartRateMonitorLEDGreenBatchData class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timestamp">Timestamp of sensor event.</param>
        /// <param name="accuracy">Sensor accuracy of sensor event.</param>
        /// <param name="green">Green LED ADC value of sensor event</param>
        /// <param name="accelerationX">X axis's value of gravitational acceleration of sensor event.</param>
        /// <param name="accelerationY">Y axis's value of gravitational acceleration of sensor event.</param>
        /// <param name="accelerationZ">Z axis's value of gravitational acceleration of sensor event.</param>
        /// <param name="index">Sequential index of sensor event.</param>
        public HeartRateMonitorLEDGreenBatchData(ulong timestamp, SensorDataAccuracy accuracy, uint green, int accelerationX, int accelerationY, int accelerationZ, uint index) : base(timestamp, accuracy)
        {
            Green = green;
            AccelerationX = accelerationX;
            AccelerationY = accelerationY;
            AccelerationY = accelerationZ;
            Index = index;
        }

        /// <summary>
        /// Gets the value of the Green LED ADC Value. (0 ~ 4194304)
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Green </value>
        public uint Green { get; }

        /// <summary>
        /// Gets the X axis's uncalibrated value of the gravitational acceleration. (-4096 ~ 4096)
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> AccelerationX </value>
        public int AccelerationX { get; }

        /// <summary>
        /// Gets the Y axis's uncalibrated value of the gravitational acceleration. (-4096 ~ 4096)
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> AccelerationY </value>
        public int AccelerationY { get; }


        /// <summary>
        /// Gets the Z axis's uncalibrated value of the gravitational acceleration. (-4096 ~ 4096)
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> AccelerationZ </value>
        public int AccelerationZ { get; }


        /// <summary>
        /// Gets the index value between 0 and 299 used for deburring purposes
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Index </value>
        public uint Index { get; }
    }
}
