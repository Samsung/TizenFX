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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ILottieExtension provides interfaces that will be needed by a Button to play Lottie animation when state changed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ILottieButtonExtension
    {
        /// <summary>
        /// Give a Lottie frame information on Button created.
        /// </summary>
        /// <return>The information of the Lottie frames</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LottieFrameInfo? GetFrameInfoOnCreate(bool isSelected);

        /// <summary>
        /// Give a Lottie frame information on Button disabled.
        /// </summary>
        /// <return>The information of the Lottie frames</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LottieFrameInfo? GetFrameInfoOnDisable(bool isSelected);

        /// <summary>
        /// Give a Lottie frame information on Button pressed.
        /// </summary>
        /// <return>The information of the Lottie frames</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LottieFrameInfo? GetFrameInfoOnPress(bool isSelected);

        /// <summary>
        /// Give a Lottie frame information on Button clicked.
        /// </summary>
        /// <return>The information of the Lottie frames</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LottieFrameInfo? GetFrameInfoOnClick(bool isSelected);
    }
}
