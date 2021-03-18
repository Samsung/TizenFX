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

#if (NUI_DEBUG_ON)
using tlog = Tizen.Log;
#endif

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// AnimatedImageView is a class for displaying Animated-GIF and Image-Array
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimatedImageView : ImageView
    {
        #region Constructor, Destructor, Dispose
        /// <summary>
        /// Construct AnimatedImageView
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedImageView() : base()
        {
            dirtyFlag = true;
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
        /// Image URL for Animated-GIF
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string ResourceUrl
        {
            get
            {
                return url;
            }
            set
            {
                dirtyFlag = true;
                url = value;
            }
        }

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
                return batchSize;
            }
            set
            {
                dirtyFlag = true;
                batchSize = value;
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
                return cacheSize;
            }
            set
            {
                dirtyFlag = true;
                cacheSize = value;
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
                return frameDelay;
            }
            set
            {
                dirtyFlag = true;
                frameDelay = value;
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
                return loopCount;
            }
            set
            {
                dirtyFlag = true;
                loopCount = value;
            }
        }

        /// <summary>
        /// Sets or gets the stop behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StopBehaviorType StopBehavior
        {
            set
            {
                stopBehavior = (StopBehaviorType)value;
                dirtyFlag = true;
            }
            get
            {
                return stopBehavior;
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
                PropertyMap map = Image;
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
            set
            {
                DoAction(ImageView.Property.IMAGE, (int)ActionType.jumpTo, new PropertyValue(value));
            }
            get
            {
                int ret = -1;
                PropertyMap map = Image;
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
            if (dirtyFlag == false)
            {
                return;
            }
            dirtyFlag = false;

            PropertyMap tMap = new PropertyMap();
            PropertyValue animatiedImage = new PropertyValue((int)Visual.Type.AnimatedImage);
            tMap.Insert(Visual.Property.Type, animatiedImage);
            if (resourceURLs?.Count != 0)
            {
                PropertyArray indexPropertyArray = new PropertyArray();
                PropertyArray returnedArr = new PropertyArray();
                PropertyValue index = new PropertyValue();
                foreach (var iter in resourceURLs)
                {
                    index = new PropertyValue(iter);
                    returnedArr = indexPropertyArray.Add(index);
                }
                index.Dispose();
                returnedArr.Dispose();
                PropertyValue arrayProperty = new PropertyValue(indexPropertyArray);
                tMap.Insert(ImageVisualProperty.URL, arrayProperty);
                PropertyValue frameDelayProperty = new PropertyValue(frameDelay);
                tMap.Insert(ImageVisualProperty.FrameDelay, frameDelayProperty);

                arrayProperty.Dispose();
                indexPropertyArray.Dispose();
                frameDelayProperty.Dispose();
            }
            else
            {
                PropertyValue urlProperty = new PropertyValue(url);
                tMap.Insert(ImageVisualProperty.URL, urlProperty);
                urlProperty.Dispose();
            }

            PropertyValue batchSizeProperty = new PropertyValue(batchSize);
            tMap.Insert(ImageVisualProperty.BatchSize, batchSizeProperty);
            PropertyValue cacheSizeProperty = new PropertyValue(cacheSize);
            tMap.Insert(ImageVisualProperty.CacheSize, cacheSizeProperty);
            PropertyValue loopCountProperty = new PropertyValue(loopCount);
            tMap.Insert(ImageVisualProperty.LoopCount, loopCountProperty);
            PropertyValue stopBehaviorProperty = new PropertyValue((int)stopBehavior);
            tMap.Insert(ImageVisualProperty.StopBehavior, stopBehaviorProperty);

            loopCountProperty.Dispose();
            cacheSizeProperty.Dispose();
            batchSizeProperty.Dispose();
            stopBehaviorProperty.Dispose();

            propertyMap = tMap;
            PropertyValue mapProperty = new PropertyValue(propertyMap);
            SetProperty(ImageView.Property.IMAGE, mapProperty);
            mapProperty.Dispose();

            tMap.Dispose();
            animatiedImage.Dispose();
        }

        /// <summary>
        /// Play animation
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Play()
        {
            SetValues();
            base.Play();
        }

        /// <summary>
        /// Pause animation. Currently pause and stop are same
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Pause()
        {
            SetValues();
            base.Pause();
        }

        /// <summary>
        /// Stop animation. Currently pause and stop are same
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Stop()
        {
            SetValues();
            base.Stop();
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

        private enum ActionType
        {
            play,
            pause,
            stop,
            jumpTo,
        };
        #endregion Event, Enum, Struct, ETC


        #region Internal
        #endregion Internal


        #region Private
        private string url = "";
        private List<string> resourceURLs = new List<string>();
        private int batchSize = 1;
        private int cacheSize = 1;
        private int frameDelay = 0;
        private int loopCount = -1;
        private bool dirtyFlag = false;
        private StopBehaviorType stopBehavior;
        private PropertyMap propertyMap;
        #endregion Private
    }
}
