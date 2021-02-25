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
using Tizen.NUI;
using Tizen.NUI.Binding;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal static class VisualExtension
    {
        public static Dictionary<string, int> KeyDictionary = new Dictionary<string, int>()
        {
            // Visual.Property
            { "Visual.Property.Type", Visual.Property.Type },
            { "Visual.Property.Shader", Visual.Property.Shader },
            { "Visual.Property.Transform", Visual.Property.Transform },
            { "Visual.Property.PremultipliedAlpha", Visual.Property.PremultipliedAlpha },
            { "Visual.Property.MixColor", Visual.Property.MixColor },
            { "Visual.Property.Opacity", Visual.Property.Opacity },
            // ShaderProperty
            { "Visual.ShaderProperty.VertexShader", Visual.ShaderProperty.VertexShader },
            { "Visual.ShaderProperty.FragmentShader", Visual.ShaderProperty.FragmentShader },
            { "Visual.ShaderProperty.ShaderSubdivideGridX", Visual.ShaderProperty.ShaderSubdivideGridX },
            { "Visual.ShaderProperty.ShaderSubdivideGridY", Visual.ShaderProperty.ShaderSubdivideGridY },
            { "Visual.ShaderProperty.ShaderHints", Visual.ShaderProperty.ShaderHints },
            // BorderVisualProperty
            { "BorderVisualProperty.Color", BorderVisualProperty.Color },
            { "BorderVisualProperty.Size", BorderVisualProperty.Size },
            { "BorderVisualProperty.AntiAliasing", BorderVisualProperty.AntiAliasing },
            // ColorVisualProperty
            { "ColorVisualProperty.MixColor", ColorVisualProperty.MixColor},
            // GradientVisualProperty
            { "GradientVisualProperty.StartPosition", GradientVisualProperty.StartPosition },
            { "GradientVisualProperty.EndPosition", GradientVisualProperty.EndPosition },
            { "GradientVisualProperty.Center", GradientVisualProperty.Center },
            { "GradientVisualProperty.Radius", GradientVisualProperty.Radius },
            { "GradientVisualProperty.StopOffset", GradientVisualProperty.StopOffset },
            { "GradientVisualProperty.StopColor", GradientVisualProperty.StopColor },
            { "GradientVisualProperty.Units", GradientVisualProperty.Units },
            { "GradientVisualProperty.SpreadMethod", GradientVisualProperty.SpreadMethod },
            // ImageVisualProperty
            { "ImageVisualProperty.URL", ImageVisualProperty.URL },
            { "ImageVisualProperty.AlphaMaskURL", ImageVisualProperty.AlphaMaskURL },
            { "ImageVisualProperty.FittingMode", ImageVisualProperty.FittingMode },
            { "ImageVisualProperty.SamplingMode", ImageVisualProperty.SamplingMode },
            { "ImageVisualProperty.DesiredWidth", ImageVisualProperty.DesiredWidth },
            { "ImageVisualProperty.DesiredHeight", ImageVisualProperty.DesiredHeight },
            { "ImageVisualProperty.SynchronousLoading", ImageVisualProperty.SynchronousLoading },
            { "ImageVisualProperty.BorderOnly", ImageVisualProperty.BorderOnly },
            { "ImageVisualProperty.PixelArea", ImageVisualProperty.PixelArea },
            { "ImageVisualProperty.WrapModeU", ImageVisualProperty.WrapModeU },
            { "ImageVisualProperty.WrapModeV", ImageVisualProperty.WrapModeV },
            { "ImageVisualProperty.Border", ImageVisualProperty.Border },
            { "ImageVisualProperty.MaskContentScale", ImageVisualProperty.MaskContentScale },
            { "ImageVisualProperty.CropToMask", ImageVisualProperty.CropToMask },
            { "ImageVisualProperty.BatchSize", ImageVisualProperty.BatchSize },
            { "ImageVisualProperty.CacheSize", ImageVisualProperty.CacheSize },
            { "ImageVisualProperty.FrameDelay", ImageVisualProperty.FrameDelay },
            { "ImageVisualProperty.LoopCount", ImageVisualProperty.LoopCount },
            { "ImageVisualProperty.ReleasePolicy", ImageVisualProperty.ReleasePolicy },
            { "ImageVisualProperty.LoadPolicy", ImageVisualProperty.LoadPolicy },
            { "ImageVisualProperty.OrientationCorrection", ImageVisualProperty.OrientationCorrection },
            { "ImageVisualProperty.AuxiliaryImageURL", ImageVisualProperty.AuxiliaryImageURL },
            { "ImageVisualProperty.AuxiliaryImageAlpha", ImageVisualProperty.AuxiliaryImageAlpha },
            // MeshVisualProperty
            { "MeshVisualProperty.ObjectURL", MeshVisualProperty.ObjectURL },
            { "MeshVisualProperty.MaterialtURL", MeshVisualProperty.MaterialtURL },
            { "MeshVisualProperty.TexturesPath", MeshVisualProperty.TexturesPath },
            { "MeshVisualProperty.ShadingMode", MeshVisualProperty.ShadingMode },
            { "MeshVisualProperty.UseMipmapping", MeshVisualProperty.UseMipmapping },
            { "MeshVisualProperty.UseSoftNormals", MeshVisualProperty.UseSoftNormals },
            { "MeshVisualProperty.LightPosition", MeshVisualProperty.LightPosition },
            // PrimitiveVisualProperty
            { "PrimitiveVisualProperty.Shape", PrimitiveVisualProperty.Shape },
            { "PrimitiveVisualProperty.MixColor", PrimitiveVisualProperty.MixColor },
            { "PrimitiveVisualProperty.Slices", PrimitiveVisualProperty.Slices },
            { "PrimitiveVisualProperty.Stacks", PrimitiveVisualProperty.Stacks },
            { "PrimitiveVisualProperty.ScaleTopRadius", PrimitiveVisualProperty.ScaleTopRadius },
            { "PrimitiveVisualProperty.ScaleBottomRadius", PrimitiveVisualProperty.ScaleBottomRadius },
            { "PrimitiveVisualProperty.ScaleHeight", PrimitiveVisualProperty.ScaleHeight },
            { "PrimitiveVisualProperty.ScaleRadius", PrimitiveVisualProperty.ScaleRadius },
            { "PrimitiveVisualProperty.ScaleDimensions", PrimitiveVisualProperty.ScaleDimensions },
            { "PrimitiveVisualProperty.BevelPercentage", PrimitiveVisualProperty.BevelPercentage },
            { "PrimitiveVisualProperty.BevelSmoothness", PrimitiveVisualProperty.BevelSmoothness },
            { "PrimitiveVisualProperty.LightPosition", PrimitiveVisualProperty.LightPosition },
            // TextVisualProperty
            { "TextVisualProperty.Text", TextVisualProperty.Text },
            { "TextVisualProperty.FontFamily", TextVisualProperty.FontFamily },
            { "TextVisualProperty.FontStyle", TextVisualProperty.FontStyle },
            { "TextVisualProperty.PointSize", TextVisualProperty.PointSize },
            { "TextVisualProperty.MultiLine", TextVisualProperty.MultiLine },
            { "TextVisualProperty.HorizontalAlignment", TextVisualProperty.HorizontalAlignment },
            { "TextVisualProperty.VerticalAlignment", TextVisualProperty.VerticalAlignment },
            { "TextVisualProperty.TextColor", TextVisualProperty.TextColor },
            { "TextVisualProperty.EnableMarkup", TextVisualProperty.EnableMarkup },
            // NpatchImageVisualProperty
            { "NpatchImageVisualProperty.URL", NpatchImageVisualProperty.URL },
            { "NpatchImageVisualProperty.FittingMode", NpatchImageVisualProperty.FittingMode },
            { "NpatchImageVisualProperty.SamplingMode", NpatchImageVisualProperty.SamplingMode },
            { "NpatchImageVisualProperty.DesiredWidth", NpatchImageVisualProperty.DesiredWidth },
            { "NpatchImageVisualProperty.DesiredHeight", NpatchImageVisualProperty.DesiredHeight },
            { "NpatchImageVisualProperty.SynchronousLoading", NpatchImageVisualProperty.SynchronousLoading },
            { "NpatchImageVisualProperty.BorderOnly", NpatchImageVisualProperty.BorderOnly },
            { "NpatchImageVisualProperty.PixelArea", NpatchImageVisualProperty.PixelArea },
            { "NpatchImageVisualProperty.WrapModeU", NpatchImageVisualProperty.WrapModeU },
            { "NpatchImageVisualProperty.WrapModeV", NpatchImageVisualProperty.WrapModeV },
            { "NpatchImageVisualProperty.Border", NpatchImageVisualProperty.Border },
            // HiddenInputProperty
            { "HiddenInputProperty.Mode", HiddenInputProperty.Mode },
            { "HiddenInputProperty.SubstituteCharacter", HiddenInputProperty.SubstituteCharacter },
            { "HiddenInputProperty.SubstituteCount", HiddenInputProperty.SubstituteCount },
            { "HiddenInputProperty.ShowLastCharacterDuration", HiddenInputProperty.ShowLastCharacterDuration },
        };
    }

    internal enum VisualTypeExtension
    {
        Border = Visual.Type.Border,
        Color = Visual.Type.Color,
        Gradient = Visual.Type.Gradient,
        Image = Visual.Type.Image,
        Mesh = Visual.Type.Mesh,
        Primitive = Visual.Type.Primitive,
        Wireframe = Visual.Type.Wireframe,
        Text = Visual.Type.Text,
        NPatch = Visual.Type.NPatch,
        SVG = Visual.Type.SVG,
        AnimatedImage = Visual.Type.AnimatedImage
    }

    internal enum VisualAlignTypeExtension
    {
        TopBegin = Visual.AlignType.TopBegin,
        TopCenter = Visual.AlignType.TopCenter,
        TopEnd = Visual.AlignType.TopEnd,
        CenterBegin = Visual.AlignType.CenterBegin,
        Center = Visual.AlignType.Center,
        CenterEnd = Visual.AlignType.CenterEnd,
        BottomBegin = Visual.AlignType.BottomBegin,
        BottomCenter = Visual.AlignType.BottomCenter,
        BottomEnd = Visual.AlignType.BottomEnd
    }
}
