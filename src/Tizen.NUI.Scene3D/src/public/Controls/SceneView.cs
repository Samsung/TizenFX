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
    /// SceneView is a Class to show multiple 3D objects in a single 2D screen.
    /// Each SceneView has its own 3D space, and 3D objects added to SceneView are positioned in the space.
    /// SceneView uses left-handed coordinate system same as NUI. X as right, Y as down, and Z as forward.
    ///
    /// SceneView has internal root container to control inner rendering process like depth test.
    /// When a View is added to the SceneView with <see cref="View.Add(View)"/> method, it is actually added on the root container.
    /// Therefore, the added Views exist in the sub tree of SceneView, but are not direct children.
    /// The sub tree of Views will be rendered with the SceneView's own Camera.
    ///
    /// SceneView has one built-in camera by default.
    /// The default Camera is not removed by using <see cref="RemoveCamera(Camera)"/> method.
    /// <see cref="GetCamera(uint)"/> method with index "0" returns the default camera,
    /// and the minimum value returned by <see cref="GetCameraCount()"/> method is 1.
    ///
    /// SceneView also provides multiple Camera and one of them can be used to render multiple objects.
    /// <see cref="AddCamera(Camera)"/>, <see cref="RemoveCamera(Camera)"/>, <see cref="GetCamera(uint)"/>,
    /// and <see cref="SelectCamera(uint)"/> are methods to manage Cameras of the SceneView.
    /// User can place multiple cameras in a scene to display the entire scene or to display individual objects.
    /// User can use the <see cref="SelectCamera(uint)"/> method to select the currently required camera.
    ///
    /// When the SceneView's size changes, some camera properties that depend on its size may also change.
    /// The changing properties are as follows: AspectRatio, LeftPlaneDistance, RightPlaneDistance, TopPlaneDistance, and BottomPlaneDistance.
    /// The Camera's FieldOfView is vertical fov. The horizontal fov is updated internally according to the SceneView size.
    ///
    /// The <see cref="SetImageBasedLightSource(string, string, float)"/> method sets the same IBL to all Model objects added to the SceneView.
    /// For the IBL, two cube map textures(diffuse and specular) are required.
    /// SceneView supports 4 types layout for Cube Map: Vertical/Horizontal Cross layouts, and Vertical/Horizontal Array layouts.
    /// And also, ktx format with cube map is supported.
    /// If a model already has an IBL, it is batch overridden with the IBL of the SceneView.
    /// If the SceneView has IBL, the IBL of newly added models is also overridden.
    ///
    /// The IBL textures start to be loaded asynchronously when <see cref="SetImageBasedLightSource(string, string, float)"/> method is called.
    /// ResourcesLoaded signal notifies that the loading of the IBL resources have been completed.
    ///
    /// If FBO is used, the rendering result of SceneView is drawn on the FBO and it is mapped on the plane of the SceneView.
    /// It could decreases performance slightly, but it is useful to show SceneView according to the rendering order with other Views.
    ///
    /// And since SceneView is a View, it can be placed together with other 2D UI components in the NUI window.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class SceneView : View
    {
        private bool inCameraTransition = false;
        private Animation cameraTransition;
        private string skyboxUrl;

        internal SceneView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized SceneView.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public SceneView() : this(Interop.SceneView.SceneNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="sceneView">The source object.</param>
        /// <since_tizen> 10 </since_tizen>
        public SceneView(SceneView sceneView) : this(Interop.SceneView.NewScene(SceneView.getCPtr(sceneView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="sceneView">Handle to an object.</param>
        /// <returns>Reference to this.</returns>
        internal SceneView Assign(SceneView sceneView)
        {
            SceneView ret = new SceneView(Interop.SceneView.SceneAssign(SwigCPtr, SceneView.getCPtr(sceneView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// An event emitted when Camera Transition is finished.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler CameraTransitionFinished;

        /// <summary>
        /// Set/Get the ImageBasedLight ScaleFactor.
        /// Scale factor controls light source intensity in [0.0f, 1.0f]
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
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
        /// Set/Get the UseFramebuffer.
        /// If this property is true, rendering result of SceneView is drawn on FBO and it is mapping on this SceneView plane.
        /// If this property is false, each item in SceneView is rendered on window directly.
        /// Default is false.
        /// </summary>
        /// <remarks>
        /// If UseFramebuffer is true, it could decrease performance but entire rendering order is satisfied.
        /// If UseFramebuffer is false, the performance becomes better but SceneView is rendered on the top of the other 2D components regardless tree order.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseFramebuffer
        {
            set
            {
                SetUseFramebuffer(value);
            }
            get
            {
                return IsUsingFramebuffer();
            }
        }

        /// <summary>
        /// Set/Get SkyboxUrl.
        /// If SkyboxUrl is set, the cube map image is loaded and skybox is attached on scene.
        /// Skybox texture is asynchronously loaded. When loading is finished, ResourcesLoaded is emitted.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SkyboxUrl
        {
            set
            {
                SetSkybox(value);
            }
            get
            {
                return skyboxUrl;
            }
        }

        /// <summary>
        /// Set/Get Skybox intensity.
        /// The skybox intensity is multiplied to the color of skybox texture.
        /// Default value is 1.0f.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SkyboxIntensity
        {
            set
            {
                SetSkyboxIntensity(value);
            }
            get
            {
                return GetSkyboxIntensity();
            }
        }

        /// <summary>
        /// Set/Get angle of orientation of the skybox.
        /// If orientation is set, the skybox will be rotate by the Radian orientation along YAxis.
        /// Default value is 0.0f.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation SkyboxOrientation
        {
            set
            {
                SetSkyboxOrientation(value);
            }
            get
            {
                return GetSkyboxOrientation();
            }
        }

        /// <summary>
        /// Adds a Camera to the SceneView at the end of the camera list of SceneView.
        /// The Camera can be used as a selected camera to render the scene by using <see cref="SelectCamera(uint)"/> or <see cref="SelectCamera(string)"/>
        /// </summary>
        /// <param name="camera">Camera added on this SceneView.</param>
        /// <remarks>
        /// Some properties of the Camera will be change depending on the Size of this SceneView.
        /// Those properties are as follows:
        /// AspectRatio, LeftPlaneDistance, RightPlaneDistance, TopPlaneDistance, and BottomPlaneDistance.
        ///
        /// The FieldOfView of Camera is for vertical fov.
        /// When the size of the SceneView is changed, the vertical fov is maintained
        /// and the horizontal fov is automatically calculated according to the SceneView's AspectRatio.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public void AddCamera(Camera camera)
        {
            if(camera != null)
            {
                Interop.SceneView.AddCamera(SwigCPtr, camera.SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Removes a Camera from this SceneView.
        /// If removed Camera is selected Camera,
        /// first camera in the list becomes the selected Camera.
        /// </summary>
        /// <param name="camera"> camera Camera to be removed from this Camera.</param>
        /// <remarks>
        /// When Camera.Dispose() is called, the NUI object is disposed, but camera information is maintained internally.
        /// Therefore, even if Camera.Dispose() is called, RemoveCamera() or RemoveCamera() methods can be used.
        /// If RemoveCamera() is called too, all information is deleted together.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public void RemoveCamera(Camera camera)
        {
            if(camera != null)
            {
                Interop.SceneView.RemoveCamera(SwigCPtr, camera.SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Retrieves the number of cameras.
        /// </summary>
        /// <returns>The number of Cameras.</returns>
        /// <since_tizen> 10 </since_tizen>
        public uint GetCameraCount()
        {
            uint count = Interop.SceneView.GetCameraCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return count;
        }

        /// <summary>
        /// Retrieves a Camera of the index.
        /// </summary>
        /// <param name="index"> Index of Camera to be retrieved.</param>
        /// <returns>Camera of the index.</returns>
        /// <since_tizen> 10 </since_tizen>
        public Camera GetCamera(uint index)
        {
            global::System.IntPtr cPtr = Interop.SceneView.GetCamera(SwigCPtr, index);
            Camera camera = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Camera;
            if(camera == null)
            {
                // Register new camera into Registry.
                camera = new Camera(cPtr, true);
            }
            else
            {
                // We found matched NUI camera. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Interop.Camera.DeleteCameraProperty(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return camera;
        }

        /// <summary>
        /// Retrieves a Camera of the input name.
        /// </summary>
        /// <param name="name"> string keyword of Camera to be retrieved.</param>
        /// <returns>Camera that has the name as a View.Name property</returns>
        /// <since_tizen> 10 </since_tizen>
        public Camera GetCamera(string name)
        {
            global::System.IntPtr cPtr = Interop.SceneView.GetCamera(SwigCPtr, name);
            Camera camera = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Camera;
            if(camera == null)
            {
                // Register new camera into Registry.
                camera = new Camera(cPtr, true);
            }
            else
            {
                // We found matched NUI camera. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Interop.Camera.DeleteCameraProperty(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return camera;
        }

        /// <summary>
        /// Makes SceneView use a Camera of index as a selected camera.
        /// </summary>
        /// <param name="index"> Index of Camera to be used as a selected camera.</param>
        /// <since_tizen> 10 </since_tizen>
        public void SelectCamera(uint index)
        {
            if(inCameraTransition)
            {
                return;
            }
            Interop.SceneView.SelectCamera(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Makes SceneView use a Camera of a name as a selected camera.
        /// </summary>
        /// <param name="name"> string keyword of Camera to be used as a selected camera.</param>
        /// <since_tizen> 10 </since_tizen>
        public void SelectCamera(string name)
        {
            if(inCameraTransition)
            {
                return;
            }
            Interop.SceneView.SelectCamera(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Starts camera transition from currently selected camera to a camera of index.
        /// Camera Position, Orientation and FieldOfView are smoothly animated.
        /// </summary>
        /// <remarks>
        /// The selected camera is switched to the Camera of the index when the transition is started.
        /// During camera transition, Selected Camera should not be changed by using SelectCamera() or CameraTransition() method.
        /// During camera transition, Camera properties of Selected Camera should not be changed.
        /// </remarks>
        /// <param name="index"> Index of destination Camera of Camera transition.</param>
        /// <param name="durationMilliSeconds">The duration in milliseconds.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <since_tizen> 10 </since_tizen>
        public void CameraTransition(uint index, int durationMilliSeconds, AlphaFunction alphaFunction = null)
        {
            if(inCameraTransition || GetSelectedCamera() == GetCamera(index))
            {
                return;
            }
            Camera source = GetSelectedCamera();
            SelectCamera(index);
            Camera destination = GetSelectedCamera();
            CameraTransition(source, destination, durationMilliSeconds, alphaFunction);
            source.Dispose();
            destination.Dispose();
        }

        /// <summary>
        /// Starts camera transition from currently selected camera to a camera of input name.
        /// Camera Position, Orientation and FieldOfView are smoothly animated.
        /// </summary>
        /// <remarks>
        /// The selected camera is switched to the Camera of the input name when the transition is started.
        /// During camera transition, Selected Camera should not be changed by using SelectCamera() or CameraTransition() method.
        /// During camera transition, Camera properties of Selected Camera should not be changed.
        /// </remarks>
        /// <param name="name"> string keyword of destination Camera of Camera transition.</param>
        /// <param name="durationMilliSeconds">The duration in milliseconds.</param>
        /// <param name="alphaFunction">The alpha function to apply.</param>
        /// <since_tizen> 10 </since_tizen>
        public void CameraTransition(string name, int durationMilliSeconds, AlphaFunction alphaFunction = null)
        {
            if(inCameraTransition || GetSelectedCamera() == GetCamera(name))
            {
                return;
            }
            Camera source = GetSelectedCamera();
            SelectCamera(name);
            Camera destination = GetSelectedCamera();
            CameraTransition(source, destination, durationMilliSeconds, alphaFunction);
            source.Dispose();
            destination.Dispose();
        }

        /// <summary>
        /// Retrieves selected Camera.
        /// </summary>
        /// <returns> Camera currently used in SceneView as a selected Camera.</returns>
        /// <since_tizen> 10 </since_tizen>
        public Camera GetSelectedCamera()
        {
            global::System.IntPtr cPtr = Interop.SceneView.GetSelectedCamera(SwigCPtr);
            Camera camera = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Camera;
            if(camera == null)
            {
                // Register new camera into Registry.
                camera = new Camera(cPtr, true);
            }
            else
            {
                // We found matched NUI camera. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Interop.Camera.DeleteCameraProperty(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return camera;
        }

        /// <summary>
        /// Changes Image Based Light as the input textures.
        /// </summary>
        /// <param name="diffuseUrl">The path of Cube map image that can be used as a diffuse IBL source.</param>
        /// <param name="specularUrl">The path of Cube map image that can be used as a specular IBL source.</param>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f]. Default value is 1.0f.</param>
        /// <remarks>
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public void SetImageBasedLightSource(string diffuseUrl, string specularUrl, float scaleFactor = 1.0f)
        {
            Interop.SceneView.SetImageBasedLightSource(SwigCPtr, diffuseUrl, specularUrl, scaleFactor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetUseFramebuffer(bool useFramebuffer)
        {
            Interop.SceneView.UseFramebuffer(SwigCPtr, useFramebuffer);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsUsingFramebuffer()
        {
            bool result = Interop.SceneView.IsUsingFramebuffer(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Set the ImageBasedLight ScaleFactor.
        /// </summary>
        /// <param name="scaleFactor">Scale factor that controls light source intensity in [0.0f, 1.0f].</param>
        private void SetImageBasedLightScaleFactor(float scaleFactor)
        {
            Interop.SceneView.SetImageBasedLightScaleFactor(SwigCPtr, scaleFactor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the ImageBasedLight ScaleFactor.
        /// </summary>
        /// <returns>ImageBasedLightScaleFactor that controls light source intensity.</returns>
        private float GetImageBasedLightScaleFactor()
        {
            float scaleFactor = Interop.SceneView.GetImageBasedLightScaleFactor(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return scaleFactor;
        }

        /// <summary>
        /// Set the Skybox from cube map image.
        /// Skybox texture is asynchronously loaded. When loading is finished, ResourcesLoaded is emitted.
        /// </summary>
        /// <param name="skyboxUrl">Cube map image url for skybox.</param>
        private void SetSkybox(string skyboxUrl)
        {
            this.skyboxUrl = skyboxUrl;
            Interop.SceneView.SetSkybox(SwigCPtr, skyboxUrl);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Skybox intensity.
        /// The skybox intensity is multiplied to the color of skybox texture.
        /// Default value is 1.0f.
        /// </summary>
        /// <param name="intensity">Intensity value to be multiplied to the cube map color.</param>
        private void SetSkyboxIntensity(float intensity)
        {
            Interop.SceneView.SetSkyboxIntensity(SwigCPtr, intensity);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets Skybox intensity.
        /// Default value is 1.0f.
        /// </summary>
        /// <returns>skybox intensity.</returns>
        private float GetSkyboxIntensity()
        {
            float intensity = Interop.SceneView.GetSkyboxIntensity(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return intensity;
        }

        /// <summary>
        /// Sets orientation of the skybox.
        /// </summary>
        /// <param name="orientation">Rotation angle of the skybox along YAxis.</param>
        private void SetSkyboxOrientation(Rotation orientation)
        {
            Interop.SceneView.SetSkyboxOrientation(SwigCPtr, Rotation.getCPtr(orientation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets Skybox orientation.
        /// </summary>
        /// <returns>skybox orientation.</returns>
        private Rotation GetSkyboxOrientation()
        {
            global::System.IntPtr cPtr = Interop.SceneView.GetSkyboxOrientation(SwigCPtr);
            Rotation ret = (cPtr == global::System.IntPtr.Zero) ? null : new Rotation(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void CameraTransition(Camera sourceCamera, Camera destinationCamera, int durationMilliSeconds, AlphaFunction alphaFunction)
        {
            inCameraTransition = true;

            Position sourcePosition = sourceCamera.Position;
            Rotation sourceOrientation = sourceCamera.Orientation;

            Position destinationPosition = destinationCamera.Position;
            Rotation destinationOrientation = destinationCamera.Orientation;

            cameraTransition = new Animation(durationMilliSeconds);

            KeyFrames positionKeyFrames = new KeyFrames();
            positionKeyFrames.Add(0.0f, sourcePosition);
            positionKeyFrames.Add(1.0f, destinationPosition);

            KeyFrames orientationKeyFrames = new KeyFrames();
            orientationKeyFrames.Add(0.0f, sourceOrientation);
            orientationKeyFrames.Add(1.0f, destinationOrientation);

            cameraTransition.AnimateBetween(destinationCamera, "Position", positionKeyFrames, Animation.Interpolation.Linear, alphaFunction);
            cameraTransition.AnimateBetween(destinationCamera, "Orientation", orientationKeyFrames, Animation.Interpolation.Linear, alphaFunction);

            if(destinationCamera.ProjectionMode == Camera.ProjectionModeType.Perspective)
            {
                Radian sourceFieldOfView = sourceCamera.FieldOfView;
                Radian destinationFieldOfView = destinationCamera.FieldOfView;

                // If ProjectionDirection is not equal, match the value.
                if (sourceCamera.ProjectionDirection != destinationCamera.ProjectionDirection)
                {
                    float aspect = destinationCamera.AspectRatio;
                    if (destinationCamera.ProjectionDirection == Camera.ProjectionDirectionType.Vertical)
                    {
                        sourceFieldOfView = Camera.ConvertFovFromHorizontalToVertical(aspect, sourceFieldOfView);
                    }
                    else
                    {
                        sourceFieldOfView = Camera.ConvertFovFromVerticalToHorizontal(aspect, sourceFieldOfView);
                    }
                }

                KeyFrames fieldOfViewKeyFrames = new KeyFrames();
                fieldOfViewKeyFrames.Add(0.0f, sourceFieldOfView.ConvertToFloat());
                fieldOfViewKeyFrames.Add(1.0f, destinationFieldOfView.ConvertToFloat());
                cameraTransition.AnimateBetween(destinationCamera, "FieldOfView", fieldOfViewKeyFrames, Animation.Interpolation.Linear, alphaFunction);

                sourceFieldOfView.Dispose();
                destinationFieldOfView.Dispose();
                fieldOfViewKeyFrames.Dispose();
            }
            else
            {
                float sourceOrthographicSize = sourceCamera.OrthographicSize;
                float destinationOrthographicSize = destinationCamera.OrthographicSize;

                // If ProjectionDirection is not equal, match the value.
                if (sourceCamera.ProjectionDirection != destinationCamera.ProjectionDirection)
                {
                    float aspect = destinationCamera.AspectRatio;
                    if (destinationCamera.ProjectionDirection == Camera.ProjectionDirectionType.Vertical)
                    {
                        sourceOrthographicSize = sourceOrthographicSize / aspect;
                    }
                    else
                    {
                        sourceOrthographicSize = sourceOrthographicSize * aspect;
                    }
                }

                KeyFrames orthographicSizeKeyFrames = new KeyFrames();
                orthographicSizeKeyFrames.Add(0.0f, sourceOrthographicSize);
                orthographicSizeKeyFrames.Add(1.0f, destinationOrthographicSize);
                cameraTransition.AnimateBetween(destinationCamera, "OrthographicSize", orthographicSizeKeyFrames, Animation.Interpolation.Linear, alphaFunction);

                orthographicSizeKeyFrames.Dispose();
            }

            float destinationNearPlaneDistance = destinationCamera.NearPlaneDistance;
            float destinationFarPlaneDistance = destinationCamera.FarPlaneDistance;
            destinationCamera.NearPlaneDistance = Math.Min(sourceCamera.NearPlaneDistance, destinationCamera.NearPlaneDistance);
            destinationCamera.FarPlaneDistance = Math.Max(sourceCamera.FarPlaneDistance, destinationCamera.FarPlaneDistance);

            cameraTransition.Finished += (s, e) =>
            {
                this.GetSelectedCamera().NearPlaneDistance = destinationNearPlaneDistance;
                this.GetSelectedCamera().FarPlaneDistance = destinationFarPlaneDistance;
                inCameraTransition = false;
                CameraTransitionFinished?.Invoke(this, EventArgs.Empty);
            };
            cameraTransition.Play();

            positionKeyFrames.Dispose();
            orientationKeyFrames.Dispose();
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.SceneView.DeleteScene(swigCPtr);
        }
    }
}
