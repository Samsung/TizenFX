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
    public class PWCanvasView : DirectRenderingGLView
    {
        public uint ID {get; set;}
        public ToolManager ToolManager {get; private set;}
        public List<Page>  Pages {get; set;}
        public Color BackgroundColor {get; set;}
        public Size2D Size {get; set;}
        public Position2D position {get; set;}

        private PropertyNotification propertyNotification;

        private readonly string FontPath = FrameworkInformation.ResourcePath + "fonts/font.ttf";
        private readonly string[] TexturePaths = {
            FrameworkInformation.ResourcePath + "images/textures/brush_acrylic.png",
            FrameworkInformation.ResourcePath + "images/textures/brush_sponge.png",
            FrameworkInformation.ResourcePath + "images/textures/dot_brush.png",
            FrameworkInformation.ResourcePath + "images/textures/highlighter.png",
            FrameworkInformation.ResourcePath + "images/textures/soft_brush.png"
        };

        public PWCanvasView() : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            ID = PWEngine.CreateCanvas(-1, -1);
            InitialCanvasView();
        }

        public PWCanvasView(string backgroundPath) : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            ID = PWEngine.CreateCanvasWithBackgroundImage(backgroundPath);
            InitialCanvasView();
        }

        private void InitialCanvasView()
        {
            PWEngine.SetCurrentCanvas(ID);
            PWEngine.SetResourcePath(FrameworkInformation.ResourcePath + "images/");
            PWEngine.SetFontPath(FontPath);
            PWEngine.SetTexturePaths(TexturePaths, TexturePaths.Length);

            this.ToolManager = new ToolManager(this);
            this.WidthResizePolicy = ResizePolicyType.FillToParent;
            this.HeightResizePolicy = ResizePolicyType.FillToParent;
            this.SetGraphicsConfig(false, false, 0, GLESVersion.Version20);
            this.RenderingMode = GLRenderingMode.Continuous;
            this.RegisterGLCallbacks(PWEngine.InitializeGL, OnRender, PWEngine.TerminateGL);

            propertyNotification = this.AddPropertyNotification("size", PropertyCondition.Step(1.0f));
            propertyNotification.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
            {
                Tizen.NUI.BaseComponents.View target = args.PropertyNotification.GetTarget() as Tizen.NUI.BaseComponents.View;
                if (target != null)
                {
                    PWEngine.UpdateGLWindowSize((int)target.SizeWidth, (int)target.SizeHeight);
                    PWEngine.RenderFullyReDraw();
                }
            };
            // this.TouchEvent += OnTouchEvent;
        }


        // private bool OnTouchEvent(object source, View.TouchEventArgs e)
        // {
        //     ToolManager.HandleInput(e.Touch);
        //     return false;
        // }

        private int OnRender(in DirectRenderingGLView.RenderCallbackInput input)
        {
            return PWEngine.RenderFrameGL();
        }


        public void AddPage()
        {

        }

        public void SetCurrentPage(int pageIndex)
        {

        }

        public void ClearCanvas()
        {

        }

        public void TakeScreenShot(float x, float y, float width, float height)
        {

        }

        public void ToggleGrid(int densityType)
        {

        }

        public void DoOperation(int operitionType)
        {
            //Undo, Redo, ResetUndo, ResetRedo
        }

        public void Export(int exportType, string filePath)
        {

        }

        public void HandleInput(Touch touch)
        {
            ToolManager.HandleInput(touch);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            PWEngine.TerminateGL();

            base.Dispose(type);
        }
    }
}