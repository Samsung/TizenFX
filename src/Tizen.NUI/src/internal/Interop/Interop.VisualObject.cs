/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VisualObject
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_New")]
            public static extern global::System.IntPtr VisualObjectNew();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_GetContainer")]
            public static extern global::System.IntPtr GetContainer(global::System.Runtime.InteropServices.HandleRef visualObject);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_CreateVisual")]
            public static extern void CreateVisual(global::System.Runtime.InteropServices.HandleRef visualObject, global::System.Runtime.InteropServices.HandleRef propertyMap);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_RetrieveVisualPropertyMap")]
            public static extern void RetrieveVisualPropertyMap(global::System.Runtime.InteropServices.HandleRef visualObject, global::System.Runtime.InteropServices.HandleRef propertyMap);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DoAction_UpdatePropertyMap")]
            public static extern void UpdateVisualPropertyMap(global::System.Runtime.InteropServices.HandleRef visualObject, global::System.Runtime.InteropServices.HandleRef propertyMap);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DoActionWithEmptyAttributes")]
            public static extern void DoActionWithEmptyAttributes(global::System.Runtime.InteropServices.HandleRef visualObject, int actionId);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DoActionWithSingleIntAttributes")]
            public static extern void DoActionWithSingleIntAttributes(global::System.Runtime.InteropServices.HandleRef visualObject, int actionId, int actionValue);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_SetSiblingOrder")]
            public static extern void SetSiblingOrder(global::System.Runtime.InteropServices.HandleRef visualObject, uint siblingOrder);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_GetSiblingOrder")]
            public static extern uint GetSiblingOrder(global::System.Runtime.InteropServices.HandleRef visualObject);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_DetachFromContainer")]
            public static extern void Detach(global::System.Runtime.InteropServices.HandleRef visualObject);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_Raise")]
            public static extern void Raise(global::System.Runtime.InteropServices.HandleRef visualObject);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_Lower")]
            public static extern void Lower(global::System.Runtime.InteropServices.HandleRef visualObject);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_RaiseToTop")]
            public static extern void RaiseToTop(global::System.Runtime.InteropServices.HandleRef visualObject);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_LowerToBottom")]
            public static extern void LowerToBottom(global::System.Runtime.InteropServices.HandleRef visualObject);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_RaiseAbove")]
            public static extern void RaiseAbove(global::System.Runtime.InteropServices.HandleRef visualObject, global::System.Runtime.InteropServices.HandleRef target);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualObject_LowerBelow")]
            public static extern void LowerBelow(global::System.Runtime.InteropServices.HandleRef visualObject, global::System.Runtime.InteropServices.HandleRef target);
        }
    }
}
