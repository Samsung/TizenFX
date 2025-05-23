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

using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The CanvasTool class provides a tool that allows the user to move the canvas around.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CanvasTool : ToolBase
    {
        private float _initialTouchX;
        private float _initialTouchY;
        private bool _isCanvasMoving = false;
        private PenWaveCanvas _canvasView;

        /// <summary>
        /// Creates a new instance of a CanvasTool.
        /// </summary>
        /// <param name="canvasView">The PenWaveCanvas</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CanvasTool(PenWaveCanvas canvasView)
        {
            _canvasView = canvasView;
        }

        /// <summary>
        /// Activates the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Activate()
        {
        }

        /// <summary>
        /// Deactivates the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Deactivate()
        {
            EndDrawing();
        }

        /// <summary>
        /// Handles input from the user.
        /// </summary>
        /// <param name="touch">The touch event.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Touch touch)
        {
            if (touch == null || touch.GetPointCount() == 0) return false;

            uint pointStateIndex = 0;
            uint touchTime = touch.GetTime();

            List<Vector2> touchPositionList = new List<Vector2>();
            for (uint i = 0; i < touch.GetPointCount(); ++i)
            {
                touchPositionList.Add(touch.GetScreenPosition(i));
            }

            Vector2 position = touchPositionList[(int)pointStateIndex];
            if (touch.GetMouseButton(0) == MouseButton.Secondary)
            {
                _isCanvasMoving = true;
            }
            switch (touch.GetState(pointStateIndex))
            {
                case PointStateType.Down:
                    StartDrawing(position.X, position.Y, touchTime);
                    break;
                case PointStateType.Motion:
                    ContinueDrawing(position.X, position.Y, touchTime);
                    break;
                case PointStateType.Up:
                case PointStateType.Leave:
                    EndDrawing();
                    break;
            }
            return _isCanvasMoving;
        }

        // Start drawing when the first touch down event occurs.
        private  void StartDrawing(float positionX, float positionY, uint touchTime)
        {
            if (_isCanvasMoving)
            {
                _initialTouchX = positionX;
                _initialTouchY = positionY;
                _canvasView.MoveBegin();
            }
        }

        // Continue drawing the touch motion events occur.
        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (_isCanvasMoving)
            {
                _canvasView.MoveUpdate((int)(positionX - _initialTouchX), (int)(positionY - _initialTouchY));
            }
        }

        // End drawing when the last touch up event occurs.
        private void EndDrawing()
        {
            if (_isCanvasMoving)
            {
                _canvasView.MoveEnd();
                _isCanvasMoving = false;
            }
        }

        /// <summary>
        /// Handles input from the user.
        /// </summary>
        /// <param name="wheel">The wheel event.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            Vector2 point = wheel.Point;
            float zoom = 1.0f - ((float)wheel.Z * 0.05f);
            _canvasView.ZoomBegin();
            _canvasView.ZoomUpdate(point.X, point.Y, zoom, 0, 0);
            _canvasView.ZoomEnd();
            return true;
        }

    }
}

