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

    internal class Any : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Any(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Any obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Any()
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
                    Interop.Any.delete_Any(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }


        public Any() : this(Interop.Any.new_Any__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public static void AssertAlways(string assertMessage)
        {
            Interop.Any.Any_AssertAlways(assertMessage);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Any(Any any) : this(Interop.Any.new_Any__SWIG_2(Any.getCPtr(any)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Any Assign(Any any)
        {
            Any ret = new Any(Interop.Any.Any_Assign(swigCPtr, Any.getCPtr(any)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public new SWIGTYPE_p_std__type_info GetType()
        {
            SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(Interop.Any.Any_GetType(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool Empty()
        {
            bool ret = Interop.Any.Any_Empty(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public class AnyContainerBase : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            /// <since_tizen> 3 </since_tizen>
            protected bool swigCMemOwn;

            internal AnyContainerBase(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AnyContainerBase obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            //A Flat to check if it is already disposed.
            /// <since_tizen> 3 </since_tizen>
            protected bool disposed = false;

            ~AnyContainerBase()
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
                        Interop.Any.delete_Any_AnyContainerBase(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

            /// <since_tizen> 3 </since_tizen>
            public AnyContainerBase(SWIGTYPE_p_std__type_info type, SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc, SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc) : this(Interop.Any.new_Any_AnyContainerBase(SWIGTYPE_p_std__type_info.getCPtr(type), SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase.getCPtr(cloneFunc), SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void.getCPtr(deleteFunc)), true)
            {
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }

            /// <since_tizen> 3 </since_tizen>
            public new SWIGTYPE_p_std__type_info GetType()
            {
                SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(Interop.Any.Any_AnyContainerBase_GetType(swigCPtr), false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <since_tizen> 3 </since_tizen>
            public SWIGTYPE_p_std__type_info mType
            {
                get
                {
                    SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(Interop.Any.Any_AnyContainerBase_mType_get(swigCPtr), false);
                    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase mCloneFunc
            {
                set
                {
                    Interop.Any.Any_AnyContainerBase_mCloneFunc_set(swigCPtr, SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase.getCPtr(value));
                    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.Any.Any_AnyContainerBase_mCloneFunc_get(swigCPtr);
                    SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(cPtr, false);
                    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void mDeleteFunc
            {
                set
                {
                    Interop.Any.Any_AnyContainerBase_mDeleteFunc_set(swigCPtr, SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void.getCPtr(value));
                    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.Any.Any_AnyContainerBase_mDeleteFunc_get(swigCPtr);
                    SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(cPtr, false);
                    if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

        }

        public Any.AnyContainerBase mContainer
        {
            set
            {
                Interop.Any.Any_mContainer_set(swigCPtr, Any.AnyContainerBase.getCPtr(value));
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.Any.Any_mContainer_get(swigCPtr);
                Any.AnyContainerBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new Any.AnyContainerBase(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

}
