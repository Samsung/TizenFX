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

using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Actor
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Actor")]
            public static extern void DeleteActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetName")]
            public static extern string GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetName")]
            public static extern void SetName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetId")]
            public static extern uint GetId(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnStage")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool OnStage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetLayer")]
            public static extern global::System.IntPtr GetLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Add")]
            public static extern void Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Remove")]
            public static extern void Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetCurrentSize")]
            public static extern global::System.IntPtr GetCurrentSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetParent")]
            public static extern global::System.IntPtr GetParent(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_FindChildByName")]
            public static extern global::System.IntPtr FindChildByName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetAnchorPoint")]
            public static extern void SetAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetAnchorPoint_3FloatValues")]
            public static extern void SetAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1, float x, float y, float z);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_FindChildById")]
            public static extern global::System.IntPtr FindChildById(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetNaturalSize")]
            public static extern global::System.IntPtr GetNaturalSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetVisible")]
            public static extern void SetVisible(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_ScreenToLocal")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool ScreenToLocal(global::System.Runtime.InteropServices.HandleRef jarg1, out float jarg2, out float jarg3, float jarg4, float jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetResizePolicy")]
            public static extern void SetResizePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetResizePolicy")]
            public static extern int GetResizePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetSizeModeFactor")]
            public static extern void SetSizeModeFactor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetHeightForWidth")]
            public static extern float GetHeightForWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetWidthForHeight")]
            public static extern float GetWidthForHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetRelayoutSize")]
            public static extern float GetRelayoutSize(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetPadding")]
            public static extern void SetPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetPadding")]
            public static extern void GetPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetHierarchyDepth")]
            public static extern int GetHierarchyDepth(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_AddRenderer")]
            public static extern uint AddRenderer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetRendererCount")]
            public static extern uint GetRendererCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetRendererAt")]
            public static extern global::System.IntPtr GetRendererAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RemoveRenderer__SWIG_0")]
            public static extern void RemoveRenderer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_RemoveRenderer__SWIG_1")]
            public static extern void RemoveRenderer(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetSuggestedMinimumWidth")]
            public static extern float GetSuggestedMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetSuggestedMinimumHeight")]
            public static extern float GetSuggestedMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_SetNeedGesturePropagation")]
            public static extern float SetNeedGesturePropagation(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_CalculateScreenPosition")]
            public static extern global::System.IntPtr CalculateScreenPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_CalculateScreenExtents")]
            public static extern global::System.IntPtr CalculateScreenExtents(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_CurrentScreenExtents")]
            public static extern global::System.IntPtr CurrentScreenExtents(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_GetVisiblityChangedActor")]
            public static extern global::System.IntPtr GetVisiblityChangedActor();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector2")]
            public static extern int InternalRetrievingPropertyVector2(HandleRef actor, int propertyType, HandleRef retrievingVector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector2")]
            public static extern int InternalSetPropertyVector2(HandleRef actor, int propertyType, HandleRef vector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetProperty2FloatValues")]
            public static extern int InternalSetProperty2FloatValues(HandleRef actor, int propertyType, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector3")]
            public static extern int InternalRetrievingPropertyVector3(HandleRef actor, int propertyType, HandleRef retrievingVector3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingProperty3FloatValues")]
            public static extern int InternalRetrievingPropertyVector3(HandleRef actor, int propertyType, out float x, out float y, out float z);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector3")]
            public static extern int InternalSetPropertyVector3(HandleRef actor, int propertyType, HandleRef vector3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetProperty3FloatValues")]
            public static extern int InternalSetProperty3FloatValues(HandleRef actor, int propertyType, float x, float y, float z);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector4")]
            public static extern int InternalRetrievingPropertyVector4(HandleRef actor, int propertyType, HandleRef retrievingVector4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingProperty4FloatValues")]
            public static extern int InternalRetrievingPropertyVector4(HandleRef actor, int propertyType, out float x, out float y, out float z, out float w);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector4")]
            public static extern int InternalSetPropertyVector4(HandleRef actor, int propertyType, HandleRef vector4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetProperty4FloatValues")]
            public static extern int InternalSetPropertyVector4(HandleRef actor, int propertyType, float x, float y, float z, float w);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyVector2ActualVector3")]
            public static extern int InternalRetrievingPropertyVector2ActualVector3(HandleRef actor, int propertyType, HandleRef retrievingVector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyVector2ActualVector3")]
            public static extern int InternalSetPropertyVector2ActualVector3(HandleRef actor, int propertyType, HandleRef vector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalRetrievingPropertyFloat")]
            public static extern int InternalRetrievingPropertyFloat(HandleRef actor, int propertyType, out float valFloat);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyFloat")]
            public static extern float InternalGetPropertyFloat(HandleRef actor, int propertyType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyFloat")]
            public static extern int InternalSetPropertyFloat(HandleRef actor, int propertyType, float valFloat);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyBool")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool InternalGetPropertyBool(HandleRef actor, int propertyType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyBool")]
            public static extern int InternalSetPropertyBool(HandleRef actor, int propertyType, bool valBool);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyString")]
            public static extern string InternalGetPropertyString(HandleRef actor, int propertyType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyString")]
            public static extern int InternalSetPropertyString(HandleRef actor, int propertyType, string valString);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalGetPropertyInt")]
            public static extern int InternalGetPropertyInt(HandleRef actor, int propertyType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyInt")]
            public static extern int InternalSetPropertyInt(HandleRef actor, int propertyType, int valInt);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InternalSetPropertyMap")]
            public static extern int InternalSetPropertyMap(HandleRef actor, int propertyType, HandleRef valInt);
        }
    }
}
