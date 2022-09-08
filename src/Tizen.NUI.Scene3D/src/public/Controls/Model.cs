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
    /// Since NUI uses a left-handed coordinate system, loaded models are transformed into a left-handed coordinate system with Y pointing down.
    /// The Animations defined in the glTF or DLI are also loaded and can be retrieved by using <see cref="GetAnimation(uint)"/> and <see cref="GetAnimation(string)"/> methods.
    /// The number of animation is also retrieved by GetAnimationCount() method.
    ///
    /// Model also supports Physically Based Rendering(PBR) with Image Based Lighting(IBL).
    /// For the IBL, two cube map textures(diffuse and specular) are required.
    /// Model supports 4 types layout for Cube Map: Vertical/Horizontal Cross layouts, and Vertical/Horizontal Array layouts.
    /// And also, ktx format with cube map is supported.
    ///
    /// The model and IBL textures start to be loaded asynchronously when the Model object is on Window.
    /// ResourcesLoaded signal notifies that the loading of the model and IBL resources have been completed.
    /// If Model or IBL is requested to be loaded before the other loading is completed, the ResourcesLoaded signal is called after all resources are loaded.
    /// <see cref="GetAnimation(uint)"/> and <see cref="GetAnimation(string)"/> methods can be used after the model loading is finished.
    ///
    /// By default, the loaded mesh has its own size and <see cref="PivotPoint"/> inferred from position of vertices.
    /// The <see cref="PivotPoint"/> can be modified after model loading is finished.
    /// If user set size property, the mesh will be scaled to the input size.
    /// Default value of <see cref="ParentOrigin"/> of the Model is Center.
    /// </remarks>
    ///
    /// <example>
    /// <code>
    /// Model model = new Model(modelUrl)
    /// {
    ///     Size = new Size(width, height),
    /// };
    /// model.ResourcesLoaded += (s, e) =>
    /// {
    ///     model.PivotPoint = new Vector3(0.5f, 0.5f, 0.5f); // Use center as a Pivot.
    ///
    ///     int animationCount = model.GetAnimationCount();
    ///     if(animationCount > 0)
    ///     {
    ///         // Play an Animation of index 0.
    ///         model.GetAnimation(0).Play();
    ///     }
    /// };
    /// model.SetImageBasedLightSource(diffuseUrl, specularUrl, scaleFactor);
    /// window.Add(model);
    ///
    /// </code>
    /// </example>
    /// <since_tizen> 10 </since_tizen>
    public class Model : View
    {
        internal Model(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            // Currenly, Model don't have API to access it's child. So, we make it false.
            this.ChildrenSensitive = false;
            this.FocusableChildren = false;
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
        /// Set/Get whether allow this model's children allow to use touch events.
        /// This property doesn't change Model itself's Sensitive info.
        /// If this property is true, event can traversal this models children.
        /// If this property is false, event traversal blocked.
        /// Default is false.
        /// </summary>
        /// <remarks>
        /// If ChildrenSensitive is true, it could decrease performance but we can connect events into it's children.
        /// If ChildrenSensitive is false, the performance becomes better but we cannot connect events into it's children.
        ///
        /// Currenly, Model don't have API to access it's child. So, we make it as private.
        /// </remarks>
        private bool ChildrenSensitive
        {
            set
            {
                SetChildrenSensitive(value);
            }
            get
            {
                return GetChildrenSensitive();
            }
        }

        /// Set/Get the ImageBasedLight ScaleFactor.
        /// Scale factor controls light source intensity in [0.0f, 1.0f]
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ImageBasedLightScaleFactor
        {
            set
            {
                SetImageBasedLightScaleFactor(value);
            }
            get
            {
                return GetImageBasedLightScaleFactor();
            }
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

        internal void SetChildrenSensitive(bool enable)
        {
            Interop.Model.SetChildrenSensitive(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool GetChildrenSensitive()
        {
            bool result = Interop.Model.GetChildrenSensitive(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Set the ImageBasedLight ScaleFactor.
        /// </summary>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f].</param>
        private void SetImageBasedLightScaleFactor(float scaleFactor)
        {
            Interop.Model.SetImageBasedLightScaleFactor(SwigCPtr, scaleFactor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the ImageBasedLight ScaleFactor.
        /// </summary>
        /// <returns>ImageBasedLightScaleFactor that controls light source intensity.</returns>
        private float GetImageBasedLightScaleFactor()
        {
            float scaleFactor = Interop.Model.GetImageBasedLightScaleFactor(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return scaleFactor;
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
