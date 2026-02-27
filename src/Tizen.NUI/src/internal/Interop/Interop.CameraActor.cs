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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class CameraActor
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_TYPE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TypeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_PROJECTION_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ProjectionModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_FIELD_OF_VIEW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FieldOfViewGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_ASPECT_RATIO_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AspectRatioGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_NEAR_PLANE_DISTANCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int NearPlaneDistanceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_FAR_PLANE_DISTANCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FarPlaneDistanceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_LEFT_PLANE_DISTANCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LeftPlaneDistanceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_RIGHT_PLANE_DISTANCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RightPlaneDistanceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_TOP_PLANE_DISTANCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TopPlaneDistanceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_BOTTOM_PLANE_DISTANCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BottomPlaneDistanceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_TARGET_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TargetPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_PROJECTION_MATRIX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ProjectionMatrixGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_VIEW_MATRIX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ViewMatrixGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Property_INVERT_Y_AXIS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InvertYAxisGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CameraActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteCameraActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_CameraActor__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewCameraActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetType(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetType(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetProjectionMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetProjectionMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetProjectionMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetProjectionMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetFieldOfView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFieldOfView(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetFieldOfView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFieldOfView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetAspectRatio", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAspectRatio(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetAspectRatio", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetAspectRatio(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetNearClippingPlane", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetNearClippingPlane(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetNearClippingPlane", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetNearClippingPlane(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetFarClippingPlane", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFarClippingPlane(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetFarClippingPlane", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetFarClippingPlane(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetTargetPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTargetPosition(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetTargetPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTargetPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetInvertYAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInvertYAxis(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_GetInvertYAxis", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetInvertYAxis(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetPerspectiveProjection", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPerspectiveProjection(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CameraActor_SetOrthographicProjection__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOrthographicProjection(IntPtr jarg1, IntPtr jarg2);
        }
    }
}





