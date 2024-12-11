using System;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Data;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// PenWave class provides functions to draw on the canvas.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PenWave
    {
        /// <summary>
        /// The delegate for the thumbnail saved callback.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ScreenShotCallback();

        private static readonly PenWave instance = new PenWave();
        private PenWave() { }

        /// <summary>
        /// Gets the singleton instance of PenWave.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PenWave Instance => instance;

        /// <summary>
        /// Initializes the PenWave library.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InitializeGL()
        {
            Interop.PenWave.InitializeGL();
        }

        /// <summary>
        /// Renders the frame using OpenGL.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RenderFrameGL()
        {
            return Interop.PenWave.RenderFrameGL();
        }

        /// <summary>
        /// Renders the fully redraw frame using OpenGL.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RenderFullyReDraw()
        {
            Interop.PenWave.RenderFullyReDraw();
        }

        /// <summary>
        /// Terminates the PenWave library.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TerminateGL()
        {
            Interop.PenWave.TerminateGL();
        }

        /// <summary>
        /// Updates the window size in OpenGL. This should be called when the window is resized.
        /// </summary>
        /// <param name="w">The width</param>
        /// <param name="h">The height</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateGLWindowSize(int w, int h)
        {
            Interop.PenWave.UpdateGLWindowSize(w, h);
        }

        /// <summary>
        /// Updates the window orientation in OpenGL. This should be called when the window is rotated.
        /// </summary>
        /// <param name="angle">The angle</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateGLWindowOrientation(int angle)
        {
            Interop.PenWave.UpdateGLWindowOrientation(angle);
        }

        /// <summary>
        /// Start point for drawing
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="time">The time</param>
        /// <returns>unique shape id</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint BeginShapeDraw(float x, float y, uint time = 1)
        {
            return Interop.PenWave.BeginShapeDraw(x, y, time);
        }

        /// <summary>
        /// Draw points on cavas
        /// </summary>
        /// <param name="shapeID">ID of drawn shape</param>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="time">The time</param>
        /// <returns>
        /// 0 No error in adding points
        /// 1 Too many points (new shape has to be created)
        /// 2 No canvas set
        /// 3 No shapes in canvas
        /// 4 Bad shapeID (not exists)
        /// 5 Object with id=shapeID is not a shape
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DrawShape(uint shapeID, float x, float y, uint time = 1)
        {
            return Interop.PenWave.DrawShape(shapeID, x, y, time);
        }

        /// <summary>
        /// Finish shape drawing
        /// </summary>
        /// <param name="shapeID">ID of drawn shape</param>
        /// <param name="time">The time</param>
        /// <returns>
        /// 0 No error in adding points
        /// 1 Too many points (new shape has to be created)
        /// 2 No canvas set
        /// 3 No shapes in canvas
        /// 4 Bad shapeID (not exists)
        /// 5 Object with id=shapeID is not a shape
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndShapeDraw(uint shapeID, uint time = 1)
        {
            return Interop.PenWave.EndShapeDraw(shapeID, time);
        }

        /// <summary>
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="time">The time</param>
        /// <returns>unique shape id</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint BeginLineDraw(float x, float y, uint time = 1)
        {
            return Interop.PenWave.BeginLineDraw(x, y, time);
        }

        /// <summary>
        /// </summary>
        /// <param name="shapeID">ID of drawn shape</param>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="time">The time</param>
        /// <returns>
        /// 0 No error in adding points
        /// 1 Too many points (new shape has to be created)
        /// 2 No canvas set
        /// 3 No shapes in canvas
        /// 4 Bad shapeID (not exists)
        /// 5 Object with id=shapeID is not a shape
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DrawLine(uint shapeID, float x, float y, uint time = 1)
        {
            return Interop.PenWave.DrawLine(shapeID, x, y, time);
        }

        /// <summary>
        /// </summary>
        /// <param name="shapeID">ID of drawn shape</param>
        /// <param name="time">The time</param>
        /// <returns>
        /// 0 No error in adding points
        /// 1 Too many points (new shape has to be created)
        /// 2 No canvas set
        /// 3 No shapes in canvas
        /// 4 Bad shapeID (not exists)
        /// 5 Object with id=shapeID is not a shape
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndLineDraw(uint shapeID, uint time = 1)
        {
            return Interop.PenWave.EndLineDraw(shapeID, time);
        }



        /// <summary>
        /// Stop erasing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopErasing()
        {
            Interop.PenWave.StopErasing();
        }

        /// <summary>
        /// Erase selected shape
        /// </summary>
        /// <param name="x">Point X coordinated</param>
        /// <param name="y">Point Y coordinated</param>
        /// <param name="radius">The radius</param>
        /// <param name="partial">If true, only the touched parts of the shape are erased, otherwise the whole shape is erased.</param>
        /// <returns>Returns true if erasure was successful.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EraseShape(int x, int y, float radius, bool partial)
        {
            return Interop.PenWave.EraseShape(x, y, radius, partial);
        }

        /// <summary>
        /// Adding rectangle with properties of current stroke
        /// </summary>
        /// <param name="xStart">coordinate of upper left corner of rectangle</param>
        /// <param name="yStart">coordinate of upper left corner of rectangle</param>
        /// <param name="x">coordinate of bottom right corner</param>
        /// <param name="y">coordinate of bottom right corner</param>
        /// <param name="finished">true if drawing of rectangle is finished, false when it is set as current shape and has to be call FinishRectanglePath at the end of drawing</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddRectanglePath(float xStart, float yStart, float x, float y, bool finished)
        {
            return Interop.PenWave.AddRectanglePath(xStart, yStart, x, y, finished);
        }

        /// <summary>
        /// Adding arc with properties of current stroke
        /// </summary>
        /// <param name="xCenter">coordinate of center of circle</param>
        /// <param name="yCenter">coordinate of center of circle</param>
        /// <param name="radius">radius of circle</param>
        /// <param name="x">coordinate of start point</param>
        /// <param name="y">coordinate of start point</param>
        /// <param name="finished">true if drawing of rectangle is finished, false when it is set as current shape and has to be call FinishRectanglePath at the end of drawing</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddArcPath(float xCenter, float yCenter, float radius, float x, float y, bool finished)
        {
            return Interop.PenWave.AddArcPath(xCenter, yCenter, radius, x, y, finished);
        }

        /// <summary>
        /// Resize shape on canvas (rectangle or arc)
        /// </summary>
        /// <param name="shapeID">ID of drawn shape</param>
        /// <param name="x">Point X coordinate of changed point</param>
        /// <param name="y">Point Y coordinate of changed point</param>
        /// <returns>
        /// 0 No error in adding points
        /// 1 Too many points (new shape has to be created)
        /// 2 No canvas set
        /// 3 No shapes in canvas
        /// 4 Bad shapeID (not exists)
        /// 5 Object with id=shapeID is not a shape
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ErrorShapeAddPointsType ResizeShapePath(uint shapeID, float x, float y)
        {
            return (ErrorShapeAddPointsType)Interop.PenWave.ResizeShapePath(shapeID, x, y);
        }

        /// <summary>
        /// End drawing shape on cavas (rectangle or arc)
        /// </summary>
        /// <param name="shapeID">ID of drawn shape</param>
        /// <returns>
        /// 0 No error in adding points
        /// 1 Too many points (new shape has to be created)
        /// 2 No canvas set
        /// 3 No shapes in canvas
        /// 4 Bad shapeID (not exists)
        /// 5 Object with id=shapeID is not a shape
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FinishShapePath(uint shapeID)
        {
            return Interop.PenWave.FinishShapePath(shapeID);
        }

        /// <summary>
        /// Zoom Canvas Begin
        /// </summary>
        /// <returns>false if some shape is being drawn, true otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanvasZoomBegin()
        {
            return Interop.PenWave.CanvasZoomBegin();
        }

        /// <summary>
        /// Zoom Canvas Point
        /// </summary>
        /// <param name="x">Point X coordinated</param>
        /// <param name="y">Point Y coordinated</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="dx">dx</param>
        /// <param name="dy">dy</param>
        /// <returns>false if zooming wasn't started with CanvasZoomBegin, true otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanvasZoom(float x, float y, float zoom, float dx, float dy)
        {
            return Interop.PenWave.CanvasZoom(x, y, zoom, dx, dy);
        }

        /// <summary>
        /// Zoom Canvas End
        /// </summary>
        /// <returns>false if zooming wasn't started with CanvasZoomBegin, true otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanvasZoomEnd()
        {
            return Interop.PenWave.CanvasZoomEnd();
        }

        /// <summary>
        /// Gets Zoom Canvas Value
        /// </summary>
        /// <returns>zoom level</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CanvasGetZoomValue()
        {
            return Interop.PenWave.CanvasGetZoomValue();
        }

        /// <summary>
        /// Sets Zoom Canvas Value
        /// </summary>
        /// <param name="zoomValue">set zoom level</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CanvasSetZoomValue(float zoomValue)
        {
            Interop.PenWave.CanvasSetZoomValue(zoomValue);
        }

        /// <summary>
        /// Move Canvas Begin
        /// </summary>
        /// <returns>false if some shape is being drawn, true otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanvasMoveBegin()
        {
            return Interop.PenWave.CanvasMoveBegin();
        }

        /// <summary>
        /// Move Canvas Area
        /// </summary>
        /// <param name="x">Point X coordinated</param>
        /// <param name="y">Point Y coordinated</param>
        /// <returns>false if moving wasn't started with CanvasMoveBegin, true otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanvasMove(int x, int y)
        {
            return Interop.PenWave.CanvasMove(x, y);
        }

        /// <summary>
        /// Move Canvas End
        /// </summary>
        /// <returns>false if moving wasn't started with CanvasMoveBegin, true otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanvasMoveEnd()
        {
            return Interop.PenWave.CanvasMoveEnd();
        }

        /// <summary>
        /// Set Canvas Color
        /// </summary>
        /// <param name="hexColor">The rgb color value</param>
        /// <param name="a">The alpha value</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CanvasSetColor(string hexColor, float a)
        {
            Interop.PenWave.CanvasSetColor(hexColor, a);
        }

        /// <summary>
        /// Sets canvas size
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CanvasSetSize(int width, int height)
        {
            Interop.PenWave.CanvasSetSize(width, height);
        }

        /// <summary>
        /// Sets resource path
        /// </summary>
        /// <param name="resourcePath">The resource path</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetResourcePath(string resourcePath)
        {
            Interop.PenWave.SetResourcePath(resourcePath);
        }

        /// <summary>
        /// Sets font path
        /// </summary>
        /// <param name="fontPath">The font path</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFontPath(string fontPath)
        {
            Interop.PenWave.SetFontPath(fontPath);
        }

        /// <summary>
        /// Sets the Texture Paths object
        /// </summary>
        /// <param name="texturePaths">The texture paths.</param>
        /// <param name="textureCount">The number of textures.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTexturePaths(string[] texturePaths, int textureCount)
        {
            Interop.PenWave.SetTexturePaths(texturePaths, textureCount);
        }

        /// <summary>
        /// Sets the radius of stroke line
        /// </summary>
        /// <param name="size">Brush size</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStrokeSize(float size)
        {
            Interop.PenWave.SetStrokeSize(size);
        }

        /// <summary>
        /// Sets the stroke color
        /// </summary>
        /// <param name="hexColor">The rgb color value</param>
        /// <param name="a">The alpha value</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStrokeColor(string hexColor, float a)
        {
            Interop.PenWave.SetStrokeColor(hexColor, a);
        }

        /// <summary>
        /// Sets the stroke type
        /// </summary>
        /// <param name="brushType">The brush type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStrokeType(int brushType)
        {
            Interop.PenWave.SetStrokeType(brushType);
        }

        /// <summary>
        /// Sets the brush texture
        /// </summary>
        /// <param name="textureId">The brush texture</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBrushTexture(int textureId)
        {
            Interop.PenWave.SetBrushTexture(textureId);
        }

        /// <summary>
        /// Sets the distance between neighbouring textures in brush
        /// </summary>
        /// <param name="distance">The brush distance</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBrushDistance(float distance)
        {
            Interop.PenWave.SetBrushDistance(distance);
        }

        /// <summary>
        /// Sets used dash array
        /// </summary>
        /// <param name="dashArray">The dash array</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDashArray(string dashArray)
        {
            Interop.PenWave.SetDashArray(dashArray);
        }

        /// <summary>
        /// Set the line angle
        /// </summary>
        /// <param name="angle">The line angle in degrees</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLineAngle(float angle)
        {
            Interop.PenWave.SetLineAngle(angle);
        }

        /// <summary>
        /// Gets Current Brush Size
        /// </summary>
        /// <returns>The brush Size</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetBrushSize()
        {
            return Interop.PenWave.GetBrushSize();
        }

        /// <summary>
        /// Gets Current Brush Type
        /// </summary>
        /// <returns>The brush type</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetBrushType()
        {
            return Interop.PenWave.GetBrushType();
        }

        /// <summary>
        /// Gets Current Brush Texture
        /// </summary>
        /// <returns>The brush texture</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetBrushTexture()
        {
            return Interop.PenWave.GetBrushTexture();
        }

        /// <summary>
        /// Gets the distance between neighbouring textures in brush
        /// </summary>
        /// <returns>The brush distance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetBrushDistance()
        {
            return Interop.PenWave.GetBrushDistance();
        }

        /// <summary>
        /// Gets Current Line Angle
        /// </summary>
        /// <returns>The line angle</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetLineAngle()
        {
            return Interop.PenWave.GetLineAngle();
        }

        /// <summary>
        /// Gets count of shapes on current canvas
        /// </summary>
        /// <returns>The shape count</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetShapeCount()
        {
            return Interop.PenWave.GetShapeCount();
        }

        /// <summary>
        /// Create Canvas
        /// </summary>
        /// <param name="canvasWidth">The width</param>
        /// <param name="canvasHeight">The height</param>
        /// <returns>The canvas ID</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint CreateCanvas(int canvasWidth, int canvasHeight)
        {
            return Interop.PenWave.CreateCanvas(canvasWidth, canvasHeight);
        }

        /// <summary>
        /// Create Canvas with background image from file path.
        /// </summary>
        /// <param name="path">The background image path</param>
        /// <returns>The canvas ID</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint CreateCanvasWithBackgroundImage(string path)
        {
            return Interop.PenWave.CreateCanvasWithBackgroundImage(path);
        }

        /// <summary>
        /// Sets Current Canvas
        /// </summary>
        /// <param name="canvasID">The canvas ID</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCurrentCanvas(uint canvasID)
        {
            Interop.PenWave.SetCurrentCanvas(canvasID);
        }

        /// <summary>
        /// Clear Current Canvas
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCurrentCanvas()
        {
            Interop.PenWave.ClearCurrentCanvas();
        }

        /// <summary>
        /// Start Selecting Area
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartSelectingArea(float x, float y)
        {
            Interop.PenWave.StartSelectingArea(x, y);
        }

        /// <summary>
        /// Resize Current Selected Area
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResizeSelectedArea(float x, float y)
        {
            Interop.PenWave.ResizeSelectedArea(x, y);
        }

        /// <summary>
        /// Is inside selected area
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>Returns true if it is inside selected area. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InsideSelectedArea(float x, float y)
        {
            return Interop.PenWave.InsideSelectedArea(x, y);
        }

        /// <summary>
        /// Gets screen-space position of top-left corner and size of current selection
        /// </summary>
        /// <param name="x">destination reference for horizontal position or NaN if no selection is present</param>
        /// <param name="y">destination reference for vertical position or NaN if no selection is present</param>
        /// <param name="width">destination reference for selection width or NaN if no selection is present</param>
        /// <param name="height">destination reference for selection height or NaN if no selection is present</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetSelectionDimensions(ref float x, ref float y, ref float width, ref float height)
        {
            return Interop.PenWave.GetSelectionDimensions(ref x, ref y, ref width, ref height);
        }

        /// <summary>
        /// TouchedDrawable
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TouchedDrawable(float x, float y)
        {
            return Interop.PenWave.TouchedDrawable(x, y);
        }

        /// <summary>
        /// Select Drawable
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>The DrawableType</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectDrawable(float x, float y)
        {
            return Interop.PenWave.SelectDrawable(x, y);
        }

        /// <summary>
        /// Select Drawables
        /// </summary>
        /// <returns>The DrawableType</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectDrawables()
        {
            return Interop.PenWave.SelectDrawables();
        }

        /// <summary>
        /// Drag Selected Drawables
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DragSelectedDrawables(float x, float y)
        {
            Interop.PenWave.DragSelectedDrawables(x, y);
        }

        /// <summary>
        /// End Draging
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EndDraging()
        {
            Interop.PenWave.EndDraging();
        }

        /// <summary>
        /// Start rotating selected shapes
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StartRotating(float x, float y)
        {
            return Interop.PenWave.StartRotating(x, y);
        }

        /// <summary>
        /// Rotate selected shapes
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RotateSelected(float x, float y)
        {
            return Interop.PenWave.RotateSelected(x, y);
        }

        /// <summary>
        /// Finish rotating selected shapes
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EndRotating(float x, float y)
        {
            return Interop.PenWave.EndRotating(x, y);
        }

        /// <summary>
        /// Initialize scaling of selected area.
        /// Selecting neither or both of left/right or bottom/top anchor will put the anchor in the middle of relevant axis
        /// </summary>
        /// <param name="anchorLeft">place anchor on the left side of current selection</param>
        /// <param name="anchorRight">place anchor on the right side of current selection</param>
        /// <param name="anchorTop">place anchor on the bottom side of current selection</param>
        /// <param name="anchorBottom">place anchor on the top side of current selection</param>
        /// <param name="anchorX">x cooridinate of anchor point</param>
        /// <param name="anchorY">y cooridinate of anchor point</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartSelectionScale(bool anchorLeft, bool anchorRight, bool anchorTop, bool anchorBottom, ref float anchorX, ref float anchorY)
        {
            Interop.PenWave.StartSelectionScale(anchorLeft, anchorRight, anchorTop, anchorBottom, ref anchorX, ref anchorY);
        }

        /// <summary>
        /// Scale Selected Area
        /// </summary>
        /// <param name="scaleFactorX">horizontal scale factor relative to initial size</param>
        /// <param name="scaleFactorY">vertical scale factor relative to initial size</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScaleSelection(float scaleFactorX, float scaleFactorY)
        {
            Interop.PenWave.ScaleSelection(scaleFactorX, scaleFactorY);
        }

        /// <summary>
        /// Finalize scaling of selected area
        /// </summary>
        /// <param name="scaleFactorX">horizontal scale factor relative to initial size</param>
        /// <param name="scaleFactorY">vertical scale factor relative to initial size</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EndSelectionScale(float scaleFactorX, float scaleFactorY)
        {
            Interop.PenWave.EndSelectionScale(scaleFactorX, scaleFactorY);
        }

        /// <summary>
        /// Drop Selected Drawables
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DropSelectedDrawables()
        {
            Interop.PenWave.DropSelectedDrawables();
        }

        /// <summary>
        /// Zoom Selected Area
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="zoom">Zoom lebel</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SelectedAreaZoom(float x, float y, float zoom)
        {
            Interop.PenWave.SelectedAreaZoom(x, y, zoom);
        }

        /// <summary>
        /// Save canvas to file
        /// </summary>
        /// <param name="canvasID">Canvas ID</param>
        /// <param name="path">file path</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SaveCanvas(uint canvasID, string path)
        {
            return Interop.PenWave.SaveCanvas(canvasID, path);
        }

        /// <summary>
        /// Load canvas from file
        /// </summary>
        /// <param name="canvasID">Canvas ID</param>
        /// <param name="path">file path</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadCanvas(uint canvasID, string path)
        {
            return Interop.PenWave.LoadCanvas(canvasID, path);
        }

        /// <summary>
        /// Take screenshot of canvas to file with given dimensions and save callback function.
        /// </summary>
        /// <param name="canvasID">Canvas ID</param>
        /// <param name="path">file path</param>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="thumbSaved">save callback function</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TakeScreenshot(uint canvasID, string path, int x, int y, int width, int height, ScreenShotCallback thumbSaved)
        {
            Interop.PenWave.TakeScreenshot(canvasID, path, x, y, width, height, thumbSaved);
        }

        /// <summary>
        /// ToggleGrid
        /// </summary>
        /// <param name="densityType">The density type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ToggleGrid(int densityType)
        {
            Interop.PenWave.ToggleGrid(densityType);
        }

        /// <summary>
        /// Toggle Chart Grid
        /// </summary>
        /// <param name="densityType">The density type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ToggleChartGrid(int densityType)
        {
            Interop.PenWave.ToggleChartGrid(densityType);
        }

        /// <summary>
        /// Gets Chart Grid Density
        /// </summary>
        /// <returns>chart grid density</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetChartGridDensity()
        {
            return Interop.PenWave.GetChartGridDensity();
        }

        /// <summary>
        /// Copy shape
        /// </summary>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Copy()
        {
            return Interop.PenWave.Copy();
        }

        /// <summary>
        /// Paste shape in position
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Paste(float x, float y)
        {
            return Interop.PenWave.Paste(x, y);
        }

        /// <summary>
        /// Cut shape
        /// </summary>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Cut()
        {
            return Interop.PenWave.Cut();
        }

        /// <summary>
        /// Remove shape
        /// </summary>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove()
        {
            return Interop.PenWave.Remove();
        }

        /// <summary>
        /// Add chart
        /// </summary>
        /// <param name="chartType">chart type</param>
        /// <param name="path">path to chart</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddChart(int chartType, string path)
        {
            Interop.PenWave.AddChart(chartType, path);
        }

        /// <summary>
        /// Change mode
        /// </summary>
        /// <param name="mode">mode</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ChangeMode(int mode)
        {
            Interop.PenWave.ChangeMode(mode);
        }

        /// <summary>
        /// Chart Position
        /// </summary>
        /// <param name="x">current chart x position</param>
        /// <param name="y">current chart y position</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ChartPosition(ref float x, ref float y)
        {
            Interop.PenWave.ChartPosition(ref x, ref y);
        }

        /// <summary>
        /// Add Picture to canvas with original size and at 0;0 position
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddPicture(string path, float x, float y, float width, float height)
        {
            Interop.PenWave.AddPicture(path, x, y, width, height);
        }

        /// <summary>
        /// Sets Canvas Background
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="path">file path</param>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCanvasBackground(string path, float x, float y, float width, float height)
        {
            Interop.PenWave.SetCanvasBackground(path, x, y, width, height);
        }

        /// <summary>
        /// Add Text to canvas
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="size">Text size</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddText(string text, float x, float y, float size)
        {
            Interop.PenWave.AddText(text, x, y, size);
        }

        /// <summary>
        /// Add Note.
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <returns>The note ID</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddNote(float x, float y, float width, float height)
        {
            return Interop.PenWave.AddNote(x, y, width, height);
        }

        /// <summary>
        /// Remove Note.
        /// </summary>
        /// <param name="noteID">The note ID</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveNote(uint noteID)
        {
            Interop.PenWave.RemoveNote(noteID);
        }

        /// <summary>
        /// Clear Note.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearNote()
        {
            Interop.PenWave.ClearNote();
        }

        /// <summary>
        /// Drag the active note.
        /// </summary>
        /// <param name="x">Point X coordinate</param>
        /// <param name="y">Point Y coordinate</param>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DragNote(float x, float y)
        {
            return Interop.PenWave.DragNote(x, y);
        }

        /// <summary>
        /// End dragging of the active note.
        /// </summary>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EndNoteDragging()
        {
            return Interop.PenWave.EndNoteDragging();
        }

        /// <summary>
        /// Sets color of the active note.
        /// </summary>
        /// <param name="hexColor">hex code of the color</param>
        /// <param name="a">alpha value</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetNoteColor(string hexColor, float a)
        {
            Interop.PenWave.SetNoteColor(hexColor, a);
        }

        /// <summary>
        /// Sets active note.
        /// </summary>
        /// <param name="noteID">The note ID</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetActiveNote(uint noteID)
        {
            Interop.PenWave.SetActiveNote(noteID);
        }

        /// <summary>
        /// Undo
        /// </summary>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Undo()
        {
            return Interop.PenWave.Undo();
        }

        /// <summary>
        /// Redo
        /// </summary>
        /// <returns>Returns true if successful. otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Redo()
        {
            return Interop.PenWave.Redo();
        }

        /// <summary>
        /// CanUndo
        /// </summary>
        /// <returns>whether there is an operation to be undone or not</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanUndo()
        {
            return Interop.PenWave.CanUndo();
        }

        /// <summary>
        /// CanRedo
        /// </summary>
        /// <returns>whether there is an operation to be redone or not</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanRedo()
        {
            return Interop.PenWave.CanRedo();
        }

        /// <summary>
        /// Reset Undo
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetUndo()
        {
            Interop.PenWave.ResetUndo();
        }

        /// <summary>
        /// Reset Redo
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetRedo()
        {
            Interop.PenWave.ResetRedo();
        }
    }
}
