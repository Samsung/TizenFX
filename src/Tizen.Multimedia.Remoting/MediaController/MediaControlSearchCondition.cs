/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Applications;
using NativeClient = Interop.MediaControllerClient;
using NativeServer = Interop.MediaControllerServer;
using NativePlaylist = Interop.MediaControllerPlaylist;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents the search conditions.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class MediaControlSearchCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlSearchCondition"/> class.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlSearchCondition(MediaControlContentType type, MediaControlSearchCategory category,
            string keyword, Bundle bundle)
            : this (type, keyword, bundle)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlSearchCategory), category, nameof(category));

            Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlSearchCondition"/> class.
        /// </summary>
        /// <remarks><see cref="MediaControlSearchCategory"/> will be set 'ALL'.</remarks>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlSearchCondition(MediaControlContentType type, string keyword, Bundle bundle)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlContentType), type, nameof(type));

            ContentType = type;
            Keyword = keyword ?? throw new ArgumentNullException("keyword is null.");
            Bundle = bundle ?? null;
        }

        /// <summary>
        /// Gets the search content type.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlContentType ContentType { get; }

        /// <summary>
        /// Gets the search category.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlSearchCategory Category { get; } = 0;

        /// <summary>
        /// Gets the search keyword.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Keyword { get; }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Bundle Bundle { get; }
    }
}