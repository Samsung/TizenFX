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

using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// This will be released at Tizen.NET API Level 6, so currently this would be used as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Camera : View
    {

        internal Camera(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CameraActor.CameraActor_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Camera obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CameraActor.delete_CameraActor(swigCPtr);
        }

        internal class Property
        {
            internal static readonly int TYPE = Interop.CameraActor.CameraActor_Property_TYPE_get();
            internal static readonly int PROJECTION_MODE = Interop.CameraActor.CameraActor_Property_PROJECTION_MODE_get();
            internal static readonly int FIELD_OF_VIEW = Interop.CameraActor.CameraActor_Property_FIELD_OF_VIEW_get();
            internal static readonly int ASPECT_RATIO = Interop.CameraActor.CameraActor_Property_ASPECT_RATIO_get();
            internal static readonly int NEAR_PLANE_DISTANCE = Interop.CameraActor.CameraActor_Property_NEAR_PLANE_DISTANCE_get();
            internal static readonly int FAR_PLANE_DISTANCE = Interop.CameraActor.CameraActor_Property_FAR_PLANE_DISTANCE_get();
            internal static readonly int LEFT_PLANE_DISTANCE = Interop.CameraActor.CameraActor_Property_LEFT_PLANE_DISTANCE_get();
            internal static readonly int RIGHT_PLANE_DISTANCE = Interop.CameraActor.CameraActor_Property_RIGHT_PLANE_DISTANCE_get();
            internal static readonly int TOP_PLANE_DISTANCE = Interop.CameraActor.CameraActor_Property_TOP_PLANE_DISTANCE_get();
            internal static readonly int BOTTOM_PLANE_DISTANCE = Interop.CameraActor.CameraActor_Property_BOTTOM_PLANE_DISTANCE_get();
            internal static readonly int TARGET_POSITION = Interop.CameraActor.CameraActor_Property_TARGET_POSITION_get();
            internal static readonly int PROJECTION_MATRIX = Interop.CameraActor.CameraActor_Property_PROJECTION_MATRIX_get();
            internal static readonly int VIEW_MATRIX = Interop.CameraActor.CameraActor_Property_VIEW_MATRIX_get();
            internal static readonly int INVERT_Y_AXIS = Interop.CameraActor.CameraActor_Property_INVERT_Y_AXIS_get();
        }

        public Camera() : this(Interop.CameraActor.CameraActor_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Camera(Vector2 size) : this(Interop.CameraActor.CameraActor_New__SWIG_1(Vector2.getCPtr(size)), true)
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

        public Camera(Camera copy) : this(Interop.CameraActor.new_CameraActor__SWIG_1(Camera.getCPtr(copy)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Camera Assign(Camera rhs)
        {
            Camera ret = new Camera(Interop.CameraActor.CameraActor_Assign(swigCPtr, Camera.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetType(CameraType type)
        {
            Interop.CameraActor.CameraActor_SetType(swigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new CameraType GetType()
        {
            CameraType ret = (CameraType)Interop.CameraActor.CameraActor_GetType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetProjectionMode(ProjectionMode mode)
        {
            Interop.CameraActor.CameraActor_SetProjectionMode(swigCPtr, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ProjectionMode GetProjectionMode()
        {
            ProjectionMode ret = (ProjectionMode)Interop.CameraActor.CameraActor_GetProjectionMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFieldOfView(float fieldOfView)
        {
            Interop.CameraActor.CameraActor_SetFieldOfView(swigCPtr, fieldOfView);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFieldOfView()
        {
            float ret = Interop.CameraActor.CameraActor_GetFieldOfView(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAspectRatio(float aspectRatio)
        {
            Interop.CameraActor.CameraActor_SetAspectRatio(swigCPtr, aspectRatio);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetAspectRatio()
        {
            float ret = Interop.CameraActor.CameraActor_GetAspectRatio(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetNearClippingPlane(float nearClippingPlane)
        {
            Interop.CameraActor.CameraActor_SetNearClippingPlane(swigCPtr, nearClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetNearClippingPlane()
        {
            float ret = Interop.CameraActor.CameraActor_GetNearClippingPlane(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFarClippingPlane(float farClippingPlane)
        {
            Interop.CameraActor.CameraActor_SetFarClippingPlane(swigCPtr, farClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFarClippingPlane()
        {
            float ret = Interop.CameraActor.CameraActor_GetFarClippingPlane(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            Interop.CameraActor.CameraActor_SetTargetPosition(swigCPtr, Vector3.getCPtr(targetPosition));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetTargetPosition()
        {
            Vector3 ret = new Vector3(Interop.CameraActor.CameraActor_GetTargetPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInvertYAxis(bool invertYAxis)
        {
            Interop.CameraActor.CameraActor_SetInvertYAxis(swigCPtr, invertYAxis);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetInvertYAxis()
        {
            bool ret = Interop.CameraActor.CameraActor_GetInvertYAxis(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPerspectiveProjection(Vector2 size)
        {
            Interop.CameraActor.CameraActor_SetPerspectiveProjection(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrthographicProjection(Vector2 size)
        {
            Interop.CameraActor.CameraActor_SetOrthographicProjection__SWIG_0(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrthographicProjection(float left, float right, float top, float bottom, float near, float far)
        {
            Interop.CameraActor.CameraActor_SetOrthographicProjection__SWIG_1(swigCPtr, left, right, top, bottom, near, far);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string Type
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
        public string ProjectionMode
        {
            get
            {
                string returnValue = "";
                PropertyValue projectionMode = GetProperty(Camera.Property.PROJECTION_MODE);
                projectionMode?.Get(out returnValue);
                projectionMode?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.PROJECTION_MODE, setValue);
                setValue.Dispose();
            }
        }
        public float FieldOfView
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue fieldView = GetProperty(Camera.Property.FIELD_OF_VIEW);
                fieldView?.Get(out returnValue);
                fieldView?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.FIELD_OF_VIEW, setValue);
                setValue.Dispose();
            }
        }
        public float AspectRatio
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue aspectRatio = GetProperty(Camera.Property.ASPECT_RATIO);
                aspectRatio?.Get(out returnValue);
                aspectRatio?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.ASPECT_RATIO, setValue);
                setValue.Dispose();
            }
        }
        public float NearPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue nearPlaneDistance = GetProperty(Camera.Property.NEAR_PLANE_DISTANCE);
                nearPlaneDistance?.Get(out returnValue);
                nearPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.NEAR_PLANE_DISTANCE, setValue);
                setValue.Dispose();
            }
        }
        public float FarPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue farPlaneDistance = GetProperty(Camera.Property.FAR_PLANE_DISTANCE);
                farPlaneDistance?.Get(out returnValue);
                farPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.FAR_PLANE_DISTANCE, setValue);
                setValue.Dispose();
            }
        }
        public float LeftPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue leftPlaneDistance = GetProperty(Camera.Property.LEFT_PLANE_DISTANCE);
                leftPlaneDistance?.Get(out returnValue);
                leftPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.LEFT_PLANE_DISTANCE, setValue);
                setValue.Dispose();
            }
        }
        public float RightPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue rightPlaneDistance = GetProperty(Camera.Property.RIGHT_PLANE_DISTANCE);
                rightPlaneDistance?.Get(out returnValue);
                rightPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.RIGHT_PLANE_DISTANCE, setValue);
                setValue.Dispose();
            }
        }
        public float TopPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue topPlaneDistance = GetProperty(Camera.Property.TOP_PLANE_DISTANCE);
                topPlaneDistance?.Get(out returnValue);
                topPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.TOP_PLANE_DISTANCE, setValue);
                setValue.Dispose();
            }
        }
        public float BottomPlaneDistance
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue bottomPlaneDistance = GetProperty(Camera.Property.BOTTOM_PLANE_DISTANCE);
                bottomPlaneDistance?.Get(out returnValue);
                bottomPlaneDistance?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.BOTTOM_PLANE_DISTANCE, setValue);
                setValue.Dispose();
            }
        }
        public Vector3 TargetPosition
        {
            get
            {
                Vector3 returnValue = new Vector3(0.0f, 0.0f, 0.0f);
                PropertyValue targetPosition = GetProperty(Camera.Property.TARGET_POSITION);
                targetPosition?.Get(returnValue);
                targetPosition?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.TARGET_POSITION, setValue);
                setValue.Dispose();
            }
        }
        internal Matrix ProjectionMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue projectionMatrix = GetProperty(Camera.Property.PROJECTION_MATRIX);
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
                PropertyValue viewMatrix = GetProperty(Camera.Property.VIEW_MATRIX);
                viewMatrix.Get(returnValue);
                viewMatrix.Dispose();
                return returnValue;
            }
        }
        public bool InvertYAxis
        {
            get
            {
                bool returnValue = false;
                PropertyValue invertYAxis = GetProperty(Camera.Property.INVERT_Y_AXIS);
                invertYAxis?.Get(out returnValue);
                invertYAxis?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(Camera.Property.INVERT_Y_AXIS, setValue);
                setValue.Dispose();
            }
        }
    }
}
