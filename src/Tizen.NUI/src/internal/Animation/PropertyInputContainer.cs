/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using global::System.ComponentModel;
using global::System.Runtime.InteropServices;
namespace Tizen.NUI
{
    /// <summary>
    /// An class for Constraints Function.
    /// </summary>
    internal class PropertyInputContainer : IDisposable
    {
        private HandleRef swigCPtr;
        private bool disposed;

        internal PropertyInputContainer(IntPtr cPtr)
        {
            swigCPtr = new HandleRef(this, cPtr);
            Count = Interop.PropertyInputContainer.GetCount(swigCPtr);
        }

        ~PropertyInputContainer() => Dispose(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Count { get; init; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyType GetPropertyType(uint index)
        {
            int ret = Interop.PropertyInputContainer.GetPropertyType(swigCPtr, index);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return (PropertyType)ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetBoolean(uint index)
        {
            bool ret = Interop.PropertyInputContainer.GetBoolean(swigCPtr, index);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFloat(uint index)
        {
            float ret = Interop.PropertyInputContainer.GetFloat(swigCPtr, index);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetInteger(uint index)
        {
            int ret = Interop.PropertyInputContainer.GetInteger(swigCPtr, index);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIVector2 GetVector2(uint index)
        {
            Interop.PropertyInputContainer.GetVector2Componentwise(swigCPtr, index, out float x, out float y);
            UIVector2 ret = new UIVector2(x, y);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIVector3 GetVector3(uint index)
        {
            Interop.PropertyInputContainer.GetVector3Componentwise(swigCPtr, index, out float x, out float y, out float z);
            UIVector3 ret = new UIVector3(x, y, z);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIColor GetColor(uint index)
        {
            Interop.PropertyInputContainer.GetVector4Componentwise(swigCPtr, index, out float x, out float y, out float z, out float w);
            UIColor ret = new UIColor(x, y, z, w);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public Vector4 GetVector4(uint index)
        {
            Interop.PropertyInputContainer.GetVector4Componentwise(swigCPtr, index, out float x, out float y, out float z, out float w);
            Vector4 ret = new Vector4(x, y, z, w);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public Matrix3 GetMatrix3(uint index)
        {
            Matrix3 ret = new Matrix3(Interop.PropertyInputContainer.GetMatrix3(swigCPtr, index), true);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public Matrix GetMatrix(uint index)
        {
            Matrix ret = new Matrix(Interop.PropertyInputContainer.GetMatrix(swigCPtr, index), true);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public Rotation GetRotation(uint index)
        {
            Rotation ret = new Rotation(Interop.PropertyInputContainer.GetRotation(swigCPtr, index), true);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                var nativeSwigCPtr = swigCPtr.Handle;
                swigCPtr = new HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

    }
}
