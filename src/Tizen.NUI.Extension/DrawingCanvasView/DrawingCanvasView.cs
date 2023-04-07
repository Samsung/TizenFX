/*
* Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    public class DrawingCanvasView : View
    {
        static DrawingCanvasView() {}

        public DrawingCanvasView() : this(Interop.DrawingCanvasView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawingCanvasView(global::System.IntPtr cPtr, bool shown = true) : base(cPtr, shown)
        {
            if (!shown) SetVisible(false);
        }

        public void BeginShapeDraw(float x, float y)
        {
            Interop.DrawingCanvasView.BeginShapeDraw(SwigCPtr, x, y);
        }

        public void DrawShape(float x, float y)
        {
            Interop.DrawingCanvasView.DrawShape(SwigCPtr, x, y);
        }

        public void EndShapeDraw()
        {
            Interop.DrawingCanvasView.EndShapeDraw(SwigCPtr);
        }

        public void CanvasSetColor(string hexColor, float a)
        {
            Interop.DrawingCanvasView.CanvasSetColor(SwigCPtr, hexColor, a);
        }

        public void SetBrushSize(float val)
        {
            Interop.DrawingCanvasView.SetBrushSize(SwigCPtr, val);
        }

        public void SetBrushColor(string hexColor, float a)
        {
            Interop.DrawingCanvasView.SetBrushColor(SwigCPtr, hexColor, a);
        }

        public void SetBrush(int brushId, int textureId)
        {
            Interop.DrawingCanvasView.SetBrush(SwigCPtr, brushId, textureId);
        }

        public uint CreateCanvas(int canvasWidth, int canvasHeight)
        {
            return Interop.DrawingCanvasView.CreateCanvas(SwigCPtr, canvasWidth,canvasHeight);
        }

        public void SetCurrentCanvas(uint canvasID)
        {
            Interop.DrawingCanvasView.SetCurrentCanvas(SwigCPtr, canvasID);
        }

        public void ClearCurrentCanvas()
        {
            Interop.DrawingCanvasView.ClearCurrentCanvas(SwigCPtr);
        }

        public void ToggleGrid(int densityType)
        {
            Interop.DrawingCanvasView.ToggleGrid(SwigCPtr, densityType);
        }

        public bool Undo()
        {
            return Interop.DrawingCanvasView.Undo(SwigCPtr);
        }

        public bool Redo()
        {
            return Interop.DrawingCanvasView.Redo(SwigCPtr);
        }

        public void ResetUndo()
        {
            Interop.DrawingCanvasView.ResetUndo(SwigCPtr);
        }

        public void ResetRedo()
        {
            Interop.DrawingCanvasView.ResetRedo(SwigCPtr);
        }

        public uint GetCurrentCanvasID()
        {
            return Interop.DrawingCanvasView.GetCurrentCanvasID(SwigCPtr);
        }

        public void SaveCanvas(uint canvasID, string name)
        {
            Interop.DrawingCanvasView.SaveCanvas(SwigCPtr, canvasID, name);
        }

        public void LoadCanvas(uint canvasID, string name)
        {
            Interop.DrawingCanvasView.LoadCanvas(SwigCPtr, canvasID, name);
        }

        public bool RemoveCanvas(uint canvasID)
        {
            return Interop.DrawingCanvasView.RemoveCanvas(SwigCPtr, canvasID);
        }

        public void Dump()
        {
            Interop.DrawingCanvasView.Dump(SwigCPtr);
        }

        public float GetBrushSize()
        {
            return Interop.DrawingCanvasView.GetBrushSize(SwigCPtr);
        }

        public float GetBrushColor(out string hexColor)
        {
            var sb = new StringBuilder("#rrggbb".Length);
            float ret =  Interop.DrawingCanvasView.GetBrushColor(SwigCPtr, sb);
            hexColor = sb.ToString(0, "#rrggbb".Length);
            return ret;
        }

        public void GetBrush(ref int type, ref int texture)
        {
            Interop.DrawingCanvasView.GetBrush(SwigCPtr, ref type, ref texture);
        }

        public void StartSelectingArea(float x, float y)
        {
            Interop.DrawingCanvasView.StartSelectingArea(SwigCPtr, x, y);
        }

        public void ResizeSelectedArea(float x, float y)
        {
            Interop.DrawingCanvasView.ResizeSelectedArea(SwigCPtr, x, y);
        }

        public bool InsideSelectedArea(float x, float y)
        {
            return Interop.DrawingCanvasView.InsideSelectedArea(SwigCPtr, x, y);
        }

        public int TouchedDrawable(float x, float y)
        {
            return Interop.DrawingCanvasView.TouchedDrawable(SwigCPtr, x, y);
        }

        public int SelectDrawable(float x, float y)
        {
            return Interop.DrawingCanvasView.SelectDrawable(SwigCPtr, x, y);
        }

        public int SelectDrawables()
        {
            return Interop.DrawingCanvasView.SelectDrawables(SwigCPtr);
        }

        public void DragSelectedDrawables(float x, float y)
        {
            Interop.DrawingCanvasView.DragSelectedDrawables(SwigCPtr, x, y);
        }

        public void EndDraging()
        {
            Interop.DrawingCanvasView.EndDraging(SwigCPtr);
        }

        public void DropSelectedDrawables()
        {
            Interop.DrawingCanvasView.DropSelectedDrawables(SwigCPtr);
        }

        public void SelectedAreaZoom(float x, float y, float zoom)
        {
            Interop.DrawingCanvasView.SelectedAreaZoom(SwigCPtr, x, y, zoom);
        }

        public void ToggleChartGrid(int densityType)
        {
            Interop.DrawingCanvasView.ToggleChartGrid(SwigCPtr, densityType);
        }

        public int GetChartGridDensity()
        {
            return Interop.DrawingCanvasView.GetChartGridDensity(SwigCPtr);
        }

        public bool Copy()
        {
            return Interop.DrawingCanvasView.Copy(SwigCPtr);
        }

        public int Paste(float x, float y)
        {
            return Interop.DrawingCanvasView.Paste(SwigCPtr, x, y);
        }

        public bool Cut()
        {
            return Interop.DrawingCanvasView.Cut(SwigCPtr);
        }

        public void StopErasing()
        {
            Interop.DrawingCanvasView.StopErasing(SwigCPtr);
        }

        public void CanvasZoom(float x, float y, float zoom, float dx, float dy)
        {
            Interop.DrawingCanvasView.CanvasZoom(SwigCPtr, x, y, zoom, dx, dy);
        }

        public void CanvasSetZoomValue(float zoomValue)
        {
            Interop.DrawingCanvasView.CanvasSetZoomValue(SwigCPtr, zoomValue);
        }

        public int CanvasGetZoomValue()
        {
            return Interop.DrawingCanvasView.CanvasGetZoomValue(SwigCPtr);
        }

        public void CanvasMoveBegin()
        {
            Interop.DrawingCanvasView.CanvasMoveBegin(SwigCPtr);
        }

        public void CanvasMove(int x, int y)
        {
            Interop.DrawingCanvasView.CanvasMove(SwigCPtr, x, y);
        }

        public bool EraseShape(int x, int y, bool partial)
        {
            return Interop.DrawingCanvasView.EraseShape(SwigCPtr, x, y, partial);
        }

        public void AddChart(int chartType, string path)
        {
            Interop.DrawingCanvasView.AddChart(SwigCPtr, chartType, path);
        }

        public void ChangeMode(int mode)
        {
            Interop.DrawingCanvasView.ChangeMode(SwigCPtr, mode);
        }

        public void ChartPosition(float x, float y)
        {
            Interop.DrawingCanvasView.ChartPosition(SwigCPtr, x, y);
        }

        public void AddPicture(int pictureExtension, string path)
        {
            Interop.DrawingCanvasView.AddPicture(SwigCPtr, pictureExtension, path);
        }

        public void AddText(string text, float x, float y, float size)
        {
            Interop.DrawingCanvasView.AddText(SwigCPtr, text, x, y, size);
        }
    }
}
