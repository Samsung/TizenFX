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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ImageControlStyle is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageControlStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = BindableProperty.Create("ImageControlResourceUrl", typeof(Selector<string>), typeof(ImageControlStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageControlStyle = (ImageControlStyle)bindable;
            if (null == imageControlStyle.resourceUrlSelector) imageControlStyle.resourceUrlSelector = new Selector<string>();
            imageControlStyle.resourceUrlSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var imageControlStyle = (ImageControlStyle)bindable;
            return imageControlStyle.resourceUrlSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = BindableProperty.Create("ImageControlBorder", typeof(Selector<Rectangle>), typeof(ImageControlStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageControlStyle = (ImageControlStyle)bindable;
            if (null == imageControlStyle.borderSelector) imageControlStyle.borderSelector = new Selector<Rectangle>();
            imageControlStyle.borderSelector.Clone((Selector<Rectangle>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var imageControlStyle = (ImageControlStyle)bindable;
            return imageControlStyle.borderSelector;
        });

        private Selector<string> resourceUrlSelector;
        private Selector<Rectangle> borderSelector;

        static ImageControlStyle() { }

        /// <summary>
        /// Creates a new instance of a ImageControlStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageControlStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a ImageControlStyle with style.
        /// </summary>
        /// <param name="style">Create ImageControlStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageControlStyle(ImageControlStyle style) : base(style)
        {
            if(null == style) return;

            this.CopyFrom(style);
        }

        /// <summary>
        /// Image URL.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> ResourceUrl
        {
            get
            {
                Selector<string> url = (Selector<string>)GetValue(ResourceUrlProperty);
                return (null != url) ? url : resourceUrlSelector = new Selector<string>();
            }
            set => SetValue(ResourceUrlProperty, value);
        }

        /// <summary>
        /// Image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> Border
        {
            get
            {
                Selector<Rectangle> border = (Selector<Rectangle>)GetValue(BorderProperty);
                return (null != border) ? border : borderSelector = new Selector<Rectangle>();
            }
            set => SetValue(BorderProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ImageControlStyle imageControlStyle = bindableObject as ImageControlStyle;

            if (null != imageControlStyle)
            {
                if (null != imageControlStyle.ResourceUrl)
                {
                    if (null == ResourceUrl) ResourceUrl = new Selector<string>();
                    ResourceUrl.Clone(imageControlStyle.ResourceUrl);
                }
                if (null != imageControlStyle.Border)
                {
                    if (null == Border) Border = new Selector<Rectangle>();
                    Border.Clone(imageControlStyle.Border);
                }
            }
        }
    }
}
