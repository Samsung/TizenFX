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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The image view attributes class.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageAttributes : ViewAttributes
    {
        /// <summary>
        /// Construct ImageAttributes.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes() : base() { }
        /// <summary>
        /// Construct with specified attribute.
        /// </summary>
        /// <param name="attributes">The specified ImageAttributes.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes(ImageAttributes attributes) : base(attributes)
        {
            if (attributes == null)
            {
                return;
            }

            if (attributes.ResourceURL != null)
            {
                ResourceURL = attributes.ResourceURL.Clone() as StringSelector;
            }

            if (attributes.Border != null)
            {
                Border = attributes.Border.Clone() as RectangleSelector;
            }

            if (attributes.PreMultipliedAlpha != null)
            {
                PreMultipliedAlpha = attributes.PreMultipliedAlpha;
            }
            if (attributes.PixelArea != null)
            {
                PixelArea = new RelativeVector4(attributes.PixelArea.X, attributes.PixelArea.Y, attributes.PixelArea.Z, attributes.PixelArea.W);
            }
            if (attributes.BorderOnly != null)
            {
                BorderOnly = attributes.BorderOnly;
            }
            if (attributes.SynchronosLoading != null)
            {
                SynchronosLoading = attributes.SynchronosLoading;
            }
            if (attributes.OrientationCorrection != null)
            {
                OrientationCorrection = attributes.OrientationCorrection;
            }
            if (attributes.AlphaMaskURL != null)
            {
                AlphaMaskURL = attributes.AlphaMaskURL.Clone() as StringSelector;
            }
            if (attributes.CropToMask != null)
            {
                CropToMask = attributes.CropToMask;
            }
            if (attributes.FittingMode != null)
            {
                FittingMode = attributes.FittingMode;
            }
            if (attributes.DesiredWidth != null)
            {
                DesiredWidth = attributes.DesiredWidth;
            }
            if (attributes.DesiredHeight != null)
            {
                DesiredHeight = attributes.DesiredHeight;
            }
            if (attributes.WrapModeX != null)
            {
                WrapModeX = attributes.WrapModeX;
            }
            if (attributes.WrapModeY != null)
            {
                WrapModeY = attributes.WrapModeY;
            }
        }
        /// <summary>
        /// Image URL.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector ResourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// Image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RectangleSelector Border
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <returns> Return the attributes clone.</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new ImageAttributes(this);
        }

        /// <summary>
        /// Image PreMultipliedAlpha.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PreMultipliedAlpha
        {
            get;
            set;
        }
        /// <summary>
        /// Image PixelArea.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RelativeVector4 PixelArea
        {
            get;
            set;
        }
        /// <summary>
        /// Image BorderOnly.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? BorderOnly
        {
            get;
            set;
        }
        /// <summary>
        /// Image SynchronosLoading.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SynchronosLoading
        {
            get;
            set;
        }
        /// <summary>
        /// Image OrientationCorrection.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? OrientationCorrection
        {
            get;
            set;
        }
        /// <summary>
        /// Image AlphaMaskURL.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector AlphaMaskURL
        {
            get;
            set;
        }
        /// <summary>
        /// Image CropToMask.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? CropToMask
        {
            get;
            set;
        }
        /// <summary>
        /// Image FittingMode.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FittingModeType? FittingMode
        {
            get;
            set;
        }
        /// <summary>
        /// Image DesiredWidth.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? DesiredWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Image DesiredHeight.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? DesiredHeight
        {
            get;
            set;
        }
        /// <summary>
        /// Image WrapModeU.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WrapModeType? WrapModeX
        {
            get;
            set;
        }
        /// <summary>
        /// Image WrapModeV.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WrapModeType? WrapModeY
        {
            get;
            set;
        }

        /// <summary>
        /// Apply ViewAttributes to ImageView.
        /// </summary>
        public override void ApplyToView(View view, ControlStates state = ControlStates.Normal)
        {
            base.ApplyToView(view, state);

            ImageView imageView = view as ImageView;
            ImageAttributes imageAttrs = this;

            if (imageView != null && imageAttrs != null)
            {
                if (imageAttrs.ResourceURL?.GetValue(state) != null)
                {
                    imageView.ResourceUrl = imageAttrs.ResourceURL.GetValue(state);
                }
                if (imageAttrs.Border?.GetValue(state) != null)
                {
                    imageView.Border = imageAttrs.Border.GetValue(state);
                }
                if (imageAttrs.PreMultipliedAlpha != null)
                {
                    imageView.PreMultipliedAlpha = imageAttrs.PreMultipliedAlpha.Value;
                }
                if (imageAttrs.PixelArea != null)
                {
                    imageView.PixelArea = imageAttrs.PixelArea;
                }
                if (imageAttrs.BorderOnly != null)
                {
                    imageView.BorderOnly = imageAttrs.BorderOnly.Value;
                }
                if (imageAttrs.SynchronosLoading != null)
                {
                    imageView.SynchronosLoading = imageAttrs.SynchronosLoading.Value;
                }
                if (imageAttrs.OrientationCorrection != null)
                {
                    imageView.OrientationCorrection = imageAttrs.OrientationCorrection.Value;
                }
                if (imageAttrs.AlphaMaskURL?.GetValue(state) != null)
                {
                    imageView.AlphaMaskURL = imageAttrs.AlphaMaskURL.GetValue(state);
                }
                if (imageAttrs.CropToMask != null)
                {
                    imageView.CropToMask = imageAttrs.CropToMask.Value;
                }
                if (imageAttrs.FittingMode != null)
                {
                    imageView.FittingMode = imageAttrs.FittingMode.Value;
                }
                if (imageAttrs.DesiredWidth != null)
                {
                    imageView.DesiredWidth = imageAttrs.DesiredWidth.Value;
                }
                if (imageAttrs.DesiredHeight != null)
                {
                    imageView.DesiredHeight = imageAttrs.DesiredHeight.Value;
                }
                if (imageAttrs.WrapModeX != null)
                {
                    imageView.WrapModeU = imageAttrs.WrapModeX.Value;
                }
                if (imageAttrs.WrapModeY != null)
                {
                    imageView.WrapModeV = imageAttrs.WrapModeY.Value;
                }
            }
        }
    }
}
