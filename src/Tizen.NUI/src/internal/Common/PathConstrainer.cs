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

namespace Tizen.NUI
{
    internal class PathConstrainer : BaseHandle
    {
        internal PathConstrainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PathConstrainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PathConstrainer.DeletePathConstrainer(swigCPtr);
        }

        internal class Property
        {
            internal static readonly int FORWARD = Interop.PathConstrainer.ForwardGet();
            internal static readonly int POINTS = Interop.PathConstrainer.PointsGet();
            internal static readonly int ControlPoints = Interop.PathConstrainer.ControlPointsGet();
        }

        public PathConstrainer() : this(Interop.PathConstrainer.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public static PathConstrainer DownCast(BaseHandle handle)
        {
            PathConstrainer ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PathConstrainer;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PathConstrainer(PathConstrainer handle) : this(Interop.PathConstrainer.NewPathConstrainer(PathConstrainer.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PathConstrainer Assign(PathConstrainer rhs)
        {
            PathConstrainer ret = new PathConstrainer(Interop.PathConstrainer.Assign(SwigCPtr, PathConstrainer.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Apply(Tizen.NUI.Property target, Tizen.NUI.Property source, Vector2 range, Vector2 wrap)
        {
            Interop.PathConstrainer.Apply(SwigCPtr, Tizen.NUI.Property.getCPtr(target), Tizen.NUI.Property.getCPtr(source), Vector2.getCPtr(range), Vector2.getCPtr(wrap));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Apply(Tizen.NUI.Property target, Tizen.NUI.Property source, Vector2 range)
        {
            Interop.PathConstrainer.Apply(SwigCPtr, Tizen.NUI.Property.getCPtr(target), Tizen.NUI.Property.getCPtr(source), Vector2.getCPtr(range));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Remove(Animatable target)
        {
            Interop.PathConstrainer.Remove(SwigCPtr, Animatable.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 Forward
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(SwigCPtr, PathConstrainer.Property.FORWARD).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, PathConstrainer.Property.FORWARD, new Tizen.NUI.PropertyValue(value));
            }
        }

        public PropertyArray Points
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                Tizen.NUI.Object.GetProperty(SwigCPtr, PathConstrainer.Property.POINTS).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, PathConstrainer.Property.POINTS, new Tizen.NUI.PropertyValue(value));
            }
        }

        public PropertyArray ControlPoints
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                Tizen.NUI.Object.GetProperty(SwigCPtr, PathConstrainer.Property.ControlPoints).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, PathConstrainer.Property.ControlPoints, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
