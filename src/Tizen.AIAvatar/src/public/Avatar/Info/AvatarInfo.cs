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
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    public class AvatarInfo
    {
        public string Name { get; private set; }

        public string ThumbnailPath { get; private set; }

        internal string ResourcePath { get; private set; }
        internal AvatarInfoOption avatarInfoOption { get; private set; }

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

    public enum AvatarInfoOption
    {
        Thumbnail = 0,
        Resource = 1,
    }
}
