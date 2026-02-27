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
        internal static partial class PanGestureDetector
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureUpcast(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_SCREEN_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScreenPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_SCREEN_DISPLACEMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScreenDisplacementGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_SCREEN_VELOCITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScreenVelocityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_LOCAL_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LocalPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_LOCAL_DISPLACEMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LocalDisplacementGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_LOCAL_VELOCITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LocalVelocityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Property_PANNING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PanningGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PanGestureDetector", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePanGestureDetector(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PanGestureDetector__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPanGestureDetector(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_SetMinimumTouchesRequired", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMinimumTouchesRequired(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_SetMaximumTouchesRequired", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaximumTouchesRequired(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_SetMaximumMotionEventAge", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMaximumMotionEventAge(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_GetMinimumTouchesRequired", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMinimumTouchesRequired(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_GetMaximumTouchesRequired", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMaximumTouchesRequired(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_GetMaximumMotionEventAge", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMaximumMotionEventAge(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_AddAngle__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddAngle(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_AddAngle__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddAngle(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_AddDirection__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddDirection(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_AddDirection__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddDirection(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_GetAngleCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetAngleCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_GetAngle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetAngle(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_ClearAngles", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearAngles(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_RemoveAngle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveAngle(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_RemoveDirection", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveDirection(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_DetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DetectedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetector_SetPanGestureProperties", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPanGestureProperties(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureNew(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PanGesture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePanGesture(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_velocity_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureVelocityGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_displacement_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureDisplacementGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_position_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGesturePositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_screenVelocity_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureScreenVelocityGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_screenDisplacement_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureScreenDisplacementGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_screenPosition_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PanGestureScreenPositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_numberOfTouches_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint PanGestureNumberOfTouchesGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_GetSpeed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float PanGestureGetSpeed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_GetDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float PanGestureGetDistance(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_GetScreenSpeed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float PanGestureGetScreenSpeed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGesture_GetScreenDistance", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float PanGestureGetScreenDistance(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetectedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PanGestureDetectedSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetectedSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint PanGestureDetectedSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetectedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PanGestureDetectedSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetectedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PanGestureDetectedSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PanGestureDetectedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PanGestureDetectedSignalEmit(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PanGestureDetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPanGestureDetectedSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PanGestureDetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePanGestureDetectedSignal(IntPtr jarg1);
        }
    }
}





