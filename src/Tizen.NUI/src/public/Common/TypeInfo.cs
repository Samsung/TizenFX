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
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// TypeInfo class for instantiation of registered types and introspection of their actions and signals.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TypeInfo : BaseHandle
    {

        /// <summary>
        /// Creates TypeInfo object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TypeInfo() : this(Interop.TypeInfo.NewTypeInfo(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates TypeInfo object.
        /// </summary>
        /// <param name="handle">This copy constructor is required for (smart) pointer semantics.</param>
        /// <since_tizen> 3 </since_tizen>
        public TypeInfo(TypeInfo handle) : this(Interop.TypeInfo.NewTypeInfo(TypeInfo.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TypeInfo(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Retrieves the type name for this type.
        /// </summary>
        /// <returns>The string name.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetName()
        {
            string ret = Interop.TypeInfo.GetName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the type name for this type.
        /// </summary>
        /// <returns>The string name.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetBaseName()
        {
            string ret = Interop.TypeInfo.GetBaseName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates an object from this type.
        /// </summary>
        /// <returns>The BaseHandle for the newly created object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle CreateInstance()
        {
            BaseHandle ret = new BaseHandle(Interop.TypeInfo.CreateInstance(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the number of event side type registered properties for this type.<br />
        /// This count does not include all properties.
        /// </summary>
        /// <returns>The count.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetPropertyCount()
        {
            uint ret = Interop.TypeInfo.GetPropertyCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Given a property index, retrieve the property name associated with it.
        /// </summary>
        /// <param name="index">The property index.</param>
        /// <returns>The name of the property at the given index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetPropertyName(int index)
        {
            string ret = Interop.TypeInfo.GetPropertyName(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TypeInfo obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TypeInfo.DeleteTypeInfo(swigCPtr);
        }
    }
}
