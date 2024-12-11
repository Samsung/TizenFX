/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// FadeTransitionItem is an object to set Fade transition of a View that will appear or disappear.
    /// FadeTransitionItem object is required to be added to the TransitionSet to play.
    /// </summary>
    internal class RenderableUtility
    {
        public enum BlendEquationType
        {
            /// <summary>
            /// The source and destination colors are added to each other.
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Add = 0x8006,

            /// <summary>
            /// Use minimum value of the source and the destination.
            /// </summary>
            /// <remark>
            /// It will be supported only if OpenGL es 3.0  or higher version using.
            /// </remark>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Min = 0x8007,

            /// <summary>
            /// Use maximum value of the source and the destination.
            /// </summary>
            /// <remark>
            /// It will be supported only if OpenGL es 3.0  or higher version using.
            /// </remark>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Max = 0x8008,

            /// <summary>
            /// Subtracts the destination from the source.
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Subtract = 0x800A,

            /// <summary>
            /// Subtracts the source from the destination.
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ReverseSubtract = 0x800B,

            //Advanced Blend Equation
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Multiply = 0x9294,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Screen = 0x9295,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Overlay = 0x9296,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Darken = 0x9297,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Lighten = 0x9298,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ColorDodge = 0x9299,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ColorBurn = 0x929A,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            HardLight = 0x929B,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            SoftLight = 0x929C,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Difference = 0x929E,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Exclusion = 0x92A0,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Hue = 0x92AD,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Saturation = 0x92AE,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Color = 0x92AF,
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Luminosity = 0x92B0,
        }

        public static RenderableUtility.BlendEquationType ConvertBlendEquationTypeToUtilityProperty(Tizen.NUI.BlendEquation blendEquationType)
        {
            switch (blendEquationType)
            {
                case BlendEquation.Add:
                    {
                        return RenderableUtility.BlendEquationType.Add;
                    }
                case BlendEquation.Min:
                    {
                        return RenderableUtility.BlendEquationType.Min;
                    }
                case BlendEquation.Max:
                    {
                        return RenderableUtility.BlendEquationType.Max;
                    }
                case BlendEquation.Subtract:
                    {
                        return RenderableUtility.BlendEquationType.Subtract;
                    }
                case BlendEquation.ReverseSubtract:
                    {
                        return RenderableUtility.BlendEquationType.ReverseSubtract;
                    }
                case BlendEquation.Multiply:
                    {
                        return RenderableUtility.BlendEquationType.Multiply;
                    }
                case BlendEquation.Screen:
                    {
                        return RenderableUtility.BlendEquationType.Screen;
                    }
                case BlendEquation.Overlay:
                    {
                        return RenderableUtility.BlendEquationType.Overlay;
                    }
                case BlendEquation.Darken:
                    {
                        return RenderableUtility.BlendEquationType.Darken;
                    }
                case BlendEquation.Lighten:
                    {
                        return RenderableUtility.BlendEquationType.Lighten;
                    }
                case BlendEquation.ColorDodge:
                    {
                        return RenderableUtility.BlendEquationType.ColorDodge;
                    }
                case BlendEquation.ColorBurn:
                    {
                        return RenderableUtility.BlendEquationType.ColorBurn;
                    }
                case BlendEquation.HardLight:
                    {
                        return RenderableUtility.BlendEquationType.HardLight;
                    }
                case BlendEquation.SoftLight:
                    {
                        return RenderableUtility.BlendEquationType.SoftLight;
                    }
                case BlendEquation.Difference:
                    {
                        return RenderableUtility.BlendEquationType.Difference;
                    }
                case BlendEquation.Exclusion:
                    {
                        return RenderableUtility.BlendEquationType.Exclusion;
                    }
                case BlendEquation.Hue:
                    {
                        return RenderableUtility.BlendEquationType.Hue;
                    }
                case BlendEquation.Saturation:
                    {
                        return RenderableUtility.BlendEquationType.Saturation;
                    }
                case BlendEquation.Color:
                    {
                        return RenderableUtility.BlendEquationType.Color;
                    }
                case BlendEquation.Luminosity:
                    {
                        return RenderableUtility.BlendEquationType.Luminosity;
                    }
            }
            return RenderableUtility.BlendEquationType.Add;
        }

        public static Tizen.NUI.BlendEquation ConvertBlendEquationTypeFromUtilityProperty(RenderableUtility.BlendEquationType blendEquationType)
        {
            switch (blendEquationType)
            {
                case RenderableUtility.BlendEquationType.Add:
                    {
                        return BlendEquation.Add;
                    }
                case RenderableUtility.BlendEquationType.Min:
                    {
                        return BlendEquation.Min;
                    }
                case RenderableUtility.BlendEquationType.Max:
                    {
                        return BlendEquation.Max;
                    }
                case RenderableUtility.BlendEquationType.Subtract:
                    {
                        return BlendEquation.Subtract;
                    }
                case RenderableUtility.BlendEquationType.ReverseSubtract:
                    {
                        return BlendEquation.ReverseSubtract;
                    }
                case RenderableUtility.BlendEquationType.Multiply:
                    {
                        return BlendEquation.Multiply;
                    }
                case RenderableUtility.BlendEquationType.Screen:
                    {
                        return BlendEquation.Screen;
                    }
                case RenderableUtility.BlendEquationType.Overlay:
                    {
                        return BlendEquation.Overlay;
                    }
                case RenderableUtility.BlendEquationType.Darken:
                    {
                        return BlendEquation.Darken;
                    }
                case RenderableUtility.BlendEquationType.Lighten:
                    {
                        return BlendEquation.Lighten;
                    }
                case RenderableUtility.BlendEquationType.ColorDodge:
                    {
                        return BlendEquation.ColorDodge;
                    }
                case RenderableUtility.BlendEquationType.ColorBurn:
                    {
                        return BlendEquation.ColorBurn;
                    }
                case RenderableUtility.BlendEquationType.HardLight:
                    {
                        return BlendEquation.HardLight;
                    }
                case RenderableUtility.BlendEquationType.SoftLight:
                    {
                        return BlendEquation.SoftLight;
                    }
                case RenderableUtility.BlendEquationType.Difference:
                    {
                        return BlendEquation.Difference;
                    }
                case RenderableUtility.BlendEquationType.Exclusion:
                    {
                        return BlendEquation.Exclusion;
                    }
                case RenderableUtility.BlendEquationType.Hue:
                    {
                        return BlendEquation.Hue;
                    }
                case RenderableUtility.BlendEquationType.Saturation:
                    {
                        return BlendEquation.Saturation;
                    }
                case RenderableUtility.BlendEquationType.Color:
                    {
                        return BlendEquation.Color;
                    }
                case RenderableUtility.BlendEquationType.Luminosity:
                    {
                        return BlendEquation.Luminosity;
                    }
            }
            return BlendEquation.Add;
        }

        public enum BlendFactorType
        {
            /// <summary>
            /// Match as GL_ZERO
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Zero = 0,

            /// <summary>
            /// Match as GL_ONE
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            One = 1,

            /// <summary>
            /// Match as GL_SRC_COLOR
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            SourceColor = 0x0300,

            /// <summary>
            /// Match as GL_ONE_MINUS_SRC_COLOR
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            OneMinusSourceColor = 0x0301,

            /// <summary>
            /// Match as GL_SRC_ALPHA
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            SourceAlpha = 0x0302,

            /// <summary>
            /// Match as GL_ONE_MINUS_SRC_ALPHA
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            OneMinusSourceAlpha = 0x0303,

            /// <summary>
            /// Match as GL_DST_ALPHA
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            DestinationAlpha = 0x0304,

            /// <summary>
            /// Match as GL_ONE_MINUS_DST_ALPHA
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            OneMinusDestinationAlpha = 0x0305,

            /// <summary>
            /// Match as GL_DST_COLOR
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            DestinationColor = 0x0306,

            /// <summary>
            /// Match as GL_ONE_MINUS_DST_COLOR
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            OneMinusDestinationColor = 0x0307,

            /// <summary>
            /// Match as GL_SRC_ALPHA_SATURATE
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            SourceAlphaSaturate = 0x0308,

            /// <summary>
            /// Match as GL_CONSTANT_COLOR
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ConstantColor = 0x8001,

            /// <summary>
            /// Match as GL_ONE_MINUS_CONSTANT_COLOR
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            OneMinusConstantColor = 0x8002,

            /// <summary>
            /// Match as GL_CONSTANT_ALPHA
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ConstantAlpha = 0x8003,

            /// <summary>
            /// Match as GL_ONE_MINUS_CONSTANT_ALPHA
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            OneMinusConstantAlpha = 0x8004,
        }

        public static RenderableUtility.BlendFactorType ConvertBlendFactorTypeToUtilityProperty(Tizen.NUI.BlendFactor blendFactorType)
        {
            switch (blendFactorType)
            {
                case Tizen.NUI.BlendFactor.Zero:
                    {
                        return RenderableUtility.BlendFactorType.Zero;
                    }
                case Tizen.NUI.BlendFactor.One:
                    {
                        return RenderableUtility.BlendFactorType.One;
                    }
                case Tizen.NUI.BlendFactor.SourceColor:
                    {
                        return RenderableUtility.BlendFactorType.SourceColor;
                    }
                case Tizen.NUI.BlendFactor.OneMinusSourceColor:
                    {
                        return RenderableUtility.BlendFactorType.OneMinusSourceColor;
                    }
                case Tizen.NUI.BlendFactor.SourceAlpha:
                    {
                        return RenderableUtility.BlendFactorType.SourceAlpha;
                    }
                case Tizen.NUI.BlendFactor.OneMinusSourceAlpha:
                    {
                        return RenderableUtility.BlendFactorType.OneMinusSourceAlpha;
                    }
                case Tizen.NUI.BlendFactor.DestinationAlpha:
                    {
                        return RenderableUtility.BlendFactorType.DestinationAlpha;
                    }
                case Tizen.NUI.BlendFactor.OneMinusDestinationAlpha:
                    {
                        return RenderableUtility.BlendFactorType.OneMinusDestinationAlpha;
                    }
                case Tizen.NUI.BlendFactor.DestinationColor:
                    {
                        return RenderableUtility.BlendFactorType.DestinationColor;
                    }
                case Tizen.NUI.BlendFactor.OneMinusDestinationColor:
                    {
                        return RenderableUtility.BlendFactorType.OneMinusDestinationColor;
                    }
                case Tizen.NUI.BlendFactor.SourceAlphaSaturate:
                    {
                        return RenderableUtility.BlendFactorType.SourceAlphaSaturate;
                    }
                case Tizen.NUI.BlendFactor.ConstantColor:
                    {
                        return RenderableUtility.BlendFactorType.ConstantColor;
                    }
                case Tizen.NUI.BlendFactor.OneMinusConstantColor:
                    {
                        return RenderableUtility.BlendFactorType.OneMinusConstantColor;
                    }
                case Tizen.NUI.BlendFactor.ConstantAlpha:
                    {
                        return RenderableUtility.BlendFactorType.ConstantAlpha;
                    }
                case Tizen.NUI.BlendFactor.OneMinusConstantAlpha:
                    {
                        return RenderableUtility.BlendFactorType.OneMinusConstantAlpha;
                    }
            }
            return RenderableUtility.BlendFactorType.Zero;
        }

        public static BlendFactor ConvertBlendFactorTypeFromUtilityProperty(Tizen.NUI.RenderableUtility.BlendFactorType blendFactorType)
        {
            switch (blendFactorType)
            {
                case Tizen.NUI.RenderableUtility.BlendFactorType.Zero:
                    {
                        return BlendFactor.Zero;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.One:
                    {
                        return BlendFactor.One;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.SourceColor:
                    {
                        return BlendFactor.SourceColor;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.OneMinusSourceColor:
                    {
                        return BlendFactor.OneMinusSourceColor;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.SourceAlpha:
                    {
                        return BlendFactor.SourceAlpha;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.OneMinusSourceAlpha:
                    {
                        return BlendFactor.OneMinusSourceAlpha;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.DestinationAlpha:
                    {
                        return BlendFactor.DestinationAlpha;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.OneMinusDestinationAlpha:
                    {
                        return BlendFactor.OneMinusDestinationAlpha;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.DestinationColor:
                    {
                        return BlendFactor.DestinationColor;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.OneMinusDestinationColor:
                    {
                        return BlendFactor.OneMinusDestinationColor;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.SourceAlphaSaturate:
                    {
                        return BlendFactor.SourceAlphaSaturate;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.ConstantColor:
                    {
                        return BlendFactor.ConstantColor;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.OneMinusConstantColor:
                    {
                        return BlendFactor.OneMinusConstantColor;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.ConstantAlpha:
                    {
                        return BlendFactor.ConstantAlpha;
                    }
                case Tizen.NUI.RenderableUtility.BlendFactorType.OneMinusConstantAlpha:
                    {
                        return BlendFactor.OneMinusConstantAlpha;
                    }
            }
            return BlendFactor.Zero;
        }
    }
}
