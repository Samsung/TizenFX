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

        /// <summary>
        /// Constructor. Creates a new instance of CanvasRenderer. This constructor sets the current canvas to the specified canvas id. Also it sets paths to resources and initializes textures.
        /// </summary>
        /// <param name="canvasId"></param>
        public CanvasRenderer(uint canvasId)
        {
            this.canvasId = canvasId;
            PWEngine.SetCurrentCanvas(canvasId);
            PWEngine.SetResourcePath(FrameworkInformation.ResourcePath + "images/");
            PWEngine.SetFontPath(FontPath);
            PWEngine.SetTexturePaths(TexturePaths, TexturePaths.Length);
        }

        /// <summary>
        /// Initializes OpenGL context. This method must be called before any other methods that require OpenGL context.
        /// </summary>
        public void InitializeGL()
        {
            PWEngine.InitializeGL();
        }

        /// <summary>
        /// Terminates OpenGL context. This method must be called after all methods that require OpenGL context are finished.
        /// </summary>
        public void TerminateGL()
        {
            PWEngine.TerminateGL();
        }

        /// <summary>
        /// Renders frame using OpenGL context. This method should be called from the render thread. It returns 0 when there is no more work to do. Otherwise it returns 1.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int RenderFrame(in DirectRenderingGLView.RenderCallbackInput input)
        {
            return PWEngine.RenderFrameGL();
        }

        /// <summary>
        /// Resizes the current canvas. This method should be called when the size of the window changes. It updates the size of the current canvas and renders the full redraw.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Resize(int width, int height)
        {
            PWEngine.UpdateGLWindowSize(width, height);
            PWEngine.RenderFullyReDraw();
        }

        /// <summary>
        /// Clears the current canvas. All strokes and pictures will be removed.
        /// </summary>
        public void ClearCanvas()
        {
            PWEngine.ClearCurrentCanvas();
        }

        /// <summary>
        /// Adds picture
        /// </summary>
        /// <param name="path"></param>
        public void AddPicture(string path)
        {
            PWEngine.AddPicture(path);
        }

        /// <summary>
        /// Toggles the grid
        /// </summary>
        /// <param name="gridType"></param>
        public void ToggleGrid(GridDensityType gridType)
        {
            PWEngine.ToggleGrid((int)gridType);
        }

        /// <summary>
        /// Sets the canvas background color
        /// </summary>
        /// <param name="color"></param>
        public void SetCanvasColor(Color color)
        {
            PWEngine.CanvasSetColor(ToHex(color), 1.0f);
        }

        /// <summary>
        /// Saves the canvas
        /// </summary>
        /// <param name="path"></param>
        public void SaveCanvas(string path)
        {
            PWEngine.SaveCanvas(canvasId, path);
        }

        /// <summary>
        /// Loads the canvas from the specified path.
        /// </summary>
        /// <param name="path"></param>
        public void LoadCanvas(string path)
        {
            if ((!File.Exists(path)) || (new FileInfo(path).Length < 6))
            {
                Tizen.Log.Error("NUI", $"Loading canvas error: {path}\n");
            }
            else
            {
                PWEngine.LoadCanvas(canvasId, path);
            }
        }

        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }
    }
}