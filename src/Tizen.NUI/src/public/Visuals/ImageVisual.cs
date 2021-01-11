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
        private string _url = null;
        private string _alphaMaskUrl = null;
        private string _auxiliaryImageUrl = null;
        private FittingModeType? _fittingMode = null;
        private SamplingModeType? _samplingMode = null;
        private int? _desiredWidth = null;
        private int? _desiredHeight = null;
        private bool? _synchronousLoading = false;
        private bool? _borderOnly = null;
        private Vector4 _pixelArea = null;
        private WrapModeType? _wrapModeU = null;
        private WrapModeType? _wrapModeV = null;
        private float? _auxiliaryImageAlpha = null;
        private float? _maskContentScale = null;
        private bool? _cropToMask = null;
        private ReleasePolicyType? _releasePolicy = null;
        private LoadPolicyType? _loadPolicy = null;
        private bool? _orientationCorrection = true;
        private bool? _atlasing = false;

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
                return _url;
            }
            set
            {
                _url = (value == null ? "" : value);
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
                return _alphaMaskUrl;
            }
            set
            {
                _alphaMaskUrl = value;
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
                return _auxiliaryImageUrl;
            }
            set
            {
                _auxiliaryImageUrl = value;
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
                return _fittingMode ?? (FittingModeType.ShrinkToFit);
            }
            set
            {
                _fittingMode = value;
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
                return _samplingMode ?? (SamplingModeType.Box);
            }
            set
            {
                _samplingMode = value;
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
                return _desiredWidth ?? (-1);
            }
            set
            {
                _desiredWidth = value;
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
                return _desiredHeight ?? (-1);
            }
            set
            {
                _desiredHeight = value;
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
                return _synchronousLoading ?? (false);
            }
            set
            {
                _synchronousLoading = value;
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
                return _borderOnly ?? (false);
            }
            set
            {
                _borderOnly = value;
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
                return _pixelArea ?? (new Vector4(0.0f, 0.0f, 1.0f, 1.0f));
            }
            set
            {
                _pixelArea = value;
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
                return _wrapModeU ?? (WrapModeType.Default);
            }
            set
            {
                _wrapModeU = value;
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
                return _wrapModeV ?? (WrapModeType.Default);
            }
            set
            {
                _wrapModeV = value;
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
                return _maskContentScale ?? 1.0f;
            }
            set
            {
                _maskContentScale = value;
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
                return _cropToMask ?? false;
            }
            set
            {
                _cropToMask = value;
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
                return _auxiliaryImageAlpha ?? 1.0f;
            }
            set
            {
                _auxiliaryImageAlpha = value;
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
                return _releasePolicy ?? (ReleasePolicyType.Destroyed);
            }
            set
            {
                _releasePolicy = value;
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
                return _loadPolicy ?? (LoadPolicyType.Attached);
            }
            set
            {
                _loadPolicy = value;
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
                return _orientationCorrection ?? (true);
            }
            set
            {
                _orientationCorrection = value;
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
                return _atlasing ?? (false);
            }
            set
            {
                _atlasing = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (_url != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                if (_alphaMaskUrl != null) { _outputVisualMap.Add(ImageVisualProperty.AlphaMaskURL, new PropertyValue(_alphaMaskUrl)); }
                if (_auxiliaryImageUrl != null) { _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageURL, new PropertyValue(_auxiliaryImageUrl)); }
                if (_fittingMode != null) { _outputVisualMap.Add(ImageVisualProperty.FittingMode, new PropertyValue((int)_fittingMode)); }
                if (_samplingMode != null) { _outputVisualMap.Add(ImageVisualProperty.SamplingMode, new PropertyValue((int)_samplingMode)); }
                if (_desiredWidth != null) { _outputVisualMap.Add(ImageVisualProperty.DesiredWidth, new PropertyValue((int)_desiredWidth)); }
                if (_desiredHeight != null) { _outputVisualMap.Add(ImageVisualProperty.DesiredHeight, new PropertyValue((int)_desiredHeight)); }
                if (_synchronousLoading != null) { _outputVisualMap.Add(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)_synchronousLoading)); }
                if (_borderOnly != null) { _outputVisualMap.Add(ImageVisualProperty.BorderOnly, new PropertyValue((bool)_borderOnly)); }
                if (_pixelArea != null) { _outputVisualMap.Add(ImageVisualProperty.PixelArea, new PropertyValue(_pixelArea)); }
                if (_wrapModeU != null) { _outputVisualMap.Add(ImageVisualProperty.WrapModeU, new PropertyValue((int)_wrapModeU)); }
                if (_wrapModeV != null) { _outputVisualMap.Add(ImageVisualProperty.WrapModeV, new PropertyValue((int)_wrapModeV)); }
                if (_maskContentScale != null) { _outputVisualMap.Add(ImageVisualProperty.MaskContentScale, new PropertyValue((float)_maskContentScale)); }
                if (_cropToMask != null) { _outputVisualMap.Add(ImageVisualProperty.CropToMask, new PropertyValue((bool)_cropToMask)); }
                if (_auxiliaryImageAlpha != null) { _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageAlpha, new PropertyValue((float)_auxiliaryImageAlpha)); }
                if (_releasePolicy != null) { _outputVisualMap.Add(ImageVisualProperty.ReleasePolicy, new PropertyValue((int)_releasePolicy)); }
                if (_loadPolicy != null) { _outputVisualMap.Add(ImageVisualProperty.LoadPolicy, new PropertyValue((int)_loadPolicy)); }
                if (_orientationCorrection != null) { _outputVisualMap.Add(ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)_orientationCorrection)); }
                if (_atlasing != null) { _outputVisualMap.Add(ImageVisualProperty.Atlasing, new PropertyValue((bool)_atlasing)); }
                base.ComposingPropertyMap();
            }
        }
    }
}
