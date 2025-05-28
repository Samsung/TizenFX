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
        /// <param name="animatable">A valid handle to the target object.</param>
        /// <param name="propertyIndex">The index of a property.</param>
        public Property(Animatable animatable, int propertyIndex) : this(Interop.Property.NewProperty(Animatable.getCPtr(animatable), propertyIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This constructor creates a property instance.<br />
        /// This performs a property index query and is therefore slower than constructing a property directly with the index.<br />
        /// </summary>
        /// <param name="animatable">A valid handle to the target object.</param>
        /// <param name="propertyName">The property name.</param>
        public Property(Animatable animatable, string propertyName) : this(Interop.Property.NewProperty(Animatable.getCPtr(animatable), propertyName), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Property(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets or sets the index of the property.
        /// </summary>
        public int PropertyIndex
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

        internal const int InvalidIndex = -1; // Should be match with Interop.Property.InvalidIndexGet()
        internal const int InvalidKey = -1; // Should be match with Interop.Property.InvalidKeyGet()
        internal const int InvalidComponentIndex = -1; // Should be match with Interop.Property.InvalidComponentIndexGet()

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Property.DeleteProperty(swigCPtr);
        }
    }
}
