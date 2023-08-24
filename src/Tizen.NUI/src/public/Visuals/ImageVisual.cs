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

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the image visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ImageVisual : VisualMap
    {
        private string url = null;
        private string alphaMaskUrl = null;
        private string auxiliaryImageUrl = null;
        private FittingModeType? fittingMode = null;
        private SamplingModeType? samplingMode = null;
        private int? desiredWidth = null;
        private int? desiredHeight = null;
        private bool? synchronousLoading = false;
        private bool? borderOnly = null;
        private Vector4 pixelArea = null;
        private WrapModeType? wrapModeU = null;
        private WrapModeType? wrapModeV = null;
        private float? auxiliaryImageAlpha = null;
        private float? maskContentScale = null;
        private bool? cropToMask = null;
        private ReleasePolicyType? releasePolicy = null;
        private LoadPolicyType? loadPolicy = null;
        private bool? orientationCorrection = true;
        private bool? atlasing = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the URL of the image.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = (value == null ? "" : value);
                UpdateVisual();
            }
        }


        /// <summary>
        /// Gets or sets the URL of the alpha mask.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string AlphaMaskURL
        {
            get
            {
                return alphaMaskUrl;
            }
            set
            {
                alphaMaskUrl = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// The resulting visual image will be at least as large as the smallest possible n-patch or the auxiliary image, whichever is larger.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string AuxiliaryImageURL
        {
            get
            {
                return auxiliaryImageUrl;
            }
            set
            {
                auxiliaryImageUrl = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets fitting options used when resizing images to fit the desired dimensions.<br />
        /// If not supplied, the default is FittingModeType.ShrinkToFit.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FittingModeType FittingMode
        {
            get
            {
                return fittingMode ?? (FittingModeType.ShrinkToFit);
            }
            set
            {
                fittingMode = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets filtering options used when resizing images to the sample original pixels.<br />
        /// If not supplied, the default is SamplingModeType.Box.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SamplingModeType SamplingMode
        {
            get
            {
                return samplingMode ?? (SamplingModeType.Box);
            }
            set
            {
                samplingMode = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the desired image width.<br />
        /// If not specified, the actual image width is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DesiredWidth
        {
            get
            {
                return desiredWidth ?? (-1);
            }
            set
            {
                desiredWidth = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the desired image height.<br />
        /// If not specified, the actual image height is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DesiredHeight
        {
            get
            {
                return desiredHeight ?? (-1);
            }
            set
            {
                desiredHeight = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to load the image synchronously.<br />
        /// If not specified, the default is false, i.e., the image is loaded asynchronously.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool SynchronousLoading
        {
            get
            {
                return synchronousLoading ?? (false);
            }
            set
            {
                synchronousLoading = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to draw the borders only (If true).<br />
        /// If not specified, the default is false.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool BorderOnly
        {
            get
            {
                return borderOnly ?? (false);
            }
            set
            {
                borderOnly = value;
                UpdateVisual();
            }
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
            get
            {
                return pixelArea ?? (new Vector4(0.0f, 0.0f, 1.0f, 1.0f));
            }
            set
            {
                pixelArea = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the wrap mode for the u coordinate.<br />
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WrapModeType WrapModeU
        {
            get
            {
                return wrapModeU ?? (WrapModeType.Default);
            }
            set
            {
                wrapModeU = value;
                UpdateVisual();
            }
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
        public WrapModeType WrapModeV
        {
            get
            {
                return wrapModeV ?? (WrapModeType.Default);
            }
            set
            {
                wrapModeV = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets scale factor to apply to the content image before masking.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float MaskContentScale
        {
            get
            {
                return maskContentScale ?? 1.0f;
            }
            set
            {
                maskContentScale = value;
                UpdateVisual();
            }
        }

        /// <summary>
        ///  Whether to crop image to mask or scale mask to fit image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool CropToMask
        {
            get
            {
                return cropToMask ?? false;
            }
            set
            {
                cropToMask = value;
                UpdateVisual();
            }
        }

        /// <summary>
        ///  An alpha value for mixing between the masked main NPatch image and the auxiliary image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float AuxiliaryImageAlpha
        {
            get
            {
                return auxiliaryImageAlpha ?? 1.0f;
            }
            set
            {
                auxiliaryImageAlpha = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the Image Visual release policy.<br/>
        /// It decides if a texture should be released from the cache or kept to reduce the loading time.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ReleasePolicyType ReleasePolicy
        {
            get
            {
                return releasePolicy ?? (ReleasePolicyType.Destroyed);
            }
            set
            {
                releasePolicy = value;
                UpdateVisual();
            }
        }


        /// <summary>
        /// Gets or sets the Image Visual image loading policy.<br />
        /// It decides if a texture should be loaded immediately after source set or only after the visual is added to the window.<br />
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public LoadPolicyType LoadPolicy
        {
            get
            {
                return loadPolicy ?? (LoadPolicyType.Attached);
            }
            set
            {
                loadPolicy = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to automatically correct the orientation based on the Exchangeable Image File (EXIF) data.<br />
        /// If not specified, the default is true.<br />
        /// For JPEG images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool OrientationCorrection
        {
            get
            {
                return orientationCorrection ?? (true);
            }
            set
            {
                orientationCorrection = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Whether to use the texture atlas or not.
        /// Optional. By default atlasing is off.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool Atlasing
        {
            get
            {
                return atlasing ?? (false);
            }
            set
            {
                atlasing = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (url != null)
            {
                _outputVisualMap = new PropertyMap();
                PropertyValue temp = new PropertyValue((int)Visual.Type.Image);
                _outputVisualMap.Add(Visual.Property.Type, temp);
                temp.Dispose();

                temp = new PropertyValue(url);
                _outputVisualMap.Add(ImageVisualProperty.URL, temp);
                temp.Dispose();

                if (alphaMaskUrl != null)
                {
                    temp = new PropertyValue(alphaMaskUrl);
                    _outputVisualMap.Add(ImageVisualProperty.AlphaMaskURL, temp);
                    temp.Dispose();
                }

                if (auxiliaryImageUrl != null)
                {
                    temp = new PropertyValue(auxiliaryImageUrl);
                    _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageURL, temp);
                    temp.Dispose();
                }

                if (fittingMode != null)
                {
                    temp = new PropertyValue((int)fittingMode);
                    _outputVisualMap.Add(ImageVisualProperty.FittingMode, temp);
                    temp.Dispose();
                }

                if (samplingMode != null)
                {
                    temp = new PropertyValue((int)samplingMode);
                    _outputVisualMap.Add(ImageVisualProperty.SamplingMode, temp);
                    temp.Dispose();
                }

                if (desiredWidth != null)
                {
                    temp = new PropertyValue((int)desiredWidth);
                    _outputVisualMap.Add(ImageVisualProperty.DesiredWidth, temp);
                    temp.Dispose();
                }

                if (desiredHeight != null)
                {
                    temp = new PropertyValue((int)desiredHeight);
                    _outputVisualMap.Add(ImageVisualProperty.DesiredHeight, temp);
                    temp.Dispose();
                }

                if (synchronousLoading != null)
                {
                    temp = new PropertyValue((bool)synchronousLoading);
                    _outputVisualMap.Add(ImageVisualProperty.SynchronousLoading, temp);
                    temp.Dispose();
                }

                if (borderOnly != null)
                {
                    temp = new PropertyValue((bool)borderOnly);
                    _outputVisualMap.Add(ImageVisualProperty.BorderOnly, temp);
                    temp.Dispose();
                }

                if (pixelArea != null)
                {
                    temp = new PropertyValue(pixelArea);
                    _outputVisualMap.Add(ImageVisualProperty.PixelArea, temp);
                    temp.Dispose();
                }

                if (wrapModeU != null)
                {
                    temp = new PropertyValue((int)wrapModeU);
                    _outputVisualMap.Add(ImageVisualProperty.WrapModeU, temp);
                    temp.Dispose();
                }

                if (wrapModeV != null)
                {
                    temp = new PropertyValue((int)wrapModeV);
                    _outputVisualMap.Add(ImageVisualProperty.WrapModeV, temp);
                    temp.Dispose();
                }

                if (maskContentScale != null)
                {
                    temp = new PropertyValue((float)maskContentScale);
                    _outputVisualMap.Add(ImageVisualProperty.MaskContentScale, temp);
                    temp.Dispose();
                }

                if (cropToMask != null)
                {
                    temp = new PropertyValue((bool)cropToMask);
                    _outputVisualMap.Add(ImageVisualProperty.CropToMask, temp);
                    temp.Dispose();
                }

                if (auxiliaryImageAlpha != null)
                {
                    temp = new PropertyValue((float)auxiliaryImageAlpha);
                    _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageAlpha, temp);
                    temp.Dispose();
                }

                if (releasePolicy != null)
                {
                    temp = new PropertyValue((int)releasePolicy);
                    _outputVisualMap.Add(ImageVisualProperty.ReleasePolicy, temp);
                    temp.Dispose();
                }

                if (loadPolicy != null)
                {
                    temp = new PropertyValue((int)loadPolicy);
                    _outputVisualMap.Add(ImageVisualProperty.LoadPolicy, temp);
                    temp.Dispose();
                }

                if (orientationCorrection != null)
                {
                    temp = new PropertyValue((bool)orientationCorrection);
                    _outputVisualMap.Add(ImageVisualProperty.OrientationCorrection, temp);
                    temp.Dispose();
                }

                if (atlasing != null)
                {
                    temp = new PropertyValue((bool)atlasing);
                    _outputVisualMap.Add(ImageVisualProperty.Atlasing, temp);
                    temp.Dispose();
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
