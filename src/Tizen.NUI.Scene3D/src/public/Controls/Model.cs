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
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Model is a Class to show 3D mesh objects.
    /// Model supports glTF 2.0 and DLI model formats.
    /// Physically Based Rendering with Image Based Lighting is also supported.
    /// </summary>
    ///
    /// <remarks>
    /// The Animations defined in the glTF or DLI are also loaded and can be retrieved by using <see cref="GetAnimation(uint)"/> and <see cref="GetAnimation(string)"/> methods.
    /// The number of animation is also retrieved by GetAnimationCount() method.
    ///
    /// By default, the loaded mesh has its own size and <see cref="PivotPoint"/> inferred from position of vertices.
    /// If user set size property, the mesh will be scaled to the input size.
    /// Default value of <see cref="ParentOrigin"/> of the Model is Center.
    ///
    /// The model starts to be loaded synchronously when the Model object is on Window.
    /// So, <see cref="GetAnimation(uint)"/> and <see cref="GetAnimation(string)"/> methods should be called after the Model object is added on Window.
    /// </remarks>
    ///
    /// <example>
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
    ///     // Play an Animation of index 0.
    ///     model.GetAnimation(0).Play();
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 10 </since_tizen>
    public class Model : View
    {
        internal Model(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized Model.
        /// </summary>
        /// <param name="modelUrl">model file url.(e.g. glTF, and DLI).</param>
        /// <param name="resourceDirectoryUrl"> The url to derectory containing resources: binary, image etc.</param>
        /// <remarks>
        /// If resourceDirectoryUrl is empty, the parent directory url of modelUrl is used for resource url.
        ///
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public Model(string modelUrl, string resourceDirectoryUrl = "") : this(Interop.Model.ModelNew(modelUrl, resourceDirectoryUrl), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.PositionUsesAnchorPoint = true;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="model">Source object to copy.</param>
        /// <since_tizen> 10 </since_tizen>
        public Model(Model model) : this(Interop.Model.NewModel(Model.getCPtr(model)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="model">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal Model Assign(Model model)
        {
            Model ret = new Model(Interop.Model.ModelAssign(SwigCPtr, Model.getCPtr(model)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes Image Based Light according to the given input textures.
        /// </summary>
        /// <param name="diffuseUrl">The path of Cube map image that will be used as a diffuse IBL source.</param>
        /// <param name="specularUrl">The path of Cube map image that will be used as a specular IBL source.</param>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f]. Default value is 1.0f.</param>
        /// <remarks>
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public void SetImageBasedLightSource(string diffuseUrl, string specularUrl, float scaleFactor = 1.0f)
        {
            Interop.Model.SetImageBasedLightSource(SwigCPtr, diffuseUrl, specularUrl, scaleFactor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets number of animations that has been loaded from model file.
        /// </summary>
        /// <remarks>
        /// This method should be called after Model load has been finished.
        /// </remarks>
        /// <returns>The number of loaded animations.</returns>
        /// <since_tizen> 10 </since_tizen>
        public uint GetAnimationCount()
        {
            uint ret = Interop.Model.GetAnimationCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets animation at the index.
        /// </summary>
        /// <remarks>
        /// This method should be called after Model load has been finished.
        /// </remarks>
        /// <param name="index">Index of animation to be retrieved.</param>
        /// <returns>Animation at the index.</returns>
        /// <since_tizen> 10 </since_tizen>
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
        /// <since_tizen> 10 </since_tizen>
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
