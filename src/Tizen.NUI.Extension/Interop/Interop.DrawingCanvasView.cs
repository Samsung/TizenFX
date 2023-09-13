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

using System.Text;

namespace Tizen.NUI.Extension
{
    internal static partial class Interop
    {
        internal static partial class DrawingCanvasView
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_BeginShapeDraw")]
            public static extern uint BeginShapeDraw(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_DrawShape")]
            public static extern void DrawShape(global::System.Runtime.InteropServices.HandleRef handle, uint shapeID, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_EndShapeDraw")]
            public static extern void EndShapeDraw(global::System.Runtime.InteropServices.HandleRef handle, uint shapeID);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CanvasZoom")]
            public static extern void CanvasZoom(global::System.Runtime.InteropServices.HandleRef handle, float x, float y, float zoom, float dx, float dy);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CanvasSetZoomValue")]
            public static extern void CanvasSetZoomValue(global::System.Runtime.InteropServices.HandleRef handle, float zoomVlaue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CanvasGetZoomValue")]
            public static extern int CanvasGetZoomValue(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CanvasSetColor")]
            public static extern void CanvasSetColor(global::System.Runtime.InteropServices.HandleRef handle, string hexColor, float a);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SetBrushSize")]
            public static extern void SetBrushSize(global::System.Runtime.InteropServices.HandleRef handle, float val);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SetBrushColor")]
            public static extern void SetBrushColor(global::System.Runtime.InteropServices.HandleRef handle, string hexColor, float a);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SetBrush")]
            public static extern void SetBrush(global::System.Runtime.InteropServices.HandleRef handle, int brushId, int textureId);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CreateCanvas")]
            public static extern uint CreateCanvas(global::System.Runtime.InteropServices.HandleRef handle, int canvasWidth, int canvasHeight);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SetCurrentCanvas")]
            public static extern void SetCurrentCanvas(global::System.Runtime.InteropServices.HandleRef handle, uint canvasID);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_ClearCurrentCanvas")]
            public static extern void ClearCurrentCanvas(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_ToggleGrid")]
            public static extern void ToggleGrid(global::System.Runtime.InteropServices.HandleRef handle, int densityType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_Undo")]
            public static extern bool Undo(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_Redo")]
            public static extern bool Redo(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_ResetUndo")]
            public static extern void ResetUndo(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_ResetRedo")]
            public static extern void ResetRedo(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_GetCurrentCanvasID")]
            public static extern uint GetCurrentCanvasID(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SaveCanvas")]
            public static extern void SaveCanvas(global::System.Runtime.InteropServices.HandleRef handle, uint canvasID, string name);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_LoadCanvas")]
            public static extern void LoadCanvas(global::System.Runtime.InteropServices.HandleRef handle, uint canvasID, string name);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_RemoveCanvas")]
            public static extern bool RemoveCanvas(global::System.Runtime.InteropServices.HandleRef handle, uint canvasID);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_Dump")]
            public static extern void Dump(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_GetBrushSize")]
            public static extern float GetBrushSize(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_GetBrushColor")]
            public static extern float GetBrushColor(global::System.Runtime.InteropServices.HandleRef handle, StringBuilder hex);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_GetBrush")]
            public static extern void GetBrush(global::System.Runtime.InteropServices.HandleRef handle, ref int type, ref int texture);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_StartSelectingArea")]
            public static extern void StartSelectingArea(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_ResizeSelectedArea")]
            public static extern void ResizeSelectedArea(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_InsideSelectedArea")]
            public static extern bool InsideSelectedArea(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_TouchedDrawable")]
            public static extern int TouchedDrawable(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SelectDrawable")]
            public static extern int SelectDrawable(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SelectDrawables")]
            public static extern int SelectDrawables(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_DragSelectedDrawables")]
            public static extern void DragSelectedDrawables(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_EndDraging")]
            public static extern void EndDraging(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_DropSelectedDrawables")]
            public static extern void DropSelectedDrawables(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_SelectedAreaZoom")]
            public static extern void SelectedAreaZoom(global::System.Runtime.InteropServices.HandleRef handle, float x, float y, float zoom);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_Copy")]
            public static extern bool Copy(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_Paste")]
            public static extern int Paste(global::System.Runtime.InteropServices.HandleRef handle, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_Cut")]
            public static extern bool Cut(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_StopErasing")]
            public static extern void StopErasing(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CanvasMoveBegin")]
            public static extern void CanvasMoveBegin(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_CanvasMove")]
            public static extern void CanvasMove(global::System.Runtime.InteropServices.HandleRef handle, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DrawingCanvasView_EraseShape")]
            public static extern bool EraseShape(global::System.Runtime.InteropServices.HandleRef handle, int x, int y, bool partial);
        }
    }
}
