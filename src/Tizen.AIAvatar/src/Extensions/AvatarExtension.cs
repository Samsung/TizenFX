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

using System.Collections.Generic;
using System.IO;
using System.ComponentModel;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class AvatarExtension
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<AvatarInfo> GetDefaultAvatarList()
        {
            var list = new List<AvatarInfo>();
            var avatarModelFolders = Directory.GetDirectories(ApplicationResourcePath + EmojiAvatarResourcePath);
            foreach (var directoryInfo in avatarModelFolders)
            {
                Log.Info(LogTag, $"Directory Path : {directoryInfo}");
                var avatarInfo = new AvatarInfo(directoryInfo);
                list.Add(avatarInfo);
            }

            return list;
        }
    }
}
