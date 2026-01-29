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
        private static readonly TypeRegistry instance = TypeRegistry.GetInternal();
        internal TypeRegistry(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal TypeRegistry(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TypeRegistry.DeleteTypeRegistry(swigCPtr);
        }

        /// <summary>
        /// Gets the singleton of the TypeRegistry object.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TypeRegistry Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets Type Registry handle.
        /// </summary>
        /// <returns>TypeRegistry handle.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [global::System.Obsolete("Do not use this, that will be deprecated. Use TypeRegistry.Instance instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TypeRegistry Get()
        {
            return TypeRegistry.Instance;
        }

        private static TypeRegistry GetInternal()
        {
            global::System.IntPtr cPtr = Interop.TypeRegistry.Get();

            if(cPtr == global::System.IntPtr.Zero)
            {
                NUILog.ErrorBacktrace("TypeRegistry.Instance called before Application created, or after Application terminated!");
            }

            TypeRegistry ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as TypeRegistry;
            if (ret != null)
            {
                NUILog.ErrorBacktrace("TypeRegistry.GetInternal() Should be called only one time!");
                object dummyObect = new object();

                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(dummyObect, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new TypeRegistry(cPtr, true);
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
            else
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Allows the creation of an empty typeRegistry handle.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeRegistry() : this(Interop.TypeRegistry.NewTypeRegistry(), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TypeRegistry(TypeRegistry handle) : this(Interop.TypeRegistry.NewTypeRegistry(TypeRegistry.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TypeRegistry Assign(TypeRegistry rhs)
        {
            TypeRegistry ret = new TypeRegistry(Interop.TypeRegistry.Assign(SwigCPtr, TypeRegistry.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            global::System.IntPtr cPtr = Interop.TypeRegistry.GetTypeInfo(SwigCPtr, uniqueTypeName);

            Tizen.NUI.TypeInfo ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Tizen.NUI.TypeInfo;
            if (ret != null)
            {
                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new Tizen.NUI.TypeInfo(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Gets type name count.
        /// </summary>
        /// <returns>The count.</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetTypeNameCount()
        {
            uint ret = Interop.TypeRegistry.GetTypeNameCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            string ret = Interop.TypeRegistry.GetTypeName(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
