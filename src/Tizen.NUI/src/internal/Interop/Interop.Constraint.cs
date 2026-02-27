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
        internal static partial class Constraint
        {
            // Property type specific API
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Boolean", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintBooleanNew(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Float", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintFloatNew(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Integer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintIntegerNew(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Vector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintVector2New(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Vector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintVector3New(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Vector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintVector4New(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Matrix3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintMatrix3New(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Matrix", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintMatrixNew(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_New_Quaternion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ConstraintRotationNew(IntPtr target, int propertyIndex, IntPtr constraintFunction);

            // Common API
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DeleteConstraint(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_AddSource", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddSource(IntPtr jarg1, IntPtr sourceHandle, int sourceIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_AddLocalSource", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddLocalSource(IntPtr jarg1, int sourceIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_AddParentSource", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddParentSource(IntPtr jarg1, int sourceIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Apply", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Apply(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_ApplyPost", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyPost(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Remove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Remove(IntPtr jarg1);

            // Note : Dali use RemoveAction as apply action behavior.
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetRemoveAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetApplyAction(IntPtr jarg1, int jarg2);

            // Note : Dali use RemoveAction as apply action behavior.
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetRemoveAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetApplyAction(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetApplyRate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetApplyRate(IntPtr jarg1, uint applyRate);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetApplyRate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetApplyRate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_SetTag", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTag(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTag", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetTag(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTargetObject", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTargetObject(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_GetTargetProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetTargetProperty(IntPtr jarg1);

            // Special Constraint
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EqualConstraintWithParentFloat_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewEqualConstraintWithParentFloat(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RelativeConstraintWithParentFloat_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRelativeConstraintWithParentFloat(IntPtr jarg1, int jarg2, int jarg3, float jarg4);
        }
    }
}





