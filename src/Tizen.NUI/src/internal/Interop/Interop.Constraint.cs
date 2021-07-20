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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Constraint
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Constraint")]
            public static extern global::System.IntPtr NewConstraint(global::System.Runtime.InteropServices.HandleRef jarg1);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint")]
            public static extern global::System.IntPtr DeleteConstraint(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Apply")]
            public static extern void Apply(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Remove")]
            public static extern void Remove(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetRemoveAction")]
            public static extern void SetRemoveAction(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetRemoveAction")]
            public static extern int GetRemoveAction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetTag")]
            public static extern void SetTag(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTag")]
            public static extern uint GetTag(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTargetObject")]
            public static extern global::System.IntPtr GetTargetObject(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTargetProperty")]
            public static extern int GetTargetProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            // Constant values
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_REMOVE_ACTION_BAKE_get")]
            public static extern int ConstraintRemoveActionBakeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_REMOVE_ACTION_DISCARD_get")]
            public static extern int ConstraintRemoveActionDiscardGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_DEFAULT_REMOVE_ACTION_get")]
            public static extern int ConstraintDefaultRemoveActionGet();

            // Special Constraint
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EqualConstraintWithParentFloat_New")]
            public static extern global::System.IntPtr NewEqualConstraintWithParentFloat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RelativeConstraintWithParentFloat_New")]
            public static extern global::System.IntPtr NewRelativeConstraintWithParentFloat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, float jarg4);
        }
    }
}
