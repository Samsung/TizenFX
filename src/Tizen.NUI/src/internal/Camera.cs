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

        internal Camera(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CameraActor.CameraActorUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Camera obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CameraActor.DeleteCameraActor(swigCPtr);
        }

        internal class Property
        {
            internal static readonly int Type = Interop.CameraActor.CameraActorPropertyTypeGet();
            internal static readonly int ProjectionMode = Interop.CameraActor.CameraActorPropertyProjectionModeGet();
            internal static readonly int FieldOfView = Interop.CameraActor.CameraActorPropertyFieldOfViewGet();
            internal static readonly int AspectRatio = Interop.CameraActor.CameraActorPropertyAspectRatioGet();
            internal static readonly int NearPlaneDistance = Interop.CameraActor.CameraActorPropertyNearPlaneDistanceGet();
            internal static readonly int FarPlaneDistance = Interop.CameraActor.CameraActorPropertyFarPlaneDistanceGet();
            internal static readonly int LeftPlaneDistance = Interop.CameraActor.CameraActorPropertyLeftPlaneDistanceGet();
            internal static readonly int RightPlaneDistance = Interop.CameraActor.CameraActorPropertyRightPlaneDistanceGet();
            internal static readonly int TopPlaneDistance = Interop.CameraActor.CameraActorPropertyTopPlaneDistanceGet();
            internal static readonly int BottomPlaneDistance = Interop.CameraActor.CameraActorPropertyBottomPlaneDistanceGet();
            internal static readonly int TargetPosition = Interop.CameraActor.CameraActorPropertyTargetPositionGet();
            internal static readonly int ProjectionMatrix = Interop.CameraActor.CameraActorPropertyProjectionMatrixGet();
            internal static readonly int ViewMatrix = Interop.CameraActor.CameraActorPropertyViewMatrixGet();
            internal static readonly int InvertYAxis = Interop.CameraActor.CameraActorPropertyInvertYAxisGet();
        }

        public Camera() : this(Interop.CameraActor.CameraActorNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Camera(Vector2 size) : this(Interop.CameraActor.CameraActorNew(Vector2.getCPtr(size)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Camera DownCast(BaseHandle handle)
        {
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
            Camera ret = new Camera(Interop.CameraActor.CameraActorAssign(swigCPtr, Camera.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetType(CameraType type)
        {
            Interop.CameraActor.CameraActorSetType(swigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new CameraType GetType()
        {
            CameraType ret = (CameraType)Interop.CameraActor.CameraActorGetType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetProjectionMode(ProjectionMode mode)
        {
            Interop.CameraActor.CameraActorSetProjectionMode(swigCPtr, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ProjectionMode GetProjectionMode()
        {
            ProjectionMode ret = (ProjectionMode)Interop.CameraActor.CameraActorGetProjectionMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFieldOfView(float fieldOfView)
        {
            Interop.CameraActor.CameraActorSetFieldOfView(swigCPtr, fieldOfView);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFieldOfView()
        {
            float ret = Interop.CameraActor.CameraActorGetFieldOfView(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAspectRatio(float aspectRatio)
        {
            Interop.CameraActor.CameraActorSetAspectRatio(swigCPtr, aspectRatio);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetAspectRatio()
        {
            float ret = Interop.CameraActor.CameraActorGetAspectRatio(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetNearClippingPlane(float nearClippingPlane)
        {
            Interop.CameraActor.CameraActorSetNearClippingPlane(swigCPtr, nearClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetNearClippingPlane()
        {
            float ret = Interop.CameraActor.CameraActorGetNearClippingPlane(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFarClippingPlane(float farClippingPlane)
        {
            Interop.CameraActor.CameraActorSetFarClippingPlane(swigCPtr, farClippingPlane);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFarClippingPlane()
        {
            float ret = Interop.CameraActor.CameraActorGetFarClippingPlane(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            Interop.CameraActor.CameraActorSetTargetPosition(swigCPtr, Vector3.getCPtr(targetPosition));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetTargetPosition()
        {
            Vector3 ret = new Vector3(Interop.CameraActor.CameraActorGetTargetPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInvertYAxis(bool invertYAxis)
        {
            Interop.CameraActor.CameraActorSetInvertYAxis(swigCPtr, invertYAxis);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetInvertYAxis()
        {
            bool ret = Interop.CameraActor.CameraActorGetInvertYAxis(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPerspectiveProjection(Vector2 size)
        {
            Interop.CameraActor.CameraActorSetPerspectiveProjection(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrthographicProjection(Vector2 size)
        {
            Interop.CameraActor.CameraActorSetOrthographicProjection(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrthographicProjection(float left, float right, float top, float bottom, float near, float far)
        {
            Interop.CameraActor.CameraActorSetOrthographicProjection(swigCPtr, left, right, top, bottom, near, far);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string Type
        {
            get
            {
                string temp;
                GetProperty(Camera.Property.Type).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.Type, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string ProjectionMode
        {
            get
            {
                string temp;
                GetProperty(Camera.Property.ProjectionMode).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.ProjectionMode, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float FieldOfView
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.FieldOfView).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.FieldOfView, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float AspectRatio
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.AspectRatio).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.AspectRatio, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float NearPlaneDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.NearPlaneDistance).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.NearPlaneDistance, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float FarPlaneDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.FarPlaneDistance).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.FarPlaneDistance, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float LeftPlaneDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.LeftPlaneDistance).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.LeftPlaneDistance, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float RightPlaneDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.RightPlaneDistance).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.RightPlaneDistance, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float TopPlaneDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.TopPlaneDistance).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.TopPlaneDistance, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float BottomPlaneDistance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Camera.Property.BottomPlaneDistance).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.BottomPlaneDistance, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector3 TargetPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(Camera.Property.TargetPosition).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.TargetPosition, new Tizen.NUI.PropertyValue(value));
            }
        }
        internal Matrix ProjectionMatrix
        {
            get
            {
                Matrix temp = new Matrix();
                GetProperty(Camera.Property.ProjectionMatrix).Get(temp);
                return temp;
            }
        }
        internal Matrix ViewMatrix
        {
            get
            {
                Matrix temp = new Matrix();
                GetProperty(Camera.Property.ViewMatrix).Get(temp);
                return temp;
            }
        }
        public bool InvertYAxis
        {
            get
            {
                bool temp = false;
                GetProperty(Camera.Property.InvertYAxis).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Camera.Property.InvertYAxis, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
