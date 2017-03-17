/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

    using System;

    public class Color : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Color(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Color obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~Color()
        {
            DisposeQueue.Instance.Add(this);
        }

        public virtual void Dispose()
        {
            if (!Stage.IsInstalled())
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_Vector4(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }


        public static Color operator +(Color arg1, Color arg2)
        {
            return arg1.Add(arg2);
        }

        public static Color operator -(Color arg1, Color arg2)
        {
            return arg1.Subtract(arg2);
        }

        public static Color operator -(Color arg1)
        {
            return arg1.Subtract();
        }

        public static Color operator *(Color arg1, Color arg2)
        {
            return arg1.Multiply(arg2);
        }

        public static Color operator *(Color arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        public static Color operator /(Color arg1, Color arg2)
        {
            return arg1.Divide(arg2);
        }

        public static Color operator /(Color arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }


        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        public static Color GetColorFromPtr(global::System.IntPtr cPtr)
        {
            Color ret = new Color(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public Color() : this(NDalicPINVOKE.new_Vector4__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Color(float r, float g, float b, float a) : this(NDalicPINVOKE.new_Vector4__SWIG_1(r, g, b, a), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Color(float[] array) : this(NDalicPINVOKE.new_Vector4__SWIG_2(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Color Add(Color rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Add(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color AddAssign(Vector4 rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_AddAssign(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract(Color rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Subtract__SWIG_0(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color SubtractAssign(Color rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_SubtractAssign(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(Color rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Multiply__SWIG_0(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(float rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(Color rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_MultiplyAssign__SWIG_0(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(float rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_MultiplyAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(Vector4 rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Divide__SWIG_0(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(float rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(Color rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_DivideAssign__SWIG_0(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(float rhs)
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_DivideAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract()
        {
            Color ret = new Color(NDalicPINVOKE.Vector4_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool EqualTo(Color rhs)
        {
            bool ret = NDalicPINVOKE.Vector4_EqualTo(swigCPtr, Color.getCPtr(rhs));

            if (rhs == null) return false;

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(Color rhs)
        {
            bool ret = NDalicPINVOKE.Vector4_NotEqualTo(swigCPtr, Color.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        private float ValueOfIndex(uint index)
        {
            float ret = NDalicPINVOKE.Vector4_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float R
        {
            set
            {
                NDalicPINVOKE.Vector4_r_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_r_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public float G
        {
            set
            {
                NDalicPINVOKE.Vector4_g_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_g_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public float B
        {
            set
            {
                NDalicPINVOKE.Vector4_b_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_b_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public float A
        {
            set
            {
                NDalicPINVOKE.Vector4_a_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_a_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Black
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.BLACK_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color White
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.WHITE_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Red
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.RED_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Green
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.GREEN_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Blue
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.BLUE_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Yellow
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.YELLOW_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Magenta
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.MAGENTA_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Cyan
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.CYAN_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color Transparent
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.TRANSPARENT_get();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static implicit operator Vector4(Color color)
        {
            return new Vector4(color.R, color.G, color.B, color.A);
        }

        public static implicit operator Color(Vector4 vec)
        {
            return new Color(vec.R, vec.G, vec.B, vec.A);
        }

    }

}


