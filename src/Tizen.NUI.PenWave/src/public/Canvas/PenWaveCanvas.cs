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
    /// PenWaveCanvas is a view that allows drawing on it using various tools.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PenWaveCanvas : DirectRenderingGLView
    {
        /// <summary>
        /// Events that are triggered when the tool starts an action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ActionStarted;

        /// <summary>
        /// Events that are triggered when the tool finishes an action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ActionFinished;

        private UnRedoManager unredoManager;
        private CanvasRenderer renderer;
        private PropertyNotification propertyNotification;
        private ToolBase currentTool;

        /// <summary>
        /// Creates a new instance of a PenWaveCanvas.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PenWaveCanvas() : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            renderer = new CanvasRenderer(PenWave.Instance.CreateCanvas(-1, -1));
            InitializeCanvas();
        }

        /// <summary>
        /// Creates a new instance of a PenWaveCanvas with a background image.
        /// </summary>
        /// <param name="backgroundPath"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PenWaveCanvas(string backgroundPath) : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            renderer = new CanvasRenderer(PenWave.Instance.CreateCanvasWithBackgroundImage(backgroundPath));
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToolBase Tool
        {
            get => currentTool;
            set
            {
                if (value == currentTool) return;
                if (currentTool!= null)
                {
                    currentTool.Deactivate();
                    currentTool.ActionStarted -= OnStarted;
                    currentTool.ActionFinished -= OnFinished;;
                }

                currentTool = value;

                if (currentTool != null)
                {
                    currentTool.Activate();
                    currentTool.ActionStarted += OnStarted;
                    currentTool.ActionFinished += OnFinished;
                }
            }
        }

        // Event handlers for action started.
        private void OnStarted(object sender, EventArgs e)
        {
            ActionStarted?.Invoke(this, e);
        }

        // Event handlers for action finished.
        private void OnFinished(object sender, EventArgs e)
        {
            ActionFinished?.Invoke(this, e);
        }

        /// <summary>
        /// Clears the canvas.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCanvas()
        {
            var command = new Command(() => renderer.ClearCanvas());
            unredoManager.Execute(command);
        }

        /// <summary>
        /// Returns true if there are any actions that can be undone. Otherwise returns false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanUndo => unredoManager.CanUndo;

        /// <summary>
        /// Returns true if there are any actions that can be redone. Otherwise returns false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanRedo => unredoManager.CanRedo;

        /// <summary>
        /// Undoes the last action. If there are no actions to undo, nothing happens.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Undo()
        {
            unredoManager.Undo();
        }

        /// <summary>
        /// Redoes the last action. If there are no actions to redo, nothing happens.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Redo()
        {
            unredoManager.Redo();
        }

        /// <summary>
        /// Sets the color of the canvas.
        /// </summary>
        /// <param name="color"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCanvasColor(Color color)
        {
            renderer.SetCanvasColor(color);
        }

        /// <summary>
        /// Toggles the visibility of the grid.
        /// </summary>
        /// <param name="gridType"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddPicture(string path, Size2D size, Position2D position)
        {
            var command = new Command(() => renderer.AddPicture(path, size, position));
            unredoManager.Execute(command);
        }

        /// <summary>
        /// Handles touch events.  This touch event is delivered to the current tool.
        /// </summary>
        /// <param name="touch"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HandleInput(Touch touch)
        {
            currentTool?.HandleInput(touch, unredoManager);
        }

        /// <summary>
        /// Saves the canvas to a file.
        /// </summary>
        /// <param name="path"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SaveCanvas(string path)
        {
            renderer.SaveCanvas(path);
        }

        /// <summary>
        /// Loads the canvas from a file.
        /// </summary>
        /// <param name="path"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadCanvas(string path)
        {
            renderer.LoadCanvas(path);
        }

        /// <summary>
        /// Takes a screen shot of the canvas and saves it to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="callback"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void TakeScreenShot(string path, int x, int y, int width, int height, PenWave.ThumbnailSavedCallback callback)
        {
            renderer.TakeScreenShot(path, x, y, width, height, callback);
        }

        /// <summary>
        /// Disposes the PenWaveCanvas.
        /// </summary>
        /// <param name="type"></param>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed) return;
            currentTool.ActionStarted -= OnStarted;
            currentTool.ActionFinished -= OnFinished;;
            renderer.TerminateGL();
            base.Dispose(type);
        }
    }
}
