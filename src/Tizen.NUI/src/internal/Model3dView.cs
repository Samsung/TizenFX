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

        internal Model3dView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Model3DView.Model3dViewUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Model3dView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Model3DView.DeleteModel3dView(swigCPtr);
        }

        internal new class Property
        {
            internal static readonly int GeometryUrl = Interop.Model3DView.GeometryUrlGet();
            internal static readonly int MaterialUrl = Interop.Model3DView.MaterialUrlGet();
            internal static readonly int ImagesUrl = Interop.Model3DView.ImagesUrlGet();
            internal static readonly int IlluminationType = Interop.Model3DView.IlluminationTypeGet();
            internal static readonly int Texture0Url = Interop.Model3DView.Texture0UrlGet();
            internal static readonly int Texture1Url = Interop.Model3DView.Texture1UrlGet();
            internal static readonly int Texture2Url = Interop.Model3DView.Texture2UrlGet();
            internal static readonly int LightPosition = Interop.Model3DView.LightPositionGet();
        }

        public Model3dView() : this(Interop.Model3DView.Model3dViewNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Model3dView(string objUrl, string mtlUrl, string imagesUrl) : this(Interop.Model3DView.Model3dViewNew(objUrl, mtlUrl, imagesUrl), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public Model3dView(Model3dView model3dView) : this(Interop.Model3DView.NewModel3dView(Model3dView.getCPtr(model3dView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Model3dView Assign(Model3dView model3dView)
        {
            Model3dView ret = new Model3dView(Interop.Model3DView.Model3dViewAssign(SwigCPtr, Model3dView.getCPtr(model3dView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Model3dView DownCast(BaseHandle handle)
        {
            Model3dView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Model3dView;
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
                GetProperty(Model3dView.Property.GeometryUrl).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.GeometryUrl, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string MaterialUrl
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.MaterialUrl).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.MaterialUrl, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string ImagesUrl
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.ImagesUrl).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.ImagesUrl, new Tizen.NUI.PropertyValue(value));
            }
        }
        public int IlluminationType
        {
            get
            {
                int temp = 0;
                GetProperty(Model3dView.Property.IlluminationType).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.IlluminationType, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string Texture0Url
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.Texture0Url).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.Texture0Url, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string Texture1Url
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.Texture1Url).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.Texture1Url, new Tizen.NUI.PropertyValue(value));
            }
        }
        public string Texture2Url
        {
            get
            {
                string temp;
                GetProperty(Model3dView.Property.Texture2Url).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.Texture2Url, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector3 LightPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(Model3dView.Property.LightPosition).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Model3dView.Property.LightPosition, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
