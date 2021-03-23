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

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for Pixel formats.<br />
    /// Pixel format, default color depth is RGBA 32 bit with alpha.
    /// </summary>
    /// /// <since_tizen> 3 </since_tizen>
    public enum PixelFormat
    {
        /// <summary>
        ///  Used to represent an unsupported format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        INVALID = 0,
        /// <summary>
        /// color depth 8-bit, alpha.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        A8 = 1,
        /// <summary>
        /// color depth 8-bit, luminance
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        L8,
        /// <summary>
        /// color depth 16-bit, luminance with 8 bit alpha
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        LA88,
        /// <summary>
        ///  color depth 16 bit, 5-6-5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RGB565,
        /// <summary>
        /// color depth 16 bit, 5-6-5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BGR565,
        /// <summary>
        /// color depth 16 bit with alpha, 4-4-4-4
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RGBA4444,
        /// <summary>
        /// color depth 16 bit with alpha, 4-4-4-4
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BGRA4444,
        /// <summary>
        /// color depth 16 bit with alpha, 5-5-5-1
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RGBA5551,
        /// <summary>
        /// color depth 16 bit with alpha, 5-5-5-1
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BGRA5551,
        /// <summary>
        /// color depth 24 bit, 8-8-8
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RGB888,
        /// <summary>
        /// color depth 32 bit, alpha is reserved but not used, 8-8-8-8#
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RGB8888,
        /// <summary>
        /// color depth 32 bit, alpha is reserved but not used, 8-8-8-8#
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BGR8888,
        /// <summary>
        /// color depth 32 bit with alpha, 8-8-8-8
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        RGBA8888,
        /// <summary>
        /// color depth 32 bit with alpha, 8-8-8-8
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        BGRA8888,
        /// <summary>
        /// ETC2 / EAC single-channel, unsigned
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_R11_EAC,
        /// <summary>
        /// ETC2 / EAC single-channel, signed
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SIGNED_R11_EAC,
        /// <summary>
        /// ETC2 / EAC dual-channel, unsigned
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RG11_EAC,
        /// <summary>
        /// ETC2 / EAC dual-channel, signed
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SIGNED_RG11_EAC,
        /// <summary>
        /// ETC2 / EAC RGB
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGB8_ETC2,
        /// <summary>
        /// ETC2 / EAC RGB using sRGB colourspace.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ETC2,
        /// <summary>
        /// ETC2 / EAC RGB with single bit per pixel alpha mask.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2,
        /// <summary>
        /// ETC2 / EAC RGB using sRGB colourspace, with single bit per pixel alpha mask.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2,
        /// <summary>
        /// ETC2 / EAC RGB plus separate alpha channel.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA8_ETC2_EAC,
        /// <summary>
        /// ETC2 / EAC RGB using sRGB colourspace, plus separate alpha channel.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ETC2_EAC,
        /// <summary>
        /// ETC1 RGB as defined by GLES 2 extension OES_compressed_ETC1_RGB8_texture: http://www.khronos.org/registry/gles/extensions/OES/OES_compressed_ETC1_RGB8_texture.txt
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGB8_ETC1,
        /// <summary>
        /// PowerVR 4bpp RGB format (v1) as defined by extension IMG_texture_compression_pvrtc: http://www.khronos.org/registry/gles/extensions/IMG/IMG_texture_compression_pvrtc.txt
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGB_PVRTC_4BPPV1,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 4x4 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_4x4_KHR,
        /// <summary>
        ///  ASTC Non-linear (gamma-corrected) color space with a 5x4 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_5x4_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 5x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_5x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 6x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_6x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 6x6 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_6x6_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 8x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_8x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 8x6 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_8x6_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 8x8 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_8x8_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_10x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x6 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_10x6_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x8 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_10x8_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x10 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_10x10_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 12x10 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_12x10_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 12x12 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_RGBA_ASTC_12x12_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 4x4 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_4x4_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 5x4 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_5x4_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 5x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_5x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 6x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_6x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 6x6 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_6x6_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 8x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_8x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 8x6 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_8x6_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 8x8 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_8x8_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x5 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_10x5_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x6 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_10x6_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x8 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_10x8_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 10x10 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_10x10_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 12x10 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_12x10_KHR,
        /// <summary>
        /// ASTC Non-linear (gamma-corrected) color space with a 12x12 block-size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        COMPRESSED_SRGB8_ALPHA8_ASTC_12x12_KHR
    }
}
