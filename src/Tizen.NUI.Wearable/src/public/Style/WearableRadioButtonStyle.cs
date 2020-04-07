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
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// A predefined style class for Wearable radio buttons.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WearableRadioButtonStyle : LottieButtonStyle
    {
        /// <summary>
        /// Creates a new class instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WearableRadioButtonStyle() : base()
        {
            LottieUrl = WearableStyle.GetResourcePath("nui_wearable_radiobutton_icon.json");
            LottieFrameInfo = new Button.ActionSelector<LottieFrameInfo>
            {
                OnSelect = (0, 12),
                OnUnselect = (13, 25)
            };
            Opacity = new Selector<float?>
            {
                Other = 1.0f,
                Pressed = 0.6f,
                Disabled = 0.3f,
            };
        }
    }
}
