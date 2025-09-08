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
    public partial class DefaultTitleItem
    {
        /// <summary>
        /// IconProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconProperty = null;
        internal static void SetInternalIconProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DefaultTitleItem)bindable;
                instance.InternalIcon = newValue as View;
            }
        }
        internal static object GetInternalIconProperty(BindableObject bindable)
        {
            var instance = (DefaultTitleItem)bindable;
            return instance.InternalIcon;
        }

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DefaultTitleItem)bindable;
                instance.InternalText = newValue as string;
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var instance = (DefaultTitleItem)bindable;
            return instance.InternalText;
        }
    }
}
