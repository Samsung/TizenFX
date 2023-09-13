/*
* Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen;

namespace Tizen.NUI.Extension
{
    /// <summary>
    /// DrawingCanvasView renders 2d hand drawing
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class DrawingCanvasView : View
    {
        static DrawingCanvasView() {}

        /// <summary>
        /// DrawingCanvasView constructor.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public DrawingCanvasView() : this(Interop.DrawingCanvasView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawingCanvasView(global::System.IntPtr cPtr, bool shown = true) : base(cPtr, shown)
        {
            if (!shown) SetVisible(false);
        }

        /// <summary>
        /// Begin shape drawing from declared point
        /// </summary>
        /// <param name="x">X coodinate of point where drawing started</param>
        /// <param name="y">X coodinate of point where drawing started</param>
        /// <returns>Shape id</returns>
        /// <since_tizen> 11 </since_tizen>
        public uint BeginShapeDraw(float x, float y)
        {
            return Interop.DrawingCanvasView.BeginShapeDraw(SwigCPtr, x, y);
        }

        /// <summary>
        /// Continue shape drawing with given shapeID and coordinate
        /// </summary>
        /// <param name="shapeID">define id of the shape currently drew</param>
        /// <param name="x">X coordinate to draw</param>
        /// <param name="y">Y coordinate to draw</param>
        /// <since_tizen> 11 </since_tizen>
        public void DrawShape(uint shapeID, float x, float y)
        {
            Interop.DrawingCanvasView.DrawShape(SwigCPtr, shapeID, x, y);
        }

        /// <summary>
        /// End shape drawing called when drawing stop
        /// </summary>
        /// <param name="shapeID">define id of the shape stopped drawing</param>
        /// <since_tizen> 11 </since_tizen>
        public void EndShapeDraw(uint shapeID)
        {
            Interop.DrawingCanvasView.EndShapeDraw(SwigCPtr, shapeID);
        }

        /// <summary>
        /// Set canvas color
        /// </summary>
        /// <param name="hexColor">color in hex format eg."#FFFFFF"</param>
        /// <param name="a">canvas alpha value</param>
        /// <since_tizen> 11 </since_tizen>
        public void CanvasSetColor(string hexColor, float a)
        {
            Interop.DrawingCanvasView.CanvasSetColor(SwigCPtr, hexColor, a);
        }

        /// <summary>
        /// Set brush size
        /// </summary>
        /// <param name="val">Brush size</param>
        /// <since_tizen> 11 </since_tizen>
        public void SetBrushSize(float val)
        {
            Interop.DrawingCanvasView.SetBrushSize(SwigCPtr, val);
        }

        /// <summary>
        /// Set brush color
        /// </summary>
        /// <param name="hexColor">color in hex format eg."#FFFFFF"</param>
        /// <param name="a">canvas alpha value</param>
        /// <since_tizen> 11 </since_tizen>
        public void SetBrushColor(string hexColor, float a)
        {
            Interop.DrawingCanvasView.SetBrushColor(SwigCPtr, hexColor, a);
        }

        /// <summary>
        /// Set brush type and texture
        /// </summary>
        /// <param name="brushId">Brush Type</param>
        /// <param name="textureId">Brush Texture</param>
        /// <since_tizen> 11 </since_tizen>
        public void SetBrush(int brushId, int textureId)
        {
            Interop.DrawingCanvasView.SetBrush(SwigCPtr, brushId, textureId);
        }

        /// <summary>
        /// Canvas Create
        /// </summary>
        /// <param name="canvasWidth">Canvas Width</param>
        /// <param name="canvasHeight">Canvas Height</param>
        /// <returns>New canvas id</returns>
        /// <since_tizen> 11 </since_tizen>
        public uint CreateCanvas(int canvasWidth, int canvasHeight)
        {
            return Interop.DrawingCanvasView.CreateCanvas(SwigCPtr, canvasWidth,canvasHeight);
        }

        /// <summary>
        /// Set Current Canvas
        /// </summary>
        /// <param name="canvasID">Canvas id</param>
        /// <since_tizen> 11 </since_tizen>
        public void SetCurrentCanvas(uint canvasID)
        {
            Interop.DrawingCanvasView.SetCurrentCanvas(SwigCPtr, canvasID);
        }

        /// <summary>
        /// Clear Current Canvas
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void ClearCurrentCanvas()
        {
            Interop.DrawingCanvasView.ClearCurrentCanvas(SwigCPtr);
        }

        /// <summary>
        /// ToggleGrid
        /// </summary>
        /// <param name="densityType">Grid Density type 1-small 2-medium 4-large</param>
        /// <since_tizen> 11 </since_tizen>
        public void ToggleGrid(int densityType)
        {
            Interop.DrawingCanvasView.ToggleGrid(SwigCPtr, densityType);
        }

        /// <summary>
        /// Undo last operation
        /// </summary>
        /// <returns>Result of undog operation</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool Undo()
        {
            return Interop.DrawingCanvasView.Undo(SwigCPtr);
        }

        /// <summary>
        /// Redo last undo operation
        /// </summary>
        /// <returns>Result of redo operation</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool Redo()
        {
            return Interop.DrawingCanvasView.Redo(SwigCPtr);
        }

        /// <summary>
        /// Reset Undo operation
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void ResetUndo()
        {
            Interop.DrawingCanvasView.ResetUndo(SwigCPtr);
        }

        /// <summary>
        /// Reset Redo operation
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void ResetRedo()
        {
            Interop.DrawingCanvasView.ResetRedo(SwigCPtr);
        }

        /// <summary>
        /// Get Current Canvas ID
        /// </summary>
        /// <returns>current canvas id</returns>
        /// <since_tizen> 11 </since_tizen>
        public uint GetCurrentCanvasID()
        {
            return Interop.DrawingCanvasView.GetCurrentCanvasID(SwigCPtr);
        }

        /// <summary>
        /// Save Canvas
        /// </summary>
        /// <param name="canvasID">canvas id to save</param>
        /// <param name="name">canvas name to save</param>
        /// <since_tizen> 11 </since_tizen>
        public void SaveCanvas(uint canvasID, string name)
        {
            Interop.DrawingCanvasView.SaveCanvas(SwigCPtr, canvasID, name);
        }

        /// <summary>
        /// Load Canvas
        /// </summary>
        /// <param name="canvasID">canvas id to load</param>
        /// <param name="name">canvas name to load</param>
        /// <since_tizen> 11 </since_tizen>
        public void LoadCanvas(uint canvasID, string name)
        {
            Interop.DrawingCanvasView.LoadCanvas(SwigCPtr, canvasID, name);
        }

        /// <summary>
        /// Remove canvas
        /// </summary>
        /// <param name="canvasID">remove canvas with given id</param>
        /// <returns>remove operation result</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool RemoveCanvas(uint canvasID)
        {
            return Interop.DrawingCanvasView.RemoveCanvas(SwigCPtr, canvasID);
        }

        /// <summary>
        /// Dump current engine stack
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void Dump()
        {
            Interop.DrawingCanvasView.Dump(SwigCPtr);
        }

        /// <summary>
        /// Get Brush Size
        /// </summary>
        /// <returns>brush size in use</returns>
        /// <since_tizen> 11 </since_tizen>
        public float GetBrushSize()
        {
            return Interop.DrawingCanvasView.GetBrushSize(SwigCPtr);
        }

        /// <summary>
        /// Get Brush Color
        /// </summary>
        /// <param name="hexColor">out parameter with saved brush color</param>
        /// <returns>current brush alpha</returns>
        /// <since_tizen> 11 </since_tizen>
        public float GetBrushColor(out string hexColor)
        {
            var sb = new StringBuilder("#rrggbb".Length);
            float ret =  Interop.DrawingCanvasView.GetBrushColor(SwigCPtr, sb);
            hexColor = sb.ToString(0, "#rrggbb".Length);
            return ret;
        }

        /// <summary>
        /// Get Current Brush texture and type
        /// </summary>
        /// <param name="type">out parameter with current brush type</param>
        /// <param name="texture">out parameter with current brush texture</param>
        /// <since_tizen> 11 </since_tizen>
        public void GetBrush(ref int type, ref int texture)
        {
            Interop.DrawingCanvasView.GetBrush(SwigCPtr, ref type, ref texture);
        }

        /// <summary>
        /// Start Selecting Area
        /// </summary>
        /// <param name="x">X coodinate of point where select started</param>
        /// <param name="y">X coodinate of point where select started</param>
        /// <since_tizen> 11 </since_tizen>
        public void StartSelectingArea(float x, float y)
        {
            Interop.DrawingCanvasView.StartSelectingArea(SwigCPtr, x, y);
        }

        /// <summary>
        /// Resize Selected Area
        /// </summary>
        /// <param name="x">X coodinate of point where resize select area started</param>
        /// <param name="y">X coodinate of point where resize select area started</param>
        /// <since_tizen> 11 </since_tizen>
        public void ResizeSelectedArea(float x, float y)
        {
            Interop.DrawingCanvasView.ResizeSelectedArea(SwigCPtr, x, y);
        }

        /// <summary>
        /// Check if point is inside selected area
        /// </summary>
        /// <param name="x">X coodinate of point to check</param>
        /// <param name="y">X coodinate of point to check</param>
        /// <returns>true if given point is in selected area, false otherwise</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool InsideSelectedArea(float x, float y)
        {
            return Interop.DrawingCanvasView.InsideSelectedArea(SwigCPtr, x, y);
        }

        /// <summary>
        /// SelctDrawable in given point, ignore current selection
        /// </summary>
        /// <param name="x">X coodinate of point to check</param>
        /// <param name="y">X coodinate of point to check</param>
        /// <returns>Drawable type</returns>
        /// <since_tizen> 11 </since_tizen>
        public int TouchedDrawable(float x, float y)
        {
            return Interop.DrawingCanvasView.TouchedDrawable(SwigCPtr, x, y);
        }

        /// <summary>
        /// SelctDrawable in given point
        /// </summary>
        /// <param name="x">X coodinate of point to check</param>
        /// <param name="y">X coodinate of point to check</param>
        /// <returns>Drawable type</returns>
        /// <since_tizen> 11 </since_tizen>
        public int SelectDrawable(float x, float y)
        {
            return Interop.DrawingCanvasView.SelectDrawable(SwigCPtr, x, y);
        }

        /// <summary>
        /// Select Drawables
        /// </summary>
        /// <returns>Drawable type</returns>
        /// <since_tizen> 11 </since_tizen>
        public int SelectDrawables()
        {
            return Interop.DrawingCanvasView.SelectDrawables(SwigCPtr);
        }

        /// <summary>
        /// Drag Selected Drawables
        /// </summary>
        /// <param name="x">X coodinate of point start select</param>
        /// <param name="y">X coodinate of point start select</param>
        /// <since_tizen> 11 </since_tizen>
        public void DragSelectedDrawables(float x, float y)
        {
            Interop.DrawingCanvasView.DragSelectedDrawables(SwigCPtr, x, y);
        }

        /// <summary>
        /// End Dragging
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void EndDraging()
        {
            Interop.DrawingCanvasView.EndDraging(SwigCPtr);
        }

        /// <summary>
        /// Drop Selcted Drawables
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void DropSelectedDrawables()
        {
            Interop.DrawingCanvasView.DropSelectedDrawables(SwigCPtr);
        }

        /// <summary>
        /// Zoom Selected Area
        /// </summary>
        /// <param name="x">X coodinate of point start zoom</param>
        /// <param name="y">Y coodinate of point start zoom</param>
        /// <param name="zoom"></param>
        /// <since_tizen> 11 </since_tizen>
        public void SelectedAreaZoom(float x, float y, float zoom)
        {
            Interop.DrawingCanvasView.SelectedAreaZoom(SwigCPtr, x, y, zoom);
        }

        /// <summary>
        /// Copy Shape
        /// </summary>
        /// <returns>result of copy operation</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool Copy()
        {
            return Interop.DrawingCanvasView.Copy(SwigCPtr);
        }

        /// <summary>
        /// Paste shape in given point
        /// </summary>
        /// <param name="x">X coodinate of point to paste</param>
        /// <param name="y">Y coodinate of point to paste</param>
        /// <returns>paste drawable type</returns>
        /// <since_tizen> 11 </since_tizen>
        public int Paste(float x, float y)
        {
            return Interop.DrawingCanvasView.Paste(SwigCPtr, x, y);
        }

        /// <summary>
        /// Cut shape
        /// </summary>
        /// <returns>cut operation result</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool Cut()
        {
            return Interop.DrawingCanvasView.Cut(SwigCPtr);
        }

        /// <summary>
        /// Stop Eraseing
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void StopErasing()
        {
            Interop.DrawingCanvasView.StopErasing(SwigCPtr);
        }

        /// <summary>
        /// Zoom Canvas between two points
        /// </summary>
        /// <param name="x">X coodinate of first point</param>
        /// <param name="y">Y coodinate of first point</param>
        /// <param name="zoom">Zoom value</param>
        /// <param name="dx">X coodinate of point second point </param>
        /// <param name="dy">Y coodinate of point second point </param>
        /// <since_tizen> 11 </since_tizen>
        public void CanvasZoom(float x, float y, float zoom, float dx, float dy)
        {
            Interop.DrawingCanvasView.CanvasZoom(SwigCPtr, x, y, zoom, dx, dy);
        }

        /// <summary>
        /// Set Canvas Zoom Value
        /// </summary>
        /// <param name="zoomValue">Value of zoom</param>
        /// <since_tizen> 11 </since_tizen>
        public void CanvasSetZoomValue(float zoomValue)
        {
            Interop.DrawingCanvasView.CanvasSetZoomValue(SwigCPtr, zoomValue);
        }

        /// <summary>
        /// Get Canvas Zoom Value
        /// </summary>
        /// <returns>current zoom value</returns>
        /// <since_tizen> 11 </since_tizen>
        public int CanvasGetZoomValue()
        {
            return Interop.DrawingCanvasView.CanvasGetZoomValue(SwigCPtr);
        }

        /// <summary>
        /// Canvas Move begin
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void CanvasMoveBegin()
        {
            Interop.DrawingCanvasView.CanvasMoveBegin(SwigCPtr);
        }

        /// <summary>
        /// Canvas Move in given point
        /// </summary>
        /// <param name="x">X coodinate of canvas move</param>
        /// <param name="y">Y coodinate of canvas move</param>
        /// <since_tizen> 11 </since_tizen>
        public void CanvasMove(int x, int y)
        {
            Interop.DrawingCanvasView.CanvasMove(SwigCPtr, x, y);
        }

        /// <summary>
        /// Erase Shape
        /// </summary>
        /// <param name="x">X coodinate of erase point</param>
        /// <param name="y">Y coodinate of erase point</param>
        /// <param name="partial">partial erase</param>
        /// <returns>erase result</returns>
        /// <since_tizen> 11 </since_tizen>
        public bool EraseShape(int x, int y, bool partial)
        {
            return Interop.DrawingCanvasView.EraseShape(SwigCPtr, x, y, partial);
        }
    }
}
