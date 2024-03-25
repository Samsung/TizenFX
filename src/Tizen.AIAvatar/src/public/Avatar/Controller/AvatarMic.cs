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

using System.ComponentModel;

using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarMic
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarMic()
        {
        }

        /// <summary>
        /// Initialize Microphone for using live lip sync
        /// </summary>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InitAvatarMic(Avatar avatar)
        {
            if (AudioRecorder.Instance == null)
            {
                Log.Error(LogTag, $"Failed to initialize AudioRecorder");
                return false;
            }
            AudioRecorder.Instance?.InitMic(avatar?.AvatarAnimator);

            return true;
        }

        /// <summary>
        /// Deinitialize Microphone
        /// </summary>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeinitAvatarMIC()
        {
            AudioRecorder.Instance?.DeinitMic();

            return true;
        }

        /// <summary>
        /// Start synchronization avatar lip based on the microphone's voice
        /// </summary>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartMic()
        {
            AudioRecorder.Instance?.StartRecording();
        }

        /// <summary>
        /// Stop microphone
        /// </summary>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopMic()
        {
            AudioRecorder.Instance?.StopRecording();
        }
    }
}
