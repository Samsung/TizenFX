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
        public static readonly BindableProperty URLProperty = BindableProperty.Create(nameof(URL), typeof(string), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalURL = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalURL;
        });

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentFrameProperty = BindableProperty.Create(nameof(CurrentFrame), typeof(int), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalCurrentFrame;
        });

        /// <summary>
        /// LoopingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopingModeProperty = BindableProperty.Create(nameof(LoopingMode), typeof(LoopingModeType), typeof(LottieAnimationView), default(LoopingModeType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalLoopingMode = (Tizen.NUI.BaseComponents.LottieAnimationView.LoopingModeType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalLoopingMode;
        });

        /// <summary>
        /// LoopCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopCountProperty = BindableProperty.Create(nameof(LoopCount), typeof(int), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalLoopCount = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalLoopCount;
        });

        /// <summary>
        /// StopBehaviorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StopBehaviorProperty = BindableProperty.Create(nameof(StopBehavior), typeof(StopBehaviorType), typeof(LottieAnimationView), default(StopBehaviorType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalStopBehavior = (Tizen.NUI.BaseComponents.LottieAnimationView.StopBehaviorType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalStopBehavior;
        });

        /// <summary>
        /// RedrawInScalingDownProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RedrawInScalingDownProperty = BindableProperty.Create(nameof(RedrawInScalingDown), typeof(bool), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            if (newValue != null)
            {
                instance.InternalRedrawInScalingDown = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.LottieAnimationView)bindable;
            return instance.InternalRedrawInScalingDown;
        });
    }
}
