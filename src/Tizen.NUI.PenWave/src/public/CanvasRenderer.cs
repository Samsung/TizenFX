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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class CanvasRenderer
    {
        private static readonly string FontPath = FrameworkInformation.ResourcePath + "fonts/font.ttf";
        private static readonly string[] TexturePaths = {
            FrameworkInformation.ResourcePath + "images/textures/brush_acrylic.png",
            FrameworkInformation.ResourcePath + "images/textures/brush_sponge.png",
            FrameworkInformation.ResourcePath + "images/textures/dot_brush.png",
            FrameworkInformation.ResourcePath + "images/textures/highlighter.png",
            FrameworkInformation.ResourcePath + "images/textures/soft_brush.png"
        };

        private uint canvasId;

        public CanvasRenderer(uint canvasId)
        {
            this.canvasId = canvasId;
            PWEngine.SetCurrentCanvas(canvasId);
            PWEngine.SetResourcePath(FrameworkInformation.ResourcePath + "images/");
            PWEngine.SetFontPath(FontPath);
            PWEngine.SetTexturePaths(TexturePaths, TexturePaths.Length);
        }

        public void InitializeGL()
        {
            PWEngine.InitializeGL();
        }

        public void TerminateGL()
        {
            PWEngine.TerminateGL();
        }

        public int RenderFrame(in DirectRenderingGLView.RenderCallbackInput input)
        {
            return PWEngine.RenderFrameGL();
        }

        public void Resize(int width, int height)
        {
            PWEngine.UpdateGLWindowSize(width, height);
            PWEngine.RenderFullyReDraw();
        }

        public void ClearCanvas()
        {
            PWEngine.ClearCurrentCanvas();
        }

        public void AddPicture(string path)
        {
            PWEngine.AddPicture(path);
        }
    }
}