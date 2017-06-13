// Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
    public enum ScrollModeType
    {
        XAxisScrollEnabled,
        XAxisSnapToInterval,
        XAxisScrollBoundary,
        YAxisScrollEnabled,
        YAxisSnapToInterval,
        YAxisScrollBoundary
    }

    /// <summary>
    /// This specifies whether the Actor uses its own color, or inherits.
    /// </summary>
    public enum ColorMode
    {
        /// <summary>
        /// Actor will use its own color.
        /// </summary>
        UseOwnColor,
        /// <summary>
        /// Actor will use its parent color.
        /// </summary>
        UseParentColor,
        /// <summary>
        /// Actor will blend its color with its parents color.
        /// </summary>
        UseOwnMultiplyParentColor,
        /// <summary>
        /// Actor will blend its alpha with its parents alpha. This means when parent fades in or out child does as well. This is the default.
        /// </summary>
        UseOwnMultiplyParentAlpha
    }

    /// <summary>
    /// This specifies the dimesion of width or heigh for size negotiation.
    /// </summary>
    public enum DimensionType
    {
        /// <summary>
        /// Width dimension
        /// </summary>
        Width = 0x1,
        /// <summary>
        /// Height dimension
        /// </summary>
        Height = 0x2,
        /// <summary>
        /// Mask to cover all flags
        /// </summary>
        AllDimensions = 0x3
    }

    /// <summary>
    /// Enumeration for the instance of how the actor and it's children will be drawn.
    /// </summary>
    public enum DrawModeType
    {
        /// <summary>
        /// The default draw-mode
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Draw the actor and its children as an overlay
        /// </summary>
        Overlay2D = 1,
        /// <summary>
        /// Will be replaced by separate ClippingMode enum. Draw the actor and its children into the stencil buffer
        /// </summary>
        Stencil = 3
    }

    /// <summary>
    /// Enumeration for size negotiation resize policies.
    /// </summary>
    public enum ResizePolicyType
    {
        /// <summary>
        /// Size is fixed as set by SetSize
        /// </summary>
        Fixed,
        /// <summary>
        /// Size is to use the actor's natural size
        /// </summary>
        /// <see cref="View.GetNaturalSize"/>
        UseNaturalSize,
        /// <summary>
        /// Size is to fill up to the actor's parent's bounds. Aspect ratio is not maintained.
        /// </summary>
        FillToParent,
        /// <summary>
        /// The actors size will be ( ParentSize * SizeRelativeToParentFactor ).
        /// </summary>
        SizeRelativeToParent,
        /// <summary>
        /// The actors size will be ( ParentSize + SizeRelativeToParentFactor ).
        /// </summary>
        SizeFixedOffsetFromParent,
        /// <summary>
        /// Size will adjust to wrap around all children
        /// </summary>
        FitToChildren,
        /// <summary>
        /// One dimension is dependent on the other
        /// </summary>
        DimensionDependency,
        /// <summary>
        /// The size will be assigned to the actor
        /// </summary>
        UseAssignedSize
    }

    /// <summary>
    /// Enumeration for policies to determine how an actor should resize itself when having its size set in size negotiation.
    /// </summary>
    public enum SizeScalePolicyType
    {
        /// <summary>
        /// Use the size that was set
        /// </summary>
        UseSizeSet,
        /// <summary>
        /// Fit within the size set maintaining natural size aspect ratio
        /// </summary>
        FitWithAspectRatio,
        /// <summary>
        /// Fit within the size set maintaining natural size aspect ratio
        /// </summary>
        FillWithAspectRatio
    }

    /// <summary>
    /// Enumeration for ClippingMode describing how this Actor's children will be clipped against it.
    /// </summary>
    public enum ClippingModeType
    {
        /// <summary>
        /// This Actor will not clip its children.
        /// </summary>
        Disabled,
        /// <summary>
        /// This Actor will clip all children to within its boundaries (the actor will also be visible itself).
        /// </summary>
        ClipChildren
    }

    /// <summary>
    /// Enumeration for type determination of how camera operates.
    /// </summary>
    public enum CameraType
    {
        /// <summary>
        /// Camera orientation is taken from CameraActor.
        /// </summary>
        FreeLook,
        /// <summary>
        /// Camera is oriented to always look at a target.
        /// </summary>
        LookAtTarget
    }

    /// <summary>
    /// Enumeration for projection modes.
    /// </summary>
    public enum ProjectionMode
    {
        /// <summary>
        /// Distance causes foreshortening; objects further from the camera appear smaller.
        /// </summary>
        PerspectiveProjection,
        /// <summary>
        /// Relative distance from the camera does not affect the size of objects.
        /// </summary>
        OrthographicProjection
    }

    /// <summary>
    /// This specifies ccustomView behaviour types.
    /// </summary>
    public enum CustomViewBehaviour
    {
        /// <summary>
        /// Use to provide default behaviour (size negotiation is on, event callbacks are not called)
        /// </summary>
        ViewBehaviourDefault = 0,
        /// <summary>
        /// True if control does not need size negotiation, i.e. it can be skipped in the algorithm
        /// </summary>
        DisableSizeNegotiation = 1 << 0,
        /// <summary>
        /// Use to provide key navigation support.
        /// </summary>
        RequiresKeyboardNavigationSupport = 1 << 5,
        /// <summary>
        /// Use to make style change event disabled.
        /// </summary>
        DisableStyleChangeSignals = 1 << 6,
        [EditorBrowsable(EditorBrowsableState.Never)]
        LastViewBehaviourFlag
    }

    public enum DeviceClassType
    {
        None,
        Seat,
        Keyboard,
        Mouse,
        Touch,
        Pen,
        Pointer,
        Gamepad
    }

    /// <summary>
    /// This specifies all the property types. <br>
    /// Enumeration for the property types supported.
    /// </summary>
    public enum PropertyType
    {
        /// <summary>
        /// No type
        /// </summary>
        None,
        /// <summary>
        /// A boolean type
        /// </summary>
        Boolean,
        /// <summary>
        /// A float type
        /// </summary>
        Float,
        /// <summary>
        /// An integer type
        /// </summary>
        Integer,
        /// <summary>
        /// a vector array of size=2 with float precision
        /// </summary>
        Vector2,
        /// <summary>
        /// a vector array of size=3 with float precision
        /// </summary>
        Vector3,
        /// <summary>
        /// a vector array of size=4 with float precision
        /// </summary>
        Vector4,
        /// <summary>
        /// a 3x3 matrix
        /// </summary>
        Matrix3,
        /// <summary>
        /// a 4x4 matrix
        /// </summary>
        Matrix,
        /// <summary>
        /// an integer array of size=4
        /// </summary>
        Rectangle,
        /// <summary>
        /// either a quaternion or an axis angle rotation
        /// </summary>
        Rotation,
        /// <summary>
        /// A string type
        /// </summary>
        String,
        /// <summary>
        /// an array of PropertyValue
        /// </summary>
        Array,
        /// <summary>
        /// a string key to PropertyValue mapping
        /// </summary>
        Map
    }

    /// <summary>
    /// This specifies the property access mode types. <br>
    /// Enumeration for the access mode for custom properties.
    /// </summary>
    public enum PropertyAccessMode
    {
        /// <summary>
        /// if the property is read-only
        /// </summary>
        ReadOnly,
        /// <summary>
        /// If the property is read/writeable
        /// </summary>
        ReadWrite,
        /// <summary>
        /// If the property can be animated or constrained
        /// </summary>
        Animatable,
        /// <summary>
        /// The number of access modes
        /// </summary>
        AccessModeCount
    }

    /// <summary>
    /// Types of style change. Enumeration for StyleChange type.
    /// </summary>
    public enum StyleChangeType
    {
        /// <summary>
        /// Denotes that the default font has changed.
        /// </summary>
        DefaultFontChange,
        /// <summary>
        /// Denotes that the default font size has changed.
        /// </summary>
        DefaultFontSizeChange,
        /// <summary>
        /// Denotes that the theme has changed.
        /// </summary>
        ThemeChange
    }

    /// <summary>
    /// Enumeration for horizontal alignment types.
    /// </summary>
    public enum HorizontalAlignmentType
    {
        /// <summary>
        /// Align horizontally left
        /// </summary>
        Left,
        /// <summary>
        /// Align horizontally center
        /// </summary>
        Center,
        /// <summary>
        /// Align horizontally right
        /// </summary>
        Right
    }

    /// <summary>
    /// Enumeration for vertical alignment types.
    /// </summary>
    public enum VerticalAlignmentType
    {
        /// <summary>
        /// Align vertically top
        /// </summary>
        Top,
        /// <summary>
        /// Align vertically center
        /// </summary>
        Center,
        /// <summary>
        /// Align vertically bottom
        /// </summary>
        Bottom
    }

    /// <summary>
    /// Enumeration for point state type.
    /// </summary>
    public enum PointStateType
    {
        /// <summary>
        /// Touch or hover started
        /// </summary>
        Started,
        /// <summary>
        /// Touch or hover finished
        /// </summary>
        Finished,
        /// <summary>
        /// Screen touched
        /// </summary>
        Down = Started,
        /// <summary>
        /// Touch stopped
        /// </summary>
        Up = Finished,
        /// <summary>
        /// Finger dragged or hovered
        /// </summary>
        Motion,
        /// <summary>
        /// Leave the boundary of an actor
        /// </summary>
        Leave,
        /// <summary>
        /// No change from last event. <br>
        /// Useful when a multi-point event occurs where all points are sent but indicates that this particular point has not changed since the last time.
        /// </summary>
        Stationary,
        /// <summary>
        /// A system event has occurred which has interrupted the touch or hover event sequence.
        /// </summary>
        Interrupted
    }

    /// <summary>
    /// Enumeration for the text horizontal aligning.
    /// </summary>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Texts place at the begin of horizontal direction.
        /// </summary>
        Begin,
        /// <summary>
        /// Texts place at the center of horizontal direction.
        /// </summary>
        Center,
        /// <summary>
        /// Texts place at the end of horizontal direction.
        /// </summary>
        End
    }

    /// <summary>
    /// Enumeration for the text horizontal aligning.
    /// </summary>
    public enum VerticalAlignment
    {
        /// <summary>
        /// Texts place at the top of vertical direction.
        /// </summary>
        Top,
        /// <summary>
        /// Texts place at the center of vertical direction.
        /// </summary>
        Center,
        /// <summary>
        /// Texts place at the bottom of vertical direction.
        /// </summary>
        Bottom
    }

    /// <summary>
    /// This specifies wrap mode types <br>
    /// WrapModeU and WrapModeV separately decide how the texture should be sampled when the u and v coordinate exceeds the range of 0.0 to 1.0.
    /// </summary>
    public enum WrapModeType
    {
        /// <summary>
        /// Defualt value
        /// </summary>
        Default = 0,
        /// <summary>
        /// Clamp to edge
        /// </summary>
        ClampToEdge,
        /// <summary>
        /// Repeat
        /// </summary>
        Repeat,
        /// <summary>
        /// Mirrored repeat
        /// </summary>
        MirroredRepeat
    }

    /// <summary>
    /// The type of coordinate system for certain attributes of the points in a gradient.
    /// </summary>
    public enum GradientVisualUnitsType
    {
        /// <summary>
        /// Uses the normals for the start, end & center points, i.e. top-left is (-0.5, -0.5) and bottom-right is (0.5, 0.5).
        /// </summary>
        ObjectBoundingBox,
        /// <summary>
        /// Uses the user coordinates for the start, end & center points, i.e. in a 200 by 200 control, top-left is (0, 0) and bottom-right is (200, 200).
        /// </summary>
        UserSpace
    }

    /// <summary>
    /// This specifies SpreadMethod types.<br>
    /// SpreadMethod defines what happens if the gradient starts or ends inside the bounds of the target rectangle.<br>
    /// </summary>
    public enum GradientVisualSpreadMethodType
    {
        /// <summary>
        /// Uses the terminal colors of the gradient to fill the remainder of the quad.
        /// </summary>
        Pad,
        /// <summary>
        /// Reflect the gradient pattern start-to-end, end-to-start, start-to-end etc. until the quad is filled.
        /// </summary>
        Reflect,
        /// <summary>
        /// Repeat the gradient pattern start-to-end, start-to-end, start-to-end etc. until the quad is filled.
        /// </summary>
        Repeat
    }

    /// <summary>
    /// The shading mode used by MeshVisual.
    /// </summary>
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
        /// Uses all textures provided including a gloss, normal and texture map along with specular, ambient and diffuse lighting.
        /// </summary>
        TexturedWithDetailedSpecularLighting
    }

    /// <summary>
    /// The primitive shape to render as a PrimitiveVisual.
    /// </summary>
    public enum PrimitiveVisualShapeType
    {
        /// <summary>
        /// A perfectly round geometrical object in three-dimensional space.
        /// </summary>
        Sphere,
        /// <summary>
        /// The area bound between two circles, i.e. a cone with the tip removed.
        /// </summary>
        ConicalFrustrum,
        /// <summary>
        /// Equivalent to a conical frustrum with top radius of zero.
        /// </summary>Equivalent to a conical frustrum with top radius of zero.
        Cone,
        /// <summary>
        /// Equivalent to a conical frustrum with top radius of zero.
        /// </summary>
        Cylinder,
        /// <summary>
        /// Equivalent to a conical frustrum with equal radii for the top and bottom circles.
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
    /// This specifies fitting mode types. Fitting options, used when resizing images to fit desired dimensions.<br>
    /// A fitting mode controls the region of a loaded image to be mapped to the desired image rectangle.<br>
    /// All fitting modes preserve the aspect ratio of the image contents.<br>
    /// </summary>
    public enum FittingModeType
    {
        /// <summary>
        /// Full-screen image display: Limit loaded image resolution to device resolution using ShrinkToFit mode.
        /// </summary>
        ShrinkToFit,
        /// <summary>
        /// Thumbnail gallery grid: Limit loaded image resolution to screen tile using ScaleToFill mode.
        /// </summary>
        ScaleToFill,
        /// <summary>
        /// Image columns: Limit loaded image resolution to column width using FitWidth mode.
        /// </summary>
        FitWidth,
        /// <summary>
        /// Image rows: Limit loaded image resolution to row height using FitHeight mode.
        /// </summary>
        FitHeight
    }

    /// <summary>
    /// This specifies sampling mode types. Filtering options, used when resizing images to sample original pixels.<br>
    /// A SamplingMode controls how pixels in an input image are sampled and combined to generate each pixel of a destination image during a scaling.<br>
    /// NoFilter and Box modes do not guarantee that the output pixel array exactly matches the rectangle specified by the desired dimensions and FittingMode,<br>
    /// but all other filter modes do if the desired dimensions are `<=` the raw dimensions of the input image file.<br>
    /// </summary>
    public enum SamplingModeType
    {
        /// <summary>
        /// Iteratively box filter to generate an image of 1/2, 1/4, 1/8, etc width and height and approximately the desired size. <br>
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
        /// Iteratively box filter to generate an image of 1/2, 1/4, 1/8 etc width and height and approximately the desired size, <br>
        /// then for each output pixel, read one pixel from the last level of box filtering.<br>
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
    /// This specifies policy types that could be used by the transform for the offset or size.
    /// </summary>
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
        /// The anchor-point of the visual
        /// </summary>
        AnchorPoint,
        /// <summary>
        /// Whether the x or y OFFSET values are relative (percentage [0.0f to 1.0f] of the control) or absolute (in world units).
        /// </summary>
        OffsetPolicy,
        /// <summary>
        /// Whether the width or height SIZE values are relative (percentage [0.0f to 1.0f] of the control) or absolute (in world units).
        /// </summary>
        SizePolicy
    }

    /// <summary>
    /// This specifies visual types.
    /// </summary>
    public struct Visual
    {
        /// <summary>
        /// The index for the visual type.
        /// </summary>
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
            /// Renders a simple 3D shape, such as a cube or sphere.
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
            /// Renders an n-patch image.
            /// </summary>
            NPatch,
            /// <summary>
            /// Renders an SVG image.
            /// </summary>
            SVG,
            /// <summary>
            /// Renders a animated image. (Animated GIF)
            /// </summary>
            AnimatedImage
        }

        /// <summary>
        /// This specifies visual properties.
        /// </summary>
        public struct Property
        {
            public static readonly int Type = NDalic.VISUAL_PROPERTY_TYPE;
            public static readonly int Shader = NDalic.VISUAL_PROPERTY_SHADER;
            public static readonly int Transform = NDalic.VISUAL_PROPERTY_TRANSFORM;
            public static readonly int PremultipliedAlpha = NDalic.VISUAL_PROPERTY_PREMULTIPLIED_ALPHA;
            public static readonly int MixColor = NDalic.VISUAL_PROPERTY_MIX_COLOR;
            public static readonly int Opacity = NDalic.VISUAL_PROPERTY_MIX_COLOR + 1;
        }

        /// <summary>
        /// This specifies shader properties.
        /// </summary>
        public struct ShaderProperty
        {
            public static readonly int VertexShader = NDalic.VISUAL_SHADER_VERTEX;
            public static readonly int FragmentShader = NDalic.VISUAL_SHADER_FRAGMENT;
            public static readonly int ShaderSubdivideGridX = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_X;
            public static readonly int ShaderSubdivideGridY = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_Y;
            public static readonly int ShaderHints = NDalic.VISUAL_SHADER_HINTS;
        }

        /// <summary>
        /// This specifies Visaul align types.
        /// </summary>
        public enum AlignType
        {
            TopBegin = 0,
            TopCenter,
            TopEnd,
            CenterBegin,
            Center,
            CenterEnd,
            BottomBegin,
            BottomCenter,
            BottomEnd
        }
    }

    /// <summary>
    /// This specifies properties of BorderVisual.
    /// </summary>
    public struct BorderVisualProperty
    {
        public static readonly int Color = NDalic.BORDER_VISUAL_COLOR;
        public static readonly int Size = NDalic.BORDER_VISUAL_SIZE;
        public static readonly int AntiAliasing = NDalic.BORDER_VISUAL_ANTI_ALIASING;
    }

    /// <summary>
    /// This specifies properties of ColorVisual.
    /// </summary>
    public struct ColorVisualProperty
    {
        public static readonly int MixColor = NDalic.COLOR_VISUAL_MIX_COLOR;
    }

    /// <summary>
    /// This specifies properties of GradientVisual.
    /// </summary>
    public struct GradientVisualProperty
    {
        public static readonly int StartPosition = NDalic.GRADIENT_VISUAL_START_POSITION;
        public static readonly int EndPosition = NDalic.GRADIENT_VISUAL_END_POSITION;
        public static readonly int Center = NDalic.GRADIENT_VISUAL_CENTER;
        public static readonly int Radius = NDalic.GRADIENT_VISUAL_RADIUS;
        public static readonly int StopOffset = NDalic.GRADIENT_VISUAL_STOP_OFFSET;
        public static readonly int StopColor = NDalic.GRADIENT_VISUAL_STOP_COLOR;
        public static readonly int Units = NDalic.GRADIENT_VISUAL_UNITS;
        public static readonly int SpreadMethod = NDalic.GRADIENT_VISUAL_SPREAD_METHOD;
    }

    /// <summary>
    /// This specifies properties of ImageVisual.
    /// </summary>
    public struct ImageVisualProperty
    {
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;
        public static readonly int AlphaMaskURL = NDalic.IMAGE_VISUAL_ALPHA_MASK_URL;
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;
        public static readonly int Border = NDalic.IMAGE_VISUAL_BORDER;
    }

    /// <summary>
    /// This specifies properties of MeshVisual.
    /// </summary>
    public struct MeshVisualProperty
    {
        public static readonly int ObjectURL = NDalic.MESH_VISUAL_OBJECT_URL;
        public static readonly int MaterialtURL = NDalic.MESH_VISUAL_MATERIAL_URL;
        public static readonly int TexturesPath = NDalic.MESH_VISUAL_TEXTURES_PATH;
        public static readonly int ShadingMode = NDalic.MESH_VISUAL_SHADING_MODE;
        public static readonly int UseMipmapping = NDalic.MESH_VISUAL_USE_MIPMAPPING;
        public static readonly int UseSoftNormals = NDalic.MESH_VISUAL_USE_SOFT_NORMALS;
        public static readonly int LightPosition = NDalic.MESH_VISUAL_LIGHT_POSITION;
    }

    /// <summary>
    /// This specifies properties of PrimitiveVisual.
    /// </summary>
    public struct PrimitiveVisualProperty
    {
        public static readonly int Shape = NDalic.PRIMITIVE_VISUAL_SHAPE;
        public static readonly int MixColor = NDalic.PRIMITIVE_VISUAL_MIX_COLOR;
        public static readonly int Slices = NDalic.PRIMITIVE_VISUAL_SLICES;
        public static readonly int Stacks = NDalic.PRIMITIVE_VISUAL_STACKS;
        public static readonly int ScaleTopRadius = NDalic.PRIMITIVE_VISUAL_SCALE_TOP_RADIUS;
        public static readonly int ScaleBottomRadius = NDalic.PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS;
        public static readonly int ScaleHeight = NDalic.PRIMITIVE_VISUAL_SCALE_HEIGHT;
        public static readonly int ScaleRadius = NDalic.PRIMITIVE_VISUAL_SCALE_RADIUS;
        public static readonly int ScaleDimensions = NDalic.PRIMITIVE_VISUAL_SCALE_DIMENSIONS;
        public static readonly int BevelPercentage = NDalic.PRIMITIVE_VISUAL_BEVEL_PERCENTAGE;
        public static readonly int BevelSmoothness = NDalic.PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS;
        public static readonly int LightPosition = NDalic.PRIMITIVE_VISUAL_LIGHT_POSITION;
    }

    /// <summary>
    /// This specifies properties of TextVisual.
    /// </summary>
    public struct TextVisualProperty
    {
        public static readonly int Text = NDalic.TEXT_VISUAL_TEXT;
        public static readonly int FontFamily = NDalic.TEXT_VISUAL_FONT_FAMILY;
        public static readonly int FontStyle = NDalic.TEXT_VISUAL_FONT_STYLE;
        public static readonly int PointSize = NDalic.TEXT_VISUAL_POINT_SIZE;
        public static readonly int MultiLine = NDalic.TEXT_VISUAL_MULTI_LINE;
        public static readonly int HorizontalAlignment = NDalic.TEXT_VISUAL_HORIZONTAL_ALIGNMENT;
        public static readonly int VerticalAlignment = NDalic.TEXT_VISUAL_VERTICAL_ALIGNMENT;
        public static readonly int TextColor = NDalic.TEXT_VISUAL_TEXT_COLOR;
        public static readonly int EnableMarkup = NDalic.TEXT_VISUAL_ENABLE_MARKUP;
    }

    /// <summary>
    /// This specifies properties of NpatchImageVisual.
    /// </summary>
    public struct NpatchImageVisualProperty
    {
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;
        public static readonly int Border = NDalic.IMAGE_VISUAL_WRAP_MODE_V + 1;
    }

    /// <summary>
    /// HiddenInput Property.
    /// </summary>
    public struct HiddenInputProperty
    {
        public static readonly int Mode = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_MODE_get();
        public static readonly int SubstituteCharacter = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get();
        public static readonly int SubstituteCount = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get();
        public static readonly int ShowDuration = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_SHOW_DURATION_get();
    }

    /// <summary>
    /// The type for HiddenInput mode.
    /// </summary>
    public enum HiddenInputModeType
    {
        /// <summary>
        /// Don't hide text.
        /// </summary>
        HideNone,
        /// <summary>
        /// Hide all the input text.
        /// </summary>
        HideAll,
        /// <summary>
        /// Hide n characters from start.
        /// </summary>
        HideCount,
        /// <summary>
        /// Show n characters from start.
        /// </summary>
        ShowCount,
        /// <summary>
        /// Show last character for the duration(use ShowDuration property to modify duration).
        /// </summary>
        ShowLastCharacter
    }

    /// <summary>
    /// ParentOrigin constants.
    /// </summary>
    public struct ParentOrigin
    {
        public static float Top
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Bottom
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Left
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Right
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Middle
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// AnchorPoint constants.
    /// </summary>
    public struct PivotPoint
    {
        public static float Top
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Bottom
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Left
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Right
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Middle
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
    /// <summary>
    /// PositionAxis constants.
    /// </summary>
    public struct PositionAxis
    {
        public static Position X
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_XAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position Y
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_YAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position Z
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ZAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position NegativeX
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_XAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position NegativeY
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_YAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position NegativeZ
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_ZAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// Auto scrolling stop behaviour.
    /// </summary>
    public enum AutoScrollStopMode
    {
        /// <summary>
        /// Stop animation after current loop finished.
        /// </summary>
        FinishLoop,
        /// <summary>
        /// Stop animation immediatly and reset position.
        /// </summary>
        Immediate
    }

    /// <summary>
    /// An enum of screen mode.
    /// </summary>
    public enum ScreenMode
    {
        /// <summary>
        /// The mode which turns the screen off after a timeout.
        /// </summary>
        Default,
        /// <summary>
        /// The mode which keeps the screen turned on.
        /// </summary>
        AlwaysOn
    }

    /// <summary>
    /// An enum of notification window's priority level.
    /// </summary>
    public enum NotificationLevel
    {
        /// <summary>
        /// No notification level.<br>
        /// Default level.<br>
        /// This value makes the notification window place in the layer of the normal window.
        /// </summary>
        None = -1,
        /// <summary>
        /// Base nofitication level.
        /// </summary>
        Base = 10,
        /// <summary>
        /// Medium notification level than base.
        /// </summary>
        Medium = 20,
        /// <summary>
        /// Higher notification level than medium.
        /// </summary>
        High = 30,
        /// <summary>
        /// The highest notification level.
        /// </summary>
        Top = 40
    }

    /// <summary>
    /// An enum of Window types.
    /// </summary>
    public enum WindowType
    {
        /// <summary>
        /// A default window type.<br>
        /// Indicates a normal, top-level window.
        /// Almost every window will be created with this type.
        /// </summary>
        Normal,
        /// <summary>
        /// A notification window, like a warning about battery life or a new E-Mail received.
        /// </summary>
        Notification,
        /// <summary>
        /// A persistent utility window, like a toolbox or palette.
        /// </summary>
        Utility,
        /// <summary>
        /// Used for simple dialog windows.
        /// </summary>
        Dialog
    }

    public enum DisposeTypes
    {
        Explicit,   //Called By User
        Implicit,   //Called by DisposeQueue
    }




    //will be removed/deprecated
    public struct AnchorPoint
    {
        public static float Top
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Bottom
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Left
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Right
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static float Middle
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// An enum of scroll state of text eidtor.
    /// </summary>
    public enum ScrollState
    {
        /// <summary>
        /// Scrolling is started.
        /// </summary>
        Started,

        /// <summary>
        /// Scrolling is finished.
        /// </summary>
        Finished
    }

}
