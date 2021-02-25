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
    internal class Property : Disposable
    {
        /// <summary>
        /// This constructor creates a property instance.
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyIndex">The index of a property.</param>
        public Property(Animatable arg0, int propertyIndex) : this(Interop.Property.NewProperty(Animatable.getCPtr(arg0), propertyIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This constructor creates a property instance.
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyIndex">The index of a property.</param>
        /// <param name="componentIndex">Index to a sub component of a property, for use with Vector2, Vector3 and Vector4. -1 for the main property (default is -1).</param>
        public Property(Animatable arg0, int propertyIndex, int componentIndex) : this(Interop.Property.NewProperty(Animatable.getCPtr(arg0), propertyIndex, componentIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This constructor creates a property instance.<br />
        /// This performs a property index query and is therefore slower than constructing a property directly with the index.<br />
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyName">The property name.</param>
        public Property(Animatable arg0, string propertyName) : this(Interop.Property.NewProperty(Animatable.getCPtr(arg0), propertyName), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This constructor creates a property instance.<br />
        /// This performs a property index query and is therefore slower than constructing a property directly with the index.<br />
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="componentIndex">Index to a sub component of a property, for use with Vector2, Vector3 and Vector4. -1 for main property (default is -1).</param>
        public Property(Animatable arg0, string propertyName, int componentIndex) : this(Interop.Property.NewProperty(Animatable.getCPtr(arg0), propertyName, componentIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Property(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets or sets the index of the property.
        /// </summary>
        public int propertyIndex
        {
            set
            {
                Interop.Property.PropertyIndexSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Property.PropertyIndexGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the component index of the property.
        /// </summary>
        public int componentIndex
        {
            set
            {
                Interop.Property.ComponentIndexSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Property.ComponentIndexGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int InvalidIndex
        {
            get
            {
                int ret = Interop.Property.InvalidIndexGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int InvalidKey
        {
            get
            {
                int ret = Interop.Property.InvalidKeyGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int InvalidComponentIndex
        {
            get
            {
                int ret = Interop.Property.InvalidComponentIndexGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal Animatable Object
        {
            set
            {
                Interop.Property.ObjectSet(SwigCPtr, Animatable.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Animatable ret = new Animatable(Interop.Property.ObjectGet(SwigCPtr), false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Property.DeleteProperty(swigCPtr);
        }
    }
}
