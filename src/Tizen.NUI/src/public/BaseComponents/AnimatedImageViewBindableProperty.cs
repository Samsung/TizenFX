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
    public partial class AnimatedImageView
    {
        /// <summary>
        /// ResourceUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly BindableProperty ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(string), typeof(AnimatedImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalResourceUrl = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalResourceUrl;
        });

        /// <summary>
        /// BatchSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BatchSizeProperty = BindableProperty.Create(nameof(BatchSize), typeof(int), typeof(AnimatedImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalBatchSize = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalBatchSize;
        });

        /// <summary>
        /// CacheSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CacheSizeProperty = BindableProperty.Create(nameof(CacheSize), typeof(int), typeof(AnimatedImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCacheSize = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalCacheSize;
        });

        /// <summary>
        /// FrameDelayProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameDelayProperty = BindableProperty.Create(nameof(FrameDelay), typeof(int), typeof(AnimatedImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalFrameDelay = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalFrameDelay;
        });

        /// <summary>
        /// LoopCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopCountProperty = BindableProperty.Create(nameof(LoopCount), typeof(int), typeof(AnimatedImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalLoopCount = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalLoopCount;
        });

        /// <summary>
        /// StopBehaviorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StopBehaviorProperty = BindableProperty.Create(nameof(StopBehavior), typeof(StopBehaviorType), typeof(AnimatedImageView), default(StopBehaviorType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalStopBehavior = (Tizen.NUI.BaseComponents.AnimatedImageView.StopBehaviorType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalStopBehavior;
        });

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentFrameProperty = BindableProperty.Create(nameof(CurrentFrame), typeof(int), typeof(AnimatedImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedImageView)bindable;
            return instance.InternalCurrentFrame;
        });
    }
}
