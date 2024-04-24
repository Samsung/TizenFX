/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using System.Net;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    [global::System.Obsolete("Do not use this. Use Tizen.NUI.Scene3D.Camera instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class Camera : View
    {
        static Camera()
        {
            if (NUIApplication.IsUsingXaml)
            {
                TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(Tizen.NUI.Camera), string.Empty,
                    propertyChanged: SetInternalTypeProperty, defaultValueCreator: GetInternalTypeProperty);

                ProjectionModeProperty = BindableProperty.Create(nameof(ProjectionMode), typeof(string), typeof(Tizen.NUI.Camera), string.Empty,
                    propertyChanged: SetInternalProjectionModeProperty, defaultValueCreator: GetInternalProjectionModeProperty);

                FieldOfViewProperty = BindableProperty.Create(nameof(FieldOfView), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalFieldOfViewProperty, defaultValueCreator: GetInternalFieldOfViewProperty);

                AspectRatioProperty = BindableProperty.Create(nameof(AspectRatio), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalAspectRatioProperty, defaultValueCreator: GetInternalAspectRatioProperty);

                NearPlaneDistanceProperty = BindableProperty.Create(nameof(NearPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalNearPlaneDistanceProperty, defaultValueCreator: GetInternalNearPlaneDistanceProperty);

                FarPlaneDistanceProperty = BindableProperty.Create(nameof(FarPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalFarPlaneDistanceProperty, defaultValueCreator: GetInternalFarPlaneDistanceProperty);

                LeftPlaneDistanceProperty = BindableProperty.Create(nameof(LeftPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalLeftPlaneDistanceProperty, defaultValueCreator: GetInternalLeftPlaneDistanceProperty);

                RightPlaneDistanceProperty = BindableProperty.Create(nameof(RightPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalRightPlaneDistanceProperty, defaultValueCreator: GetInternalRightPlaneDistanceProperty);

                TopPlaneDistanceProperty = BindableProperty.Create(nameof(TopPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalTopPlaneDistanceProperty, defaultValueCreator: GetInternalTopPlaneDistanceProperty);

                BottomPlaneDistanceProperty = BindableProperty.Create(nameof(BottomPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), default(float),
                    propertyChanged: SetInternalBottomPlaneDistanceProperty, defaultValueCreator: GetInternalBottomPlaneDistanceProperty);

                TargetPositionProperty = BindableProperty.Create(nameof(TargetPosition), typeof(Tizen.NUI.Vector3), typeof(Tizen.NUI.Camera), null,
                    propertyChanged: SetInternalTargetPositionProperty, defaultValueCreator: GetInternalTargetPositionProperty);

                InvertYAxisProperty = BindableProperty.Create(nameof(InvertYAxis), typeof(bool), typeof(Tizen.NUI.Camera), false,
                    propertyChanged: SetInternalInvertYAxisProperty, defaultValueCreator: GetInternalInvertYAxisProperty);
            }
        }

        internal Camera(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CameraActor.DeleteCameraActor(swigCPtr);
        }

        new internal class Property
        {
            internal static readonly int TYPE = Interop.CameraActor.TypeGet();
            internal static readonly int ProjectionMode = Interop.CameraActor.ProjectionModeGet();
            internal static readonly int FieldOfView = Interop.CameraActor.FieldOfViewGet();
            internal static readonly int AspectRatio = Interop.CameraActor.AspectRatioGet();
            internal static readonly int NearPlaneDistance = Interop.CameraActor.NearPlaneDistanceGet();
            internal static readonly int FarPlaneDistance = Interop.CameraActor.FarPlaneDistanceGet();
            internal static readonly int LeftPlaneDistance = Interop.CameraActor.LeftPlaneDistanceGet();
            internal static readonly int RightPlaneDistance = Interop.CameraActor.RightPlaneDistanceGet();
            internal static readonly int TopPlaneDistance = Interop.CameraActor.TopPlaneDistanceGet();
            internal static readonly int BottomPlaneDistance = Interop.CameraActor.BottomPlaneDistanceGet();
            internal static readonly int TargetPosition = Interop.CameraActor.TargetPositionGet();
            internal static readonly int ProjectionMatrix = Interop.CameraActor.ProjectionMatrixGet();
            internal static readonly int ViewMatrix = Interop.CameraActor.ViewMatrixGet();
            internal static readonly int InvertYAxis = Interop.CameraActor.InvertYAxisGet();
        }

        public Camera() : this(Interop.CameraActor.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Camera(Vector2 size) : this(Interop.CameraActor.New(Vector2.getCPtr(size)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Camera DownCast(BaseHandle handle)
        {
            if (handle == null)
            {
                throw new global::System.ArgumentNullException(nameof(handle));
            }
            Camera ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Camera;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Camera(Camera copy) : this(Interop.CameraActor.NewCameraActor(Camera.getCPtr(copy)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Camera Assign(Camera rhs)
        {
            Camera ret = new Camera(Interop.CameraActor.Assign(SwigCPtr, Camera.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetType(CameraType type)
        {
            Interop.CameraActor.SetType(SwigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new CameraType GetType()
        {
            CameraType ret = (CameraType)Interop.CameraActor.GetType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetProjectionMode(ProjectionMode mode)
        {
            Interop.CameraActor.SetProjectionMode(SwigCPtr, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ProjectionMode GetProjectionMode()
        {
            ProjectionMode ret = (ProjectionMode)Interop.CameraActor.GetProjectionMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use FieldOfView property instead.")]
        public void SetFieldOfView(float fieldOfView)
        {
            Interop.CameraActor.SetFieldOfView(SwigCPtr, fieldOfView);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use FieldOfView property instead.")]
        public float GetFieldOfView()
        {
            float ret = Interop.CameraActor.GetFieldOfView(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use AspectRatio property instead.")]
        public void SetAspectRatio(float aspectRatio)
        {
            Interop.CameraActor.SetAspectRatio(SwigCPtr, aspectRatio);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use AspectRatio property instead.")]
        public float GetAspectRatio()
        {
            float ret = Interop.CameraActor.GetAspectRatio(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetNearClippingPlane(float nearClippingPlane)
        {
            Interop.CameraActor.SetNearClippingPlane(SwigCPtr, nearClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetNearClippingPlane()
        {
            float ret = Interop.CameraActor.GetNearClippingPlane(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFarClippingPlane(float farClippingPlane)
        {
            Interop.CameraActor.SetFarClippingPlane(SwigCPtr, farClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFarClippingPlane()
        {
            float ret = Interop.CameraActor.GetFarClippingPlane(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use TargetPosition property instead.")]
        public void SetTargetPosition(Vector3 targetPosition)
        {
            Interop.CameraActor.SetTargetPosition(SwigCPtr, Vector3.getCPtr(targetPosition));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use TargetPosition property instead.")]
        public Vector3 GetTargetPosition()
        {
            Vector3 ret = new Vector3(Interop.CameraActor.GetTargetPosition(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use InvertYAxis property instead.")]
        public void SetInvertYAxis(bool invertYAxis)
        {
            Interop.CameraActor.SetInvertYAxis(SwigCPtr, invertYAxis);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use InvertYAxis property instead.")]
        public bool GetInvertYAxis()
        {
            bool ret = Interop.CameraActor.GetInvertYAxis(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPerspectiveProjection(Vector2 size)
        {
            Interop.CameraActor.SetPerspectiveProjection(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrthographicProjection(Vector2 size)
        {
            Interop.CameraActor.SetOrthographicProjection(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrthographicProjection(float left, float right, float top, float bottom, float near, float far)
        {
            Interop.CameraActor.SetOrthographicProjection(SwigCPtr, left, right, top, bottom, near, far);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        // The type of GetType() and SetType() is different from Type property.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1721: Property names should not match get methods")]
        public string Type
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TypeProperty) as string;
                }
                else
                {
                    return GetInternalTypeProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TypeProperty, value);
                }
                else
                {
                    SetInternalTypeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private string InternalType
        {
            get
            {
                string returnValue = "";
                PropertyValue type = GetProperty(Camera.Property.TYPE);
                type?.Get(out returnValue);
                type?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.TYPE, setValue);
                setValue.Dispose();
            }
        }

        // The type of GetProjectionMode() and SetProjectionMode() is different from Projection Property.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1721: Property names should not match get methods")]
        public string ProjectionMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ProjectionModeProperty) as string;
                }
                else
                {
                    return GetInternalProjectionModeProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ProjectionModeProperty, value);
                }
                else
                {
                    SetInternalProjectionModeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private string InternalProjectionMode
        {
            get
            {
                string returnValue = "";
                PropertyValue projectionMode = GetProperty(Camera.Property.ProjectionMode);
                projectionMode?.Get(out returnValue);
                projectionMode?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.ProjectionMode, setValue);
                setValue.Dispose();
            }
        }

        public float FieldOfView
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(FieldOfViewProperty);
                }
                else
                {
                    return (float)GetInternalFieldOfViewProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FieldOfViewProperty, value);
                }
                else
                {
                    SetInternalFieldOfViewProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalFieldOfView
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue fieldView = GetProperty(Camera.Property.FieldOfView);
                fieldView?.Get(out returnValue);
                fieldView?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.FieldOfView, setValue);
                setValue.Dispose();
            }
        }

        public float AspectRatio
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(AspectRatioProperty);
                }
                else
                {
                    return (float)GetInternalAspectRatioProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AspectRatioProperty, value);
                }
                else
                {
                    SetInternalAspectRatioProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalAspectRatio
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue aspectRatio = GetProperty(Camera.Property.AspectRatio);
                aspectRatio?.Get(out returnValue);
                aspectRatio?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.AspectRatio, setValue);
                setValue.Dispose();
            }
        }

        public float NearPlaneDistance
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(NearPlaneDistanceProperty);
                }
                else
                {
                    return (float)GetInternalNearPlaneDistanceProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(NearPlaneDistanceProperty, value);
                }
                else
                {
                    SetInternalNearPlaneDistanceProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalNearPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue nearPlaneDistance = GetProperty(Camera.Property.NearPlaneDistance);
                nearPlaneDistance?.Get(out returnValue);
                nearPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.NearPlaneDistance, setValue);
                setValue.Dispose();
            }
        }

        public float FarPlaneDistance
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(FarPlaneDistanceProperty);
                }
                else
                {
                    return (float)GetInternalFarPlaneDistanceProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FarPlaneDistanceProperty, value);
                }
                else
                {
                    SetInternalFarPlaneDistanceProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalFarPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue farPlaneDistance = GetProperty(Camera.Property.FarPlaneDistance);
                farPlaneDistance?.Get(out returnValue);
                farPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.FarPlaneDistance, setValue);
                setValue.Dispose();
            }
        }

        public float LeftPlaneDistance
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(LeftPlaneDistanceProperty);
                }
                else
                {
                    return (float)GetInternalLeftPlaneDistanceProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LeftPlaneDistanceProperty, value);
                }
                else
                {
                    SetInternalLeftPlaneDistanceProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalLeftPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue leftPlaneDistance = GetProperty(Camera.Property.LeftPlaneDistance);
                leftPlaneDistance?.Get(out returnValue);
                leftPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.LeftPlaneDistance, setValue);
                setValue.Dispose();
            }
        }

        public float RightPlaneDistance
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(RightPlaneDistanceProperty);
                }
                else
                {
                    return (float)GetInternalRightPlaneDistanceProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RightPlaneDistanceProperty, value);
                }
                else
                {
                    SetInternalRightPlaneDistanceProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalRightPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue rightPlaneDistance = GetProperty(Camera.Property.RightPlaneDistance);
                rightPlaneDistance?.Get(out returnValue);
                rightPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.RightPlaneDistance, setValue);
                setValue.Dispose();
            }
        }

        public float TopPlaneDistance
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(TopPlaneDistanceProperty);
                }
                else
                {
                    return (float)GetInternalTopPlaneDistanceProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TopPlaneDistanceProperty, value);
                }
                else
                {
                    SetInternalTopPlaneDistanceProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalTopPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue topPlaneDistance = GetProperty(Camera.Property.TopPlaneDistance);
                topPlaneDistance?.Get(out returnValue);
                topPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.TopPlaneDistance, setValue);
                setValue.Dispose();
            }
        }

        public float BottomPlaneDistance
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(BottomPlaneDistanceProperty);
                }
                else
                {
                    return (float)GetInternalBottomPlaneDistanceProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BottomPlaneDistanceProperty, value);
                }
                else
                {
                    SetInternalBottomPlaneDistanceProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private float InternalBottomPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue bottomPlaneDistance = GetProperty(Camera.Property.BottomPlaneDistance);
                bottomPlaneDistance?.Get(out returnValue);
                bottomPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.BottomPlaneDistance, setValue);
                setValue.Dispose();
            }
        }

        public Vector3 TargetPosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TargetPositionProperty) as Vector3;
                }
                else
                {
                    return GetInternalTargetPositionProperty(this) as Vector3;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TargetPositionProperty, value);
                }
                else
                {
                    SetInternalTargetPositionProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private Vector3 InternalTargetPosition
        {
            get
            {
                Vector3 returnValue = new Vector3(0.0f, 0.0f, 0.0f);
                PropertyValue targetPosition = GetProperty(Camera.Property.TargetPosition);
                targetPosition?.Get(returnValue);
                targetPosition?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.TargetPosition, setValue);
                setValue.Dispose();
            }
        }
        internal Matrix ProjectionMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue projectionMatrix = GetProperty(Camera.Property.ProjectionMatrix);
                projectionMatrix?.Get(returnValue);
                projectionMatrix?.Dispose();
                return returnValue;
            }
        }
        internal Matrix ViewMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue viewMatrix = GetProperty(Camera.Property.ViewMatrix);
                viewMatrix.Get(returnValue);
                viewMatrix.Dispose();
                return returnValue;
            }
        }

        public bool InvertYAxis
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(InvertYAxisProperty);
                }
                else
                {
                    return (bool)GetInternalInvertYAxisProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InvertYAxisProperty, value);
                }
                else
                {
                    SetInternalInvertYAxisProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalInvertYAxis
        {
            get
            {
                bool returnValue = false;
                PropertyValue invertYAxis = GetProperty(Camera.Property.InvertYAxis);
                invertYAxis?.Get(out returnValue);
                invertYAxis?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.InvertYAxis, setValue);
                setValue.Dispose();
            }
        }
    }
}
