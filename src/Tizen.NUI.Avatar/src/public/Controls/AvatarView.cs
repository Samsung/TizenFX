/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Avatar
{
    /// <summary>
    /// AvatarView
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AvatarView : View
    {
        /// <summary>
        /// Create an initialized AvatarView.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AvatarView() : base()
        {
        }

        /// <summary>
        /// Create an initialized AvatarView.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceUrl
        {
            get
            {
                return InternalResourceUrl;
            }
            set
            {
                InternalResourceUrl = value;
            }
        }

        internal string InternalResourceUrl
        {
            get
            {
                return resourceUrl;
            }
            set
            {
                resourceUrl = value;
                if (string.IsNullOrEmpty(resourceUrl))
                {
                    rootSceneView?.Dispose();
                    rootAvatar?.Dispose();
                    rootSceneView = null;
                }
                else
                {
                    if (rootSceneView == null)
                    {
                        rootSceneView = new SceneView()
                        {
                            WidthResizePolicy = ResizePolicyType.FillToParent,
                            HeightResizePolicy = ResizePolicyType.FillToParent,
                            UseFramebuffer = true,
                            FramebufferMultiSamplingLevel = 4,
                        };
                        this.Add(rootSceneView);
                    }
                    rootAvatar = new Avatar(resourceUrl)
                    {
                        Size = new Size(3.0f, 3.0f, 3.0f),
                    };
                    rootSceneView.Add(rootAvatar);
                }
            }
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                rootSceneView?.Dispose();
                rootAvatar?.Dispose();
                resourceUrl = null;
            }

            base.Dispose(type);
        }

        private string resourceUrl;
        private SceneView rootSceneView;
        private Avatar rootAvatar;
    }
}
