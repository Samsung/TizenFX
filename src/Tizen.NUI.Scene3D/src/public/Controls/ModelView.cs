/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// ModelView is a View to show 3D model objects.
    /// ModelView supports to load glTF 2.0 and DLI models for the input format
    /// and also supports Physically Based Rendering with Image Based Lighting.
    ///
    /// The Animations defined in the glTF or DLI models are also loaded and can be retrieved by using GetAnimation() method.
    /// The number of animation is also retrieved by GetAnimationCount() method.
    ///
    /// By default, The loaded model has it's own position and size which are defined in vertex buffer regardless of the View size.
    /// The model can be resized and repositioned to fit to the ModelView with UseSizeOfView and UseCenterOfView properties.
    /// </summary>
    /// <code>
    /// ModelView modelView = new ModelView(modelUrl)
    /// {
    ///     Size = new Size(width, height),
    ///     PositionUsesPivotPoint = true,
    ///     PivotPoint = PivotPoint.Center,
    ///     ParentOrigin = ParentOrigin.Center,
    ///     UseSizeOfView = true,
    ///     UseCenterOfView = true,
    /// };
    /// modelView.SetImageBasedLightSource(diffuseUrl, specularUrl, scaleFactor);
    /// window.Add(modelView);
    /// int animationCount = modelView.GetAnimationCount();
    /// if(animationCount > 0)
    /// {
    ///     modelView.GetAnimation(0).Play();
    /// }
    /// </code>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ModelView : View
    {
        private bool useSizeOfView = false;
        private bool useCenterOfView = false;

        internal ModelView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized ModelView.
        /// </summary>
        /// <param name="modelPath">model file path.(e.g., glTF, and DLI).</param>
        /// <param name="resourcePath">resource file path that includes binary, image etc.</param>
        /// <note> If resourcePath is empty, the parent directory path of modelPath is used for resource path. </note>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView(string modelPath, string resourcePath = "") : this(Interop.ModelView.ModelViewNew(modelPath, resourcePath), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="modelView">Handle to an object.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView(ModelView modelView) : this(Interop.ModelView.NewModelView(ModelView.getCPtr(modelView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves model root View.
        /// </summary>
        /// <note>
        /// This ModelRoot means a root View that contains 3D models to render.
        /// The light source is only applied on the models under this ModelRoot.
        /// </note>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View ModelRoot
        {
            get
            {
                return GetModelRoot();
            }
        }

        /// <summary>
        /// Fits the model to the View size.
        /// If this property is true, the model is resized to fit the width or height of the View by scaling the ModelRoot.
        /// <note>
        /// This property only changes model size not the pivot.
        /// </note>
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseSizeOfView
        {
            get
            {
                return useSizeOfView;
            }
            set
            {
                useSizeOfView = value;
                Interop.ModelView.FitSize(SwigCPtr, useSizeOfView);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Moves the model to the center of ModelView.
        /// If this property is true, the model moves so that the center is located at the center of the View by change PivotPoint of ModelRoot.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseCenterOfView
        {
            get
            {
                return useCenterOfView;
            }
            set
            {
                useCenterOfView = value;
                Interop.ModelView.FitCenter(SwigCPtr, useCenterOfView);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="modelView">Handle to an object.</param>
        /// <returns>Reference to this.</returns>
        internal ModelView Assign(ModelView modelView)
        {
            ModelView ret = new ModelView(Interop.ModelView.ModelViewAssign(SwigCPtr, ModelView.getCPtr(modelView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes Image Based Light as the input textures.
        /// </summary>
        /// <param name="diffuse">Cube map that can be used as a diffuse IBL source.</param>
        /// <param name="specular">Cube map that can be used as a specular IBL source.</param>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f]. Default value is 1.0f.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetImageBasedLightSource(string diffuse, string specular, float scaleFactor = 1.0f)
        {
            Interop.ModelView.SetImageBasedLightSource(SwigCPtr, diffuse, specular, scaleFactor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets number of animations those loaded from model file.
        /// Note: This method should be called after Model load finished.
        /// </summary>
        /// <returns>The number of loaded animations.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetAnimationCount()
        {
            uint ret = Interop.ModelView.GetAnimationCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets animation at the index.
        /// Note: This method should be called after Model load finished.
        /// </summary>
        /// <param name="index">Index of animation to be retrieved.</param>
        /// <returns>Animation at the index.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animation GetAnimation(uint index)
        {
            Animation ret = new Animation(Interop.ModelView.GetAnimation(SwigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves animation with the given name.
        /// Note: This method should be called after Model load finished.
        /// </summary>
        /// <param name="name">String name of animation to be retrieved.</param>
        /// <returns>Animation that has the given name.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animation GetAnimation(string name)
        {
            Animation ret = new Animation(Interop.ModelView.GetAnimation(SwigCPtr, name), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves model root Actor.
        /// </summary>
        /// <returns>Root View of the model.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private View GetModelRoot()
        {
            View ret = new View(Interop.ModelView.GetModelRoot(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ModelView.DeleteModelView(swigCPtr);
        }
    }
}
