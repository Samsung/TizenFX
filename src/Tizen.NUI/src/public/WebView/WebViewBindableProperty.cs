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
        private static readonly BindableProperty UrlProperty = null;

        internal static void SetInternalUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalUrl((string)newValue);
            }
        }

        internal static object GetInternalUrlProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalUrl();
        }

        private static readonly BindableProperty UserAgentProperty = null;

        internal static void SetInternalUserAgentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalUserAgent((string)newValue);
            }
        }

        internal static object GetInternalUserAgentProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalUserAgent();
        }

        private static readonly BindableProperty ScrollPositionProperty = null;

        internal static void SetInternalScrollPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalScrollPosition((Position)newValue);
            }
        }

        internal static object GetInternalScrollPositionProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalScrollPosition();
        }

        private static readonly BindableProperty ScrollSizeProperty = null;

        internal static object GetInternalScrollSizeProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalScrollSize();
        }

        private static readonly BindableProperty ContentSizeProperty = null;

        internal static object GetInternalContentSizeProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalContentSize();
        }

        private static readonly BindableProperty TitleProperty = null;

        internal static object GetInternalTitleProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalTitle();
        }

        private static readonly BindableProperty VideoHoleEnabledProperty = null;

        internal static void SetInternalVideoHoleEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalVideoHoleEnabled((bool)newValue);
            }
        }

        internal static object GetInternalVideoHoleEnabledProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalVideoHoleEnabled();
        }

        private static readonly BindableProperty MouseEventsEnabledProperty = null;

        internal static void SetInternalMouseEventsEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalMouseEventsEnabled((bool)newValue);
            }
        }

        internal static object GetInternalMouseEventsEnabledProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalMouseEventsEnabled();
        }

        private static readonly BindableProperty KeyEventsEnabledProperty = null;

        internal static void SetInternalKeyEventsEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalKeyEventsEnabled((bool)newValue);
            }
        }

        internal static object GetInternalKeyEventsEnabledProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalKeyEventsEnabled();
        }

        private static readonly BindableProperty ContentBackgroundColorProperty = null;

        internal static void SetInternalContentBackgroundColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalContentBackgroundColor((Color)newValue);
            }
        }

        internal static object GetInternalContentBackgroundColorProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalContentBackgroundColor();
        }

        private static readonly BindableProperty TilesClearedWhenHiddenProperty = null;

        internal static void SetInternalTilesClearedWhenHiddenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalTilesClearedWhenHidden((bool)newValue);
            }
        }

        internal static object GetInternalTilesClearedWhenHiddenProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalTilesClearedWhenHidden();
        }

        private static readonly BindableProperty TileCoverAreaMultiplierProperty = null;

        internal static void SetInternalTileCoverAreaMultiplierProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalTileCoverAreaMultiplier((float)newValue);
            }
        }

        internal static object GetInternalTileCoverAreaMultiplierProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalTileCoverAreaMultiplier();
        }

        private static readonly BindableProperty CursorEnabledByClientProperty = null;

        internal static void SetInternalCursorEnabledByClientProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalCursorEnabledByClient((bool)newValue);
            }
        }

        internal static object GetInternalCursorEnabledByClientProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalCursorEnabledByClient();
        }

        private static readonly BindableProperty SelectedTextProperty = null;

        internal static object GetInternalSelectedTextProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalSelectedText();
        }

        private static readonly BindableProperty PageZoomFactorProperty = null;

        internal static void SetInternalPageZoomFactorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalPageZoomFactor((float)newValue);
            }
        }

        internal static object GetInternalPageZoomFactorProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalPageZoomFactor();
        }

        private static readonly BindableProperty TextZoomFactorProperty = null;

        internal static void SetInternalTextZoomFactorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var webview = (WebView)bindable;
                webview.SetInternalTextZoomFactor((float)newValue);
            }
        }

        internal static object GetInternalTextZoomFactorProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalTextZoomFactor();
        }

        private static readonly BindableProperty LoadProgressPercentageProperty = null;

        internal static object GetInternalLoadProgressPercentageProperty(BindableObject bindable)
        {
            var webview = (WebView)bindable;
            return webview.GetInternalLoadProgressPercentage();
        }

        /// <summary>
        /// CacheModelProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CacheModelProperty = null;

        internal static void SetInternalCacheModelProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (WebView)bindable;
                instance.InternalCacheModel = (Tizen.NUI.CacheModel)newValue;
            }
        }

        internal static object GetInternalCacheModelProperty(BindableObject bindable)
        {
            var instance = (WebView)bindable;
            return instance.InternalCacheModel;
        }

        /// <summary>
        /// CookieAcceptPolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CookieAcceptPolicyProperty = null;

        internal static void SetInternalCookieAcceptPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (WebView)bindable;
                instance.InternalCookieAcceptPolicy = (Tizen.NUI.CookieAcceptPolicy)newValue;
            }
        }

        internal static object GetInternalCookieAcceptPolicyProperty(BindableObject bindable)
        {
            var instance = (WebView)bindable;
            return instance.InternalCookieAcceptPolicy;
        }

        /// <summary>
        /// EnableJavaScriptProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableJavaScriptProperty = null;

        internal static void SetInternalEnableJavaScriptProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (WebView)bindable;
                instance.InternalEnableJavaScript = (bool)newValue;
            }
        }

        internal static object GetInternalEnableJavaScriptProperty(BindableObject bindable)
        {
            var instance = (WebView)bindable;
            return instance.InternalEnableJavaScript;
        }

        /// <summary>
        /// LoadImagesAutomaticallyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoadImagesAutomaticallyProperty = null;

        internal static void SetInternalLoadImagesAutomaticallyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (WebView)bindable;
                instance.InternalLoadImagesAutomatically = (bool)newValue;
            }
        }

        internal static object GetInternalLoadImagesAutomaticallyProperty(BindableObject bindable)
        {
            var instance = (WebView)bindable;
            return instance.InternalLoadImagesAutomatically;
        }

        /// <summary>
        /// DefaultTextEncodingNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DefaultTextEncodingNameProperty = null;

        internal static void SetInternalDefaultTextEncodingNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (WebView)bindable;
                instance.InternalDefaultTextEncodingName = (string)newValue;
            }
        }

        internal static object GetInternalDefaultTextEncodingNameProperty(BindableObject bindable)
        {
            var instance = (WebView)bindable;
            return instance.InternalDefaultTextEncodingName;
        }

        /// <summary>
        /// DefaultFontSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DefaultFontSizeProperty = null;

        internal static void SetInternalDefaultFontSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (WebView)bindable;
                instance.InternalDefaultFontSize = (int)newValue;
            }
        }

        internal static object GetInternalDefaultFontSizeProperty(BindableObject bindable)
        {
            var instance = (WebView)bindable;
            return instance.InternalDefaultFontSize;
        }
    }
}
