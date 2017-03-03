/** Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
  namespace Constants
  {
    public enum TextureType
    {
      Texture2D     = Tizen.NUI.TextureType.TEXTURE_2D,   ///< One 2D image                            @SINCE_1_1.43
      TextureCube   = Tizen.NUI.TextureType.TEXTURE_CUBE  ///< Six 2D images arranged in a cube-shape  @SINCE_1_1.43
    }

    public enum ViewMode
    {
      Mono              = Tizen.NUI.ViewMode.MONO,                          ///< Monoscopic (single camera). This is the default @SINCE_1_0.0
      StereoHorizontal  = Tizen.NUI.ViewMode.STEREO_HORIZONTAL, ///< Stereoscopic. Frame buffer is split horizontally with the left and right camera views in their respective sides. @SINCE_1_0.0
      StereoVertical    = Tizen.NUI.ViewMode.STEREO_VERTICAL,     ///< Stereoscopic. Frame buffer is split vertically with the left camera view at the top and the right camera view at the bottom. @SINCE_1_0.0
      StereoInterlaced  = Tizen.NUI.ViewMode.STEREO_INTERLACED  ///< @DEPRECATED_1_1.19 @brief Stereoscopic. Left/Right camera views are rendered into the framebuffer on alternate frames. @SINCE_1_0.0
    }

    public enum MeshVisualShadingModeValue
    {
      TexturelessWithDiffuseLighting = Tizen.NUI.MeshVisualShadingModeValue.TEXTURELESS_WITH_DIFFUSE_LIGHTING,       ///< *Simplest*. One color that is lit by ambient and diffuse lighting. @SINCE_1_1.45
      TexturedWithSpecularLigting = Tizen.NUI.MeshVisualShadingModeValue.TEXTURED_WITH_SPECULAR_LIGHTING,         ///< Uses only the visual image textures provided with specular lighting in addition to ambient and diffuse lighting. @SINCE_1_1.45
      TexturedWithDetailedSpecularLighting = Tizen.NUI.MeshVisualShadingModeValue.TEXTURED_WITH_DETAILED_SPECULAR_LIGHTING ///< Uses all textures provided including a gloss, normal and texture map along with specular, ambient and diffuse lighting. @SINCE_1_1.45
    }



    public struct Direction
    {
      public enum Type
      {
        LeftToRight = Tizen.NUI.DirectionType.LEFT_TO_RIGHT,
        RightToLeft = Tizen.NUI.DirectionType.RIGHT_TO_LEFT
      }
    }

    public struct Visual
    {
      public enum Type
      {
        Border = Tizen.NUI.VisualType.BORDER,
        Color = Tizen.NUI.VisualType.COLOR,
        Gradient = Tizen.NUI.VisualType.GRADIENT,
        Image = Tizen.NUI.VisualType.IMAGE,
        Mesh = Tizen.NUI.VisualType.MESH,
        Primitive = Tizen.NUI.VisualType.PRIMITIVE,
        WireFrame = Tizen.NUI.VisualType.WIREFRAME,
        Text = Tizen.NUI.VisualType.TEXT
      }

      public struct Property
      {
        public static readonly int Type = NDalic.VISUAL_PROPERTY_TYPE;
        public static readonly int Shader = NDalic.VISUAL_PROPERTY_SHADER;
        public static readonly int Transform = NDalic.VISUAL_PROPERTY_TRANSFORM;
        public static readonly int PremultipliedAlpha = NDalic.VISUAL_PROPERTY_PREMULTIPLIED_ALPHA;
        public static readonly int MixColor = NDalic.VISUAL_PROPERTY_MIX_COLOR;
      }

      public struct ShaderProperty
      {
        public static readonly int VertexShader = NDalic.VISUAL_SHADER_VERTEX;
        public static readonly int FragmentShader = NDalic.VISUAL_SHADER_FRAGMENT;
        public static readonly int ShaderSubdivideGridX = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_X;
        public static readonly int ShaderSubdivideGridY = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_Y;
        public static readonly int ShaderHints = NDalic.VISUAL_SHADER_HINTS;
      }
    }

    public struct BorderVisualProperty
    {
      public static readonly int Color = NDalic.BORDER_VISUAL_COLOR;
      public static readonly int Size = NDalic.BORDER_VISUAL_SIZE;
      public static readonly int AntiAliasing = NDalic.BORDER_VISUAL_ANTI_ALIASING;
    }

    public struct ColorVisualProperty
    {
      public static readonly int MixColor = NDalic.COLOR_VISUAL_MIX_COLOR;
    }

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

    public struct ImageVisualProperty
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
    }

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

    public struct Tooltip
    {
      public struct Property
      {
        public static readonly int Content = NDalic.TOOLTIP_CONTENT;
        public static readonly int Layout = NDalic.TOOLTIP_LAYOUT;
        public static readonly int WaitTime = NDalic.TOOLTIP_WAIT_TIME;
        public static readonly int Background = NDalic.TOOLTIP_BACKGROUND;
        public static readonly int Tail = NDalic.TOOLTIP_TAIL;
        public static readonly int Position = NDalic.TOOLTIP_POSITION;
        public static readonly int HoverPointOffset = NDalic.TOOLTIP_HOVER_POINT_OFFSET;
        public static readonly int MovementThreshold = NDalic.TOOLTIP_MOVEMENT_THRESHOLD;
        public static readonly int DisappearOnMovement = NDalic.TOOLTIP_DISAPPEAR_ON_MOVEMENT;
      }

      public struct BackgroundProperty
      {
        public static readonly int Visual = NDalic.TOOLTIP_BACKGROUND_VISUAL;
        public static readonly int Border = NDalic.TOOLTIP_BACKGROUND_BORDER;
      }

      public struct TailProperty
      {
        public static readonly int Visibility = NDalic.TOOLTIP_TAIL_VISIBILITY;
        public static readonly int AboveVisual = NDalic.TOOLTIP_TAIL_ABOVE_VISUAL;
        public static readonly int BelowVisual = NDalic.TOOLTIP_TAIL_BELOW_VISUAL;
      }
    }
  } // namespace Constants
} // namesapce Dali
