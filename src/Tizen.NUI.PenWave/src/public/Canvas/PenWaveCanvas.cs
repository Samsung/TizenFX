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

        private UnRedoManager _unredoManager;
        private PropertyNotification _propertyNotification;
        private ToolBase _currentTool;
        private ToolBase _canvasTool;
        private uint _canvasId;

        /// <summary>
        /// Creates a new instance of a PenWaveCanvas.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PenWaveCanvas() : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            _canvasId = PenWaveRenderer.Instance.CreateCanvas(-1, -1);
            PenWaveRenderer.Instance.SetCurrentCanvas(_canvasId);
            InitializeCanvas();
        }

        /// <summary>
        /// Creates a new instance of a PenWaveCanvas with a background image.
        /// </summary>
        /// <param name="backgroundPath"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PenWaveCanvas(string backgroundPath) : base(DirectRenderingGLView.ColorFormat.RGBA8888, DirectRenderingGLView.BackendMode.UnsafeDirectRendering)
        {
            _canvasId = PenWaveRenderer.Instance.CreateCanvasWithBackgroundImage(backgroundPath);
            PenWaveRenderer.Instance.SetCurrentCanvas(_canvasId);
            InitializeCanvas();
        }

        // Initialize canvas
        private void InitializeCanvas()
        {
            _unredoManager = new UnRedoManager();
            _canvasTool = new CanvasTool(this);
            this.WidthResizePolicy = ResizePolicyType.FillToParent;
            this.HeightResizePolicy = ResizePolicyType.FillToParent;

            this.RenderingMode = GLRenderingMode.Continuous;
            this.RegisterGLCallbacks(PenWaveRenderer.Instance.InitializeGL, PenWaveRenderer.Instance.RenderFrame, PenWaveRenderer.Instance.TerminateGL);
            this.SetGraphicsConfig(false, false, 0, GLESVersion.Version20);

            _propertyNotification = this.AddPropertyNotification("size", PropertyCondition.Step(1.0f));
            _propertyNotification.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
            {
                Tizen.NUI.BaseComponents.View target = args.PropertyNotification.GetTarget() as Tizen.NUI.BaseComponents.View;
                if (target != null)
                {
                    PenWaveRenderer.Instance.Resize((int)target.SizeWidth, (int)target.SizeHeight);
                }
            };
        }

        /// <summary>
        /// The tool used to draw on the canvas. If the tool is changed, the previous tool will be deactivated and the new tool will be activated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToolBase CurrentTool
        {
            get => _currentTool;
            set
            {
                if (value == _currentTool) return;
                if (_currentTool!= null)
                {
                    _currentTool.Deactivate();
                    _currentTool.ActionStarted -= OnStarted;
                    _currentTool.ActionFinished -= OnFinished;;
                }

                _currentTool = value;

                if (_currentTool != null)
                {
                    _currentTool.Activate();
                    _currentTool.ActionStarted += OnStarted;
                    _currentTool.ActionFinished += OnFinished;
                }
            }
        }

        /// <summary>
        /// Notifies that the canvas has started an action.
        /// </summary>
        private void NotifyActionStarted(object sender, EventArgs e)
        {
            ActionStarted?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Notifies that the canvas has finished an action.
        /// </summary>
        private void NotifyActionFinished(object sender, EventArgs e)
        {
            ActionFinished?.Invoke(this, EventArgs.Empty);
        }


        // Event handlers for action started.
        private void OnStarted(object sender, EventArgs e)
        {
            NotifyActionStarted(sender, e);
        }

        // Event handlers for action finished.
        private void OnFinished(object sender, EventArgs e)
        {
            RegisterUndo();
            NotifyActionFinished(sender, e);
        }

        private void RegisterUndo()
        {
            _unredoManager.RegisterUndo();
        }

        /// <summary>
        /// Clears the canvas.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCanvas()
        {
            PenWaveRenderer.Instance.ClearCurrentCanvas();
            RegisterUndo();
            NotifyActionFinished(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns true if there are any actions that can be undone. Otherwise returns false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanUndo => _unredoManager.CanUndo;

        /// <summary>
        /// Returns true if there are any actions that can be redone. Otherwise returns false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanRedo => _unredoManager.CanRedo;

        /// <summary>
        /// Undoes the last action. If there are no actions to undo, nothing happens.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Undo()
        {
            _unredoManager.Undo();
        }

        /// <summary>
        /// Redoes the last action. If there are no actions to redo, nothing happens.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Redo()
        {
            _unredoManager.Redo();
        }

        /// <summary>
        /// Sets the color of the canvas.
        /// </summary>
        /// <param name="color"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCanvasColor(Color color)
        {
            PenWaveRenderer.Instance.SetCanvasColor(color);
        }

        /// <summary>
        /// Toggles the visibility of the grid.
        /// </summary>
        /// <param name="gridType"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ToggleGrid(GridDensityType gridType)
        {
            PenWaveRenderer.Instance.ToggleGrid(gridType);
        }

        /// <summary>
        /// Adds a picture to canvas
        /// </summary>
        /// <param name="path">The image file path</param>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddPicture(string path, float x, float y, float width, float height)
        {
            PenWaveRenderer.Instance.AddPicture(path, x, y, width, height);
            RegisterUndo();
            NotifyActionFinished(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles touch events.  This touch event is delivered to the current tool.
        /// </summary>
        /// <param name="touch"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HandleInput(Touch touch)
        {
            if (!_canvasTool.HandleInput(touch))
            {
                _currentTool?.HandleInput(touch);
            }
        }

        /// <summary>
        /// Handles wheel events.  This wheel event is delivered to the current tool.
        /// </summary>
        /// <param name="wheel"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HandleInput(Wheel wheel)
        {
            if (!_canvasTool.HandleInput(wheel))
            {
                _currentTool?.HandleInput(wheel);
            }
        }

        /// <summary>
        /// Saves the canvas to a file.
        /// </summary>
        /// <param name="path"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SaveCanvas(string path)
        {
            PenWaveRenderer.Instance.SaveCanvas(_canvasId, path);
        }

        /// <summary>
        /// Loads the canvas from a file.
        /// </summary>
        /// <param name="path"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadCanvas(string path)
        {
            PenWaveRenderer.Instance.LoadCanvas(_canvasId, path);
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
        public void TakeScreenShot(string path, int x, int y, int width, int height, EventHandler callback)
        {
            PenWaveRenderer.Instance.TakeScreenShot(_canvasId, path, x, y, width, height, () => {
                callback?.Invoke(this, EventArgs.Empty);
            });
        }

        /// <summary>
        /// Start the canvas movement.
        /// </summary>
        /// <returns>True if the canvas move begin is successful, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MoveBegin()
        {
            return PenWaveRenderer.Instance.CanvasMoveBegin();
        }

        /// <summary>
        /// Update the canvas movement.
        /// </summary>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <returns>True if the canvas move update is successful, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MoveUpdate(int x, int y)
        {
            return PenWaveRenderer.Instance.CanvasMove(x, y);
        }

        /// <summary>
        /// End the canvas movement.
        /// </summary>
        /// <returns>True if the canvas move end is successful, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MoveEnd()
        {
            return PenWaveRenderer.Instance.CanvasMoveEnd();
        }

        /// <summary>
        /// Start the canvas zoom
        /// </summary>
        /// <returns>True if the canvas zoom begin is successful, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ZoomBegin()
        {
            return PenWaveRenderer.Instance.CanvasZoomBegin();
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ZoomUpdate(float x, float y, float zoom, float dx, float dy)
        {
            return PenWaveRenderer.Instance.CanvasZoom(x, y, zoom, dx, dy);
        }

        /// <summary>
        /// End the canvas zoom
        /// </summary>
        /// <returns>True if the canvas zoom end is successful, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ZoomEnd()
        {
            return PenWaveRenderer.Instance.CanvasZoomEnd();
        }

        /// <summary>
        /// Get the canvas zoom value
        /// </summary>
        /// <returns>The zoom value</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetZoomValue()
        {
            return PenWaveRenderer.Instance.CanvasGetZoomValue();
        }

        /// <summary>
        /// Set the canvas zoom value
        /// </summary>
        /// <param name="zoomValue">The zoom value</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetZoomValue(int zoomValue)
        {
            PenWaveRenderer.Instance.CanvasSetZoomValue(zoomValue);
        }

        /// <summary>
        /// Zoom to the specified value
        /// </summary>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="zoomValue">The zoom value</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetZoomValue(int x, int y, int zoomValue)
        {
            PenWaveRenderer.Instance.CanvasSetZoomValue(x, y, zoomValue);
        }

        /// <summary>
        /// Disposes the PenWaveCanvas.
        /// </summary>
        /// <param name="type"></param>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed) return;
            _currentTool.ActionStarted -= OnStarted;
            _currentTool.ActionFinished -= OnFinished;;
            PenWaveRenderer.Instance.TerminateGL();
            base.Dispose(type);
        }
    }
}
