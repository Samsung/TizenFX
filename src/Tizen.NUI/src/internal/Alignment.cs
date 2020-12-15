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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    internal class Alignment : View
    {

        internal Alignment(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Alignment.Upcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Alignment obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Alignment.DeleteAlignment(swigCPtr);
        }

        /// <since_tizen> 3 </since_tizen>
        public new class Padding : Disposable
        {

            internal Padding(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            {
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Padding obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            /// <since_tizen> 3 </since_tizen>
            protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                Interop.Alignment.DeleteAlignmentPadding(swigCPtr);
            }

            /// <since_tizen> 3 </since_tizen>
            public Padding() : this(Interop.Alignment.NewAlignmentPadding(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <since_tizen> 3 </since_tizen>
            public Padding(float l, float r, float t, float b) : this(Interop.Alignment.NewAlignmentPadding(l, r, t, b), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <since_tizen> 3 </since_tizen>
            public float left
            {
                set
                {
                    Interop.Alignment.PaddingLeftSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingLeftGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public float right
            {
                set
                {
                    Interop.Alignment.PaddingRightSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingRightGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public float top
            {
                set
                {
                    Interop.Alignment.PaddingTopSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingTopGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public float bottom
            {
                set
                {
                    Interop.Alignment.PaddingBottomSet(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingBottomGet(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }
        }

        public Alignment(Alignment.Type horizontal, Alignment.Type vertical) : this(Interop.Alignment.New((int)horizontal, (int)vertical), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Alignment(Alignment.Type horizontal) : this(Interop.Alignment.New((int)horizontal), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Alignment() : this(Interop.Alignment.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Alignment(Alignment alignment) : this(Interop.Alignment.NewAlignment(Alignment.getCPtr(alignment)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Alignment DownCast(BaseHandle handle)
        {
            Alignment ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Alignment;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAlignmentType(Alignment.Type type)
        {
            Interop.Alignment.SetAlignmentType(swigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Type GetAlignmentType()
        {
            Alignment.Type ret = (Alignment.Type)Interop.Alignment.GetAlignmentType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScaling(Alignment.Scaling scaling)
        {
            Interop.Alignment.SetScaling(swigCPtr, (int)scaling);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Scaling GetScaling()
        {
            Alignment.Scaling ret = (Alignment.Scaling)Interop.Alignment.GetScaling(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPadding(Alignment.Padding padding)
        {
            Interop.Alignment.SetPadding(swigCPtr, Alignment.Padding.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Padding GetPadding()
        {
            Alignment.Padding ret = new Alignment.Padding(Interop.Alignment.GetPadding(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Alignment Assign(Alignment alignment)
        {
            Alignment ret = new Alignment(Interop.Alignment.Assign(swigCPtr, Alignment.getCPtr(alignment)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum Type
        {
            HorizontalLeft = 1,
            HorizontalCenter = 2,
            HorizontalRight = 4,
            VerticalTop = 8,
            VerticalCenter = 16,
            VerticalBottom = 32
        }

        /// <since_tizen> 3 </since_tizen>
        public enum Scaling
        {
            ScaleNone,
            ScaleToFill,
            ScaleToFitKeepAspect,
            ScaleToFillKeepAspect,
            ShrinkToFit,
            ShrinkToFitKeepAspect
        }
    }
}
