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
    internal class LinearConstrainer : BaseHandle
    {
        internal LinearConstrainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LinearConstrainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.LinearConstrainer.DeleteLinearConstrainer(swigCPtr);
        }

        internal class Property
        {
            internal static readonly int VALUE = Interop.LinearConstrainer.ValueGet();
            internal static readonly int PROGRESS = Interop.LinearConstrainer.ProgressGet();
        }

        public LinearConstrainer() : this(Interop.LinearConstrainer.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static LinearConstrainer DownCast(BaseHandle handle)
        {
            LinearConstrainer ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as LinearConstrainer;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LinearConstrainer(LinearConstrainer handle) : this(Interop.LinearConstrainer.NewLinearConstrainer(LinearConstrainer.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LinearConstrainer Assign(LinearConstrainer rhs)
        {
            LinearConstrainer ret = new LinearConstrainer(Interop.LinearConstrainer.Assign(SwigCPtr, LinearConstrainer.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Apply(Tizen.NUI.Property target, Tizen.NUI.Property source, Vector2 range, Vector2 wrap)
        {
            Interop.LinearConstrainer.Apply(SwigCPtr, Tizen.NUI.Property.getCPtr(target), Tizen.NUI.Property.getCPtr(source), Vector2.getCPtr(range), Vector2.getCPtr(wrap));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Apply(Tizen.NUI.Property target, Tizen.NUI.Property source, Vector2 range)
        {
            Interop.LinearConstrainer.Apply(SwigCPtr, Tizen.NUI.Property.getCPtr(target), Tizen.NUI.Property.getCPtr(source), Vector2.getCPtr(range));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Remove(Animatable target)
        {
            Interop.LinearConstrainer.Remove(SwigCPtr, Animatable.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PropertyArray Value
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                Tizen.NUI.Object.GetProperty(SwigCPtr, LinearConstrainer.Property.VALUE).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, LinearConstrainer.Property.VALUE, new Tizen.NUI.PropertyValue(value));
            }
        }

        public PropertyArray Progress
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                Tizen.NUI.Object.GetProperty(SwigCPtr, LinearConstrainer.Property.PROGRESS).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, LinearConstrainer.Property.PROGRESS, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
