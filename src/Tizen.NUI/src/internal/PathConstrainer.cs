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

    internal class PathConstrainer : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PathConstrainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PathConstrainer.PathConstrainer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PathConstrainer obj)
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
                    Interop.PathConstrainer.delete_PathConstrainer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }



        /// <since_tizen> 3 </since_tizen>
        public class Property : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            /// <since_tizen> 3 </since_tizen>
            protected bool swigCMemOwn;

            internal Property(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            //A Flat to check if it is already disposed.
            /// <since_tizen> 3 </since_tizen>
            protected bool disposed = false;


            ~Property()
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
                        Interop.PathConstrainer.delete_PathConstrainer_Property(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

            /// <since_tizen> 3 </since_tizen>
            public Property() : this(Interop.PathConstrainer.new_PathConstrainer_Property(), true)
            {
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }

            internal static readonly int FORWARD = Interop.PathConstrainer.PathConstrainer_Property_FORWARD_get();
            internal static readonly int POINTS = Interop.PathConstrainer.PathConstrainer_Property_POINTS_get();
            internal static readonly int CONTROL_POINTS = Interop.PathConstrainer.PathConstrainer_Property_CONTROL_POINTS_get();

        }

        public PathConstrainer() : this(Interop.PathConstrainer.PathConstrainer_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }
        public static PathConstrainer DownCast(BaseHandle handle)
        {
            PathConstrainer ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PathConstrainer;
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PathConstrainer(PathConstrainer handle) : this(Interop.PathConstrainer.new_PathConstrainer__SWIG_1(PathConstrainer.getCPtr(handle)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal PathConstrainer Assign(PathConstrainer rhs)
        {
            PathConstrainer ret = new PathConstrainer(Interop.PathConstrainer.PathConstrainer_Assign(swigCPtr, PathConstrainer.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Apply(Property target, Property source, Vector2 range, Vector2 wrap)
        {
            Interop.PathConstrainer.PathConstrainer_Apply__SWIG_0(swigCPtr, Property.getCPtr(target), Property.getCPtr(source), Vector2.getCPtr(range), Vector2.getCPtr(wrap));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void Apply(Property target, Property source, Vector2 range)
        {
            Interop.PathConstrainer.PathConstrainer_Apply__SWIG_1(swigCPtr, Property.getCPtr(target), Property.getCPtr(source), Vector2.getCPtr(range));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal void Remove(Animatable target)
        {
            Interop.PathConstrainer.PathConstrainer_Remove(swigCPtr, Animatable.getCPtr(target));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Vector3 Forward
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PathConstrainer.Property.FORWARD).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, PathConstrainer.Property.FORWARD, new Tizen.NUI.PropertyValue(value));
            }
        }

        public PropertyArray Points
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                Tizen.NUI.Object.GetProperty(swigCPtr, PathConstrainer.Property.POINTS).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, PathConstrainer.Property.POINTS, new Tizen.NUI.PropertyValue(value));
            }
        }

        public PropertyArray ControlPoints
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                Tizen.NUI.Object.GetProperty(swigCPtr, PathConstrainer.Property.CONTROL_POINTS).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, PathConstrainer.Property.CONTROL_POINTS, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}
