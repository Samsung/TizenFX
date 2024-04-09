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
    /// Specifies the release policy types.<br />
    /// Decides if the image should be cached in different conditions.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum ReleasePolicyType
    {
        /// <summary>
        /// Image is released when visual detached from scene.
        /// </summary>
        Detached = 0,
        /// <summary>
        /// Image is only released when visual is destroyed.
        /// </summary>
        Destroyed,
        /// <summary>
        /// Image is not released.
        /// </summary>
        Never
    }

    /// <summary>
    /// Specifies the load policy types.<br />
    /// Decides when the image texture should be loaded.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum LoadPolicyType
    {
        /// <summary>
        /// Load texture once the image source has been provided. Even if not being used yet.
        /// </summary>
        Immediate = 0,
        /// <summary>
        /// Only load texture once the visual is attached, when the image needs to be shown.
        /// </summary>
        Attached
    }

    /// <summary>
    /// Enumeration for the horizontal alignment of objects such as texts and layout items.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Objects are placed at the beginning of the horizontal direction.
        /// </summary>
        [Description("BEGIN")]
        Begin,
        /// <summary>
        /// Objects are placed at the center of the horizontal direction.
        /// </summary>
        [Description("CENTER")]
        Center,
        /// <summary>
        /// Objects are placed at the end of the horizontal direction.
        /// </summary>
        [Description("END")]
        End
    }

    /// <summary>
    /// Enumeration for the vertical alignment of objects such as texts and layout items.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VerticalAlignment
    {
        /// <summary>
        /// Objects are placed at the top of the vertical direction.
        /// </summary>
        [Description("TOP")]
        Top,
        /// <summary>
        /// Objects are placed at the center of the vertical direction.
        /// </summary>
        [Description("CENTER")]
        Center,
        /// <summary>
        /// Objects are placed at the bottom of the vertical direction.
        /// </summary>
        [Description("BOTTOM")]
        Bottom
    }

    /// <summary>
    /// This specifies wrap mode types.<br />
    /// WrapModeU and WrapModeV separately decide how the texture should be sampled when the u and v coordinate exceeds the range of 0.0 to 1.0.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WrapModeType
    {
        /// <summary>
        /// The default value.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Clamp to edge.
        /// </summary>
        ClampToEdge,
        /// <summary>
        /// Repeat.
        /// </summary>
        Repeat,
        /// <summary>
        /// Mirrored repeat.
        /// </summary>
        MirroredRepeat
    }

    /// <summary>
    /// This specifies fitting mode types. Fitting options, used when resizing images to fit desired dimensions.<br />
    /// A fitting mode controls the region of a loaded image to be mapped to the desired image rectangle.<br />
    /// All fitting modes preserve the aspect ratio of the image contents.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum FittingModeType
    {
        /// <summary>
        /// Full-screen image display: Limit loaded image resolution to device resolution using the ShrinkToFit mode.
        /// </summary>
        ShrinkToFit,
        /// <summary>
        /// Thumbnail gallery grid: Limit loaded image resolution to screen tile using the ScaleToFill mode.
        /// </summary>
        ScaleToFill,
        /// <summary>
        /// Image columns: Limit loaded image resolution to column width using the FitWidth mode.
        /// </summary>
        FitWidth,
        /// <summary>
        /// Image rows: Limit loaded image resolution to row height using the FitHeight mode.
        /// </summary>
        FitHeight,
        /// <summary>
        /// Image displayed in its original size (no scaling) using the Center mode.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Center,
        /// <summary>
        /// Image stretched to fill the desired area (aspect ratio could be changed) using the Fill mode.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Fill
    }

    /// <summary>
    /// This specifies sampling mode types. Filtering options are used when resizing images to sample original pixels.<br />
    /// A SamplingMode controls how pixels in an input image are sampled and combined to generate each pixel of a destination image during scaling.<br />
    /// NoFilter and Box modes do not guarantee that the output pixel array exactly matches the rectangle specified by the desired dimensions and the FittingMode,<br />
    /// but all other filter modes do if the desired dimensions are not more than the raw dimensions of the input image file.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SamplingModeType
    {
        /// <summary>
        /// Iteratively box filter to generate an image of 1/2, 1/4, 1/8, etc. width and height and approximately the desired size. <br />
        /// This is the default.
        /// </summary>
        Box,
        /// <summary>
        /// For each output pixel, read one input pixel.
        /// </summary>
        Nearest,
        /// <summary>
        /// For each output pixel, read a quad of four input pixels and write a weighted average of them.
        /// </summary>
        Linear,
        /// <summary>
        /// Iteratively box filter to generate an image of 1/2, 1/4, 1/8, etc. width and height and approximately the desired size, <br />
        /// then for each output pixel, read one pixel from the last level of box filtering.<br />
        /// </summary>
        BoxThenNearest,
        /// <summary>
        /// Iteratively box filter to almost the right size, then for each output pixel, read four pixels from the last level of box filtering and write their weighted average.
        /// </summary>
        BoxThenLinear,
        /// <summary>
        /// No filtering is performed. If the SCALE_TO_FILL scaling mode is enabled, the borders of the image may be trimmed to match the aspect ratio of the desired dimensions.
        /// </summary>
        NoFilter,
        /// <summary>
        /// For caching algorithms where a client strongly prefers a cache-hit to reuse a cached image.
        /// </summary>
        DontCare
    }

    /// <summary>
    /// The type of coordinate system for certain attributes of the points in a gradient.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GradientVisualUnitsType
    {
        /// <summary>
        /// Uses the normals for the start, end, and center points, i.e., top-left is (-0.5, -0.5) and bottom-right is (0.5, 0.5).
        /// </summary>
        ObjectBoundingBox,
        /// <summary>
        /// Uses the user coordinates for the start, end, and center points, i.e., in a 200 by 200 control, top-left is (0, 0) and bottom-right is (200, 200).
        /// </summary>
        UserSpace
    }

    /// <summary>
    /// This specifies SpreadMethod types.<br />
    /// SpreadMethod defines what happens if the gradient starts or ends inside the bounds of the target rectangle.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GradientVisualSpreadMethodType
    {
        /// <summary>
        /// Uses the terminal colors of the gradient to fill the remainder of the quad.
        /// </summary>
        Pad,
        /// <summary>
        /// Reflects the gradient pattern start-to-end, end-to-start, start-to-end, etc. until the quad is filled.
        /// </summary>
        Reflect,
        /// <summary>
        /// Repeats the gradient pattern start-to-end, start-to-end, start-to-end, etc. until the quad is filled.
        /// </summary>
        Repeat
    }

    /// <summary>
    /// The shading mode used by the mesh visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MeshVisualShadingModeValue
    {
        /// <summary>
        /// *Simplest*. One color that is lit by ambient and diffuse lighting.
        /// </summary>
        TexturelessWithDiffuseLighting,
        /// <summary>
        /// Uses only the visual image textures provided with specular lighting in addition to ambient and diffuse lighting.
        /// </summary>
        TexturedWithSpecularLighting,
        /// <summary>
        /// Uses all textures provided including gloss, normal, and texture map along with specular, ambient, and diffuse lighting.
        /// </summary>
        TexturedWithDetailedSpecularLighting
    }

    /// <summary>
    /// The primitive shape to render as a primitive visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PrimitiveVisualShapeType
    {
        /// <summary>
        /// A perfectly round geometrical object in the three-dimensional space.
        /// </summary>
        Sphere,
        /// <summary>
        /// The area bound between two circles, i.e., a cone with the tip removed.
        /// </summary>
        ConicalFrustrum,
        /// <summary>
        /// Equivalent to a conical frustum with the top radius of zero.
        /// </summary>Equivalent to a conical frustum with the top radius of zero.
        Cone,
        /// <summary>
        /// Equivalent to a conical frustum with the top radius of zero.
        /// </summary>
        Cylinder,
        /// <summary>
        /// Equivalent to a conical frustum with equal radii for the top and bottom circles.
        /// </summary>
        Cube,
        /// <summary>
        /// Equivalent to a bevelled cube with a bevel percentage of zero.
        /// </summary>
        Octahedron,
        /// <summary>
        /// Equivalent to a bevelled cube with a bevel percentage of one.
        /// </summary>
        BevelledCube
    }

    /// <summary>
    /// The values of this enum determine how the visual should fit into the view.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum VisualFittingModeType
    {
        /// <summary>
        /// The visual should be scaled to fit, preserving aspect ratio.
        /// </summary>
        FitKeepAspectRatio,
        /// <summary>
        /// The visual should be stretched to fill, not preserving aspect ratio.
        /// </summary>
        Fill,
        /// <summary>
        /// The visual should be scaled to fit, preserving aspect ratio. The visual will be filled without empty area, and outside is cropped away.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        OverFitKeepAspectRatio,
        /// <summary>
        /// The visual should keep original size of image. it is not scaled and not stretched.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Center,
        /// <summary>
        /// The visual should be scaled to fit, preserving aspect ratio. Height is scaled proportionately to maintain aspect ratio.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FitHeight,
        /// <summary>
        /// The visual should be scaled to fit, preserving aspect ratio. WIDTH is scaled proportionately to maintain aspect ratio.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FitWidth,
    }

    /// <summary>
    /// This specifies policy types that could be used by the transform for the offset or size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VisualTransformPolicyType
    {
        /// <summary>
        /// Relative to the control (percentage [0.0f to 1.0f] of the control).
        /// </summary>
        Relative = 0,
        /// <summary>
        /// Absolute value in world units.
        /// </summary>
        Absolute = 1
    }

    /// <summary>
    /// This specifies all the transform property types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VisualTransformPropertyType
    {
        /// <summary>
        /// Offset of the visual, which can be either relative (percentage [0.0f to 1.0f] of the parent) or absolute (in world units).
        /// </summary>
        Offset,
        /// <summary>
        /// Size of the visual, which can be either relative (percentage [0.0f to 1.0f] of the parent) or absolute (in world units).
        /// </summary>
        Size,
        /// <summary>
        /// The origin of the visual within its control area.
        /// </summary>
        Origin,
        /// <summary>
        /// The anchor-point of the visual.
        /// </summary>
        AnchorPoint,
        /// <summary>
        /// Whether the x or y offset values are relative (percentage [0.0f to 1.0f] of the control) or absolute (in world units).
        /// </summary>
        OffsetPolicy,
        /// <summary>
        /// Whether the width or the height size values are relative (percentage [0.0f to 1.0f] of the control) or absolute (in world units).
        /// </summary>
        SizePolicy,
        /// <summary>
        /// Extra size value that will be added to the computed visual size.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ExtraSize,
    }

    /// <summary>
    /// This specifies visual types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct Visual
    {
        /// <summary>
        /// The index for the visual type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum Type
        {
            /// <summary>
            /// Renders a solid color as an internal border to the control's quad.
            /// </summary>
            Border,
            /// <summary>
            /// Renders a solid color to the control's quad.
            /// </summary>
            Color,
            /// <summary>
            /// Renders a smooth transition of colors to the control's quad.
            /// </summary>
            Gradient,
            /// <summary>
            /// Renders an image into the control's quad.
            /// </summary>
            Image,
            /// <summary>
            /// Renders a mesh using an "obj" file, optionally with textures provided by an "mtl" file.
            /// </summary>
            Mesh,
            /// <summary>
            /// Renders a simple 3D shape, such as a cube or a sphere.
            /// </summary>
            Primitive,
            /// <summary>
            /// Renders a simple wire-frame outlining a quad.
            /// </summary>
            Wireframe,
            /// <summary>
            /// Renders text.
            /// </summary>
            Text,
            /// <summary>
            /// Renders an NPatch image.
            /// </summary>
            NPatch,
            /// <summary>
            /// Renders an SVG image.
            /// </summary>
            SVG,
            /// <summary>
            /// Renders a animated image (animated GIF).
            /// </summary>
            AnimatedImage,
            /// <summary>
            /// Renders an animated gradient.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            AnimatedGradient = Visual.Type.AnimatedImage + 1,
            /// <summary>
            /// Renders an animated vector image.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            AnimatedVectorImage = Visual.Type.AnimatedImage + 2,
            /// <summary>
            /// Renders an arc.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Arc = AnimatedImage + 3,

            /// <summary>
            /// Keyword for invalid visual type. (NUI only)
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = Border - 1,
        }

        /// <summary>
        /// This specifies visual properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716: Identifiers should not match keywords")]
        public struct Property
        {
            /// <summary>
            /// Type.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Type = NDalic.VisualPropertyType;
            /// <summary>
            /// Shader.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Shader = NDalic.VisualPropertyShader;
            /// <summary>
            /// Transform.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Transform = NDalic.VisualPropertyTransform;
            /// <summary>
            /// PremultipliedAlpha.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int PremultipliedAlpha = NDalic.VisualPropertyPremultipliedAlpha;
            /// <summary>
            /// MixColor.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int MixColor = NDalic.VisualPropertyMixColor;
            /// <summary>
            /// Opacity.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Opacity = NDalic.VisualPropertyMixColor + 1;
            /// <summary>
            /// The fitting mode of the visual.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public static readonly int VisualFittingMode = NDalic.VisualPropertyMixColor + 2;
            /// <summary>
            /// The corner radius of the visual.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CornerRadius = NDalic.VisualPropertyMixColor + 3;
            /// <summary>
            /// The corner radius policy of the visual.
            /// Whether the corner radius value is relative (percentage [0.0f to 1.0f] of the visual size) or absolute (in world units).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CornerRadiusPolicy = NDalic.VisualPropertyMixColor + 4;
            /// <summary>
            /// The borderline width of the visual.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BorderlineWidth = NDalic.VisualPropertyMixColor + 5;
            /// <summary>
            /// The borderline color of the visual.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BorderlineColor = NDalic.VisualPropertyMixColor + 6;
            /// <summary>
            /// The borderline offset of the visual.
            /// Relative position of borderline. (percentage [-1.0f to 1.0f]).
            /// If -1.0f, borderline draw inside of visual
            /// If 1.0f, borderline draw outside of visual
            /// If 0.0f, half draw inside and half draw outside of visual
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int BorderlineOffset = NDalic.VisualPropertyMixColor + 7;
        }

        /// <summary>
        /// This specifies shader properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public struct ShaderProperty
        {
            /// <summary>
            /// Vertex shader code
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int VertexShader = NDalic.VisualShaderVertex;
            /// <summary>
            /// Fragment shader code
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int FragmentShader = NDalic.VisualShaderFragment;
            /// <summary>
            /// How to subdivide the grid along X
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderSubdivideGridX = NDalic.VisualShaderSubdivideGridX;
            /// <summary>
            /// How to subdivide the grid along Y
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderSubdivideGridY = NDalic.VisualShaderSubdivideGridY;
            /// <summary>
            /// Bitmask of hints
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderHints = NDalic.VisualShaderHints;
        }

        /// <summary>
        /// This specifies visual align types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum AlignType
        {
            /// <summary>
            /// TopBegin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TopBegin = 0,
            /// <summary>
            /// TopCenter
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TopCenter,
            /// <summary>
            /// TopEnd
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TopEnd,
            /// <summary>
            /// CenterBegin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            CenterBegin,
            /// <summary>
            /// Center
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Center,
            /// <summary>
            /// CenterEnd
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            CenterEnd,
            /// <summary>
            /// BottomBegin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            BottomBegin,
            /// <summary>
            /// BottomCenter
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            BottomCenter,
            /// <summary>
            /// BottomEnd
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            BottomEnd
        }
    }

    /// <summary>
    /// This specifies properties of the BorderVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct BorderVisualProperty
    {
        /// <summary>
        /// The color of the border.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Color = NDalic.BorderVisualColor;
        /// <summary>
        /// The width of the border (in pixels).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Size = NDalic.BorderVisualSize;
        /// <summary>
        /// Whether anti-aliasing of the border is required.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int AntiAliasing = NDalic.BorderVisualAntiAliasing;
    }

    /// <summary>
    /// This specifies properties of the ColorVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ColorVisualProperty
    {
        /// <summary>
        /// The solid color required.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MixColor = NDalic.ColorVisualMixColor;
        /// <summary>
        /// Whether to render if the MixColor is transparent.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int RenderIfTransparent = NDalic.ColorVisualMixColor + 1;
        /// <summary>
        /// Then radius value for the area to blur.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int BlurRadius = NDalic.ColorVisualMixColor + 2;
    }

    /// <summary>
    /// This specifies properties of the GradientVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct GradientVisualProperty
    {
        /// <summary>
        /// The start position of a linear gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StartPosition = NDalic.GradientVisualStartPosition;
        /// <summary>
        /// The end position of a linear gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int EndPosition = NDalic.GradientVisualEndPosition;
        /// <summary>
        /// The center point of a radial gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Center = NDalic.GradientVisualCenter;
        /// <summary>
        /// The size of the radius of a radial gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Radius = NDalic.GradientVisualRadius;
        /// <summary>
        /// All the stop offsets.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StopOffset = NDalic.GradientVisualStopOffset;
        /// <summary>
        /// The color at the stop offsets.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StopColor = NDalic.GradientVisualStopColor;
        /// <summary>
        /// Defines the coordinate system for certain attributes of the points in a gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Units = NDalic.GradientVisualUnits;
        /// <summary>
        /// Indicates what happens if the gradient starts or ends inside the bounds of the target rectangle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SpreadMethod = NDalic.GradientVisualSpreadMethod;
    }

    /// <summary>
    /// This specifies properties of the ImageVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ImageVisualProperty
    {
        /// <summary>
        /// The URL of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int URL = NDalic.ImageVisualUrl;

        /// <summary>
        /// Fitting options, used when resizing images to fit desired dimensions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FittingMode = NDalic.ImageVisualFittingMode;

        /// <summary>
        /// Filtering options, used when resizing images to sample original pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SamplingMode = NDalic.ImageVisualSamplingMode;

        /// <summary>
        /// The desired image width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredWidth = NDalic.ImageVisualDesiredWidth;

        /// <summary>
        /// The desired image height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredHeight = NDalic.ImageVisualDesiredHeight;

        /// <summary>
        /// Whether to load the image synchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SynchronousLoading = NDalic.ImageVisualSynchronousLoading;

        /// <summary>
        /// If true, only draws the borders.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BorderOnly = NDalic.ImageVisualBorderOnly;

        /// <summary>
        /// The image area to be displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PixelArea = NDalic.ImageVisualPixelArea;

        /// <summary>
        /// The wrap mode for u coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeU = NDalic.ImageVisualWrapModeU;

        /// <summary>
        /// The wrap mode for v coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeV = NDalic.ImageVisualWrapModeV;

        /// <summary>
        /// The border of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Border = NDalic.ImageVisualBorder;

        /// <summary>
        /// Whether to use the texture atlas.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Atlasing = NDalic.ImageVisualBorder + 1;

        /// <summary>
        /// The URL of the alpha mask image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int AlphaMaskURL = NDalic.ImageVisualAlphaMaskUrl;

        /// <summary>
        /// Defines the batch size for pre-loading images in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int BatchSize = NDalic.ImageVisualBatchSize;

        /// <summary>
        /// Defines the cache size for loading images in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int CacheSize = NDalic.ImageVisualCacheSize;

        /// <summary>
        /// The number of milliseconds between each frame in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int FrameDelay = NDalic.ImageVisualFrameDelay;

        /// <summary>
        /// The scale factor to apply to the content image before masking.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int MaskContentScale = NDalic.ImageVisualMaskContentScale;

        /// <summary>
        /// Whether to crop image to mask or scale mask to fit image
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int CropToMask = NDalic.ImageVisualCropToMask;

        /// <summary>
        /// The policy to determine when an image should be loaded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int LoadPolicy = NDalic.ImageVisualLoadPolicy;

        /// <summary>
        /// The policy to determine when an image should no longer be cached.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int ReleasePolicy = NDalic.ImageVisualReleasePolicy;

        /// <summary>
        /// Determines if image orientation should be corrected so that the image displays as it was intended.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int OrientationCorrection = NDalic.ImageVisualOrientationCorrection;

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int AuxiliaryImageURL = NDalic.ImageVisualAuxiliaryImageUrl;

        /// <summary>
        /// Alpha value for the auxiliary image, without affecting the underlying NPatch image
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int AuxiliaryImageAlpha = NDalic.ImageVisualAuxiliaryImageAlpha;

        /// <summary>
        /// The number of times the AnimatedImageVisual will be looped.
        /// The default is -1. If the value is less than 0, loop unlimited. Otherwise, loop loopCount times.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int LoopCount = NDalic.ImageVisualLoopCount;

        /// <summary>
        /// @brief The playing range the AnimatedVectorImageVisual will use.
        /// Animation will play between the values specified.The array can only have two values, and more will be ignored.
        /// Both values should be between 0 and the total frame number, otherwise they will be ignored.
        /// If the range provided is not in proper order (minimum, maximum), it will be reordered.
        /// @details Name "playRange", Type Property::ARRAY of Property::INTEGER
        /// @note Default 0 and the total frame number.
        /// </summary>
        /// <remarks>
        /// Hidden API (Inhouse API)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int PlayRange = NDalic.ImageVisualOrientationCorrection + 4;

        /// <summary>
        /// @brief The playing state the AnimatedVectorImageVisual will use.
        /// @details Name "playState", type PlayState (Property::INTEGER)
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Hidden API (Inhouse API)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int PlayState = NDalic.ImageVisualOrientationCorrection + 5;

        /// <summary>
        /// @brief The current frame number the AnimatedVectorImageVisual will use.
        /// @details Name "currentFrameNumber", Type Property::INTEGER, between[0, the maximum frame number] or between the play range if specified
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int CurrentFrameNumber = NDalic.ImageVisualOrientationCorrection + 6;

        /// <summary>
        /// @brief The total frame number the AnimatedVectorImageVisual will use.
        /// @details Name "totalFrameNumber", Type Property::INTEGER.
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int TotalFrameNumber = NDalic.ImageVisualOrientationCorrection + 7;

        /// <summary>
        /// @brief  The stop behavior the AnimatedVectorImageVisual will use.
        /// @details Name "stopBehavior", Type StopBehavior::Type (Property::INTEGER)
        /// @note Default value is StopBehavior::CURRENT_FRAME.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int StopBehavior = NDalic.ImageVisualOrientationCorrection + 8;

        /// <summary>
        /// @brief  The looping mode the AnimatedVectorImageVisual will use.
        /// @details Name "loopingMode", Type LoopingMode::Type (Property::INTEGER)
        /// @note Default value is LoopingMode::RESTART.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int LoopingMode = NDalic.ImageVisualOrientationCorrection + 9;

        /// <summary>
        /// @brief The content information the AnimatedVectorImageVisual will use.
        /// @details Name "contentInfo", Type Property::MAP.
        /// The map contains the layer name as a key and Property::Array as a value.
        /// And the array contains 2 integer values which are the frame numbers, the start frame number and the end frame number of the layer.
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int ContentInfo = NDalic.ImageVisualOrientationCorrection + 10;

        /// <summary>
        /// @brief Whether to redraw the image when the visual is scaled down.
        /// @details Name "redrawInScalingDown", type Property::BOOLEAN.
        /// @note It is used in the AnimatedVectorImageVisual.The default is true.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int RedrawInScalingDown = NDalic.ImageVisualOrientationCorrection + 11;

        /// <summary>
        /// @brief Whether to apply mask on the GPU or not.
        /// @details Name "MaskingMode", type MaskingModeType (Property::INTEGER).
        /// @note It is used in the ImageVisual, and AnimatedImageVisual.The default is MaskingOnLoading.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int MaskingMode = NDalic.ImageVisualOrientationCorrection + 12;

        /// <summary>
        /// @brief Whether to uploading texture before ResourceReady signal emit or after texture load completed time.
        /// @details Name "fastTrackUploading", type Property::BOOLEAN.
        /// @note It is used in the ImageVisual. The default is false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int FastTrackUploading = NDalic.ImageVisualOrientationCorrection + 13;

        /// <summary>
        /// @brief The marker information the AnimatedVectorImageVisual will use.
        /// @details Type Property::MAP.
        /// The map contains the marker name as a key and Property::Array as a value.
        /// And the array contains 2 integer values which are the frame numbers, the start frame number and the end frame number of the marker.
        /// @note This property is read-only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int MarkerInfo = NDalic.ImageVisualOrientationCorrection + 15;

        /// <summary>
        /// @brief Whether to animated image visual uses fixed cache or not.
        /// @details type Property::BOOLEAN.
        /// If this property is true, animated image visual uses fixed cache for loading and keeps loaded frame
        /// until the visual is removed. It reduces CPU cost when the animated image will be looping.
        /// But it can spend a lot of memory if the resource has high resolution image or many frame count.
        /// @note It is used in the AnimatedVectorImageVisual. The default is false
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int EnableFrameCache = NDalic.ImageVisualOrientationCorrection + 16;

        /// <summary>
        /// @brief Whether notify AnimatedVectorImageVisual to render thread after every rasterization or not.
        /// @details type Property::BOOLEAN.
        /// If this property is true, AnimatedVectorImageVisual send notify to render thread after every rasterization.
        /// If false, AnimatedVectorImageVisual set Renderer's Behaviour as Continouly (mean, always update the render thread.)
        ///
        /// This flag is useful if given resource has low fps, so we don't need to render every frame.
        /// @note It is used in the AnimatedVectorImageVisual. The default is false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int NotifyAfterRasterization = NDalic.ImageVisualOrientationCorrection + 17;
    }

    /// <summary>
    /// This specifies properties of the MeshVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct MeshVisualProperty
    {
        /// <summary>
        /// The location of the ".obj" file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ObjectURL = NDalic.MeshVisualObjectUrl;
        /// <summary>
        /// The location of the ".mtl" file.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int MaterialURL = NDalic.MeshVisualMaterialUrl;
        /// <summary>
        /// The location of the ".mtl" file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MaterialtURL = NDalic.MeshVisualMaterialUrl;
        /// <summary>
        /// Path to the directory the textures (including gloss and normal) are stored in.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int TexturesPath = NDalic.MeshVisualTexturesPath;
        /// <summary>
        /// Sets the type of shading mode that the mesh will use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ShadingMode = NDalic.MeshVisualShadingMode;
        /// <summary>
        /// Whether to use mipmaps for textures or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int UseMipmapping = NDalic.MeshVisualUseMipmapping;
        /// <summary>
        /// Whether to average normals at each point to smooth textures or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int UseSoftNormals = NDalic.MeshVisualUseSoftNormals;
        /// <summary>
        /// The position, in stage space, of the point light that applies lighting to the model.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int LightPosition = NDalic.MeshVisualLightPosition;
    }

    /// <summary>
    /// This specifies properties of the PrimitiveVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PrimitiveVisualProperty
    {
        /// <summary>
        /// The specific shape to render.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Shape = NDalic.PrimitiveVisualShape;
        /// <summary>
        /// The color of the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MixColor = NDalic.PrimitiveVisualMixColor;
        /// <summary>
        /// The number of slices as you go around the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Slices = NDalic.PrimitiveVisualSlices;
        /// <summary>
        /// The number of stacks as you go down the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Stacks = NDalic.PrimitiveVisualStacks;
        /// <summary>
        /// The scale of the radius of the top circle of a conical frustum.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleTopRadius = NDalic.PrimitiveVisualScaleTopRadius;
        /// <summary>
        /// The scale of the radius of the bottom circle of a conical frustum.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleBottomRadius = NDalic.PrimitiveVisualScaleBottomRadius;
        /// <summary>
        /// The scale of the height of a conic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleHeight = NDalic.PrimitiveVisualScaleHeight;
        /// <summary>
        /// The scale of the radius of a cylinder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleRadius = NDalic.PrimitiveVisualScaleRadius;
        /// <summary>
        /// The dimensions of a cuboid. Scales in the same fashion as a 9-patch image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleDimensions = NDalic.PrimitiveVisualScaleDimensions;
        /// <summary>
        /// Determines how bevelled the cuboid should be, based off the smallest dimension.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BevelPercentage = NDalic.PrimitiveVisualBevelPercentage;
        /// <summary>
        /// Defines how smooth the bevelled edges should be.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BevelSmoothness = NDalic.PrimitiveVisualBevelSmoothness;
        /// <summary>
        /// The position, in stage space, of the point light that applies lighting to the model.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int LightPosition = NDalic.PrimitiveVisualLightPosition;
    }

    /// <summary>
    /// This specifies properties of the TextVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct TextVisualProperty
    {
        /// <summary>
        /// The text to display in UTF-8 format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Text = NDalic.TextVisualText;
        /// <summary>
        /// The requested font family to use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FontFamily = NDalic.TextVisualFontFamily;
        /// <summary>
        /// The requested font style to use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FontStyle = NDalic.TextVisualFontStyle;
        /// <summary>
        /// The size of font in points.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PointSize = NDalic.TextVisualPointSize;
        /// <summary>
        /// The single-line or multi-line layout option.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MultiLine = NDalic.TextVisualMultiLine;
        /// <summary>
        /// The line horizontal alignment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int HorizontalAlignment = NDalic.TextVisualHorizontalAlignment;
        /// <summary>
        /// The line vertical alignment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int VerticalAlignment = NDalic.TextVisualVerticalAlignment;
        /// <summary>
        /// The color of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int TextColor = NDalic.TextVisualTextColor;
        /// <summary>
        /// Whether the mark-up processing is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int EnableMarkup = NDalic.TextVisualEnableMarkup;
        /// <summary>
        /// The shadow parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Shadow = NDalic.TextVisualEnableMarkup + 1;
        /// <summary>
        /// The default underline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Underline = NDalic.TextVisualEnableMarkup + 2;
        /// <summary>
        /// The default outline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Outline = NDalic.TextVisualEnableMarkup + 3;
        /// <summary>
        /// The default text background parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Background = NDalic.TextVisualEnableMarkup + 4;
    }

    /// <summary>
    /// This specifies properties of the NpatchImageVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct NpatchImageVisualProperty
    {
        /// <summary>
        /// The URL of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int URL = NDalic.ImageVisualUrl;
        /// <summary>
        /// Fitting options, used when resizing images to fit desired dimensions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FittingMode = NDalic.ImageVisualFittingMode;
        /// <summary>
        /// Filtering options, used when resizing images to sample original pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SamplingMode = NDalic.ImageVisualSamplingMode;
        /// <summary>
        /// The desired image width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredWidth = NDalic.ImageVisualDesiredWidth;
        /// <summary>
        /// The desired image height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredHeight = NDalic.ImageVisualDesiredHeight;
        /// <summary>
        /// Whether to load the image synchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SynchronousLoading = NDalic.ImageVisualSynchronousLoading;
        /// <summary>
        /// If true, only draws the borders.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BorderOnly = NDalic.ImageVisualBorderOnly;
        /// <summary>
        /// The image area to be displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PixelArea = NDalic.ImageVisualPixelArea;
        /// <summary>
        /// The wrap mode for u coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeU = NDalic.ImageVisualWrapModeU;
        /// <summary>
        /// The wrap mode for v coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeV = NDalic.ImageVisualWrapModeV;
        /// <summary>
        /// The border of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Border = NDalic.ImageVisualWrapModeV + 1;
    }

    /// <summary>
    /// This specifies properties of the ArcVisual.
    /// </summary>
    internal struct ArcVisualProperty
    {
        /// <summary>
        /// The thickness of the arc.
        /// </summary>
        /// <remarks>The value is float type.</remarks>
        /// <remarks>This is mandatory property.</remarks>
        internal static readonly int Thickness = NDalic.ImageVisualUrl;

        /// <summary>
        /// The start angle where the arc begins in degrees.
        /// </summary>
        /// <remarks>The value is float type.</remarks>
        /// <remarks>The property of optional. The default value is 0.</remarks>
        internal static readonly int StartAngle = Thickness + 1;

        /// <summary>
        /// The sweep angle of the arc in degrees.
        /// </summary>
        /// <remarks>The value is float type.</remarks>
        /// <remarks>The property of optional. The default value is 360.</remarks>
        internal static readonly int SweepAngle = Thickness + 2;

        /// <summary>
        /// The cap style of the arc.
        /// </summary>
        /// <remarks>
        /// The value is integer type.
        /// The value 0 means butt, the arc does not extend beyond its two endpoints.
        /// The value 1 means round, the arc will be extended by a half circle with the center at the end.
        /// </remarks>
        /// <remarks>The property of optional. The default value is 0 (butt).</remarks>
        internal static readonly int Cap = Thickness + 3;
    }

    /// <summary>
    /// Enumeration for Circular alignment.
    /// The @p horizontalAlignment and @p verticalAlignment can be used to align the text within the text area.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CircularAlignment
    {
        /// <summary>
        /// Texts place at the begin of Circular direction.
        /// </summary>
        [Description("BEGIN")]
        Begin,
        /// <summary>
        /// Texts place at the center of Circular direction.
        /// </summary>
        [Description("CENTER")]
        Center,
        /// <summary>
        /// Texts place at the end of Circular direction.
        /// </summary>
        [Description("END")]
        End
    }

    /// <summary>
    /// Enumeration for Text Layout.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum TextLayout
    {
        /// <summary>
        /// SingleLine.
        /// </summary>
        [Description("singleLine")]
        SingleLine,
        /// <summary>
        /// MultiLine.
        /// </summary>
        [Description("multiLine")]
        MultiLine,
        /// <summary>
        /// Circular.
        /// </summary>
        [Description("circular")]
        Circular
    }

    /// <summary>
    /// Defines how a color is blended.
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ColorBlendingMode
    {
        /// <summary>
        ///  No blend.
        /// </summary>
        None,
        /// <summary>
        ///  The color is multiplied by another one.
        /// </summary>
        Multiply
    };
}
