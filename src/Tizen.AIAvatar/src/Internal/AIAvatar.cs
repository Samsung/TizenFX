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

using Tizen.Multimedia;

namespace Tizen.AIAvatar
{
    internal static class AIAvatar
    {
        internal const string LogTag = "Tizen.AIAvatar";
        internal static readonly string ApplicationResourcePath = "/usr/apps/org.tizen.default-avatar-resource/shared/res/";
        internal static readonly string EmojiAvatarResourcePath = "/models/EmojiAvatar/";
        internal static readonly string DefaultModelResourcePath = "/models/DefaultAvatar/";
        internal static readonly string DefaultMotionResourcePath = "/animation/motion/";

        internal static readonly string VisemeInfo = $"{ApplicationResourcePath}/viseme/emoji_viseme_info.json";
        internal static readonly string DefaultModel = "DefaultAvatar.gltf";

        internal static readonly string AREmojiDefaultAvatarPath = $"{ApplicationResourcePath}{DefaultModelResourcePath}{DefaultModel}";

        internal static readonly string DefaultLowModelResourcePath = "/models/DefaultAvatar_Low/";
        internal static readonly string ExternalModel = "model_external.gltf";
        internal static readonly string AREmojiDefaultLowAvatarPath = $"{ApplicationResourcePath}{DefaultLowModelResourcePath}{ExternalModel}";

        internal static AudioOptions DefaultAudioOptions = new AudioOptions(24000, AudioChannel.Mono, AudioSampleType.S16Le);
        internal static AudioOptions CurrentAudioOptions = DefaultAudioOptions;
    }
}
