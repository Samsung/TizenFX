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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Tab
    {
        /// <summary>
        /// SelectedItemIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemIndexProperty = null;
        internal static void SetInternalSelectedItemIndexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalSelectedItemIndex = (int)newValue;
            }
        }
        internal static object GetInternalSelectedItemIndexProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalSelectedItemIndex;
        }

        /// <summary>
        /// UseTextNaturalSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UseTextNaturalSizeProperty = null;
        internal static void SetInternalUseTextNaturalSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalUseTextNaturalSize = (bool)newValue;
            }
        }
        internal static object GetInternalUseTextNaturalSizeProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalUseTextNaturalSize;
        }

        /// <summary>
        /// ItemSpaceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemSpaceProperty = null;
        internal static void SetInternalItemSpaceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalItemSpace = (int)newValue;
            }
        }
        internal static object GetInternalItemSpaceProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalItemSpace;
        }

        /// <summary>
        /// SpaceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceProperty = null;
        internal static void SetInternalSpaceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalSpace = newValue as Extents;
            }
        }
        internal static object GetInternalSpaceProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalSpace;
        }

        /// <summary>
        /// ItemPaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemPaddingProperty = null;
        internal static void SetInternalItemPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalItemPadding = newValue as Extents;
            }
        }
        internal static object GetInternalItemPaddingProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalItemPadding;
        }

        /// <summary>
        /// UnderLineSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderLineSizeProperty = null;
        internal static void SetInternalUnderLineSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalUnderLineSize = newValue as Size;
            }
        }
        internal static object GetInternalUnderLineSizeProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalUnderLineSize;
        }

        /// <summary>
        /// UnderLineBackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderLineBackgroundColorProperty = null;
        internal static void SetInternalUnderLineBackgroundColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalUnderLineBackgroundColor = newValue as Color;
            }
        }
        internal static object GetInternalUnderLineBackgroundColorProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalUnderLineBackgroundColor;
        }

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalPointSize = (float)newValue;
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalPointSize;
        }

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalFontFamily = newValue as string;
            }
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalFontFamily;
        }

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalTextColor = newValue as Color;
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalTextColor;
        }

        /// <summary>
        /// TextColorSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = null;
        internal static void SetInternalTextColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Tab)bindable;
                instance.InternalTextColorSelector = newValue as ColorSelector;
            }
        }
        internal static object GetInternalTextColorSelectorProperty(BindableObject bindable)
        {
            var instance = (Tab)bindable;
            return instance.InternalTextColorSelector;
        }
    }
}
