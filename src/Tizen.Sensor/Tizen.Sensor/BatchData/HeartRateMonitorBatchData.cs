using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// The HeartRateMonitorBatchData class is used for storing value of HeartRateMonitorBatch sensor.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class HeartRateMonitorBatchData : BatchData
    {
        /// <summary>
        /// Initializes a new instance of the HeartRateMonitorBatchData class.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timestamp">Timestamp of HeartRateMonitorBatch sensor event.</param>
        /// <param name="accuracy">Sensor accuracy of HeartRateMonitorBatch sensor event.</param>
        /// <param name="state">Value indicating the status of the HeartRateMonitorBatch sensor.</param>
        /// <param name="heartRate">heartRate of HeartRateMonitorBatch sensor event.</param>
        /// <param name="rri">rri of HeartRateMonitorBatch sensor event.</param>
        public HeartRateMonitorBatchData(ulong timestamp, SensorDataAccuracy accuracy, HeartRateMonitorBatchState state, int heartRate, int rri) : base(timestamp, accuracy)
        {
            State = state;
            HeartRate = heartRate;
            RRInterval = rri;
        }

        /// <summary>
        /// Gets the value of the HeartRateMonitorBatch state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> State </value>
        public HeartRateMonitorBatchState State { get; }

        /// <summary>
        /// Heart rate in beats per minute
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> HeartRate </value>
        public int HeartRate { get; }

        /// <summary>
        /// Gets the value R wave-to-R wave interval(RRI) from ECG sensor(Unit is millisecond).
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <value> RRInterval </value>
        public int RRInterval { get; }

    }
}
