/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

using System;
using System.ComponentModel;
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbnailPath { get; private set; }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal string ResourcePath { get; private set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal AvatarInfoOption avatarInfoOption { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarInfo(string path, string Name, AvatarInfoOption info = AvatarInfoOption.Thumbnail)
        {
            this.Name = Name;
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

        internal AvatarInfo(string directoryPath)
        {
            string path = ApplicationResourcePath + EmojiAvatarResourcePath;
            Name = directoryPath.Substring(path.Length, directoryPath.Length - path.Length);
            ResourcePath = $"{directoryPath}/{AIAvatar.ExternalModel}";
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AvatarInfoOption
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Thumbnail = 0,
        [EditorBrowsable(EditorBrowsableState.Never)]
        Resource = 1,
    }
}
