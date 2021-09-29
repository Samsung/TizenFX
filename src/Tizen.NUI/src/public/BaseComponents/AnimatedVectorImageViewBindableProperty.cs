/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    public partial class AnimatedVectorImageView
    {
        /// <summary>
        /// ResourceURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceURLProperty = BindableProperty.Create(nameof(ResourceURL), typeof(string), typeof(Tizen.NUI.BaseComponents.AnimatedVectorImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalResourceURL = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalResourceURL;
        });

        /// <summary>
        /// ResourceUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly BindableProperty ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(string), typeof(Tizen.NUI.BaseComponents.AnimatedVectorImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalResourceUrl = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalResourceUrl;
        });

        /// <summary>
        /// RepeatCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RepeatCountProperty = BindableProperty.Create(nameof(RepeatCount), typeof(int), typeof(Tizen.NUI.BaseComponents.AnimatedVectorImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalRepeatCount = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalRepeatCount;
        });

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly BindableProperty CurrentFrameProperty = BindableProperty.Create(nameof(CurrentFrame), typeof(int), typeof(Tizen.NUI.BaseComponents.AnimatedVectorImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalCurrentFrame;
        });

        /// <summary>
        /// RepeatModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RepeatModeProperty = BindableProperty.Create(nameof(RepeatMode), typeof(Tizen.NUI.BaseComponents.AnimatedVectorImageView.RepeatModes), typeof(Tizen.NUI.BaseComponents.AnimatedVectorImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalRepeatMode = (Tizen.NUI.BaseComponents.AnimatedVectorImageView.RepeatModes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalRepeatMode;
        });
    }
}
