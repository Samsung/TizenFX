#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>Texture UV mapping for all objects (rotation, perspective, 3d, ...).
/// Evas allows different transformations to be applied to all kinds of objects. These are applied by means of UV mapping.
/// 
/// With UV mapping, one maps points in the source object to a 3D space positioning at target. This allows rotation, perspective, scale and lots of other effects, depending on the map that is used.
/// 
/// Each map point may carry a multiplier color. If properly calculated, these can do shading effects on the object, producing 3D effects.
/// 
/// At the moment of writing, maps can only have 4 points (no more, no less).
/// (Since EFL 1.22)</summary>
[Efl.Gfx.IMappingConcrete.NativeMethods]
public interface IMapping : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// (Since EFL 1.22)</summary>
/// <returns>The number of points of map</returns>
int GetMappingPointCount();
    /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// (Since EFL 1.22)</summary>
/// <param name="count">The number of points of map</param>
void SetMappingPointCount(int count);
    /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise</returns>
bool GetMappingClockwise();
    /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> by default.</returns>
bool GetMappingSmooth();
    /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// (Since EFL 1.22)</summary>
/// <param name="smooth"><c>true</c> by default.</param>
void SetMappingSmooth(bool smooth);
    /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> by default.</returns>
bool GetMappingAlpha();
    /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
/// (Since EFL 1.22)</summary>
/// <param name="alpha"><c>true</c> by default.</param>
void SetMappingAlpha(bool alpha);
    /// <summary>A point&apos;s absolute coordinate on the canvas.
/// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
/// 
/// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
/// 
/// Remember all coordinates are canvas global ones as with move and resize in the canvas.
/// 
/// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
/// (Since EFL 1.22)</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).</param>
/// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
/// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
/// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
void GetMappingCoordAbsolute(int idx, out double x, out double y, out double z);
    /// <summary>A point&apos;s absolute coordinate on the canvas.
/// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
/// 
/// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
/// 
/// Remember all coordinates are canvas global ones as with move and resize in the canvas.
/// 
/// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
/// (Since EFL 1.22)</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).</param>
/// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
/// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
/// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
void SetMappingCoordAbsolute(int idx, double x, double y, double z);
    /// <summary>Map point&apos;s U and V texture source point.
/// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
/// 
/// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
/// (Since EFL 1.22)</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).</param>
/// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
/// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
void GetMappingUv(int idx, out double u, out double v);
    /// <summary>Map point&apos;s U and V texture source point.
/// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
/// 
/// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
/// (Since EFL 1.22)</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included).</param>
/// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
/// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
void SetMappingUv(int idx, double u, double v);
    /// <summary>Color of a vertex in the map.
/// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
/// 
/// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
/// (Since EFL 1.22)</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
/// <param name="r">Red (0 - 255)</param>
/// <param name="g">Green (0 - 255)</param>
/// <param name="b">Blue (0 - 255)</param>
/// <param name="a">Alpha (0 - 255)</param>
void GetMappingColor(int idx, out int r, out int g, out int b, out int a);
    /// <summary>Color of a vertex in the map.
/// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
/// 
/// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
/// (Since EFL 1.22)</summary>
/// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
/// <param name="r">Red (0 - 255)</param>
/// <param name="g">Green (0 - 255)</param>
/// <param name="b">Blue (0 - 255)</param>
/// <param name="a">Alpha (0 - 255)</param>
void SetMappingColor(int idx, int r, int g, int b, int a);
    /// <summary>Read-only property indicating whether an object is mapped.
/// This will be <c>true</c> if any transformation is applied to this object.
/// (Since EFL 1.22)</summary>
/// <returns><c>true</c> if the object is mapped.</returns>
bool HasMapping();
    /// <summary>Resets the map transformation to its default state.
/// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.IMapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.IMapping.MappingSmooth"/> or <see cref="Efl.Gfx.IMapping.MappingAlpha"/>.
/// (Since EFL 1.22)</summary>
void ResetMapping();
    /// <summary>Apply a translation to the object using map.
/// This does not change the real geometry of the object but will affect its visible position.
/// (Since EFL 1.22)</summary>
/// <param name="dx">Distance in pixels along the X axis.</param>
/// <param name="dy">Distance in pixels along the Y axis.</param>
/// <param name="dz">Distance in pixels along the Z axis.</param>
void Translate(double dx, double dy, double dz);
    /// <summary>Apply a rotation to the object.
/// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
/// 
/// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
/// 
/// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.
/// (Since EFL 1.22)</summary>
/// <param name="degrees">CCW rotation in degrees.</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
/// <param name="cx">X relative coordinate of the center point.</param>
/// <param name="cy">y relative coordinate of the center point.</param>
void Rotate(double degrees, Efl.Gfx.IEntity pivot, double cx, double cy);
    /// <summary>Rotate the object around 3 axes in 3D.
/// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.IMapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
/// 
/// As with <see cref="Efl.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
/// (Since EFL 1.22)</summary>
/// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
/// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
/// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
/// <param name="cx">X relative coordinate of the center point.</param>
/// <param name="cy">y relative coordinate of the center point.</param>
/// <param name="cz">Z absolute coordinate of the center point.</param>
void Rotate3d(double dx, double dy, double dz, Efl.Gfx.IEntity pivot, double cx, double cy, double cz);
    /// <summary>Rotate the object in 3D using a unit quaternion.
/// This is similar to <see cref="Efl.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
/// 
/// As with <see cref="Efl.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
/// (Since EFL 1.22)</summary>
/// <param name="qx">The x component of the imaginary part of the quaternion.</param>
/// <param name="qy">The y component of the imaginary part of the quaternion.</param>
/// <param name="qz">The z component of the imaginary part of the quaternion.</param>
/// <param name="qw">The w component of the real part of the quaternion.</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
/// <param name="cx">X relative coordinate of the center point.</param>
/// <param name="cy">y relative coordinate of the center point.</param>
/// <param name="cz">Z absolute coordinate of the center point.</param>
void RotateQuat(double qx, double qy, double qz, double qw, Efl.Gfx.IEntity pivot, double cx, double cy, double cz);
    /// <summary>Apply a zoom to the object.
/// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
/// 
/// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.
/// (Since EFL 1.22)</summary>
/// <param name="zoomx">Zoom in X direction</param>
/// <param name="zoomy">Zoom in Y direction</param>
/// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
/// <param name="cx">X relative coordinate of the center point.</param>
/// <param name="cy">y relative coordinate of the center point.</param>
void Zoom(double zoomx, double zoomy, Efl.Gfx.IEntity pivot, double cx, double cy);
    /// <summary>Apply a lighting effect on the object.
/// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
/// 
/// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
/// (Since EFL 1.22)</summary>
/// <param name="pivot">A pivot object for the light point, can be <c>null</c>.</param>
/// <param name="lx">X relative coordinate in space of light point.</param>
/// <param name="ly">Y relative coordinate in space of light point.</param>
/// <param name="lz">Z absolute coordinate in space of light point.</param>
/// <param name="lr">Light red value (0 - 255).</param>
/// <param name="lg">Light green value (0 - 255).</param>
/// <param name="lb">Light blue value (0 - 255).</param>
/// <param name="ar">Ambient color red value (0 - 255).</param>
/// <param name="ag">Ambient color green value (0 - 255).</param>
/// <param name="ab">Ambient color blue value (0 - 255).</param>
void Lighting3d(Efl.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab);
    /// <summary>Apply a perspective transform to the map
/// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
/// 
/// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
/// (Since EFL 1.22)</summary>
/// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.</param>
/// <param name="px">The perspective distance X relative coordinate.</param>
/// <param name="py">The perspective distance Y relative coordinate.</param>
/// <param name="z0">The &quot;0&quot; Z plane value.</param>
/// <param name="foc">The focal distance, must be greater than 0.</param>
void Perspective3d(Efl.Gfx.IEntity pivot, double px, double py, double z0, double foc);
    /// <summary>Apply a rotation to the object, using absolute coordinates.
/// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
/// 
/// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.IMapping.Rotate"/> for a relative coordinate version.
/// (Since EFL 1.22)</summary>
/// <param name="degrees">CCW rotation in degrees.</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.</param>
void RotateAbsolute(double degrees, double cx, double cy);
    /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
/// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.IMapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Rotate3d"/> for a pivot-based 3D rotation.
/// (Since EFL 1.22)</summary>
/// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
/// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
/// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.</param>
/// <param name="cz">Z absolute coordinate of the center point.</param>
void Rotate3dAbsolute(double dx, double dy, double dz, double cx, double cy, double cz);
    /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
/// This is similar to <see cref="Efl.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.RotateQuat"/> for a pivot-based 3D rotation.
/// (Since EFL 1.22)</summary>
/// <param name="qx">The x component of the imaginary part of the quaternion.</param>
/// <param name="qy">The y component of the imaginary part of the quaternion.</param>
/// <param name="qz">The z component of the imaginary part of the quaternion.</param>
/// <param name="qw">The w component of the real part of the quaternion.</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.</param>
/// <param name="cz">Z absolute coordinate of the center point.</param>
void RotateQuatAbsolute(double qx, double qy, double qz, double qw, double cx, double cy, double cz);
    /// <summary>Apply a zoom to the object, using absolute coordinates.
/// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Zoom"/> for a pivot-based zoom.
/// (Since EFL 1.22)</summary>
/// <param name="zoomx">Zoom in X direction</param>
/// <param name="zoomy">Zoom in Y direction</param>
/// <param name="cx">X absolute coordinate in pixels of the center point.</param>
/// <param name="cy">y absolute coordinate in pixels of the center point.</param>
void ZoomAbsolute(double zoomx, double zoomy, double cx, double cy);
    /// <summary>Apply a lighting effect to the object.
/// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Lighting3d"/> for a pivot-based lighting effect.
/// (Since EFL 1.22)</summary>
/// <param name="lx">X absolute coordinate in pixels of the light point.</param>
/// <param name="ly">y absolute coordinate in pixels of the light point.</param>
/// <param name="lz">Z absolute coordinate in space of light point.</param>
/// <param name="lr">Light red value (0 - 255).</param>
/// <param name="lg">Light green value (0 - 255).</param>
/// <param name="lb">Light blue value (0 - 255).</param>
/// <param name="ar">Ambient color red value (0 - 255).</param>
/// <param name="ag">Ambient color green value (0 - 255).</param>
/// <param name="ab">Ambient color blue value (0 - 255).</param>
void Lighting3dAbsolute(double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab);
    /// <summary>Apply a perspective transform to the map
/// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
/// 
/// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Perspective3d"/> for a pivot-based perspective effect.
/// (Since EFL 1.22)</summary>
/// <param name="px">The perspective distance X relative coordinate.</param>
/// <param name="py">The perspective distance Y relative coordinate.</param>
/// <param name="z0">The &quot;0&quot; Z plane value.</param>
/// <param name="foc">The focal distance, must be greater than 0.</param>
void Perspective3dAbsolute(double px, double py, double z0, double foc);
                                                                                                                    /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// (Since EFL 1.22)</summary>
/// <value>The number of points of map</value>
    int MappingPointCount {
        get ;
        set ;
    }
    /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise</value>
    bool MappingClockwise {
        get ;
    }
    /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> by default.</value>
    bool MappingSmooth {
        get ;
        set ;
    }
    /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> by default.</value>
    bool MappingAlpha {
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
/// (Since EFL 1.22)</summary>
sealed public class IMappingConcrete : 

IMapping
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IMappingConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_gfx_mapping_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IMapping"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IMappingConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IMappingConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
    /// (Since EFL 1.22)</summary>
    /// <returns>The number of points of map</returns>
    public int GetMappingPointCount() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_point_count_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Number of points of a map.
    /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
    /// (Since EFL 1.22)</summary>
    /// <param name="count">The number of points of map</param>
    public void SetMappingPointCount(int count) {
                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_point_count_set_ptr.Value.Delegate(this.NativeHandle,count);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Clockwise state of a map (read-only).
    /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise</returns>
    public bool GetMappingClockwise() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_clockwise_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> by default.</returns>
    public bool GetMappingSmooth() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_smooth_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Smoothing state for map rendering.
    /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
    /// (Since EFL 1.22)</summary>
    /// <param name="smooth"><c>true</c> by default.</param>
    public void SetMappingSmooth(bool smooth) {
                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_smooth_set_ptr.Value.Delegate(this.NativeHandle,smooth);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> by default.</returns>
    public bool GetMappingAlpha() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_alpha_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Alpha flag for map rendering.
    /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
    /// 
    /// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
    /// (Since EFL 1.22)</summary>
    /// <param name="alpha"><c>true</c> by default.</param>
    public void SetMappingAlpha(bool alpha) {
                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_alpha_set_ptr.Value.Delegate(this.NativeHandle,alpha);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A point&apos;s absolute coordinate on the canvas.
    /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
    /// 
    /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
    /// 
    /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
    /// 
    /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
    /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
    /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
    public void GetMappingCoordAbsolute(int idx, out double x, out double y, out double z) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate(this.NativeHandle,idx, out x, out y, out z);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>A point&apos;s absolute coordinate on the canvas.
    /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
    /// 
    /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
    /// 
    /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
    /// 
    /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
    /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
    /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
    public void SetMappingCoordAbsolute(int idx, double x, double y, double z) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate(this.NativeHandle,idx, x, y, z);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Map point&apos;s U and V texture source point.
    /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
    /// 
    /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
    /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
    public void GetMappingUv(int idx, out double u, out double v) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_uv_get_ptr.Value.Delegate(this.NativeHandle,idx, out u, out v);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Map point&apos;s U and V texture source point.
    /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
    /// 
    /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
    /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
    /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
    public void SetMappingUv(int idx, double u, double v) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_uv_set_ptr.Value.Delegate(this.NativeHandle,idx, u, v);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Color of a vertex in the map.
    /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
    /// 
    /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
    /// <param name="r">Red (0 - 255)</param>
    /// <param name="g">Green (0 - 255)</param>
    /// <param name="b">Blue (0 - 255)</param>
    /// <param name="a">Alpha (0 - 255)</param>
    public void GetMappingColor(int idx, out int r, out int g, out int b, out int a) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_color_get_ptr.Value.Delegate(this.NativeHandle,idx, out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Color of a vertex in the map.
    /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
    /// 
    /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
    /// (Since EFL 1.22)</summary>
    /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
    /// <param name="r">Red (0 - 255)</param>
    /// <param name="g">Green (0 - 255)</param>
    /// <param name="b">Blue (0 - 255)</param>
    /// <param name="a">Alpha (0 - 255)</param>
    public void SetMappingColor(int idx, int r, int g, int b, int a) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_color_set_ptr.Value.Delegate(this.NativeHandle,idx, r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Read-only property indicating whether an object is mapped.
    /// This will be <c>true</c> if any transformation is applied to this object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is mapped.</returns>
    public bool HasMapping() {
         var _ret_var = Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_has_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the map transformation to its default state.
    /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.IMapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.IMapping.MappingSmooth"/> or <see cref="Efl.Gfx.IMapping.MappingAlpha"/>.
    /// (Since EFL 1.22)</summary>
    public void ResetMapping() {
         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_reset_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Apply a translation to the object using map.
    /// This does not change the real geometry of the object but will affect its visible position.
    /// (Since EFL 1.22)</summary>
    /// <param name="dx">Distance in pixels along the X axis.</param>
    /// <param name="dy">Distance in pixels along the Y axis.</param>
    /// <param name="dz">Distance in pixels along the Z axis.</param>
    public void Translate(double dx, double dy, double dz) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_translate_ptr.Value.Delegate(this.NativeHandle,dx, dy, dz);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Apply a rotation to the object.
    /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
    /// 
    /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.
    /// (Since EFL 1.22)</summary>
    /// <param name="degrees">CCW rotation in degrees.</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    public void Rotate(double degrees, Efl.Gfx.IEntity pivot, double cx, double cy) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_ptr.Value.Delegate(this.NativeHandle,degrees, pivot, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Rotate the object around 3 axes in 3D.
    /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.IMapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
    /// 
    /// As with <see cref="Efl.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
    /// (Since EFL 1.22)</summary>
    /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
    /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
    /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public void Rotate3d(double dx, double dy, double dz, Efl.Gfx.IEntity pivot, double cx, double cy, double cz) {
                                                                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_3d_ptr.Value.Delegate(this.NativeHandle,dx, dy, dz, pivot, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Rotate the object in 3D using a unit quaternion.
    /// This is similar to <see cref="Efl.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
    /// 
    /// As with <see cref="Efl.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
    /// (Since EFL 1.22)</summary>
    /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
    /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
    /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
    /// <param name="qw">The w component of the real part of the quaternion.</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public void RotateQuat(double qx, double qy, double qz, double qw, Efl.Gfx.IEntity pivot, double cx, double cy, double cz) {
                                                                                                                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_quat_ptr.Value.Delegate(this.NativeHandle,qx, qy, qz, qw, pivot, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                         }
    /// <summary>Apply a zoom to the object.
    /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
    /// 
    /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.
    /// (Since EFL 1.22)</summary>
    /// <param name="zoomx">Zoom in X direction</param>
    /// <param name="zoomy">Zoom in Y direction</param>
    /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
    /// <param name="cx">X relative coordinate of the center point.</param>
    /// <param name="cy">y relative coordinate of the center point.</param>
    public void Zoom(double zoomx, double zoomy, Efl.Gfx.IEntity pivot, double cx, double cy) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_zoom_ptr.Value.Delegate(this.NativeHandle,zoomx, zoomy, pivot, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Apply a lighting effect on the object.
    /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
    /// (Since EFL 1.22)</summary>
    /// <param name="pivot">A pivot object for the light point, can be <c>null</c>.</param>
    /// <param name="lx">X relative coordinate in space of light point.</param>
    /// <param name="ly">Y relative coordinate in space of light point.</param>
    /// <param name="lz">Z absolute coordinate in space of light point.</param>
    /// <param name="lr">Light red value (0 - 255).</param>
    /// <param name="lg">Light green value (0 - 255).</param>
    /// <param name="lb">Light blue value (0 - 255).</param>
    /// <param name="ar">Ambient color red value (0 - 255).</param>
    /// <param name="ag">Ambient color green value (0 - 255).</param>
    /// <param name="ab">Ambient color blue value (0 - 255).</param>
    public void Lighting3d(Efl.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
                                                                                                                                                                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_lighting_3d_ptr.Value.Delegate(this.NativeHandle,pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                                         }
    /// <summary>Apply a perspective transform to the map
    /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
    /// 
    /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
    /// (Since EFL 1.22)</summary>
    /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.</param>
    /// <param name="px">The perspective distance X relative coordinate.</param>
    /// <param name="py">The perspective distance Y relative coordinate.</param>
    /// <param name="z0">The &quot;0&quot; Z plane value.</param>
    /// <param name="foc">The focal distance, must be greater than 0.</param>
    public void Perspective3d(Efl.Gfx.IEntity pivot, double px, double py, double z0, double foc) {
                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_perspective_3d_ptr.Value.Delegate(this.NativeHandle,pivot, px, py, z0, foc);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Apply a rotation to the object, using absolute coordinates.
    /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
    /// 
    /// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.IMapping.Rotate"/> for a relative coordinate version.
    /// (Since EFL 1.22)</summary>
    /// <param name="degrees">CCW rotation in degrees.</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    public void RotateAbsolute(double degrees, double cx, double cy) {
                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate(this.NativeHandle,degrees, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
    /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.IMapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Rotate3d"/> for a pivot-based 3D rotation.
    /// (Since EFL 1.22)</summary>
    /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
    /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
    /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public void Rotate3dAbsolute(double dx, double dy, double dz, double cx, double cy, double cz) {
                                                                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate(this.NativeHandle,dx, dy, dz, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                         }
    /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
    /// This is similar to <see cref="Efl.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.RotateQuat"/> for a pivot-based 3D rotation.
    /// (Since EFL 1.22)</summary>
    /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
    /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
    /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
    /// <param name="qw">The w component of the real part of the quaternion.</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    /// <param name="cz">Z absolute coordinate of the center point.</param>
    public void RotateQuatAbsolute(double qx, double qy, double qz, double qw, double cx, double cy, double cz) {
                                                                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate(this.NativeHandle,qx, qy, qz, qw, cx, cy, cz);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                         }
    /// <summary>Apply a zoom to the object, using absolute coordinates.
    /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Zoom"/> for a pivot-based zoom.
    /// (Since EFL 1.22)</summary>
    /// <param name="zoomx">Zoom in X direction</param>
    /// <param name="zoomy">Zoom in Y direction</param>
    /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
    /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
    public void ZoomAbsolute(double zoomx, double zoomy, double cx, double cy) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate(this.NativeHandle,zoomx, zoomy, cx, cy);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Apply a lighting effect to the object.
    /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Lighting3d"/> for a pivot-based lighting effect.
    /// (Since EFL 1.22)</summary>
    /// <param name="lx">X absolute coordinate in pixels of the light point.</param>
    /// <param name="ly">y absolute coordinate in pixels of the light point.</param>
    /// <param name="lz">Z absolute coordinate in space of light point.</param>
    /// <param name="lr">Light red value (0 - 255).</param>
    /// <param name="lg">Light green value (0 - 255).</param>
    /// <param name="lb">Light blue value (0 - 255).</param>
    /// <param name="ar">Ambient color red value (0 - 255).</param>
    /// <param name="ag">Ambient color green value (0 - 255).</param>
    /// <param name="ab">Ambient color blue value (0 - 255).</param>
    public void Lighting3dAbsolute(double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
                                                                                                                                                                                                                                 Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate(this.NativeHandle,lx, ly, lz, lr, lg, lb, ar, ag, ab);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                         }
    /// <summary>Apply a perspective transform to the map
    /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
    /// 
    /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.IMapping.Perspective3d"/> for a pivot-based perspective effect.
    /// (Since EFL 1.22)</summary>
    /// <param name="px">The perspective distance X relative coordinate.</param>
    /// <param name="py">The perspective distance Y relative coordinate.</param>
    /// <param name="z0">The &quot;0&quot; Z plane value.</param>
    /// <param name="foc">The focal distance, must be greater than 0.</param>
    public void Perspective3dAbsolute(double px, double py, double z0, double foc) {
                                                                                                         Efl.Gfx.IMappingConcrete.NativeMethods.efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate(this.NativeHandle,px, py, z0, foc);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// (Since EFL 1.22)</summary>
/// <value>The number of points of map</value>
    public int MappingPointCount {
        get { return GetMappingPointCount(); }
        set { SetMappingPointCount(value); }
    }
    /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise</value>
    public bool MappingClockwise {
        get { return GetMappingClockwise(); }
    }
    /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> by default.</value>
    public bool MappingSmooth {
        get { return GetMappingSmooth(); }
        set { SetMappingSmooth(value); }
    }
    /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> by default.</value>
    public bool MappingAlpha {
        get { return GetMappingAlpha(); }
        set { SetMappingAlpha(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IMappingConcrete.efl_gfx_mapping_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_mapping_point_count_get_static_delegate == null)
            {
                efl_gfx_mapping_point_count_get_static_delegate = new efl_gfx_mapping_point_count_get_delegate(mapping_point_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingPointCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_point_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_get_static_delegate) });
            }

            if (efl_gfx_mapping_point_count_set_static_delegate == null)
            {
                efl_gfx_mapping_point_count_set_static_delegate = new efl_gfx_mapping_point_count_set_delegate(mapping_point_count_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingPointCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_point_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_set_static_delegate) });
            }

            if (efl_gfx_mapping_clockwise_get_static_delegate == null)
            {
                efl_gfx_mapping_clockwise_get_static_delegate = new efl_gfx_mapping_clockwise_get_delegate(mapping_clockwise_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingClockwise") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_clockwise_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_clockwise_get_static_delegate) });
            }

            if (efl_gfx_mapping_smooth_get_static_delegate == null)
            {
                efl_gfx_mapping_smooth_get_static_delegate = new efl_gfx_mapping_smooth_get_delegate(mapping_smooth_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingSmooth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_smooth_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_get_static_delegate) });
            }

            if (efl_gfx_mapping_smooth_set_static_delegate == null)
            {
                efl_gfx_mapping_smooth_set_static_delegate = new efl_gfx_mapping_smooth_set_delegate(mapping_smooth_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingSmooth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_smooth_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_set_static_delegate) });
            }

            if (efl_gfx_mapping_alpha_get_static_delegate == null)
            {
                efl_gfx_mapping_alpha_get_static_delegate = new efl_gfx_mapping_alpha_get_delegate(mapping_alpha_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_get_static_delegate) });
            }

            if (efl_gfx_mapping_alpha_set_static_delegate == null)
            {
                efl_gfx_mapping_alpha_set_static_delegate = new efl_gfx_mapping_alpha_set_delegate(mapping_alpha_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingAlpha") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_set_static_delegate) });
            }

            if (efl_gfx_mapping_coord_absolute_get_static_delegate == null)
            {
                efl_gfx_mapping_coord_absolute_get_static_delegate = new efl_gfx_mapping_coord_absolute_get_delegate(mapping_coord_absolute_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingCoordAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_coord_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_get_static_delegate) });
            }

            if (efl_gfx_mapping_coord_absolute_set_static_delegate == null)
            {
                efl_gfx_mapping_coord_absolute_set_static_delegate = new efl_gfx_mapping_coord_absolute_set_delegate(mapping_coord_absolute_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingCoordAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_coord_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_set_static_delegate) });
            }

            if (efl_gfx_mapping_uv_get_static_delegate == null)
            {
                efl_gfx_mapping_uv_get_static_delegate = new efl_gfx_mapping_uv_get_delegate(mapping_uv_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingUv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_uv_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_get_static_delegate) });
            }

            if (efl_gfx_mapping_uv_set_static_delegate == null)
            {
                efl_gfx_mapping_uv_set_static_delegate = new efl_gfx_mapping_uv_set_delegate(mapping_uv_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingUv") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_uv_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_set_static_delegate) });
            }

            if (efl_gfx_mapping_color_get_static_delegate == null)
            {
                efl_gfx_mapping_color_get_static_delegate = new efl_gfx_mapping_color_get_delegate(mapping_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMappingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_get_static_delegate) });
            }

            if (efl_gfx_mapping_color_set_static_delegate == null)
            {
                efl_gfx_mapping_color_set_static_delegate = new efl_gfx_mapping_color_set_delegate(mapping_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMappingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_set_static_delegate) });
            }

            if (efl_gfx_mapping_has_static_delegate == null)
            {
                efl_gfx_mapping_has_static_delegate = new efl_gfx_mapping_has_delegate(mapping_has);
            }

            if (methods.FirstOrDefault(m => m.Name == "HasMapping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_has"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_has_static_delegate) });
            }

            if (efl_gfx_mapping_reset_static_delegate == null)
            {
                efl_gfx_mapping_reset_static_delegate = new efl_gfx_mapping_reset_delegate(mapping_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetMapping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_reset_static_delegate) });
            }

            if (efl_gfx_mapping_translate_static_delegate == null)
            {
                efl_gfx_mapping_translate_static_delegate = new efl_gfx_mapping_translate_delegate(translate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Translate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_translate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_translate_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_static_delegate == null)
            {
                efl_gfx_mapping_rotate_static_delegate = new efl_gfx_mapping_rotate_delegate(rotate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Rotate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_3d_static_delegate == null)
            {
                efl_gfx_mapping_rotate_3d_static_delegate = new efl_gfx_mapping_rotate_3d_delegate(rotate_3d);
            }

            if (methods.FirstOrDefault(m => m.Name == "Rotate3d") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_quat_static_delegate == null)
            {
                efl_gfx_mapping_rotate_quat_static_delegate = new efl_gfx_mapping_rotate_quat_delegate(rotate_quat);
            }

            if (methods.FirstOrDefault(m => m.Name == "RotateQuat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_quat"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_static_delegate) });
            }

            if (efl_gfx_mapping_zoom_static_delegate == null)
            {
                efl_gfx_mapping_zoom_static_delegate = new efl_gfx_mapping_zoom_delegate(zoom);
            }

            if (methods.FirstOrDefault(m => m.Name == "Zoom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_zoom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_static_delegate) });
            }

            if (efl_gfx_mapping_lighting_3d_static_delegate == null)
            {
                efl_gfx_mapping_lighting_3d_static_delegate = new efl_gfx_mapping_lighting_3d_delegate(lighting_3d);
            }

            if (methods.FirstOrDefault(m => m.Name == "Lighting3d") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_lighting_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_static_delegate) });
            }

            if (efl_gfx_mapping_perspective_3d_static_delegate == null)
            {
                efl_gfx_mapping_perspective_3d_static_delegate = new efl_gfx_mapping_perspective_3d_delegate(perspective_3d);
            }

            if (methods.FirstOrDefault(m => m.Name == "Perspective3d") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_perspective_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_absolute_static_delegate = new efl_gfx_mapping_rotate_absolute_delegate(rotate_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "RotateAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_3d_absolute_static_delegate = new efl_gfx_mapping_rotate_3d_absolute_delegate(rotate_3d_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "Rotate3dAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_quat_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_quat_absolute_static_delegate = new efl_gfx_mapping_rotate_quat_absolute_delegate(rotate_quat_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "RotateQuatAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_quat_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_zoom_absolute_static_delegate == null)
            {
                efl_gfx_mapping_zoom_absolute_static_delegate = new efl_gfx_mapping_zoom_absolute_delegate(zoom_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "ZoomAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_zoom_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_lighting_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_lighting_3d_absolute_static_delegate = new efl_gfx_mapping_lighting_3d_absolute_delegate(lighting_3d_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "Lighting3dAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_lighting_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_perspective_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_perspective_3d_absolute_static_delegate = new efl_gfx_mapping_perspective_3d_absolute_delegate(perspective_3d_absolute);
            }

            if (methods.FirstOrDefault(m => m.Name == "Perspective3dAbsolute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_perspective_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_absolute_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.IMappingConcrete.efl_gfx_mapping_mixin_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate int efl_gfx_mapping_point_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_gfx_mapping_point_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate> efl_gfx_mapping_point_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate>(Module, "efl_gfx_mapping_point_count_get");

        private static int mapping_point_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_point_count_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IMappingConcrete)wrapper).GetMappingPointCount();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_mapping_point_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_point_count_get_delegate efl_gfx_mapping_point_count_get_static_delegate;

        
        private delegate void efl_gfx_mapping_point_count_set_delegate(System.IntPtr obj, System.IntPtr pd,  int count);

        
        public delegate void efl_gfx_mapping_point_count_set_api_delegate(System.IntPtr obj,  int count);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate> efl_gfx_mapping_point_count_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate>(Module, "efl_gfx_mapping_point_count_set");

        private static void mapping_point_count_set(System.IntPtr obj, System.IntPtr pd, int count)
        {
            Eina.Log.Debug("function efl_gfx_mapping_point_count_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((IMappingConcrete)wrapper).SetMappingPointCount(count);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_mapping_point_count_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), count);
            }
        }

        private static efl_gfx_mapping_point_count_set_delegate efl_gfx_mapping_point_count_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_clockwise_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_clockwise_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate> efl_gfx_mapping_clockwise_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate>(Module, "efl_gfx_mapping_clockwise_get");

        private static bool mapping_clockwise_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_clockwise_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMappingConcrete)wrapper).GetMappingClockwise();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_mapping_clockwise_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_clockwise_get_delegate efl_gfx_mapping_clockwise_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_smooth_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_smooth_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate> efl_gfx_mapping_smooth_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate>(Module, "efl_gfx_mapping_smooth_get");

        private static bool mapping_smooth_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_smooth_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMappingConcrete)wrapper).GetMappingSmooth();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_mapping_smooth_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_smooth_get_delegate efl_gfx_mapping_smooth_get_static_delegate;

        
        private delegate void efl_gfx_mapping_smooth_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool smooth);

        
        public delegate void efl_gfx_mapping_smooth_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool smooth);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate> efl_gfx_mapping_smooth_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate>(Module, "efl_gfx_mapping_smooth_set");

        private static void mapping_smooth_set(System.IntPtr obj, System.IntPtr pd, bool smooth)
        {
            Eina.Log.Debug("function efl_gfx_mapping_smooth_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((IMappingConcrete)wrapper).SetMappingSmooth(smooth);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_mapping_smooth_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), smooth);
            }
        }

        private static efl_gfx_mapping_smooth_set_delegate efl_gfx_mapping_smooth_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_alpha_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate> efl_gfx_mapping_alpha_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate>(Module, "efl_gfx_mapping_alpha_get");

        private static bool mapping_alpha_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_alpha_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMappingConcrete)wrapper).GetMappingAlpha();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_mapping_alpha_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_alpha_get_delegate efl_gfx_mapping_alpha_get_static_delegate;

        
        private delegate void efl_gfx_mapping_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

        
        public delegate void efl_gfx_mapping_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate> efl_gfx_mapping_alpha_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate>(Module, "efl_gfx_mapping_alpha_set");

        private static void mapping_alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
        {
            Eina.Log.Debug("function efl_gfx_mapping_alpha_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((IMappingConcrete)wrapper).SetMappingAlpha(alpha);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_mapping_alpha_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), alpha);
            }
        }

        private static efl_gfx_mapping_alpha_set_delegate efl_gfx_mapping_alpha_set_static_delegate;

        
        private delegate void efl_gfx_mapping_coord_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out double x,  out double y,  out double z);

        
        public delegate void efl_gfx_mapping_coord_absolute_get_api_delegate(System.IntPtr obj,  int idx,  out double x,  out double y,  out double z);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate> efl_gfx_mapping_coord_absolute_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate>(Module, "efl_gfx_mapping_coord_absolute_get");

        private static void mapping_coord_absolute_get(System.IntPtr obj, System.IntPtr pd, int idx, out double x, out double y, out double z)
        {
            Eina.Log.Debug("function efl_gfx_mapping_coord_absolute_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                x = default(double);        y = default(double);        z = default(double);                                            
                try
                {
                    ((IMappingConcrete)wrapper).GetMappingCoordAbsolute(idx, out x, out y, out z);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, out x, out y, out z);
            }
        }

        private static efl_gfx_mapping_coord_absolute_get_delegate efl_gfx_mapping_coord_absolute_get_static_delegate;

        
        private delegate void efl_gfx_mapping_coord_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  double x,  double y,  double z);

        
        public delegate void efl_gfx_mapping_coord_absolute_set_api_delegate(System.IntPtr obj,  int idx,  double x,  double y,  double z);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate> efl_gfx_mapping_coord_absolute_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate>(Module, "efl_gfx_mapping_coord_absolute_set");

        private static void mapping_coord_absolute_set(System.IntPtr obj, System.IntPtr pd, int idx, double x, double y, double z)
        {
            Eina.Log.Debug("function efl_gfx_mapping_coord_absolute_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).SetMappingCoordAbsolute(idx, x, y, z);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, x, y, z);
            }
        }

        private static efl_gfx_mapping_coord_absolute_set_delegate efl_gfx_mapping_coord_absolute_set_static_delegate;

        
        private delegate void efl_gfx_mapping_uv_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out double u,  out double v);

        
        public delegate void efl_gfx_mapping_uv_get_api_delegate(System.IntPtr obj,  int idx,  out double u,  out double v);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate> efl_gfx_mapping_uv_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate>(Module, "efl_gfx_mapping_uv_get");

        private static void mapping_uv_get(System.IntPtr obj, System.IntPtr pd, int idx, out double u, out double v)
        {
            Eina.Log.Debug("function efl_gfx_mapping_uv_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                        u = default(double);        v = default(double);                                    
                try
                {
                    ((IMappingConcrete)wrapper).GetMappingUv(idx, out u, out v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_uv_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, out u, out v);
            }
        }

        private static efl_gfx_mapping_uv_get_delegate efl_gfx_mapping_uv_get_static_delegate;

        
        private delegate void efl_gfx_mapping_uv_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  double u,  double v);

        
        public delegate void efl_gfx_mapping_uv_set_api_delegate(System.IntPtr obj,  int idx,  double u,  double v);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate> efl_gfx_mapping_uv_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate>(Module, "efl_gfx_mapping_uv_set");

        private static void mapping_uv_set(System.IntPtr obj, System.IntPtr pd, int idx, double u, double v)
        {
            Eina.Log.Debug("function efl_gfx_mapping_uv_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).SetMappingUv(idx, u, v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_uv_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, u, v);
            }
        }

        private static efl_gfx_mapping_uv_set_delegate efl_gfx_mapping_uv_set_static_delegate;

        
        private delegate void efl_gfx_mapping_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out int r,  out int g,  out int b,  out int a);

        
        public delegate void efl_gfx_mapping_color_get_api_delegate(System.IntPtr obj,  int idx,  out int r,  out int g,  out int b,  out int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate> efl_gfx_mapping_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate>(Module, "efl_gfx_mapping_color_get");

        private static void mapping_color_get(System.IntPtr obj, System.IntPtr pd, int idx, out int r, out int g, out int b, out int a)
        {
            Eina.Log.Debug("function efl_gfx_mapping_color_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                        r = default(int);        g = default(int);        b = default(int);        a = default(int);                                                    
                try
                {
                    ((IMappingConcrete)wrapper).GetMappingColor(idx, out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, out r, out g, out b, out a);
            }
        }

        private static efl_gfx_mapping_color_get_delegate efl_gfx_mapping_color_get_static_delegate;

        
        private delegate void efl_gfx_mapping_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  int r,  int g,  int b,  int a);

        
        public delegate void efl_gfx_mapping_color_set_api_delegate(System.IntPtr obj,  int idx,  int r,  int g,  int b,  int a);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate> efl_gfx_mapping_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate>(Module, "efl_gfx_mapping_color_set");

        private static void mapping_color_set(System.IntPtr obj, System.IntPtr pd, int idx, int r, int g, int b, int a)
        {
            Eina.Log.Debug("function efl_gfx_mapping_color_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).SetMappingColor(idx, r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx, r, g, b, a);
            }
        }

        private static efl_gfx_mapping_color_set_delegate efl_gfx_mapping_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_has_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_gfx_mapping_has_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_has_api_delegate> efl_gfx_mapping_has_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_has_api_delegate>(Module, "efl_gfx_mapping_has");

        private static bool mapping_has(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_has was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMappingConcrete)wrapper).HasMapping();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_gfx_mapping_has_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_has_delegate efl_gfx_mapping_has_static_delegate;

        
        private delegate void efl_gfx_mapping_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_gfx_mapping_reset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_reset_api_delegate> efl_gfx_mapping_reset_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_reset_api_delegate>(Module, "efl_gfx_mapping_reset");

        private static void mapping_reset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_mapping_reset was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            
                try
                {
                    ((IMappingConcrete)wrapper).ResetMapping();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_gfx_mapping_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_mapping_reset_delegate efl_gfx_mapping_reset_static_delegate;

        
        private delegate void efl_gfx_mapping_translate_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz);

        
        public delegate void efl_gfx_mapping_translate_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_translate_api_delegate> efl_gfx_mapping_translate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_translate_api_delegate>(Module, "efl_gfx_mapping_translate");

        private static void translate(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_translate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).Translate(dx, dy, dz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_translate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dx, dy, dz);
            }
        }

        private static efl_gfx_mapping_translate_delegate efl_gfx_mapping_translate_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_delegate(System.IntPtr obj, System.IntPtr pd,  double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_rotate_api_delegate(System.IntPtr obj,  double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate> efl_gfx_mapping_rotate_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate>(Module, "efl_gfx_mapping_rotate");

        private static void rotate(System.IntPtr obj, System.IntPtr pd, double degrees, Efl.Gfx.IEntity pivot, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).Rotate(degrees, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), degrees, pivot, cx, cy);
            }
        }

        private static efl_gfx_mapping_rotate_delegate efl_gfx_mapping_rotate_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_3d_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_3d_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate> efl_gfx_mapping_rotate_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate>(Module, "efl_gfx_mapping_rotate_3d");

        private static void rotate_3d(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz, Efl.Gfx.IEntity pivot, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_3d was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).Rotate3d(dx, dy, dz, pivot, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dx, dy, dz, pivot, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_3d_delegate efl_gfx_mapping_rotate_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_quat_delegate(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_quat_api_delegate(System.IntPtr obj,  double qx,  double qy,  double qz,  double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate> efl_gfx_mapping_rotate_quat_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate>(Module, "efl_gfx_mapping_rotate_quat");

        private static void rotate_quat(System.IntPtr obj, System.IntPtr pd, double qx, double qy, double qz, double qw, Efl.Gfx.IEntity pivot, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_quat was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).RotateQuat(qx, qy, qz, qw, pivot, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_quat_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), qx, qy, qz, qw, pivot, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_quat_delegate efl_gfx_mapping_rotate_quat_static_delegate;

        
        private delegate void efl_gfx_mapping_zoom_delegate(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_zoom_api_delegate(System.IntPtr obj,  double zoomx,  double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate> efl_gfx_mapping_zoom_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate>(Module, "efl_gfx_mapping_zoom");

        private static void zoom(System.IntPtr obj, System.IntPtr pd, double zoomx, double zoomy, Efl.Gfx.IEntity pivot, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_zoom was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).Zoom(zoomx, zoomy, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_zoom_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), zoomx, zoomy, pivot, cx, cy);
            }
        }

        private static efl_gfx_mapping_zoom_delegate efl_gfx_mapping_zoom_static_delegate;

        
        private delegate void efl_gfx_mapping_lighting_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        
        public delegate void efl_gfx_mapping_lighting_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate> efl_gfx_mapping_lighting_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate>(Module, "efl_gfx_mapping_lighting_3d");

        private static void lighting_3d(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab)
        {
            Eina.Log.Debug("function efl_gfx_mapping_lighting_3d was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                                                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).Lighting3d(pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_lighting_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
            }
        }

        private static efl_gfx_mapping_lighting_3d_delegate efl_gfx_mapping_lighting_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_perspective_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double px,  double py,  double z0,  double foc);

        
        public delegate void efl_gfx_mapping_perspective_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity pivot,  double px,  double py,  double z0,  double foc);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate> efl_gfx_mapping_perspective_3d_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate>(Module, "efl_gfx_mapping_perspective_3d");

        private static void perspective_3d(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity pivot, double px, double py, double z0, double foc)
        {
            Eina.Log.Debug("function efl_gfx_mapping_perspective_3d was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).Perspective3d(pivot, px, py, z0, foc);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_gfx_mapping_perspective_3d_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pivot, px, py, z0, foc);
            }
        }

        private static efl_gfx_mapping_perspective_3d_delegate efl_gfx_mapping_perspective_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double degrees,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_rotate_absolute_api_delegate(System.IntPtr obj,  double degrees,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate> efl_gfx_mapping_rotate_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_absolute");

        private static void rotate_absolute(System.IntPtr obj, System.IntPtr pd, double degrees, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_absolute was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).RotateAbsolute(degrees, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), degrees, cx, cy);
            }
        }

        private static efl_gfx_mapping_rotate_absolute_delegate efl_gfx_mapping_rotate_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_3d_absolute_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate> efl_gfx_mapping_rotate_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_3d_absolute");

        private static void rotate_3d_absolute(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_3d_absolute was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).Rotate3dAbsolute(dx, dy, dz, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dx, dy, dz, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_3d_absolute_delegate efl_gfx_mapping_rotate_3d_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_quat_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);

        
        public delegate void efl_gfx_mapping_rotate_quat_absolute_api_delegate(System.IntPtr obj,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate> efl_gfx_mapping_rotate_quat_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_quat_absolute");

        private static void rotate_quat_absolute(System.IntPtr obj, System.IntPtr pd, double qx, double qy, double qz, double qw, double cx, double cy, double cz)
        {
            Eina.Log.Debug("function efl_gfx_mapping_rotate_quat_absolute was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).RotateQuatAbsolute(qx, qy, qz, qw, cx, cy, cz);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), qx, qy, qz, qw, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_quat_absolute_delegate efl_gfx_mapping_rotate_quat_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_zoom_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  double cx,  double cy);

        
        public delegate void efl_gfx_mapping_zoom_absolute_api_delegate(System.IntPtr obj,  double zoomx,  double zoomy,  double cx,  double cy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate> efl_gfx_mapping_zoom_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate>(Module, "efl_gfx_mapping_zoom_absolute");

        private static void zoom_absolute(System.IntPtr obj, System.IntPtr pd, double zoomx, double zoomy, double cx, double cy)
        {
            Eina.Log.Debug("function efl_gfx_mapping_zoom_absolute was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).ZoomAbsolute(zoomx, zoomy, cx, cy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), zoomx, zoomy, cx, cy);
            }
        }

        private static efl_gfx_mapping_zoom_absolute_delegate efl_gfx_mapping_zoom_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_lighting_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        
        public delegate void efl_gfx_mapping_lighting_3d_absolute_api_delegate(System.IntPtr obj,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate> efl_gfx_mapping_lighting_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_lighting_3d_absolute");

        private static void lighting_3d_absolute(System.IntPtr obj, System.IntPtr pd, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab)
        {
            Eina.Log.Debug("function efl_gfx_mapping_lighting_3d_absolute was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                                                                                                                                                    
                try
                {
                    ((IMappingConcrete)wrapper).Lighting3dAbsolute(lx, ly, lz, lr, lg, lb, ar, ag, ab);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                                                                                        
            }
            else
            {
                efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), lx, ly, lz, lr, lg, lb, ar, ag, ab);
            }
        }

        private static efl_gfx_mapping_lighting_3d_absolute_delegate efl_gfx_mapping_lighting_3d_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_perspective_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double px,  double py,  double z0,  double foc);

        
        public delegate void efl_gfx_mapping_perspective_3d_absolute_api_delegate(System.IntPtr obj,  double px,  double py,  double z0,  double foc);

        public static Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate> efl_gfx_mapping_perspective_3d_absolute_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_perspective_3d_absolute");

        private static void perspective_3d_absolute(System.IntPtr obj, System.IntPtr pd, double px, double py, double z0, double foc)
        {
            Eina.Log.Debug("function efl_gfx_mapping_perspective_3d_absolute was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                                            
                try
                {
                    ((IMappingConcrete)wrapper).Perspective3dAbsolute(px, py, z0, foc);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), px, py, z0, foc);
            }
        }

        private static efl_gfx_mapping_perspective_3d_absolute_delegate efl_gfx_mapping_perspective_3d_absolute_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

