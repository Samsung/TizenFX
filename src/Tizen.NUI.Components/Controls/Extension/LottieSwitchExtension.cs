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
    /// LottieSwitchExtension is a SwitchExtension class that uses Lottie image for a Switch icon.
    /// <remark>
    /// This extension must be used within a class implementing LottieSwitchStyle.
    /// </remark>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LottieSwitchExtension : SwitchExtension
    {
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool ProcessIcon(Button button, ref ImageView icon)
        {
            if (button.Style is ILottieButtonStyle lottieStyle)
            {
                var lottieView = LottieExtensionHelper.CreateLottieView(lottieStyle);
                var parent = icon.GetParent();

                icon.Unparent();
                icon.Dispose();
                icon = lottieView;
                parent?.Add(icon);

                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnControlStateChanged(Button button, View.ControlStateChangedEventArgs args)
        {
            if (button.Style is ILottieButtonStyle lottieStyle && button.Icon is LottieAnimationView lottieView)
            {
                LottieExtensionHelper.UpdateLottieView(lottieView, lottieStyle, args.PreviousState, button.ControlState);
            }
        }
    }
}
