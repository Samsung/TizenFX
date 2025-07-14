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
    /// <summary>
    /// A 3x3 matrix. <br/>
    /// The matrix is stored as a flat array and is Column Major, i.e. the storage order is as follows (numbers represent indices of array): <br/>
    /// <code>
    /// 0   3   6
    /// 1   4   7
    /// 2   5   8
    /// </code>
    /// Each axis is contiguous in memory, so the x-axis corresponds to elements 0, 1, and 2, the y-axis corresponds to
    /// elements 3, 4, 5, the z-axis corresponds to elements 6, 7, and 8.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Matrix3 : Disposable
    {
        internal Matrix3(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Matrix.DeleteMatrix3(swigCPtr);
        }

        /// <summary>
        /// The constructor initialized as zero.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix3() : this(Interop.Matrix.NewMatrix3(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="matrix">The matrix to copy value.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix3(Matrix3 matrix) : this(Interop.Matrix.NewMatrix3(Matrix3.getCPtr(matrix)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="matrix">The matrix to copy value. The translation and shear components are ignored.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public Matrix3(Matrix matrix) : this(Interop.Matrix.NewMatrix3Matrix(Matrix.getCPtr(matrix)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor with nine floats.
        /// </summary>
        /// <param name="s00">Value of 0 column, 0 row.</param>
        /// <param name="s01">Value of 0 column, 1 row.</param>
        /// <param name="s02">Value of 0 column, 2 row.</param>
        /// <param name="s10">Value of 1 column, 0 row.</param>
        /// <param name="s11">Value of 1 column, 1 row.</param>
        /// <param name="s12">Value of 1 column, 2 row.</param>
        /// <param name="s20">Value of 2 column, 0 row.</param>
        /// <param name="s21">Value of 2 column, 1 row.</param>
        /// <param name="s22">Value of 2 column, 2 row.</param>
        /// <remark>
        /// Please note that NUI using column major matrix.
        /// </remark>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix3(float s00, float s01, float s02, float s10, float s11, float s12, float s20, float s21, float s22) : this(Interop.Matrix.NewMatrix3(s00, s01, s02, s10, s11, s12, s20, s21, s22), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assign.
        /// </summary>
        /// <param name="rhs">A reference to the copied handle.</param>
        /// <returns>A reference to this.</returns>
        internal Matrix3 Assign(Matrix3 rhs)
        {
            Matrix3 ret = new Matrix3(Interop.Matrix.Matrix3Assign(SwigCPtr, Matrix3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Assign.
        /// </summary>
        /// <param name="rhs">A reference to the copied handle.</param>
        /// <returns>A reference to this.</returns>
        internal Matrix3 Assign(Matrix rhs)
        {
            Matrix3 ret = new Matrix3(Interop.Matrix.Matrix3AssignMatrix(SwigCPtr, Matrix.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The matrix as identity
        /// </summary>
        /// <code>
        /// [[1, 0, 0],
        ///  [0, 1, 0],
        ///  [0, 0, 1]]
        /// </code>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1065: Do not raise exceptions in unexpected locations")]
        public static Matrix3 Identity
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Matrix.Matrix3IdentityGet();
                Matrix3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Matrix3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Get/set the value of matrix by it's index.
        /// </summary>
        /// <param name="index">The index to get/set value.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Multiply Matrix3 and Vector3.
        /// </summary>
        /// <code>
        /// returns = lhs * rhs;
        /// </code>
        /// <param name="lhs">The left-hand-side Matrix3.</param>
        /// <param name="rhs">The right-hand-side Vector3.</param>
        /// <returns>The vector multiply as lhs * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return lhs?.Multiply(rhs);
        }

        /// <summary>
        /// Multiply Matrix3 and Matrix3.
        /// </summary>
        /// <code>
        /// returns = lhs * rhs;
        /// </code>
        /// <param name="lhs">The left-hand-side Matrix3.</param>
        /// <param name="rhs">The right-hand-side Matrix3.</param>
        /// <returns>The Matrix3 multiply as lhs * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return lhs?.Multiply(rhs);
        }

        /// <summary>
        /// Make matrix as identity.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetIdentity()
        {
            Interop.Matrix.Matrix3SetIdentity(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Generic brute force matrix invert.
        /// </summary>
        /// <returns>True if successful.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Invert()
        {
            bool ret = Interop.Matrix.Matrix3Invert(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Swaps the rows to columns.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Transpose()
        {
            bool ret = Interop.Matrix.Matrix3Transpose(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Multiplies all elements of the matrix by the scale value.
        /// </summary>
        /// <param name="scale">The value by which to scale the whole matrix.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Scale(float scale)
        {
            Interop.Matrix.Matrix3Scale(SwigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Magnitude returns the average of the absolute values of the elements * 3.0f.
        /// The Magnitude of the unit matrix is therefore 1.
        /// </summary>
        /// <returns>The magnitude - always positive.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Magnitude()
        {
            float ret = Interop.Matrix.Matrix3Magnitude(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// If the matrix is invertible, then this method inverts, transposes
        /// and scales the matrix such that the resultant element values
        /// average 1. <br/>
        /// If the matrix is not invertible, then the matrix is left unchanged.
        /// </summary>
        /// <returns>True if the matrix is invertable. False otherwise</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScaledInverseTranspose()
        {
            bool ret = Interop.Matrix.Matrix3ScaledInverseTranspose(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Function to multiply two matrices and store the result onto third.<br/>
        /// Use this method in time critical path as it does not require temporaries.<br/>
        /// </summary>
        /// <remark>
        /// This Mutliply function be used for time-critical path. lhs and rhs is not matched as normal sense.
        /// </remark>
        /// <code>
        /// result = rhs * lhs;
        /// </code>
        /// <param name="result">Result of the multiplication.</param>
        /// <param name="lhs">The left-hand-side Matrix3. this can be same matrix as result.</param>
        /// <param name="rhs">The right-hand-side Matrix3. this cannot be same matrix as result.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Multiply(Matrix3 result, Matrix3 lhs, Matrix3 rhs)
        {
            Interop.Matrix.Matrix3Multiply(Matrix3.getCPtr(result), Matrix3.getCPtr(lhs), Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Multiply the Matrix3 and Vector3.
        /// </summary>
        /// <code>
        /// returns = this * rhs;
        /// </code>
        /// <param name="rhs">The right-hand-side Vector3.</param>
        /// <returns>The vector multiply as this * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 Multiply(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Matrix.Matrix3MultiplyVector3(SwigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Multiply the Matrix3 and Matrix3.
        /// </summary>
        /// <code>
        /// returns = this * rhs;
        /// </code>
        /// <param name="rhs">The right-hand-side Matrix3.</param>
        /// <returns>The matrix multiply as this * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix3 Multiply(Matrix3 rhs)
        {
            Matrix3 ret = new Matrix3(Interop.Matrix.Matrix3Multiply(SwigCPtr, Matrix3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Multiply the Matrix3 and Matrix3. Result will be stored into this Matrix3.
        /// </summary>
        /// <code>
        /// this = this * rhs;
        /// </code>
        /// <param name="rhs">The right-hand-side Matrix3.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void MultiplyAssign(Matrix3 rhs)
        {
            Interop.Matrix.Matrix3MultiplyAssign(SwigCPtr, Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the hash code of this Matrix3.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Compares if rhs is equal to.
        /// </summary>
        /// <param name="rhs">The matrix to compare.</param>
        /// <returns>Returns true if the two matrixes are equal, otherwise false.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EqualTo(Matrix3 rhs)
        {
            bool ret = Interop.Matrix.Matrix3EqualTo(SwigCPtr, Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The matrix to compare.</param>
        /// <returns>Returns true if the two matrixes are not equal, otherwise false.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NotEqualTo(Matrix3 rhs)
        {
            bool ret = Interop.Matrix.Matrix3NotEqualTo(SwigCPtr, Matrix3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get the value of matrix by it's index.
        /// </summary>
        /// <param name="index">The index to get value.</param>
        /// <returns>A value of index</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ValueOfIndex(uint index)
        {
            float ret = Interop.Matrix.Matrix3ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get the value of matrix by it's row index and column index.
        /// </summary>
        /// <param name="indexRow">The row index to get value.</param>
        /// <param name="indexColumn">The column index to get value.</param>
        /// <returns>A value of index</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ValueOfIndex(uint indexRow, uint indexColumn)
        {
            float ret = Interop.Matrix.Matrix3ValueOfIndex(SwigCPtr, indexRow, indexColumn);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the value at matrix by it's index.
        /// </summary>
        /// <param name="index">The index to set value.</param>
        /// <param name="value">The value to set.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValueAtIndex(uint index, float value)
        {
            Interop.Matrix.Matrix3SetValueAtIndex(SwigCPtr, index, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set the value at matrix by it's row index and column index.
        /// </summary>
        /// <param name="indexRow">The row index to set value.</param>
        /// <param name="indexColumn">The column index to set value.</param>
        /// <param name="value">The value to set.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValueAtIndex(uint indexRow, uint indexColumn, float value)
        {
            Interop.Matrix.Matrix3SetValueAtIndex(SwigCPtr, indexRow, indexColumn, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
