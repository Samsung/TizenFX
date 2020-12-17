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
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// CircularPaginationStyle used to config the circularPagination represent.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularPaginationStyle : ControlStyle
    {
        /// <summary>The IndicatorSize bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSizeProperty = BindableProperty.Create(nameof(IndicatorSize), typeof(Size), typeof(CircularPaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularPaginationStyle)bindable).indicatorSize = newValue == null ? null : new Size((Size)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularPaginationStyle)bindable).indicatorSize;
        });

        /// <summary>The IndicatorImageUrlSelector bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorImageUrlSelectorProperty = BindableProperty.Create("IndicatorImageUrlSelector", typeof(Selector<string>), typeof(CircularPaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularPaginationStyle)bindable).indicatorImageUrl = ((Selector<string>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularPaginationStyle)bindable).indicatorImageUrl;
        });

        /// <summary>The CenterIndicatorImageUrlSelector bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CenterIndicatorImageUrlSelectorProperty = BindableProperty.Create("CenterIndicatorImageUrlSelector", typeof(Selector<string>), typeof(CircularPaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularPaginationStyle)bindable).centerIndicatorImageUrl = ((Selector<string>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularPaginationStyle)bindable).centerIndicatorImageUrl;
        });

        private Size indicatorSize;
        private Selector<string> indicatorImageUrl;
        private Selector<string> centerIndicatorImageUrl;

        static CircularPaginationStyle() { }

        /// <summary>
        /// Creates a new instance of a CircularPaginationStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularPaginationStyle() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a CircularPaginationStyle using style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularPaginationStyle(CircularPaginationStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IndicatorSize
        {
            get => (Size)GetValue(IndicatorSizeProperty);
            set => SetValue(IndicatorSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> IndicatorImageURL
        {
            get => (Selector<string>)GetValue(IndicatorImageUrlSelectorProperty);
            set => SetValue(IndicatorImageUrlSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the resource of the center indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> CenterIndicatorImageURL
        {
            get => (Selector<string>)GetValue(CenterIndicatorImageUrlSelectorProperty);
            set => SetValue(CenterIndicatorImageUrlSelectorProperty, value);
        }

        private void Initialize()
        {
            IndicatorSize = new Size(10, 10);
            IndicatorImageURL = new Selector<string>()
            {
                Normal = Tizen.NUI.FrameworkInformation.ResourcePath + "nui_component_default_pagination_normal_dot.png",
                Selected = Tizen.NUI.FrameworkInformation.ResourcePath + "nui_component_default_pagination_focus_dot.png",
            };
            CenterIndicatorImageURL = new Selector<string>()
            {
                Normal = Tizen.NUI.FrameworkInformation.ResourcePath + "nui_wearable_circular_pagination_center_normal_dot.png",
                Selected = Tizen.NUI.FrameworkInformation.ResourcePath + "nui_wearable_circular_pagination_center_focus_dot.png",
            };
        }
    }
}
