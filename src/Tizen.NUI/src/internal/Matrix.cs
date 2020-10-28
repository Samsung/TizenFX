/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    internal class Matrix : Disposable
    {

        internal Matrix(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Matrix obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Matrix.delete_Matrix(swigCPtr);
        }


        public static Vector4 operator *(Matrix arg1, Vector4 arg2)
        {
            return arg1.Multiply(arg2);
        }

        public Matrix() : this(Interop.Matrix.new_Matrix__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(bool initialize) : this(Interop.Matrix.new_Matrix__SWIG_1(initialize), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(float[] array) : this(Interop.Matrix.new_Matrix__SWIG_2(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(Rotation rotation) : this(Interop.Matrix.new_Matrix__SWIG_3(Rotation.getCPtr(rotation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(Matrix matrix) : this(Interop.Matrix.new_Matrix__SWIG_4(Matrix.getCPtr(matrix)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix Assign(Matrix matrix)
        {
            Matrix ret = new Matrix(Interop.Matrix.Matrix_Assign(swigCPtr, Matrix.getCPtr(matrix)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Matrix IDENTITY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Matrix.Matrix_IDENTITY_get();
                Matrix ret = (cPtr == global::System.IntPtr.Zero) ? null : new Matrix(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public void SetIdentity()
        {
            Interop.Matrix.Matrix_SetIdentity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetIdentityAndScale(Vector3 scale)
        {
            Interop.Matrix.Matrix_SetIdentityAndScale(swigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void InvertTransform(Matrix result)
        {
            Interop.Matrix.Matrix_InvertTransform(swigCPtr, Matrix.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool Invert()
        {
            bool ret = Interop.Matrix.Matrix_Invert(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Transpose()
        {
            Interop.Matrix.Matrix_Transpose(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetXAxis()
        {
            Vector3 ret = new Vector3(Interop.Matrix.Matrix_GetXAxis(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetYAxis()
        {
            Vector3 ret = new Vector3(Interop.Matrix.Matrix_GetYAxis(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetZAxis()
        {
            Vector3 ret = new Vector3(Interop.Matrix.Matrix_GetZAxis(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetXAxis(Vector3 axis)
        {
            Interop.Matrix.Matrix_SetXAxis(swigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetYAxis(Vector3 axis)
        {
            Interop.Matrix.Matrix_SetYAxis(swigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetZAxis(Vector3 axis)
        {
            Interop.Matrix.Matrix_SetZAxis(swigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetTranslation()
        {
            Vector4 ret = new Vector4(Interop.Matrix.Matrix_GetTranslation(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetTranslation3()
        {
            Vector3 ret = new Vector3(Interop.Matrix.Matrix_GetTranslation3(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTranslation(Vector4 translation)
        {
            Interop.Matrix.Matrix_SetTranslation__SWIG_0(swigCPtr, Vector4.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetTranslation(Vector3 translation)
        {
            Interop.Matrix.Matrix_SetTranslation__SWIG_1(swigCPtr, Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void OrthoNormalize()
        {
            Interop.Matrix.Matrix_OrthoNormalize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = Interop.Matrix.Matrix_AsFloat__SWIG_0(swigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static void Multiply(Matrix result, Matrix lhs, Matrix rhs)
        {
            Interop.Matrix.Matrix_Multiply__SWIG_0(Matrix.getCPtr(result), Matrix.getCPtr(lhs), Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void Multiply(Matrix result, Matrix lhs, Rotation rhs)
        {
            Interop.Matrix.Matrix_Multiply__SWIG_1(Matrix.getCPtr(result), Matrix.getCPtr(lhs), Rotation.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 Multiply(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Matrix.Matrix_Multiply__SWIG_2(swigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool EqualTo(Matrix rhs)
        {
            bool ret = Interop.Matrix.Matrix_EqualTo(swigCPtr, Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(Matrix rhs)
        {
            bool ret = Interop.Matrix.Matrix_NotEqualTo(swigCPtr, Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTransformComponents(Vector3 scale, Rotation rotation, Vector3 translation)
        {
            Interop.Matrix.Matrix_SetTransformComponents(swigCPtr, Vector3.getCPtr(scale), Rotation.getCPtr(rotation), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetInverseTransformComponents(Vector3 scale, Rotation rotation, Vector3 translation)
        {
            Interop.Matrix.Matrix_SetInverseTransformComponents__SWIG_0(swigCPtr, Vector3.getCPtr(scale), Rotation.getCPtr(rotation), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetInverseTransformComponents(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis, Vector3 translation)
        {
            Interop.Matrix.Matrix_SetInverseTransformComponents__SWIG_1(swigCPtr, Vector3.getCPtr(xAxis), Vector3.getCPtr(yAxis), Vector3.getCPtr(zAxis), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void GetTransformComponents(Vector3 position, Rotation rotation, Vector3 scale)
        {
            Interop.Matrix.Matrix_GetTransformComponents(swigCPtr, Vector3.getCPtr(position), Rotation.getCPtr(rotation), Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
