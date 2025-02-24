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
        /// Default constructor of ImageVisual class.
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
                _outputVisualMap.Add(Visual.Property.Type, (int)Visual.Type.Image);
                _outputVisualMap.Add(ImageVisualProperty.URL, url);

                if (alphaMaskUrl != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.AlphaMaskURL, alphaMaskUrl);
                }

                if (auxiliaryImageUrl != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageURL, auxiliaryImageUrl);
                }

                if (fittingMode != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.FittingMode, (int)fittingMode);
                }

                if (samplingMode != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.SamplingMode, (int)samplingMode);
                }

                if (desiredWidth != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.DesiredWidth, (int)desiredWidth);
                }

                if (desiredHeight != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.DesiredHeight, (int)desiredHeight);
                }

                if (synchronousLoading != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.SynchronousLoading, (bool)synchronousLoading);
                }

                if (borderOnly != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.BorderOnly, (bool)borderOnly);
                }

                if (pixelArea != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.PixelArea, pixelArea);
                }

                if (wrapModeU != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.WrapModeU, (int)wrapModeU);
                }

                if (wrapModeV != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.WrapModeV, (int)wrapModeV);
                }

                if (maskContentScale != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.MaskContentScale, (float)maskContentScale);
                }

                if (cropToMask != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.CropToMask, (bool)cropToMask);
                }

                if (auxiliaryImageAlpha != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageAlpha, (float)auxiliaryImageAlpha);
                }

                if (releasePolicy != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.ReleasePolicy, (int)releasePolicy);
                }

                if (loadPolicy != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.LoadPolicy, (int)loadPolicy);
                }

                if (orientationCorrection != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.OrientationCorrection, (bool)orientationCorrection);
                }

                if (atlasing != null)
                {
                    _outputVisualMap.Add(ImageVisualProperty.Atlasing, (bool)atlasing);
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
