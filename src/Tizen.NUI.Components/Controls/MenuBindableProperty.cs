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
    public partial class Menu
    {
        /// <summary>
        /// AnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorProperty = null;
        internal static void SetInternalAnchorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Menu)bindable;
                instance.InternalAnchor = newValue as View;
            }
        }
        internal static object GetInternalAnchorProperty(BindableObject bindable)
        {
            var instance = (Menu)bindable;
            return instance.InternalAnchor;
        }

        /// <summary>
        /// HorizontalPositionToAnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalPositionToAnchorProperty = null;
        internal static void SetInternalHorizontalPositionToAnchorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Menu)bindable;
                instance.InternalHorizontalPositionToAnchor = (RelativePosition)newValue;
            }
        }
        internal static object GetInternalHorizontalPositionToAnchorProperty(BindableObject bindable)
        {
            var instance = (Menu)bindable;
            return instance.InternalHorizontalPositionToAnchor;
        }

        /// <summary>
        /// VerticalPositionToAnchorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalPositionToAnchorProperty = null;
        internal static void SetInternalVerticalPositionToAnchorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Menu)bindable;
                instance.InternalVerticalPositionToAnchor = (RelativePosition)newValue;
            }
        }
        internal static object GetInternalVerticalPositionToAnchorProperty(BindableObject bindable)
        {
            var instance = (Menu)bindable;
            return instance.InternalVerticalPositionToAnchor;
        }
    }
}
