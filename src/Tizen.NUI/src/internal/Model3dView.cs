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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class Model3dView : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Model3dView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Model3DView.Model3dView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Model3dView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Model3DView.delete_Model3dView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        internal new class Property
        {
            internal static readonly int GEOMETRY_URL = Interop.Model3DView.Model3dView_Property_GEOMETRY_URL_get();
            internal static readonly int MATERIAL_URL = Interop.Model3DView.Model3dView_Property_MATERIAL_URL_get();
            internal static readonly int IMAGES_URL = Interop.Model3DView.Model3dView_Property_IMAGES_URL_get();
            internal static readonly int ILLUMINATION_TYPE = Interop.Model3DView.Model3dView_Property_ILLUMINATION_TYPE_get();
            internal static readonly int TEXTURE0_URL = Interop.Model3DView.Model3dView_Property_TEXTURE0_URL_get();
            internal static readonly int TEXTURE1_URL = Interop.Model3DView.Model3dView_Property_TEXTURE1_URL_get();
            internal static readonly int TEXTURE2_URL = Interop.Model3DView.Model3dView_Property_TEXTURE2_URL_get();
            internal static readonly int LIGHT_POSITION = Interop.Model3DView.Model3dView_Property_LIGHT_POSITION_get();
        }

        public Model3dView() : this(Interop.Model3DView.Model3dView_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Model3dView(string objUrl, string mtlUrl, string imagesUrl) : this(Interop.Model3DView.Model3dView_New__SWIG_1(objUrl, mtlUrl, imagesUrl), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Model3dView(Model3dView model3dView) : this(Interop.Model3DView.new_Model3dView__SWIG_1(Model3dView.getCPtr(model3dView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Model3dView Assign(Model3dView model3dView)
        {
            Model3dView ret = new Model3dView(Interop.Model3DView.Model3dView_Assign(swigCPtr, Model3dView.getCPtr(model3dView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Model3dView DownCast(BaseHandle handle)
        {
            Model3dView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as Model3dView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum IluminationTypeEnum
        {
            DIFFUSE,
            DIFFUSE_WITH_TEXTURE,
            DIFFUSE_WITH_NORMAL_MAP
        }

        public string GeometryUrl
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.GEOMETRY_URL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.GEOMETRY_URL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string MaterialUrl
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.MATERIAL_URL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.MATERIAL_URL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string ImagesUrl
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.IMAGES_URL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.IMAGES_URL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public int IlluminationType
        {
            get
            {
                int temp = 0;
                GetProperty(Model3dView.Property.ILLUMINATION_TYPE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.ILLUMINATION_TYPE, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string Texture0Url
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.TEXTURE0_URL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.TEXTURE0_URL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string Texture1Url
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.TEXTURE1_URL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.TEXTURE1_URL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string Texture2Url
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.TEXTURE2_URL).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.TEXTURE2_URL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector3 LightPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(Model3dView.Property.LIGHT_POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.LIGHT_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
