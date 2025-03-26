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
    /// An abstract base class for ConstraintsFunction.
    /// Must not be open to public.
    /// </summary>
    internal class ConstraintFunctionBase : Disposable
    {
        internal ConstraintFunctionBase(IntPtr cPtr, System.Delegate callback) : this(cPtr, true)
        {
            Callback = callback;
        }

        internal ConstraintFunctionBase(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal PropertyType Type { get; init; }
        internal System.Delegate Callback { get; init; } // Invoke to user
        internal System.Delegate InternalCallback { get; init; } // Comes from native
        internal uint Id { get; init; }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if(Disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                RenderThreadObjectHolder.RegisterDelegate(Callback);
                RenderThreadObjectHolder.RegisterDelegate(InternalCallback);
            }
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            switch (Type)
            {
                case PropertyType.Boolean:
                {
                    Interop.ConstraintFunction.DeleteBooleanFunction(swigCPtr);
                    break;
                }
                case PropertyType.Float:
                {
                    Interop.ConstraintFunction.DeleteFloatFunction(swigCPtr);
                    break;
                }
                case PropertyType.Integer:
                {
                    Interop.ConstraintFunction.DeleteIntegerFunction(swigCPtr);
                    break;
                }
                case PropertyType.Vector2:
                {
                    Interop.ConstraintFunction.DeleteVector2Function(swigCPtr);
                    break;
                }
                case PropertyType.Vector3:
                {
                    Interop.ConstraintFunction.DeleteVector3Function(swigCPtr);
                    break;
                }
                case PropertyType.Vector4:
                {
                    Interop.ConstraintFunction.DeleteVector4Function(swigCPtr);
                    break;
                }
                case PropertyType.Matrix3:
                {
                    Interop.ConstraintFunction.DeleteMatrix3Function(swigCPtr);
                    break;
                }
                case PropertyType.Matrix:
                {
                    Interop.ConstraintFunction.DeleteMatrixFunction(swigCPtr);
                    break;
                }
                case PropertyType.Rotation:
                {
                    Interop.ConstraintFunction.DeleteRotationFunction(swigCPtr);
                    break;
                }
                default:
                {
                    throw new ArgumentException("Type : " + Type);
                }
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for boolean.
    /// </summary>
    internal class ConstraintBooleanFunction : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(ref bool current, uint id, IntPtr inputContainerCPtr);

        public ConstraintBooleanFunction(Constraint.ConstraintBooleanFunctionCallbackType callback) : base(Interop.ConstraintFunction.BooleanFunctionNew(), callback)
        {
            Type = PropertyType.Boolean;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetBooleanFunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetBooleanFunction(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(ref bool current, uint id, IntPtr inputContainerCPtr)
        {
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);
            bool ret = (Callback as Constraint.ConstraintBooleanFunctionCallbackType).Invoke(current, id, in container);
            current = ret;
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for float.
    /// </summary>
    internal class ConstraintFloatFunction : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(ref float current, uint id, IntPtr inputContainerCPtr);

        public ConstraintFloatFunction(Constraint.ConstraintFloatFunctionCallbackType callback) : base(Interop.ConstraintFunction.FloatFunctionNew(), callback)
        {
            Type = PropertyType.Float;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetFloatFunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetFloatFunction(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(ref float current, uint id, IntPtr inputContainerCPtr)
        {
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);
            float ret = (Callback as Constraint.ConstraintFloatFunctionCallbackType).Invoke(current, id, in container);
            current = ret;
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for int.
    /// </summary>
    internal class ConstraintIntegerFunction : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(ref int current, uint id, IntPtr inputContainerCPtr);

        public ConstraintIntegerFunction(Constraint.ConstraintIntegerFunctionCallbackType callback) : base(Interop.ConstraintFunction.IntegerFunctionNew(), callback)
        {
            Type = PropertyType.Integer;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetIntegerFunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetIntegerFunction(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(ref int current, uint id, IntPtr inputContainerCPtr)
        {
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);
            int ret = (Callback as Constraint.ConstraintIntegerFunctionCallbackType).Invoke(current, id, in container);
            current = ret;
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Vector2.
    /// </summary>
    internal class ConstraintVector2Function : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintVector2Function(Constraint.ConstraintVector2FunctionCallbackType callback) : base(Interop.ConstraintFunction.Vector2FunctionNew(), callback)
        {
            Type = PropertyType.Vector2;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetVector2FunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetVector2Function(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Vector2 tempVector2 = new Vector2(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            UIVector2 realCurrent = new UIVector2(tempVector2.X, tempVector2.Y);
            UIVector2 ret = (Callback as Constraint.ConstraintVector2FunctionCallbackType).Invoke(realCurrent, id, in container);

            Interop.Vector2.XSet(Vector2.getCPtr(tempVector2), ret.X);
            Interop.Vector2.YSet(Vector2.getCPtr(tempVector2), ret.Y);
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Vector3.
    /// </summary>
    internal class ConstraintVector3Function : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintVector3Function(Constraint.ConstraintVector3FunctionCallbackType callback) : base(Interop.ConstraintFunction.Vector3FunctionNew(), callback)
        {
            Type = PropertyType.Vector3;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetVector3FunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetVector3Function(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Vector3 tempVector3 = new Vector3(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            UIVector3 realCurrent = new UIVector3(tempVector3.X, tempVector3.Y, tempVector3.Z);
            UIVector3 ret = (Callback as Constraint.ConstraintVector3FunctionCallbackType).Invoke(realCurrent, id, in container);

            Interop.Vector3.XSet(Vector3.getCPtr(tempVector3), ret.X);
            Interop.Vector3.YSet(Vector3.getCPtr(tempVector3), ret.Y);
            Interop.Vector3.ZSet(Vector3.getCPtr(tempVector3), ret.Z);
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Color. (Special case of Vector4, that we can use UIColor)
    /// </summary>
    internal class ConstraintColorFunction : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintColorFunction(Constraint.ConstraintColorFunctionCallbackType callback) : base(Interop.ConstraintFunction.Vector4FunctionNew(), callback)
        {
            Type = PropertyType.Vector4;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetVector4FunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetVector4Function(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Vector4 tempVector4 = new Vector4(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            UIColor realCurrent = new UIColor(tempVector4.X, tempVector4.Y, tempVector4.Z, tempVector4.W);
            UIColor ret = (Callback as Constraint.ConstraintColorFunctionCallbackType).Invoke(realCurrent, id, in container);

            Interop.Vector4.XSet(Vector3.getCPtr(tempVector4), ret.R);
            Interop.Vector4.YSet(Vector3.getCPtr(tempVector4), ret.G);
            Interop.Vector4.ZSet(Vector3.getCPtr(tempVector4), ret.B);
            Interop.Vector4.WSet(Vector3.getCPtr(tempVector4), ret.A);
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Vector4.
    /// </summary>
    internal class ConstraintVector4Function : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintVector4Function(Constraint.ConstraintVector4FunctionCallbackType callback) : base(Interop.ConstraintFunction.Vector4FunctionNew(), callback)
        {
            Type = PropertyType.Vector4;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetVector4FunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetVector4Function(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Vector4 tempVector4 = new Vector4(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            // TODO : Chane below logic if UIVector4 Implemented.
            using Vector4 ret = (Callback as Constraint.ConstraintVector4FunctionCallbackType).Invoke(in tempVector4, id, in container);

            if (ret != null)
            {
                Interop.Vector4.XSet(Vector4.getCPtr(tempVector4), ret.X);
                Interop.Vector4.YSet(Vector4.getCPtr(tempVector4), ret.Y);
                Interop.Vector4.ZSet(Vector4.getCPtr(tempVector4), ret.Z);
                Interop.Vector4.WSet(Vector4.getCPtr(tempVector4), ret.W);
            }
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Matrix3.
    /// </summary>
    internal class ConstraintMatrix3Function : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintMatrix3Function(Constraint.ConstraintMatrix3FunctionCallbackType callback) : base(Interop.ConstraintFunction.Matrix3FunctionNew(), callback)
        {
            Type = PropertyType.Matrix3;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetMatrix3FunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetMatrix3Function(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Matrix3 tempMatix3 = new Matrix3(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            using Matrix3 ret = (Callback as Constraint.ConstraintMatrix3FunctionCallbackType).Invoke(in tempMatix3, id, in container);

            if (ret != null)
            {
                // Copy to native result. TODO : Can we optimize here?
                tempMatix3.Assign(ret);
            }
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Matrix.
    /// </summary>
    internal class ConstraintMatrixFunction : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintMatrixFunction(Constraint.ConstraintMatrixFunctionCallbackType callback) : base(Interop.ConstraintFunction.MatrixFunctionNew(), callback)
        {
            Type = PropertyType.Matrix;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetMatrixFunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetMatrixFunction(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Matrix tempMatix = new Matrix(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            using Matrix ret = (Callback as Constraint.ConstraintMatrixFunctionCallbackType).Invoke(in tempMatix, id, in container);

            if (ret != null)
            {
                // Copy to native result. TODO : Can we optimize here?
                tempMatix.Assign(ret);
            }
        }
    }

    /// <summary>
    /// An class for ConstraintsFunction for Rotation.
    /// </summary>
    internal class ConstraintRotationFunction : ConstraintFunctionBase
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InternalCallbackType(IntPtr current, uint id, IntPtr inputContainerCPtr);

        public ConstraintRotationFunction(Constraint.ConstraintRotationFunctionCallbackType callback) : base(Interop.ConstraintFunction.RotationFunctionNew(), callback)
        {
            Type = PropertyType.Rotation;

            InternalCallback = (InternalCallbackType)OnCallback;

            Id = Interop.ConstraintFunction.GetRotationFunctionId(SwigCPtr);

            var ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(InternalCallback);

            Interop.ConstraintFunction.SetRotationFunction(SwigCPtr, new HandleRef(this, ip));
        }

        private void OnCallback(IntPtr current, uint id, IntPtr inputContainerCPtr)
        {
            using Rotation tempRotation = new Rotation(current, false);
            using PropertyInputContainer container = new PropertyInputContainer(inputContainerCPtr);

            using Rotation ret = (Callback as Constraint.ConstraintRotationFunctionCallbackType).Invoke(in tempRotation, id, in container);

            if (ret != null)
            {
                // Copy to native result. TODO : Can we optimize here?
                tempRotation.Assign(ret);
            }
        }
    }
}
