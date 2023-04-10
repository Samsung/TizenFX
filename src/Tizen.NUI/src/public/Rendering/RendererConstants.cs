// Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
        NONE = 0,

        /// <summary>
        /// Cull front face, front faces should never be shown
        /// </summary>
        FRONT,

        /// <summary>
        /// Cull back face, back faces should never be shown
        /// </summary>
        BACK,

        /// <summary>
        /// Cull front and back faces; if the geometry is composed of triangles none of the faces will be shown
        /// </summary>
        FRONT_AND_BACK
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
        OFF = 0,

        /// <summary>
        /// Blending is enabled if there is alpha channel. This is the default mode.
        /// </summary>
        AUTO,

        /// <summary>
        /// Blending is enabled.
        /// </summary>
        ON,

        /// <summary>
        /// Blending is enabled, and don't cull the renderer.
        /// </summary>
        ON_WITHOUT_CULL,

        /// <summary>
        /// Blending is enabled when the actor is not opaque
        /// </summary>
        USE_ACTOR_OPACITY
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
        Add = 0x8006,

        /// <summary>
        /// Subtracts the destination from the source.
        /// </summary>
        Subtract = 0x800A,

        /// <summary>
        /// Subtracts the source from the destination.
        /// </summary>
        ReverseSubtract = 0x800B,

        //OpenGL es 3.0 enumeration
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Min = 0x8007,
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Max = 0x8008,

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
        Luminosity = 0x92B0
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
        ZERO = 0,

        /// <summary>
        /// Match as GL_ONE
        /// </summary>
        ONE = 1,

        /// <summary>
        /// Match as GL_SRC_COLOR
        /// </summary>
        SRC_COLOR = 0x0300,

        /// <summary>
        /// Match as GL_ONE_MINUS_SRC_COLOR
        /// </summary>
        ONE_MINUS_SRC_COLOR = 0x0301,

        /// <summary>
        /// Match as GL_SRC_ALPHA
        /// </summary>
        SRC_ALPHA = 0x0302,

        /// <summary>
        /// Match as GL_ONE_MINUS_SRC_ALPHA
        /// </summary>
        ONE_MINUS_SRC_ALPHA = 0x0303,

        /// <summary>
        /// Match as GL_DST_ALPHA
        /// </summary>
        DST_ALPHA = 0x0304,

        /// <summary>
        /// Match as GL_ONE_MINUS_DST_ALPHA
        /// </summary>
        ONE_MINUS_DST_ALPHA = 0x0305,

        /// <summary>
        /// Match as GL_DST_COLOR
        /// </summary>
        DST_COLOR = 0x0306,

        /// <summary>
        /// Match as GL_ONE_MINUS_DST_COLOR
        /// </summary>
        ONE_MINUS_DST_COLOR = 0x0307,

        /// <summary>
        /// Match as GL_SRC_ALPHA_SATURATE
        /// </summary>
        SRC_ALPHA_SATURATE = 0x0308,

        /// <summary>
        /// Match as GL_CONSTANT_COLOR
        /// </summary>
        CONSTANT_COLOR = 0x8001,

        /// <summary>
        /// Match as GL_ONE_MINUS_CONSTANT_COLOR
        /// </summary>
        ONE_MINUS_CONSTANT_COLOR = 0x8002,

        /// <summary>
        /// Match as GL_CONSTANT_ALPHA
        /// </summary>
        CONSTANT_ALPHA = 0x8003,

        /// <summary>
        /// Match as GL_ONE_MINUS_CONSTANT_ALPHA
        /// </summary>
        ONE_MINUS_CONSTANT_ALPHA = 0x8004
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
        OFF = 0,

        /// <summary>
        /// Renderer only writes to the depth buffer if it's opaque
        /// </summary>
        AUTO,

        /// <summary>
        /// Renderer writes to the depth buffer
        /// </summary>
        ON
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
        NEVER = 0,

        /// <summary>
        /// Depth test always passes
        /// </summary>
        ALWAYS,

        /// <summary>
        /// Depth test passes if the incoming depth value is less than the stored depth value
        /// </summary>
        LESS,

        /// <summary>
        /// Depth test passes if the incoming depth value is greater than the stored depth value
        /// </summary>
        GREATER,

        /// <summary>
        /// Depth test passes if the incoming depth value is equal to the stored depth value
        /// </summary>
        EQUAL,

        /// <summary>
        /// Depth test passes if the incoming depth value is not equal to the stored depth value
        /// </summary>
        NOT_EQUAL,

        /// <summary>
        /// Depth test passes if the incoming depth value is less than or equal to the stored depth value
        /// </summary>
        LESS_EQUAL,

        /// <summary>
        /// Depth test passes if the incoming depth value is greater than or equal to the stored depth value
        /// </summary>
        GREATER_EQUAL
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
        OFF = 0,

        /// <summary>
        /// Renderer only reads from the depth buffer if in a 3D layer
        /// </summary>
        AUTO,

        /// <summary>
        /// Renderer reads from the depth buffer based on the DepthFunction
        /// </summary>
        ON
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
        NONE = 0,

        /// <summary>
        /// Managed by the View Clipping API. This is the default.
        /// </summary>
        AUTO,

        /// <summary>
        /// Ingore stencil properties.  Write to the color buffer.
        /// </summary>
        COLOR,

        /// <summary>
        /// Use the stencil properties. Do not write to the color buffer.
        /// </summary>
        STENCIL,

        /// <summary>
        /// Use the stencil properties AND Write to the color buffer.
        /// </summary>
        COLOR_STENCIL,
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
        NEVER = 0,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) <  ( stencil & mask ) ]]>
        /// </summary>
        LESS,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) =  ( stencil & mask ) ]]>
        /// </summary>
        EQUAL,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) <= ( stencil & mask ) ]]>
        /// </summary>
        LESS_EQUAL,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) >  ( stencil & mask ) ]]>
        /// </summary>
        GREATER,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) != ( stencil & mask ) ]]>
        /// </summary>
        NOT_EQUAL,

        /// <summary>
        /// Passes if <![CDATA[ ( reference & mask ) >= ( stencil & mask ) ]]>
        /// </summary>
        GREATER_EQUAL,

        /// <summary>
        /// Always passes
        /// </summary>
        ALWAYS
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
        ZERO = 0,

        /// <summary>
        /// Keeps the current value
        /// </summary>
        KEEP,

        /// <summary>
        /// Sets the stencil buffer value to ref, as specified by glStencilFunc
        /// </summary>
        REPLACE,

        /// <summary>
        /// Increments the current stencil buffer value. Clamps to the maximum representable unsigned value
        /// </summary>
        INCREMENT,

        /// <summary>
        /// Decrements the current stencil buffer value. Clamps to 0
        /// </summary>
        DECREMENT,

        /// <summary>
        /// Bitwise inverts the current stencil buffer value
        /// </summary>
        INVERT,

        /// <summary>
        /// Increments the current stencil buffer value.
        /// Wraps stencil buffer value to zero when incrementing the maximum representable unsigned value
        /// </summary>
        INCREMENT_WRAP,

        /// <summary>
        /// Decrements the current stencil buffer value.
        /// Wraps stencil buffer value to the maximum representable unsigned value when decrementing a stencil buffer value of zero
        /// </summary>,
        DECREMENT_WRAP
    }
}
