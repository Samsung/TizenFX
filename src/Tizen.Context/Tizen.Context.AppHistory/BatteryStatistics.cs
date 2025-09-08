/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Context.AppHistory
{
    /// <summary>
    /// This class provides APIs to query the battery consumption per application.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class BatteryStatistics : AppStatistics
    {
        private const string AppStatsConsumption = "TotalAmount";

        /// <summary>
        /// The default constructor of BatteryStatistics class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an internal error.</exception>
        /// <exception cref="NotSupportedException">Thrown when the features are not supported.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public BatteryStatistics()
        {
            SortOrder = SortOrderType.ConsumptionMost;
            Uri = ConvertSortOrderToString((int)SortOrder);

            bool isSupported = false;
            int error = Interop.CtxHistory.IsSupported(Uri, out isSupported);
            if ((AppHistoryError)error != AppHistoryError.None)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException((AppHistoryError)error, Uri);
            }

            if (!isSupported)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.NotSupported, Uri);
            }
        }

        /// <summary>
        /// The constructor of BatteryStatistics class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="order">The criteria of the battery statistics sorted by.</param>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an internal error.</exception>
        /// <exception cref="NotSupportedException">Thrown when the features are not supported.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public BatteryStatistics(SortOrderType order)
        {
            SortOrder = order;
            Uri = ConvertSortOrderToString((int)SortOrder);

            if (Uri == null)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.InvalidParameter, "Invalid SortOrderType");
            }

            bool isSupported = false;
            int error = Interop.CtxHistory.IsSupported(Uri, out isSupported);
            if ((AppHistoryError)error != AppHistoryError.None)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException((AppHistoryError)error, Uri);
            }

            if (!isSupported)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.NotSupported, Uri);
            }
        }

        /// <summary>
        /// Retrieves a given type of battery statistics.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="startTime">The start time of the data to be aggregated.</param>
        /// <param name="endTime">The end time of the data to be aggregated.</param>
        /// <returns>Battery statistics data retrieved.</returns>
        /// <privilege>http://tizen.org/privilege/apphistory.read</privilege>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="InvalidOperationException">Thrown when invalid operation occurs.</exception>
        /// <exception cref="NotSupportedException">Thrown when the features are not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to retrieve the application history.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public IReadOnlyList<BatteryStatisticsData> Query(DateTime startTime, DateTime endTime)
        {
            CheckTimeSpan(startTime, endTime);

            return Query(startTime, endTime, DefaultResultSize);
        }

        /// <summary>
        /// Retrieves a given type of battery statistics.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="startTime">The start time of the data to be aggregated.</param>
        /// <param name="endTime">The end time of the data to be aggregated.</param>
        /// <param name="resultSize">The number of data records to be retrieved.</param>
        /// <returns>Battery statistics data retrieved.</returns>
        /// <privilege>http://tizen.org/privilege/apphistory.read</privilege>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an invalid operation occurs.</exception>
        /// <exception cref="NotSupportedException">Thrown when the features are not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to retrieve the application history.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public IReadOnlyList<BatteryStatisticsData> Query(DateTime startTime, DateTime endTime, uint resultSize)
        {
            CheckTimeSpan(startTime, endTime);
            CheckResultSize(resultSize);

            List<BatteryStatisticsData> result = new List<BatteryStatisticsData>();

            IntPtr cursor = IntPtr.Zero;
            int error = Interop.CtxHistory.Query(Uri, (int)ConvertDateTimeToUnixTimestamp(startTime), (int)ConvertDateTimeToUnixTimestamp(endTime), resultSize, out cursor);
            if ((AppHistoryError)error == AppHistoryError.NoData)
            {
                return result.AsReadOnly();
            }
            else if ((AppHistoryError)error != AppHistoryError.None)
            {
                Log.Error(AppHistoryErrorFactory.LogTag, "Failed to request query battery statistics");
                throw AppHistoryErrorFactory.CheckAndThrowException((AppHistoryError)error, "Failed to request query battery statistics");
            }

            int size;
            error = Interop.CtxHistoryCursor.GetCount(cursor, out size);
            Interop.CtxHistoryCursor.First(cursor);

            for (int i = 0; i < size; i++)
            {
                result.Add(ConvertOutputToStatsData(cursor));
                Interop.CtxHistoryCursor.Next(cursor);
            }
            Interop.CtxHistoryCursor.Destroy(cursor);

            return result.AsReadOnly();
        }

        /// <summary>
        /// Gets the last time when the device was fully charged.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns>The last time when the device was fully charged.</returns>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <feature>http://tizen.org/feature/battery</feature>
        /// <exception cref="NotSupportedException">Thrown when the statistics is not supported.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public static DateTime GetLastFullyChargedTime()
        {
            Int64 timestamp;
            int error = Interop.CtxHistory.GetLastFullyChargedTime(out timestamp);
            if ((AppHistoryError)error != AppHistoryError.None)
            {
                Log.Error(AppHistoryErrorFactory.LogTag, "Failed to request get last fully charged time");
                throw AppHistoryErrorFactory.CheckAndThrowException((AppHistoryError)error, "Failed to request get last fully charged time");
            }

            return ConvertUnixTimestampToDateTime(timestamp);
        }

        internal override string ConvertSortOrderToString(int order)
        {
            switch ((SortOrderType)order)
            {
                case SortOrderType.ConsumptionMost:
                    return "stats/battery/history";
                default:
                    return null;
            }
        }

        private static BatteryStatisticsData ConvertOutputToStatsData(IntPtr cursor)
        {
            string appId;
            double consumption;

            Interop.CtxHistoryCursor.GetString(cursor, AppStatsAppId, out appId);
            Interop.CtxHistoryCursor.GetDouble(cursor, AppStatsConsumption, out consumption);

            return new BatteryStatisticsData(appId, consumption);
        }

        /// <summary>
        /// Gets the criteria of battery statistics sorted by.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The criteria of battery statistics sorted by.</value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public SortOrderType SortOrder { get; private set; }

        /// <summary>
        /// Sorts the order type of battery statistics.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum SortOrderType
        {
            /// <summary>
            /// Sorts the apps by consumption, the most battery consuming apps appear first (default).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Obsolete("Deprecated since API13, will be removed in API15.")]
            ConsumptionMost = 0
        }
    }
}
