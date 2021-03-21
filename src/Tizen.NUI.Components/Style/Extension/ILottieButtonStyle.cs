/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Extension
{
    /// <summary>
    /// Interface that provides style properties for Lottie playing in Button.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILottieButtonStyle
    {
        /// <summary>
        /// Get/Set Lottie resource url.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string LottieUrl { get; set; }

        /// <summary>
        /// Get/Set LottieFrameInfo for playing on various states of attached Button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Selector<LottieFrameInfo> PlayRange { get; set; }
    }
}
