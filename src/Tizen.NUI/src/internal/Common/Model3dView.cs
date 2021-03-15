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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class Model3dView : View
    {
        internal Model3dView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
                string retVal = "";
                PropertyValue geometry = GetProperty(Model3dView.Property.GeometryUrl);
                geometry?.Get(out retVal);
                geometry?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.GeometryUrl, setVal);
                setVal?.Dispose();
            }
        }
        public string MaterialUrl
        {
            get
            {
                string retVal = "";
                PropertyValue material = GetProperty(Model3dView.Property.MaterialUrl);
                material?.Get(out retVal);
                material?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.MaterialUrl, setVal);
                setVal?.Dispose();
            }
        }
        public string ImagesUrl
        {
            get
            {
                string retVal = "";
                PropertyValue images = GetProperty(Model3dView.Property.ImagesUrl);
                images?.Get(out retVal);
                images?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.ImagesUrl, setVal);
                setVal?.Dispose();
            }
        }
        public int IlluminationType
        {
            get
            {
                int retVal = 0;
                PropertyValue illumination = GetProperty(Model3dView.Property.IlluminationType);
                illumination?.Get(out retVal);
                illumination?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.IlluminationType, setVal);
                setVal?.Dispose();
            }
        }
        public string Texture0Url
        {
            get
            {
                string retVal = "";
                PropertyValue texture0 = GetProperty(Model3dView.Property.Texture0Url);
                texture0?.Get(out retVal);
                texture0?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.Texture0Url, setVal);
                setVal?.Dispose();
            }
        }
        public string Texture1Url
        {
            get
            {
                string retVal = "";
                PropertyValue texture1 = GetProperty(Model3dView.Property.Texture1Url);
                texture1?.Get(out retVal);
                texture1?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.Texture1Url, setVal);
                setVal?.Dispose();
            }
        }
        public string Texture2Url
        {
            get
            {
                string retVal = "";
                PropertyValue texture2 = GetProperty(Model3dView.Property.Texture2Url);
                texture2?.Get(out retVal);
                texture2?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.Texture2Url, setVal);
                setVal?.Dispose();
            }
        }
        public Vector3 LightPosition
        {
            get
            {
                Vector3 retVal = new Vector3(0.0f, 0.0f, 0.0f);
                PropertyValue lightPos = GetProperty(Model3dView.Property.LightPosition);
                lightPos?.Get(retVal);
                lightPos?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Model3dView.Property.LightPosition, setVal);
                setVal?.Dispose();
            }
        }
    }
}
