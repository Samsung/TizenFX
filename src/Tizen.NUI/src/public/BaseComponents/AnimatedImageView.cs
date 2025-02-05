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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AnimatedImageView is a class for displaying Animated-GIF and Image-Array
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AnimatedImageView : ImageView
    {
        #region Internal
        /// <summary>
        /// Actions property value to Jump to the specified frame.
        /// </summary>
        internal static readonly int ActionJumpTo = Interop.AnimatedImageView.AnimatedImageVisualActionJumpToGet();
        #endregion Internal

        #region Private
        // Collection of animated-image-sensitive properties.
        private static readonly List<int> cachedAnimatedImagePropertyKeyList = new List<int> {
            ImageVisualProperty.BatchSize,
            ImageVisualProperty.CacheSize,
            ImageVisualProperty.FrameDelay,
            ImageVisualProperty.LoopCount,
            ImageVisualProperty.StopBehavior,
            ImageVisualProperty.FrameSpeedFactor,
        };
        private List<string> resourceURLs = new List<string>();
        #endregion Private

        #region Constructor, Destructor, Dispose
        /// <summary>
        /// Construct AnimatedImageView
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedImageView() : base()
        {
        }

        /// <summary>
        /// You can override it to clean-up your own resources
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            base.Dispose(type);
        }
        #endregion Constructor, Destructor, Dispose

        #region Property
        /// <summary>
        ///  Image URL list for Image-Array
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<string> URLs
        {
            get
            {
                return resourceURLs;
            }
        }

        /// <summary>
        /// Defines the batch size for pre-loading images in the Image-Array animation.
        /// number of images to pre-load before starting to play. Default value: 1.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BatchSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(BatchSizeProperty);
                }
                else
                {
                    return (int)GetInternalBatchSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BatchSizeProperty, value);
                }
                else
                {
                    SetInternalBatchSizeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalBatchSize
        {
            get
            {
                int ret = 1;

                PropertyValue batchSize = GetCachedImageVisualProperty(ImageVisualProperty.BatchSize);
                batchSize?.Get(out ret);
                batchSize?.Dispose();

                return ret;
            }
            set
            {
                using PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.BatchSize, setValue);
            }
        }

        /// <summary>
        /// Defines the cache size for loading images in the Image-Array animation.
        /// number of images to keep cached ahead during playback. Default value: 1.
        ///</summary>
        ///<remarks>
        /// cacheSize should be >= batchSize. If it isn't, then the cache will automatically be changed to batchSize.
        /// because of the defaults, it is expected that the application developer tune the batch and cache sizes to their particular use case.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CacheSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CacheSizeProperty);
                }
                else
                {
                    return (int)GetInternalCacheSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CacheSizeProperty, value);
                }
                else
                {
                    SetInternalCacheSizeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalCacheSize
        {
            get
            {
                int ret = 1;

                PropertyValue cacheSize = GetCachedImageVisualProperty(ImageVisualProperty.CacheSize);
                cacheSize?.Get(out ret);
                cacheSize?.Dispose();

                return ret;
            }
            set
            {
                using PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.CacheSize, setValue);
            }
        }

        /// <summary>
        /// The number of milliseconds between each frame in the Image-Array animation.
        /// The number of milliseconds between each frame.
        /// </summary>
        /// <remarks>
        /// This is only used when URLs(multiple string) are provided.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FrameDelay
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(FrameDelayProperty);
                }
                else
                {
                    return (int)GetInternalFrameDelayProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FrameDelayProperty, value);
                }
                else
                {
                    SetInternalFrameDelayProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalFrameDelay
        {
            get
            {
                int ret = 0;

                PropertyValue frameDelay = GetCachedImageVisualProperty(ImageVisualProperty.FrameDelay);
                frameDelay?.Get(out ret);
                frameDelay?.Dispose();

                return ret;
            }
            set
            {
                using PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.FrameDelay, setValue);
            }
        }

        /// <summary>
        /// The number of looping.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LoopCount
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(LoopCountProperty);
                }
                else
                {
                    return (int)GetInternalLoopCountProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LoopCountProperty, value);
                }
                else
                {
                    SetInternalLoopCountProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalLoopCount
        {
            get
            {
                int ret = -1;

                PropertyValue loopCount = GetCachedImageVisualProperty(ImageVisualProperty.LoopCount);
                loopCount?.Get(out ret);
                loopCount?.Dispose();

                return ret;
            }
            set
            {
                using PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.LoopCount, setValue);
            }
        }

        /// <summary>
        /// Sets or gets the stop behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StopBehaviorType StopBehavior
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (StopBehaviorType)GetValue(StopBehaviorProperty);
                }
                else
                {
                    return (StopBehaviorType)GetInternalStopBehaviorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(StopBehaviorProperty, value);
                }
                else
                {
                    SetInternalStopBehaviorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private StopBehaviorType InternalStopBehavior
        {
            get
            {
                int ret = 0;

                PropertyValue stopBehavior = GetCachedImageVisualProperty(ImageVisualProperty.StopBehavior);
                stopBehavior?.Get(out ret);
                stopBehavior?.Dispose();

                return (StopBehaviorType)ret;
            }
            set
            {
                using PropertyValue setValue = new PropertyValue((int)value);
                UpdateImage(ImageVisualProperty.StopBehavior, setValue);
            }
        }

        /// <summary>
        /// Specifies a speed factor for the animated image frame.
        /// </summary>
        /// <remarks>
        /// The speed factor is a multiplier of the normal velocity of the animation. Values between [0,1] will
        /// slow down the animation and values above one will speed up the animation.
        ///
        /// The range of this value is clamped between [0.01f ~ 100.0f].
        ///
        /// Inhouse API.
        /// The default is 1.0f.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FrameSpeedFactor
        {
            get
            {
                return InternalFrameSpeedFactor;
            }
            set
            {
                InternalFrameSpeedFactor = value;
                NotifyPropertyChanged();
            }
        }

        private float InternalFrameSpeedFactor
        {
            get
            {
                float ret = 1.0f;

                using PropertyValue frameSpeedFactor = GetCachedImageVisualProperty(ImageVisualProperty.FrameSpeedFactor);
                frameSpeedFactor?.Get(out ret);

                return ret;
            }
            set
            {
                using PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.FrameSpeedFactor, setValue);
            }
        }

        /// <summary>
        /// Get the number of total frames
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TotalFrame
        {
            get
            {
                int ret = -1;
                PropertyMap map = base.Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.TotalFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            return ret;
                        }
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Set or get the current frame. When setting a specific frame, it is displayed as a still image.
        /// </summary>
        /// <remarks>
        /// Gets the value set by a user. If the setting value is out-ranged, it is reset as a minimum frame or a maximum frame.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentFrame
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CurrentFrameProperty);
                }
                else
                {
                    return (int)GetInternalCurrentFrameProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CurrentFrameProperty, value);
                }
                else
                {
                    SetInternalCurrentFrameProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalCurrentFrame
        {
            set
            {
                // Sync as current properties
                UpdateImage();

                DoAction(ImageView.Property.IMAGE, ActionJumpTo, new PropertyValue(value));
            }
            get
            {
                int ret = -1;
                PropertyMap map = base.Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.CurrentFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            return ret;
                        }
                    }
                }
                return ret;
            }
        }
        #endregion Property

        #region Method
        /// <summary>
        /// To make the properies be set. This should be called after the properties are set.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValues()
        {
            // This API assume that Animated relative properties setuped forcely.
            imagePropertyUpdatedFlag = true;

            // Sync as current properties
            UpdateImage();
        }

        /// <summary>
        /// Update animated-image-relative properties synchronously.
        /// After call this API, All image properties updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void UpdateImage()
        {
            if (Disposed)
            {
                return;
            }

            if (!imagePropertyUpdatedFlag) return;

            // Assume that we are using standard Image at first.
            // (Since we might cache Visual.Property.Type as Visual.Type.AnimatedImage even we don't use URLs.)
            using (PropertyValue imageType = new PropertyValue((int)Visual.Type.Image))
            {
                UpdateImage(Visual.Property.Type, imageType, false);
            }

            if (resourceURLs != null && resourceURLs.Count != 0)
            {
                using (PropertyArray indexPropertyArray = new PropertyArray())
                {
                    PropertyArray returnedArr = new PropertyArray();
                    foreach (var iter in resourceURLs)
                    {
                        using (PropertyValue index = new PropertyValue(iter))
                        {
                            returnedArr = indexPropertyArray.Add(index);
                        }
                    }
                    returnedArr.Dispose();
                    using PropertyValue arrayProperty = new PropertyValue(indexPropertyArray);

                    // Trigger the ImageView so that we have something update
                    UpdateImage(ImageVisualProperty.URL, arrayProperty, false);
                }

                // Trick that we are using resourceURLs without ResourceUrl API.
                using PropertyValue animatiedImage = new PropertyValue((int)Visual.Type.AnimatedImage);
                UpdateImage(Visual.Property.Type, animatiedImage, false);
            }

            base.UpdateImage();
        }

        /// <summary>
        /// Update NUI cached animated image visual property map by inputed property map.
        /// And call base.MergeCachedImageVisualProperty()
        /// </summary>
        /// <remarks>
        /// For performance issue, we will collect only "cachedAnimatedImagePropertyKeyList" hold in this class.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void MergeCachedImageVisualProperty(PropertyMap map)
        {
            if (map == null) return;
            if (cachedImagePropertyMap == null)
            {
                cachedImagePropertyMap = new PropertyMap();
            }
            foreach (var key in cachedAnimatedImagePropertyKeyList)
            {
                PropertyValue value = map.Find(key);
                if (value != null)
                {
                    // Update-or-Insert new value
                    cachedImagePropertyMap[key] = value;
                }
            }
            base.MergeCachedImageVisualProperty(map);
        }
        #endregion Method

        #region Event, Enum, Struct, ETC

        /// <summary>
        /// Enumeration for what to do when the animation is stopped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum StopBehaviorType
        {
            /// <summary>
            /// When the animation is stopped, the current frame is shown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            CurrentFrame,
            /// <summary>
            /// When the animation is stopped, the min frame (first frame) is shown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MinimumFrame,
            /// <summary>
            /// When the animation is stopped, the max frame (last frame) is shown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MaximumFrame
        }

        #endregion Event, Enum, Struct, ETC
    }
}
