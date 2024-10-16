using System;
using System.Text;
using System.Runtime.InteropServices;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Data;

namespace Tizen.NUI.PenWave
{
//     public enum ConfigParamType
//     {
//         CONFIG_PARAM_TYPE_INT,
//         CONFIG_PARAM_TYPE_FLOAT,
//         CONFIG_PARAM_TYPE_STRING,
//         CONFIG_PARAM_TYPE_BOOL
//     }

//     [StructLayout(LayoutKind.Explicit)]
//     public struct ConfigParamData
//     {
//         [FieldOffset(0)]
//         public int i;
//         [FieldOffset(0)]
//         public float f;
//         [FieldOffset(0)]
//         public bool b;
//         [FieldOffset(0)]
//         public IntPtr s;
//     }

//     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
//     public struct ConfigParameter : IComparable<ConfigParameter>
//     {
//         public float step;
//         public float min;
//         public float max;

//         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
//         public string paramName;
//         public ConfigParamType type;
//         public ConfigParamData data;

//         public int CompareTo(ConfigParameter other) {
//             return String.Compare(this.paramName, other.paramName);
//         }
//     }

    public class ExtRendererDelegates
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void ThumbnailSavedDelegate();

        static public ThumbnailSavedDelegate mSwapThumbnailsDelegate = null;
    }

//     public class ExtRenderer
//     {
//         public static RendererView mRenderView;

//         public static void Init(RendererView renderView)
//         {
//                 mRenderView = renderView;
//         }

//         public static void CallRenderGL()
//         {
//                 if (mRenderView != null) mRenderView.RenderOnce();
//         }

//         public static void InitializeGL()
//         {
//                 Interop.ExtRenderer.InitializeGL();
//         }

//         public static int RenderFrameGL()
//         {
//                 return Interop.ExtRenderer.RenderFrameGL();
//         }

//         public static void RenderFullyReDraw()
//         {
//                 Interop.ExtRenderer.RenderFullyReDraw();
//         }

//         public static void TerminateGL()
//         {
//                 Interop.ExtRenderer.TerminateGL();
//         }

//         public static void UpdateGLWindowSize(int w, int h)
//         {
//                 Interop.ExtRenderer.UpdateGLWindowSize(w, h);
//                 CallRenderGL();
//         }

//         public static void UpdateGLWindowOrientation(int angle)
//         {
//                 Interop.ExtRenderer.UpdateGLWindowOrientation(angle);
//                 CallRenderGL();
//         }

//         public static uint BeginShapeDraw(float x, float y, uint eventTime)
//         {
//                 uint ret = Interop.ExtRenderer.BeginShapeDraw(x, y, eventTime);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static int DrawShape(uint shapeID, float x, float y, uint eventTime)
//         {
//                 int ret = Interop.ExtRenderer.DrawShape(shapeID, x, y, eventTime);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static int EndShapeDraw(uint shapeID, uint eventTime)
//         {
//                 int ret = Interop.ExtRenderer.EndShapeDraw(shapeID, eventTime);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static void StopErasing()
//         {
//                 Interop.ExtRenderer.StopErasing();
//                 CallRenderGL();
//         }

//         public static bool EraseShape(int x, int y, float radius, bool partial)
//         {
//                 bool ret = Interop.ExtRenderer.EraseShape(x, y, radius, partial);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static uint AddRectanglePath(float xStart, float yStart, float x, float y, bool finished)
//         {
//                 // #if USE_GLVIEW
//                 mRenderView.setContinuousRendering();
//                 // #endif
//                 uint ret = Interop.ExtRenderer.AddRectanglePath(xStart, yStart, x, y, finished);
//                 if (finished)
//                 {
//                         // #if USE_GLVIEW
//                         mRenderView.setOnDemandRendering();
//                         // #endif
//                 }
//                 CallRenderGL();
//                 return ret;
//         }

//         public static uint AddArcPath(float xCenter, float yCenter, float radius, float x, float y, bool finished)
//         {
//                 // #if USE_GLVIEW
//                 mRenderView.setContinuousRendering();
//                 // #endif
//                 uint ret = Interop.ExtRenderer.AddArcPath(xCenter, yCenter, radius, x, y, finished);
//                 if (finished)
//                 {
//                         // #if USE_GLVIEW
//                         mRenderView.setOnDemandRendering();
//                         // #endif
//                 }
//                 CallRenderGL();
//                 return ret;
//         }
//         public static int ResizeShapePath(uint shapeID, float x, float y)
//         {
//                 int ret = Interop.ExtRenderer.ResizeShapePath(shapeID, x, y);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static int FinishShapePath(uint shapeID)
//         {
//                 int ret = Interop.ExtRenderer.FinishShapePath(shapeID);
//                 // #if USE_GLVIEW
//                 mRenderView.setOnDemandRendering();
//                 // #endif
//                 CallRenderGL();
//                 return ret;
//         }

//         public static bool CanvasZoomBegin()
//         {
//                 bool ret = Interop.ExtRenderer.CanvasZoomBegin();
//                 CallRenderGL();
//                 return ret;
//         }

//         public static bool CanvasZoom(float x, float y, float zoom, float dx, float dy)
//         {
//                 bool ret = Interop.ExtRenderer.CanvasZoom(x, y, zoom, dx, dy);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static bool CanvasZoomEnd()
//         {
//                 bool ret = Interop.ExtRenderer.CanvasZoomEnd();
//                 CallRenderGL();
//                 return ret;
//         }

//         public static int CanvasGetZoomValue()
//         {
//                 return Interop.ExtRenderer.CanvasGetZoomValue();
//         }

//         public static void CanvasSetZoomValue(float zoomValue)
//         {
//                 Interop.ExtRenderer.CanvasSetZoomValue(zoomValue);
//                 CallRenderGL();
//         }

//         public static bool CanvasMoveBegin()
//         {
//                 bool ret = Interop.ExtRenderer.CanvasMoveBegin();
//                 CallRenderGL();
//                 return ret;
//         }

//         public static bool CanvasMove(int x, int y)
//         {
//                 bool ret = Interop.ExtRenderer.CanvasMove(x, y);
//                 CallRenderGL();
//                 return ret;
//         }

//         public static bool CanvasMoveEnd()
//         {
//                 bool ret = Interop.ExtRenderer.CanvasMoveEnd();
//                 CallRenderGL();
//                 return ret;
//         }

//         public static void CanvasSetColor(string hexColor, float a)
//         {
//                 Interop.ExtRenderer.CanvasSetColor(hexColor, a);
//                 CallRenderGL();
//         }

//         public static void CanvasSetSize(int width, int height)
//         {
//                 Interop.ExtRenderer.CanvasSetSize(width, height);
//                 CallRenderGL();
//         }

//         public static void SetResourcePath(string resourcePath)
//         {
//                 Interop.ExtRenderer.SetResourcePath(resourcePath);
//         }

//         public static void SetFontPath(string fontPath)
//         {
//                 Interop.ExtRenderer.SetFontPath(fontPath);
//         }

//         public static void SetTexturePaths(string[] texturePaths, int textureCount)
//         {
//                 Interop.ExtRenderer.SetTexturePaths(texturePaths, textureCount);
//         }

//         public static void SetStrokeSize(float val)
//         {
//                 Interop.ExtRenderer.SetStrokeSize(val);
//                 CallRenderGL();
//         }

//         public static void SetStrokeColor(string hexColor, float a)
//         {
//                 Interop.ExtRenderer.SetStrokeColor(hexColor, a);
//                 CallRenderGL();
//         }


//         public static void SetStrokeType(int brushId)
//         {
//                 Interop.ExtRenderer.SetStrokeType(brushId);
//                 CallRenderGL();
//         }

//         public static void SetBrushTexture(int textureId)
//         {
//                 Interop.ExtRenderer.SetBrushTexture(textureId);
//                 CallRenderGL();
//         }

//         public static void SetBrushDistance(float distance)
//         {
//                 Interop.ExtRenderer.SetBrushDistance(distance);
//                 CallRenderGL();
//         }

//         public static void SetDashArray(string dashArray)
//         {
//                 Interop.ExtRenderer.SetDashArray(dashArray);
//                 CallRenderGL();
//         }

//         public static void SetLineAngle(float angle)
//         {
//                 Interop.ExtRenderer.SetLineAngle(angle);
//                 CallRenderGL();
//         }

//         public static float GetBrushSize()
//         {
//                 return Interop.ExtRenderer.GetBrushSize();
//         }

//         public static float GetBrushColor(StringBuilder hex)
//         {
//                 return Interop.ExtRenderer.GetBrushColor(hex);
//         }

//         public static int GetBrushType()
//         {
//                 return Interop.ExtRenderer.GetBrushType();
//         }

//         public static int GetBrushTexture()
//         {
//                 return Interop.ExtRenderer.GetBrushTexture();
//         }

//         public static float GetBrushDistance()
//         {
//                 return Interop.ExtRenderer.GetBrushDistance();
//         }

//         public static float GetLineAngle()
//         {
//                 return Interop.ExtRenderer.GetLineAngle();
//         }

//         public static int GetShapeCount()
//         {
//                 return Interop.ExtRenderer.GetShapeCount();
//         }

//         public static uint CreateCanvas(int canvasWidth, int canvasHeight)
//         {
//                 return Interop.ExtRenderer.CreateCanvas(canvasWidth, canvasHeight);
//         }

// // #if PICTURE
//         public static uint CreateCanvasWithBackground(string path)
//         {
//                 return Interop.ExtRenderer.CreateCanvasWithBackgroundImage(path);
//                 CallRenderGL();
//         }

//         public static void SetCanvasBackground(string path, float x, float y, float width, float height)
//         {
//                 Interop.ExtRenderer.SetCanvasBackground(path, x, y, width, height);
//                 CallRenderGL();
//         }
// // #endif

//         public static void SetCurrentCanvas(uint canvasID)
//         {
//                 Interop.ExtRenderer.SetCurrentCanvas(canvasID);
//                 CallRenderGL();
//         }

//         public static void ClearCurrentCanvas()
//         {
//             Interop.ExtRenderer.ClearCurrentCanvas();
//             CallRenderGL();
//         }

//         public static void StartSelectingArea(float x, float y)
//         {
//             Interop.ExtRenderer.StartSelectingArea(x, y);
//             CallRenderGL();
//         }

//         public static void ResizeSelectedArea(float x, float y)
//         {
//             Interop.ExtRenderer.ResizeSelectedArea(x, y);
//             CallRenderGL();
//         }

//         public static bool InsideSelectedArea(float x, float y)
//         {
//             return Interop.ExtRenderer.InsideSelectedArea(x, y);
//         }

//         public static bool GetSelectionDimensions(ref float x, ref float y, ref float width, ref float height)
//         {
//             return Interop.ExtRenderer.GetSelectionDimensions(ref x, ref y, ref width, ref height);
//         }

//         public static int TouchedDrawable(float x, float y)
//         {
//             int ret = Interop.ExtRenderer.TouchedDrawable(x, y);
//             CallRenderGL();
//             return ret;
//         }

//         public static int SelectDrawable(float x, float y)
//         {
//             int ret = Interop.ExtRenderer.SelectDrawable(x, y);
//             CallRenderGL();
//             return ret;
//         }

//         public static int SelectDrawables()
//         {
//             int ret = Interop.ExtRenderer.SelectDrawables();
//             CallRenderGL();
//             return ret;
//         }

//         public static void DragSelectedDrawables(float x, float y)
//         {
//             Interop.ExtRenderer.DragSelectedDrawables(x, y);
//             CallRenderGL();
//         }

//         public static void EndDraging()
//         {
//             Interop.ExtRenderer.EndDraging();
//             CallRenderGL();
//         }

//         public static bool StartRotating(float x, float y)
//         {
//             return Interop.ExtRenderer.StartRotating(x, y);
//         }

//         public static bool RotateSelected(float x, float y)
//         {
//             return Interop.ExtRenderer.RotateSelected(x, y);
//         }

//         public static bool EndRotating(float x, float y)
//         {
//             return Interop.ExtRenderer.EndRotating(x, y);
//         }

//         public static void StartSelectionScale(bool anchorLeft, bool anchorRight, bool anchorTop, bool anchorBottom, ref float anchorX,ref float anchorY)
//         {
//             Interop.ExtRenderer.StartSelectionScale(anchorLeft, anchorRight, anchorTop, anchorBottom, ref anchorX, ref anchorY);
//         }

//         public static void ScaleSelection(float scaleFactorX, float scaleFactorY)
//         {
//             Interop.ExtRenderer.ScaleSelection(scaleFactorX, scaleFactorY);
//         }

//         public static void EndSelectionScale(float scaleFactorX, float scaleFactorY)
//         {
//             Interop.ExtRenderer.EndSelectionScale(scaleFactorX, scaleFactorY);
//         }

//         public static void DropSelectedDrawables()
//         {
//             Interop.ExtRenderer.DropSelectedDrawables();
//             CallRenderGL();
//         }

//         public static void SelectedAreaZoom(float x, float y, float zoom)
//         {
//             Interop.ExtRenderer.SelectedAreaZoom(x, y, zoom);
//             CallRenderGL();
//         }

//         public static bool SaveCanvas(uint canvasID, string path)
//         {
//             return Interop.ExtRenderer.SaveCanvas(canvasID, path);
//         }

//         public static bool LoadCanvas(uint canvasID, string path)
//         {
//             bool ret = Interop.ExtRenderer.LoadCanvas(canvasID, path);
//             CallRenderGL();
//             return ret;
//         }

//         public static void TakeScreenshot(uint canvasID, string path, int x, int y, int width, int height, ExtRendererDelegates.ThumbnailSavedDelegate thumbSaved)
//         {
//             Interop.ExtRenderer.TakeScreenshot(canvasID, path, x, y, width, height, thumbSaved);
//             CallRenderGL();
//         }

//         public static void ToggleGrid(int densityType)
//         {
//             Interop.ExtRenderer.ToggleGrid(densityType);
//             CallRenderGL();
//         }

// // #if CHART
//         public static void ToggleChartGrid(int densityType)
//         {
//             Interop.ExtRenderer.ToggleChartGrid(densityType);
//             CallRenderGL();
//         }

//         public static int GetChartGridDensity()
//         {
//             int ret = Interop.ExtRenderer.GetChartGridDensity();
//             CallRenderGL();
//             return ret;
//         }
// // #endif

//         public static void Dump()
//         {
//             Interop.ExtRenderer.Dump();
//             CallRenderGL();
//         }

//         public static bool Copy()
//         {
//             bool ret = Interop.ExtRenderer.Copy();
//             CallRenderGL();
//             return ret;
//         }

//         public static int Paste(float x, float y)
//         {
//             int ret = Interop.ExtRenderer.Paste(x, y);
//             CallRenderGL();
//             return ret;
//         }

//         public static bool Cut()
//         {
//             bool ret = Interop.ExtRenderer.Cut();
//             CallRenderGL();
//             return ret;
//         }
//         public static bool Remove()
//         {
//             bool ret = Interop.ExtRenderer.Remove();
//             CallRenderGL();
//             return ret;
//         }

// // #if CHART
//         public static void AddChart(int chartType, string path)
//         {
//             Interop.ExtRenderer.AddChart(chartType, path);
//             CallRenderGL();
//         }

//         public static void ChangeMode(int mode)
//         {
//             Interop.ExtRenderer.ChangeMode(mode);
//             CallRenderGL();
//         }

//         public static void ChartPosition(ref float x, ref float y)
//         {
//             Interop.ExtRenderer.ChartPosition(ref x, ref y);
//             CallRenderGL();
//         }
// // #endif

// // #if PICTURE
//         public static void AddPicture(string path)
//         {
//             Interop.ExtRenderer.AddPicture(path);
//             CallRenderGL();
//         }
// // #endif

// // #if TEXT
//         public static void AddText(string text, float x, float y, float size)
//         {
//             Interop.ExtRenderer.AddText(text, x, y, size);
//             CallRenderGL();
//         }
// // #endif
// // #if NOTES
//         public static uint AddNote(float x, float y, float w, float h)
//         {
//             uint ret = 0;
//             ret = Interop.ExtRenderer.AddNote(x, y, w, h);
//             CallRenderGL();

//             return ret;
//         }

//         public static void RemoveNote(uint id)
//         {
//             Interop.ExtRenderer.RemoveNote(id);
//             CallRenderGL();
//         }

//         public static void ClearNote()
//         {
//             Interop.ExtRenderer.ClearNote();
//             CallRenderGL();
//         }

//         public static bool DragNote(float x, float y)
//         {
//             bool ret = false;
//             ret = Interop.ExtRenderer.DragNote(x, y);
//             CallRenderGL();

//             return ret;
//         }

//         public static bool EndNoteDragging()
//         {
//             bool ret = false;
//             ret = Interop.ExtRenderer.EndNoteDragging();
//             CallRenderGL();

//             return ret;
//         }

//         public static void SetNoteColor(string hexColor, float a)
//         {
//             Interop.ExtRenderer.SetNoteColor(hexColor, a);
//             CallRenderGL();
//         }

//         public static void SetActiveNote(uint id)
//         {
//             Interop.ExtRenderer.SetActiveNote(id);
//         }

//         public static uint TouchedNote(float x, float y)
//         {
//             uint ret = 0;
//             ret = Interop.ExtRenderer.TouchedNote(x, y);

//             return ret;
//         }
// // #endif

//         public static bool Undo()
//         {
//             bool ret = Interop.ExtRenderer.Undo();
//             CallRenderGL();
//             return ret;
//         }

//         public static bool Redo()
//         {
//             bool ret = Interop.ExtRenderer.Redo();
//             CallRenderGL();
//             return ret;
//         }

//         public static void ResetUndo()
//         {
//             Interop.ExtRenderer.ResetUndo();
//         }

//         public static void ResetRedo()
//         {
//             Interop.ExtRenderer.ResetRedo();
//         }

//         public static int GetConfigurationCount()
//         {
//             return Interop.ExtRenderer.GetConfigurationCount();
//         }

//         public static IntPtr GetAllConfigurations()
//         {
//             return Interop.ExtRenderer.GetAllConfigurations();
//         }

//         public static IntPtr GetConfiguration(string key)
//         {
//             return Interop.ExtRenderer.GetConfiguration(key);
//         }

//         public static bool SetConfigurationInt(string key, int value)
//         {
//             return Interop.ExtRenderer.SetConfigurationInt(key, value);
//         }

//         public static bool SetConfigurationFloat(string key, float value)
//         {
//             return Interop.ExtRenderer.SetConfigurationFloat(key, value);
//         }

//         public static bool SetConfigurationString(string key, string value)
//         {
//             return Interop.ExtRenderer.SetConfigurationString(key, value);
//         }

//         public static bool SetConfigurationBool(string key, bool value)
//         {
//             return Interop.ExtRenderer.SetConfigurationBool(key, value);
//         }

//         public static void GetConfigurations(out ConfigParameter[] configParameters, out int count)
//         {
//             Interop.ExtRenderer.GetConfigurations(out configParameters, out count);
//         }

//         public static void SaveProfiler(string path)
//         {
//                 Interop.ExtRenderer.SaveProfiler(path);
//         }

//         public static void ResetProfiler()
//         {
//                 Interop.ExtRenderer.ResetProfiler();
//         }
//     }

    internal static partial class Interop
    {
        internal static partial class ExtRenderer
        {
            public const string Lib = "libhand-drawing-engine.so";

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
            public static extern float CanvasSetZoomValue(float zoomValue);

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

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetBrushColor")]
            public static extern float GetBrushColor([MarshalAs(UnmanagedType.LPStr)] StringBuilder hex);

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

    // #if PICTURE
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "CreateCanvasWithBackgroundImage")]
            public static extern uint CreateCanvasWithBackgroundImage([MarshalAs(UnmanagedType.LPStr)] string path);
    // #endif

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
            public static extern void TakeScreenshot(uint canvasID, [MarshalAs(UnmanagedType.LPStr)] string path, int x, int y, int width, int height, [MarshalAs(UnmanagedType.FunctionPtr)] ExtRendererDelegates.ThumbnailSavedDelegate thumbSaved);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ToggleGrid")]
            public static extern void ToggleGrid(int densityType);

    // #if CHART
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ToggleChartGrid")]
            public static extern void ToggleChartGrid(int densityType);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "GetChartGridDensity")]
            public static extern int GetChartGridDensity();
    // #endif

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

    // #if CHART
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddChart")]
            public static extern void AddChart(int chartType, [MarshalAs(UnmanagedType.LPStr)] string path);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ChangeMode")]
            public static extern void ChangeMode(int mode);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "ChartPosition")]
            public static extern void ChartPosition(ref float x, ref float y);
    // #endif

    // #if PICTURE
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddPicture")]
            public static extern void AddPicture([MarshalAs(UnmanagedType.LPStr)] string path);

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "SetCanvasBackground")]
            public static extern void SetCanvasBackground([MarshalAs(UnmanagedType.LPStr)] string path, float x, float y, float width, float height);
    // #endif

    // #if TEXT
            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "AddText")]
            public static extern void AddText([MarshalAs(UnmanagedType.LPStr)] string text, float x, float y, float size);
    // #endif
    // #if NOTES
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
    // #endif

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Undo")]
            [return:MarshalAs(UnmanagedType.I1)]
            public static extern bool Undo();

            [global::System.Runtime.InteropServices.DllImport(Lib, EntryPoint = "Redo")]
            [return:MarshalAs(UnmanagedType.I1)]
            public static extern bool Redo();

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

            //Wrappers for Marshalled APIS
            // public static void GetConfigurations(out ConfigParameter[] configParameters, out int count)
            // {
            //     IntPtr configArrayPtr = GetAllConfigurations();
            //     int engineConfigCount = GetConfigurationCount();
            //     count = engineConfigCount;

            //     ConfigParameter[] configArray = new ConfigParameter[count];

            //     for (int i = 0; i < count; i++)
            //     {
            //         configArray[i] = Marshal.PtrToStructure<ConfigParameter>(configArrayPtr);
            //         configArrayPtr += Marshal.SizeOf<ConfigParameter>();
            //     }

            //     configParameters = configArray;
            // }
        }
    }
}
