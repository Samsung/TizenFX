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
    public partial class Switch
    {
        /// <summary>
        /// SwitchBackgroundImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchBackgroundImageURLSelectorProperty = null;
        internal static void SetInternalSwitchBackgroundImageURLSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchBackgroundImageURLSelector = newValue as StringSelector;
            }
        }
        internal static object GetInternalSwitchBackgroundImageURLSelectorProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchBackgroundImageURLSelector;
        }

        /// <summary>
        /// SwitchHandlerImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageURLProperty = null;
        internal static void SetInternalSwitchHandlerImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchHandlerImageURL = newValue as string;
            }
        }
        internal static object GetInternalSwitchHandlerImageURLProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageURL;
        }

        /// <summary>
        /// SwitchHandlerImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageURLSelectorProperty = null;
        internal static void SetInternalSwitchHandlerImageURLSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchHandlerImageURLSelector = newValue as StringSelector;
            }
        }
        internal static object GetInternalSwitchHandlerImageURLSelectorProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageURLSelector;
        }

        /// <summary>
        /// SwitchHandlerImageSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SwitchHandlerImageSizeProperty = null;
        internal static void SetInternalSwitchHandlerImageSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Switch)bindable;
                instance.InternalSwitchHandlerImageSize = newValue as Size;
            }
        }
        internal static object GetInternalSwitchHandlerImageSizeProperty(BindableObject bindable)
        {
            var instance = (Switch)bindable;
            return instance.InternalSwitchHandlerImageSize;
        }
    }
}
