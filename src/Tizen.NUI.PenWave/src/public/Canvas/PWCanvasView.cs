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
    /// <summary>
    /// PWCanvasView is a view that allows drawing on it using various tools.
    /// </summary>
    public class PWCanvasView : DirectRenderingGLView
    {
        private UnRedoManager unredoManager;
        private CanvasRenderer renderer;
        private PropertyNotification propertyNotification;
        private ToolBase currentTool;

        /// <summary>
        /// Creates a new instance of a PWCanvasView.
        /// </summary>
        public PWCanvasView() : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            renderer = new CanvasRenderer(PWEngine.CreateCanvas(-1, -1));
            InitializeCanvas();
        }

        /// <summary>
        /// Creates a new instance of a PWCanvasView with a background image.
        /// </summary>
        /// <param name="backgroundPath"></param>
        public PWCanvasView(string backgroundPath) : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            renderer = new CanvasRenderer(PWEngine.CreateCanvasWithBackgroundImage(backgroundPath));
            InitializeCanvas();
        }

        // Initialize canvas
        private void InitializeCanvas()
        {
            unredoManager = new UnRedoManager();
            this.WidthResizePolicy = ResizePolicyType.FillToParent;
            this.HeightResizePolicy = ResizePolicyType.FillToParent;

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

        /// <summary>
        /// The tool used to draw on the canvas. If the tool is changed, the previous tool will be deactivated and the new tool will be activated.
        /// </summary>
        public ToolBase Tool
        {
            get => currentTool;
            set
            {
                currentTool?.Deactivate();
                currentTool = value;
                currentTool?.Activate();
            }
        }

        /// <summary>
        /// Clears the canvas.
        /// </summary>
        public void ClearCanvas()
        {
            var command = new Command(() => renderer.ClearCanvas());
            unredoManager.Execute(command);
        }

        /// <summary>
        /// Returns true if there are any actions that can be undone. Otherwise returns false.
        /// </summary>
        public bool CanUndo => unredoManager.CanUndo;

        /// <summary>
        /// Returns true if there are any actions that can be redone. Otherwise returns false.
        /// </summary>
        public bool CanRedo => unredoManager.CanRedo;

        /// <summary>
        /// Undoes the last action. If there are no actions to undo, nothing happens.
        /// </summary>
        public void Undo()
        {
            unredoManager.Undo();
        }

        /// <summary>
        /// Redoes the last action. If there are no actions to redo, nothing happens.
        /// </summary>
        public void Redo()
        {
            unredoManager.Redo();
        }

        /// <summary>
        /// Sets the color of the canvas.
        /// </summary>
        /// <param name="color"></param>
        public void SetCanvasColor(Color color)
        {
            renderer.SetCanvasColor(color);
        }

        /// <summary>
        /// Toggles the visibility of the grid.
        /// </summary>
        /// <param name="gridType"></param>
        public void ToggleGrid(GridDensityType gridType)
        {
            renderer.ToggleGrid(gridType);
        }

        /// <summary>
        /// Adds a picture to the canvas.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="size"></param>
        /// <param name="position"></param>
        public void AddPicture(string path, Size2D size, Position2D position)
        {
            var command = new Command(() => renderer.AddPicture(path));
            unredoManager.Execute(command);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="touch"></param>
        public void HandleInput(Touch touch)
        {
            currentTool?.HandleInput(touch, unredoManager);
        }

        /// <summary>
        /// Saves the canvas to a file.
        /// </summary>
        /// <param name="path"></param>
        public void SaveCanvas(string path)
        {
            renderer.SaveCanvas(path);
        }

        /// <summary>
        /// Loads the canvas from a file.
        /// </summary>
        /// <param name="path"></param>
        public void LoadCanvas(string path)
        {
            renderer.LoadCanvas(path);
        }

        /// <summary>
        /// Disposes the PWCanvasView.
        /// </summary>
        /// <param name="type"></param>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed) return;
            renderer.TerminateGL();
            base.Dispose(type);
        }
    }
}
