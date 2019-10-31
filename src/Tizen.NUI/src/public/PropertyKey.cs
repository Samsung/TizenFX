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
    /// <summary>
    /// A key type which can be either a std::string or a Property::Index.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PropertyKey : Disposable
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="key">The string key.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyKey(string key) : this(Interop.Property.new_Property_Key__SWIG_0(key), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="key">The index key.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyKey(int key) : this(Interop.Property.new_Property_Key__SWIG_1(key), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyKey(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The type of key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum KeyType
        {
            /// <summary>
            /// The type of key is index.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Index,
            /// <summary>
            /// The type of key is string.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            String
        }

        /// <summary>
        /// The type of the key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyKey.KeyType Type
        {
            set
            {
                Interop.Property.Property_Key_type_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                PropertyKey.KeyType ret = (PropertyKey.KeyType)Interop.Property.Property_Key_type_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The index key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int IndexKey
        {
            set
            {
                Interop.Property.Property_Key_indexKey_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Property.Property_Key_indexKey_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The string key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string StringKey
        {
            set
            {
                Interop.Property.Property_Key_stringKey_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = Interop.Property.Property_Key_stringKey_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Compares if rhs is equal to.
        /// </summary>
        /// <param name="rhs">A string key to compare against.</param>
        /// <returns>Returns true if the key compares, or false if it isn't equal or of the wrong type.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(string rhs)
        {
            bool ret = Interop.Property.Property_Key_EqualTo__SWIG_0(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is equal to.
        /// </summary>
        /// <param name="rhs">The index key to compare against.</param>
        /// <returns>Returns true if the key compares, or false if it isn't equal or of the wrong type.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(int rhs)
        {
            bool ret = Interop.Property.Property_Key_EqualTo__SWIG_1(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is equal to
        /// </summary>
        /// <param name="rhs">A key to compare against</param>
        /// <returns>Returns true if the keys are of the same type and have the same value.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(PropertyKey rhs)
        {
            bool ret = Interop.Property.Property_Key_EqualTo__SWIG_2(swigCPtr, PropertyKey.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The index key to compare against.</param>
        /// <returns>Returns true if the key is not equal or not a string key.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(string rhs)
        {
            bool ret = Interop.Property.Property_Key_NotEqualTo__SWIG_0(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The index key to compare against.</param>
        /// <returns>Returns true if the key is not equal, or not the index key.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(int rhs)
        {
            bool ret = Interop.Property.Property_Key_NotEqualTo__SWIG_1(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is not equal to.
        /// </summary>
        /// <param name="rhs">A key to compare against.</param>
        /// <returns>Returns true if the keys are not of the same type or are not equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(PropertyKey rhs)
        {
            bool ret = Interop.Property.Property_Key_NotEqualTo__SWIG_2(swigCPtr, PropertyKey.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyKey obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Property.delete_Property_Key(swigCPtr);
        }
    }
}
