/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ToastStyle is a class which saves Toast's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ToastStyle : TextLabelStyle
    {
        /// <summary>
        /// Creates a new instance of a ToastStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToastStyle() : base()
        {
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a ToastStyle with Style.
        /// </summary>
        /// <param name="Style">Create ToastStyle by Style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToastStyle(ToastStyle style) : base()
        {
            InitSubStyle();
            this.CopyFrom(style);
        }

        /// <summary>
        /// Gets or sets background image Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundUrl
        {
            get;
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundBorder
        {
            get;
            set;
        }    

        /// <summary>
        /// Gets or sets toast show duration time.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? Duration
        {
            get;
            set;
        }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
            ToastStyle toastStyle = bindableObject as ToastStyle;
            if (toastStyle != null)
            {
                Duration = toastStyle.Duration;
                BackgroundUrl = toastStyle.BackgroundUrl;
                BackgroundBorder = toastStyle.BackgroundBorder;          
            }
        }

        private void InitSubStyle()
        {
            HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center;
            VerticalAlignment = Tizen.NUI.VerticalAlignment.Center;
            TextColor = Color.White;
        }
    }
}
