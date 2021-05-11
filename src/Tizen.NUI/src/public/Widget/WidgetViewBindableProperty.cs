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
    public partial class WidgetView
    {
        /// <summary>
        /// PreviewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty PreviewProperty { get; } = BindableProperty.Create(nameof(Preview), typeof(bool), typeof(Tizen.NUI.WidgetView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalPreview = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalPreview;
        });

        /// <summary>
        /// LoadingTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LoadingTextProperty { get; } = BindableProperty.Create(nameof(LoadingText), typeof(bool), typeof(Tizen.NUI.WidgetView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalLoadingText = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalLoadingText;
        });

        /// <summary>
        /// WidgetStateFaultedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty WidgetStateFaultedProperty { get; } = BindableProperty.Create(nameof(WidgetStateFaulted), typeof(bool), typeof(Tizen.NUI.WidgetView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalWidgetStateFaulted = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalWidgetStateFaulted;
        });

        /// <summary>
        /// PermanentDeleteProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty PermanentDeleteProperty { get; } = BindableProperty.Create(nameof(PermanentDelete), typeof(bool), typeof(Tizen.NUI.WidgetView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalPermanentDelete = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalPermanentDelete;
        });

        /// <summary>
        /// RetryTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty RetryTextProperty { get; } = BindableProperty.Create(nameof(RetryText), typeof(Tizen.NUI.PropertyMap), typeof(Tizen.NUI.WidgetView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalRetryText = (Tizen.NUI.PropertyMap)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalRetryText;
        });

        /// <summary>
        /// EffectProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty EffectProperty { get; } = BindableProperty.Create(nameof(Effect), typeof(Tizen.NUI.PropertyMap), typeof(Tizen.NUI.WidgetView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalEffect = (Tizen.NUI.PropertyMap)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalEffect;
        });

    }
}
