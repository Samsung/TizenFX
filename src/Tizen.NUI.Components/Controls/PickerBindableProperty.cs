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
    public partial class Picker
    {
        /// <summary>
        /// CurrentValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = null;
        internal static void SetInternalCurrentValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Picker)bindable;
                instance.InternalCurrentValue = (int)newValue;
            }
        }
        internal static object GetInternalCurrentValueProperty(BindableObject bindable)
        {
            var instance = (Picker)bindable;
            return instance.InternalCurrentValue;
        }

        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = null;
        internal static void SetInternalMaxValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Picker)bindable;
                instance.InternalMaxValue = (int)newValue;
            }
        }
        internal static object GetInternalMaxValueProperty(BindableObject bindable)
        {
            var instance = (Picker)bindable;
            return instance.InternalMaxValue;
        }

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = null;
        internal static void SetInternalMinValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Picker)bindable;
                instance.InternalMinValue = (int)newValue;
            }
        }
        internal static object GetInternalMinValueProperty(BindableObject bindable)
        {
            var instance = (Picker)bindable;
            return instance.InternalMinValue;
        }
    }
}
