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
        #region Constructor, Distructor, Dispose
        /// <summary>
        /// Construct AnimatedImageView
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedImageView() : base()
        {
            mDirtyFlag = true;
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
        #endregion Constructor, Distructor, Dispose

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
                return mUrl;
            }
            set
            {
                mDirtyFlag = true;
                mUrl = value;
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
                return mResourceURLs;
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
                return mBatchSize;
            }
            set
            {
                mDirtyFlag = true;
                mBatchSize = value;
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
                return mCacheSize;
            }
            set
            {
                mDirtyFlag = true;
                mCacheSize = value;
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
                return mFrameDelay;
            }
            set
            {
                mDirtyFlag = true;
                mFrameDelay = value;
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
                return mLoopCount;
            }
            set
            {
                mDirtyFlag = true;
                mLoopCount = value;
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
            if (mDirtyFlag == false)
            {
                return;
            }
            mDirtyFlag = false;

            PropertyMap tMap = new PropertyMap();
            PropertyValue animatiedImage = new PropertyValue((int)Visual.Type.AnimatedImage);
            tMap.Insert(Visual.Property.Type, animatiedImage);
            if (mResourceURLs?.Count != 0)
            {
                PropertyArray mArray = new PropertyArray();
                PropertyArray returnedArr = new PropertyArray();
                PropertyValue index = new PropertyValue();
                foreach (var iter in mResourceURLs)
                {
                    index = new PropertyValue(iter);
                    returnedArr = mArray.Add(index);
                }
                index.Dispose();
                returnedArr.Dispose();
                PropertyValue array = new PropertyValue(mArray);
                tMap.Insert(ImageVisualProperty.URL, array);
                PropertyValue batchSize = new PropertyValue(mBatchSize);
                tMap.Insert(ImageVisualProperty.BatchSize, batchSize);
                PropertyValue cacheSize = new PropertyValue(mCacheSize);
                tMap.Insert(ImageVisualProperty.CacheSize, cacheSize);
                PropertyValue frameDelay = new PropertyValue(mFrameDelay);
                tMap.Insert(ImageVisualProperty.FrameDelay, frameDelay);
                PropertyValue loopCount = new PropertyValue(mLoopCount);
                tMap.Insert(ImageVisualProperty.LoopCount, loopCount);

                loopCount.Dispose();
                frameDelay.Dispose();
                cacheSize.Dispose();
                batchSize.Dispose();
                mArray.Dispose();
                array.Dispose();
            }
            else
            {
                PropertyValue url = new PropertyValue(mUrl);
                tMap.Insert(ImageVisualProperty.URL, url);
                url.Dispose();
            }

            mMap = tMap;
            PropertyValue map = new PropertyValue(mMap);
            SetProperty(ImageView.Property.IMAGE, map);
            map.Dispose();

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
        #endregion Event, Enum, Struct, ETC


        #region Internal
        #endregion Internal


        #region Private
        string mUrl = "";
        List<string> mResourceURLs = new List<string>();
        int mBatchSize = 1;
        int mCacheSize = 1;
        int mFrameDelay = 0;
        int mLoopCount = -1;
        bool mDirtyFlag = false;
        PropertyMap mMap;
        #endregion Private
    }
}
