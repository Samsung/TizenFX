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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Extension
{
    /// <summary>
    /// LottieButtonStyle implements ILottieButtonStyle interface to support extended ButtonStyle using Lottie.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LottieButtonStyle : ButtonStyle, ILottieButtonStyle
    {
        static LottieButtonStyle()
        {
        }

        /// <summary>
        /// Create new instance of a LottieButtonStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieButtonStyle() : base()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieButtonStyle(LottieButtonStyle style) : base(style)
        {
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LottieUrl { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<LottieFrameInfo> PlayRange { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is LottieButtonStyle lottieButtonStyle)
            {
                LottieUrl = lottieButtonStyle.LottieUrl;
                PlayRange = lottieButtonStyle.PlayRange?.Clone();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ButtonExtension CreateExtension()
        {
            return new LottieButtonExtension();
        }
    }
}
