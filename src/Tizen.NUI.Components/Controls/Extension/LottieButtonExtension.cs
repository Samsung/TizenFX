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
using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Extension
{
    /// <summary>
    /// LottieButtonExtension is a ButtonExtension class that uses Lottie image for a Button icon.
    /// <remark>
    /// This extension must be used within a class implementing LottieButtonStyle.
    /// </remark>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LottieButtonExtension : ButtonExtension
    {
        /// <summary>
        /// A constructor that creates LottieButtonExtension with a specified Lottie resource URL
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieButtonExtension() : base()
        {
            LottieView = new LottieAnimationView();
        }

        /// <summary>
        /// The Lottie view that will be used as an icon part in a Button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected LottieAnimationView LottieView { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageView OnCreateIcon(Button button, ImageView icon)
        {
            InitializeLottieView(button, LottieView);

            return LottieView;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnControlStateChanged(Button button, ControlStates previousState, Touch touchInfo)
        {
            UpdateLottieView(button, previousState, touchInfo, LottieView);
        }

        internal static void InitializeLottieView(Button button, LottieAnimationView lottieView)
        {
            if (button.Style as ILottieButtonStyle == null)
            {
                throw new Exception("LottieButtonExtension must be used within a ILottieButtonStyle or derived class.");
            }

            var lottieStyle = (ILottieButtonStyle)button.Style;
            lottieView.URL = lottieStyle.LottieUrl;
            lottieView.StopBehavior = LottieAnimationView.StopBehaviorType.MaximumFrame;
            lottieStyle.LottieFrameInfo.OnCreate?.Show(lottieView, true);
        }

        internal static void UpdateLottieView(Button button, ControlStates previousState, Touch touchInfo, LottieAnimationView lottieView)
        {
            var lottieStyle = (ILottieButtonStyle)button.Style;

            switch (button.ControlState)
            {
                case ControlStates.Normal:
                    lottieStyle.LottieFrameInfo?.OnUnselect?.Show(lottieView, previousState == ControlStates.Disabled);
                    break;

                case ControlStates.Focused:
                    lottieStyle.LottieFrameInfo?.OnUnselect?.Show(lottieView, previousState == ControlStates.DisabledFocused);
                    break;

                case ControlStates.Selected:
                case ControlStates.SelectedFocused:
                    lottieStyle.LottieFrameInfo?.OnSelect?.Show(lottieView);
                    break;

                case ControlStates.Disabled:
                case ControlStates.DisabledFocused:
                    lottieStyle.LottieFrameInfo?.OnDisable?.Show(lottieView);
                    break;

                case ControlStates.DisabledSelected:
                    lottieStyle.LottieFrameInfo?.OnDisableSelected?.Show(lottieView);
                    break;

                case ControlStates.Pressed:
                    if (button.IsSelected)
                    {
                        lottieStyle.LottieFrameInfo?.OnPressSelected?.Show(lottieView);
                    }
                    else
                    {
                        lottieStyle.LottieFrameInfo?.OnPress?.Show(lottieView);
                    }
                    break;
            }
        }
    }
}
