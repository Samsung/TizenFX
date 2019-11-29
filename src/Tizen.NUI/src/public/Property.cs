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

namespace Tizen.NUI
{
    internal class Property : Disposable
    {

        /// <summary>
        /// This constructor creates a property instance.
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyIndex">The index of a property.</param>
        /// <since_tizen> 3 </since_tizen>
        public Property(Animatable arg0, int propertyIndex) : this(Interop.Property.new_Property__SWIG_0(Animatable.getCPtr(arg0), propertyIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This constructor creates a property instance.
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyIndex">The index of a property.</param>
        /// <param name="componentIndex">Index to a sub component of a property, for use with Vector2, Vector3 and Vector4. -1 for the main property (default is -1).</param>
        /// <since_tizen> 3 </since_tizen>
        public Property(Animatable arg0, int propertyIndex, int componentIndex) : this(Interop.Property.new_Property__SWIG_1(Animatable.getCPtr(arg0), propertyIndex, componentIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This constructor creates a property instance.<br />
        /// This performs a property index query and is therefore slower than constructing a property directly with the index.<br />
        /// </summary>
        /// <param name="arg0">A valid handle to the target object.</param>
        /// <param name="propertyName">The property name.</param>
        /// <since_tizen> 3 </since_tizen>
        public Property(Animatable arg0, string propertyName) : this(Interop.Property.new_Property__SWIG_2(Animatable.getCPtr(arg0), propertyName), true)
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
        /// <since_tizen> 3 </since_tizen>
        public Property(Animatable arg0, string propertyName, int componentIndex) : this(Interop.Property.new_Property__SWIG_3(Animatable.getCPtr(arg0), propertyName, componentIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Property(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets or sets the index of the property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int propertyIndex
        {
            set
            {
                Interop.Property.Property_propertyIndex_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Property.Property_propertyIndex_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the component index of the property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int componentIndex
        {
            set
            {
                Interop.Property.Property_componentIndex_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Property.Property_componentIndex_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int INVALID_INDEX
        {
            get
            {
                int ret = Interop.Property.Property_INVALID_INDEX_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int INVALID_KEY
        {
            get
            {
                int ret = Interop.Property.Property_INVALID_KEY_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int INVALID_COMPONENT_INDEX
        {
            get
            {
                int ret = Interop.Property.Property_INVALID_COMPONENT_INDEX_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal Animatable _object
        {
            set
            {
                Interop.Property.Property__object_set(swigCPtr, Animatable.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Animatable ret = new Animatable(Interop.Property.Property__object_get(swigCPtr), false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Property.delete_Property(swigCPtr);
        }
    }
}