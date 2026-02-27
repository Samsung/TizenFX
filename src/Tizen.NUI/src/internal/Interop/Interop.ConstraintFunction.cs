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
        internal static partial class ConstraintFunction
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Boolean_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr BooleanFunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Boolean_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBooleanFunction(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Boolean_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetBooleanFunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Boolean", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteBooleanFunction(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Float_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FloatFunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Float_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFloatFunction(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Float_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetFloatFunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Float", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFloatFunction(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Integer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr IntegerFunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Integer_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetIntegerFunction(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Integer_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetIntegerFunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Integer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteIntegerFunction(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector2_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Vector2FunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector2_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVector2Function(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector2_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetVector2FunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Vector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVector2Function(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector3_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Vector3FunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector3_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVector3Function(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector3_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetVector3FunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Vector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVector3Function(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector4_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Vector4FunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector4_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVector4Function(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Vector4_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetVector4FunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Vector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVector4Function(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Matrix3_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3FunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Matrix3_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMatrix3Function(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Matrix3_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMatrix3FunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Matrix3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteMatrix3Function(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Matrix_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MatrixFunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Matrix_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetMatrixFunction(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Matrix_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMatrixFunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Matrix", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteMatrixFunction(IntPtr function);


            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Quaternion_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotationFunctionNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Quaternion_SetHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRotationFunction(IntPtr function, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Constraint_Function_Quaternion_GetId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetRotationFunctionId(IntPtr function);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Constraint_Function_Quaternion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRotationFunction(IntPtr function);
        }
    }
}





