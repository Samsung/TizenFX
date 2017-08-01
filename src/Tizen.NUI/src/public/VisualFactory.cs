/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
    /// VisualFactory is a singleton object that provides and shares visuals between views
    /// </summary>
    public class VisualFactory : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal VisualFactory(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.VisualFactory_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VisualFactory obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
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
                    NDalicPINVOKE.delete_VisualFactory(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        /// <summary>
        /// Create or retrieve VisualFactory singleton.
        /// </summary>
        /// <returns>A handle to the VisualFactory control.</returns>
        private static VisualFactory Get()
        {
            VisualFactory ret = new VisualFactory(NDalicPINVOKE.VisualFactory_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VisualFactory() : this(NDalicPINVOKE.new_VisualFactory__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// Request the visual
        /// </summary>
        /// <param name="propertyMap">The map contains the properties required by the visual. The content of the map determines the type of visual that will be returned.</param>
        /// <returns>The handle to the created visual</returns>
        public VisualBase CreateVisual(PropertyMap propertyMap)
        {
            VisualBase ret = new VisualBase(NDalicPINVOKE.VisualFactory_CreateVisual__SWIG_0(swigCPtr, PropertyMap.getCPtr(propertyMap)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VisualBase CreateVisual(Image image)
        {
            VisualBase ret = new VisualBase(NDalicPINVOKE.VisualFactory_CreateVisual__SWIG_1(swigCPtr, Image.getCPtr(image)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static readonly VisualFactory instance = VisualFactory.Get();

        /// <summary>
        /// retrieve VisualFactory singleton.
        /// </summary>
        public static VisualFactory Instance
        {
            get
            {
                return instance;
            }
        }

    }

}
