using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// The BatchData class is used for storing value of particular batch type sensor.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public abstract class BatchData
    {
        /// <summary>
        /// Initializes a new instance of the BatchData class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timestamp">Timestamp of sensor event.</param>
        /// <param name="accuracy">Sensor accuracy of sensor event.</param>
        public BatchData(ulong timestamp, SensorDataAccuracy accuracy)
        {
            Timestamp = timestamp;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Timestamp as ticks that data was created
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Timestamp </value>
        public ulong Timestamp
        {
            get; private set;
        }

        /// <summary>
        /// Accuracy of the HeartRateMonitorBatch data.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> Accuracy </value>
        public SensorDataAccuracy Accuracy { get; private set; } = SensorDataAccuracy.Undefined;
    }
}
