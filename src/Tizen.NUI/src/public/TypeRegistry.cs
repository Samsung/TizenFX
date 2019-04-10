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
    /// The TypeRegistry allows registration of type instance creation functions.
    /// These can then be created later by name and down cast to the appropriate type.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TypeRegistry : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal TypeRegistry(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.TypeRegistry.TypeRegistry_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TypeRegistry obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
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
                    Interop.TypeRegistry.delete_TypeRegistry(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Gets Type Registry handle.
        /// </summary>
        /// <returns>TypeRegistry handle.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TypeRegistry Get()
        {
            TypeRegistry ret = new TypeRegistry(Interop.TypeRegistry.TypeRegistry_Get(), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Allows the creation of an empty typeRegistry handle.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeRegistry() : this(Interop.TypeRegistry.new_TypeRegistry__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal TypeRegistry(TypeRegistry handle) : this(Interop.TypeRegistry.new_TypeRegistry__SWIG_1(TypeRegistry.getCPtr(handle)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal TypeRegistry Assign(TypeRegistry rhs)
        {
            TypeRegistry ret = new TypeRegistry(Interop.TypeRegistry.TypeRegistry_Assign(swigCPtr, TypeRegistry.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets TypeInfo for a registered type.
        /// </summary>
        /// <param name="uniqueTypeName">A unique type name.</param>
        /// <returns>TypeInfo if the type exists, otherwise an empty handle.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.TypeInfo GetTypeInfo(string uniqueTypeName)
        {
            Tizen.NUI.TypeInfo ret = new Tizen.NUI.TypeInfo(Interop.TypeRegistry.TypeRegistry_GetTypeInfo__SWIG_0(swigCPtr, uniqueTypeName), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Tizen.NUI.TypeInfo GetTypeInfo(SWIGTYPE_p_std__type_info registerType)
        {
            Tizen.NUI.TypeInfo ret = new Tizen.NUI.TypeInfo(Interop.TypeRegistry.TypeRegistry_GetTypeInfo__SWIG_1(swigCPtr, SWIGTYPE_p_std__type_info.getCPtr(registerType)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets type name count.
        /// </summary>
        /// <returns>The counte.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetTypeNameCount()
        {
            uint ret = Interop.TypeRegistry.TypeRegistry_GetTypeNameCount(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets type names by index.
        /// </summary>
        /// <param name="index">The index to get the type name.</param>
        /// <returns>The type name or an empty string when index is not valid.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetTypeName(uint index)
        {
            string ret = Interop.TypeRegistry.TypeRegistry_GetTypeName(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}

