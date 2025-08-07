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
        public static readonly BindableProperty ResourceURLProperty = null;

        internal static void SetInternalResourceURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedVectorImageView)bindable;
            instance.InternalResourceURL = (string)newValue;
        }
        internal static object GetInternalResourceURLProperty(BindableObject bindable)
        {
            var instance = (AnimatedVectorImageView)bindable;
            return instance.InternalResourceURL;
        }

        /// <summary>
        /// ResourceUrlProperty
        /// </summary>
        /// <remarks>
        /// This property does not have same logic with LottieAnimationView.ResourceUrl.
        /// Should use new keyword!
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty ResourceUrlProperty = null;

        internal static new void SetInternalResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedVectorImageView)bindable;
            instance.InternalResourceUrl = (string)newValue;
        }
        internal static new object GetInternalResourceUrlProperty(BindableObject bindable)
        {
            var instance = (AnimatedVectorImageView)bindable;
            return instance.InternalResourceUrl;
        }

        /// <summary>
        /// RepeatCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RepeatCountProperty = null;

        internal static void SetInternalRepeatCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalRepeatCount = (int)newValue;
            }
        }
        internal static object GetInternalRepeatCountProperty(BindableObject bindable)
        {
            var instance = (AnimatedVectorImageView)bindable;
            return instance.InternalRepeatCount;
        }

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        /// <remarks>
        /// This property does not have same logic with LottieAnimationView.CurrentFrame.
        /// Should use new keyword!
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty CurrentFrameProperty = null;

        internal static new void SetInternalCurrentFrameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        }
        internal static new object GetInternalCurrentFrameProperty(BindableObject bindable)
        {
            var instance = (AnimatedVectorImageView)bindable;
            return instance.InternalCurrentFrame;
        }

        /// <summary>
        /// RepeatModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RepeatModeProperty = null;

        static internal void SetInternalRepeatModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalRepeatMode = (RepeatModes)newValue;
            }
        }
        static internal object GetInternalRepeatModeProperty(BindableObject bindable)
        {
            var instance = (AnimatedVectorImageView)bindable;
            return instance.InternalRepeatMode;
        }
    }
}
