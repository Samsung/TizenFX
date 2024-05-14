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
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ResourceURLProperty = null;
#else
        public static readonly BindableProperty ResourceURLProperty = null;
#endif
        internal static void SetInternalResourceURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            instance.InternalResourceURL = (string)newValue;
        }
        internal static object GetInternalResourceURLProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalResourceURL;
        }

        /// <summary>
        /// ResourceUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static new BindableProperty ResourceUrlProperty = null;
#else
        public static readonly new BindableProperty ResourceUrlProperty = null;
#endif
        internal static void SetInternalResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            instance.InternalResourceUrl = (string)newValue;
        }
        internal static object GetInternalResourceUrlProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalResourceUrl;
        }

        /// <summary>
        /// RepeatCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty RepeatCountProperty = null;
#else
        public static readonly BindableProperty RepeatCountProperty = null;
#endif
        internal static void SetInternalRepeatCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalRepeatCount = (int)newValue;
            }
        }
        internal static object GetInternalRepeatCountProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalRepeatCount;
        }

        /// <summary>
        /// CurrentFrameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static new BindableProperty CurrentFrameProperty = null;
#else
        public static readonly new BindableProperty CurrentFrameProperty = null;
#endif
        internal static void SetInternalCurrentFrameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentFrame = (int)newValue;
            }
        }
        internal static object GetInternalCurrentFrameProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalCurrentFrame;
        }

        /// <summary>
        /// RepeatModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty RepeatModeProperty = null;
#else
        public static readonly BindableProperty RepeatModeProperty = null;
#endif
        static internal void SetInternalRepeatModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            if (newValue != null)
            {
                instance.InternalRepeatMode = (Tizen.NUI.BaseComponents.AnimatedVectorImageView.RepeatModes)newValue;
            }
        }
        static internal object GetInternalRepeatModeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.AnimatedVectorImageView)bindable;
            return instance.InternalRepeatMode;
        }
    }
}
