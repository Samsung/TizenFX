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
    /// By default, The loaded model has it's own position and size which are defined in vertex buffer regardless of the Control size.
    /// The model can be resized and repositioned to fit to the ModelView Control with FitSize() and FitCenter() methods.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ModelView : View
    {
        internal ModelView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
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

        /// <summary>
        /// Create an initialized ModelView.
        /// </summary>
        /// <param name="modelPath">model file path.(e.g., glTF, and DLI).</param>
        /// <param name="resourcePath">resource file path that includes binary, image etc.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView(string modelPath, string resourcePath) : this(Interop.ModelView.ModelViewNew(modelPath, resourcePath), true)
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
        /// Assignment operator.
        /// </summary>
        /// <param name="modelView">Handle to an object.</param>
        /// <returns>Reference to this.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView Assign(ModelView modelView)
        {
            ModelView ret = new ModelView(Interop.ModelView.ModelViewAssign(SwigCPtr, ModelView.getCPtr(modelView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves model root Actor.
        /// </summary>
        /// <returns>Root View of the model.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetModelRoot()
        {
            View ret = new View(Interop.ModelView.GetModelRoot(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Fits the model to the Control size.
        /// </summary>
        /// <param name="fit">True to fit model size to control.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FitSize(bool fit)
        {
            Interop.ModelView.FitSize(SwigCPtr, fit);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Moves the model to the center of control.
        /// </summary>
        /// <param name="fit">True to fit model to center of control.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FitCenter(bool fit)
        {
            Interop.ModelView.FitCenter(SwigCPtr, fit);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves model root Actor.
        /// </summary>
        /// <param name="diffuse">Cube map that can be used as a diffuse IBL source.</param>
        /// <param name="specular">Cube map that can be used as a specular IBL source.</param>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f]. Default value is 1.0f.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetImageBasedLightSource(string diffuse, string specular, float scaleFactor)
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
    }
}
