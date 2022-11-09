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

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Matrix3 : Disposable
    {
        internal Matrix3(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Matrix.DeleteMatrix3(swigCPtr);
        }

        public static Matrix3 IDENTITY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Matrix.Matrix3IdentityGet();
                Matrix3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Matrix3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public Matrix3() : this(Interop.Matrix.NewMatrix3(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix3(Matrix3 m) : this(Interop.Matrix.NewMatrix3(Matrix3.getCPtr(m)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix3(Matrix m) : this(Interop.Matrix.NewMatrix3Matrix(Matrix.getCPtr(m)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix3(float s00, float s01, float s02, float s10, float s11, float s12, float s20, float s21, float s22) : this(Interop.Matrix.NewMatrix3(s00, s01, s02, s10, s11, s12, s20, s21, s22), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix3 Assign(Matrix3 matrix)
        {
            Matrix3 ret = new Matrix3(Interop.Matrix.Matrix3Assign(SwigCPtr, Matrix3.getCPtr(matrix)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Matrix3 Assign(Matrix matrix)
        {
            Matrix3 ret = new Matrix3(Interop.Matrix.Matrix3AssignMatrix(SwigCPtr, Matrix.getCPtr(matrix)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float this[uint index]
        {
            set
            {
                SetValueAtIndex(index, value);
            }
            get
            {
                return ValueOfIndex(index);
            }
        }

        public static Vector3 operator *(Matrix3 arg1, Vector3 arg2)
        {
            return arg1?.Multiply(arg2);
        }

        public static Matrix3 operator *(Matrix3 arg1, Matrix3 arg2)
        {
            return arg1?.Multiply(arg2);
        }

        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        public bool EqualTo(Matrix3 rhs)
        {
            bool ret = Interop.Matrix.Matrix3EqualTo(SwigCPtr, Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(Matrix3 rhs)
        {
            bool ret = Interop.Matrix.Matrix3NotEqualTo(SwigCPtr, Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetIdentity()
        {
            Interop.Matrix.Matrix3SetIdentity(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool Invert()
        {
            bool ret = Interop.Matrix.Matrix3Invert(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool Transpose()
        {
            bool ret = Interop.Matrix.Matrix3Transpose(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Scale(float scale)
        {
            Interop.Matrix.Matrix3Scale(SwigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float Magnitude()
        {
            float ret = Interop.Matrix.Matrix3Magnitude(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ScaledInverseTranspose()
        {
            bool ret = Interop.Matrix.Matrix3ScaledInverseTranspose(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static void Multiply(Matrix3 result, Matrix3 lhs, Matrix3 rhs)
        {
            Interop.Matrix.Matrix3Multiply(Matrix3.getCPtr(result), Matrix3.getCPtr(lhs), Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 Multiply(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Matrix.Matrix3MultiplyVector3(SwigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Matrix3 Multiply(Matrix3 rhs)
        {
            Matrix3 ret = new Matrix3(Interop.Matrix.Matrix3Multiply(SwigCPtr, Matrix3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void MultiplyAssign(Matrix3 rhs)
        {
            Interop.Matrix.Matrix3MultiplyAssign(SwigCPtr, Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float ValueOfIndex(uint index)
        {
            float ret = Interop.Matrix.Matrix3ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float ValueOfIndex(uint indexRow, uint indexColumn)
        {
            float ret = Interop.Matrix.Matrix3ValueOfIndex(SwigCPtr, indexRow, indexColumn);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetValueAtIndex(uint index, float val)
        {
            Interop.Matrix.Matrix3SetValueAtIndex(SwigCPtr, index, val);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetValueAtIndex(uint indexRow, uint indexColumn, float val)
        {
            Interop.Matrix.Matrix3SetValueAtIndex(SwigCPtr, indexRow, indexColumn, val);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
