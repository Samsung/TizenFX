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
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class AlertDialog
    {
        /// <summary>
        /// TitleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleProperty = null;
        internal static void SetInternalTitleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (AlertDialog)bindable;
                instance.InternalTitle = newValue as string;
            }
        }
        internal static object GetInternalTitleProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalTitle;
        }

        /// <summary>
        /// TitleContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleContentProperty = null;
        internal static void SetInternalTitleContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (AlertDialog)bindable;
                instance.InternalTitleContent = newValue as View;
            }
        }
        internal static object GetInternalTitleContentProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalTitleContent;
        }

        /// <summary>
        /// MessageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MessageProperty = null;
        internal static void SetInternalMessageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (AlertDialog)bindable;
                instance.InternalMessage = newValue as string;
            }
        }
        internal static object GetInternalMessageProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalMessage;
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
                var instance = (AlertDialog)bindable;
                instance.InternalContent = newValue as View;
            }
        }
        internal static object GetInternalContentProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalContent;
        }

        /// <summary>
        /// ActionsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionsProperty = null;
        internal static void SetInternalActionsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (AlertDialog)bindable;
                instance.InternalActions = newValue as IEnumerable<View>;
            }
        }
        internal static object GetInternalActionsProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalActions;
        }

        /// <summary>
        /// ActionContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionContentProperty = null;
        internal static void SetInternalActionContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (AlertDialog)bindable;
                instance.InternalActionContent = newValue as View;
            }
        }
        internal static object GetInternalActionContentProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalActionContent;
        }
    }
}
