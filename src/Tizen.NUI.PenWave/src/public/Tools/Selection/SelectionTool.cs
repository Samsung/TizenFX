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
    /// The selection tool allows the user to select
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectionTool : ToolBase
    {

        // Enumeration for the type of drawable object
        private enum DrawableType
        {
            None,  //nothing found/selected
            Multi, //more than one drawable selected
            Shape,
            Chart,
            Picture,
            Text
        }

        // Enumeration for the current mode of operation
        private enum Mode
        {
            None,
            Move,
            Resize,
            Scale,
            Rotate
        }

        // Flag to check if the touch is inside the selected area
        private bool _isTouchedInsideSelectedArea = false;

        // Current mode of operation
        private Mode _currentMode = Mode.None;

        // Type of drawable object being interacted with
        private DrawableType _drawableType = DrawableType.None;

        // Initial touch position
        private float _initialTouchX;
        private float _initialTouchY;

        // Variables used during scaling operations
        private float _startScaleX;
        private float _startScaleY;
        private float _anchorX;
        private float _anchorY;

        /// <summary>
        /// Constructor for the selection tool.
        /// </summary>
        /// <param name="selectionType"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectionTool(SelectionType selectionType)
        {
            Selection = selectionType;
        }

        /// <summary>
        /// The type of selection operation. Default is move.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectionType Selection { get; set; }


        /// <summary>
        /// Activate the selection tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Activate()
        {
        }

        /// <summary>
        /// Deactivate the selection tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Deactivate()
        {
            _currentMode = Mode.None;
            EndDrawing(0, 0, 0);
        }

        /// <summary>
        /// Handle input events from the touch.
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the input was handled, otherwise false.</returns>
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
                    EndDrawing(position.X, position.Y, touchTime);
                    break;
            }
            return true;
        }

        // Start drawing the selection area or interacting with the selected drawables.
        private  void StartDrawing(float positionX, float positionY, uint touchTime)
        {
            _initialTouchX = positionX;
            _initialTouchY = positionY;
            _isTouchedInsideSelectedArea = PenWave.Instance.InsideSelectedArea(positionX, positionY);
            if (!_isTouchedInsideSelectedArea)
            {
                PenWave.Instance.DropSelectedDrawables();
                _drawableType = (DrawableType)PenWave.Instance.SelectDrawable(positionX, positionY);
            }
            else
            {
                if (Selection == SelectionType.Rotate)
                {
                    PenWave.Instance.StartRotating(positionX, positionY);
                }
                else if (Selection == SelectionType.Scale)
                {
                    float topLeftX = 0, topLeftY = 0, widthSelection = 0, heightSelection = 0;
                    PenWave.Instance.GetSelectionDimensions(ref topLeftX, ref topLeftY, ref widthSelection, ref heightSelection);
                    if (!Double.IsNaN(topLeftX))
                    {
                        PenWave.Instance.StartSelectionScale(
                            _initialTouchX >= topLeftX + widthSelection  * 0.5f,
                            _initialTouchX <  topLeftX + widthSelection  * 0.5f,
                            _initialTouchY >= topLeftY + heightSelection * 0.5f,
                            _initialTouchY <  topLeftY + heightSelection * 0.5f,
                            ref _anchorX,
                            ref _anchorY
                        );

                        _currentMode = Mode.Scale;
                    }
                    _startScaleX = _initialTouchX;
                    _startScaleY = _initialTouchY;
                }
            }
            NotifyActionStarted();
        }

        // Continue drawing the selection area or interacting with the selected drawables.
        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (_drawableType == DrawableType.None)
            {
                if (_currentMode == Mode.None)
                {
                    PenWave.Instance.StartSelectingArea(positionX, positionY);
                }
                PenWave.Instance.ResizeSelectedArea(positionX, positionY);
                _currentMode = Mode.Resize;
            }
            else if (_currentMode != Mode.Resize && _drawableType != DrawableType.None)
            {
                if (Selection == SelectionType.Move)
                {
                    PenWave.Instance.DragSelectedDrawables(positionX, positionY);
                    _currentMode = Mode.Move;
                }
                else if (Selection == SelectionType.Rotate)
                {
                    PenWave.Instance.RotateSelected(positionX, positionY);
                    _currentMode = Mode.Rotate;
                }
                else if (Selection == SelectionType.Scale)
                {
                    PenWave.Instance.ScaleSelection(
                                (positionX - _anchorX) / (_startScaleX - _anchorX),
                                (positionY - _anchorY) / (_startScaleY - _anchorY));
                    _currentMode = Mode.Scale;
                }
            }
        }

        // End drawing the selection area or interacting with the selected drawables.
        private void EndDrawing(float positionX, float positionY, uint touchTime)
        {
            switch (_currentMode)
            {
                case Mode.Move :
                    PenWave.Instance.EndDraging();
                    break;
                case Mode.Resize :
                    _drawableType = (DrawableType)PenWave.Instance.SelectDrawables();
                    break;
                case Mode.Rotate :
                    PenWave.Instance.EndRotating(positionX, positionY);
                    break;
                case Mode.Scale :
                    PenWave.Instance.EndRotating(positionX, positionY);
                    PenWave.Instance.EndSelectionScale(
                                    (positionX - _anchorX) / (_startScaleX - _anchorX),
                                    (positionY - _anchorY) / (_startScaleY - _anchorY));
                    break;
                default :
                    PenWave.Instance.DropSelectedDrawables();
                    break;
            }
            _isTouchedInsideSelectedArea = false;
            _currentMode = Mode.None;
            NotifyActionFinished();
        }

        /// <summary>
        /// Handle input events from the mouse wheel.
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

