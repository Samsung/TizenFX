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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Camera class controls a camera in 3D space.
    ///
    /// Camera can be added on the SceneView and displays SceneView's virtual 3D world to the screen.
    /// Camera can be translated and rotated in the space.
    /// </summary>
    /// <remarks>
    /// Transform inheritance cannot be guaranteed when adding children to a camera.
    /// </remarks>
    /// <since_tizen> 10 </since_tizen>
    public partial class Camera : View
    {
        internal Camera(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Camera(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, true, cRegister)
        {
        }

        /// <summary>
        /// Creates an uninitialized Camera.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public Camera() : this(Interop.Camera.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="camera">The Camera object to be copied.</param>
        /// <since_tizen> 10 </since_tizen>
        public Camera(Camera camera) : this(Interop.Camera.NewCamera(Camera.getCPtr(camera)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Camera Assign(Camera rhs)
        {
            Camera ret = new Camera(Interop.Camera.Assign(SwigCPtr, Camera.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates a CameraActor object.
        /// Sets the default camera perspective projection for the given canvas size..
        /// </summary>
        internal Camera(Vector2 size) : this(Interop.Camera.New(Vector2.getCPtr(size)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static Camera DownCast(BaseHandle handle)
        {
            if (handle == null)
            {
                throw new global::System.ArgumentNullException(nameof(handle));
            }
            Camera ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Camera;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enumeration for the projectionMode.
        /// ProjectionMode defines how the camera shows 3D objects or scene on a 2D plane with projection.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public enum ProjectionModeType
        {
            /// <summary>
            /// Distance causes foreshortening; objects further from the camera appear smaller.
            /// </summary>
            Perspective,
            /// <summary>
            /// Relative distance from the camera does not affect the size of objects.
            /// </summary>
            Orthographic
        }

        /// <summary>
        /// Enumeration for the projectionDirection.
        /// </summary>
        /// This will be released at Tizen.NET API Level 10, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ProjectionDirectionType
        {
            /// <summary>
            /// Distance causes foreshortening; objects further from the camera appear smaller.
            /// </summary>
            Vertical,
            /// <summary>
            /// Relative distance from the camera does not affect the size of objects.
            /// </summary>
            Horizontal
        }

        /// <summary>
        /// Sets/Gets the projection mode.
        /// The default is Perspective
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public ProjectionModeType ProjectionMode
        {
            get
            {
                return (ProjectionModeType)GetValue(ProjectionProperty);
            }
            set
            {
                SetValue(ProjectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// <para>
        /// Sets/Gets the projection direction.
        /// Projection direction determine basic direction of projection relative properties.
        /// It will be used when we need to calculate some values relative with aspect ratio.
        /// <see cref="FieldOfView"/>, and <see cref="OrthographicSize"/>
        /// </para>
        /// <para>
        /// For example, if aspect ratio is 4:3 and set fieldOfView as 60 degree.
        /// If ProjectionDirectionType.Vertical, basic direction is vertical. so, FoV of horizontal direction become ~75.2 degree
        /// If ProjectionDirectionType.Horizontal, basic direction is horizontal. so, FoV of vertical direction become ~46.8 degree
        /// </para>
        /// <note>
        /// This property doesn't change <see cref="FieldOfView"/> and <see cref="OrthographicSize"/> value automatically.
        /// So result scene might be changed.
        /// </note>
        /// <para>The default is Vertical.</para>
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProjectionDirectionType ProjectionDirection
        {
            get
            {
                return (ProjectionDirectionType)GetValue(ProjectionDirectionProperty);
            }
            set
            {
                SetValue(ProjectionDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets/Gets the field of view in Radians.
        /// FieldOfView depends on <see cref="ProjectionDirection"/> value.
        /// The default field of view is 45 degrees.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public Radian FieldOfView
        {
            get
            {
                return new Radian((float)GetValue(FieldOfViewProperty));
            }
            set
            {
                SetValue(FieldOfViewProperty, value?.ConvertToFloat() ?? 0.0f);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets/Gets Orthographic Size of this camera.
        /// OrthographicSize depends on <see cref="ProjectionDirection"/> value.
        /// If ProjectoinDirection is Vertical, OrthographicSize is height/2 of viewing cube of Orthographic projection.
        /// If ProjectoinDirection is Horizontal, OrthographicSize is width/2 of viewing cube of Orthographic projection.
        /// Remained Width or Height of viewing cube is internally computed by using aspect ratio of Viewport.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public float OrthographicSize
        {
            get
            {
                return InternalOrthographicSize;
            }
            set
            {
                SetValue(OrthographicSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the aspect ratio of the camera.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public float AspectRatio
        {
            get
            {
                return (float)GetValue(AspectRatioProperty);
            }
        }

        /// <summary>
        /// Sets/Gets the near clipping plane distance.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public float NearPlaneDistance
        {
            get
            {
                return (float)GetValue(NearPlaneDistanceProperty);
            }
            set
            {
                SetValue(NearPlaneDistanceProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets/Gets the far clipping plane distance.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public float FarPlaneDistance
        {
            get
            {
                return (float)GetValue(FarPlaneDistanceProperty);
            }
            set
            {
                SetValue(FarPlaneDistanceProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the left clipping plane distance.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float LeftPlaneDistance
        {
            get
            {
                return (float)GetValue(LeftPlaneDistanceProperty);
            }
        }

        /// <summary>
        /// Gets the right clipping plane distance.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RightPlaneDistance
        {
            get
            {
                return (float)GetValue(RightPlaneDistanceProperty);
            }
        }

        /// <summary>
        /// Gets the top clipping plane distance.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TopPlaneDistance
        {
            get
            {
                return (float)GetValue(TopPlaneDistanceProperty);
            }
        }

        /// <summary>
        /// Gets the bottom clipping plane distance.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BottomPlaneDistance
        {
            get
            {
                return (float)GetValue(BottomPlaneDistanceProperty);
            }
        }

        /// <summary>
        /// Requests for an inversion on the Y axis on the projection calculation.
        /// or gets whether the Y axis is inverted.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InvertYAxis
        {
            get
            {
                return (bool)GetValue(InvertYAxisProperty);
            }
            set
            {
                SetValue(InvertYAxisProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets ProjectionMatrix of this Camera
        /// TODO : Open Matrix
        /// </summary>
        internal Matrix ProjectionMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue projectionMatrix = GetProperty(Interop.Camera.ProjectionMatrixGet());
                projectionMatrix?.Get(returnValue);
                projectionMatrix?.Dispose();
                return returnValue;
            }
        }

        /// <summary>
        /// Gets ViewMatrix of this Camera
        /// TODO : Open Matrix
        /// </summary>
        internal Matrix ViewMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue viewMatrix = GetProperty(Interop.Camera.ViewMatrixGet());
                viewMatrix.Get(returnValue);
                viewMatrix.Dispose();
                return returnValue;
            }
        }

        private ProjectionModeType InternalProjectionMode
        {
            get
            {
                int returnValue = (int)ProjectionModeType.Perspective;
                PropertyValue projectionMode = GetProperty(Interop.Camera.ProjectionModeGet());
                projectionMode?.Get(out returnValue);
                projectionMode?.Dispose();
                return (ProjectionModeType)returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue((int)value);
                SetProperty(Interop.Camera.ProjectionModeGet(), setValue);
                setValue.Dispose();
            }
        }

        private ProjectionDirectionType InternalProjectionDirection
        {
            get
            {
                int returnValue = (int)ProjectionDirectionType.Vertical;
                PropertyValue projectionDirection = GetProperty(Interop.Camera.ProjectionDirectionGet());
                projectionDirection?.Get(out returnValue);
                projectionDirection?.Dispose();
                return (ProjectionDirectionType)returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue((int)value);
                SetProperty(Interop.Camera.ProjectionDirectionGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalFieldOfView
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue fieldView = GetProperty(Interop.Camera.FieldOfViewGet());
                fieldView?.Get(out returnValue);
                fieldView?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.FieldOfViewGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalOrthographicSize
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue orthographicSize = GetProperty(Interop.Camera.OrthographicSizeGet());
                orthographicSize?.Get(out returnValue);
                orthographicSize?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.OrthographicSizeGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalAspectRatio
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue aspectRatio = GetProperty(Interop.Camera.AspectRatioGet());
                aspectRatio?.Get(out returnValue);
                aspectRatio?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.AspectRatioGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalNearPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue nearPlaneDistance = GetProperty(Interop.Camera.NearPlaneDistanceGet());
                nearPlaneDistance?.Get(out returnValue);
                nearPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.NearPlaneDistanceGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalFarPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue farPlaneDistance = GetProperty(Interop.Camera.FarPlaneDistanceGet());
                farPlaneDistance?.Get(out returnValue);
                farPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.FarPlaneDistanceGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalLeftPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue leftPlaneDistance = GetProperty(Interop.Camera.LeftPlaneDistanceGet());
                leftPlaneDistance?.Get(out returnValue);
                leftPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.LeftPlaneDistanceGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalRightPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue rightPlaneDistance = GetProperty(Interop.Camera.RightPlaneDistanceGet());
                rightPlaneDistance?.Get(out returnValue);
                rightPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.RightPlaneDistanceGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalTopPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue topPlaneDistance = GetProperty(Interop.Camera.TopPlaneDistanceGet());
                topPlaneDistance?.Get(out returnValue);
                topPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.TopPlaneDistanceGet(), setValue);
                setValue.Dispose();
            }
        }

        private float InternalBottomPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue bottomPlaneDistance = GetProperty(Interop.Camera.BottomPlaneDistanceGet());
                bottomPlaneDistance?.Get(out returnValue);
                bottomPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.BottomPlaneDistanceGet(), setValue);
                setValue.Dispose();
            }
        }

        private bool InternalInvertYAxis
        {
            get
            {
                bool returnValue = false;
                PropertyValue invertYAxis = GetProperty(Interop.Camera.InvertYAxisGet());
                invertYAxis?.Get(out returnValue);
                invertYAxis?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Camera.InvertYAxisGet(), setValue);
                setValue.Dispose();
            }
        }

        internal void SetProjection(ProjectionModeType mode)
        {
            Interop.Camera.SetProjectionMode(SwigCPtr, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ProjectionModeType GetProjection()
        {
            ProjectionModeType ret = (ProjectionModeType)Interop.Camera.GetProjectionMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFieldOfView(float fieldOfView)
        {
            Interop.Camera.SetFieldOfView(SwigCPtr, fieldOfView);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetFieldOfView()
        {
            float ret = Interop.Camera.GetFieldOfView(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetAspectRatio(float aspectRatio)
        {
            Interop.Camera.SetAspectRatio(SwigCPtr, aspectRatio);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetAspectRatio()
        {
            float ret = Interop.Camera.GetAspectRatio(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetNearClippingPlane(float nearClippingPlane)
        {
            Interop.Camera.SetNearClippingPlane(SwigCPtr, nearClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetNearClippingPlane()
        {
            float ret = Interop.Camera.GetNearClippingPlane(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFarClippingPlane(float farClippingPlane)
        {
            Interop.Camera.SetFarClippingPlane(SwigCPtr, farClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetFarClippingPlane()
        {
            float ret = Interop.Camera.GetFarClippingPlane(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInvertYAxis(bool invertYAxis)
        {
            Interop.Camera.SetInvertYAxis(SwigCPtr, invertYAxis);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool GetInvertYAxis()
        {
            bool ret = Interop.Camera.GetInvertYAxis(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Convert from vertical fov to horizontal fov consider with camera's AspectRatio.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ConvertFovFromVerticalToHorizontal(float aspect, ref Radian fov)
        {
            if (fov == null)
            {
                return;
            }
            fov.Value = 2.0f * (float)Math.Atan(Math.Tan(fov.ConvertToFloat() * 0.5f) * aspect);
        }

        /// <summary>
        /// Convert from horizontal fov to vertical fov consider with camera's AspectRatio.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ConvertFovFromHorizontalToVertical(float aspect, ref Radian fov)
        {
            if (fov == null)
            {
                return;
            }
            fov.Value = 2.0f * (float)Math.Atan(Math.Tan(fov.ConvertToFloat() * 0.5f) / aspect);
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Camera.DeleteCamera(swigCPtr);
        }
    }
}
