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
            // Property type specific API
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Boolean")]
            public static extern global::System.IntPtr ConstraintBooleanNew(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Float")]
            public static extern global::System.IntPtr ConstraintFloatNew(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Integer")]
            public static extern global::System.IntPtr ConstraintIntegerNew(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Vector2")]
            public static extern global::System.IntPtr ConstraintVector2New(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Vector3")]
            public static extern global::System.IntPtr ConstraintVector3New(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Vector4")]
            public static extern global::System.IntPtr ConstraintVector4New(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Matrix3")]
            public static extern global::System.IntPtr ConstraintMatrix3New(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Matrix")]
            public static extern global::System.IntPtr ConstraintMatrixNew(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Quaternion")]
            public static extern global::System.IntPtr ConstraintRotationNew(global::System.Runtime.InteropServices.HandleRef target, int propertyIndex, global::System.Runtime.InteropServices.HandleRef constraintFunction);

            // Common API
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint")]
            public static extern global::System.IntPtr DeleteConstraint(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_AddSource")]
            public static extern void AddSource(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef sourceHandle, int sourceIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_AddLocalSource")]
            public static extern void AddLocalSource(global::System.Runtime.InteropServices.HandleRef jarg1, int sourceIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_AddParentSource")]
            public static extern void AddParentSource(global::System.Runtime.InteropServices.HandleRef jarg1, int sourceIndex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Apply")]
            public static extern void Apply(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_ApplyPost")]
            public static extern void ApplyPost(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Remove")]
            public static extern void Remove(global::System.Runtime.InteropServices.HandleRef jarg1);

            // Note : Dali use RemoveAction as apply action behavior.
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetRemoveAction")]
            public static extern void SetApplyAction(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            // Note : Dali use RemoveAction as apply action behavior.
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetRemoveAction")]
            public static extern int GetApplyAction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetApplyRate")]
            public static extern void SetApplyRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint applyRate);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetApplyRate")]
            public static extern uint GetApplyRate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetTag")]
            public static extern void SetTag(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTag")]
            public static extern uint GetTag(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTargetObject")]
            public static extern global::System.IntPtr GetTargetObject(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTargetProperty")]
            public static extern int GetTargetProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            // Special Constraint
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EqualConstraintWithParentFloat_New")]
            public static extern global::System.IntPtr NewEqualConstraintWithParentFloat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RelativeConstraintWithParentFloat_New")]
            public static extern global::System.IntPtr NewRelativeConstraintWithParentFloat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, float jarg4);
        }
    }
}
