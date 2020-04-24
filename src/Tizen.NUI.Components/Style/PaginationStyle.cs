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
    /// PaginationStyle used to config the pagination represent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PaginationStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorImageURLProperty = BindableProperty.Create(nameof(IndicatorImageURL), typeof(Selector<string>), typeof(PaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (PaginationStyle)bindable;
            if (newValue != null)
            {
                instance.indicatorImageURL = (Selector<string>)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (PaginationStyle)bindable;
            return instance.indicatorImageURL;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSizeProperty = BindableProperty.Create(nameof(IndicatorSize), typeof(Size), typeof(PaginationStyle), new Size(0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (PaginationStyle)bindable;
            if (newValue != null)
            {
                instance.indicatorSize = (Size)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (PaginationStyle)bindable;
            return instance.indicatorSize;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSpacingProperty = BindableProperty.Create(nameof(IndicatorSpacing), typeof(int), typeof(PaginationStyle), (int)0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (PaginationStyle)bindable;
            if (newValue != null)
            {
                instance.indicatorSpacing = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (PaginationStyle)bindable;
            return instance.indicatorSpacing;
        });

        private Selector<string> indicatorImageURL;
        private Size indicatorSize;
        private int indicatorSpacing;

        static PaginationStyle() { }

        /// <summary>
        /// Creates a new instance of a PaginationStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PaginationStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a PaginationStyle using style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PaginationStyle(PaginationStyle style) : base(style)
        {
            if (null == style) return;

            this.CopyFrom(style);
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IndicatorSize
        {
            get
            {
                return (Size)GetValue(IndicatorSizeProperty);
            }
            set
            {
                SetValue(IndicatorSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the resource of indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> IndicatorImageURL
        {
            get
            {
                return (Selector<string>)GetValue(IndicatorImageURLProperty);
            }
            set
            {
                SetValue(IndicatorImageURLProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorSpacing
        {
            get
            {
                return (int)GetValue(IndicatorSpacingProperty);
            }
            set
            {
                SetValue(IndicatorSpacingProperty, value);
            } 
        }
    }
}
