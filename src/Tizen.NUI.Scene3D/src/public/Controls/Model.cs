/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
    public partial class Model : View
    {
        private bool isBuilt = false;
        private Position modelPivotPoint = new Position();
        internal Model(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Model(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, true, cRegister)
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
            this.PositionUsesPivotPoint = true;
            ResourcesLoaded += OnResourcesLoaded;
        }

        /// <summary>
        /// Create an initialized Model.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Model() : this(Interop.Model.ModelNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.PositionUsesPivotPoint = true;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="model">Source object to copy.</param>
        /// <since_tizen> 10 </since_tizen>
        public Model(Model model) : this(Interop.Model.NewModel(Model.getCPtr(model)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.PositionUsesPivotPoint = model.PositionUsesPivotPoint;
        }

        /// <summary>
        /// Get The original pivot point of the model
        /// </summary>
        /// <remarks>
        /// This returns (0, 0, 0) before resources are loaded.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position ModelPivotPoint
        {
            get
            {
                return modelPivotPoint;
            }
        }

        /// <summary>
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
        /// Retrieves root ModelNode of this Model.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelNode ModelRoot
        {
            get
            {
                return GetModelRoot();
            }
        }

        /// <summary>
        /// Whether this Model casts shadow or not by directional light.
        /// If it is true, this Model is drawn on Shadow Map.
        /// Default value is true.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShadowCast
        {
            get
            {
                return IsShadowCasting();
            }
            set
            {
                CastShadow(value);
            }
        }

        /// <summary>
        /// Whether this Model receives shadow or not by directional light.
        /// If it is true, shadows are drawn on this Model.
        /// Default value is true.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShadowReceive
        {
            get
            {
                return IsShadowReceiving();
            }
            set
            {
                ReceiveShadow(value);
            }
        }

        /// <summary>
        /// Adds modelNode to this Model.
        /// </summary>
        /// <param name="modelNode">Root of a ModelNode tree</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddModelNode(ModelNode modelNode)
        {
            Interop.Model.AddModelNode(SwigCPtr, ModelNode.getCPtr(modelNode));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes modelNode from this Model.
        /// </summary>
        /// <param name="modelNode">Root of a ModelNode tree to be removed</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveModelNode(ModelNode modelNode)
        {
            Interop.Model.RemoveModelNode(SwigCPtr, ModelNode.getCPtr(modelNode));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes Returns a child ModelNode object with a name that matches nodeName.
        /// </summary>
        /// <param name="nodeName">The name of the child ModelNode object you want to find.</param>
        /// <returns>Child ModelNode that has nodeName as name.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelNode FindChildModelNodeByName(string nodeName)
        {
            global::System.IntPtr cPtr = Interop.Model.FindChildModelNodeByName(SwigCPtr, nodeName);
            ModelNode ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ModelNode;
            if (ret == null)
            {
                // Store the value of PositionUsesAnchorPoint from dali object (Since View object automatically change PositionUsesPivotPoint value as false, we need to keep value.)
                HandleRef handle = new HandleRef(this, cPtr);

                // Use original value as 'true' if we got invalid ModelNode.
                bool originalPositionUsesAnchorPoint = (cPtr == global::System.IntPtr.Zero || !Tizen.NUI.Interop.BaseHandle.HasBody(handle)) || Object.InternalGetPropertyBool(handle, View.Property.PositionUsesAnchorPoint);
                handle = new HandleRef(null, IntPtr.Zero);

                // Register new animatable into Registry.
                ret = new ModelNode(cPtr, true);
                if (ret != null)
                {
                    ret.PositionUsesPivotPoint = originalPositionUsesAnchorPoint;
                }
            }
            else
            {
                // We found matched NUI animatable. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
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
            global::System.IntPtr cPtr = Interop.Model.GetAnimation(SwigCPtr, index);
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new Animation(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
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
            global::System.IntPtr cPtr = Interop.Model.GetAnimation(SwigCPtr, name);
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new Animation(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets number of camera parameters that has been loaded from model file.
        /// </summary>
        /// <remarks>
        /// This method should be called after Model load has been finished.
        /// </remarks>
        /// <returns>The number of loaded camera parameters.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCameraCount()
        {
            uint ret = Interop.Model.GetCameraCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Generate Camera using camera parameters at the index.
        /// If camera parameter is valid, create new Camera.
        /// Else, return empty Handle.
        /// </summary>
        /// <remarks>
        /// This method should be called after Model load has been finished.
        /// </remarks>
        /// <param name="index">Index of camera to be generated.</param>
        /// <returns>Generated Camera by the index, or empty Handle if generation failed.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Camera GenerateCamera(uint index)
        {
            global::System.IntPtr cPtr = Interop.Model.GenerateCamera(SwigCPtr, index);
            Camera ret = new Camera(cPtr, true); // Always create new camera.
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Apply camera parameters at the index to inputed Camera.
        /// If camera parameter is valid and camera is not empty, apply parameters.
        /// It will change camera's transform and near / far / fov or orthographic size / aspect ratio (if defined)
        /// </summary>
        /// <remarks>
        /// This method should be called after Model load has been finished.
        /// </remarks>
        /// <param name="index">Index of camera to be retrieved.</param>
        /// <param name="camera">Camera to be applied parameter.</param>
        /// <returns>True if Apply successed. False otherwise.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ApplyCamera(uint index, Camera camera)
        {
            bool ret = false;
            if (camera?.HasBody() == true)
            {
                ret = Interop.Model.ApplyCamera(SwigCPtr, index, Camera.getCPtr(camera));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        /// <summary>
        /// Load bvh animation and assign to model.
        /// Scale is additional scale factor of bvh animation. It is possible that
        /// Model's scale may not matched with bvh animation scale.
        /// If scale is null, default use as Vector3.ONE
        /// </summary>
        /// <param name="bvhFilename">Name of bvh format file.</param>
        /// <param name="scale">Scale value of bvh animation match with model.</param>
        /// <param name="translateRootFromModelNode">Whether we should translate the bvh root from it's ModelNode position or not.</param>
        /// <returns>Animaion of bvh</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this LoadBvhAnimation. Use MotionData.LoadMotionCaptureAnimation and GenerateMotionDataAnimation instead.")]
        public Animation LoadBvhAnimation(string bvhFilename, Vector3 scale = null, bool translateRootFromModelNode = true)
        {
            global::System.IntPtr cPtr = Interop.Model.LoadBvhAnimation(SwigCPtr, bvhFilename, Vector3.getCPtr(scale), translateRootFromModelNode);
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new Animation(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load bvh animation and assign to model.
        /// Scale is additional scale factor of bvh animation. It is possible that
        /// Model's scale may not matched with bvh animation scale.
        /// If scale is null, default use as Vector3.ONE
        /// </summary>
        /// <param name="bvhBuffer">Contents of bvh format file.</param>
        /// <param name="scale">Scale value of bvh animation match with model.</param>
        /// <param name="translateRootFromModelNode">Whether we should translate the bvh root from it's ModelNode position or not.</param>
        /// <returns>Animaion of bvh</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this LoadBvhAnimationFromBuffer. Use MotionData.LoadMotionCaptureAnimationFromBuffer and GenerateMotionDataAnimation instead.")]
        public Animation LoadBvhAnimationFromBuffer(string bvhBuffer, Vector3 scale = null, bool translateRootFromModelNode = true)
        {
            global::System.IntPtr cPtr = Interop.Model.LoadBvhAnimationFromBuffer(SwigCPtr, bvhBuffer, bvhBuffer.Length, Vector3.getCPtr(scale), translateRootFromModelNode);
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new Animation(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load facial animation and assign to model.
        /// </summary>
        /// <param name="facialFilename">Name of json format file what we predefined.</param>
        /// <returns>Animaion of facial</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this LoadFacialAnimation. Use MotionData.LoadBlendShapeAnimation and GenerateMotionDataAnimation instead.")]
        public Animation LoadFacialAnimation(string facialFilename)
        {
            return LoadBlendShapeAnimation(facialFilename);
        }

        /// <summary>
        /// Load facial animation and assign to model.
        /// </summary>
        /// <param name="facialBuffer">Contents of json format file what we predefined.</param>
        /// <returns>Animaion of facial</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this LoadFacialAnimationFromBuffer. Use MotionData.LoadBlendShapeAnimationFromBuffer and GenerateMotionDataAnimation instead.")]
        public Animation LoadFacialAnimationFromBuffer(string facialBuffer)
        {
            return LoadBlendShapeAnimationFromBuffer(facialBuffer);
        }

        /// <summary>
        /// Load blendshape animation and assign to model from json file.
        /// </summary>
        /// <param name="jsonFilename">Name of json format file what we predefined.</param>
        /// <returns>Animaion of facial</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this LoadBlendShapeAnimation. Use MotionData.LoadBlendShapeAnimation and GenerateMotionDataAnimation instead.")]
        public Animation LoadBlendShapeAnimation(string jsonFilename)
        {
            global::System.IntPtr cPtr = Interop.Model.LoadBlendShapeAnimation(SwigCPtr, jsonFilename);
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new Animation(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load morphing animation and assign to model from json string.
        /// </summary>
        /// <param name="jsonBuffer">Contents of json format file what we predefined.</param>
        /// <returns>Animaion of facial</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this LoadBlendShapeAnimationFromBuffer. Use MotionData.LoadBlendShapeAnimationFromBuffer and GenerateMotionDataAnimation instead.")]
        public Animation LoadBlendShapeAnimationFromBuffer(string jsonBuffer)
        {
            global::System.IntPtr cPtr = Interop.Model.LoadBlendShapeAnimationFromBuffer(SwigCPtr, jsonBuffer, jsonBuffer.Length);
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new Animation(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Generate animation by MotionData.
        /// If there is no animatable item for MotionData, return null.
        /// </summary>
        /// <param name="motionData">Source motion data.</param>
        /// <returns>Generated animation from then given motion data, or null if there is no animatable item in <paramref name="motionData"/></returns>
        /// <since_tizen> 11 </since_tizen>
        public Animation GenerateMotionDataAnimation(MotionData motionData)
        {
            global::System.IntPtr cPtr = Interop.Model.GenerateMotionDataAnimation(SwigCPtr, MotionData.getCPtr(motionData));
            Animation ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animation;
            HandleRef handle = new HandleRef(this, cPtr);
            if (ret == null)
            {
                // Register new animation into Registry only if it has body.
                if (handle.Handle != global::System.IntPtr.Zero && Tizen.NUI.Interop.BaseHandle.HasBody(handle))
                {
                    ret = new Animation(cPtr, true);
                }
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                Tizen.NUI.Interop.Animation.DeleteAnimation(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // It is possible if there is no animatable properties exist on inputed motionData.
            // In this case, let we return null.
            if (!(ret?.HasBody() ?? false))
            {
                ret?.Dispose();
                ret = null;
            }
            return ret;
        }

        /// <summary>
        /// Set values from MotionData.
        /// Note that this method doesn not apply KeyFrames animation.
        /// If you want to apply the animation, please use <see cref="GenerateMotionDataAnimation(MotionData)"/> and play the result.
        /// </summary>
        /// <param name="motionData">Source motion data.</param>
        /// <since_tizen> 11 </since_tizen>
        public void SetMotionData(MotionData motionData)
        {
            Interop.Model.SetMotionData(SwigCPtr, MotionData.getCPtr(motionData));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether this Model casts shadow or not.
        /// If it is true, this model is drawn on Shadow Map.
        /// Note: This method affects all of the child ModelNode.
        /// However, same property of each child ModelNode can be changed respectively and it not changes parent's property.
        /// </summary>
        /// <param name="castShadow">Whether this Model casts shadow or not.</param>
        private void CastShadow(bool castShadow)
        {
            Interop.Model.CastShadow(SwigCPtr, castShadow);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the Model casts shadow or not for Light.
        /// Note: IBL does not cast any shadow.
        /// </summary>
        /// <returns>True if this model casts shadow.</returns>
        private bool IsShadowCasting()
        {
            var isShadowCasting = Interop.Model.IsShadowCasting(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return isShadowCasting;
        }

        /// <summary>
        /// Sets whether this Model receives shadow or not.
        /// If it is true, shadows are drawn on this model.
        /// Note: This method affects all of the child ModelNode.
        /// However, same property of each child ModelNode can be changed respectively and it not changes parent's property.
        /// </summary>
        /// <param name="receiveShadow">Whether this Model receives shadow or not.</param>
        private void ReceiveShadow(bool receiveShadow)
        {
            Interop.Model.ReceiveShadow(SwigCPtr, receiveShadow);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the Model receives shadow or not for Light
        /// If it is true, this model is drawn on Shadow Map.
        /// </summary>
        /// <returns>True if this model receives shadow.</returns>
        private bool IsShadowReceiving()
        {
            var isShadowReceiving = Interop.Model.IsShadowReceiving(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return isShadowReceiving;
        }

        /// <summary>
        /// Retrieves model root Actor.
        /// </summary>
        /// <returns>Root View of the model.</returns>
        private ModelNode GetModelRoot()
        {
            global::System.IntPtr cPtr = Interop.Model.GetModelRoot(SwigCPtr);
            ModelNode ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as ModelNode;
            if (ret == null)
            {
                // Store the value of PositionUsesAnchorPoint from dali object (Since View object automatically change PositionUsesPivotPoint value as false, we need to keep value.)
                HandleRef handle = new HandleRef(this, cPtr);

                // Use original value as 'true' if we got invalid ModelNode.
                bool originalPositionUsesAnchorPoint = (cPtr == global::System.IntPtr.Zero || !Tizen.NUI.Interop.BaseHandle.HasBody(handle)) || Object.InternalGetPropertyBool(handle, View.Property.PositionUsesAnchorPoint);
                handle = new HandleRef(null, IntPtr.Zero);

                // Register new animatable into Registry.
                ret = new ModelNode(cPtr, true);
                if (ret != null)
                {
                    ret.PositionUsesPivotPoint = originalPositionUsesAnchorPoint;
                }
            }
            else
            {
                // We found matched NUI animatable. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.BaseHandle.DeleteBaseHandle(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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

        private void OnResourcesLoaded(object sender, EventArgs e)
        {
            if (!isBuilt && this.ModelRoot != null)
            {
                this.ModelRoot.Build();
                isBuilt = true;
                this.modelPivotPoint.X = this.PivotPoint.X;
                this.modelPivotPoint.Y = this.PivotPoint.Y;
                this.modelPivotPoint.Z = this.PivotPoint.Z;
            }
        }

        /// <summary>
        /// To make transitionSet instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            ResourcesLoaded -= OnResourcesLoaded;
            base.Dispose(type);
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
        
        
        private EventHandler<MeshHitEventArgs> meshHitEventHandler;
        private MeshHitCallbackType meshHitCallback;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void MeshHitCallbackType(IntPtr motionData);

        /// <summary>
        /// MeshHitEventArgs
        /// Contains arguments when MeshHitSignal called
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class MeshHitEventArgs : EventArgs
        {
            private ModelNode modelNode;
            
            /// <summary>
            /// ModelNode that's been hit
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ModelNode ModelNode
            {
                get
                {
                    return modelNode;
                }
                set
                {
                    modelNode = value;
                }
            }
        }
        
        /// <summary>
        /// EventHandler event.
        /// It will be invoked when collider mesh is hit.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<MeshHitEventArgs> ColliderMeshHitted
        {
            add
            {
                if (meshHitEventHandler == null)
                {
                    meshHitCallback = MeshHitCollision;
                    Interop.Model.MeshHitSignalConnect(SwigCPtr, meshHitCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                meshHitEventHandler += value;
            }
            remove
            {
                meshHitEventHandler -= value;
                if (meshHitEventHandler == null && meshHitCallback != null)
                {
                    Interop.Model.MeshHitSignalDisconnect(SwigCPtr, meshHitCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    meshHitCallback = null;
                }
            }
        }

        private void MeshHitCollision(IntPtr modelNode)
        {
            if (meshHitEventHandler != null)
            {
                var args = new MeshHitEventArgs();
                args.ModelNode = new ModelNode(modelNode, false);
                meshHitEventHandler(this, args);
            }
        }
    }
}
