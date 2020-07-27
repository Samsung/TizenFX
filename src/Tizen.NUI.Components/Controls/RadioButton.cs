﻿/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// RadioButton is the Class that describe the control which can be checked, but not cleared by a user.
    /// </summary>
    /// <code>
    /// RadioButton radio = new RadioButton("C_RadioButton_WhiteText");
    /// radio.Size = new Size(200, 64, 0);
    /// radio.Position = new Position(500, posY, 0);
    /// radio.Text = "RadioButton";
    /// radio.Focusable = true;
    /// </code>
    /// <since_tizen> 8 </since_tizen>
    public class RadioButton : SelectButton
    {
        static RadioButton() { }

        /// <summary>
        /// Creates a new instance of a RadioButton.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public RadioButton() : base() { }
        /// <summary>
        /// Creates a new instance of a RadioButton with style.
        /// </summary>
        /// <param name="style"></param>
        /// <since_tizen> 8 </since_tizen>
        public RadioButton(string style) : base(style) { }
        /// <summary>
        /// Creates a new instance of a RadioButton with style.
        /// </summary>
        /// <param name="buttonStyle"></param>
        /// <since_tizen> 8 </since_tizen>
        public RadioButton(ButtonStyle buttonStyle) : base(buttonStyle) { }

        /// <summary>
        /// Get RadioButtonGroup to which this selections belong.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RadioButtonGroup ItemGroup
        {
            get
            {
                return base.ItemGroup as RadioButtonGroup;
            }
            internal set
            {
                base.ItemGroup = value;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            if (viewStyle is ButtonStyle buttonStyle)
            {
                if (buttonStyle.IsSelectable == null)
                {
                    buttonStyle.IsSelectable = true;
                }

                base.ApplyStyle(buttonStyle);
            }
        }

        /// <summary>
        /// Set CheckState to true after selecting RadioButton.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnSelectedChanged()
        {
            if (!IsSelected)
            {
                IsSelected = true;
            }
        }
    }
}
