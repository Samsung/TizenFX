/*
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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// PopupStyle is a class which saves Popup's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PopupStyle : ControlStyle
    {
        static PopupStyle() { }

        /// <summary>
        /// Creates a new instance of a PopupStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PopupStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a PopupStyle with style.
        /// </summary>
        /// <param name="style">Create PopupStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PopupStyle(PopupStyle style) : base(style)
        {
        }

        /// <summary>
        /// Title Text's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Title { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Popup button's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonStyle Buttons { get; set; } = new ButtonStyle();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is PopupStyle popupStyle)
            {
                Title.CopyFrom(popupStyle.Title);
                Buttons.CopyFrom(popupStyle.Buttons);
            }
        }
    }
}
