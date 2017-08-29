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
    /// Class represents information about a sync job request
    /// </summary>
    public class SyncJobData
    {
        /// <summary>
        /// Represents calendar capability
        /// </summary>
        /// <remarks>
        /// If you want to receive notification about calendar database change, assign it to SyncJobName property of SyncJobData object.
        /// </remarks>
        public const string CalendarCapability = "http://tizen.org/sync/capability/calendar";

        /// <summary>
        /// Represents contact capability
        /// </summary>
        /// <remarks>
        /// If you want to receive notification about contact database change, assign it to SyncJobName property of SyncJobData object.
        /// </remarks>
        public const string ContactCapability = "http://tizen.org/sync/capability/contact";

        /// <summary>
        /// Represents image capability
        /// </summary>
        /// <remarks>
        /// If you want to receive notification about image database change, assign it to SyncJobName property of SyncJobData object.
        /// </remarks>
        public const string ImageCapability = "http://tizen.org/sync/capability/image";

        /// <summary>
        /// Represents video capability
        /// </summary>
        /// <remarks>
        /// If you want to receive notification about video database change, assign it to SyncJobName property of SyncJobData object.
        /// </remarks>
        public const string VideoCapability = "http://tizen.org/sync/capability/video";

        /// <summary>
        /// Represents sound capability
        /// </summary>
        /// <remarks>
        /// If you want to receive notification about sound database change, assign it to SyncJobName property of SyncJobData object.
        /// </remarks>
        public const string SoundCapability = "http://tizen.org/sync/capability/sound";

        /// <summary>
        /// Represents music capability
        /// </summary>
        /// <remarks>
        /// If you want to receive notification about music database change, assign it to SyncJobName property of SyncJobData object.
        /// </remarks>
        public const string MusicCapability = "http://tizen.org/sync/capability/music";

        /// <summary>
        /// The account instance on which sync operation was requested or @c null in the case of accountless sync operation
        /// </summary>
        public AccountManager.Account Account { get; set; }

        /// <summary>
        /// User data which contains additional information related registered sync job
        /// </summary>
        public Bundle UserData { get; set; }

        /// <summary>
        /// A string representing a sync job which has been operated or capability setting to operate data change sync job
        /// </summary>
        public string SyncJobName { get; set; }
    }
}

