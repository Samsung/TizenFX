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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// PaginationStyle used to config the pagination represent.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class PaginationStyle : ControlStyle
    {
        /// <summary>The IndicatorSize bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSizeProperty = BindableProperty.Create(nameof(IndicatorSize), typeof(Size), typeof(PaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((PaginationStyle)bindable).indicatorSize = newValue == null ? null : new Size((Size)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((PaginationStyle)bindable).indicatorSize;
        });

        /// <summary>The IndicatorImageUrlSelector bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorImageUrlSelectorProperty = BindableProperty.Create("IndicatorImageUrl", typeof(Selector<string>), typeof(PaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((PaginationStyle)bindable).indicatorImageUrl = (Selector<string>)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((PaginationStyle)bindable).indicatorImageUrl;
        });

        /// <summary>The IndicatorSpacing bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSpacingProperty = BindableProperty.Create(nameof(IndicatorSpacing), typeof(int?), typeof(PaginationStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((PaginationStyle)bindable).indicatorSpacing = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((PaginationStyle)bindable).indicatorSpacing;
        });

        private Size indicatorSize;
        private Selector<string> indicatorImageUrl;
        private int? indicatorSpacing;

        static PaginationStyle() { }

        /// <summary>
        /// Creates a new instance of a PaginationStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public PaginationStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a PaginationStyle using style.
        /// </summary>
        /// <param name="style">Create PaginationStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public PaginationStyle(PaginationStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Size IndicatorSize
        {
            get => (Size)GetValue(IndicatorSizeProperty);
            set => SetValue(IndicatorSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<string> IndicatorImageUrl
        {
            get => (Selector<string>)GetValue(IndicatorImageUrlSelectorProperty);
            set => SetValue(IndicatorImageUrlSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int IndicatorSpacing
        {
            get => ((int?)GetValue(IndicatorSpacingProperty)) ?? 0;
            set => SetValue(IndicatorSpacingProperty, value);
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
        }
    }
}
