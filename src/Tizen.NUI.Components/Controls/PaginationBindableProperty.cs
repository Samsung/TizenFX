/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
    public partial class Pagination
    {
        /// <summary>The IndicatorSize bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSizeProperty = null;
        internal static void SetInternalIndicatorSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var pagination = (Pagination)bindable;
                pagination.SetInternalIndicatorSize((Size)newValue);
            }
        }
        internal static object GetInternalIndicatorSizeProperty(BindableObject bindable)
        {
            var pagination = (Pagination)bindable;
            return pagination.GetInternalIndicatorSize();
        }

        /// <summary>The IndicatorImageUrlSelector bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorImageUrlProperty = null;
        internal static void SetInternalIndicatorImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var pagination = (Pagination)bindable;
            pagination.SetInternalIndicatorImageUrl((Selector<string>)newValue);
        }
        internal static object GetInternalIndicatorImageUrlProperty(BindableObject bindable)
        {
            var pagination = (Pagination)bindable;
            return pagination.GetInternalIndicatorImageUrl();
        }

        /// <summary>The IndicatorSpacing bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSpacingProperty = null;
        internal static void SetInternalIndicatorSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var pagination = (Pagination)bindable;
            pagination.SetInternalIndicatorSpacing((int)newValue);
        }
        internal static object GetInternalIndicatorSpacingProperty(BindableObject bindable)
        {
            var pagination = (Pagination)bindable;
            return pagination.GetInternalIndicatorSpacing();
        }

        /// <summary>
        /// LastIndicatorImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LastIndicatorImageUrlProperty = null;
        internal static void SetInternalLastIndicatorImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Pagination)bindable;
                instance.InternalLastIndicatorImageUrl = newValue as Selector<string>;
            }
        }
        internal static object GetInternalLastIndicatorImageUrlProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalLastIndicatorImageUrl;
        }

        /// <summary>
        /// IndicatorCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorCountProperty = null;
        internal static void SetInternalIndicatorCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Pagination)bindable;
                instance.InternalIndicatorCount = (int)newValue;
            }
        }
        internal static object GetInternalIndicatorCountProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalIndicatorCount;
        }

        /// <summary>
        /// IndicatorColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorColorProperty = null;
        internal static void SetInternalIndicatorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Pagination)bindable;
                instance.InternalIndicatorColor = newValue as Color;
            }
        }
        internal static object GetInternalIndicatorColorProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalIndicatorColor;
        }

        /// <summary>
        /// SelectedIndicatorColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedIndicatorColorProperty = null;
        internal static void SetInternalSelectedIndicatorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Pagination)bindable;
                instance.InternalSelectedIndicatorColor = newValue as Color;
            }
        }
        internal static object GetInternalSelectedIndicatorColorProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalSelectedIndicatorColor;
        }

        /// <summary>
        /// SelectedIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedIndexProperty = null;
        internal static void SetInternalSelectedIndexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Pagination)bindable;
                instance.InternalSelectedIndex = (int)newValue;
            }
        }
        internal static object GetInternalSelectedIndexProperty(BindableObject bindable)
        {
            var instance = (Pagination)bindable;
            return instance.InternalSelectedIndex;
        }
    }
}
