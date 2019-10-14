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
    /// Enumeration for the text horizontal aligning.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
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
        FitHeight
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
        /// Equivalent to a conical frustrum with the top radius of zero.
        /// </summary>Equivalent to a conical frustrum with the top radius of zero.
        Cone,
        /// <summary>
        /// Equivalent to a conical frustrum with the top radius of zero.
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
        Fill
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
        SizePolicy
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
            AnimatedImage
        }

        /// <summary>
        /// This specifies visual properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public struct Property
        {
            /// <summary>
            /// Type.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Type = NDalic.VISUAL_PROPERTY_TYPE;
            /// <summary>
            /// Shader.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Shader = NDalic.VISUAL_PROPERTY_SHADER;
            /// <summary>
            /// Transform.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Transform = NDalic.VISUAL_PROPERTY_TRANSFORM;
            /// <summary>
            /// PremultipliedAlpha.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int PremultipliedAlpha = NDalic.VISUAL_PROPERTY_PREMULTIPLIED_ALPHA;
            /// <summary>
            /// MixColor.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int MixColor = NDalic.VISUAL_PROPERTY_MIX_COLOR;
            /// <summary>
            /// Opacity.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Opacity = NDalic.VISUAL_PROPERTY_MIX_COLOR + 1;
            /// <summary>
            /// The fitting mode of the visual.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public static readonly int VisualFittingMode = NDalic.VISUAL_PROPERTY_MIX_COLOR + 2;
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
            public static readonly int VertexShader = NDalic.VISUAL_SHADER_VERTEX;
            /// <summary>
            /// Fragment shader code
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int FragmentShader = NDalic.VISUAL_SHADER_FRAGMENT;
            /// <summary>
            /// How to subdivide the grid along X
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderSubdivideGridX = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_X;
            /// <summary>
            /// How to subdivide the grid along Y
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderSubdivideGridY = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_Y;
            /// <summary>
            /// Bitmask of hints
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderHints = NDalic.VISUAL_SHADER_HINTS;
        }

        /// <summary>
        /// This specifies visaul align types.
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
        public static readonly int Color = NDalic.BORDER_VISUAL_COLOR;
        /// <summary>
        /// The width of the border (in pixels).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Size = NDalic.BORDER_VISUAL_SIZE;
        /// <summary>
        /// Whether anti-aliasing of the border is required.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int AntiAliasing = NDalic.BORDER_VISUAL_ANTI_ALIASING;
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
        public static readonly int MixColor = NDalic.COLOR_VISUAL_MIX_COLOR;
        /// <summary>
        /// Whether to render if the MixColor is transparent.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int RenderIfTransparent = NDalic.COLOR_VISUAL_MIX_COLOR + 1;
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
        public static readonly int StartPosition = NDalic.GRADIENT_VISUAL_START_POSITION;
        /// <summary>
        /// The end position of a linear gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int EndPosition = NDalic.GRADIENT_VISUAL_END_POSITION;
        /// <summary>
        /// The center point of a radial gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Center = NDalic.GRADIENT_VISUAL_CENTER;
        /// <summary>
        /// The size of the radius of a radial gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Radius = NDalic.GRADIENT_VISUAL_RADIUS;
        /// <summary>
        /// All the stop offsets.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StopOffset = NDalic.GRADIENT_VISUAL_STOP_OFFSET;
        /// <summary>
        /// The color at the stop offsets.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StopColor = NDalic.GRADIENT_VISUAL_STOP_COLOR;
        /// <summary>
        /// Defines the coordinate system for certain attributes of the points in a gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Units = NDalic.GRADIENT_VISUAL_UNITS;
        /// <summary>
        /// Indicates what happens if the gradient starts or ends inside the bounds of the target rectangle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SpreadMethod = NDalic.GRADIENT_VISUAL_SPREAD_METHOD;
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
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;

        /// <summary>
        /// Fitting options, used when resizing images to fit desired dimensions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;

        /// <summary>
        /// Filtering options, used when resizing images to sample original pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;

        /// <summary>
        /// The desired image width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;

        /// <summary>
        /// The desired image height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;

        /// <summary>
        /// Whether to load the image synchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;

        /// <summary>
        /// If true, only draws the borders.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;

        /// <summary>
        /// The image area to be displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;

        /// <summary>
        /// The wrap mode for u coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;

        /// <summary>
        /// The wrap mode for v coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;

        /// <summary>
        /// The border of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Border = NDalic.IMAGE_VISUAL_BORDER;

        /// <summary>
        /// Whether to use the texture atlas.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Atlasing = NDalic.IMAGE_VISUAL_BORDER + 1;

        /// <summary>
        /// The URL of the alpha mask image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int AlphaMaskURL = NDalic.IMAGE_VISUAL_ALPHA_MASK_URL;

        /// <summary>
        /// Defines the batch size for pre-loading images in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int BatchSize = NDalic.IMAGE_VISUAL_BATCH_SIZE;

        /// <summary>
        /// Defines the cache size for loading images in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int CacheSize = NDalic.IMAGE_VISUAL_CACHE_SIZE;

        /// <summary>
        /// The number of milliseconds between each frame in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int FrameDelay = NDalic.IMAGE_VISUAL_FRAME_DELAY;

        /// <summary>
        /// The scale factor to apply to the content image before masking.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int MaskContentScale = NDalic.IMAGE_VISUAL_MASK_CONTENT_SCALE;

        /// <summary>
        /// Whether to crop image to mask or scale mask to fit image
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int CropToMask = NDalic.IMAGE_VISUAL_CROP_TO_MASK;

        /// <summary>
        /// The policy to determine when an image should be loaded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int LoadPolicy = NDalic.IMAGE_VISUAL_LOAD_POLICY;

        /// <summary>
        /// The policy to determine when an image should no longer be cached.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int ReleasePolicy = NDalic.IMAGE_VISUAL_RELEASE_POLICY;

        /// <summary>
        /// Determines if image orientation should be corrected so that the image displays as it was intended.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int OrientationCorrection = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION;

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int AuxiliaryImageURL = NDalic.IMAGE_VISUAL_AUXILIARY_IMAGE_URL;

        /// <summary>
        /// Alpha value for the auxiliary image, without affecting the underlying NPatch image
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int AuxiliaryImageAlpha = NDalic.IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA;

        /// <summary>
        /// The number of times the AnimatedImageVisual will be looped.
        /// The default is -1. If the value is less than 0, loop unlimited. Otherwise, loop loopCount times.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int LoopCount = NDalic.IMAGE_VISUAL_LOOP_COUNT;

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
        public static readonly int PlayRange = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 4;

        /// <summary>
        /// @brief The playing state the AnimatedVectorImageVisual will use.
        /// @details Name "playState", type PlayState (Property::INTEGER)
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Hidden API (Inhouse API)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int PlayState = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 5;

        /// <summary>
        /// @brief The current frame number the AnimatedVectorImageVisual will use.
        /// @details Name "currentFrameNumber", Type Property::INTEGER, between[0, the maximum frame number] or between the play range if specified
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int CurrentFrameNumber = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 6;

        /// <summary>
        /// @brief The total frame number the AnimatedVectorImageVisual will use.
        /// @details Name "totalFrameNumber", Type Property::INTEGER.
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int TotalFrameNumber = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 7;

        /// <summary>
        /// @brief  The stop behavior the AnimatedVectorImageVisual will use.
        /// @details Name "stopBehavior", Type StopBehavior::Type (Property::INTEGER)
        /// @note Default value is StopBehavior::CURRENT_FRAME.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int StopBehavior = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 8;

        /// <summary>
        /// @brief  The looping mode the AnimatedVectorImageVisual will use.
        /// @details Name "loopingMode", Type LoopingMode::Type (Property::INTEGER) 
        /// @note Default value is LoopingMode::RESTART.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int LoopingMode = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 9;
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
        public static readonly int ObjectURL = NDalic.MESH_VISUAL_OBJECT_URL;
        /// <summary>
        /// The location of the ".mtl" file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MaterialtURL = NDalic.MESH_VISUAL_MATERIAL_URL;
        /// <summary>
        /// Path to the directory the textures (including gloss and normal) are stored in.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int TexturesPath = NDalic.MESH_VISUAL_TEXTURES_PATH;
        /// <summary>
        /// Sets the type of shading mode that the mesh will use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ShadingMode = NDalic.MESH_VISUAL_SHADING_MODE;
        /// <summary>
        /// Whether to use mipmaps for textures or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int UseMipmapping = NDalic.MESH_VISUAL_USE_MIPMAPPING;
        /// <summary>
        /// Whether to average normals at each point to smooth textures or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int UseSoftNormals = NDalic.MESH_VISUAL_USE_SOFT_NORMALS;
        /// <summary>
        /// The position, in stage space, of the point light that applies lighting to the model.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int LightPosition = NDalic.MESH_VISUAL_LIGHT_POSITION;
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
        public static readonly int Shape = NDalic.PRIMITIVE_VISUAL_SHAPE;
        /// <summary>
        /// The color of the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MixColor = NDalic.PRIMITIVE_VISUAL_MIX_COLOR;
        /// <summary>
        /// The number of slices as you go around the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Slices = NDalic.PRIMITIVE_VISUAL_SLICES;
        /// <summary>
        /// The number of stacks as you go down the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Stacks = NDalic.PRIMITIVE_VISUAL_STACKS;
        /// <summary>
        /// The scale of the radius of the top circle of a conical frustrum.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleTopRadius = NDalic.PRIMITIVE_VISUAL_SCALE_TOP_RADIUS;
        /// <summary>
        /// The scale of the radius of the bottom circle of a conical frustrum.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleBottomRadius = NDalic.PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS;
        /// <summary>
        /// The scale of the height of a conic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleHeight = NDalic.PRIMITIVE_VISUAL_SCALE_HEIGHT;
        /// <summary>
        /// The scale of the radius of a cylinder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleRadius = NDalic.PRIMITIVE_VISUAL_SCALE_RADIUS;
        /// <summary>
        /// The dimensions of a cuboid. Scales in the same fashion as a 9-patch image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleDimensions = NDalic.PRIMITIVE_VISUAL_SCALE_DIMENSIONS;
        /// <summary>
        /// Determines how bevelled the cuboid should be, based off the smallest dimension.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BevelPercentage = NDalic.PRIMITIVE_VISUAL_BEVEL_PERCENTAGE;
        /// <summary>
        /// Defines how smooth the bevelled edges should be.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BevelSmoothness = NDalic.PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS;
        /// <summary>
        /// The position, in stage space, of the point light that applies lighting to the model.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int LightPosition = NDalic.PRIMITIVE_VISUAL_LIGHT_POSITION;
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
        public static readonly int Text = NDalic.TEXT_VISUAL_TEXT;
        /// <summary>
        /// The requested font family to use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FontFamily = NDalic.TEXT_VISUAL_FONT_FAMILY;
        /// <summary>
        /// The requested font style to use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FontStyle = NDalic.TEXT_VISUAL_FONT_STYLE;
        /// <summary>
        /// The size of font in points.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PointSize = NDalic.TEXT_VISUAL_POINT_SIZE;
        /// <summary>
        /// The single-line or multi-line layout option.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MultiLine = NDalic.TEXT_VISUAL_MULTI_LINE;
        /// <summary>
        /// The line horizontal alignment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int HorizontalAlignment = NDalic.TEXT_VISUAL_HORIZONTAL_ALIGNMENT;
        /// <summary>
        /// The line vertical alignment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int VerticalAlignment = NDalic.TEXT_VISUAL_VERTICAL_ALIGNMENT;
        /// <summary>
        /// The color of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int TextColor = NDalic.TEXT_VISUAL_TEXT_COLOR;
        /// <summary>
        /// Whether the mark-up processing is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int EnableMarkup = NDalic.TEXT_VISUAL_ENABLE_MARKUP;
        /// <summary>
        /// The shadow parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Shadow = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 1;
        /// <summary>
        /// The default underline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Underline = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 2;
        /// <summary>
        /// The default outline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Outline = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 3;
        /// <summary>
        /// The default text background parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Background = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 4;
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
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;
        /// <summary>
        /// Fitting options, used when resizing images to fit desired dimensions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;
        /// <summary>
        /// Filtering options, used when resizing images to sample original pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;
        /// <summary>
        /// The desired image width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;
        /// <summary>
        /// The desired image height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;
        /// <summary>
        /// Whether to load the image synchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;
        /// <summary>
        /// If true, only draws the borders.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;
        /// <summary>
        /// The image area to be displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;
        /// <summary>
        /// The wrap mode for u coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;
        /// <summary>
        /// The wrap mode for v coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;
        /// <summary>
        /// The border of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Border = NDalic.IMAGE_VISUAL_WRAP_MODE_V + 1;
    }
}
