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

namespace Tizen.NUI.Scene3D
{
    internal static partial class Interop
    {
        internal static partial class Material
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_New_SWIG_0")]
            public static extern global::System.IntPtr MaterialNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Material_SWIG_1")]
            public static extern global::System.IntPtr NewMaterial(global::System.Runtime.InteropServices.HandleRef material);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_Material")]
            public static extern void DeleteMaterial(global::System.Runtime.InteropServices.HandleRef material);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_Assign")]
            public static extern global::System.IntPtr MaterialAssign(global::System.Runtime.InteropServices.HandleRef material, global::System.Runtime.InteropServices.HandleRef sourceMaterial);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_NAME_get")]
            public static extern int PropertyNameIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_BASE_COLOR_URL_get")]
            public static extern int PropertyBaseColorUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_BASE_COLOR_FACTOR_get")]
            public static extern int PropertyBaseColorFactorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_METALLIC_ROUGHNESS_URL_get")]
            public static extern int PropertyMetallicRoughnessUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_METALLIC_FACTOR_get")]
            public static extern int PropertyMetallicFactorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_ROUGHNESS_FACTOR_get")]
            public static extern int PropertyRoughnessFactorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_NORMAL_URL_get")]
            public static extern int PropertyNormalUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_NORMAL_SCALE_get")]
            public static extern int PropertyNormalScaleIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_OCCLUSION_URL_get")]
            public static extern int PropertyOcclusionUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_OCCLUSION_STRENGTH_get")]
            public static extern int PropertyOcclusionStrengthIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_EMISSIVE_URL_get")]
            public static extern int PropertyEmissiveUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_EMISSIVE_FACTOR_get")]
            public static extern int PropertyEmissiveFactorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_ALPHA_MODE_get")]
            public static extern int PropertyAlphaModeIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_ALPHA_CUTOFF_get")]
            public static extern int PropertyAlphaCutOffIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_DOUBLE_SIDED_get")]
            public static extern int PropertyDoubleSidedIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_IOR_get")]
            public static extern int PropertyIorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_SPECULAR_URL_get")]
            public static extern int PropertySpecularUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_SPECULAR_FACTOR_get")]
            public static extern int PropertySpecularFactorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_SPECULAR_COLOR_URL_get")]
            public static extern int PropertySpecularColorUrlIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_SPECULAR_COLOR_FACTOR_get")]
            public static extern int PropertySpecularColorFactorIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_property_DEPTH_INDEX_get")]
            public static extern int PropertyDepthIndexIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_SetProperty")]
            public static extern void SetProperty(global::System.Runtime.InteropServices.HandleRef model, int index, global::System.Runtime.InteropServices.HandleRef propertyValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_GetProperty")]
            public static extern global::System.IntPtr GetProperty(global::System.Runtime.InteropServices.HandleRef model, int index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_SetTexture")]
            public static extern void SetTexture(global::System.Runtime.InteropServices.HandleRef model, int textureType, global::System.Runtime.InteropServices.HandleRef texture);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_GetTexture")]
            public static extern global::System.IntPtr GetTexture(global::System.Runtime.InteropServices.HandleRef model, int textureType);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_SetSampler")]
            public static extern void SetSampler(global::System.Runtime.InteropServices.HandleRef model, int textureType, global::System.Runtime.InteropServices.HandleRef sampler);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Material_GetSampler")]
            public static extern global::System.IntPtr GetSampler(global::System.Runtime.InteropServices.HandleRef model, int textureType);
        }
    }
}
