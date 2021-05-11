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
    public partial class Layer
    {
        /// <summary>
        /// BehaviorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty BehaviorProperty { get; } = BindableProperty.Create(nameof(Behavior), typeof(Tizen.NUI.Layer.LayerBehavior), typeof(Tizen.NUI.Layer), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            if (newValue != null)
            {
                instance.InternalBehavior = (Tizen.NUI.Layer.LayerBehavior)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            return instance.InternalBehavior;
        });

        /// <summary>
        /// ViewportProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ViewportProperty { get; } = BindableProperty.Create(nameof(Viewport), typeof(Tizen.NUI.Rectangle), typeof(Tizen.NUI.Layer), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            if (newValue != null)
            {
                instance.InternalViewport = (Tizen.NUI.Rectangle)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            return instance.InternalViewport;
        });

        /// <summary>
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty OpacityProperty { get; } = BindableProperty.Create(nameof(Opacity), typeof(float), typeof(Tizen.NUI.Layer), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            if (newValue != null)
            {
                instance.InternalOpacity = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            return instance.InternalOpacity;
        });

        /// <summary>
        /// VisibilityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty VisibilityProperty { get; } = BindableProperty.Create(nameof(Visibility), typeof(bool), typeof(Tizen.NUI.Layer), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            if (newValue != null)
            {
                instance.InternalVisibility = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            return instance.InternalVisibility;
        });

        /// <summary>
        /// NameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty NameProperty { get; } = BindableProperty.Create(nameof(Name), typeof(string), typeof(Tizen.NUI.Layer), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            if (newValue != null)
            {
                instance.InternalName = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Layer)bindable;
            return instance.InternalName;
        });
    }
}
