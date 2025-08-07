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
    public partial class ContentPage
    {
        /// <summary>
        /// AppBarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AppBarProperty = null;
        internal static void SetInternalAppBarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ContentPage)bindable;
                instance.InternalAppBar = newValue as AppBar;
            }
        }
        internal static object GetInternalAppBarProperty(BindableObject bindable)
        {
            var instance = (ContentPage)bindable;
            return instance.InternalAppBar;
        }

        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = null;
        internal static void SetInternalContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ContentPage)bindable;
                instance.InternalContent = newValue as View;
            }
        }
        internal static object GetInternalContentProperty(BindableObject bindable)
        {
            var instance = (ContentPage)bindable;
            return instance.InternalContent;
        }
    }
}
