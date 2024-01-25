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
    /// DatePickerStyle is a class which saves DatePickerStyle's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DatePickerStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a DatePickerStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatePickerStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a DatePickerStyle with style.
        /// </summary>
        /// <param name="style">Creates DatePickerStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DatePickerStyle(DatePickerStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the DatePickerStyle internal pickers style.
        /// </summary>
        public PickerStyle Pickers { get; set;} = new PickerStyle();

        /// <summary>
        /// Gets or sets the DatePickerStyle internal pickers padding.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D CellPadding { get; set; } = new Size2D();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is DatePickerStyle DatePickerStyle)
            {
                Pickers.CopyFrom(DatePickerStyle.Pickers);
                CellPadding = (DatePickerStyle.CellPadding == null) ?
                               new Size2D() : new Size2D(DatePickerStyle.CellPadding.Width, DatePickerStyle.CellPadding.Height);
            }
        }
    }
}
