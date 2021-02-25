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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class Alignment : View
    {
        internal Alignment(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Alignment obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Alignment.DeleteAlignment(swigCPtr);
        }

        public new class Padding : Disposable
        {

            internal Padding(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            {
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Padding obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
            }

            protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                Interop.Alignment.DeleteAlignmentPadding(swigCPtr);
            }

            public Padding() : this(Interop.Alignment.NewAlignmentPadding(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            public Padding(float l, float r, float t, float b) : this(Interop.Alignment.NewAlignmentPadding(l, r, t, b), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            public float left
            {
                set
                {
                    Interop.Alignment.PaddingLeftSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingLeftGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public float right
            {
                set
                {
                    Interop.Alignment.PaddingRightSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingRightGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public float top
            {
                set
                {
                    Interop.Alignment.PaddingTopSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingTopGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public float bottom
            {
                set
                {
                    Interop.Alignment.PaddingBottomSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.Alignment.PaddingBottomGet(SwigCPtr);
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
            Interop.Alignment.SetAlignmentType(SwigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Type GetAlignmentType()
        {
            Alignment.Type ret = (Alignment.Type)Interop.Alignment.GetAlignmentType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScaling(Alignment.Scaling scaling)
        {
            Interop.Alignment.SetScaling(SwigCPtr, (int)scaling);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Scaling GetScaling()
        {
            Alignment.Scaling ret = (Alignment.Scaling)Interop.Alignment.GetScaling(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPadding(Alignment.Padding padding)
        {
            Interop.Alignment.SetPadding(SwigCPtr, Alignment.Padding.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Padding GetPadding()
        {
            Alignment.Padding ret = new Alignment.Padding(Interop.Alignment.GetPadding(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Alignment Assign(Alignment alignment)
        {
            Alignment ret = new Alignment(Interop.Alignment.Assign(SwigCPtr, Alignment.getCPtr(alignment)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public enum Type
        {
            HorizontalLeft = 1,
            HorizontalCenter = 2,
            HorizontalRight = 4,
            VerticalTop = 8,
            VerticalCenter = 16,
            VerticalBottom = 32
        }

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
