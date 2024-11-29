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
        public class PenWave
        {
            /// <summary>
            /// The delegate for the thumbnail saved callback.
            /// </summary>
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public delegate void ThumbnailSavedCallback();

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

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void TerminateGL()
            {
                Interop.PenWave.TerminateGL();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void UpdateGLWindowSize(int w, int h)
            {
                Interop.PenWave.UpdateGLWindowSize(w, h);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void UpdateGLWindowOrientation(int angle)
            {
                Interop.PenWave.UpdateGLWindowOrientation(angle);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint BeginShapeDraw(float x, float y, uint time = 1)
            {
                return Interop.PenWave.BeginShapeDraw(x, y, time);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int DrawShape(uint shapeID, float x, float y, uint time = 1)
            {
                return Interop.PenWave.DrawShape(shapeID, x, y, time);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int EndShapeDraw(uint shapeID, uint time = 1)
            {
                return Interop.PenWave.EndShapeDraw(shapeID, time);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void StopErasing()
            {
                Interop.PenWave.StopErasing();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool EraseShape(int x, int y, float radius, bool partial)
            {
                return Interop.PenWave.EraseShape(x, y, radius, partial);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint AddRectanglePath(float xStart, float yStart, float x, float y, bool finished)
            {
                return Interop.PenWave.AddRectanglePath(xStart, yStart, x, y, finished);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint AddArcPath(float xCenter, float yCenter, float radius, float x, float y, bool finished)
            {
                return Interop.PenWave.AddArcPath(xCenter, yCenter, radius, x, y, finished);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ResizeShapePath(uint shapeID, float x, float y)
            {
                return Interop.PenWave.ResizeShapePath(shapeID, x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int FinishShapePath(uint shapeID)
            {
                return Interop.PenWave.FinishShapePath(shapeID);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool CanvasZoomBegin()
            {
                return Interop.PenWave.CanvasZoomBegin();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool CanvasZoom(float x, float y, float zoom, float dx, float dy)
            {
                return Interop.PenWave.CanvasZoom(x, y, zoom, dx, dy);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool CanvasZoomEnd()
            {
                return Interop.PenWave.CanvasZoomEnd();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CanvasGetZoomValue()
            {
                return Interop.PenWave.CanvasGetZoomValue();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public float CanvasSetZoomValue(float zoomValue)
            {
                return Interop.PenWave.CanvasSetZoomValue(zoomValue);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool CanvasMoveBegin()
            {
                return Interop.PenWave.CanvasMoveBegin();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool CanvasMove(int x, int y)
            {
                return Interop.PenWave.CanvasMove(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool CanvasMoveEnd()
            {
                return Interop.PenWave.CanvasMoveEnd();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void CanvasSetColor(string hexColor, float a)
            {
                Interop.PenWave.CanvasSetColor(hexColor, a);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void CanvasSetSize(int width, int height)
            {
                Interop.PenWave.CanvasSetSize(width, height);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetResourcePath(string resourcePath)
            {
                Interop.PenWave.SetResourcePath(resourcePath);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetFontPath(string fontPath)
            {
                Interop.PenWave.SetFontPath(fontPath);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetTexturePaths(string[] texturePaths, int textureCount)
            {
                Interop.PenWave.SetTexturePaths(texturePaths, textureCount);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetStrokeSize(float val)
            {
                Interop.PenWave.SetStrokeSize(val);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetStrokeColor(string hexColor, float a)
            {
                Interop.PenWave.SetStrokeColor(hexColor, a);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetStrokeType(int brushId)
            {
                Interop.PenWave.SetStrokeType(brushId);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetBrushTexture(int textureId)
            {
                Interop.PenWave.SetBrushTexture(textureId);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetBrushDistance(float distance)
            {
                Interop.PenWave.SetBrushDistance(distance);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetDashArray(string dashArray)
            {
                Interop.PenWave.SetDashArray(dashArray);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetLineAngle(float angle)
            {
                Interop.PenWave.SetLineAngle(angle);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetBrushSize()
            {
                return Interop.PenWave.GetBrushSize();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetBrushColor(StringBuilder hex)
            {
                return Interop.PenWave.GetBrushColor(hex);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetBrushType()
            {
                return Interop.PenWave.GetBrushType();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetBrushTexture()
            {
                return Interop.PenWave.GetBrushTexture();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetBrushDistance()
            {
                return Interop.PenWave.GetBrushDistance();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetLineAngle()
            {
                return Interop.PenWave.GetLineAngle();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetShapeCount()
            {
                return Interop.PenWave.GetShapeCount();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint CreateCanvas(int canvasWidth, int canvasHeight)
            {
                return Interop.PenWave.CreateCanvas(canvasWidth, canvasHeight);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint CreateCanvasWithBackgroundImage(string path)
            {
                return Interop.PenWave.CreateCanvasWithBackgroundImage(path);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetCurrentCanvas(uint canvasID)
            {
                Interop.PenWave.SetCurrentCanvas(canvasID);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ClearCurrentCanvas()
            {
                Interop.PenWave.ClearCurrentCanvas();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void StartSelectingArea(float x, float y)
            {
                Interop.PenWave.StartSelectingArea(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ResizeSelectedArea(float x, float y)
            {
                Interop.PenWave.ResizeSelectedArea(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool InsideSelectedArea(float x, float y)
            {
                return Interop.PenWave.InsideSelectedArea(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool GetSelectionDimensions(ref float x, ref float y, ref float width, ref float height)
            {
                return Interop.PenWave.GetSelectionDimensions(ref x, ref y, ref width, ref height);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int TouchedDrawable(float x, float y)
            {
                return Interop.PenWave.TouchedDrawable(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int SelectDrawable(float x, float y)
            {
                return Interop.PenWave.SelectDrawable(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int SelectDrawables()
            {
                return Interop.PenWave.SelectDrawables();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void DragSelectedDrawables(float x, float y)
            {
                Interop.PenWave.DragSelectedDrawables(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void EndDraging()
            {
                Interop.PenWave.EndDraging();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool StartRotating(float x, float y)
            {
                return Interop.PenWave.StartRotating(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool RotateSelected(float x, float y)
            {
                return Interop.PenWave.RotateSelected(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool EndRotating(float x, float y)
            {
                return Interop.PenWave.EndRotating(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void StartSelectionScale(bool anchorLeft, bool anchorRight, bool anchorTop, bool anchorBottom, ref float anchorX, ref float anchorY)
            {
                Interop.PenWave.StartSelectionScale(anchorLeft, anchorRight, anchorTop, anchorBottom, ref anchorX, ref anchorY);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ScaleSelection(float scaleFactorX, float scaleFactorY)
            {
                Interop.PenWave.ScaleSelection(scaleFactorX, scaleFactorY);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void EndSelectionScale(float scaleFactorX, float scaleFactorY)
            {
                Interop.PenWave.EndSelectionScale(scaleFactorX, scaleFactorY);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void DropSelectedDrawables()
            {
                Interop.PenWave.DropSelectedDrawables();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SelectedAreaZoom(float x, float y, float zoom)
            {
                Interop.PenWave.SelectedAreaZoom(x, y, zoom);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool SaveCanvas(uint canvasID, string path)
            {
                return Interop.PenWave.SaveCanvas(canvasID, path);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool LoadCanvas(uint canvasID, string path)
            {
                return Interop.PenWave.LoadCanvas(canvasID, path);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void TakeScreenshot(uint canvasID, string path, int x, int y, int width, int height, ThumbnailSavedCallback thumbSaved)
            {
                Interop.PenWave.TakeScreenshot(canvasID, path, x, y, width, height, thumbSaved);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ToggleGrid(int densityType)
            {
                Interop.PenWave.ToggleGrid(densityType);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ToggleChartGrid(int densityType)
            {
                Interop.PenWave.ToggleChartGrid(densityType);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetChartGridDensity()
            {
                return Interop.PenWave.GetChartGridDensity();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void Dump()
            {
                Interop.PenWave.Dump();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Copy()
            {
                return Interop.PenWave.Copy();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int Paste(float x, float y)
            {
                return Interop.PenWave.Paste(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Cut()
            {
                return Interop.PenWave.Cut();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Remove()
            {
                return Interop.PenWave.Remove();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddChart(int chartType, string path)
            {
                Interop.PenWave.AddChart(chartType, path);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ChangeMode(int mode)
            {
                Interop.PenWave.ChangeMode(mode);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ChartPosition(ref float x, ref float y)
            {
                Interop.PenWave.ChartPosition(ref x, ref y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddPicture(string path, float x, float y, float width, float height)
            {
                Interop.PenWave.AddPicture(path, x, y, width, height);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetCanvasBackground(string path, float x, float y, float width, float height)
            {
                Interop.PenWave.SetCanvasBackground(path, x, y, width, height);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddText(string text, float x, float y, float size)
            {
                Interop.PenWave.AddText(text, x, y, size);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint AddNote(float x, float y, float w, float h)
            {
                return Interop.PenWave.AddNote(x, y, w, h);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RemoveNote(uint noteID)
            {
                Interop.PenWave.RemoveNote(noteID);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ClearNote()
            {
                Interop.PenWave.ClearNote();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool DragNote(float x, float y)
            {
                return Interop.PenWave.DragNote(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool EndNoteDragging()
            {
                return Interop.PenWave.EndNoteDragging();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetNoteColor(string hexColor, float a)
            {
                Interop.PenWave.SetNoteColor(hexColor, a);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetActiveNote(uint noteID)
            {
                Interop.PenWave.SetActiveNote(noteID);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint TouchedNote(float x, float y)
            {
                return Interop.PenWave.TouchedNote(x, y);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Undo()
            {
                return Interop.PenWave.Undo();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Redo()
            {
                return Interop.PenWave.Redo();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ResetUndo()
            {
                Interop.PenWave.ResetUndo();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ResetRedo()
            {
                Interop.PenWave.ResetRedo();
            }
        }
}
