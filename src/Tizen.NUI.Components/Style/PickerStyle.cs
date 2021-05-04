/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    /// PickerStyle is a class which saves PickerStyle's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PickerStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a PickerStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PickerStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a PickerStyle with style.
        /// </summary>
        /// <param name="style">Creates PickerStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PickerStyle(PickerStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the PickerStyle Item TextLabel style.
        /// This style is applied if PickerStyle Item is a TextLabel.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle ItemTextLabel { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Gets or sets the PickerStyle Center line style.
        /// </summary>
        public ViewStyle Divider { get; set;} = new ViewStyle();
        
        /// <summary>
        /// Gets or sets the PickerStyle Item list start offset value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size StartScrollOffset { get; set; } = new Size();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is PickerStyle pickerStyle)
            {
                ItemTextLabel.CopyFrom(pickerStyle.ItemTextLabel);
                Divider.CopyFrom(pickerStyle.Divider);
                StartScrollOffset = (pickerStyle.StartScrollOffset == null) ?
                                    new Size() : new Size(pickerStyle.StartScrollOffset.Width, pickerStyle.StartScrollOffset.Height);
            }
        }
    }
}
