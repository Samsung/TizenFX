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
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Model is a Class to show 3D mesh objects.
    /// Model supports to load glTF 2.0 and DLI models for the input format
    /// and also supports Physically Based Rendering with Image Based Lighting.
    ///
    /// The Animations defined in the glTF or DLI are also loaded and can be retrieved by using GetAnimation() method.
    /// The number of animation is also retrieved by GetAnimationCount() method.
    ///
    /// By default, The loaded mesh has it's own size inferred from position of vertices.
    /// If user set size property, the mesh will be scaled to the input size.
    ///
    /// Both of the default value of PivotPoint and ParentOrigin of the Model is Center.
    ///
    /// </summary>
    /// <code>
    /// Model model = new Model(modelUrl)
    /// {
    ///     Size = new Size(width, height),
    /// };
    /// model.SetImageBasedLightSource(diffuseUrl, specularUrl, scaleFactor);
    /// window.Add(model);
    ///
    /// int animationCount = model.GetAnimationCount();
    /// if(animationCount > 0)
    /// {
    ///     model.GetAnimation(0).Play();
    /// }
    /// </code>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Model : View
    {
        internal Model(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized Model.
        /// </summary>
        /// <param name="modelPath">model file path.(e.g., glTF, and DLI).</param>
        /// <param name="resourcePath">resource file path that includes binary, image etc.</param>
        /// <note> If resourcePath is empty, the parent directory path of modelPath is used for resource path. </note>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Model(string modelPath, string resourcePath = "") : this(Interop.Model.ModelNew(modelPath, resourcePath), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Interop.Model.FitSize(SwigCPtr, true);
            this.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            this.PivotPoint = Tizen.NUI.PivotPoint.Center;
            this.PositionUsesAnchorPoint = true;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="modelView">Handle to an object.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Model(Model modelView) : this(Interop.Model.NewModel(Model.getCPtr(modelView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="modelView">Handle to an object.</param>
        /// <returns>Reference to this.</returns>
        internal Model Assign(Model modelView)
        {
            Model ret = new Model(Interop.Model.ModelAssign(SwigCPtr, Model.getCPtr(modelView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes Image Based Light as the input textures.
        /// </summary>
        /// <param name="diffuseUrl">The path of Cube map image that can be used as a diffuse IBL source.</param>
        /// <param name="specularUrl">The path of Cube map image that can be used as a specular IBL source.</param>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f]. Default value is 1.0f.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetImageBasedLightSource(string diffuseUrl, string specularUrl, float scaleFactor = 1.0f)
        {
            Interop.Model.SetImageBasedLightSource(SwigCPtr, diffuseUrl, specularUrl, scaleFactor);
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
            uint ret = Interop.Model.GetAnimationCount(SwigCPtr);
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
            Animation ret = new Animation(Interop.Model.GetAnimation(SwigCPtr, index), false);
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
            Animation ret = new Animation(Interop.Model.GetAnimation(SwigCPtr, name), false);
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
            View ret = new View(Interop.Model.GetModelRoot(SwigCPtr), false);
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
            Interop.Model.DeleteModel(swigCPtr);
        }
    }
}
