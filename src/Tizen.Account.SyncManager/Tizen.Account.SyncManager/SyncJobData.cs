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

using Tizen.Applications;
using Tizen.Account.AccountManager;

namespace Tizen.Account.SyncManager
{
    /// <summary>
    /// This class represents information about the sync job request.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SyncJobData
    {
        /// <summary>
        /// Represents the calendar capability.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>
        /// If you want to receive notification about the calendar database change, assign it to the SyncJobName property of the SyncJobData object.
        /// </remarks>
        public const string CalendarCapability = "http://tizen.org/sync/capability/calendar";

        /// <summary>
        /// Represents the contact capability.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>
        /// If you want to receive notification about the contact database change, assign it to the SyncJobName property of the SyncJobData object.
        /// </remarks>
        public const string ContactCapability = "http://tizen.org/sync/capability/contact";

        /// <summary>
        /// Represents the image capability.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>
        /// If you want to receive notification about the image database change, assign it to the SyncJobName property of the SyncJobData object.
        /// </remarks>
        public const string ImageCapability = "http://tizen.org/sync/capability/image";

        /// <summary>
        /// Represents the video capability.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>
        /// If you want to receive notification about the video database change, assign it to the SyncJobName property of the SyncJobData object.
        /// </remarks>
        public const string VideoCapability = "http://tizen.org/sync/capability/video";

        /// <summary>
        /// Represents the sound capability.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>
        /// If you want to receive notification about the sound database change, assign it to the SyncJobName property of the SyncJobData object.
        /// </remarks>
        public const string SoundCapability = "http://tizen.org/sync/capability/sound";

        /// <summary>
        /// Represents the music capability.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <remarks>
        /// If you want to receive notification about the music database change, assign it to the SyncJobName property of the SyncJobData object.
        /// </remarks>
        public const string MusicCapability = "http://tizen.org/sync/capability/music";

        /// <summary>
        /// The account instance on which the sync operation was requested or @c null in the case of the accountless sync operation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public AccountManager.Account Account { get; set; }

        /// <summary>
        /// User data which contains an additional information related to the registered sync job.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Bundle UserData { get; set; }

        /// <summary>
        /// A string representing a sync job which has been operated or capability setting to operate the data change sync job.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string SyncJobName { get; set; }
    }
}

