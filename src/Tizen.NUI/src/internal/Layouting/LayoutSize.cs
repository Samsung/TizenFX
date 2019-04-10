/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class represents a layout size (width and height)
    /// </summary>
    internal class LayoutSize : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal LayoutSize(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutSize obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~LayoutSize()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock(this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        Interop.LayoutSize.delete_LayoutSize(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        public LayoutSize() : this(Interop.LayoutSize.new_LayoutSize__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public LayoutSize(int x, int y) : this(Interop.LayoutSize.new_LayoutSize__SWIG_1(x, y), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal void SetWidth(LayoutLength value)
        {
            Interop.LayoutSize.LayoutSize_SetWidth__SWIG_1(swigCPtr, LayoutLength.getCPtr(value));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal void SetHeight(LayoutLength value)
        {
            Interop.LayoutSize.LayoutSize_SetHeight__SWIG_1(swigCPtr, LayoutLength.getCPtr(value));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        private bool EqualTo(LayoutSize rhs)
        {
            bool ret = Interop.LayoutSize.LayoutSize_EqualTo(swigCPtr, LayoutSize.getCPtr(rhs));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsEqualTo(LayoutSize target)
        {
            if (this.Width == target.Width && this.Height == target.Height)
            {
                return true;
            }
            return false;
        }


        // This causes crash!
        // compile warning message :
        //'LayoutSize' defines operator == or operator != but does not override Object.Equals(object o)
        //'LayoutSize' defines operator == or operator != but does not override Object.GetHashCode()
        //public static bool operator ==(LayoutSize r1, LayoutSize r2)
        //{
        //    return r1.EqualTo(r2);
        //}
        //public static bool operator !=(LayoutSize r1, LayoutSize r2)
        //{
        //    return !r1.EqualTo(r2);
        //}


        public int Width
        {
            //This should be blocked! Otherwise, user can set multiple-cascading property setting like "LinearLayout.CellPadding.Width = 100;". This will not be working!
            //set
            //{
            //    LayoutPINVOKE.LayoutSize_width_set(swigCPtr, value);
            //    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            //}
            get
            {
                int ret = Interop.LayoutSize.LayoutSize_width_get(swigCPtr);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public int Height
        {
            //This should be blocked! Otherwise, user can set multiple-cascading property setting like "LinearLayout.CellPadding.Height = 100;". This will not be working!
            //set
            //{
            //    LayoutPINVOKE.LayoutSize_height_set(swigCPtr, value);
            //    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            //}
            get
            {
                int ret = Interop.LayoutSize.LayoutSize_height_get(swigCPtr);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
}
