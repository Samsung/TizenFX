/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.Gfx {
    /// <summary>Texture UV mapping for all objects (rotation, perspective, 3d, ...).
    /// 
    /// Evas allows different transformations to be applied to all kinds of objects. These are applied by means of UV mapping.
    /// 
    /// With UV mapping, one maps points in the source object to a 3D space positioning at target. This allows rotation, perspective, scale and lots of other effects, depending on the map that is used.
    /// 
    /// Each map point may carry a multiplier color. If properly calculated, these can do shading effects on the object, producing 3D effects.
    /// 
    /// At the moment of writing, maps can only have 4 points (no more, no less).</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IMappingNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IMapping : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Number of points of a map.
        /// 
        /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
        /// <returns>The number of points of map</returns>
        /// <since_tizen> 6 </since_tizen>
        int GetMappingPointCount();

        /// <summary>Number of points of a map.
        /// 
        /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
        /// <param name="count">The number of points of map</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMappingPointCount(int count);

        /// <summary>Clockwise state of a map (read-only).
        /// 
        /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.</summary>
        /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetMappingClockwise();

        /// <summary>Smoothing state for map rendering.
        /// 
        /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
        /// <returns><c>true</c> by default.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetMappingSmooth();

        /// <summary>Smoothing state for map rendering.
        /// 
        /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
        /// <param name="smooth"><c>true</c> by default.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMappingSmooth(bool smooth);

        /// <summary>Alpha flag for map rendering.
        /// 
        /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
        /// 
        /// Note that this may conflict with <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
        /// <returns><c>true</c> by default.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetMappingAlpha();

        /// <summary>Alpha flag for map rendering.
        /// 
        /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
        /// 
        /// Note that this may conflict with <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
        /// <param name="alpha"><c>true</c> by default.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMappingAlpha(bool alpha);

        /// <summary>A point&apos;s absolute coordinate on the canvas.
        /// 
        /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
        /// 
        /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
        /// 
        /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
        /// 
        /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
        /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
        /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
        /// <since_tizen> 6 </since_tizen>
        void GetMappingCoordAbsolute(int idx, out double x, out double y, out double z);

        /// <summary>A point&apos;s absolute coordinate on the canvas.
        /// 
        /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
        /// 
        /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
        /// 
        /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
        /// 
        /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
        /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
        /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMappingCoordAbsolute(int idx, double x, double y, double z);

        /// <summary>Map point&apos;s U and V texture source point.
        /// 
        /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
        /// 
        /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
        /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetMappingUv(int idx, out double u, out double v);

        /// <summary>Map point&apos;s U and V texture source point.
        /// 
        /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
        /// 
        /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
        /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMappingUv(int idx, double u, double v);

        /// <summary>Color of a vertex in the map.
        /// 
        /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
        /// 
        /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
        /// <param name="r">Red (0 - 255)</param>
        /// <param name="g">Green (0 - 255)</param>
        /// <param name="b">Blue (0 - 255)</param>
        /// <param name="a">Alpha (0 - 255)</param>
        /// <since_tizen> 6 </since_tizen>
        void GetMappingColor(int idx, out int r, out int g, out int b, out int a);

        /// <summary>Color of a vertex in the map.
        /// 
        /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
        /// 
        /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
        /// <param name="r">Red (0 - 255)</param>
        /// <param name="g">Green (0 - 255)</param>
        /// <param name="b">Blue (0 - 255)</param>
        /// <param name="a">Alpha (0 - 255)</param>
        /// <since_tizen> 6 </since_tizen>
        void SetMappingColor(int idx, int r, int g, int b, int a);

        /// <summary>Read-only property indicating whether an object is mapped.
        /// 
        /// This will be <c>true</c> if any transformation is applied to this object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> if the object is mapped.</returns>
        bool HasMapping();

        /// <summary>Resets the map transformation to its default state.
        /// 
        /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="CoreUI.Gfx.IMapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> or <see cref="CoreUI.Gfx.IMapping.MappingAlpha"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        void ResetMapping();

        /// <summary>Apply a translation to the object using map.
        /// 
        /// This does not change the real geometry of the object but will affect its visible position.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dx">Distance in pixels along the X axis.</param>
        /// <param name="dy">Distance in pixels along the Y axis.</param>
        /// <param name="dz">Distance in pixels along the Z axis.</param>
        void Translate(double dx, double dy, double dz);

        /// <summary>Apply a rotation to the object.
        /// 
        /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
        /// 
        /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
        /// 
        /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="degrees">CCW rotation in degrees.</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        void Rotate(double degrees, CoreUI.Gfx.IEntity pivot, double cx, double cy);

        /// <summary>Rotate the object around 3 axes in 3D.
        /// 
        /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="CoreUI.Gfx.IMapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
        /// 
        /// As with <see cref="CoreUI.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
        /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
        /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        void Rotate3d(double dx, double dy, double dz, CoreUI.Gfx.IEntity pivot, double cx, double cy, double cz);

        /// <summary>Rotate the object in 3D using a unit quaternion.
        /// 
        /// This is similar to <see cref="CoreUI.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
        /// 
        /// As with <see cref="CoreUI.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
        /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
        /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
        /// <param name="qw">The w component of the real part of the quaternion.</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        void RotateQuat(double qx, double qy, double qz, double qw, CoreUI.Gfx.IEntity pivot, double cx, double cy, double cz);

        /// <summary>Apply a zoom to the object.
        /// 
        /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
        /// 
        /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="zoomx">Zoom in X direction</param>
        /// <param name="zoomy">Zoom in Y direction</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        void Zoom(double zoomx, double zoomy, CoreUI.Gfx.IEntity pivot, double cx, double cy);

        /// <summary>Apply a lighting effect on the object.
        /// 
        /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
        /// 
        /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.</summary>
        /// <since_tizen> 6 </since_tizen>
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
        void Lighting3d(CoreUI.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab);

        /// <summary>Apply a perspective transform to the map
        /// 
        /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
        /// 
        /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.</param>
        /// <param name="px">The perspective distance X relative coordinate.</param>
        /// <param name="py">The perspective distance Y relative coordinate.</param>
        /// <param name="z0">The &quot;0&quot; Z plane value.</param>
        /// <param name="foc">The focal distance, must be greater than 0.</param>
        void Perspective3d(CoreUI.Gfx.IEntity pivot, double px, double py, double z0, double foc);

        /// <summary>Apply a rotation to the object, using absolute coordinates.
        /// 
        /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
        /// 
        /// The given coordinates are absolute values in pixels. See also <see cref="CoreUI.Gfx.IMapping.Rotate"/> for a relative coordinate version.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="degrees">CCW rotation in degrees.</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        void RotateAbsolute(double degrees, double cx, double cy);

        /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
        /// 
        /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="CoreUI.Gfx.IMapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Rotate3d"/> for a pivot-based 3D rotation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
        /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
        /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        void Rotate3dAbsolute(double dx, double dy, double dz, double cx, double cy, double cz);

        /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
        /// 
        /// This is similar to <see cref="CoreUI.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.RotateQuat"/> for a pivot-based 3D rotation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
        /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
        /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
        /// <param name="qw">The w component of the real part of the quaternion.</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        void RotateQuatAbsolute(double qx, double qy, double qz, double qw, double cx, double cy, double cz);

        /// <summary>Apply a zoom to the object, using absolute coordinates.
        /// 
        /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Zoom"/> for a pivot-based zoom.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="zoomx">Zoom in X direction</param>
        /// <param name="zoomy">Zoom in Y direction</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        void ZoomAbsolute(double zoomx, double zoomy, double cx, double cy);

        /// <summary>Apply a lighting effect to the object.
        /// 
        /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Lighting3d"/> for a pivot-based lighting effect.</summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// 
        /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Perspective3d"/> for a pivot-based perspective effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="px">The perspective distance X relative coordinate.</param>
        /// <param name="py">The perspective distance Y relative coordinate.</param>
        /// <param name="z0">The &quot;0&quot; Z plane value.</param>
        /// <param name="foc">The focal distance, must be greater than 0.</param>
        void Perspective3dAbsolute(double px, double py, double z0, double foc);

        /// <summary>Number of points of a map.
        /// 
        /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
        /// <value>The number of points of map</value>
        /// <since_tizen> 6 </since_tizen>
        int MappingPointCount {
            get;
            set;
        }

        /// <summary>Clockwise state of a map (read-only).
        /// 
        /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.</summary>
        /// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise</value>
        /// <since_tizen> 6 </since_tizen>
        bool MappingClockwise {
            get;
        }

        /// <summary>Smoothing state for map rendering.
        /// 
        /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
        /// <value><c>true</c> by default.</value>
        /// <since_tizen> 6 </since_tizen>
        bool MappingSmooth {
            get;
            set;
        }

        /// <summary>Alpha flag for map rendering.
        /// 
        /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
        /// 
        /// Note that this may conflict with <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
        /// <value><c>true</c> by default.</value>
        /// <since_tizen> 6 </since_tizen>
        bool MappingAlpha {
            get;
            set;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IMappingNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_gfx_mapping_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_mapping_point_count_get_static_delegate == null)
            {
                efl_gfx_mapping_point_count_get_static_delegate = new efl_gfx_mapping_point_count_get_delegate(mapping_point_count_get);
            }

            if (methods.Contains("GetMappingPointCount"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_point_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_get_static_delegate) });
            }

            if (efl_gfx_mapping_point_count_set_static_delegate == null)
            {
                efl_gfx_mapping_point_count_set_static_delegate = new efl_gfx_mapping_point_count_set_delegate(mapping_point_count_set);
            }

            if (methods.Contains("SetMappingPointCount"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_point_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_point_count_set_static_delegate) });
            }

            if (efl_gfx_mapping_clockwise_get_static_delegate == null)
            {
                efl_gfx_mapping_clockwise_get_static_delegate = new efl_gfx_mapping_clockwise_get_delegate(mapping_clockwise_get);
            }

            if (methods.Contains("GetMappingClockwise"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_clockwise_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_clockwise_get_static_delegate) });
            }

            if (efl_gfx_mapping_smooth_get_static_delegate == null)
            {
                efl_gfx_mapping_smooth_get_static_delegate = new efl_gfx_mapping_smooth_get_delegate(mapping_smooth_get);
            }

            if (methods.Contains("GetMappingSmooth"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_smooth_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_get_static_delegate) });
            }

            if (efl_gfx_mapping_smooth_set_static_delegate == null)
            {
                efl_gfx_mapping_smooth_set_static_delegate = new efl_gfx_mapping_smooth_set_delegate(mapping_smooth_set);
            }

            if (methods.Contains("SetMappingSmooth"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_smooth_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_smooth_set_static_delegate) });
            }

            if (efl_gfx_mapping_alpha_get_static_delegate == null)
            {
                efl_gfx_mapping_alpha_get_static_delegate = new efl_gfx_mapping_alpha_get_delegate(mapping_alpha_get);
            }

            if (methods.Contains("GetMappingAlpha"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_get_static_delegate) });
            }

            if (efl_gfx_mapping_alpha_set_static_delegate == null)
            {
                efl_gfx_mapping_alpha_set_static_delegate = new efl_gfx_mapping_alpha_set_delegate(mapping_alpha_set);
            }

            if (methods.Contains("SetMappingAlpha"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_alpha_set_static_delegate) });
            }

            if (efl_gfx_mapping_coord_absolute_get_static_delegate == null)
            {
                efl_gfx_mapping_coord_absolute_get_static_delegate = new efl_gfx_mapping_coord_absolute_get_delegate(mapping_coord_absolute_get);
            }

            if (methods.Contains("GetMappingCoordAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_coord_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_get_static_delegate) });
            }

            if (efl_gfx_mapping_coord_absolute_set_static_delegate == null)
            {
                efl_gfx_mapping_coord_absolute_set_static_delegate = new efl_gfx_mapping_coord_absolute_set_delegate(mapping_coord_absolute_set);
            }

            if (methods.Contains("SetMappingCoordAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_coord_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_coord_absolute_set_static_delegate) });
            }

            if (efl_gfx_mapping_uv_get_static_delegate == null)
            {
                efl_gfx_mapping_uv_get_static_delegate = new efl_gfx_mapping_uv_get_delegate(mapping_uv_get);
            }

            if (methods.Contains("GetMappingUv"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_uv_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_get_static_delegate) });
            }

            if (efl_gfx_mapping_uv_set_static_delegate == null)
            {
                efl_gfx_mapping_uv_set_static_delegate = new efl_gfx_mapping_uv_set_delegate(mapping_uv_set);
            }

            if (methods.Contains("SetMappingUv"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_uv_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_uv_set_static_delegate) });
            }

            if (efl_gfx_mapping_color_get_static_delegate == null)
            {
                efl_gfx_mapping_color_get_static_delegate = new efl_gfx_mapping_color_get_delegate(mapping_color_get);
            }

            if (methods.Contains("GetMappingColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_get_static_delegate) });
            }

            if (efl_gfx_mapping_color_set_static_delegate == null)
            {
                efl_gfx_mapping_color_set_static_delegate = new efl_gfx_mapping_color_set_delegate(mapping_color_set);
            }

            if (methods.Contains("SetMappingColor"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_color_set_static_delegate) });
            }

            if (efl_gfx_mapping_has_static_delegate == null)
            {
                efl_gfx_mapping_has_static_delegate = new efl_gfx_mapping_has_delegate(mapping_has);
            }

            if (methods.Contains("HasMapping"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_has"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_has_static_delegate) });
            }

            if (efl_gfx_mapping_reset_static_delegate == null)
            {
                efl_gfx_mapping_reset_static_delegate = new efl_gfx_mapping_reset_delegate(mapping_reset);
            }

            if (methods.Contains("ResetMapping"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_reset_static_delegate) });
            }

            if (efl_gfx_mapping_translate_static_delegate == null)
            {
                efl_gfx_mapping_translate_static_delegate = new efl_gfx_mapping_translate_delegate(translate);
            }

            if (methods.Contains("Translate"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_translate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_translate_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_static_delegate == null)
            {
                efl_gfx_mapping_rotate_static_delegate = new efl_gfx_mapping_rotate_delegate(rotate);
            }

            if (methods.Contains("Rotate"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_3d_static_delegate == null)
            {
                efl_gfx_mapping_rotate_3d_static_delegate = new efl_gfx_mapping_rotate_3d_delegate(rotate_3d);
            }

            if (methods.Contains("Rotate3d"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_quat_static_delegate == null)
            {
                efl_gfx_mapping_rotate_quat_static_delegate = new efl_gfx_mapping_rotate_quat_delegate(rotate_quat);
            }

            if (methods.Contains("RotateQuat"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_quat"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_static_delegate) });
            }

            if (efl_gfx_mapping_zoom_static_delegate == null)
            {
                efl_gfx_mapping_zoom_static_delegate = new efl_gfx_mapping_zoom_delegate(zoom);
            }

            if (methods.Contains("Zoom"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_zoom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_static_delegate) });
            }

            if (efl_gfx_mapping_lighting_3d_static_delegate == null)
            {
                efl_gfx_mapping_lighting_3d_static_delegate = new efl_gfx_mapping_lighting_3d_delegate(lighting_3d);
            }

            if (methods.Contains("Lighting3d"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_lighting_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_static_delegate) });
            }

            if (efl_gfx_mapping_perspective_3d_static_delegate == null)
            {
                efl_gfx_mapping_perspective_3d_static_delegate = new efl_gfx_mapping_perspective_3d_delegate(perspective_3d);
            }

            if (methods.Contains("Perspective3d"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_perspective_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_absolute_static_delegate = new efl_gfx_mapping_rotate_absolute_delegate(rotate_absolute);
            }

            if (methods.Contains("RotateAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_3d_absolute_static_delegate = new efl_gfx_mapping_rotate_3d_absolute_delegate(rotate_3d_absolute);
            }

            if (methods.Contains("Rotate3dAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_3d_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_rotate_quat_absolute_static_delegate == null)
            {
                efl_gfx_mapping_rotate_quat_absolute_static_delegate = new efl_gfx_mapping_rotate_quat_absolute_delegate(rotate_quat_absolute);
            }

            if (methods.Contains("RotateQuatAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_rotate_quat_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_rotate_quat_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_zoom_absolute_static_delegate == null)
            {
                efl_gfx_mapping_zoom_absolute_static_delegate = new efl_gfx_mapping_zoom_absolute_delegate(zoom_absolute);
            }

            if (methods.Contains("ZoomAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_zoom_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_zoom_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_lighting_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_lighting_3d_absolute_static_delegate = new efl_gfx_mapping_lighting_3d_absolute_delegate(lighting_3d_absolute);
            }

            if (methods.Contains("Lighting3dAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_lighting_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_lighting_3d_absolute_static_delegate) });
            }

            if (efl_gfx_mapping_perspective_3d_absolute_static_delegate == null)
            {
                efl_gfx_mapping_perspective_3d_absolute_static_delegate = new efl_gfx_mapping_perspective_3d_absolute_delegate(perspective_3d_absolute);
            }

            if (methods.Contains("Perspective3dAbsolute"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_mapping_perspective_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_mapping_perspective_3d_absolute_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_gfx_mapping_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_gfx_mapping_point_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_gfx_mapping_point_count_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate> efl_gfx_mapping_point_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_point_count_get_api_delegate>(Module, "efl_gfx_mapping_point_count_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int mapping_point_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_point_count_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IMapping)ws.Target).GetMappingPointCount();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_mapping_point_count_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_mapping_point_count_get_delegate efl_gfx_mapping_point_count_get_static_delegate;

        
        private delegate void efl_gfx_mapping_point_count_set_delegate(System.IntPtr obj, System.IntPtr pd,  int count);

        
        internal delegate void efl_gfx_mapping_point_count_set_api_delegate(System.IntPtr obj,  int count);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate> efl_gfx_mapping_point_count_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_point_count_set_api_delegate>(Module, "efl_gfx_mapping_point_count_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_point_count_set(System.IntPtr obj, System.IntPtr pd, int count)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_point_count_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).SetMappingPointCount(count);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_point_count_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), count);
            }
        }

        private static efl_gfx_mapping_point_count_set_delegate efl_gfx_mapping_point_count_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_clockwise_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_mapping_clockwise_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate> efl_gfx_mapping_clockwise_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_clockwise_get_api_delegate>(Module, "efl_gfx_mapping_clockwise_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool mapping_clockwise_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_clockwise_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMapping)ws.Target).GetMappingClockwise();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_mapping_clockwise_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_mapping_clockwise_get_delegate efl_gfx_mapping_clockwise_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_smooth_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_mapping_smooth_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate> efl_gfx_mapping_smooth_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_smooth_get_api_delegate>(Module, "efl_gfx_mapping_smooth_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool mapping_smooth_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_smooth_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMapping)ws.Target).GetMappingSmooth();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_mapping_smooth_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_mapping_smooth_get_delegate efl_gfx_mapping_smooth_get_static_delegate;

        
        private delegate void efl_gfx_mapping_smooth_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool smooth);

        
        internal delegate void efl_gfx_mapping_smooth_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool smooth);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate> efl_gfx_mapping_smooth_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_smooth_set_api_delegate>(Module, "efl_gfx_mapping_smooth_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_smooth_set(System.IntPtr obj, System.IntPtr pd, bool smooth)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_smooth_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).SetMappingSmooth(smooth);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_smooth_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), smooth);
            }
        }

        private static efl_gfx_mapping_smooth_set_delegate efl_gfx_mapping_smooth_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_mapping_alpha_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate> efl_gfx_mapping_alpha_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_alpha_get_api_delegate>(Module, "efl_gfx_mapping_alpha_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool mapping_alpha_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_alpha_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMapping)ws.Target).GetMappingAlpha();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_mapping_alpha_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_mapping_alpha_get_delegate efl_gfx_mapping_alpha_get_static_delegate;

        
        private delegate void efl_gfx_mapping_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool alpha);

        
        internal delegate void efl_gfx_mapping_alpha_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool alpha);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate> efl_gfx_mapping_alpha_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_alpha_set_api_delegate>(Module, "efl_gfx_mapping_alpha_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_alpha_set(System.IntPtr obj, System.IntPtr pd, bool alpha)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_alpha_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).SetMappingAlpha(alpha);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_alpha_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), alpha);
            }
        }

        private static efl_gfx_mapping_alpha_set_delegate efl_gfx_mapping_alpha_set_static_delegate;

        
        private delegate void efl_gfx_mapping_coord_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out double x,  out double y,  out double z);

        
        internal delegate void efl_gfx_mapping_coord_absolute_get_api_delegate(System.IntPtr obj,  int idx,  out double x,  out double y,  out double z);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate> efl_gfx_mapping_coord_absolute_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_coord_absolute_get_api_delegate>(Module, "efl_gfx_mapping_coord_absolute_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_coord_absolute_get(System.IntPtr obj, System.IntPtr pd, int idx, out double x, out double y, out double z)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_coord_absolute_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                x = default(double);y = default(double);z = default(double);
                try
                {
                    ((IMapping)ws.Target).GetMappingCoordAbsolute(idx, out x, out y, out z);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx, out x, out y, out z);
            }
        }

        private static efl_gfx_mapping_coord_absolute_get_delegate efl_gfx_mapping_coord_absolute_get_static_delegate;

        
        private delegate void efl_gfx_mapping_coord_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  double x,  double y,  double z);

        
        internal delegate void efl_gfx_mapping_coord_absolute_set_api_delegate(System.IntPtr obj,  int idx,  double x,  double y,  double z);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate> efl_gfx_mapping_coord_absolute_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_coord_absolute_set_api_delegate>(Module, "efl_gfx_mapping_coord_absolute_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_coord_absolute_set(System.IntPtr obj, System.IntPtr pd, int idx, double x, double y, double z)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_coord_absolute_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).SetMappingCoordAbsolute(idx, x, y, z);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx, x, y, z);
            }
        }

        private static efl_gfx_mapping_coord_absolute_set_delegate efl_gfx_mapping_coord_absolute_set_static_delegate;

        
        private delegate void efl_gfx_mapping_uv_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out double u,  out double v);

        
        internal delegate void efl_gfx_mapping_uv_get_api_delegate(System.IntPtr obj,  int idx,  out double u,  out double v);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate> efl_gfx_mapping_uv_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_uv_get_api_delegate>(Module, "efl_gfx_mapping_uv_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_uv_get(System.IntPtr obj, System.IntPtr pd, int idx, out double u, out double v)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_uv_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                u = default(double);v = default(double);
                try
                {
                    ((IMapping)ws.Target).GetMappingUv(idx, out u, out v);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_uv_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx, out u, out v);
            }
        }

        private static efl_gfx_mapping_uv_get_delegate efl_gfx_mapping_uv_get_static_delegate;

        
        private delegate void efl_gfx_mapping_uv_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  double u,  double v);

        
        internal delegate void efl_gfx_mapping_uv_set_api_delegate(System.IntPtr obj,  int idx,  double u,  double v);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate> efl_gfx_mapping_uv_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_uv_set_api_delegate>(Module, "efl_gfx_mapping_uv_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_uv_set(System.IntPtr obj, System.IntPtr pd, int idx, double u, double v)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_uv_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).SetMappingUv(idx, u, v);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_uv_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx, u, v);
            }
        }

        private static efl_gfx_mapping_uv_set_delegate efl_gfx_mapping_uv_set_static_delegate;

        
        private delegate void efl_gfx_mapping_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  out int r,  out int g,  out int b,  out int a);

        
        internal delegate void efl_gfx_mapping_color_get_api_delegate(System.IntPtr obj,  int idx,  out int r,  out int g,  out int b,  out int a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate> efl_gfx_mapping_color_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_color_get_api_delegate>(Module, "efl_gfx_mapping_color_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_color_get(System.IntPtr obj, System.IntPtr pd, int idx, out int r, out int g, out int b, out int a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_color_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                r = default(int);g = default(int);b = default(int);a = default(int);
                try
                {
                    ((IMapping)ws.Target).GetMappingColor(idx, out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_color_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx, out r, out g, out b, out a);
            }
        }

        private static efl_gfx_mapping_color_get_delegate efl_gfx_mapping_color_get_static_delegate;

        
        private delegate void efl_gfx_mapping_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  int idx,  int r,  int g,  int b,  int a);

        
        internal delegate void efl_gfx_mapping_color_set_api_delegate(System.IntPtr obj,  int idx,  int r,  int g,  int b,  int a);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate> efl_gfx_mapping_color_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_color_set_api_delegate>(Module, "efl_gfx_mapping_color_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_color_set(System.IntPtr obj, System.IntPtr pd, int idx, int r, int g, int b, int a)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_color_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).SetMappingColor(idx, r, g, b, a);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_color_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx, r, g, b, a);
            }
        }

        private static efl_gfx_mapping_color_set_delegate efl_gfx_mapping_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_mapping_has_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_mapping_has_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_has_api_delegate> efl_gfx_mapping_has_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_has_api_delegate>(Module, "efl_gfx_mapping_has");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool mapping_has(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_has was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IMapping)ws.Target).HasMapping();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_mapping_has_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_mapping_has_delegate efl_gfx_mapping_has_static_delegate;

        
        private delegate void efl_gfx_mapping_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_gfx_mapping_reset_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_reset_api_delegate> efl_gfx_mapping_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_reset_api_delegate>(Module, "efl_gfx_mapping_reset");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void mapping_reset(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_reset was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).ResetMapping();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_reset_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_mapping_reset_delegate efl_gfx_mapping_reset_static_delegate;

        
        private delegate void efl_gfx_mapping_translate_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz);

        
        internal delegate void efl_gfx_mapping_translate_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_translate_api_delegate> efl_gfx_mapping_translate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_translate_api_delegate>(Module, "efl_gfx_mapping_translate");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void translate(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_translate was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Translate(dx, dy, dz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_translate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dx, dy, dz);
            }
        }

        private static efl_gfx_mapping_translate_delegate efl_gfx_mapping_translate_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_delegate(System.IntPtr obj, System.IntPtr pd,  double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy);

        
        internal delegate void efl_gfx_mapping_rotate_api_delegate(System.IntPtr obj,  double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate> efl_gfx_mapping_rotate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_api_delegate>(Module, "efl_gfx_mapping_rotate");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void rotate(System.IntPtr obj, System.IntPtr pd, double degrees, CoreUI.Gfx.IEntity pivot, double cx, double cy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_rotate was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Rotate(degrees, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_rotate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), degrees, pivot, cx, cy);
            }
        }

        private static efl_gfx_mapping_rotate_delegate efl_gfx_mapping_rotate_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_3d_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        
        internal delegate void efl_gfx_mapping_rotate_3d_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate> efl_gfx_mapping_rotate_3d_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_3d_api_delegate>(Module, "efl_gfx_mapping_rotate_3d");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void rotate_3d(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz, CoreUI.Gfx.IEntity pivot, double cx, double cy, double cz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_rotate_3d was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Rotate3d(dx, dy, dz, pivot, cx, cy, cz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_rotate_3d_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dx, dy, dz, pivot, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_3d_delegate efl_gfx_mapping_rotate_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_quat_delegate(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        
        internal delegate void efl_gfx_mapping_rotate_quat_api_delegate(System.IntPtr obj,  double qx,  double qy,  double qz,  double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy,  double cz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate> efl_gfx_mapping_rotate_quat_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_quat_api_delegate>(Module, "efl_gfx_mapping_rotate_quat");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void rotate_quat(System.IntPtr obj, System.IntPtr pd, double qx, double qy, double qz, double qw, CoreUI.Gfx.IEntity pivot, double cx, double cy, double cz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_rotate_quat was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).RotateQuat(qx, qy, qz, qw, pivot, cx, cy, cz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_rotate_quat_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), qx, qy, qz, qw, pivot, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_quat_delegate efl_gfx_mapping_rotate_quat_static_delegate;

        
        private delegate void efl_gfx_mapping_zoom_delegate(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy);

        
        internal delegate void efl_gfx_mapping_zoom_api_delegate(System.IntPtr obj,  double zoomx,  double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double cx,  double cy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate> efl_gfx_mapping_zoom_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_zoom_api_delegate>(Module, "efl_gfx_mapping_zoom");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void zoom(System.IntPtr obj, System.IntPtr pd, double zoomx, double zoomy, CoreUI.Gfx.IEntity pivot, double cx, double cy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_zoom was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Zoom(zoomx, zoomy, pivot, cx, cy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_zoom_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), zoomx, zoomy, pivot, cx, cy);
            }
        }

        private static efl_gfx_mapping_zoom_delegate efl_gfx_mapping_zoom_static_delegate;

        
        private delegate void efl_gfx_mapping_lighting_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        
        internal delegate void efl_gfx_mapping_lighting_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate> efl_gfx_mapping_lighting_3d_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_lighting_3d_api_delegate>(Module, "efl_gfx_mapping_lighting_3d");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void lighting_3d(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_lighting_3d was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Lighting3d(pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_lighting_3d_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
            }
        }

        private static efl_gfx_mapping_lighting_3d_delegate efl_gfx_mapping_lighting_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_perspective_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double px,  double py,  double z0,  double foc);

        
        internal delegate void efl_gfx_mapping_perspective_3d_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity pivot,  double px,  double py,  double z0,  double foc);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate> efl_gfx_mapping_perspective_3d_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_perspective_3d_api_delegate>(Module, "efl_gfx_mapping_perspective_3d");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void perspective_3d(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity pivot, double px, double py, double z0, double foc)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_perspective_3d was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Perspective3d(pivot, px, py, z0, foc);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_perspective_3d_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pivot, px, py, z0, foc);
            }
        }

        private static efl_gfx_mapping_perspective_3d_delegate efl_gfx_mapping_perspective_3d_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double degrees,  double cx,  double cy);

        
        internal delegate void efl_gfx_mapping_rotate_absolute_api_delegate(System.IntPtr obj,  double degrees,  double cx,  double cy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate> efl_gfx_mapping_rotate_absolute_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_absolute");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void rotate_absolute(System.IntPtr obj, System.IntPtr pd, double degrees, double cx, double cy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_rotate_absolute was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).RotateAbsolute(degrees, cx, cy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), degrees, cx, cy);
            }
        }

        private static efl_gfx_mapping_rotate_absolute_delegate efl_gfx_mapping_rotate_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz);

        
        internal delegate void efl_gfx_mapping_rotate_3d_absolute_api_delegate(System.IntPtr obj,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate> efl_gfx_mapping_rotate_3d_absolute_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_3d_absolute");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void rotate_3d_absolute(System.IntPtr obj, System.IntPtr pd, double dx, double dy, double dz, double cx, double cy, double cz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_rotate_3d_absolute was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Rotate3dAbsolute(dx, dy, dz, cx, cy, cz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dx, dy, dz, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_3d_absolute_delegate efl_gfx_mapping_rotate_3d_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_rotate_quat_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);

        
        internal delegate void efl_gfx_mapping_rotate_quat_absolute_api_delegate(System.IntPtr obj,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate> efl_gfx_mapping_rotate_quat_absolute_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_rotate_quat_absolute_api_delegate>(Module, "efl_gfx_mapping_rotate_quat_absolute");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void rotate_quat_absolute(System.IntPtr obj, System.IntPtr pd, double qx, double qy, double qz, double qw, double cx, double cy, double cz)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_rotate_quat_absolute was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).RotateQuatAbsolute(qx, qy, qz, qw, cx, cy, cz);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), qx, qy, qz, qw, cx, cy, cz);
            }
        }

        private static efl_gfx_mapping_rotate_quat_absolute_delegate efl_gfx_mapping_rotate_quat_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_zoom_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  double cx,  double cy);

        
        internal delegate void efl_gfx_mapping_zoom_absolute_api_delegate(System.IntPtr obj,  double zoomx,  double zoomy,  double cx,  double cy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate> efl_gfx_mapping_zoom_absolute_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_zoom_absolute_api_delegate>(Module, "efl_gfx_mapping_zoom_absolute");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void zoom_absolute(System.IntPtr obj, System.IntPtr pd, double zoomx, double zoomy, double cx, double cy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_zoom_absolute was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).ZoomAbsolute(zoomx, zoomy, cx, cy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), zoomx, zoomy, cx, cy);
            }
        }

        private static efl_gfx_mapping_zoom_absolute_delegate efl_gfx_mapping_zoom_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_lighting_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        
        internal delegate void efl_gfx_mapping_lighting_3d_absolute_api_delegate(System.IntPtr obj,  double lx,  double ly,  double lz,  int lr,  int lg,  int lb,  int ar,  int ag,  int ab);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate> efl_gfx_mapping_lighting_3d_absolute_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_lighting_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_lighting_3d_absolute");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void lighting_3d_absolute(System.IntPtr obj, System.IntPtr pd, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_lighting_3d_absolute was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Lighting3dAbsolute(lx, ly, lz, lr, lg, lb, ar, ag, ab);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), lx, ly, lz, lr, lg, lb, ar, ag, ab);
            }
        }

        private static efl_gfx_mapping_lighting_3d_absolute_delegate efl_gfx_mapping_lighting_3d_absolute_static_delegate;

        
        private delegate void efl_gfx_mapping_perspective_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,  double px,  double py,  double z0,  double foc);

        
        internal delegate void efl_gfx_mapping_perspective_3d_absolute_api_delegate(System.IntPtr obj,  double px,  double py,  double z0,  double foc);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate> efl_gfx_mapping_perspective_3d_absolute_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_mapping_perspective_3d_absolute_api_delegate>(Module, "efl_gfx_mapping_perspective_3d_absolute");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void perspective_3d_absolute(System.IntPtr obj, System.IntPtr pd, double px, double py, double z0, double foc)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_mapping_perspective_3d_absolute was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMapping)ws.Target).Perspective3dAbsolute(px, py, z0, foc);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), px, py, z0, foc);
            }
        }

        private static efl_gfx_mapping_perspective_3d_absolute_delegate efl_gfx_mapping_perspective_3d_absolute_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class MappingExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> MappingPointCount<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IMapping, T>magic = null) where T : CoreUI.Gfx.IMapping {
            return new CoreUI.BindableProperty<int>("mapping_point_count", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> MappingSmooth<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IMapping, T>magic = null) where T : CoreUI.Gfx.IMapping {
            return new CoreUI.BindableProperty<bool>("mapping_smooth", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> MappingAlpha<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IMapping, T>magic = null) where T : CoreUI.Gfx.IMapping {
            return new CoreUI.BindableProperty<bool>("mapping_alpha", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

