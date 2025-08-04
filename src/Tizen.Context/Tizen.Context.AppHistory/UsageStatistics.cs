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
    /// This class provides APIs to query the application launch history.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class UsageStatistics : AppStatistics
    {
        private const string AppStatsDuration = "TotalDuration";
        private const string AppStatsLaunchCount = "TotalCount";
        private const string AppStatsLastLaunchTime = "LastTime";

        /// <summary>
        /// The default constructor of UsageStatistics class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an internal error.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public UsageStatistics()
        {
            SortOrder = SortOrderType.LastLaunchTimeNewest;
            Uri = ConvertSortOrderToString((int)SortOrder);

            bool isSupported = false;
            int error = Interop.CtxHistory.IsSupported(Uri, out isSupported);
            if ((AppHistoryError)error != AppHistoryError.None)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException((AppHistoryError)error, Uri);
            }

            if (!isSupported)
            {
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.OperationFailed, Uri);
            }
        }

        /// <summary>
        /// The constructor of UsageStatistics class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="order">The criteria of the usage statistics sorted by.</param>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an internal error.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public UsageStatistics(SortOrderType order)
        {
            SortOrder = order;
            Uri = ConvertSortOrderToString((int)SortOrder);

            if (Uri== null)
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
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.OperationFailed, Uri);
            }
        }

        /// <summary>
        /// Retrieves a given type of usage statistics.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="startTime">The start time of the data to be aggregated.</param>
        /// <param name="endTime">The end time of the data to be aggregated.</param>
        /// <returns>Usage statistics data retrieved.</returns>
        /// <privilege>http://tizen.org/privilege/apphistory.read</privilege>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an invalid operation occurs.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to retrieve the application history.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public IReadOnlyList<UsageStatisticsData> Query(DateTime startTime, DateTime endTime)
        {
            CheckTimeSpan(startTime, endTime);

            return Query(startTime, endTime, DefaultResultSize);
        }

        /// <summary>
        /// Retrieves a given type of usage statistics.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="startTime">The start time of the data to be aggregated.</param>
        /// <param name="endTime">The end time of the data to be aggregated.</param>
        /// <param name="resultSize">The number of data records to be retrieved.</param>
        /// <returns>Usage statistics data retrieved.</returns>
        /// <privilege>http://tizen.org/privilege/apphistory.read</privilege>
        /// <feature>http://tizen.org/feature/app_history</feature>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an invalid operation occurs.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application has no privilege to retrieve the application history.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public IReadOnlyList<UsageStatisticsData> Query(DateTime startTime, DateTime endTime, uint resultSize)
        {
            CheckTimeSpan(startTime, endTime);
            CheckResultSize(resultSize);

            List<UsageStatisticsData> result = new List<UsageStatisticsData>();

            IntPtr cursor = IntPtr.Zero;
            int error = Interop.CtxHistory.Query(Uri, ConvertDateTimeToUnixTimestamp(startTime), ConvertDateTimeToUnixTimestamp(endTime), resultSize, out cursor);
            if ((AppHistoryError)error == AppHistoryError.NoData)
            {
                return result.AsReadOnly();
            } else if ((AppHistoryError)error != AppHistoryError.None)
            {
                Log.Error(AppHistoryErrorFactory.LogTag, "Failed to request query usage statistics");
                throw AppHistoryErrorFactory.CheckAndThrowException((AppHistoryError)error, "Failed to request query usage statistics");
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

        internal override string ConvertSortOrderToString(int order)
        {
            switch ((SortOrderType)order)
            {
                case SortOrderType.LastLaunchTimeNewest:
                    return "stats/app/recently";
                case SortOrderType.LaunchCountMost:
                    return "stats/app/often";
                default:
                    return null;
            }
        }

        private static UsageStatisticsData ConvertOutputToStatsData(IntPtr cursor)
        {
            string appId;
            Int64 duration = 1;
            Int64 launchCount = 1;
            Int64 lastLaunchTime;

            Interop.CtxHistoryCursor.GetString(cursor, AppStatsAppId, out appId);
            Interop.CtxHistoryCursor.GetInt64(cursor, AppStatsDuration, out duration);
            Interop.CtxHistoryCursor.GetInt64(cursor, AppStatsLaunchCount, out launchCount);
            Interop.CtxHistoryCursor.GetInt64(cursor, AppStatsLastLaunchTime, out lastLaunchTime);

            return new UsageStatisticsData(appId, (int)duration, (int)launchCount, ConvertUnixTimestampToDateTime(lastLaunchTime));
        }

        /// <summary>
        /// Gets the criteria of usage statistics sorted by.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>The criteria of usage statistics sorted by.</value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public SortOrderType SortOrder { get; private set; }

        /// <summary>
        /// Sorts the order type of usage statistics.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum SortOrderType
        {
            /// <summary>
            /// Sorts the apps by the last launch time, the most recently launched apps appear first (default).
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Obsolete("Deprecated since API13, will be removed in API15.")]
            LastLaunchTimeNewest = 0,
            /// <summary>
            /// Sorts the apps by the launch count of being launched, the most frequently launched apps appear first.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            [Obsolete("Deprecated since API13, will be removed in API15.")]
            LaunchCountMost
        }
    }
}
