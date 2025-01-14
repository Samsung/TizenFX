/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using System.IO;

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The class that provides rendering functionality for PenWave.
    /// </summary>
    internal class CanvasRenderer
    {
        // Paths to resources.
        private static readonly string s_fontPath = FrameworkInformation.ResourcePath + "fonts/font.ttf";
        private static readonly string[] s_texturePaths = {
            FrameworkInformation.ResourcePath + "images/textures/brush_acrylic.png",
            FrameworkInformation.ResourcePath + "images/textures/brush_sponge.png",
            FrameworkInformation.ResourcePath + "images/textures/dot_brush.png",
            FrameworkInformation.ResourcePath + "images/textures/highlighter.png",
            FrameworkInformation.ResourcePath + "images/textures/soft_brush.png"
        };

        // Canvas id.
        private uint _canvasId;
        // PenWave engine.
        private PenWave _engine;

        /// <summary>
        /// Constructor. Creates a new instance of CanvasRenderer. This constructor sets the current canvas to the specified canvas id. Also it sets paths to resources and initializes textures.
        /// </summary>
        /// <param name="canvasId">The canvas id</param>
        internal CanvasRenderer(uint canvasId)
        {
            _canvasId = canvasId;
            _engine = PenWave.Instance;
            _engine.SetCurrentCanvas(canvasId);
            _engine.SetResourcePath(FrameworkInformation.ResourcePath + "images/");
            _engine.SetFontPath(s_fontPath);
            _engine.SetTexturePaths(s_texturePaths, s_texturePaths.Length);
        }

        /// <summary>
        /// Initializes OpenGL context. This method must be called before any other methods that require OpenGL context.
        /// </summary>
        internal void InitializeGL()
        {
            _engine.InitializeGL();
        }

        /// <summary>
        /// Terminates OpenGL context. This method must be called after all methods that require OpenGL context are finished.
        /// </summary>
        internal void TerminateGL()
        {
            _engine.TerminateGL();
        }

        /// <summary>
        /// Renders frame using OpenGL context. This method should be called from the render thread. It returns 0 when there is no more work to do. Otherwise it returns 1.
        /// </summary>
        /// <param name="input">DirectRenderingGLView.RenderCallbackInput</param>
        /// <returns></returns>
        internal int RenderFrame(in DirectRenderingGLView.RenderCallbackInput input)
        {
            return _engine.RenderFrameGL();
        }

        /// <summary>
        /// Resizes the current canvas. This method should be called when the size of the window changes. It updates the size of the current canvas and renders the full redraw.
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        internal void Resize(int width, int height)
        {
            _engine.UpdateGLWindowSize(width, height);
            _engine.RenderFullyReDraw();
        }

        /// <summary>
        /// Clears the current canvas. All strokes and pictures will be removed.
        /// </summary>
        internal void ClearCanvas()
        {
            _engine.ClearCurrentCanvas();
        }

        /// <summary>
        /// Adds a picture to canvas
        /// </summary>
        /// <param name="path">The image file path</param>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        internal void AddPicture(string path, float x, float y, float width, float height)
        {
            _engine.AddPicture(path, x, y, width, height);
            _engine.RenderFullyReDraw();
        }

        /// <summary>
        /// Toggles the grid
        /// </summary>
        /// <param name="gridType">The grid type</param>
        internal void ToggleGrid(GridDensityType gridType)
        {
            _engine.ToggleGrid((int)gridType);
        }

        /// <summary>
        /// Sets the canvas background color
        /// </summary>
        /// <param name="color">The background color</param>
        internal void SetCanvasColor(Color color)
        {
            _engine.CanvasSetColor(ToHex(color), color.A);
        }

        /// <summary>
        /// Saves the canvas
        /// </summary>
        /// <param name="path">The file path</param>
        internal void SaveCanvas(string path)
        {
            _engine.SaveCanvas(_canvasId, path);
        }

        /// <summary>
        /// Loads the canvas from the specified path.
        /// </summary>
        /// <param name="path">The file path</param>
        internal void LoadCanvas(string path)
        {
            if (!File.Exists(path))
            {
                Tizen.Log.Error("NUI", $"Loading canvas error: {path}\n");
            }
            else
            {
                _engine.LoadCanvas(_canvasId, path);
            }
        }

        /// <summary>
        /// Takes screenshot of the current canvas and saves it to the specified path. The area of the screenshot is defined by the coordinates and dimensions. The callback is called when the screenshot is saved. The callback has one parameter which is the path to the saved image. If the path is null, then the screenshot was not saved successfully.
        /// </summary>
        /// <param name="path">The file paht</param>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="callback">Callback when screenshot is complete</param>
        internal void TakeScreenShot(string path, int x, int y, int width, int height, PenWave.ScreenShotCallback callback)
        {
            _engine.TakeScreenshot(_canvasId, path, x, y, width, height, callback);
        }

        // Converts Color to hex string.
        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        /// <summary>
        /// Start the canvas movement.
        /// </summary>
        /// <returns>True if the canvas move begin is successful, otherwise false</returns>
        internal bool CanvasMoveBegin()
        {
            return _engine.CanvasMoveBegin();
        }

        /// <summary>
        /// Update the canvas movement.
        /// </summary>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <returns>True if the canvas move update is successful, otherwise false</returns>
        internal bool CanvasMoveUpdate(int x, int y)
        {
            return _engine.CanvasMove(x, y);
        }

        /// <summary>
        /// End the canvas movement.
        /// </summary>
        /// <returns>True if the canvas move end is successful, otherwise false</returns>
        internal bool CanvasMoveEnd()
        {
            return _engine.CanvasMoveEnd();
        }

        /// <summary>
        /// Start the canvas zoom
        /// </summary>
        /// <returns>True if the canvas zoom begin is successful, otherwise false</returns>
        internal bool CanvasZoomBegin()
        {
            return _engine.CanvasZoomBegin();
        }

        /// <summary>
        /// Update the canvas zoom
        /// </summary>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="zoom">The zoom value</param>
        /// <param name="dx">The delta x, It will be zoomed in when it exceeds this value.</param>
        /// <param name="dy">The delta y, It will be zoomed in when it exceeds this value.</param>
        /// <returns>True if the canvas zoom update is successful, otherwise false</returns>
        internal bool CanvasZoomUpdate(float x, float y, float zoom, float dx, float dy)
        {
            return _engine.CanvasZoom(x, y, zoom, dx, dy);
        }

        /// <summary>
        /// End the canvas zoom
        /// </summary>
        /// <returns>True if the canvas zoom end is successful, otherwise false</returns>
        internal bool CanvasZoomEnd()
        {
            return _engine.CanvasZoomEnd();
        }

        /// <summary>
        /// Get the canvas zoom value
        /// </summary>
        /// <returns>The zoom value</returns>
        internal int CanvasGetZoomValue()
        {
            return _engine.CanvasGetZoomValue();
        }

        /// <summary>
        /// Set the canvas zoom value
        /// </summary>
        /// <param name="zoomValue">The zoom value</param>
        internal void CanvasSetZoomValue(int zoomValue)
        {
            _engine.CanvasSetZoomValue(zoomValue);
        }

        /// <summary>
        /// Zoom to the specified value
        /// </summary>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="zoomValue">The zoom value</param>
        internal void CanvasSetZoomValue(int x, int y, int zoomValue)
        {
            _engine.CanvasSetZoomValue(x, y, zoomValue);
        }
    }
}
