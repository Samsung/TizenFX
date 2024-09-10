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

namespace Tizen.AIAvatar
{
    internal class Test
    {
        public void CreateTest()
        {
            var avatar1 = new Avatar();

            var avatarInfo = new AvatarInfo("avatarName", "resourcePath");
            var avatar2 = new Avatar(avatarInfo);

            var avatar3 = new Avatar("resourcePath");

            var avatar4 = new Avatar(avatar1);

            avatar1.Dispose();
            avatar2.Dispose();
            avatar3.Dispose();
            avatar4.Dispose();
        }
    }
}
