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
        private bool isTouchedInsideSelectedArea = false;

        // Current mode of operation
        private Mode currentMode = Mode.None;

        // Type of drawable object being interacted with
        private DrawableType drawableType = DrawableType.None;

        // Initial touch position
        private Vector2 initialTouch = new Vector2(0, 0);

        // Variables used during scaling operations
        private float startScaleX;
        private float startScaleY;
        private float anchorX;
        private float anchorY;

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
            currentMode = Mode.None;
            EndDrawing(0, 0, 0);
        }

        /// <summary>
        /// Handle input events from the touch.
        /// </summary>
        /// <param name="touch"></param>
        /// <param name="unredoManager"></param>
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
            initialTouch = new Vector2(positionX, positionY);
            isTouchedInsideSelectedArea = PenWave.Instance.InsideSelectedArea(positionX, positionY);
            if (!isTouchedInsideSelectedArea)
            {
                PenWave.Instance.DropSelectedDrawables();
                drawableType = (DrawableType)PenWave.Instance.SelectDrawable(positionX, positionY);
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
                            initialTouch.X >= topLeftX + widthSelection  * 0.5f,
                            initialTouch.X <  topLeftX + widthSelection  * 0.5f,
                            initialTouch.Y >= topLeftY + heightSelection * 0.5f,
                            initialTouch.Y <  topLeftY + heightSelection * 0.5f,
                            ref anchorX,
                            ref anchorY
                        );

                        currentMode = Mode.Scale;
                    }
                    startScaleX = initialTouch.X;
                    startScaleY = initialTouch.Y;
                }
            }
            NotifyActionStarted();
        }

        // Continue drawing the selection area or interacting with the selected drawables.
        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (drawableType == DrawableType.None)
            {
                if (currentMode == Mode.None)
                {
                    PenWave.Instance.StartSelectingArea(positionX, positionY);
                }
                PenWave.Instance.ResizeSelectedArea(positionX, positionY);
                currentMode = Mode.Resize;
            }
            else if (currentMode != Mode.Resize && drawableType != DrawableType.None)
            {
                if (Selection == SelectionType.Move)
                {
                    PenWave.Instance.DragSelectedDrawables(positionX, positionY);
                    currentMode = Mode.Move;
                }
                else if (Selection == SelectionType.Rotate)
                {
                    PenWave.Instance.RotateSelected(positionX, positionY);
                    currentMode = Mode.Rotate;
                }
                else if (Selection == SelectionType.Scale)
                {
                    PenWave.Instance.ScaleSelection(
                                (positionX - anchorX) / (startScaleX - anchorX),
                                (positionY - anchorY) / (startScaleY - anchorY));
                    currentMode = Mode.Scale;
                }
            }
        }

        // End drawing the selection area or interacting with the selected drawables.
        private void EndDrawing(float positionX, float positionY, uint touchTime)
        {
            switch (currentMode)
            {
                case Mode.Move :
                    PenWave.Instance.EndDraging();
                    break;
                case Mode.Resize :
                    drawableType = (DrawableType)PenWave.Instance.SelectDrawables();
                    break;
                case Mode.Rotate :
                    PenWave.Instance.EndRotating(positionX, positionY);
                    break;
                case Mode.Scale :
                    PenWave.Instance.EndRotating(positionX, positionY);
                    PenWave.Instance.EndSelectionScale(
                                    (positionX - anchorX) / (startScaleX - anchorX),
                                    (positionY - anchorY) / (startScaleY - anchorY));
                    break;
                default :
                    PenWave.Instance.DropSelectedDrawables();
                    break;
            }
            isTouchedInsideSelectedArea = false;
            currentMode = Mode.None;
            NotifyActionFinished();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            return false;
        }

    }
}

