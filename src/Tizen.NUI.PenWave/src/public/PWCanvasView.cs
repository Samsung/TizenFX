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
        private CanvasRenderer renderer;
        private CanvasUIManager uiManager;
        private PageManager pageManager;
        private PropertyNotification propertyNotification;

        public ToolManager ToolManager {get; private set;}
        public event Action<int> OnPageChanged;
        public event Action OnCanvasCleared;

        public PWCanvasView() : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            pageManager = new PageManager();
            renderer = new CanvasRenderer(PWEngine.CreateCanvas(-1, -1));
            uiManager = new CanvasUIManager(this);
            ToolManager = new ToolManager();
            InitializeCanvas();
        }

        public PWCanvasView(string backgroundPath) : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            pageManager = new PageManager();
            renderer = new CanvasRenderer(PWEngine.CreateCanvasWithBackgroundImage(backgroundPath));
            uiManager = new CanvasUIManager(this);
            ToolManager = new ToolManager();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            this.RenderingMode = GLRenderingMode.Continuous;
            this.RegisterGLCallbacks(renderer.InitializeGL, renderer.RenderFrame, renderer.TerminateGL);
            this.SetGraphicsConfig(false, false, 0, GLESVersion.Version20);

            propertyNotification = this.AddPropertyNotification("size", PropertyCondition.Step(1.0f));
            propertyNotification.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
            {
                Tizen.NUI.BaseComponents.View target = args.PropertyNotification.GetTarget() as Tizen.NUI.BaseComponents.View;
                if (target != null)
                {
                    renderer.Resize((int)target.SizeWidth, (int)target.SizeHeight);
                }
            };
        }

        public void SetCurrentPage(int pageIndex)
        {
            pageManager.SetCurrentPage(pageIndex);
            OnPageChanged?.Invoke(pageIndex);
        }

        public void ClearCanvas()
        {
            // 캔버스 클리어 처리
            OnCanvasCleared?.Invoke();
        }


        public void HandleInput(Touch touch)
        {
            ToolManager.HandleInput(touch);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed) return;
            renderer.TerminateGL();
            base.Dispose(type);
        }
    }
}