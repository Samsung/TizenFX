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

namespace NUI 
{
  namespace Constants
  {

    public enum TextureType 
    {
      Texture2D     = NUI.TextureType.TEXTURE_2D,   ///< One 2D image                            @SINCE_1_1.43
      TextureCube   = NUI.TextureType.TEXTURE_CUBE  ///< Six 2D images arranged in a cube-shape  @SINCE_1_1.43
    }

    public enum ViewMode 
    {
      Mono              = NUI.ViewMode.MONO,                          ///< Monoscopic (single camera). This is the default @SINCE_1_0.0
      StereoHorizontal  = NUI.ViewMode.STEREO_HORIZONTAL, ///< Stereoscopic. Frame buffer is split horizontally with the left and right camera views in their respective sides. @SINCE_1_0.0
      StereoVertical    = NUI.ViewMode.STEREO_VERTICAL,     ///< Stereoscopic. Frame buffer is split vertically with the left camera view at the top and the right camera view at the bottom. @SINCE_1_0.0
      StereoInterlaced  = NUI.ViewMode.STEREO_INTERLACED  ///< @DEPRECATED_1_1.19 @brief Stereoscopic. Left/Right camera views are rendered into the framebuffer on alternate frames. @SINCE_1_0.0
    }

    public enum MeshVisualShadingModeValue
    {
      TexturelessWithDiffuseLighting = NUI.MeshVisualShadingModeValue.TEXTURELESS_WITH_DIFFUSE_LIGHTING,       ///< *Simplest*. One color that is lit by ambient and diffuse lighting. @SINCE_1_1.45
      TexturedWithSpecularLigting = NUI.MeshVisualShadingModeValue.TEXTURED_WITH_SPECULAR_LIGHTING,         ///< Uses only the visual image textures provided with specular lighting in addition to ambient and diffuse lighting. @SINCE_1_1.45
      TexturedWithDetailedSpecularLighting = NUI.MeshVisualShadingModeValue.TEXTURED_WITH_DETAILED_SPECULAR_LIGHTING ///< Uses all textures provided including a gloss, normal and texture map along with specular, ambient and diffuse lighting. @SINCE_1_1.45
    }

    public enum ProjectionMode
    {
      PerspectiveProjection  = NUI.ProjectionMode.PERSPECTIVE_PROJECTION,      ///< Distance causes foreshortening; objects further from the camera appear smaller @SINCE_1_0.0
      OrthographicProjection = NUI.ProjectionMode.ORTHOGRAPHIC_PROJECTION      ///< Relative distance from the camera does not affect the size of objects @SINCE_1_0.0
    }

    public struct ParentOrigin
    {
      public static readonly float Top = NDalic.ParentOriginTop;
      public static readonly float Bottom = NDalic.ParentOriginBottom;
      public static readonly float Left = NDalic.ParentOriginLeft;
      public static readonly float Right = NDalic.ParentOriginRight;
      public static readonly float Middle = NDalic.ParentOriginMiddle;
      public static readonly NUI.Vector3 TopLeft = NDalic.ParentOriginTopLeft;
      public static readonly NUI.Vector3 TopCenter = NDalic.ParentOriginTopCenter;
      public static readonly NUI.Vector3 TopRight = NDalic.ParentOriginTopRight;
      public static readonly NUI.Vector3 CenterLeft = NDalic.ParentOriginCenterLeft;
      public static readonly NUI.Vector3 Center = NDalic.ParentOriginCenter;
      public static readonly NUI.Vector3 CenterRight = NDalic.ParentOriginCenterRight;
      public static readonly NUI.Vector3 BottomLeft = NDalic.ParentOriginBottomLeft;
      public static readonly NUI.Vector3 BottomCenter = NDalic.ParentOriginBottomCenter;
      public static readonly NUI.Vector3 BottomRight = NDalic.ParentOriginBottomRight;
    }

    public struct AnchorPoint
    {
      public static readonly float Top = NDalic.AnchorPointTop;
      public static readonly float Bottom = NDalic.AnchorPointBottom;
      public static readonly float Left = NDalic.AnchorPointLeft;
      public static readonly float Right = NDalic.AnchorPointRight;
      public static readonly float Middle = NDalic.AnchorPointMiddle;
      public static readonly NUI.Vector3 TopLeft = NDalic.AnchorPointTopLeft;
      public static readonly NUI.Vector3 TopCenter = NDalic.AnchorPointTopCenter;
      public static readonly NUI.Vector3 TopRight = NDalic.AnchorPointTopRight;
      public static readonly NUI.Vector3 CenterLeft = NDalic.AnchorPointCenterLeft;
      public static readonly NUI.Vector3 Center = NDalic.AnchorPointCenter;
      public static readonly NUI.Vector3 CenterRight = NDalic.AnchorPointCenterRight;
      public static readonly NUI.Vector3 BottomLeft = NDalic.AnchorPointBottomLeft;
      public static readonly NUI.Vector3 BottomCenter = NDalic.AnchorPointBottomCenter;
      public static readonly NUI.Vector3 BottomRight = NDalic.AnchorPointBottomRight;
    }

    public struct Vect3
    {
      public static readonly NUI.Vector3 One = NUI.Vector3.ONE;
      public static readonly NUI.Vector3 Xaxis = NUI.Vector3.XAXIS;
      public static readonly NUI.Vector3 Yaxis = NUI.Vector3.YAXIS;
      public static readonly NUI.Vector3 Zaxis = NUI.Vector3.ZAXIS;
      public static readonly NUI.Vector3 NegativeXaxis = NUI.Vector3.NEGATIVE_XAXIS;
      public static readonly NUI.Vector3 NegativeYaxis = NUI.Vector3.NEGATIVE_YAXIS;
      public static readonly NUI.Vector3 NegativeZaxis = NUI.Vector3.NEGATIVE_ZAXIS;
      public static readonly NUI.Vector3 Zero = NUI.Vector3.ZERO;
    }

    public struct Visual
    {
      public static readonly int PropertyType = NDalic.VISUAL_PROPERTY_TYPE;
      public static readonly int PropertyShader = NDalic.VISUAL_PROPERTY_SHADER;

      public static readonly int VertexShader = NDalic.VERTEX_SHADER;
      public static readonly int FragmentShader = NDalic.FRAGMENT_SHADER;
      public static readonly int SubdivideGridX = NDalic.SUBDIVIDE_GRID_X;
      public static readonly int SubdivideGridY = NDalic.SUBDIVIDE_GRID_Y;
      public static readonly int Hints = NDalic.HINTS;

      public static readonly int Color = NDalic.COLOR;
      public static readonly int Size = NDalic.SIZE;
      public static readonly int AntiAliasing = NDalic.ANTI_ALIASING;

      public static readonly int MixColor = NDalic.MIX_COLOR;

      public static readonly int StartPosition = NDalic.START_POSITION;
      public static readonly int EndPosition = NDalic.END_POSITION;
      public static readonly int Center = NDalic.CENTER;
      public static readonly int Radius = NDalic.RADIUS;
      public static readonly int StopOffset = NDalic.STOP_OFFSET;
      public static readonly int StopColor = NDalic.STOP_COLOR;
      public static readonly int Units = NDalic.UNITS;
      public static readonly int SpreadMethod = NDalic.SPREAD_METHOD;

      public static readonly int ImageVisualURL = NDalic.IMAGE_VISUAL_URL;
      public static readonly int ImageVisualFittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;
      public static readonly int ImageVisualSamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;
      public static readonly int ImageVisualDesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;
      public static readonly int ImageVisualDesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;
      public static readonly int ImageVisualSynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;
      public static readonly int ImageVisualBorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;
      public static readonly int ImageVisualBatchingEnabled = NDalic.IMAGE_VISUAL_BATCHING_ENABLED;
      public static readonly int ImageVisualPixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;
      public static readonly int ImageVisualWrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;
      public static readonly int ImageVisualWrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;

      public enum Type
      {
        Border = NUI.VisualType.BORDER,
        Color = NUI.VisualType.COLOR,
        Gradient = NUI.VisualType.GRADIENT,
        Image = NUI.VisualType.IMAGE,
        Mesh = NUI.VisualType.MESH,
        Primitive = NUI.VisualType.PRIMITIVE,
        WireFrame = NUI.VisualType.WIREFRAME
      }
    }

  } // namespace Constants
} // namesapce Dali
