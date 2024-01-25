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
        public static readonly BindableProperty CacheModelProperty = BindableProperty.Create(nameof(CacheModel), typeof(CacheModel), typeof(WebView), default(CacheModel), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalCacheModel = (Tizen.NUI.CacheModel)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalCacheModel;
        });

        /// <summary>
        /// CookieAcceptPolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CookieAcceptPolicyProperty = BindableProperty.Create(nameof(CookieAcceptPolicy), typeof(CookieAcceptPolicy), typeof(WebView), default(CookieAcceptPolicy), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalCookieAcceptPolicy = (Tizen.NUI.CookieAcceptPolicy)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalCookieAcceptPolicy;
        });

        /// <summary>
        /// EnableJavaScriptProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableJavaScriptProperty = BindableProperty.Create(nameof(EnableJavaScript), typeof(bool), typeof(WebView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalEnableJavaScript = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalEnableJavaScript;
        });

        /// <summary>
        /// LoadImagesAutomaticallyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoadImagesAutomaticallyProperty = BindableProperty.Create(nameof(LoadImagesAutomatically), typeof(bool), typeof(WebView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalLoadImagesAutomatically = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalLoadImagesAutomatically;
        });

        /// <summary>
        /// DefaultTextEncodingNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DefaultTextEncodingNameProperty = BindableProperty.Create(nameof(DefaultTextEncodingName), typeof(string), typeof(WebView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalDefaultTextEncodingName = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalDefaultTextEncodingName;
        });

        /// <summary>
        /// DefaultFontSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DefaultFontSizeProperty = BindableProperty.Create(nameof(DefaultFontSize), typeof(int), typeof(WebView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            if (newValue != null)
            {
                instance.InternalDefaultFontSize = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.WebView)bindable;
            return instance.InternalDefaultFontSize;
        });
    }
}
