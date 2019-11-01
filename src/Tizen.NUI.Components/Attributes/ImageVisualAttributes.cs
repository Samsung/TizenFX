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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ImageVisualAttributes is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageVisualAttributes : VisualAttributes
    {
        /// <summary>
        /// Creates a new instance of a ImageVisualAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageVisualAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a VisualAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create ButtonAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageVisualAttributes(ImageVisualAttributes attributes) : base(attributes)
        {
            if (null == attributes)
            {
                return;
            }

            ResourceURL = attributes.ResourceURL?.Clone() as StringSelector;
            AlphaMaskURL = attributes.AlphaMaskURL?.Clone() as StringSelector;
            AuxiliaryImageURL = attributes.AuxiliaryImageURL?.Clone() as StringSelector;
            FittingMode = attributes.FittingMode;
            SamplingMode = attributes.SamplingMode;
            DesiredWidth = attributes.DesiredWidth;
            DesiredHeight = attributes.DesiredHeight;
            SynchronousLoading = attributes.SynchronousLoading;
            BorderOnly = attributes.BorderOnly;
            PixelArea = attributes.PixelArea;
            WrapModeU = attributes.WrapModeU;
            WrapModeV = attributes.WrapModeV;
            MaskContentScale = attributes.MaskContentScale;
            CropToMask = attributes.CropToMask;
            AuxiliaryImageAlpha = attributes.AuxiliaryImageAlpha;
            ReleasePolicy = attributes.ReleasePolicy;
            LoadPolicy = attributes.LoadPolicy;
            OrientationCorrection = attributes.OrientationCorrection;
            Atlasing = attributes.Atlasing;
        }

        /// <summary>
        /// Gets or sets the URL of the image.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StringSelector ResourceURL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL of the alpha mask.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StringSelector AlphaMaskURL
        {
            get;
            set;
        }

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// The resulting visual image will be at least as large as the smallest possible n-patch or the auxiliary image, whichever is larger.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public StringSelector AuxiliaryImageURL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets fitting options used when resizing images to fit the desired dimensions.<br />
        /// If not supplied, the default is FittingModeType.ShrinkToFit.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FittingModeType? FittingMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets filtering options used when resizing images to the sample original pixels.<br />
        /// If not supplied, the default is SamplingModeType.Box.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SamplingModeType? SamplingMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the desired image width.<br />
        /// If not specified, the actual image width is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int? DesiredWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the desired image height.<br />
        /// If not specified, the actual image height is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int? DesiredHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to load the image synchronously.<br />
        /// If not specified, the default is false, i.e., the image is loaded asynchronously.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool? SynchronousLoading
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to draw the borders only (If true).<br />
        /// If not specified, the default is false.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool? BorderOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image area to be displayed.<br />
        /// It is a rectangular area.<br />
        /// The first two elements indicate the top-left position of the area, and the last two elements are the areas of the width and the height respectively.<br />
        /// If not specified, the default value is Vector4 (0.0, 0.0, 1.0, 1.0), i.e., the entire area of the image.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PixelArea
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wrap mode for the u coordinate.<br />
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WrapModeType? WrapModeU
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wrap mode for the v coordinate.<br />
        /// It decides how the texture should be sampled when the v coordinate exceeds the range of 0.0 to 1.0.<br />
        /// The first two elements indicate the top-left position of the area, and the last two elements are the areas of the width and the height respectively.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WrapModeType? WrapModeV
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets scale factor to apply to the content image before masking.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float? MaskContentScale
        {
            get;
            set;
        }

        /// <summary>
        ///  Whether to crop image to mask or scale mask to fit image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool? CropToMask
        {
            get;
            set;
        }

        /// <summary>
        ///  An alpha value for mixing between the masked main NPatch image and the auxiliary image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float? AuxiliaryImageAlpha
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Image Visual release policy.<br/>
        /// It decides if a texture should be released from the cache or kept to reduce the loading time.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ReleasePolicyType? ReleasePolicy
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the Image Visual image loading policy.<br />
        /// It decides if a texture should be loaded immediately after source set or only after the visual is added to the window.<br />
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public LoadPolicyType? LoadPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to automatically correct the orientation based on the Exchangeable Image File (EXIF) data.<br />
        /// If not specified, the default is true.<br />
        /// For JPEG images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool? OrientationCorrection
        {
            get;
            set;
        }

        /// <summary>
        /// Whether to use the texture atlas or not.
        /// Optional. By default atlasing is off.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool? Atlasing
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new ImageVisualAttributes(this);
        }
    }
}
