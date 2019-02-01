#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Texture UV mapping for all objects (rotation, perspective, 3d, ...).
/// Evas allows different transformations to be applied to all kinds of objects. These are applied by means of UV mapping.
/// 
/// With UV mapping, one maps points in the source object to a 3D space positioning at target. This allows rotation, perspective, scale and lots of other effects, depending on the map that is used.
/// 
/// Each map point may carry a multiplier color. If properly calculated, these can do shading effects on the object, producing 3D effects.
/// 
/// At the moment of writing, maps can only have 4 points (no more, no less).
/// 1.20</summary>
[MapConcreteNativeInherit]
public interface Map : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// 1.20</summary>
/// <returns>The number of points of map
/// 1.20</returns>
 int GetMapPointCount();
   /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// 1.20</summary>
/// <param name="count">The number of points of map
/// 1.20</param>
/// <returns></returns>
 void SetMapPointCount(  int count);
   /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// 1.20</summary>
/// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise
/// 1.20</returns>
bool GetMapClockwise();
   /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// 1.20</summary>
/// <returns><c>true</c> by default.
/// 1.20</returns>
bool GetMapSmooth();
   /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// 1.20</summary>
/// <param name="smooth"><c>true</c> by default.
/// 1.20</param>
/// <returns></returns>
 void SetMapSmooth( bool smooth);
   /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
/// 1.20</summary>
/// <returns><c>true</c> by default.
/// 1.20</returns>
bool GetMapAlpha();
   /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
/// 1.20</summary>
/// <param name="alpha"><c>true</c> by default.
/// 1.20</param>
/// <returns></returns>
 void SetMapAlpha( bool alpha);
   /// <summary>A point&apos;s absolute coordinate on the canvas.
/// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
/// 
/// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
/// 
/// Remember all coordinates are canvas global ones as with move and resize in the canvas.
/// 
/// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
/// 1.20</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).
/// 1.20</param>
/// <param name="x">Point X coordinate in absolute pixel coordinates.
/// 1.20</param>
/// <param name="y">Point Y coordinate in absolute pixel coordinates.
/// 1.20</param>
/// <param name="z">Point Z coordinate hint (pre-perspective transform).
/// 1.20</param>
/// <returns></returns>
 void GetMapCoordAbsolute(  int idx,  out double x,  out double y,  out double z);
   /// <summary>A point&apos;s absolute coordinate on the canvas.
/// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
/// 
/// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
/// 
/// Remember all coordinates are canvas global ones as with move and resize in the canvas.
/// 
/// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
/// 1.20</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).
/// 1.20</param>
/// <param name="x">Point X coordinate in absolute pixel coordinates.
/// 1.20</param>
/// <param name="y">Point Y coordinate in absolute pixel coordinates.
/// 1.20</param>
/// <param name="z">Point Z coordinate hint (pre-perspective transform).
/// 1.20</param>
/// <returns></returns>
 void SetMapCoordAbsolute(  int idx,  double x,  double y,  double z);
   /// <summary>Map point&apos;s U and V texture source point.
/// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
/// 
/// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
/// 1.20</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).
/// 1.20</param>
/// <param name="u">Relative X coordinate within the image, from 0 to 1.
/// 1.20</param>
/// <param name="v">Relative Y coordinate within the image, from 0 to 1.
/// 1.20</param>
/// <returns></returns>
 void GetMapUv(  int idx,  out double u,  out double v);
   /// <summary>Map point&apos;s U and V texture source point.
/// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
/// 
/// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
/// 1.20</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).
/// 1.20</param>
/// <param name="u">Relative X coordinate within the image, from 0 to 1.
/// 1.20</param>
/// <param name="v">Relative Y coordinate within the image, from 0 to 1.
/// 1.20</param>
/// <returns></returns>
 void SetMapUv(  int idx,  double u,  double v);
   /// <summary>Color of a vertex in the map.
/// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
/// 
/// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
/// 1.20</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().
/// 1.20</param>
/// <param name="r">Red (0 - 255)
/// 1.20</param>
/// <param name="g">Green (0 - 255)
/// 1.20</param>
/// <param name="b">Blue (0 - 255)
/// 1.20</param>
/// <param name="a">Alpha (0 - 255)
/// 1.20</param>
/// <returns></returns>
 void GetMapColor(  int idx,  out  int r,  out  int g,  out  int b,  out  int a);
   /// <summary>Color of a vertex in the map.
/// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
/// 
/// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
/// 1.20</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().
/// 1.20</param>
/// <param name="r">Red (0 - 255)
/// 1.20</param>
/// <param name="g">Green (0 - 255)
/// 1.20</param>
/// <param name="b">Blue (0 - 255)
/// 1.20</param>
/// <param name="a">Alpha (0 - 255)
/// 1.20</param>
/// <returns></returns>
 void SetMapColor(  int idx,   int r,   int g,   int b,   int a);
   /// <summary>Read-only property indicating whether an object is mapped.
/// This will be <c>true</c> if any transformation is applied to this object.
/// 1.20</summary>
/// <returns><c>true</c> if the object is mapped.
/// 1.20</returns>
bool HasMap();
   /// <summary>Resets the map transformation to its default state.
/// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.Map.HasMap"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.Map.MapSmooth"/> or <see cref="Efl.Gfx.Map.MapAlpha"/>.
/// 1.20</summary>
/// <returns></returns>
 void ResetMap();
   /// <summary>Apply a translation to the object using map.
/// This does not change the real geometry of the object but will affect its visible position.
/// 1.20</summary>
/// <param name="dx">Distance in pixels along the X axis.
/// 1.20</param>
/// <param name="dy">Distance in pixels along the Y axis.
/// 1.20</param>
/// <param name="dz">Distance in pixels along the Z axis.
/// 1.20</param>
/// <returns></returns>
 void Translate( double dx,  double dy,  double dz);
   /// <summary>Apply a rotation to the object.
/// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
/// 
/// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
/// 
/// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.
/// 1.20</summary>
/// <param name="degrees">CCW rotation in degrees.
/// 1.20</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
/// 1.20</param>
/// <param name="cx">X relative coordinate of the center point.
/// 1.20</param>
/// <param name="cy">y relative coordinate of the center point.
/// 1.20</param>
/// <returns></returns>
 void Rotate( double degrees,  Efl.Gfx.Entity pivot,  double cx,  double cy);
   /// <summary>Rotate the object around 3 axes in 3D.
/// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.Map.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
/// 
/// As with <see cref="Efl.Gfx.Map.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
/// 1.20</summary>
/// <param name="dx">Rotation in degrees around X axis (0 to 360).
/// 1.20</param>
/// <param name="dy">Rotation in degrees around Y axis (0 to 360).
/// 1.20</param>
/// <param name="dz">Rotation in degrees around Z axis (0 to 360).
/// 1.20</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
/// 1.20</param>
/// <param name="cx">X relative coordinate of the center point.
/// 1.20</param>
/// <param name="cy">y relative coordinate of the center point.
/// 1.20</param>
/// <param name="cz">Z absolute coordinate of the center point.
/// 1.20</param>
/// <returns></returns>
 void Rotate3d( double dx,  double dy,  double dz,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz);
   /// <summary>Rotate the object in 3D using a unit quaternion.
/// This is similar to <see cref="Efl.Gfx.Map.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
/// 
/// As with <see cref="Efl.Gfx.Map.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
/// 1.20</summary>
/// <param name="qx">The x component of the imaginary part of the quaternion.
/// 1.20</param>
/// <param name="qy">The y component of the imaginary part of the quaternion.
/// 1.20</param>
/// <param name="qz">The z component of the imaginary part of the quaternion.
/// 1.20</param>
/// <param name="qw">The w component of the real part of the quaternion.
/// 1.20</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
/// 1.20</param>
/// <param name="cx">X relative coordinate of the center point.
/// 1.20</param>
/// <param name="cy">y relative coordinate of the center point.
/// 1.20</param>
/// <param name="cz">Z absolute coordinate of the center point.
/// 1.20</param>
/// <returns></returns>
 void RotateQuat( double qx,  double qy,  double qz,  double qw,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz);
   /// <summary>Apply a zoom to the object.
/// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
/// 
/// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.
/// 1.20</summary>
/// <param name="zoomx">Zoom in X direction
/// 1.20</param>
/// <param name="zoomy">Zoom in Y direction
/// 1.20</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
/// 1.20</param>
/// <param name="cx">X relative coordinate of the center point.
/// 1.20</param>
/// <param name="cy">y relative coordinate of the center point.
/// 1.20</param>
/// <returns></returns>
 void Zoom( double zoomx,  double zoomy,  Efl.Gfx.Entity pivot,  double cx,  double cy);
   /// <summary>Apply a lighting effect on the object.
/// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
/// 
/// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
/// 1.20</summary>
/// <param name="pivot">A pivot object for the light point, can be <c>null</c>.
/// 1.20</param>
/// <param name="lx">X relative coordinate in space of light point.
/// 1.20</param>
/// <param name="ly">Y relative coordinate in space of light point.
/// 1.20</param>
/// <param name="lz">Z absolute coordinate in space of light point.
/// 1.20</param>
/// <param name="lr">Light red value (0 - 255).
/// 1.20</param>
/// <param name="lg">Light green value (0 - 255).
/// 1.20</param>
/// <param name="lb">Light blue value (0 - 255).
/// 1.20</param>
/// <param name="ar">Ambient color red value (0 - 255).
/// 1.20</param>
/// <param name="ag">Ambient color green value (0 - 255).
/// 1.20</param>
/// <param name="ab">Ambient color blue value (0 - 255).
/// 1.20</param>
/// <returns></returns>
 void Lightning3d( Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab);
   /// <summary>Apply a perspective transform to the map
/// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
/// 
/// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
/// 1.20</summary>
/// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.
/// 1.20</param>
/// <param name="px">The perspective distance X relative coordinate.
/// 1.20</param>
/// <param name="py">The perspective distance Y relative coordinate.
/// 1.20</param>
/// <param name="z0">The &quot;0&quot; Z plane value.
/// 1.20</param>
/// <param name="foc">The focal distance, must be greater than 0.
/// 1.20</param>
/// <returns></returns>
 void Perspective3d( Efl.Gfx.Entity pivot,  double px,  double py,  double z0,  double foc);
   /// <summary>Apply a rotation to the object, using absolute coordinates.
/// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
/// 
/// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.Map.Rotate"/> for a relative coordinate version.
/// 1.20</summary>
/// <param name="degrees">CCW rotation in degrees.
/// 1.20</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <returns></returns>
 void RotateAbsolute( double degrees,  double cx,  double cy);
   /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
/// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.Map.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Rotate3d"/> for a pivot-based 3D rotation.
/// 1.20</summary>
/// <param name="dx">Rotation in degrees around X axis (0 to 360).
/// 1.20</param>
/// <param name="dy">Rotation in degrees around Y axis (0 to 360).
/// 1.20</param>
/// <param name="dz">Rotation in degrees around Z axis (0 to 360).
/// 1.20</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <param name="cz">Z absolute coordinate of the center point.
/// 1.20</param>
/// <returns></returns>
 void Rotate3dAbsolute( double dx,  double dy,  double dz,  double cx,  double cy,  double cz);
   /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
/// This is similar to <see cref="Efl.Gfx.Map.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.RotateQuat"/> for a pivot-based 3D rotation.
/// 1.20</summary>
/// <param name="qx">The x component of the imaginary part of the quaternion.
/// 1.20</param>
/// <param name="qy">The y component of the imaginary part of the quaternion.
/// 1.20</param>
/// <param name="qz">The z component of the imaginary part of the quaternion.
/// 1.20</param>
/// <param name="qw">The w component of the real part of the quaternion.
/// 1.20</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <param name="cz">Z absolute coordinate of the center point.
/// 1.20</param>
/// <returns></returns>
 void RotateQuatAbsolute( double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);
   /// <summary>Apply a zoom to the object, using absolute coordinates.
/// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Zoom"/> for a pivot-based zoom.
/// 1.20</summary>
/// <param name="zoomx">Zoom in X direction
/// 1.20</param>
/// <param name="zoomy">Zoom in Y direction
/// 1.20</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.
/// 1.20</param>
/// <returns></returns>
 void ZoomAbsolute( double zoomx,  double zoomy,  double cx,  double cy);
   /// <summary>Apply a lighting effect to the object.
/// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Lightning3d"/> for a pivot-based lightning effect.
/// 1.20</summary>
/// <param name="lx">X absolute coordinate in pixels of the light point.
/// 1.20</param>
/// <param name="ly">y absolute coordinate in pixels of the light point.
/// 1.20</param>
/// <param name="lz">Z absolute coordinate in space of light point.
/// 1.20</param>
/// <param name="lr">Light red value (0 - 255).
/// 1.20</param>
/// <param name="lg">Light green value (0 - 255).
/// 1.20</param>
/// <param name="lb">Light blue value (0 - 255).
/// 1.20</param>
/// <param name="ar">Ambient color red value (0 - 255).
/// 1.20</param>
/// <param name="ag">Ambient color green value (0 - 255).
/// 1.20</param>
/// <param name="ab">Ambient color blue value (0 - 255).
/// 1.20</param>
/// <returns></returns>
 void Lightning3dAbsolute( double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab);
   /// <summary>Apply a perspective transform to the map
/// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Perspective3d"/> for a pivot-based perspective effect.
/// 1.20</summary>
/// <param name="px">The perspective distance X relative coordinate.
/// 1.20</param>
/// <param name="py">The perspective distance Y relative coordinate.
/// 1.20</param>
/// <param name="z0">The &quot;0&quot; Z plane value.
/// 1.20</param>
/// <param name="foc">The focal distance, must be greater than 0.
/// 1.20</param>
/// <returns></returns>
 void Perspective3dAbsolute( double px,  double py,  double z0,  double foc);
                                                                                       /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// 1.20</summary>
    int MapPointCount {
      get ;
      set ;
   }
   /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// 1.20</summary>
   bool MapClockwise {
      get ;
   }
   /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// 1.20</summary>
   bool MapSmooth {
      get ;
      set ;
   }
   /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
/// 1.20</summary>
   bool MapAlpha {
      get ;
      set ;
   }
}
/// <summary>Texture UV mapping for all objects (rotation, perspective, 3d, ...).
/// Evas allows different transformations to be applied to all kinds of objects. These are applied by means of UV mapping.
/// 
/// With UV mapping, one maps points in the source object to a 3D space positioning at target. This allows rotation, perspective, scale and lots of other effects, depending on the map that is used.
/// 
/// Each map point may carry a multiplier color. If properly calculated, these can do shading effects on the object, producing 3D effects.
/// 
/// At the moment of writing, maps can only have 4 points (no more, no less).
/// 1.20</summary>
sealed public class MapConcrete : 

Map
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (MapConcrete))
            return Efl.Gfx.MapConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_gfx_map_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public MapConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~MapConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static MapConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new MapConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  int efl_gfx_map_point_count_get(System.IntPtr obj);
   /// <summary>Number of points of a map.
   /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
   /// 1.20</summary>
   /// <returns>The number of points of map
   /// 1.20</returns>
   public  int GetMapPointCount() {
       var _ret_var = efl_gfx_map_point_count_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_point_count_set(System.IntPtr obj,    int count);
   /// <summary>Number of points of a map.
   /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
   /// 1.20</summary>
   /// <param name="count">The number of points of map
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMapPointCount(  int count) {
                         efl_gfx_map_point_count_set(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  count);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_clockwise_get(System.IntPtr obj);
   /// <summary>Clockwise state of a map (read-only).
   /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
   /// 1.20</summary>
   /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise
   /// 1.20</returns>
   public bool GetMapClockwise() {
       var _ret_var = efl_gfx_map_clockwise_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_smooth_get(System.IntPtr obj);
   /// <summary>Smoothing state for map rendering.
   /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
   /// 1.20</summary>
   /// <returns><c>true</c> by default.
   /// 1.20</returns>
   public bool GetMapSmooth() {
       var _ret_var = efl_gfx_map_smooth_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_smooth_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
   /// <summary>Smoothing state for map rendering.
   /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
   /// 1.20</summary>
   /// <param name="smooth"><c>true</c> by default.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMapSmooth( bool smooth) {
                         efl_gfx_map_smooth_set(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  smooth);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_alpha_get(System.IntPtr obj);
   /// <summary>Alpha flag for map rendering.
   /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
   /// 
   /// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
   /// 1.20</summary>
   /// <returns><c>true</c> by default.
   /// 1.20</returns>
   public bool GetMapAlpha() {
       var _ret_var = efl_gfx_map_alpha_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   /// <summary>Alpha flag for map rendering.
   /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
   /// 
   /// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
   /// 1.20</summary>
   /// <param name="alpha"><c>true</c> by default.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMapAlpha( bool alpha) {
                         efl_gfx_map_alpha_set(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  alpha);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_coord_absolute_get(System.IntPtr obj,    int idx,   out double x,   out double y,   out double z);
   /// <summary>A point&apos;s absolute coordinate on the canvas.
   /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
   /// 
   /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
   /// 
   /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
   /// 
   /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="x">Point X coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="y">Point Y coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="z">Point Z coordinate hint (pre-perspective transform).
   /// 1.20</param>
   /// <returns></returns>
   public  void GetMapCoordAbsolute(  int idx,  out double x,  out double y,  out double z) {
                                                                               efl_gfx_map_coord_absolute_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  idx,  out x,  out y,  out z);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_coord_absolute_set(System.IntPtr obj,    int idx,   double x,   double y,   double z);
   /// <summary>A point&apos;s absolute coordinate on the canvas.
   /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
   /// 
   /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
   /// 
   /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
   /// 
   /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="x">Point X coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="y">Point Y coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="z">Point Z coordinate hint (pre-perspective transform).
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMapCoordAbsolute(  int idx,  double x,  double y,  double z) {
                                                                               efl_gfx_map_coord_absolute_set(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  idx,  x,  y,  z);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_uv_get(System.IntPtr obj,    int idx,   out double u,   out double v);
   /// <summary>Map point&apos;s U and V texture source point.
   /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
   /// 
   /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="u">Relative X coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <param name="v">Relative Y coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <returns></returns>
   public  void GetMapUv(  int idx,  out double u,  out double v) {
                                                             efl_gfx_map_uv_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  idx,  out u,  out v);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_uv_set(System.IntPtr obj,    int idx,   double u,   double v);
   /// <summary>Map point&apos;s U and V texture source point.
   /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
   /// 
   /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="u">Relative X coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <param name="v">Relative Y coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMapUv(  int idx,  double u,  double v) {
                                                             efl_gfx_map_uv_set(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  idx,  u,  v);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_color_get(System.IntPtr obj,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
   /// <summary>Color of a vertex in the map.
   /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
   /// 
   /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().
   /// 1.20</param>
   /// <param name="r">Red (0 - 255)
   /// 1.20</param>
   /// <param name="g">Green (0 - 255)
   /// 1.20</param>
   /// <param name="b">Blue (0 - 255)
   /// 1.20</param>
   /// <param name="a">Alpha (0 - 255)
   /// 1.20</param>
   /// <returns></returns>
   public  void GetMapColor(  int idx,  out  int r,  out  int g,  out  int b,  out  int a) {
                                                                                                 efl_gfx_map_color_get(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  idx,  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_color_set(System.IntPtr obj,    int idx,    int r,    int g,    int b,    int a);
   /// <summary>Color of a vertex in the map.
   /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
   /// 
   /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().
   /// 1.20</param>
   /// <param name="r">Red (0 - 255)
   /// 1.20</param>
   /// <param name="g">Green (0 - 255)
   /// 1.20</param>
   /// <param name="b">Blue (0 - 255)
   /// 1.20</param>
   /// <param name="a">Alpha (0 - 255)
   /// 1.20</param>
   /// <returns></returns>
   public  void SetMapColor(  int idx,   int r,   int g,   int b,   int a) {
                                                                                                 efl_gfx_map_color_set(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  idx,  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_has(System.IntPtr obj);
   /// <summary>Read-only property indicating whether an object is mapped.
   /// This will be <c>true</c> if any transformation is applied to this object.
   /// 1.20</summary>
   /// <returns><c>true</c> if the object is mapped.
   /// 1.20</returns>
   public bool HasMap() {
       var _ret_var = efl_gfx_map_has(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_reset(System.IntPtr obj);
   /// <summary>Resets the map transformation to its default state.
   /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.Map.HasMap"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.Map.MapSmooth"/> or <see cref="Efl.Gfx.Map.MapAlpha"/>.
   /// 1.20</summary>
   /// <returns></returns>
   public  void ResetMap() {
       efl_gfx_map_reset(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_translate(System.IntPtr obj,   double dx,   double dy,   double dz);
   /// <summary>Apply a translation to the object using map.
   /// This does not change the real geometry of the object but will affect its visible position.
   /// 1.20</summary>
   /// <param name="dx">Distance in pixels along the X axis.
   /// 1.20</param>
   /// <param name="dy">Distance in pixels along the Y axis.
   /// 1.20</param>
   /// <param name="dz">Distance in pixels along the Z axis.
   /// 1.20</param>
   /// <returns></returns>
   public  void Translate( double dx,  double dy,  double dz) {
                                                             efl_gfx_map_translate(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  dx,  dy,  dz);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_rotate(System.IntPtr obj,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   /// <summary>Apply a rotation to the object.
   /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
   /// 
   /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
   /// 
   /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.
   /// 1.20</summary>
   /// <param name="degrees">CCW rotation in degrees.
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void Rotate( double degrees,  Efl.Gfx.Entity pivot,  double cx,  double cy) {
                                                                               efl_gfx_map_rotate(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  degrees,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_rotate_3d(System.IntPtr obj,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object around 3 axes in 3D.
   /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.Map.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
   /// 
   /// As with <see cref="Efl.Gfx.Map.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
   /// 1.20</summary>
   /// <param name="dx">Rotation in degrees around X axis (0 to 360).
   /// 1.20</param>
   /// <param name="dy">Rotation in degrees around Y axis (0 to 360).
   /// 1.20</param>
   /// <param name="dz">Rotation in degrees around Z axis (0 to 360).
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void Rotate3d( double dx,  double dy,  double dz,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz) {
                                                                                                                                     efl_gfx_map_rotate_3d(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  dx,  dy,  dz,  pivot,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_rotate_quat(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object in 3D using a unit quaternion.
   /// This is similar to <see cref="Efl.Gfx.Map.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
   /// 
   /// As with <see cref="Efl.Gfx.Map.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
   /// 1.20</summary>
   /// <param name="qx">The x component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qy">The y component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qz">The z component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qw">The w component of the real part of the quaternion.
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void RotateQuat( double qx,  double qy,  double qz,  double qw,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz) {
                                                                                                                                                       efl_gfx_map_rotate_quat(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_zoom(System.IntPtr obj,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   /// <summary>Apply a zoom to the object.
   /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
   /// 
   /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.
   /// 1.20</summary>
   /// <param name="zoomx">Zoom in X direction
   /// 1.20</param>
   /// <param name="zoomy">Zoom in Y direction
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void Zoom( double zoomx,  double zoomy,  Efl.Gfx.Entity pivot,  double cx,  double cy) {
                                                                                                 efl_gfx_map_zoom(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  zoomx,  zoomy,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_lightning_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   /// <summary>Apply a lighting effect on the object.
   /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
   /// 
   /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
   /// 1.20</summary>
   /// <param name="pivot">A pivot object for the light point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="lx">X relative coordinate in space of light point.
   /// 1.20</param>
   /// <param name="ly">Y relative coordinate in space of light point.
   /// 1.20</param>
   /// <param name="lz">Z absolute coordinate in space of light point.
   /// 1.20</param>
   /// <param name="lr">Light red value (0 - 255).
   /// 1.20</param>
   /// <param name="lg">Light green value (0 - 255).
   /// 1.20</param>
   /// <param name="lb">Light blue value (0 - 255).
   /// 1.20</param>
   /// <param name="ar">Ambient color red value (0 - 255).
   /// 1.20</param>
   /// <param name="ag">Ambient color green value (0 - 255).
   /// 1.20</param>
   /// <param name="ab">Ambient color blue value (0 - 255).
   /// 1.20</param>
   /// <returns></returns>
   public  void Lightning3d( Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab) {
                                                                                                                                                                                           efl_gfx_map_lightning_3d(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_perspective_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
   /// <summary>Apply a perspective transform to the map
   /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
   /// 
   /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
   /// 1.20</summary>
   /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="px">The perspective distance X relative coordinate.
   /// 1.20</param>
   /// <param name="py">The perspective distance Y relative coordinate.
   /// 1.20</param>
   /// <param name="z0">The &quot;0&quot; Z plane value.
   /// 1.20</param>
   /// <param name="foc">The focal distance, must be greater than 0.
   /// 1.20</param>
   /// <returns></returns>
   public  void Perspective3d( Efl.Gfx.Entity pivot,  double px,  double py,  double z0,  double foc) {
                                                                                                 efl_gfx_map_perspective_3d(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  pivot,  px,  py,  z0,  foc);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_rotate_absolute(System.IntPtr obj,   double degrees,   double cx,   double cy);
   /// <summary>Apply a rotation to the object, using absolute coordinates.
   /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
   /// 
   /// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.Map.Rotate"/> for a relative coordinate version.
   /// 1.20</summary>
   /// <param name="degrees">CCW rotation in degrees.
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void RotateAbsolute( double degrees,  double cx,  double cy) {
                                                             efl_gfx_map_rotate_absolute(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  degrees,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_rotate_3d_absolute(System.IntPtr obj,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
   /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.Map.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Rotate3d"/> for a pivot-based 3D rotation.
   /// 1.20</summary>
   /// <param name="dx">Rotation in degrees around X axis (0 to 360).
   /// 1.20</param>
   /// <param name="dy">Rotation in degrees around Y axis (0 to 360).
   /// 1.20</param>
   /// <param name="dz">Rotation in degrees around Z axis (0 to 360).
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void Rotate3dAbsolute( double dx,  double dy,  double dz,  double cx,  double cy,  double cz) {
                                                                                                                   efl_gfx_map_rotate_3d_absolute(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  dx,  dy,  dz,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_rotate_quat_absolute(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
   /// This is similar to <see cref="Efl.Gfx.Map.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.RotateQuat"/> for a pivot-based 3D rotation.
   /// 1.20</summary>
   /// <param name="qx">The x component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qy">The y component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qz">The z component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qw">The w component of the real part of the quaternion.
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void RotateQuatAbsolute( double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz) {
                                                                                                                                     efl_gfx_map_rotate_quat_absolute(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  qx,  qy,  qz,  qw,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_zoom_absolute(System.IntPtr obj,   double zoomx,   double zoomy,   double cx,   double cy);
   /// <summary>Apply a zoom to the object, using absolute coordinates.
   /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Zoom"/> for a pivot-based zoom.
   /// 1.20</summary>
   /// <param name="zoomx">Zoom in X direction
   /// 1.20</param>
   /// <param name="zoomy">Zoom in Y direction
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <returns></returns>
   public  void ZoomAbsolute( double zoomx,  double zoomy,  double cx,  double cy) {
                                                                               efl_gfx_map_zoom_absolute(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  zoomx,  zoomy,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_lightning_3d_absolute(System.IntPtr obj,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   /// <summary>Apply a lighting effect to the object.
   /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Lightning3d"/> for a pivot-based lightning effect.
   /// 1.20</summary>
   /// <param name="lx">X absolute coordinate in pixels of the light point.
   /// 1.20</param>
   /// <param name="ly">y absolute coordinate in pixels of the light point.
   /// 1.20</param>
   /// <param name="lz">Z absolute coordinate in space of light point.
   /// 1.20</param>
   /// <param name="lr">Light red value (0 - 255).
   /// 1.20</param>
   /// <param name="lg">Light green value (0 - 255).
   /// 1.20</param>
   /// <param name="lb">Light blue value (0 - 255).
   /// 1.20</param>
   /// <param name="ar">Ambient color red value (0 - 255).
   /// 1.20</param>
   /// <param name="ag">Ambient color green value (0 - 255).
   /// 1.20</param>
   /// <param name="ab">Ambient color blue value (0 - 255).
   /// 1.20</param>
   /// <returns></returns>
   public  void Lightning3dAbsolute( double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab) {
                                                                                                                                                                         efl_gfx_map_lightning_3d_absolute(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    private static extern  void efl_gfx_map_perspective_3d_absolute(System.IntPtr obj,   double px,   double py,   double z0,   double foc);
   /// <summary>Apply a perspective transform to the map
   /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Perspective3d"/> for a pivot-based perspective effect.
   /// 1.20</summary>
   /// <param name="px">The perspective distance X relative coordinate.
   /// 1.20</param>
   /// <param name="py">The perspective distance Y relative coordinate.
   /// 1.20</param>
   /// <param name="z0">The &quot;0&quot; Z plane value.
   /// 1.20</param>
   /// <param name="foc">The focal distance, must be greater than 0.
   /// 1.20</param>
   /// <returns></returns>
   public  void Perspective3dAbsolute( double px,  double py,  double z0,  double foc) {
                                                                               efl_gfx_map_perspective_3d_absolute(Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get(),  px,  py,  z0,  foc);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// 1.20</summary>
   public  int MapPointCount {
      get { return GetMapPointCount(); }
      set { SetMapPointCount( value); }
   }
   /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// 1.20</summary>
   public bool MapClockwise {
      get { return GetMapClockwise(); }
   }
   /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// 1.20</summary>
   public bool MapSmooth {
      get { return GetMapSmooth(); }
      set { SetMapSmooth( value); }
   }
   /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
/// 1.20</summary>
   public bool MapAlpha {
      get { return GetMapAlpha(); }
      set { SetMapAlpha( value); }
   }
}
public class MapConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_gfx_map_point_count_get_static_delegate = new efl_gfx_map_point_count_get_delegate(map_point_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_point_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_point_count_get_static_delegate)});
      efl_gfx_map_point_count_set_static_delegate = new efl_gfx_map_point_count_set_delegate(map_point_count_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_point_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_point_count_set_static_delegate)});
      efl_gfx_map_clockwise_get_static_delegate = new efl_gfx_map_clockwise_get_delegate(map_clockwise_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_clockwise_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_clockwise_get_static_delegate)});
      efl_gfx_map_smooth_get_static_delegate = new efl_gfx_map_smooth_get_delegate(map_smooth_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_smooth_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_smooth_get_static_delegate)});
      efl_gfx_map_smooth_set_static_delegate = new efl_gfx_map_smooth_set_delegate(map_smooth_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_smooth_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_smooth_set_static_delegate)});
      efl_gfx_map_alpha_get_static_delegate = new efl_gfx_map_alpha_get_delegate(map_alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_alpha_get_static_delegate)});
      efl_gfx_map_alpha_set_static_delegate = new efl_gfx_map_alpha_set_delegate(map_alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_alpha_set_static_delegate)});
      efl_gfx_map_coord_absolute_get_static_delegate = new efl_gfx_map_coord_absolute_get_delegate(map_coord_absolute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_coord_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_coord_absolute_get_static_delegate)});
      efl_gfx_map_coord_absolute_set_static_delegate = new efl_gfx_map_coord_absolute_set_delegate(map_coord_absolute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_coord_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_coord_absolute_set_static_delegate)});
      efl_gfx_map_uv_get_static_delegate = new efl_gfx_map_uv_get_delegate(map_uv_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_uv_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_uv_get_static_delegate)});
      efl_gfx_map_uv_set_static_delegate = new efl_gfx_map_uv_set_delegate(map_uv_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_uv_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_uv_set_static_delegate)});
      efl_gfx_map_color_get_static_delegate = new efl_gfx_map_color_get_delegate(map_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_color_get_static_delegate)});
      efl_gfx_map_color_set_static_delegate = new efl_gfx_map_color_set_delegate(map_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_color_set_static_delegate)});
      efl_gfx_map_has_static_delegate = new efl_gfx_map_has_delegate(map_has);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_has"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_has_static_delegate)});
      efl_gfx_map_reset_static_delegate = new efl_gfx_map_reset_delegate(map_reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_reset_static_delegate)});
      efl_gfx_map_translate_static_delegate = new efl_gfx_map_translate_delegate(translate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_translate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_translate_static_delegate)});
      efl_gfx_map_rotate_static_delegate = new efl_gfx_map_rotate_delegate(rotate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_static_delegate)});
      efl_gfx_map_rotate_3d_static_delegate = new efl_gfx_map_rotate_3d_delegate(rotate_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_3d_static_delegate)});
      efl_gfx_map_rotate_quat_static_delegate = new efl_gfx_map_rotate_quat_delegate(rotate_quat);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_quat"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_quat_static_delegate)});
      efl_gfx_map_zoom_static_delegate = new efl_gfx_map_zoom_delegate(zoom);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_zoom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_zoom_static_delegate)});
      efl_gfx_map_lightning_3d_static_delegate = new efl_gfx_map_lightning_3d_delegate(lightning_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_lightning_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_lightning_3d_static_delegate)});
      efl_gfx_map_perspective_3d_static_delegate = new efl_gfx_map_perspective_3d_delegate(perspective_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_perspective_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_perspective_3d_static_delegate)});
      efl_gfx_map_rotate_absolute_static_delegate = new efl_gfx_map_rotate_absolute_delegate(rotate_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_absolute_static_delegate)});
      efl_gfx_map_rotate_3d_absolute_static_delegate = new efl_gfx_map_rotate_3d_absolute_delegate(rotate_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_3d_absolute_static_delegate)});
      efl_gfx_map_rotate_quat_absolute_static_delegate = new efl_gfx_map_rotate_quat_absolute_delegate(rotate_quat_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_quat_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_quat_absolute_static_delegate)});
      efl_gfx_map_zoom_absolute_static_delegate = new efl_gfx_map_zoom_absolute_delegate(zoom_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_zoom_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_zoom_absolute_static_delegate)});
      efl_gfx_map_lightning_3d_absolute_static_delegate = new efl_gfx_map_lightning_3d_absolute_delegate(lightning_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_lightning_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_lightning_3d_absolute_static_delegate)});
      efl_gfx_map_perspective_3d_absolute_static_delegate = new efl_gfx_map_perspective_3d_absolute_delegate(perspective_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_perspective_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_perspective_3d_absolute_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Gfx.MapConcrete.efl_gfx_map_mixin_get();
   }


    private delegate  int efl_gfx_map_point_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_gfx_map_point_count_get(System.IntPtr obj);
    private static  int map_point_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_point_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((MapConcrete)wrapper).GetMapPointCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_point_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_point_count_get_delegate efl_gfx_map_point_count_get_static_delegate;


    private delegate  void efl_gfx_map_point_count_set_delegate(System.IntPtr obj, System.IntPtr pd,    int count);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_point_count_set(System.IntPtr obj,    int count);
    private static  void map_point_count_set(System.IntPtr obj, System.IntPtr pd,   int count)
   {
      Eina.Log.Debug("function efl_gfx_map_point_count_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((MapConcrete)wrapper).SetMapPointCount( count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_map_point_count_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  count);
      }
   }
   private efl_gfx_map_point_count_set_delegate efl_gfx_map_point_count_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_clockwise_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_clockwise_get(System.IntPtr obj);
    private static bool map_clockwise_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_clockwise_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((MapConcrete)wrapper).GetMapClockwise();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_clockwise_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_clockwise_get_delegate efl_gfx_map_clockwise_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_smooth_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_smooth_get(System.IntPtr obj);
    private static bool map_smooth_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_smooth_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((MapConcrete)wrapper).GetMapSmooth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_smooth_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_smooth_get_delegate efl_gfx_map_smooth_get_static_delegate;


    private delegate  void efl_gfx_map_smooth_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_smooth_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
    private static  void map_smooth_set(System.IntPtr obj, System.IntPtr pd,  bool smooth)
   {
      Eina.Log.Debug("function efl_gfx_map_smooth_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((MapConcrete)wrapper).SetMapSmooth( smooth);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_map_smooth_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  smooth);
      }
   }
   private efl_gfx_map_smooth_set_delegate efl_gfx_map_smooth_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_alpha_get(System.IntPtr obj);
    private static bool map_alpha_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_alpha_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((MapConcrete)wrapper).GetMapAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_alpha_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_alpha_get_delegate efl_gfx_map_alpha_get_static_delegate;


    private delegate  void efl_gfx_map_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
    private static  void map_alpha_set(System.IntPtr obj, System.IntPtr pd,  bool alpha)
   {
      Eina.Log.Debug("function efl_gfx_map_alpha_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((MapConcrete)wrapper).SetMapAlpha( alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_map_alpha_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  alpha);
      }
   }
   private efl_gfx_map_alpha_set_delegate efl_gfx_map_alpha_set_static_delegate;


    private delegate  void efl_gfx_map_coord_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out double x,   out double y,   out double z);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_coord_absolute_get(System.IntPtr obj,    int idx,   out double x,   out double y,   out double z);
    private static  void map_coord_absolute_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out double x,  out double y,  out double z)
   {
      Eina.Log.Debug("function efl_gfx_map_coord_absolute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             x = default(double);      y = default(double);      z = default(double);                                 
         try {
            ((MapConcrete)wrapper).GetMapCoordAbsolute( idx,  out x,  out y,  out z);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_coord_absolute_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out x,  out y,  out z);
      }
   }
   private efl_gfx_map_coord_absolute_get_delegate efl_gfx_map_coord_absolute_get_static_delegate;


    private delegate  void efl_gfx_map_coord_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   double x,   double y,   double z);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_coord_absolute_set(System.IntPtr obj,    int idx,   double x,   double y,   double z);
    private static  void map_coord_absolute_set(System.IntPtr obj, System.IntPtr pd,   int idx,  double x,  double y,  double z)
   {
      Eina.Log.Debug("function efl_gfx_map_coord_absolute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((MapConcrete)wrapper).SetMapCoordAbsolute( idx,  x,  y,  z);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_coord_absolute_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  x,  y,  z);
      }
   }
   private efl_gfx_map_coord_absolute_set_delegate efl_gfx_map_coord_absolute_set_static_delegate;


    private delegate  void efl_gfx_map_uv_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out double u,   out double v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_uv_get(System.IntPtr obj,    int idx,   out double u,   out double v);
    private static  void map_uv_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out double u,  out double v)
   {
      Eina.Log.Debug("function efl_gfx_map_uv_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       u = default(double);      v = default(double);                           
         try {
            ((MapConcrete)wrapper).GetMapUv( idx,  out u,  out v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_uv_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out u,  out v);
      }
   }
   private efl_gfx_map_uv_get_delegate efl_gfx_map_uv_get_static_delegate;


    private delegate  void efl_gfx_map_uv_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   double u,   double v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_uv_set(System.IntPtr obj,    int idx,   double u,   double v);
    private static  void map_uv_set(System.IntPtr obj, System.IntPtr pd,   int idx,  double u,  double v)
   {
      Eina.Log.Debug("function efl_gfx_map_uv_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((MapConcrete)wrapper).SetMapUv( idx,  u,  v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_uv_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  u,  v);
      }
   }
   private efl_gfx_map_uv_set_delegate efl_gfx_map_uv_set_static_delegate;


    private delegate  void efl_gfx_map_color_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_color_get(System.IntPtr obj,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
    private static  void map_color_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_map_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   r = default( int);      g = default( int);      b = default( int);      a = default( int);                                       
         try {
            ((MapConcrete)wrapper).GetMapColor( idx,  out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out r,  out g,  out b,  out a);
      }
   }
   private efl_gfx_map_color_get_delegate efl_gfx_map_color_get_static_delegate;


    private delegate  void efl_gfx_map_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,    int r,    int g,    int b,    int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_color_set(System.IntPtr obj,    int idx,    int r,    int g,    int b,    int a);
    private static  void map_color_set(System.IntPtr obj, System.IntPtr pd,   int idx,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_map_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((MapConcrete)wrapper).SetMapColor( idx,  r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  r,  g,  b,  a);
      }
   }
   private efl_gfx_map_color_set_delegate efl_gfx_map_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_has_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_has(System.IntPtr obj);
    private static bool map_has(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_has was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((MapConcrete)wrapper).HasMap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_has(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_has_delegate efl_gfx_map_has_static_delegate;


    private delegate  void efl_gfx_map_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_reset(System.IntPtr obj);
    private static  void map_reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((MapConcrete)wrapper).ResetMap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_map_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_reset_delegate efl_gfx_map_reset_static_delegate;


    private delegate  void efl_gfx_map_translate_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_translate(System.IntPtr obj,   double dx,   double dy,   double dz);
    private static  void translate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz)
   {
      Eina.Log.Debug("function efl_gfx_map_translate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((MapConcrete)wrapper).Translate( dx,  dy,  dz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_translate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz);
      }
   }
   private efl_gfx_map_translate_delegate efl_gfx_map_translate_static_delegate;


    private delegate  void efl_gfx_map_rotate_delegate(System.IntPtr obj, System.IntPtr pd,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate(System.IntPtr obj,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
    private static  void rotate(System.IntPtr obj, System.IntPtr pd,  double degrees,  Efl.Gfx.Entity pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((MapConcrete)wrapper).Rotate( degrees,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_rotate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degrees,  pivot,  cx,  cy);
      }
   }
   private efl_gfx_map_rotate_delegate efl_gfx_map_rotate_static_delegate;


    private delegate  void efl_gfx_map_rotate_3d_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_3d(System.IntPtr obj,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
    private static  void rotate_3d(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((MapConcrete)wrapper).Rotate3d( dx,  dy,  dz,  pivot,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_map_rotate_3d(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz,  pivot,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_3d_delegate efl_gfx_map_rotate_3d_static_delegate;


    private delegate  void efl_gfx_map_rotate_quat_delegate(System.IntPtr obj, System.IntPtr pd,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_quat(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
    private static  void rotate_quat(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_quat was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                  
         try {
            ((MapConcrete)wrapper).RotateQuat( qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                            } else {
         efl_gfx_map_rotate_quat(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_quat_delegate efl_gfx_map_rotate_quat_static_delegate;


    private delegate  void efl_gfx_map_zoom_delegate(System.IntPtr obj, System.IntPtr pd,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_zoom(System.IntPtr obj,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
    private static  void zoom(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  Efl.Gfx.Entity pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_zoom was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((MapConcrete)wrapper).Zoom( zoomx,  zoomy,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_zoom(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoomx,  zoomy,  pivot,  cx,  cy);
      }
   }
   private efl_gfx_map_zoom_delegate efl_gfx_map_zoom_static_delegate;


    private delegate  void efl_gfx_map_lightning_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_lightning_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
    private static  void lightning_3d(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab)
   {
      Eina.Log.Debug("function efl_gfx_map_lightning_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                                      
         try {
            ((MapConcrete)wrapper).Lightning3d( pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                                    } else {
         efl_gfx_map_lightning_3d(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      }
   }
   private efl_gfx_map_lightning_3d_delegate efl_gfx_map_lightning_3d_static_delegate;


    private delegate  void efl_gfx_map_perspective_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_perspective_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
    private static  void perspective_3d(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity pivot,  double px,  double py,  double z0,  double foc)
   {
      Eina.Log.Debug("function efl_gfx_map_perspective_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((MapConcrete)wrapper).Perspective3d( pivot,  px,  py,  z0,  foc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_perspective_3d(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pivot,  px,  py,  z0,  foc);
      }
   }
   private efl_gfx_map_perspective_3d_delegate efl_gfx_map_perspective_3d_static_delegate;


    private delegate  void efl_gfx_map_rotate_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double degrees,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_absolute(System.IntPtr obj,   double degrees,   double cx,   double cy);
    private static  void rotate_absolute(System.IntPtr obj, System.IntPtr pd,  double degrees,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((MapConcrete)wrapper).RotateAbsolute( degrees,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_rotate_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degrees,  cx,  cy);
      }
   }
   private efl_gfx_map_rotate_absolute_delegate efl_gfx_map_rotate_absolute_static_delegate;


    private delegate  void efl_gfx_map_rotate_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_3d_absolute(System.IntPtr obj,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
    private static  void rotate_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((MapConcrete)wrapper).Rotate3dAbsolute( dx,  dy,  dz,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_map_rotate_3d_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_3d_absolute_delegate efl_gfx_map_rotate_3d_absolute_static_delegate;


    private delegate  void efl_gfx_map_rotate_quat_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_quat_absolute(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
    private static  void rotate_quat_absolute(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_quat_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((MapConcrete)wrapper).RotateQuatAbsolute( qx,  qy,  qz,  qw,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_map_rotate_quat_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  qx,  qy,  qz,  qw,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_quat_absolute_delegate efl_gfx_map_rotate_quat_absolute_static_delegate;


    private delegate  void efl_gfx_map_zoom_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double zoomx,   double zoomy,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_zoom_absolute(System.IntPtr obj,   double zoomx,   double zoomy,   double cx,   double cy);
    private static  void zoom_absolute(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_zoom_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((MapConcrete)wrapper).ZoomAbsolute( zoomx,  zoomy,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_zoom_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoomx,  zoomy,  cx,  cy);
      }
   }
   private efl_gfx_map_zoom_absolute_delegate efl_gfx_map_zoom_absolute_static_delegate;


    private delegate  void efl_gfx_map_lightning_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_lightning_3d_absolute(System.IntPtr obj,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
    private static  void lightning_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab)
   {
      Eina.Log.Debug("function efl_gfx_map_lightning_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                    
         try {
            ((MapConcrete)wrapper).Lightning3dAbsolute( lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                        } else {
         efl_gfx_map_lightning_3d_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      }
   }
   private efl_gfx_map_lightning_3d_absolute_delegate efl_gfx_map_lightning_3d_absolute_static_delegate;


    private delegate  void efl_gfx_map_perspective_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double px,   double py,   double z0,   double foc);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_perspective_3d_absolute(System.IntPtr obj,   double px,   double py,   double z0,   double foc);
    private static  void perspective_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double px,  double py,  double z0,  double foc)
   {
      Eina.Log.Debug("function efl_gfx_map_perspective_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((MapConcrete)wrapper).Perspective3dAbsolute( px,  py,  z0,  foc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_perspective_3d_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  px,  py,  z0,  foc);
      }
   }
   private efl_gfx_map_perspective_3d_absolute_delegate efl_gfx_map_perspective_3d_absolute_static_delegate;
}
} } 
