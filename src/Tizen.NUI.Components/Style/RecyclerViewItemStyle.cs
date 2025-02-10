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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = null;
        internal static void SetInternalIsSelectableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var RecyclerViewItemStyle = (RecyclerViewItemStyle)bindable;
            RecyclerViewItemStyle.isSelectable = (bool?)newValue;
        }
        internal static object GetInternalIsSelectableProperty(BindableObject bindable)
        {
            var RecyclerViewItemStyle = (RecyclerViewItemStyle)bindable;
            return RecyclerViewItemStyle.isSelectable;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = null;
        internal static void SetInternalIsSelectedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var RecyclerViewItemStyle = (RecyclerViewItemStyle)bindable;
            RecyclerViewItemStyle.isSelected = (bool?)newValue;
        }
        internal static object GetInternalIsSelectedProperty(BindableObject bindable)
        {
            var RecyclerViewItemStyle = (RecyclerViewItemStyle)bindable;
            return RecyclerViewItemStyle.isSelected;
        }

        private bool? isSelectable;
        private bool? isSelected;

        static RecyclerViewItemStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool?), typeof(RecyclerViewItemStyle), null,
                    propertyChanged: SetInternalIsSelectableProperty, defaultValueCreator: GetInternalIsSelectableProperty);
                IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool?), typeof(RecyclerViewItemStyle), null,
                    propertyChanged: SetInternalIsSelectedProperty, defaultValueCreator: GetInternalIsSelectedProperty);
            }
        }

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
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(IsSelectableProperty);
                }
                else
                {
                    return (bool?)GetInternalIsSelectableProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsSelectableProperty, value);
                }
                else
                {
                    SetInternalIsSelectableProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Flag to decide selected state in RecyclerViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelected
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(IsSelectedProperty);
                }
                else
                {
                    return (bool?)GetInternalIsSelectedProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsSelectedProperty, value);
                }
                else
                {
                    SetInternalIsSelectedProperty(this, null, value);
                }
            }
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
