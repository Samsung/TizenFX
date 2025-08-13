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

namespace Tizen.Context.AppHistory
{
    /// <summary>
    /// The Base class for application statistics.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public abstract class AppStatistics
    {
        internal const string AppStatsQueryResult = "QueryResult";
        internal const string AppStatsStartTime = "StartTime";
        internal const string AppStatsEndTime = "EndTime";
        internal const string AppStatsResultSize = "ResultSize";
        internal const string AppStatsAppId = "AppId";
        internal const int DefaultResultSize = 10;

        internal string Uri;

        internal AppStatistics()
        {
        }

        internal static long ConvertDateTimeToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return unixTimestampInTicks / TimeSpan.TicksPerSecond;
        }

        internal static DateTime ConvertUnixTimestampToDateTime(long unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = unixTime * TimeSpan.TicksPerSecond;
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc).ToLocalTime();
        }

        internal static void CheckTimeSpan(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                Log.Error(AppHistoryErrorFactory.LogTag, "endTime should be greater than startTime");
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.InvalidParameter, "endTime should be greater than startTime");
            }
        }

        internal static void CheckResultSize(uint resultSize)
        {
            if (resultSize <= 0)
            {
                Log.Error(AppHistoryErrorFactory.LogTag, "resultSize should be greater than 0");
                throw AppHistoryErrorFactory.CheckAndThrowException(AppHistoryError.InvalidParameter, "resultSize should be greater than 0");
            }
        }

        internal abstract string ConvertSortOrderToString(int order);
    }
}
