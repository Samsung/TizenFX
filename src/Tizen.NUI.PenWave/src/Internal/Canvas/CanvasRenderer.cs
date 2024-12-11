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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The class that provides rendering functionality for PenWave.
    /// </summary>
    internal class CanvasRenderer
    {
        // Paths to resources.
        private static readonly string FontPath = FrameworkInformation.ResourcePath + "fonts/font.ttf";
        private static readonly string[] TexturePaths = {
            FrameworkInformation.ResourcePath + "images/textures/brush_acrylic.png",
            FrameworkInformation.ResourcePath + "images/textures/brush_sponge.png",
            FrameworkInformation.ResourcePath + "images/textures/dot_brush.png",
            FrameworkInformation.ResourcePath + "images/textures/highlighter.png",
            FrameworkInformation.ResourcePath + "images/textures/soft_brush.png"
        };

        // Canvas id.
        private uint canvasId;
        private PenWave engine;

        /// <summary>
        /// Constructor. Creates a new instance of CanvasRenderer. This constructor sets the current canvas to the specified canvas id. Also it sets paths to resources and initializes textures.
        /// </summary>
        /// <param name="canvasId"></param>
        internal CanvasRenderer(uint canvasId)
        {
            this.canvasId = canvasId;
            engine = PenWave.Instance;
            engine.SetCurrentCanvas(canvasId);
            engine.SetResourcePath(FrameworkInformation.ResourcePath + "images/");
            engine.SetFontPath(FontPath);
            engine.SetTexturePaths(TexturePaths, TexturePaths.Length);
        }

        /// <summary>
        /// Initializes OpenGL context. This method must be called before any other methods that require OpenGL context.
        /// </summary>
        internal void InitializeGL()
        {
            engine.InitializeGL();
        }

        /// <summary>
        /// Terminates OpenGL context. This method must be called after all methods that require OpenGL context are finished.
        /// </summary>
        internal void TerminateGL()
        {
            engine.TerminateGL();
        }

        /// <summary>
        /// Renders frame using OpenGL context. This method should be called from the render thread. It returns 0 when there is no more work to do. Otherwise it returns 1.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal int RenderFrame(in DirectRenderingGLView.RenderCallbackInput input)
        {
            return engine.RenderFrameGL();
        }

        /// <summary>
        /// Resizes the current canvas. This method should be called when the size of the window changes. It updates the size of the current canvas and renders the full redraw.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        internal void Resize(int width, int height)
        {
            engine.UpdateGLWindowSize(width, height);
            engine.RenderFullyReDraw();
        }

        /// <summary>
        /// Clears the current canvas. All strokes and pictures will be removed.
        /// </summary>
        internal void ClearCanvas()
        {
            engine.ClearCurrentCanvas();
        }

        /// <summary>
        /// Adds picture
        /// </summary>
        /// <param name="path"></param>
        internal void AddPicture(string path, Size2D size, Position2D position)
        {
            engine.AddPicture(path, position.X, position.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Toggles the grid
        /// </summary>
        /// <param name="gridType"></param>
        internal void ToggleGrid(GridDensityType gridType)
        {
            engine.ToggleGrid((int)gridType);
        }

        /// <summary>
        /// Sets the canvas background color
        /// </summary>
        /// <param name="color"></param>
        internal void SetCanvasColor(Color color)
        {
            engine.CanvasSetColor(ToHex(color), 1.0f);
        }

        /// <summary>
        /// Saves the canvas
        /// </summary>
        /// <param name="path"></param>
        internal void SaveCanvas(string path)
        {
            engine.SaveCanvas(canvasId, path);
        }

        /// <summary>
        /// Loads the canvas from the specified path.
        /// </summary>
        /// <param name="path"></param>
        internal void LoadCanvas(string path)
        {
            if (!File.Exists(path))
            {
                Tizen.Log.Error("NUI", $"Loading canvas error: {path}\n");
            }
            else
            {
                engine.LoadCanvas(canvasId, path);
            }
        }

        /// <summary>
        /// Takes screenshot of the current canvas and saves it to the specified path. The area of the screenshot is defined by the coordinates and dimensions. The callback is called when the screenshot is saved. The callback has one parameter which is the path to the saved image. If the path is null, then the screenshot was not saved successfully.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="callback"></param>
        internal void TakeScreenShot(string path, int x, int y, int width, int height, PenWave.ScreenShotCallback callback)
        {
            engine.TakeScreenshot(canvasId, path, x, y, width, height, callback);
        }

        // Converts Color to hex string.
        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        internal bool CanvasMoveBegin()
        {
            return engine.CanvasMoveBegin();
        }

        internal bool CanvasMoveUpdate(int x, int y)
        {
            return engine.CanvasMove(x, y);
        }

        internal bool CanvasMoveEnd()
        {
            return engine.CanvasMoveEnd();
        }

        internal bool CanvasZoomBegin()
        {
            return engine.CanvasZoomBegin();
        }

        internal bool CanvasZoomUpdate(float x, float y, float zoom, float dx, float dy)
        {
            return engine.CanvasZoom(x, y, zoom, dx, dy);
        }

        internal bool CanvasZoomEnd()
        {
            return engine.CanvasZoomEnd();
        }
    }
}