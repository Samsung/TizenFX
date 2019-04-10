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

    /// <summary>
    /// TypeInfo class for instantiation of registered types and introspection of their actions and signals.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TypeInfo : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Creates TypeInfo object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TypeInfo() : this(Interop.TypeInfo.new_TypeInfo__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates TypeInfo object.
        /// </summary>
        /// <param name="handle">This copy constructor is required for (smart) pointer semantics.</param>
        /// <since_tizen> 3 </since_tizen>
        public TypeInfo(TypeInfo handle) : this(Interop.TypeInfo.new_TypeInfo__SWIG_1(TypeInfo.getCPtr(handle)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal TypeInfo(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.TypeInfo.TypeInfo_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Retrieves the type name for this type.
        /// </summary>
        /// <returns>The string name.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetName()
        {
            string ret = Interop.TypeInfo.TypeInfo_GetName(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the type name for this type.
        /// </summary>
        /// <returns>The string name.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetBaseName()
        {
            string ret = Interop.TypeInfo.TypeInfo_GetBaseName(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates an object from this type.
        /// </summary>
        /// <returns>The BaseHandle for the newly created object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BaseHandle CreateInstance()
        {
            BaseHandle ret = new BaseHandle(Interop.TypeInfo.TypeInfo_CreateInstance(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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
            uint ret = Interop.TypeInfo.TypeInfo_GetPropertyCount(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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
            string ret = Interop.TypeInfo.TypeInfo_GetPropertyName(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TypeInfo obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
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
                    Interop.TypeInfo.delete_TypeInfo(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

    }

}