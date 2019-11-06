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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// An array of property values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PropertyArray : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray() : this(Interop.Property.new_Property_Array__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyArray(PropertyArray other) : this(Interop.Property.new_Property_Array__SWIG_1(PropertyArray.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyArray(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The operator to access an element.
        /// </summary>
        /// <param name="index">The element index to access. No bounds checking is performed.</param>
        /// <returns>The reference to the element.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// Retrieves the number of elements in the array.
        /// </summary>
        /// <returns>The number of elements in the array.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint Size()
        {
            uint ret = Interop.Property.Property_Array_Size(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the number of elements in the array.
        /// </summary>
        /// <returns>The number of elements in the array.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint Count()
        {
            uint ret = Interop.Property.Property_Array_Count(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns whether the array is empty.
        /// </summary>
        /// <returns>Returns true if empty, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Empty()
        {
            bool ret = Interop.Property.Property_Array_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Clear()
        {
            Interop.Property.Property_Array_Clear(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Increases the capacity of the array.
        /// </summary>
        /// <param name="size">The size to reserve.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Reserve(uint size)
        {
            Interop.Property.Property_Array_Reserve(swigCPtr, size);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resizes to size.
        /// </summary>
        /// <param name="size">The size to resize</param>
        /// <since_tizen> 3 </since_tizen>
        public void Resize(uint size)
        {
            Interop.Property.Property_Array_Resize(swigCPtr, size);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the capacity of the array.
        /// </summary>
        /// <returns>The allocated capacity of the array.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint Capacity()
        {
            uint ret = Interop.Property.Property_Array_Capacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds an element to the array.
        /// </summary>
        /// <param name="value">The value to add at the end of the array.</param>
        /// <since_tizen> 3 </since_tizen>
        public void PushBack(PropertyValue value)
        {
            Interop.Property.Property_Array_PushBack(swigCPtr, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds an keyvalue to the array.
        /// This function should be first
        /// </summary>
        /// <param name="value">The value to add at the end of the array.</param>
        public PropertyArray Add(KeyValue value)
        {
            PropertyArray ret = new PropertyArray(Interop.Property.Property_Array_Add(swigCPtr, PropertyValue.getCPtr(value.TrueValue)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds an element to the array.
        /// </summary>
        /// <param name="value">The value to add at the end of the array.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray Add(PropertyValue value)
        {
            PropertyArray ret = new PropertyArray(Interop.Property.Property_Array_Add(swigCPtr, PropertyValue.getCPtr(value)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Accesses an element.
        /// </summary>
        /// <param name="index">The element index to access. No bounds checking is performed.</param>
        /// <returns>The reference to the element.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue GetElementAt(uint index)
        {
            PropertyValue ret = new PropertyValue(Interop.Property.Property_Array_GetElementAt__SWIG_0(swigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyArray obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Property.delete_Property_Array(swigCPtr);
        }

        /// <summary>
        /// Retrieves the value of elements in the array.
        /// </summary>
        /// <param name="index">The element index to retrieve.</param>
        /// <returns>The reference to the element.</returns>
        private PropertyValue ValueOfIndex(uint index)
        {
            PropertyValue ret = new PropertyValue(Interop.Property.Property_Array_ValueOfIndex__SWIG_0(swigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
