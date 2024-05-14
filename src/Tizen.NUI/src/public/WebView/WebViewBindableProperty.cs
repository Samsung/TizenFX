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
    public partial class WebView
    {
        /// <summary>
        /// CacheModelProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CacheModelProperty = null;

        internal static void SetInternalCacheModelProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalCacheModel = (Tizen.NUI.CacheModel)newValue;
            }
        }

        internal static object GetInternalCacheModelProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalCacheModel;
        }

        /// <summary>
        /// CookieAcceptPolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CookieAcceptPolicyProperty = null;

        internal static void SetInternalCookieAcceptPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalCookieAcceptPolicy = (Tizen.NUI.CookieAcceptPolicy)newValue;
            }
        }

        internal static object GetInternalCookieAcceptPolicyProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalCookieAcceptPolicy;
        }

        /// <summary>
        /// EnableJavaScriptProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableJavaScriptProperty = null;

        internal static void SetInternalEnableJavaScriptProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalEnableJavaScript = (bool)newValue;
            }
        }

        internal static object GetInternalEnableJavaScriptProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalEnableJavaScript;
        }

        /// <summary>
        /// LoadImagesAutomaticallyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoadImagesAutomaticallyProperty = null;

        internal static void SetInternalLoadImagesAutomaticallyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalLoadImagesAutomatically = (bool)newValue;
            }
        }

        internal static object GetInternalLoadImagesAutomaticallyProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalLoadImagesAutomatically;
        }

        /// <summary>
        /// DefaultTextEncodingNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DefaultTextEncodingNameProperty = null;

        internal static void SetInternalDefaultTextEncodingNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalDefaultTextEncodingName = (string)newValue;
            }
        }

        internal static object GetInternalDefaultTextEncodingNameProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalDefaultTextEncodingName;
        }

        /// <summary>
        /// DefaultFontSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DefaultFontSizeProperty = null;

        internal static void SetInternalDefaultFontSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalDefaultFontSize = (int)newValue;
            }
        }

        internal static object GetInternalDefaultFontSizeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalDefaultFontSize;
        }
    }
}
