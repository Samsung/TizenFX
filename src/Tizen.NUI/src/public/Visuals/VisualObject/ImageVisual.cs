// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.NUI.Visuals
{
    /// <summary>
    /// The visual which can display an image resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageVisual : VisualBase
    {
        #region Internal And Private
        internal static readonly int ActionReload = Tizen.NUI.BaseComponents.ImageView.ActionReload;
        internal bool isResourceUrlValid = false;

        private PropertyMap temperalStoredPropertyMap = null; // To store property map when resource url is not valid.
        #endregion

        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal ImageVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal ImageVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.Image;
        }

        #region Visual Properties
        /// <summary>
        /// Gets or sets the URL of the image.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceUrl
        {
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    isResourceUrlValid = false;

                    UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.URL, null);

                    // Special behavior. If ResourceUrl is empty, unregister visual, and do not show anything.
                    UnregisterVisual();
                }
                else
                {
                    isResourceUrlValid = true;

                    UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.URL, new PropertyValue(value));

                    // Special case. If set GeneratedUrl, or FastTrackUploading, Create ImageVisual synchronously.
                    if (value.StartsWith("dali://") || value.StartsWith("enbuf://") || FastTrackUploading)
                    {
                        UpdateVisualPropertyMap();
                    }
                }
            }
            get
            {
                string ret = "";
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.URL);
                propertyValue?.Get(out ret);
                return ret;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PixelArea
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.PixelArea, new PropertyValue(value), false);
            }
            get
            {
                Vector4 ret = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.PixelArea);
                propertyValue?.Get(ret);
                return ret;
            }
        }

        /// <summary>
        /// ImageView PreMultipliedAlpha, type Boolean.<br />
        /// Image must be initialized.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PreMultipliedAlpha
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.PremultipliedAlpha, new PropertyValue(value), true);
            }
            get
            {
                bool ret = true;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.PremultipliedAlpha);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Synchronously load the image for the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SynchronousLoading
        {
            set
            {
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.SynchronousLoading, new PropertyValue(value), value);
            }
            get
            {
                bool ret = false;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.SynchronousLoading);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets whether to automatically correct the orientation of an image.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrientationCorrection
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.OrientationCorrection, new PropertyValue(value), true);
            }
            get
            {
                bool ret = true;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.OrientationCorrection);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the URL of the alpha mask.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AlphaMaskURL
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.AlphaMaskURL, string.IsNullOrEmpty(value) ? null : new PropertyValue(value));
            }
            get
            {
                string ret = "";
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.AlphaMaskURL);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets scale factor to apply to the content image before masking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaskContentScale
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.MaskContentScale, new PropertyValue(value));
            }
            get
            {
                float ret = 1.0f;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.MaskContentScale);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        ///  Whether to crop image to mask or scale mask to fit image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CropToMask
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.CropToMask, new PropertyValue(value));
            }
            get
            {
                bool ret = false;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.CropToMask);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets whether to apply mask on GPU or not.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.BaseComponents.ImageView.MaskingModeType MaskingMode
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.MaskingMode, new PropertyValue((int)value));
            }
            get
            {
                int ret = (int)Tizen.NUI.BaseComponents.ImageView.MaskingModeType.MaskingOnLoading;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.MaskingMode);
                propertyValue?.Get(out ret);
                return (Tizen.NUI.BaseComponents.ImageView.MaskingModeType)ret;
            }
        }

        /// <summary>
        /// Gets or sets whether to apply fast track uploading or not.<br />
        /// </summary>
        /// <remarks>
        /// If we use fast track uploading feature, It can upload texture without event-thead dependency. But also,<br />
        ///  - Texture size is invalid until ResourceReady signal comes.<br />
        ///  - Texture cannot be cached (We always try to load new image).<br />
        ///  - Seamless visual change didn't supported.<br />
        ///  - Alpha masking didn't supported. If you try, It will load as normal case.<br />
        ///  - Synchronous loading didn't supported. If you try, It will load as normal case.<br />
        ///  - Reload action didn't supported. If you try, It will load as normal case.<br />
        ///  - Atlas loading didn't supported. If you try, It will load as normal case.<br />
        ///  - Custom shader didn't supported. If you try, It will load as normal case.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FastTrackUploading
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.FastTrackUploading, new PropertyValue(value));

                if (value && !string.IsNullOrEmpty(ResourceUrl))
                {
                    // Special case. If user set FastTrackUploading mean, user want to upload image As-Soon-As-Possible.
                    // Create ImageVisual synchronously.
                    UpdateVisualPropertyMap();
                }
            }
            get
            {
                bool ret = false;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.FastTrackUploading);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the Image Visual release policy.<br/>
        /// It decides if a texture should be released from the cache or kept to reduce the loading time.<br/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReleasePolicyType ReleasePolicy
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.ReleasePolicy, new PropertyValue((int)value));
            }
            get
            {
                int ret = (int)ReleasePolicyType.Detached;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.ReleasePolicy);
                propertyValue?.Get(out ret);
                return (ReleasePolicyType)ret;
            }
        }

        /// <summary>
        /// Gets or sets the desired image width.<br />
        /// If not specified, the actual image width is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DesiredWidth
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.DesiredWidth, new PropertyValue(value));
            }
            get
            {
                int ret = -1;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.DesiredWidth);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the desired image height.<br />
        /// If not specified, the actual image height is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DesiredHeight
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.DesiredHeight, new PropertyValue(value));
            }
            get
            {
                int ret = -1;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.DesiredHeight);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the Image Visual image loading policy.<br />
        /// It decides if a texture should be loaded immediately after source set or only after the visual is added to the window.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadPolicyType LoadPolicy
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.LoadPolicy, new PropertyValue((int)value));
            }
            get
            {
                int ret = (int)LoadPolicyType.Attached;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.LoadPolicy);
                propertyValue?.Get(out ret);
                return (LoadPolicyType)ret;
            }
        }

        /// <summary>
        /// Gets or sets the wrap mode for the u coordinate.<br />
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WrapModeType WrapModeU
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.WrapModeU, new PropertyValue((int)value));
            }
            get
            {
                int ret = (int)WrapModeType.Default;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.WrapModeU);
                propertyValue?.Get(out ret);
                return (WrapModeType)ret;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WrapModeType WrapModeV
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.WrapModeV, new PropertyValue((int)value));
            }
            get
            {
                int ret = (int)WrapModeType.Default;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.WrapModeV);
                propertyValue?.Get(out ret);
                return (WrapModeType)ret;
            }
        }
        #endregion

        #region Decorated Visual Properties
        /// <summary>
        /// The radius for the rounded corners of the visual.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        /// Each radius will clamp internally to the half of smaller of the visual's width or height.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 CornerRadius
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadius, new PropertyValue(value), false);
            }
            get
            {
                Vector4 ret = new Vector4();
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadius);
                propertyValue?.Get(ret);
                return ret;
            }
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 0.5f] of the visual size) or absolute (in world units).
        /// It is absolute by default.
        /// When the policy is relative, the corner radius is relative to the smaller of the visual's width and height.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualTransformPolicyType CornerRadiusPolicy
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadiusPolicy, new PropertyValue((int)value), false);
            }
            get
            {
                int ret = (int)VisualTransformPolicyType.Absolute;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadiusPolicy);
                propertyValue?.Get(out ret);
                return (VisualTransformPolicyType)ret;
            }
        }

        /// <summary>
        /// The width for the borderline of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderlineWidth
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineWidth, new PropertyValue(value), false);
            }
            get
            {
                float ret = 0.0f;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineWidth);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The color for the borderline of the visual.
        /// It is Color.Black by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BorderlineColor
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineColor, new PropertyValue(value), false);
            }
            get
            {
                Color ret = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineColor);
                propertyValue?.Get(ret);
                return ret;
            }
        }

        /// <summary>
        /// The Relative offset for the borderline of the visual.
        /// Recommended range : [-1.0f to 1.0f].
        /// If -1.0f, draw borderline inside of the visual.
        /// If 1.0f, draw borderline outside of the visual.
        /// If 0.0f, draw borderline half inside and half outside.
        /// It is 0.0f by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderlineOffset
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineOffset, new PropertyValue(value), false);
            }
            get
            {
                float ret = 0.0f;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineOffset);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Reload image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reload()
        {
            Interop.VisualObject.DoActionWithEmptyAttributes(SwigCPtr, ActionReload);
        }
        #endregion

        #region Internal Methods
        internal override void OnUpdateVisualPropertyMap()
        {
            // We should not create visual if url is invalid.
            if (!isResourceUrlValid)
            {
                temperalStoredPropertyMap = cachedVisualPropertyMap;
                cachedVisualPropertyMap = null;
            }
        }

        internal override void OnVisualCreated()
        {
            if (temperalStoredPropertyMap != null)
            {
                cachedVisualPropertyMap = temperalStoredPropertyMap;
                temperalStoredPropertyMap = null;
            }
        }
        #endregion
    }
}