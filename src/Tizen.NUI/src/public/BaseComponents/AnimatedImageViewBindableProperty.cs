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
        static AnimatedImageView()
        {
            if (NUIApplication.IsUsingXaml)
            {
                BatchSizeProperty = BindableProperty.Create(nameof(BatchSize), typeof(int), typeof(AnimatedImageView), 0,
                    propertyChanged: SetInternalBatchSizeProperty, defaultValueCreator: GetInternalBatchSizeProperty);
                CacheSizeProperty = BindableProperty.Create(nameof(CacheSize), typeof(int), typeof(AnimatedImageView), 0,
                    propertyChanged: SetInternalCacheSizeProperty, defaultValueCreator: GetInternalCacheSizeProperty);
                FrameDelayProperty = BindableProperty.Create(nameof(FrameDelay), typeof(int), typeof(AnimatedImageView), 0,
                    propertyChanged: SetInternalFrameDelayProperty, defaultValueCreator: GetInternalFrameDelayProperty);
                LoopCountProperty = BindableProperty.Create(nameof(LoopCount), typeof(int), typeof(AnimatedImageView), 0,
                    propertyChanged: SetInternalLoopCountProperty, defaultValueCreator: GetInternalLoopCountProperty);
                StopBehaviorProperty = BindableProperty.Create(nameof(StopBehavior), typeof(StopBehaviorType), typeof(AnimatedImageView), default(StopBehaviorType),
                    propertyChanged: SetInternalStopBehaviorProperty, defaultValueCreator: GetInternalStopBehaviorProperty);
                CurrentFrameProperty = BindableProperty.Create(nameof(CurrentFrame), typeof(int), typeof(AnimatedImageView), 0,
                    propertyChanged: SetInternalCurrentFrameProperty, defaultValueCreator: GetInternalCurrentFrameProperty);
            }
        }

        /// <summary>
        /// BatchSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BatchSizeProperty = null;
        internal static void SetInternalBatchSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalBatchSize = (int)newValue;
            }
        }
        internal static object GetInternalBatchSizeProperty(BindableObject bindable)
        {
            var instance = (AnimatedImageView)bindable;
            return instance.InternalBatchSize;
        }

        /// <summary>
        /// CacheSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CacheSizeProperty = null;
        internal static void SetInternalCacheSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCacheSize = (int)newValue;
            }
        }
        internal static object GetInternalCacheSizeProperty(BindableObject bindable)
        {
            var instance = (AnimatedImageView)bindable;
            return instance.InternalCacheSize;
        }

        /// <summary>
        /// FrameDelayProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameDelayProperty = null;
        internal static void SetInternalFrameDelayProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalFrameDelay = (int)newValue;
            }
        }
        internal static object GetInternalFrameDelayProperty(BindableObject bindable)
        {
            var instance = (AnimatedImageView)bindable;
            return instance.InternalFrameDelay;
        }

        /// <summary>
        /// LoopCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopCountProperty = null;
        internal static void SetInternalLoopCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalLoopCount = (int)newValue;
            }
        }
        internal static object GetInternalLoopCountProperty(BindableObject bindable)
        {
            var instance = (AnimatedImageView)bindable;
            return instance.InternalLoopCount;
        }

        /// <summary>
        /// StopBehaviorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StopBehaviorProperty = null;
        internal static void SetInternalStopBehaviorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalStopBehavior = (StopBehaviorType)newValue;
            }
        }
        internal static object GetInternalStopBehaviorProperty(BindableObject bindable)
        {
            var instance = (AnimatedImageView)bindable;
            return instance.InternalStopBehavior;
        }

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentFrameProperty = null;
        internal static void SetInternalCurrentFrameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        }
        internal static object GetInternalCurrentFrameProperty(BindableObject bindable)
        {
            var instance = (AnimatedImageView)bindable;
            return instance.InternalCurrentFrame;
        }
    }
}
