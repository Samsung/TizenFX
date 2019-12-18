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
    /// The control component is class of image. Temporarily for SelectButton.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageControl : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = BindableProperty.Create("ImageControlResourceUrl", typeof(Selector<string>), typeof(ImageControl), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageControl = (ImageControl)bindable;
            if (null != newValue)
            {
                imageControl.ResourceUrlSelector.Clone((Selector<string>)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageControl = (ImageControl)bindable;
            return imageControl.ResourceUrlSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = BindableProperty.Create("ImageControlBorder", typeof(Selector<Rectangle>), typeof(ImageControl), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageControl = (ImageControl)bindable;
            if (null == newValue)
            {
                imageControl.BorderSelector.Clone((Selector<Rectangle>)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageControl = (ImageControl)bindable;
            return imageControl.BorderSelector;
        });

        internal ImageView imageView;

        /// <summary>
        /// Construct an empty Control.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageControl() : base()
        {
            Initialize(null);
        }

        /// <summary>
        /// Construct with style.
        /// </summary>
        /// <param name="style">Create style customized by user</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageControl(ImageControlStyle style) : base(style)
        {
            Initialize(null);
        }

        /// <summary>
        /// Construct with style
        /// </summary>
        /// <param name="style">Style to be applied</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageControl(string style) : base(style)
        {
            Initialize(style);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageControlStyle Style => ViewStyle as ImageControlStyle;

        /// <summary>
        /// Override view's BackgroundImage.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> ResourceUrl
        {
            get => (Selector<string>)GetValue(ResourceUrlProperty);
            set => SetValue(ResourceUrlProperty, value);
        }

        /// <summary>
        /// Override view's BackgroundImageBorder.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> Border
        {
            get => (Selector<Rectangle>)GetValue(BorderProperty);
            set => SetValue(BorderProperty, value);
        }

        private TriggerableSelector<string> _resourceUrlSelector;
        private TriggerableSelector<string> ResourceUrlSelector
        {
            get
            {
                if (null == _resourceUrlSelector)
                {
                    _resourceUrlSelector = new TriggerableSelector<string>(imageView, ImageView.ResourceUrlProperty);
                }
                return _resourceUrlSelector;
            }
        }
        private TriggerableSelector<Rectangle> _borderSelector;
        private TriggerableSelector<Rectangle> BorderSelector
        {
            get
            {
                if (null == _borderSelector)
                {
                    _borderSelector = new TriggerableSelector<Rectangle>(imageView, ImageView.BorderProperty);
                }
                return _borderSelector;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            ImageControlStyle imageControlStyle = viewStyle as ImageControlStyle;
            if (null != imageControlStyle)
            {
                if (null == imageView)
                {
                    imageView = new ImageView()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                    };
                    this.Add(imageView);
                }
                imageView.RaiseToTop();
            }
        }

        /// <summary>
        /// Dispose Control and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (imageView != null)
            {
                Utility.Dispose(imageView);
            }

            base.Dispose(type);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new ImageControlStyle(); ;
        }

        private void Initialize(string style)
        {
            if (null == imageView)
            {
                imageView = new ImageView()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                };
                this.Add(imageView);
            }
        }
    }
}
