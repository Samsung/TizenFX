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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    internal class Alignment : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Alignment(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Alignment_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Alignment obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
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
                    NDalicPINVOKE.delete_Alignment(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }



        /// <since_tizen> 3 </since_tizen>
        public new class Padding : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            /// <since_tizen> 3 </since_tizen>
            protected bool swigCMemOwn;

            internal Padding(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Padding obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            //A Flat to check if it is already disposed.
            /// <since_tizen> 3 </since_tizen>
            protected bool disposed = false;

            ~Padding()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            /// <since_tizen> 3 </since_tizen>
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

            /// <since_tizen> 3 </since_tizen>
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
                        NDalicPINVOKE.delete_Alignment_Padding(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

            /// <since_tizen> 3 </since_tizen>
            public Padding() : this(NDalicPINVOKE.new_Alignment_Padding__SWIG_0(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <since_tizen> 3 </since_tizen>
            public Padding(float l, float r, float t, float b) : this(NDalicPINVOKE.new_Alignment_Padding__SWIG_1(l, r, t, b), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <since_tizen> 3 </since_tizen>
            public float left
            {
                set
                {
                    NDalicPINVOKE.Alignment_Padding_left_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = NDalicPINVOKE.Alignment_Padding_left_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public float right
            {
                set
                {
                    NDalicPINVOKE.Alignment_Padding_right_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = NDalicPINVOKE.Alignment_Padding_right_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public float top
            {
                set
                {
                    NDalicPINVOKE.Alignment_Padding_top_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = NDalicPINVOKE.Alignment_Padding_top_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public float bottom
            {
                set
                {
                    NDalicPINVOKE.Alignment_Padding_bottom_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = NDalicPINVOKE.Alignment_Padding_bottom_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

        }

        public Alignment(Alignment.Type horizontal, Alignment.Type vertical) : this(NDalicPINVOKE.Alignment_New__SWIG_0((int)horizontal, (int)vertical), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Alignment(Alignment.Type horizontal) : this(NDalicPINVOKE.Alignment_New__SWIG_1((int)horizontal), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Alignment() : this(NDalicPINVOKE.Alignment_New__SWIG_2(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Alignment(Alignment alignment) : this(NDalicPINVOKE.new_Alignment__SWIG_1(Alignment.getCPtr(alignment)), true)
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
            NDalicPINVOKE.Alignment_SetAlignmentType(swigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Type GetAlignmentType()
        {
            Alignment.Type ret = (Alignment.Type)NDalicPINVOKE.Alignment_GetAlignmentType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScaling(Alignment.Scaling scaling)
        {
            NDalicPINVOKE.Alignment_SetScaling(swigCPtr, (int)scaling);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Scaling GetScaling()
        {
            Alignment.Scaling ret = (Alignment.Scaling)NDalicPINVOKE.Alignment_GetScaling(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPadding(Alignment.Padding padding)
        {
            NDalicPINVOKE.Alignment_SetPadding(swigCPtr, Alignment.Padding.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Alignment.Padding GetPadding()
        {
            Alignment.Padding ret = new Alignment.Padding(NDalicPINVOKE.Alignment_GetPadding(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Alignment Assign(Alignment alignment)
        {
            Alignment ret = new Alignment(NDalicPINVOKE.Alignment_Assign(swigCPtr, Alignment.getCPtr(alignment)), false);
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
