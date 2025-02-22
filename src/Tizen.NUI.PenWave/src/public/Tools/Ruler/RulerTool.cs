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

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The RulerTool class allows the user to draw lines, circles and rectangles on the screen.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RulerTool : ToolBase
    {

        // The id of the current shape being drawn.
        private uint _currentShapeId;
        private float _dragStartX = 0;
        private float _dragStartY = 0;
        private bool _isDrawingCircular = false;

        /// <summary>
        /// The constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RulerTool(RulerType rulerType)
        {
            Ruler = rulerType;
        }

        /// <summary>
        /// The type of selection operation. Default is move.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RulerType Ruler { get; set; }

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
        /// <returns>True if the input was handled.</returns>
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
            return true;
        }

        private void StartDrawing(float positionX, float positionY, uint touchTime)
        {

            if (Ruler == RulerType.Line)
            {
                _currentShapeId = PenWaveRenderer.Instance.BeginLineDraw(positionX, positionY, touchTime);
                _isDrawingCircular = false;
            }
            else if (Ruler == RulerType.Circle)
            {
                if(!_isDrawingCircular)
                {
                    _dragStartX = positionX;
                    _dragStartY = positionY;
                    _isDrawingCircular = true;
                }
                else
                {
                    double rad = Math.Sqrt(((_dragStartX - positionX) * (_dragStartX - positionX)) + ((_dragStartY - positionY) * (_dragStartY - positionY)));
                    _currentShapeId = PenWaveRenderer.Instance.AddArcPath(_dragStartX, _dragStartY,(float) rad, positionX, positionY, false );
                    _isDrawingCircular = false;
                }
            }
            else if (Ruler == RulerType.Rectangle)
            {
                _currentShapeId = PenWaveRenderer.Instance.AddRectanglePath(positionX, positionY, 400.0f, 400.0f, false);
                _isDrawingCircular = false;
            }

            if (_currentShapeId > 0)
            {
                NotifyActionStarted();
            }
        }


        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (_currentShapeId > 0)
            {
                if (Ruler == RulerType.Line)
                {
                    PenWaveRenderer.Instance.DrawLine(_currentShapeId, positionX, positionY, touchTime);
                }
                else
                {
                    var res = PenWaveRenderer.Instance.ResizeShapePath(_currentShapeId, positionX, positionY);
                    if (res == ErrorShapeAddPointsType.DrawingCanceled)
                    {
                        PenWaveRenderer.Instance.FinishShapePath(_currentShapeId);
                    }
                }
            }
        }

        private void EndDrawing()
        {
            if (_currentShapeId > 0)
            {
                if (Ruler == RulerType.Line)
                {
                    PenWaveRenderer.Instance.EndLineDraw(_currentShapeId, 0);
                }
                else
                {
                    PenWaveRenderer.Instance.FinishShapePath(_currentShapeId);
                }
                _currentShapeId = 0;
                NotifyActionFinished();
            }
        }

        /// <summary>
        /// Handles input from the user.
        /// </summary>
        /// <param name="wheel">The wheel event.</param>
        /// <returns>True if the input was handled.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            return false;
        }

    }
}

