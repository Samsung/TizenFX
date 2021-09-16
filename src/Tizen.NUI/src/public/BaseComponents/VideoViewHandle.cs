/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Contains and encapsulates Native Player handle.
    /// </summary>
    internal class SafeNativePlayerHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of SafeNativePlayerHandle referencing the given videoView.
        /// </summary>
        internal SafeNativePlayerHandle(VideoView videoView) : base(global::System.IntPtr.Zero, false)
        {
            if (videoView != null)
            {
                SetHandle(videoView.GetNativePlayerHandle());
            }
        }

        /// <summary>
        /// Null check if the handle is valid or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid
        {
            get
            {
                return handle == global::System.IntPtr.Zero;
            }
        }
        /// <summary>
        /// Release handle itself.
        /// </summary>
        /// <returns>true when released successfully.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool ReleaseHandle()
        {
            SetHandle(global::System.IntPtr.Zero);
            return true;
        }
    }
}
