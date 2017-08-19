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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents a member of <see cref="Playlist"/>.
    /// </summary>
    public class PlaylistMember
    {
        /// <summary>
        /// Gets the member id.
        /// </summary>
        /// <value>The member id of playlist.</value>
        public int MemberId { get; }

        /// <summary>
        /// Gets the media info of the member.
        /// </summary>
        /// <value>The <see cref="MediaInfo"/> of the member.</value>
        public MediaInfo MediaInfo { get; }

        internal PlaylistMember(int memberId, MediaInfo mediaInfo)
        {
            MemberId = memberId;
            MediaInfo = mediaInfo;
        }
    }
}
