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

using System.ComponentModel;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// MaterialTextureType is enum for Material's Texture type
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MaterialTextureType
    {
        /// <summary>
        /// Base Color Texture Property.
        /// </summary>
        /// <remarks>
        /// This texture represents the base color of the material. In most cases, this will be the diffuse color of the material.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        BaseColor,

        /// <summary>
        /// Metallic Roughness Texture Property.
        /// </summary>
        /// <remarks>
        /// This texture represents the metallicness and roughness of the material. This texture can be used to make the material look more metallic or rough.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MetallicRoughness,

        /// <summary>
        /// Normal Texture Property.
        /// </summary>
        /// <remarks>
        /// This texture represents the surface of the material. This texture can be used to make the surface of the material look smooth or rough.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Normal,

        /// <summary>
        /// Occlusion Texture Property.
        /// </summary>
        /// <remarks>
        /// This texture represents the depth of the material. This texture can be used to make the material look more three-dimensional.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Occlusion,

        /// <summary>
        /// Emissive Texture Property.
        /// </summary> 
        /// <remarks> 
        /// This texture makes the material look like it's emitting light. This texture can be used to make the material look like it's glowing.
        /// </remarks> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        Emissive,

        /// <summary>
        /// Specular Texture Property.
        /// </summary>
        /// <remarks>
        /// This texture represents the specular reflection of the material. This texture can be used to make the material look more reflective.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Specular,

        /// <summary>
        /// Specular Color Texture Property.
        ///</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SpecularColor,
    }
}
