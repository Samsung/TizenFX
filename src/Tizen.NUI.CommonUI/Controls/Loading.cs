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
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// The Loading class of nui component. It's used to indicate informs users of the ongoing operation.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Loading : Control
    {
        private LoadingAttributes loadingAttrs = null;  // Loading Attributes
        private AnimatedImageVisual imageVisual = null;

        /// <summary>
        /// The constructor of Loading
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Loading class with special style.
        /// </summary>
        /// <param name="style">The string to initialize the Loading.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Loading class with specific Attributes.
        /// </summary>
        /// <param name="attributes">The Attributes object to initialize the Loading.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading(LoadingAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets loading image resource array.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] ImageArray
        {
            get
            {
                return loadingAttrs.ImageArray;
            }
            set
            {
                if (null != value)
                {
                    loadingAttrs.ImageArray = value;
                    imageVisual.URLS = new List<string>(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets loading size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D LoadingSize
        {
            get
            {
                return loadingAttrs.LoadingSize ?? new Size2D(100, 100);
            }
            set
            {
                loadingAttrs.LoadingSize = value;
                imageVisual.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets FPS of loading.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FPS
        {
            get
            {
                return loadingAttrs?.FPS?.All ?? (int)(1000.0f / 16.6f);
            }
            set
            {
                if (value != 0) //It will crash if 0 
                {
                    if (null == loadingAttrs.FPS)
                    {
                        loadingAttrs.FPS = new IntSelector();
                    }
                    loadingAttrs.FPS.All = value;
                    imageVisual.FrameDelay = 1000.0f / value;
                }
            }
        }

        /// <summary>
        /// Get Loading attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new LoadingAttributes();
        }

        /// <summary>
        /// Dispose Loading.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                RemoveVisual("loadingImageVisual");
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// Update Loading by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
        }

        private void Initialize()
        {
            loadingAttrs = attributes as LoadingAttributes;
            if (null == loadingAttrs)
            {
                throw new Exception("Loading attribute parse error.");
            }
            ApplyAttributes(this, loadingAttrs);

            imageVisual = new AnimatedImageVisual()
            {
                URLS = new List<string>(),
                FrameDelay = 16.6f,
                LoopCount = -1,
                Size = new Size2D(100, 100),
                Position = new Vector2(0, 0),
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center
            };

            UpdateVisual();

            this.AddVisual("loadingImageVisual", imageVisual);
        }

        private void UpdateVisual()
        {
            if (null != loadingAttrs.ImageArray)
            {
                imageVisual.URLS = new List<string>(loadingAttrs.ImageArray);
            }
            if (null != loadingAttrs.FPS)
            {
                imageVisual.FrameDelay = 1000.0f / (float)loadingAttrs.FPS.All;
            }
            if (null != loadingAttrs.LoadingSize)
            {
                imageVisual.Size = loadingAttrs.LoadingSize;
            }
        }
    }
}
