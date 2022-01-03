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

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ModelView : View
    {
        internal ModelView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ModelView.DeleteModelView(swigCPtr);
        }

        internal new class Property
        {
            internal static readonly int GeometryUrl = Interop.ModelView.GeometryUrlGet();
            internal static readonly int MaterialUrl = Interop.ModelView.MaterialUrlGet();
            internal static readonly int ImagesUrl = Interop.ModelView.ImagesUrlGet();
            internal static readonly int IlluminationType = Interop.ModelView.IlluminationTypeGet();
            internal static readonly int Texture0Url = Interop.ModelView.Texture0UrlGet();
            internal static readonly int Texture1Url = Interop.ModelView.Texture1UrlGet();
            internal static readonly int Texture2Url = Interop.ModelView.Texture2UrlGet();
            internal static readonly int LightPosition = Interop.ModelView.LightPositionGet();
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView() : this(Interop.ModelView.ModelViewNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView(string objUrl, string mtlUrl, string imagesUrl) : this(Interop.ModelView.ModelViewNew(objUrl, mtlUrl, imagesUrl), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView(ModelView ModelView) : this(Interop.ModelView.NewModelView(ModelView.getCPtr(ModelView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelView Assign(ModelView ModelView)
        {
            ModelView ret = new ModelView(Interop.ModelView.ModelViewAssign(SwigCPtr, ModelView.getCPtr(ModelView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum IluminationTypeEnum
        {
            Diffuse,
            DiffuseWithTexture,
            DiffuseWithNormalMap
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GeometryUrl
        {
            get
            {
                string retVal = "";
                PropertyValue geometry = GetProperty(ModelView.Property.GeometryUrl);
                geometry?.Get(out retVal);
                geometry?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.GeometryUrl, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MaterialUrl
        {
            get
            {
                string retVal = "";
                PropertyValue material = GetProperty(ModelView.Property.MaterialUrl);
                material?.Get(out retVal);
                material?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.MaterialUrl, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ImagesUrl
        {
            get
            {
                string retVal = "";
                PropertyValue images = GetProperty(ModelView.Property.ImagesUrl);
                images?.Get(out retVal);
                images?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.ImagesUrl, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IlluminationType
        {
            get
            {
                int retVal = 0;
                PropertyValue illumination = GetProperty(ModelView.Property.IlluminationType);
                illumination?.Get(out retVal);
                illumination?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.IlluminationType, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Texture0Url
        {
            get
            {
                string retVal = "";
                PropertyValue texture0 = GetProperty(ModelView.Property.Texture0Url);
                texture0?.Get(out retVal);
                texture0?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.Texture0Url, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Texture1Url
        {
            get
            {
                string retVal = "";
                PropertyValue texture1 = GetProperty(ModelView.Property.Texture1Url);
                texture1?.Get(out retVal);
                texture1?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.Texture1Url, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Texture2Url
        {
            get
            {
                string retVal = "";
                PropertyValue texture2 = GetProperty(ModelView.Property.Texture2Url);
                texture2?.Get(out retVal);
                texture2?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.Texture2Url, setVal);
                setVal?.Dispose();
            }
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 LightPosition
        {
            get
            {
                Vector3 retVal = new Vector3(0.0f, 0.0f, 0.0f);
                PropertyValue lightPos = GetProperty(ModelView.Property.LightPosition);
                lightPos?.Get(retVal);
                lightPos?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(ModelView.Property.LightPosition, setVal);
                setVal?.Dispose();
            }
        }
    }
}
