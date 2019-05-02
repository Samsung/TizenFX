/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

    internal class Matrix : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Matrix(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Matrix obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }


        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;


        ~Matrix()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Matrix(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }


        public static Vector4 operator *(Matrix arg1, Vector4 arg2)
        {
            return arg1.Multiply(arg2);
        }

        public Matrix() : this(NDalicPINVOKE.new_Matrix__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(bool initialize) : this(NDalicPINVOKE.new_Matrix__SWIG_1(initialize), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(float[] array) : this(NDalicPINVOKE.new_Matrix__SWIG_2(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(Rotation rotation) : this(NDalicPINVOKE.new_Matrix__SWIG_3(Rotation.getCPtr(rotation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix(Matrix matrix) : this(NDalicPINVOKE.new_Matrix__SWIG_4(Matrix.getCPtr(matrix)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Matrix Assign(Matrix matrix)
        {
            Matrix ret = new Matrix(NDalicPINVOKE.Matrix_Assign(swigCPtr, Matrix.getCPtr(matrix)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Matrix IDENTITY
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Matrix_IDENTITY_get();
                Matrix ret = (cPtr == global::System.IntPtr.Zero) ? null : new Matrix(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public void SetIdentity()
        {
            NDalicPINVOKE.Matrix_SetIdentity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetIdentityAndScale(Vector3 scale)
        {
            NDalicPINVOKE.Matrix_SetIdentityAndScale(swigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void InvertTransform(Matrix result)
        {
            NDalicPINVOKE.Matrix_InvertTransform(swigCPtr, Matrix.getCPtr(result));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool Invert()
        {
            bool ret = NDalicPINVOKE.Matrix_Invert(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Transpose()
        {
            NDalicPINVOKE.Matrix_Transpose(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetXAxis()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Matrix_GetXAxis(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetYAxis()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Matrix_GetYAxis(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetZAxis()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Matrix_GetZAxis(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetXAxis(Vector3 axis)
        {
            NDalicPINVOKE.Matrix_SetXAxis(swigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetYAxis(Vector3 axis)
        {
            NDalicPINVOKE.Matrix_SetYAxis(swigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetZAxis(Vector3 axis)
        {
            NDalicPINVOKE.Matrix_SetZAxis(swigCPtr, Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetTranslation()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Matrix_GetTranslation(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetTranslation3()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Matrix_GetTranslation3(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTranslation(Vector4 translation)
        {
            NDalicPINVOKE.Matrix_SetTranslation__SWIG_0(swigCPtr, Vector4.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetTranslation(Vector3 translation)
        {
            NDalicPINVOKE.Matrix_SetTranslation__SWIG_1(swigCPtr, Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void OrthoNormalize()
        {
            NDalicPINVOKE.Matrix_OrthoNormalize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Matrix_AsFloat__SWIG_0(swigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static void Multiply(Matrix result, Matrix lhs, Matrix rhs)
        {
            NDalicPINVOKE.Matrix_Multiply__SWIG_0(Matrix.getCPtr(result), Matrix.getCPtr(lhs), Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void Multiply(Matrix result, Matrix lhs, Rotation rhs)
        {
            NDalicPINVOKE.Matrix_Multiply__SWIG_1(Matrix.getCPtr(result), Matrix.getCPtr(lhs), Rotation.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 Multiply(Vector4 rhs)
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Matrix_Multiply__SWIG_2(swigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool EqualTo(Matrix rhs)
        {
            bool ret = NDalicPINVOKE.Matrix_EqualTo(swigCPtr, Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(Matrix rhs)
        {
            bool ret = NDalicPINVOKE.Matrix_NotEqualTo(swigCPtr, Matrix.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTransformComponents(Vector3 scale, Rotation rotation, Vector3 translation)
        {
            NDalicPINVOKE.Matrix_SetTransformComponents(swigCPtr, Vector3.getCPtr(scale), Rotation.getCPtr(rotation), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetInverseTransformComponents(Vector3 scale, Rotation rotation, Vector3 translation)
        {
            NDalicPINVOKE.Matrix_SetInverseTransformComponents__SWIG_0(swigCPtr, Vector3.getCPtr(scale), Rotation.getCPtr(rotation), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetInverseTransformComponents(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis, Vector3 translation)
        {
            NDalicPINVOKE.Matrix_SetInverseTransformComponents__SWIG_1(swigCPtr, Vector3.getCPtr(xAxis), Vector3.getCPtr(yAxis), Vector3.getCPtr(zAxis), Vector3.getCPtr(translation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void GetTransformComponents(Vector3 position, Rotation rotation, Vector3 scale)
        {
            NDalicPINVOKE.Matrix_GetTransformComponents(swigCPtr, Vector3.getCPtr(position), Rotation.getCPtr(rotation), Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

    }

}
