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
    /// The Matrix class represents transformations and projections. <br/>
    /// The matrix is stored as a flat array and is Column Major, i.e. the storage order is as follows (numbers represent indices of array): <br/>
    /// <code>
    /// 0   4   8   12
    /// 1   5   9   13
    /// 2   6   10  14
    /// 3   7   11  15
    /// </code>
    /// Each axis is contiguous in memory, so the x-axis corresponds to elements 0, 1, 2 and 3, the y-axis corresponds to
    /// elements 4, 5, 6, 7, the z-axis corresponds to elements 12, 13, 14 and 15, and the translation vector corresponds to
    /// elements 12, 13 and 14.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Matrix : Disposable
    {
        internal Matrix(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Matrix.DeleteMatrix(swigCPtr);
        }

        /// <summary>
        /// The constructor initialized as zero.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix() : this(Interop.Matrix.NewMatrix(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor whether initialize matrix or not.
        /// </summary>
        /// <param name="initialize">True if we want to initialize values as zero. False if we just allocate and do not initalize value.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix(bool initialize) : this(Interop.Matrix.NewMatrix(initialize), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor with continuous float array.
        /// </summary>
        /// <param name="array">Array of float value.</param>
        /// <remark>
        /// Please note that NUI using column major matrix.
        /// </remark>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix(float[] array) : this(Interop.Matrix.NewMatrix(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor with Rotation to be rotation transform matrix.
        /// </summary>
        /// <param name="rotation">Rotation information.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix(Rotation rotation) : this(Interop.Matrix.NewMatrixQuaternion(Rotation.getCPtr(rotation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="matrix">Matrix to create this matrix from</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix(Matrix matrix) : this(Interop.Matrix.NewMatrix(Matrix.getCPtr(matrix)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assign.
        /// </summary>
        /// <param name="rhs">A reference to the copied handle.</param>
        /// <returns>A reference to this.</returns>
        internal Matrix Assign(Matrix rhs)
        {
            Matrix ret = new Matrix(Interop.Matrix.Assign(SwigCPtr, Matrix.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The matrix as identity
        /// </summary>
        /// <code>
        /// [[1, 0, 0, 0],
        ///  [0, 1, 0, 0],
        ///  [0, 0, 1, 0],
        ///  [0, 0, 0, 1]]
        /// </code>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1065: Do not raise exceptions in unexpected locations")]
        public static Matrix Identity
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Matrix.IdentityGet();
                Matrix ret = (cPtr == global::System.IntPtr.Zero) ? null : new Matrix(cPtr, false);
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
        /// Multiply Matrix and Vector4.
        /// </summary>
        /// <code>
        /// returns = lhs * rhs;
        /// </code>
        /// <param name="lhs">The left-hand-side Matrix.</param>
        /// <param name="rhs">The right-hand-side Vector4.</param>
        /// <returns>The vector multiply as lhs * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector4 operator *(Matrix lhs, Vector4 rhs)
        {
            return lhs?.Multiply(rhs);
        }

        /// <summary>
        /// Multiply Rotation matrix and Matrix.
        /// </summary>
        /// <code>
        /// returns = lhs * rhs;
        /// </code>
        /// <param name="lhs">The left-hand-side Rotation.</param>
        /// <param name="rhs">The right-hand-side Matrix.</param>
        /// <returns>The Matrix multiply as lhs * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Matrix operator *(Rotation lhs, Matrix rhs)
        {
            Matrix ret = new Matrix(false);
            Matrix.Multiply(ret, rhs, lhs); // Note : Mutliply function be used for time-critical path. lhs and rhs is not matched as normal sense.
            return ret;
        }

        /// <summary>
        /// Multiply Matrix and Matrix.
        /// </summary>
        /// <code>
        /// returns = lhs * rhs;
        /// </code>
        /// <param name="lhs">The left-hand-side Matrix.</param>
        /// <param name="rhs">The right-hand-side Matrix.</param>
        /// <returns>The Matrix multiply as lhs * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Matrix operator *(Matrix lhs, Matrix rhs)
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
            Interop.Matrix.SetIdentity(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Make matrix as identity and multiply scale.
        /// </summary>
        /// <param name="scale">The scale value to be multiplied into identity Matrix.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetIdentityAndScale(Vector3 scale)
        {
            Interop.Matrix.SetIdentityAndScale(SwigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inverts a transform Matrix.<br/>
        /// Any Matrix representing only a rotation and/or translation
        /// can be inverted using this function. It is faster and more accurate then using Invert().
        /// </summary>
        /// <param name="result">The inverse of this Matrix.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InvertTransform(Matrix result)
        {
            Interop.Matrix.InvertTransform(SwigCPtr, Matrix.getCPtr(result));
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
            bool ret = Interop.Matrix.Invert(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Swaps the rows to columns.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Transpose()
        {
            Interop.Matrix.Transpose(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the X Axis from a Transform matrix.
        /// </summary>
        /// <returns>The X axis.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetXAxis()
        {
            Vector3 ret = new Vector3(Interop.Matrix.GetXAxis(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the Y Axis from a Transform matrix.
        /// </summary>
        /// <returns>The Y axis.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetYAxis()
        {
            Vector3 ret = new Vector3(Interop.Matrix.GetYAxis(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the Z Axis from a Transform matrix.
        /// </summary>
        /// <returns>The Z axis.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetZAxis()
        {
            Vector3 ret = new Vector3(Interop.Matrix.GetZAxis(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the X Axis to a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <param name="axis">The X axis.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetXAxis(Vector3 axis)
        {
            Interop.Matrix.SetXAxis(SwigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the Y Axis to a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <param name="axis">The Y axis.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetYAxis(Vector3 axis)
        {
            Interop.Matrix.SetYAxis(SwigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the Z Axis to a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <param name="axis">The Z axis.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetZAxis(Vector3 axis)
        {
            Interop.Matrix.SetZAxis(SwigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the translate from a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <returns>The Translation.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 GetTranslation()
        {
            Vector4 ret = new Vector4(Interop.Matrix.GetTranslation(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the x, y, and z components of translate from a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <returns>The Translation.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetTranslation3()
        {
            Vector3 ret = new Vector3(Interop.Matrix.GetTranslation3(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the translate to a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <returns>The Translation.</returns>
        /// <param name="translation">The translation.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTranslation(Vector4 translation)
        {
            Interop.Matrix.SetTranslationVector4(SwigCPtr, Vector4.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the translate to a Transform matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// <param name="translation">The translation.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTranslation(Vector3 translation)
        {
            Interop.Matrix.SetTranslationVector3(SwigCPtr, Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Makes the axes of the matrix orthogonal to each other and of unit length.<br/>
        /// This function is used to correct floating point errors which would otherwise accumulate
        /// as operations are applied to the matrix.<br/>
        /// This assumes the matrix is a transform matrix.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OrthoNormalize()
        {
            Interop.Matrix.OrthoNormalize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
        /// <param name="lhs">The left-hand-side Matrix. this can be same matrix as result.</param>
        /// <param name="rhs">The right-hand-side Matrix. this cannot be same matrix as result.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Multiply(Matrix result, Matrix lhs, Matrix rhs)
        {
            Interop.Matrix.Multiply(Matrix.getCPtr(result), Matrix.getCPtr(lhs), Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Function to multiply a matrix and rotataion and store the result onto third.<br/>
        /// Use this method in time critical path as it does not require temporaries.<br/>
        /// </summary>
        /// <remark>
        /// This Mutliply function be used for time-critical path. lhs and rhs is not matched as normal sense.
        /// </remark>
        /// <code>
        /// result = rhs * lhs;
        /// </code>
        /// <param name="result">Result of the multiplication.</param>
        /// <param name="lhs">The left-hand-side Matrix. this can be same matrix as result.</param>
        /// <param name="rhs">The right-hand-side Rotation.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Multiply(Matrix result, Matrix lhs, Rotation rhs)
        {
            Interop.Matrix.MultiplyQuaternion(Matrix.getCPtr(result), Matrix.getCPtr(lhs), Rotation.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Multiply the Matrix and Vector4.
        /// </summary>
        /// <code>
        /// returns = this * rhs;
        /// </code>
        /// <param name="rhs">The right-hand-side Vector4.</param>
        /// <returns>The vector multiply as this * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 Multiply(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Matrix.MultiplyVector4(SwigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Multiply the Matrix and Matrix.
        /// </summary>
        /// <code>
        /// returns = this * rhs;
        /// </code>
        /// <param name="rhs">The right-hand-side Matrix.</param>
        /// <returns>The matrix multiply as this * rhs.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix Multiply(Matrix rhs)
        {
            Matrix ret = new Matrix(Interop.Matrix.Multiply(SwigCPtr, Matrix.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Multiply the Matrix and Matrix. Result will be stored into this Matrix.
        /// </summary>
        /// <code>
        /// this = this * rhs;
        /// </code>
        /// <param name="rhs">The right-hand-side Matrix.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void MultiplyAssign(Matrix rhs)
        {
            Interop.Matrix.MultiplyAssign(SwigCPtr, Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the hash code of this Matrix.
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
        public bool EqualTo(Matrix rhs)
        {
            bool ret = Interop.Matrix.EqualTo(SwigCPtr, Matrix.getCPtr(rhs));
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
        public bool NotEqualTo(Matrix rhs)
        {
            bool ret = Interop.Matrix.NotEqualTo(SwigCPtr, Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets this matrix to contain the position, scale and rotation components.<br/>
        /// Performs scale, rotation, then translation
        /// </summary>
        /// <param name="scale">Scale to apply.</param>
        /// <param name="rotation">Rotation to apply.</param>
        /// <param name="translation">Translation to apply.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTransformComponents(Vector3 scale, Rotation rotation, Vector3 translation)
        {
            Interop.Matrix.SetTransformComponents(SwigCPtr, Vector3.getCPtr(scale), Rotation.getCPtr(rotation), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets this matrix to contain the inverse of the position, scale and rotation components.<br/>
        /// Performs scale, rotation, then translation
        /// </summary>
        /// <param name="scale">Scale to apply.</param>
        /// <param name="rotation">Rotation to apply.</param>
        /// <param name="translation">Translation to apply.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetInverseTransformComponents(Vector3 scale, Rotation rotation, Vector3 translation)
        {
            Interop.Matrix.SetInverseTransformComponents(SwigCPtr, Vector3.getCPtr(scale), Rotation.getCPtr(rotation), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets this matrix to contain the inverse of the orthonormal basis and position components.<br/>
        /// Performs scale, rotation, then translation
        /// </summary>
        /// <param name="xAxis">The X axis of the basis.</param>
        /// <param name="yAxis">The Y axis of the basis.</param>
        /// <param name="zAxis">The Z axis of the basis.</param>
        /// <param name="translation">Translation to apply.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetInverseTransformComponents(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis, Vector3 translation)
        {
            Interop.Matrix.SetInverseTransformComponents(SwigCPtr, Vector3.getCPtr(xAxis), Vector3.getCPtr(yAxis), Vector3.getCPtr(zAxis), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the position, scale and rotation components from the given transform matrix.<br/>
        /// </summary>
        /// <remark>
        /// This matrix must not contain skews or shears.
        /// </remark>
        /// <param name="position">Position to set.</param>
        /// <param name="rotation">Rotation to set - only valid if the transform matrix has not been skewed or sheared</param>
        /// <param name="scale">Scale to set - only valid if the transform matrix has not been skewed or sheared.</param>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetTransformComponents(Vector3 position, Rotation rotation, Vector3 scale)
        {
            Interop.Matrix.GetTransformComponents(SwigCPtr, Vector3.getCPtr(position), Rotation.getCPtr(rotation), Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            float ret = Interop.Matrix.ValueOfIndex(SwigCPtr, index);
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
            float ret = Interop.Matrix.ValueOfIndex(SwigCPtr, indexRow, indexColumn);
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
            Interop.Matrix.SetValueAtIndex(SwigCPtr, index, value);
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
            Interop.Matrix.SetValueAtIndex(SwigCPtr, indexRow, indexColumn, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the matrix class from native IntPtr
        /// </summary>
        /// <param name="cPtr">The native IntPtr.</param>
        /// <returns>New created matrix by inputed cPtr</returns>
        internal static Matrix GetMatrixFromPtr(global::System.IntPtr cPtr)
        {
            Matrix ret = new Matrix(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
