/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;

namespace Tizen.NUI.PenWave
{
        internal static partial class Interop
        {
                internal static partial class PenWaveRenderer
                {
                        private const string Lib = "libhand-drawing-engine.so";

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "InitializeGL")]
                        public static extern void InitializeGL();
                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "RenderFrameGL")]
                        public static extern int RenderFrameGL();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "RenderFullyReDraw")]
                        public static extern void RenderFullyReDraw();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "TerminateGL")]
                        public static extern void TerminateGL();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "UpdateGLWindowSize")]
                        public static extern void UpdateGLWindowSize(int w, int h);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "UpdateGLWindowOrientation")]
                        public static extern void UpdateGLWindowOrientation(int angle);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "BeginShapeDraw")]
                        public static extern uint BeginShapeDraw(float x, float y, uint time = 1);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "DrawShape")]
                        public static extern int DrawShape(uint shapeID, float x, float y, uint time = 1);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EndShapeDraw")]
                        public static extern int EndShapeDraw(uint shapeID, uint time = 1);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "BeginLineDraw")]
                        public static extern uint BeginLineDraw(float x, float y, uint time = 1);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "DrawLine")]
                        public static extern int DrawLine(uint lineID, float x, float y, uint time = 1);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EndLineDraw")]
                        public static extern int EndLineDraw(uint lineID, uint time = 1);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "StopErasing")]
                        public static extern void StopErasing();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EraseShape")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool EraseShape(int x, int y, float radius, [MarshalAs(UnmanagedType.I1)] bool partial);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddRectanglePath")]
                        public static extern uint AddRectanglePath(float xStart, float yStart, float x, float y, bool finished);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddArcPath")]
                        public static extern uint AddArcPath(float xCenter, float yCenter, float radius, float x, float y, bool finished);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ResizeShapePath")]
                        public static extern int ResizeShapePath(uint shapeID, float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "FinishShapePath")]
                        public static extern int FinishShapePath(uint shapeID);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasZoomBegin")]
                        public static extern bool CanvasZoomBegin();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasZoom")]
                        public static extern bool CanvasZoom(float x, float y, float zoom, float dx, float dy);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasZoomEnd")]
                        public static extern bool CanvasZoomEnd();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasGetZoomValue")]
                        public static extern int CanvasGetZoomValue();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasSetZoomValue")]
                        public static extern void CanvasSetZoomValue(float zoomValue);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasZoomToValue")]
                        public static extern void CanvasSetZoomValue(int x, int y, float zoomValue);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasMoveBegin")]
                        public static extern bool CanvasMoveBegin();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasMove")]
                        public static extern bool CanvasMove(int x, int y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasMoveEnd")]
                        public static extern bool CanvasMoveEnd();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasSetColor")]
                        public static extern void CanvasSetColor([MarshalAs(UnmanagedType.LPStr)] string hexColor, float a);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanvasSetSize")]
                        public static extern void CanvasSetSize(int width, int height);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetResourcePath")]
                        public static extern void SetResourcePath([MarshalAs(UnmanagedType.LPStr)] string resourcePath);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetFontPath")]
                        public static extern void SetFontPath([MarshalAs(UnmanagedType.LPStr)] string fontPath);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetTexturePaths")]
                        public static extern void SetTexturePaths([MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStr)] string[] texturePaths, int textureCount);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetStrokeSize")]
                        public static extern void SetStrokeSize(float val);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetStrokeColor")]
                        public static extern void SetStrokeColor([MarshalAs(UnmanagedType.LPStr)] string hexColor, float a);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetStrokeType")]
                        public static extern void SetStrokeType(int brushId);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetBrushTexture")]
                        public static extern void SetBrushTexture(int textureId);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetBrushDistance")]
                        public static extern void SetBrushDistance(float distance);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetDashArray")]
                        public static extern void SetDashArray([MarshalAs(UnmanagedType.LPStr)] string dashArray);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetLineAngle")]
                        public static extern void SetLineAngle(float angle);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetBrushSize")]
                        public static extern float GetBrushSize();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetBrushType")]
                        public static extern int GetBrushType();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetBrushTexture")]
                        public static extern int GetBrushTexture();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetBrushDistance")]
                        public static extern float GetBrushDistance();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetLineAngle")]
                        public static extern float GetLineAngle();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetShapeCount")]
                        public static extern int GetShapeCount();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CreateCanvas")]
                        public static extern uint CreateCanvas(int canvasWidth, int canvasHeight);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CreateCanvasWithBackgroundImage")]
                        public static extern uint CreateCanvasWithBackgroundImage([MarshalAs(UnmanagedType.LPStr)] string path);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetCurrentCanvas")]
                        public static extern void SetCurrentCanvas(uint canvasID);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ClearCurrentCanvas")]
                        public static extern void ClearCurrentCanvas();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "StartSelectingArea")]
                        public static extern void StartSelectingArea(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ResizeSelectedArea")]
                        public static extern void ResizeSelectedArea(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "InsideSelectedArea")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool InsideSelectedArea(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetSelectionDimensions")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool GetSelectionDimensions(ref float x, ref float y, ref float width, ref float height);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "TouchedDrawable")]
                        public static extern int TouchedDrawable(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SelectDrawable")]
                        public static extern int SelectDrawable(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SelectDrawables")]
                        public static extern int SelectDrawables();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "DragSelectedDrawables")]
                        public static extern void DragSelectedDrawables(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EndDraging")]
                        public static extern void EndDraging();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "StartRotating")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool StartRotating(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "RotateSelected")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool RotateSelected(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EndRotating")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool EndRotating(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "StartSelectionScale")]
                        public static extern void StartSelectionScale(bool anchorLeft, bool anchorRight, bool anchorTop, bool anchorBottom, ref float anchorX, ref float anchorY);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ScaleSelection")]
                        public static extern void ScaleSelection(float scaleFactorX, float scaleFactorY);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EndSelectionScale")]
                        public static extern void EndSelectionScale(float scaleFactorX, float scaleFactorY);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "DropSelectedDrawables")]
                        public static extern void DropSelectedDrawables();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SelectedAreaZoom")]
                        public static extern void SelectedAreaZoom(float x, float y, float zoom);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SaveCanvas")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool SaveCanvas(uint canvasID, [MarshalAs(UnmanagedType.LPStr)] string path);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "LoadCanvas")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool LoadCanvas(uint canvasID, [MarshalAs(UnmanagedType.LPStr)] string path);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "TakeScreenshot")]
                        public static extern void TakeScreenShot(uint canvasID, [MarshalAs(UnmanagedType.LPStr)] string path, int x, int y, int width, int height, [MarshalAs(UnmanagedType.FunctionPtr)] Tizen.NUI.PenWave.PenWaveRenderer.ScreenShotCallback thumbSaved);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ToggleGrid")]
                        public static extern void ToggleGrid(int densityType);

                        //CHART
                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ToggleChartGrid")]
                        public static extern void ToggleChartGrid(int densityType);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetChartGridDensity")]
                        public static extern int GetChartGridDensity();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddChart")]
                        public static extern void AddChart(int chartType, [MarshalAs(UnmanagedType.LPStr)] string path);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ChangeMode")]
                        public static extern void ChangeMode(int mode);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ChartPosition")]
                        public static extern void ChartPosition(ref float x, ref float y);
                        //

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Dump")]
                        public static extern void Dump();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Copy")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool Copy();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Paste")]
                        public static extern int Paste(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Cut")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool Cut();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Remove")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool Remove();


                        // PICTURE
                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "PlacePicture")]
                        public static extern void AddPicture([MarshalAs(UnmanagedType.LPStr)] string path, float x, float y, float width, float height);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetCanvasBackground")]
                        public static extern void SetCanvasBackground([MarshalAs(UnmanagedType.LPStr)] string path, float x, float y, float width, float height);
                        //

                        // TEXT
                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddText")]
                        public static extern void AddText([MarshalAs(UnmanagedType.LPStr)] string text, float x, float y, float size);
                        //
                        // NOTES
                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddNote")]
                        public static extern uint AddNote(float x, float y, float w, float h);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "RemoveNote")]
                        public static extern void RemoveNote(uint noteID);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ClearNote")]
                        public static extern void ClearNote();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "DragNote")]
                        public static extern bool DragNote(float x, float y);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "EndNoteDragging")]
                        public static extern bool EndNoteDragging();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetNoteColor")]
                        public static extern void SetNoteColor([MarshalAs(UnmanagedType.LPStr)] string hexColor, float a);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetActiveNote")]
                        public static extern void SetActiveNote(uint noteID);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "TouchedNote")]
                        public static extern uint TouchedNote(float x, float y);
                        //

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Undo")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool Undo();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Redo")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool Redo();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanUndo")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool CanUndo();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CanRedo")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool CanRedo();


                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ResetUndo")]
                        public static extern void ResetUndo();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ResetRedo")]
                        public static extern void ResetRedo();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetConfigurationCount")]
                        public static extern int GetConfigurationCount();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetAllConfigurations", CallingConvention = CallingConvention.Cdecl)]
                        public static extern IntPtr GetAllConfigurations();

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetConfiguration", CallingConvention = CallingConvention.Cdecl)]
                        public static extern IntPtr GetConfiguration([MarshalAs(UnmanagedType.LPStr)] string key);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetConfigurationInt", CallingConvention = CallingConvention.Cdecl)]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool SetConfigurationInt([MarshalAs(UnmanagedType.LPStr)] string key, int value);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetConfigurationFloat", CallingConvention = CallingConvention.Cdecl)]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool SetConfigurationFloat([MarshalAs(UnmanagedType.LPStr)] string key, float value);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetConfigurationString", CallingConvention = CallingConvention.Cdecl)]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool SetConfigurationString([MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetConfigurationBool", CallingConvention = CallingConvention.Cdecl)]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool SetConfigurationBool([MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.I1)] bool value);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SaveProfiler")]
                        [return:MarshalAs(UnmanagedType.I1)]
                        public static extern bool SaveProfiler([MarshalAs(UnmanagedType.LPStr)] string path);

                        [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ResetProfiler")]
                        public static extern void ResetProfiler();
                }
        }
}
