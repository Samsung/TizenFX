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
        internal static partial class Actor
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Actor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetName(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetId(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnStage", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool OnStage(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetLayer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetLayer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Add", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Add(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Remove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Remove(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetCurrentSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetParent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetParent(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_FindChildByName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FindChildByName(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetAnchorPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAnchorPoint(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_FindChildById", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FindChildById(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetNaturalSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetNaturalSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetVisible", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVisible(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_ScreenToLocal", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ScreenToLocal(IntPtr jarg1, out float jarg2, out float jarg3, float jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetResizePolicy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetResizePolicy(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetResizePolicy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetResizePolicy(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetSizeModeFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSizeModeFactor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetHeightForWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetHeightForWidth(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetWidthForHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetWidthForHeight(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetRelayoutSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetRelayoutSize(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetIgnored", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetIgnored(IntPtr actor, [MarshalAs(UnmanagedType.U1)] bool ignored);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_IsIgnored", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsIgnored(IntPtr actor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetPadding", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPadding(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetPadding", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetPadding(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetHierarchyDepth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetHierarchyDepth(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_AddRenderer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint AddRenderer(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetRendererCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetRendererCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetRendererAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetRendererAt(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RemoveRenderer__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveRenderer(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RemoveRenderer__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveRenderer(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetSuggestedMinimumWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetSuggestedMinimumWidth(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetSuggestedMinimumHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetSuggestedMinimumHeight(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetNeedGesturePropagation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float SetNeedGesturePropagation(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_CalculateScreenPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CalculateScreenPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_CalculateScreenExtents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CalculateScreenExtents(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_CurrentScreenExtents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CurrentScreenExtents(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetVisiblityChangedActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetVisiblityChangedActor();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingPropertyVector2(IntPtr actor, int propertyType, IntPtr retrievingVector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyVector2(IntPtr actor, int propertyType, IntPtr vector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingPropertyVector3(IntPtr actor, int propertyType, IntPtr retrievingVector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyVector3(IntPtr actor, int propertyType, IntPtr vector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingPropertyVector4(IntPtr actor, int propertyType, IntPtr retrievingVector4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyVector4(IntPtr actor, int propertyType, IntPtr vector4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyExtents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingPropertyExtents(IntPtr actor, int propertyType, IntPtr extents);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyExtents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyExtents(IntPtr actor, int propertyType, IntPtr extents);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector2ActualVector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalRetrievingPropertyVector2ActualVector3(IntPtr actor, int propertyType, IntPtr retrievingVector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector2ActualVector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyVector2ActualVector3(IntPtr actor, int propertyType, IntPtr vector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyFloat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float InternalGetPropertyFloat(IntPtr actor, int propertyType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyFloat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyFloat(IntPtr actor, int propertyType, float valFloat);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyBool", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool InternalGetPropertyBool(IntPtr actor, int propertyType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyBool", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyBool(IntPtr actor, int propertyType, [MarshalAs(UnmanagedType.U1)] bool valBool);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyString", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string InternalGetPropertyString(IntPtr actor, int propertyType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyString", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyString(IntPtr actor, int propertyType, string valString);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyInt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalGetPropertyInt(IntPtr actor, int propertyType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyInt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyInt(IntPtr actor, int propertyType, int valInt);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyMap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InternalSetPropertyMap(IntPtr actor, int propertyType, IntPtr valInt);
        }
    }
}





