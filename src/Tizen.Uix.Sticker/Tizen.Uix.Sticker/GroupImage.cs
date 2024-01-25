/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Uix.Sticker
{
    /// <summary>
    /// This structure represents an image of sticker group.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public struct GroupImage
    {
        /// <summary>
        /// The public constructor.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="groupName">The group name for setting group image.</param>
        /// <param name="uriType">The URI type of the image file.</param>
        /// <param name="uri">The URI of the image file.</param>
        public GroupImage(string groupName, UriType uriType, string uri)
        {
            GroupName = groupName;
            UriType = uriType;
            Uri = uri;
        }

        /// <summary>
        /// The name of the group.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string GroupName { get; }

        /// <summary>
        /// The URI type of the image file.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public UriType UriType { get; }

        /// <summary>
        /// The URI of the image file.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string Uri { get; }

        /// <summary>
        /// Compares an object to an instance of <see cref="GroupImage"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the two group images are equal; otherwise, false.</returns>
        /// /// <since_tizen> 10 </since_tizen>
        public override bool Equals(object obj)
        {
            return obj is GroupImage && this == (GroupImage)obj;
        }

        /// <summary>
        /// Gets the hash code for this instance of <see cref="GroupImage"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="GroupImage"/>.</returns>
        /// <since_tizen> 10 </since_tizen>
        public override int GetHashCode()
        {
            return new { GroupName, UriType, Uri }.GetHashCode();
        }

        /// <summary>
        /// Compares two instances of <see cref="GroupImage"/> for equality.
        /// </summary>
        /// <param name="groupImage1">A <see cref="GroupImage"/> to compare.</param>
        /// <param name="groupImage2">A <see cref="GroupImage"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="GroupImage"/> are equal; otherwise false.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static bool operator ==(GroupImage groupImage1, GroupImage groupImage2)
        {
            return groupImage1.GroupName == groupImage2.GroupName && groupImage1.UriType == groupImage2.UriType && groupImage1.Uri == groupImage2.Uri;
        }

        /// <summary>
        /// Compares two instances of <see cref="GroupImage"/> for inequality.
        /// </summary>
        /// <param name="groupImage1">A <see cref="GroupImage"/> to compare.</param>
        /// <param name="groupImage2">A <see cref="GroupImage"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="GroupImage"/> are not equal; otherwise false.</returns>
        /// <since_tizen> 10 </since_tizen>
        public static bool operator !=(GroupImage groupImage1, GroupImage groupImage2)
        {
            return !(groupImage1 == groupImage2);
        }
    }
}
