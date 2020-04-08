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
    /// LottieSwitchStyle implements ILottieButtonStyle interface to support extended ButtonStyle using Lottie.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LottieSwitchStyle : SwitchStyle, ILottieButtonStyle
    {
        static LottieSwitchStyle()
        {
        }

        /// <summary>
        /// Create new instance of a LottieButtonStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieSwitchStyle() : base()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieSwitchStyle(LottieSwitchStyle style) : base(style)
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

            LottieSwitchStyle style = bindableObject as LottieSwitchStyle;

            if (style == null)
            {
                return;
            }

            LottieUrl = style.LottieUrl;
            PlayRange = style.PlayRange;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ButtonExtension CreateExtension()
        {
            return new LottieSwitchExtension();
        }

        private void InitSubStyle()
        {
        }
    }
}
