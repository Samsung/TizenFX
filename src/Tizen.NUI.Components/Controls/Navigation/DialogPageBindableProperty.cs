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
    public partial class DialogPage
    {
        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = null;
        internal static void SetInternalContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DialogPage)bindable;
                instance.InternalContent = newValue as View;
            }
        }
        internal static object GetInternalContentProperty(BindableObject bindable)
        {
            var instance = (DialogPage)bindable;
            return instance.InternalContent;
        }

        /// <summary>
        /// EnableScrimProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrimProperty = null;
        internal static void SetInternalEnableScrimProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DialogPage)bindable;
                instance.InternalEnableScrim = (bool)newValue;
            }
        }
        internal static object GetInternalEnableScrimProperty(BindableObject bindable)
        {
            var instance = (DialogPage)bindable;
            return instance.InternalEnableScrim;
        }

        /// <summary>
        /// EnableDismissOnScrimProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableDismissOnScrimProperty = null;
        internal static void SetInternalEnableDismissOnScrimProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DialogPage)bindable;
                instance.InternalEnableDismissOnScrim = (bool)newValue;
            }
        }
        internal static object GetInternalEnableDismissOnScrimProperty(BindableObject bindable)
        {
            var instance = (DialogPage)bindable;
            return instance.InternalEnableDismissOnScrim;
        }

        /// <summary>
        /// ScrimColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrimColorProperty = null;
        internal static void SetInternalScrimColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (DialogPage)bindable;
                instance.InternalScrimColor = newValue as Color;
            }
        }
        internal static object GetInternalScrimColorProperty(BindableObject bindable)
        {
            var instance = (DialogPage)bindable;
            return instance.InternalScrimColor;
        }
    }
}
