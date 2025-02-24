/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// RecyclerViewItemStyle is a class which saves RecyclerViewItem's UX data.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class RecyclerViewItemStyle : ControlStyle
    {
        static readonly IStyleProperty IsSelectableProperty = new StyleProperty<RecyclerViewItem, bool>((v, o) => v.IsSelectable = o);
        static readonly IStyleProperty IsSelectedProperty = new StyleProperty<RecyclerViewItem, bool>((v, o) => v.IsSelected = o);

        static RecyclerViewItemStyle() { }

        /// <summary>
        /// Creates a new instance of a RecyclerViewItemStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecyclerViewItemStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a RecyclerViewItemStyle with style.
        /// </summary>
        /// <param name="style">Create RecyclerViewItemStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecyclerViewItemStyle(RecyclerViewItemStyle style) : base(style)
        {
        }

        /// <summary>
        /// Flag to decide RecyclerViewItem can be selected or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelectable
        {
            get => (bool?)GetValue(IsSelectableProperty);
            set => SetValue(IsSelectableProperty, value);
        }

        /// <summary>
        /// Flag to decide selected state in RecyclerViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelected
        {
            get => (bool?)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            /*
            if (bindableObject is RecyclerViewItemStyle RecyclerViewItemStyle)
            {
                //
            }
            */
        }
    }
}
