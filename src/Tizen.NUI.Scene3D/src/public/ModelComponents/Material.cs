/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Class for setting Material properties of 3D models.
    /// </summary>
    /// <remarks>
    /// This Material class is for setting Material properties of 3D models.
    /// This Material supports properties and textures for PBR. Also, Material
    /// can be shared with multiple ModelPrimitives and if the value is modified,
    /// the rendering results of all ModelPrimitives using this Material will be changed.
    /// </remarks>
    /// <example>
    /// <code>
    /// Material material = new Material();
    /// ModelPrimitive modelPrimitive = new ModelPrimitive();
    /// modelPrimitive.Material = material;
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Material : BaseHandle
    {
        internal Material(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create an initialized Material.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Material() : this(Interop.Material.MaterialNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="material">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Material(Material material) : this(Interop.Material.NewMaterial(Material.getCPtr(material)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="material">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal Material Assign(Material material)
        {
            Material ret = new Material(Interop.Material.MaterialAssign(SwigCPtr, Material.getCPtr(material)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The name of the Material.
        /// </summary>
        /// <remarks>
        /// This Name property is for setting the name of Material. The name can be used to identify the Material.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyNameIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyNameIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the base color texture.
        /// </summary>
        /// <remarks>
        /// This texture represents the base color of the material.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BaseColorUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyBaseColorUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyBaseColorUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the base color factor of the material.
        /// </summary>
        /// <remarks>
        /// This factor is multiplied with the base color of the material.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 BaseColorFactor
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyBaseColorFactorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyBaseColorFactorIndexGet());
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the metallic roughness texture.
        /// </summary>
        /// <remarks>
        /// This texture represents the metallicness and roughness of the material.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MetallicRoughnessUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyMetallicRoughnessUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyMetallicRoughnessUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the metallic factor of the material.
        /// </summary>
        /// <remarks>
        /// This factor is multiplied with the metallicness of the material.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MetallicFactor
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyMetallicFactorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyMetallicFactorIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the roughness factor of the material.
        /// </summary>
        /// <remarks>
        /// This factor is multiplied with the roughness of the material.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RoughnessFactor
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyRoughnessFactorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyRoughnessFactorIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the normal texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NormalUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyNormalUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyNormalUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the scale of the normal texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float NormalScale
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyNormalScaleIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyNormalScaleIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the occlusion texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OcclusionUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyOcclusionUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyOcclusionUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the strength of the occlusion texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OcclusionStrength
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyOcclusionStrengthIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyOcclusionStrengthIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the emissive texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EmissiveUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyEmissiveUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyEmissiveUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the emissive factor of the material.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 EmissiveFactor
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyEmissiveFactorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyEmissiveFactorIndexGet());
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the alpha blending mode of the material.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MaterialAlphaModeType AlphaMode
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue((int)value);
                SetProperty(Interop.Material.PropertyAlphaModeIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                int temp = 0;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyAlphaModeIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return (MaterialAlphaModeType)temp;
            }
        }

        /// <summary>
        /// Property for the alpha cutoff value of the material.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float AlphaCutoff
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyAlphaCutOffIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyAlphaCutOffIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the double sided material flag.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DoubleSided
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyDoubleSidedIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                bool temp = false;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyDoubleSidedIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the index of refraction of the material.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Ior
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyIorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyIorIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the specular texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SpecularUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertySpecularUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertySpecularUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }




        /// <summary>
        /// Property for the specular factor of the material.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SpecularFactor
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertySpecularFactorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                float temp = 0.0f;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertySpecularFactorIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the URL of the specular color texture.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SpecularColorUrl
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertySpecularColorUrlIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                string temp;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertySpecularColorUrlIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property for the specular color factor of the material.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 SpecularColorFactor
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertySpecularColorFactorIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertySpecularColorFactorIndexGet());
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Property to define rendering order.
        /// </summary>
        /// <remarks>
        /// Depth index is used to defind rendering order. Basically,
        /// a Renderer that has smaller depth index is rendered earlier.
        /// In the ordinary DALI UI components has 0 as depth index by default.
        /// (For the case of Toolkit::Control, its renderer has depth index
        /// value between [-20, 20] as fallowing the renderer's purpose)
        ///
        /// In the Scene3D cases, the rendering order of each Renderer may need
        /// to be manually defined to match scene developer's intent.
        /// Scene3D::DepthIndex::Ranges could be used to adjust rendering order
        /// between 3D Scene content.
        /// Or it also could be used to manage UI component in 3D Scene independently.
        ///
        /// Changing the depth index only affects the rendering order, and does not
        /// mean that objects drawn later will be drawn on top. To compute final
        /// rendering order, whether the object is opaque or non-opaque takes precedence
        /// over the depth index. Changing the rendering order among translucent objects
        /// has a significant impact on the rendering results.
        ///
        /// The predefined depth index range is definded in <see cref="MaterialDepthIndexRange"/>.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DepthIndex
        {
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.Material.PropertyDepthIndexIndexGet(), temp);
                temp.Dispose();
            }
            get
            {
                int temp = 0;
                Tizen.NUI.PropertyValue pValue = GetProperty(Interop.Material.PropertyDepthIndexIndexGet());
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Sets the texture of the ModelNode object for the specified texture type.
        /// </summary>
        /// <param name="textureType">The TextureType of the texture to set.</param>
        /// <param name="texture">The Texture object to set.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTexture(MaterialTextureType textureType, Texture texture)
        {
            Interop.Material.SetTexture(SwigCPtr, (int)textureType, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the texture of the ModelNode object for the specified texture type.
        /// </summary>
        /// <param name="textureType">The TextureType of the texture to get.</param>
        /// <returns>The Texture object of the ModelNode object for the specified texture type.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Texture GetTexture(MaterialTextureType textureType)
        {
            IntPtr cPtr = Interop.Material.GetTexture(SwigCPtr, (int)textureType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Texture ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Texture;
            return ret;
        }

        /// <summary>
        /// Sets the sampler of the ModelNode object for the specified texture type.
        /// </summary>
        /// <param name="textureType">The TextureType of the sampler to set.</param>
        /// <param name="sampler">The Sampler object to set.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSampler(MaterialTextureType textureType, Sampler sampler)
        {
            Interop.Material.SetSampler(SwigCPtr, (int)textureType, Sampler.getCPtr(sampler));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the sampler of the ModelNode object for the specified texture type.
        /// </summary>
        /// <param name="textureType">The TextureType of the sampler to get.</param>
        /// <returns>The Sampler object of the ModelNode object for the specified texture type.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Sampler GetSampler(MaterialTextureType textureType)
        {
            IntPtr cPtr = Interop.Material.GetSampler(SwigCPtr, (int)textureType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Sampler ret = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Sampler;
            return ret;
        }

        /// <summary>
        /// Sets the value of an existing property.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <param name="propertyValue">The new value of the property.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetProperty(int index, PropertyValue propertyValue)
        {
            global::System.Runtime.InteropServices.HandleRef handle = SwigCPtr;
            if (handle.Handle == global::System.IntPtr.Zero)
            {
                throw new global::System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            Interop.Material.SetProperty(handle, index, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves a property value.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>The property value.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        private PropertyValue GetProperty(int index)
        {
            global::System.Runtime.InteropServices.HandleRef handle = SwigCPtr;
            if (handle.Handle == global::System.IntPtr.Zero)
            {
                throw new global::System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            PropertyValue ret = new PropertyValue(Interop.Material.GetProperty(handle, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Material.DeleteMaterial(swigCPtr);
        }
    }
}
