/*
 * Copyright(c) 2019-2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    public partial class Spin
    {
        /// <summary>
        /// ValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ValueProperty { get; } = BindableProperty.Create(nameof(Value), typeof(int), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalValue = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalValue;
        });

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MinValueProperty { get; } = BindableProperty.Create(nameof(MinValue), typeof(int), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalMinValue = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalMinValue;
        });

        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MaxValueProperty { get; } = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalMaxValue = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalMaxValue;
        });

        /// <summary>
        /// StepProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty StepProperty { get; } = BindableProperty.Create(nameof(Step), typeof(int), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalStep = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalStep;
        });

        /// <summary>
        /// WrappingEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty WrappingEnabledProperty { get; } = BindableProperty.Create(nameof(WrappingEnabled), typeof(bool), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalWrappingEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalWrappingEnabled;
        });

        /// <summary>
        /// TextPointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty TextPointSizeProperty { get; } = BindableProperty.Create(nameof(TextPointSize), typeof(int), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalTextPointSize = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalTextPointSize;
        });

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty TextColorProperty { get; } = BindableProperty.Create(nameof(TextColor), typeof(Tizen.NUI.Color), typeof(Tizen.NUI.Spin), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalTextColor = (Tizen.NUI.Color)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalTextColor;
        });

        /// <summary>
        /// MaxTextLengthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MaxTextLengthProperty { get; } = BindableProperty.Create(nameof(MaxTextLength), typeof(int), typeof(Tizen.NUI.Spin), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalMaxTextLength = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalMaxTextLength;
        });

        /// <summary>
        /// SpinTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty SpinTextProperty { get; } = BindableProperty.Create(nameof(SpinText), typeof(Tizen.NUI.BaseComponents.TextField), typeof(Tizen.NUI.Spin), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalSpinText = (Tizen.NUI.BaseComponents.TextField)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalSpinText;
        });

        /// <summary>
        /// IndicatorImageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty IndicatorImageProperty { get; } = BindableProperty.Create(nameof(IndicatorImage), typeof(string), typeof(Tizen.NUI.Spin), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            if (newValue != null)
            {
                instance.InternalIndicatorImage = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Spin)bindable;
            return instance.InternalIndicatorImage;
        });

    }
}
