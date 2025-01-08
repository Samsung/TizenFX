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
    public partial class LottieAnimationView
    {
        /// <summary>
        /// URLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty URLProperty = null;

        internal static void SetInternalURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalURL = (string)newValue;
            }
        }

        internal static object GetInternalURLProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalURL;
        }

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentFrameProperty = null;

        internal static void SetInternalCurrentFrameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        }

        internal static object GetInternalCurrentFrameProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalCurrentFrame;
        }

        /// <summary>
        /// LoopingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopingModeProperty = null;

        internal static void SetInternalLoopingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalLoopingMode = (Tizen.NUI.BaseComponents.LottieAnimationView.LoopingModeType)newValue;
            }
        }
        internal static object GetInternalLoopingModeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalLoopingMode;
        }

        /// <summary>
        /// LoopCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopCountProperty = null;

        internal static void SetInternalLoopCountProperty(BindableObject bindable, object oldValue, object newValue)

        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalLoopCount = (int)newValue;
            }
        }
        internal static object GetInternalLoopCountProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalLoopCount;
        }

        /// <summary>
        /// StopBehaviorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StopBehaviorProperty = null;

        internal static void SetInternalStopBehaviorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalStopBehavior = (Tizen.NUI.BaseComponents.LottieAnimationView.StopBehaviorType)newValue;
            }
        }

        internal static object GetInternalStopBehaviorProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalStopBehavior;
        }

        /// <summary>
        /// RedrawInScalingDownProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RedrawInScalingDownProperty = null;

        internal static void SetInternalRedrawInScalingDownProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalRedrawInScalingDown = (bool)newValue;
            }
        }

        internal static object GetInternalRedrawInScalingDownProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalRedrawInScalingDown;
        }

        /// <summary>
        /// EnableFrameCacheProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFrameCacheProperty = null;

        internal static void SetInternalEnableFrameCacheProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalEnableFrameCache = (bool)newValue;
            }
        }

        internal static object GetInternalEnableFrameCacheProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalEnableFrameCache;
        }

        /// <summary>
        /// NotifyAfterRasterizationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NotifyAfterRasterizationProperty = null;

        internal static void SetInternalNotifyAfterRasterizationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalNotifyAfterRasterization = (bool)newValue;
            }
        }

        internal static object GetInternalNotifyAfterRasterizationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalNotifyAfterRasterization;
        }
    }
}
