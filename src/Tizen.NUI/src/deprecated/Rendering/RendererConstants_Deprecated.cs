// Copyright (c) 2023 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for face culling mode.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum FaceCullingModeType
    {
        /// <summary>
        /// None of the faces should be culled
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,

        /// <summary>
        /// Cull front face, front faces should never be shown
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Front,

        /// <summary>
        /// Cull back face, back faces should never be shown
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Back,

        /// <summary>
        /// Cull front and back faces; if the geometry is composed of triangles none of the faces will be shown
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        FrontAndBack,
    }

    /// <summary>
    /// Enumeration for blend mode.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BlendModeType
    {
        /// <summary>
        /// Blending is disabled.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Off = 0,

        /// <summary>
        /// Blending is enabled if there is alpha channel. This is the default mode.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Auto,

        /// <summary>
        /// Blending is enabled.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        On,

        /// <summary>
        /// Blending is enabled, and don't cull the renderer.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        OnWithoutCull,

        /// <summary>
        /// Blending is enabled when the actor is not opaque
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        UseActorOpacity,
    }

    /// <summary>
    /// Enumeration for blend equation.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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

    /// <summary>
    /// Enumeration for blend factor.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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
        SrcColor = 0x0300,

        /// <summary>
        /// Match as GL_ONE_MINUS_SRC_COLOR
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneMinusSrcColor = 0x0301,

        /// <summary>
        /// Match as GL_SRC_ALPHA
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        SrcAlpha = 0x0302,

        /// <summary>
        /// Match as GL_ONE_MINUS_SRC_ALPHA
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneMinusSrcAlpha = 0x0303,

        /// <summary>
        /// Match as GL_DST_ALPHA
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        DstAlpha = 0x0304,

        /// <summary>
        /// Match as GL_ONE_MINUS_DST_ALPHA
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneMinusDstAlpha = 0x0305,

        /// <summary>
        /// Match as GL_DST_COLOR
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        DstColor = 0x0306,

        /// <summary>
        /// Match as GL_ONE_MINUS_DST_COLOR
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        OneMinusDstColor = 0x0307,

        /// <summary>
        /// Match as GL_SRC_ALPHA_SATURATE
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        SrcAlphaSaturate = 0x0308,

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

    /// <summary>
    /// Enumeration for depth buffer write modes.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DepthWriteModeType
    {
        /// <summary>
        /// Renderer doesn't write to the depth buffer
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Off = 0,

        /// <summary>
        /// Renderer only writes to the depth buffer if it's opaque
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Auto,

        /// <summary>
        /// Renderer writes to the depth buffer
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        On,
    }

    /// <summary>
    /// Enumeration for depth functions.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DepthFunctionType
    {
        /// <summary>
        /// Depth test never passes
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Never = 0,

        /// <summary>
        /// Depth test always passes
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Always,

        /// <summary>
        /// Depth test passes if the incoming depth value is less than the stored depth value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Less,

        /// <summary>
        /// Depth test passes if the incoming depth value is greater than the stored depth value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Greater,

        /// <summary>
        /// Depth test passes if the incoming depth value is equal to the stored depth value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Equal,

        /// <summary>
        /// Depth test passes if the incoming depth value is not equal to the stored depth value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        NotEqual,

        /// <summary>
        /// Depth test passes if the incoming depth value is less than or equal to the stored depth value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        LessEqual,

        /// <summary>
        /// Depth test passes if the incoming depth value is greater than or equal to the stored depth value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        GreaterEqual,
    }

    /// <summary>
    /// Enumeration for depth buffer test (read) modes.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DepthTestModeType
    {
        /// <summary>
        /// Renderer does not read from the depth buffer
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Off = 0,

        /// <summary>
        /// Renderer only reads from the depth buffer if in a 3D layer
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Auto,

        /// <summary>
        /// Renderer reads from the depth buffer based on the DepthFunction
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        On,
    }

    /// <summary>
    /// Enumeration for the controls of how this renderer uses its stencil properties and writes to the color buffer.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum RenderModeType
    {
        /// <summary>
        /// Do not write to either color or stencil buffer (But will potentially render to depth buffer).
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,

        /// <summary>
        /// Managed by the View Clipping API. This is the default.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Auto,

        /// <summary>
        /// Ingore stencil properties.  Write to the color buffer.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Color,

        /// <summary>
        /// Use the stencil properties. Do not write to the color buffer.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Stencil,

        /// <summary>
        /// Use the stencil properties AND Write to the color buffer.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        ColorStencil,
    }

    /// <summary>
    /// Enumeration for the comparison function used on the stencil buffer.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum StencilFunctionType
    {
        /// <summary>
        /// Always fails
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Never = 0,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) <  ( stencil & mask ) ]]>
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Less,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) =  ( stencil & mask ) ]]>
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Equal,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) <= ( stencil & mask ) ]]>
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        LessEqual,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) >  ( stencil & mask ) ]]>
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Greater,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) != ( stencil & mask ) ]]>
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        NotEqual,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) >= ( stencil & mask ) ]]>
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        GreaterEqual,

        /// <summary>
        /// Always passes
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Always,
    }

    /// <summary>
    /// Enumeration for specifying the action to take when the stencil (or depth) test fails during stencil test.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum StencilOperationType
    {
        /// <summary>
        /// Sets the stencil buffer value to 0
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Zero = 0,

        /// <summary>
        /// Keeps the current value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Keep,

        /// <summary>
        /// Sets the stencil buffer value to ref, as specified by glStencilFunc
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Replace,

        /// <summary>
        /// Increments the current stencil buffer value. Clamps to the maximum representable unsigned value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Increment,

        /// <summary>
        /// Decrements the current stencil buffer value. Clamps to 0
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Decrement,

        /// <summary>
        /// Bitwise inverts the current stencil buffer value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Invert,

        /// <summary>
        /// Increments the current stencil buffer value.
        /// Wraps stencil buffer value to zero when incrementing the maximum representable unsigned value
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        IncrementWrap,

        /// <summary>
        /// Decrements the current stencil buffer value.
        /// Wraps stencil buffer value to the maximum representable unsigned value when decrementing a stencil buffer value of zero
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        DecrementWrap,
    }
}
