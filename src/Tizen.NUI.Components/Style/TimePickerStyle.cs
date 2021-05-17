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
    /// TimePickerStyle is a class which saves TimePickerStyle's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TimePickerStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a TimePickerStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePickerStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a TimePickerStyle with style.
        /// </summary>
        /// <param name="style">Creates TimePickerStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimePickerStyle(TimePickerStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the TimePickerStyle internal pickers style.
        /// </summary>
        public PickerStyle Pickers { get; set;} = new PickerStyle();

        /// <summary>
        /// Gets or sets the TimePickerStyle internal pickers padding.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D CellPadding { get; set; } = new Size2D();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is TimePickerStyle timePickerStyle)
            {
                Pickers.CopyFrom(timePickerStyle.Pickers);
                CellPadding = (timePickerStyle.CellPadding == null) ?
                               new Size2D() : new Size2D(timePickerStyle.CellPadding.Width, timePickerStyle.CellPadding.Height);
            }
        }
    }
}
