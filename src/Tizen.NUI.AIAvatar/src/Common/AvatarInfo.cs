/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// The AvatarInfo class describes the properties of an Avatar object.
    /// It includes information such as the name of the avatar, its thumbnail image, and associated resources.
    /// This class helps users manage and organize their Avatar assets more effectively.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarInfo
    {
        /// <summary>
        /// The Name property gets the name of the Avatar.
        /// This value is read-only and cannot be modified directly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; private set; }

        /// <summary>
        /// The ThumbnailPath property gets the path to the thumbnail image representing the Avatar.
        /// This value is read-only and cannot be modified directly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbnailPath { get; private set; }

        /// <summary>
        /// The ResourcePath property gets the path to the resource files associated with the Avatar.
        /// This value is intended for internal use only and should not be accessed by users directly.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal string ResourcePath { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AvatarInfoOption avatarInfoOption { get; private set; }

        /// <summary>
        /// Initializes a new instance of the AvatarInfo class with the specified file path, name, and option.
        /// If no option is provided, the default is AvatarInfoOption.Thumbnail.
        /// </summary>
        /// <param name="name">The name of the Avatar.</param>
        /// <param name="path">The full path to the Avatar file.</param>
        /// <param name="info">The option specifying what type of information should be loaded from the file (thumbnail or resource).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarInfo(string name, string path, AvatarInfoOption info = AvatarInfoOption.Thumbnail)
        {
            this.Name = name;
            this.avatarInfoOption = info;

            if (info == AvatarInfoOption.Thumbnail)
            {
                ThumbnailPath = path;
            }
            else
            {
                ResourcePath = path;
            }
        }

        internal AvatarInfo(string avatarPath)
        {
            Name = global::System.IO.Path.GetFileNameWithoutExtension(avatarPath);
            ResourcePath = avatarPath;
        }
    }

    /// <summary>
    /// The AvatarInfoOption enumeration defines the options that determine how AvatarInfo instances are displayed or managed.
    /// Currently it has two values: Thumbnail and Resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AvatarInfoOption
    {

        /// <summary>
        /// Thumbnail indicates that the AvatarInfo instance should display or manipulate the thumbnail image of the Avatar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Thumbnail = 0,
        /// <summary>
        /// Resource indicates that the AvatarInfo instance should display or manipulate the resource files associated with the Avatar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Resource = 1,
    }
}
