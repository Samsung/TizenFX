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
    /// LottieButtonExtension is a ButtonExtension class that uses Lottie image for a Button icon.
    /// </summary>
    /// <remarks>
    /// You can make a custom LottieButton by overriding methods.
    /// </remarks>
    /// <example>
    /// <code>
    /// public class CustomLottieButton : LottieButtonExtension
    /// {
    ///     public CustomLottieButton(string url) : base(url)
    ///     {
    ///     }
    /// 
    ///     public override LottieFrameInfo? GetFrameInfoOnClick(bool isSelected)
    ///     {
    ///         return LottieFrameInfo.CreateAnimationRange(0, 30);
    ///     }
    /// }
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class LottieButtonExtension : ButtonExtension, ILottieButtonExtension
    {
        /// <summary>
        /// The Lottie view that will be used as an icon part in a Button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected LottieAnimationView LottieView { get; set; }

        /// <summary>
        /// A constructor that creates LottieButtonExtension with a specified Lottie resource URL
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieButtonExtension(string resourceURL) : base()
        {
            LottieView = new LottieAnimationView();
            LottieView.URL = resourceURL;
            LottieView.StopBehavior = LottieAnimationView.StopBehaviorType.MaximumFrame;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnCreateIcon(Button button, ref ImageView icon, ImageViewStyle style)
        {
            // Replace icon to the Lottie view
            icon = LottieView;
            style.WidthResizePolicy = ResizePolicyType.FillToParent;
            style.HeightResizePolicy = ResizePolicyType.FillToParent;
            GetFrameInfoOnCreate(button.IsSelected)?.Show(LottieView);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnControlStateChanged(Button.ButtonExposer buttonExposer, ControlStates previousState, ControlStates currentState, bool byUI, Touch touchInfo)
        {
            HandleStateChange(currentState, buttonExposer.Button.IsSelected, byUI, this, LottieView);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo? GetFrameInfoOnCreate(bool isSelected)
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo? GetFrameInfoOnClick(bool isSelected)
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo? GetFrameInfoOnDisable(bool isSelected)
        {
            return null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual LottieFrameInfo? GetFrameInfoOnPress(bool isSelected)
        {
            return null;
        }

        static internal void HandleStateChange(ControlStates state, bool isSelected, bool byUser, ILottieButtonExtension extension, LottieAnimationView lottieView)
        {
            switch (state)
            {
                case ControlStates.Normal:
                case ControlStates.Focused:
                case ControlStates.Selected:
                case ControlStates.SelectedFocused:
                    if (byUser)
                    {
                        extension.GetFrameInfoOnClick(isSelected)?.Show(lottieView);
                    }
                    else
                    {
                        extension.GetFrameInfoOnClick(isSelected)?.ShowEndFrame(lottieView);
                    }
                    break;

                case ControlStates.Disabled:
                case ControlStates.DisabledFocused:
                case ControlStates.DisabledSelected:
                    extension.GetFrameInfoOnDisable(isSelected)?.Show(lottieView);
                    break;

                case ControlStates.Pressed:
                    extension.GetFrameInfoOnPress(isSelected)?.Show(lottieView);
                    break;
            }
        }
    }
}
