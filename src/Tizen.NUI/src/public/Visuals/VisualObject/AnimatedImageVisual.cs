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
    /// The visual which can display and control an animated image resource.
    /// We can also set image sequences by using ResourceUrlList and FrameDelay property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AnimatedImageVisual : ImageVisual
    {
        #region Internal And Private
        internal static readonly int ActionPlay = Tizen.NUI.BaseComponents.ImageView.ActionPlay;
        internal static readonly int ActionPause = Tizen.NUI.BaseComponents.ImageView.ActionPause;
        internal static readonly int ActionStop = Tizen.NUI.BaseComponents.ImageView.ActionStop;

        internal static readonly int ActionJumpTo = Tizen.NUI.BaseComponents.AnimatedImageView.ActionJumpTo;

        private List<string> resourceUrls;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AnimatedImageVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal AnimatedImageVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal AnimatedImageVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.AnimatedImage;
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// Gets and Sets the url list in the AnimatedImageVisual.
        /// </summary>
        /// <remarks>
        /// If we set ResourceUrlList as non-null, ImageVisual.ResourceUrl will be ignored.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<string> ResourceUrlList
        {
            get
            {
                return resourceUrls;
            }
            set
            {
                resourceUrls = value;

                // Always request to create new visual
                visualCreationRequiredFlag = true;
                ReqeustProcessorOnceEvent();
            }
        }

        /// <summary>
        /// The number of milliseconds between each frame in the Image-Array animation.
        /// </summary>
        /// <remarks>
        /// This is only used when ResourceUrlList(multiple string) are provided.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FrameDelay
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.FrameDelay, value);
            }
            get
            {
                int ret = 100;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.FrameDelay);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets and sets the number of times the AnimatedImageVisual will be looped.
        /// The default is -1. If the number is less than 0 then it loops unlimited,otherwise loop loopCount times.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LoopCount
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.LoopCount, value);
            }
            get
            {
                int ret = -1;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.LoopCount);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Sets or gets the stop behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.BaseComponents.AnimatedImageView.StopBehaviorType StopBehavior
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.StopBehavior, value);
            }
            get
            {
                int ret = (int)Tizen.NUI.BaseComponents.AnimatedImageView.StopBehaviorType.CurrentFrame;
                using var propertyValue = GetVisualProperty((int)Tizen.NUI.ImageVisualProperty.StopBehavior);
                propertyValue?.Get(out ret);
                return (Tizen.NUI.BaseComponents.AnimatedImageView.StopBehaviorType)ret;
            }
        }

        /// <summary>
        /// Gets and sets the speed factor for the AnimatedImageVisual frame rendering.
        /// The default is 1.0f. If the number is less than 1.0f then it will play slower than normal case.
        /// If the number is greater than 1.0f then it will play faster than normal case.
        /// We will clamp the value between [0.01f 100.0f] internally.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FrameSpeedFactor
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.FrameSpeedFactor, value);
            }
            get
            {
                float ret = 1.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.FrameSpeedFactor);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Get the number of total frames.
        /// Or -1 if image is invalid, or not loaded yet.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TotalFrame
        {
            get
            {
                // Sync as current properties
                UpdateVisualPropertyMap();

                int ret = -1;
                using var propertyValue = GetCurrentVisualProperty((int)Tizen.NUI.ImageVisualProperty.TotalFrameNumber);
                propertyValue?.Get(out ret);
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
                // Sync as current properties
                UpdateVisualPropertyMap();

                Interop.VisualObject.DoActionWithSingleIntAttributes(SwigCPtr, ActionJumpTo, value);
            }
            get
            {
                // Sync as current properties
                UpdateVisualPropertyMap();

                int ret = -1;
                using var propertyValue = GetCurrentVisualProperty((int)Tizen.NUI.ImageVisualProperty.CurrentFrameNumber);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets and Sets the batch size for pre-loading images in the AnimatedImageVisual. (Advanced)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BatchSize
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.BatchSize, value);
            }
            get
            {
                int ret = 1;
                using var propertyValue = GetVisualProperty((int)Tizen.NUI.ImageVisualProperty.BatchSize);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets and Sets the cache size for loading images in the AnimatedImageVisual. (Advanced)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CacheSize
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.CacheSize, value);
            }
            get
            {
                int ret = 1;
                using var propertyValue = GetVisualProperty((int)Tizen.NUI.ImageVisualProperty.CacheSize);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Play the animated image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play()
        {
            // Sync as current properties
            UpdateVisualPropertyMap();

            Interop.VisualObject.DoActionWithEmptyAttributes(SwigCPtr, ActionPlay);
        }

        /// <summary>
        /// Pause the animated image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause()
        {
            // Sync as current properties
            UpdateVisualPropertyMap();

            Interop.VisualObject.DoActionWithEmptyAttributes(SwigCPtr, ActionPause);
        }

        /// <summary>
        /// Stop the animated image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            // Sync as current properties
            UpdateVisualPropertyMap();

            Interop.VisualObject.DoActionWithEmptyAttributes(SwigCPtr, ActionStop);
        }
        #endregion

        #region Internal Methods
        internal override void OnUpdateVisualPropertyMap()
        {
            if (resourceUrls != null && resourceUrls.Count > 0)
            {
                using var urlArray = new PropertyArray();
                foreach (var url in resourceUrls)
                {
                    var urlValue = new PropertyValue(url);
                    using var _ = urlArray.Add(urlValue);
                }

                if (cachedVisualPropertyMap != null)
                {
                    // Remove ResourceUrl from cachedVisualPropertyMap
                    cachedVisualPropertyMap.Remove((int)Tizen.NUI.ImageVisualProperty.URL);
                    cachedVisualPropertyMap.Add((int)Tizen.NUI.ImageVisualProperty.URL, urlArray);
                }
            }
            else
            {
                // If we don't use image sequence, follow the ImageVisual logic.
                base.OnUpdateVisualPropertyMap();
            }
        }
        #endregion
    }
}