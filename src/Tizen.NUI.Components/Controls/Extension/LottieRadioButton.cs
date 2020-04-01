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
    /// LottieRadioButton is a RadioButton class that uses Lottie image for a RadioButton icon.
    /// </summary>
    /// <remarks>
    /// You can make a custom LottieRadioButton by overriding methods.
    /// </remarks>
    /// <example>
    /// <code>
    /// public class CustomLottieRadioButton : LottieRadioButton
    /// {
    ///     public CustomLottieRadioButton(string url) : base(url)
    ///     {
    ///     }
    /// 
    ///     public override LottieFrameInfo GetFrameInfoOnClick()
    ///     {
    ///         return LottieFrameInfo.CreateAnimationRange(0, 30);
    ///     }
    /// }
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class LottieRadioButton : RadioButton, ILottieButton
    {
        /// <summary>
        /// Create LottieRadioButton with a specified Lottie resource URL
        /// </summary>
        /// <param name="resourceURL">The resource URL of a Lottie content.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieRadioButton(string resourceURL) : base()
        {
            Initialize(resourceURL);
        }

        /// <summary>
        /// Create LottieRadioButton with a specified Lottie resource URL
        /// </summary>
        /// <param name="buttonStyle">The style to apply to the initial RadioButton.</param>
        /// <param name="resourceURL">The resource URL of a Lottie content.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieRadioButton(ButtonStyle buttonStyle, string resourceURL) : base(buttonStyle)
        {
            Initialize(resourceURL);
        }

        /// <summary>
        /// LottieView used by a Button as an icon
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected LottieAnimationView LottieView => (ButtonIcon as LottieAnimationView);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo GetFrameInfoOnCreate()
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo GetFrameInfoOnClick()
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo GetFrameInfoOnDisable()
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo GetFrameInfoOnPress()
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ImageView CreateIcon(ImageViewStyle style)
        {
            return new LottieAnimationView();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool OnControlStateChanged(ControlStates previousState, Touch touchInfo)
        {
            return LottieButton.OnButtonControlStateChanged(this, LottieView, previousState, ControlState, touchInfo, Initializing);
        }

        private void Initialize(string resourceURL)
        {
            LottieView.URL = resourceURL;
            LottieView.StopBehavior = LottieAnimationView.StopBehaviorType.MaximumFrame;
            GetFrameInfoOnCreate()?.Show(LottieView);
        }
    }
}
