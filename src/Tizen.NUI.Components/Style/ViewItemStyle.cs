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
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ViewItemStyle is a class which saves ViewItem's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ViewItemStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool?), typeof(ViewItemStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewItemStyle = (ViewItemStyle)bindable;
            viewItemStyle.isSelectable = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewItemStyle = (ViewItemStyle)bindable;
            return viewItemStyle.isSelectable;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool?), typeof(ViewItemStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewItemStyle = (ViewItemStyle)bindable;
            viewItemStyle.isSelected = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewItemStyle = (ViewItemStyle)bindable;
            return viewItemStyle.isSelected;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool?), typeof(ViewItemStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewItemStyle = (ViewItemStyle)bindable;
            viewItemStyle.isEnabled = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewItemStyle = (ViewItemStyle)bindable;
            return viewItemStyle.isEnabled;
        });

        private bool? isSelectable;
        private bool? isSelected;
        private bool? isEnabled;

        static ViewItemStyle() { }

        /// <summary>
        /// Creates a new instance of a ViewItemStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ViewItemStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a ViewItemStyle with style.
        /// </summary>
        /// <param name="style">Create ViewItemStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewItemStyle(ViewItemStyle style) : base(style)
        {
        }

        /// <summary>
        /// Flag to decide ViewItem can be selected or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelectable
        {
            get => (bool?)GetValue(IsSelectableProperty);
            set => SetValue(IsSelectableProperty, value);
        }

        /// <summary>
        /// Flag to decide selected state in ViewItem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSelected
        {
            get => (bool?)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        /// <summary>
        /// Flag to decide viewItem can be selected or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get => (bool?)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
        }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is ViewItemStyle viewItemStyle)
            {
                //
            }
        }
    }
}
