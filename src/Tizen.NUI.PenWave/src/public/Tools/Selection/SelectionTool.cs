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
    public class SelectionTool : ToolBase
    {
        /// <summary>
        /// Enumeration for the type of selection operation
        /// </summary>
        public enum SelectionType
        {
            Move  = 0,
            Scale,
            Rotate,
        }

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
        public SelectionTool(SelectionType selectionType)
        {
            Selection = selectionType;
        }

        /// <summary>
        /// The type of selection operation. Default is move.
        /// </summary>
        public SelectionType Selection { get; set; }


        /// <summary>
        /// Activate the selection tool. This method is called when the tool is selected from the tools
        /// </summary>
        public override void Activate()
        {
        }

        /// <summary>
        /// Deactivate the selection tool. This method is called when the tool is deselected from the tools
        /// </summary>
        public override void Deactivate()
        {
            currentMode = Mode.None;
            EndDrawing(new Vector2(), 0);
        }

        /// <summary>
        /// Handle input events from the touch.
        /// </summary>
        /// <param name="touch"></param>
        /// <param name="unredoManager"></param>
        public override void HandleInput(Touch touch, UnRedoManager unredoManager)
        {
            if (touch == null || touch.GetPointCount() == 0) return;

            uint pointStateIndex = 0;
            uint touchTime = touch.GetTime();

            List<Vector2> touchPositionList = new List<Vector2>();
            for (uint i = 0; i < touch.GetPointCount(); ++i)
            {
                touchPositionList.Add(touch.GetLocalPosition(i));
            }

            Vector2 position = touchPositionList[(int)pointStateIndex];
            switch (touch.GetState(pointStateIndex))
            {
                case PointStateType.Down:
                    StartDrawing(position, touchTime);
                    break;
                case PointStateType.Motion:
                    ContinueDrawing(position, touchTime);
                    break;
                case PointStateType.Up:
                case PointStateType.Leave:
                    EndDrawing(position, touchTime);
                    break;
            }
        }

        // Start drawing the selection area or interacting with the selected drawables.
        private  void StartDrawing(Vector2 position, uint touchTime)
        {
            initialTouch = new Vector2(position.X, position.Y);
            isTouchedInsideSelectedArea = PWEngine.InsideSelectedArea(position.X, position.Y);
            if (!isTouchedInsideSelectedArea)
            {
                PWEngine.DropSelectedDrawables();
                drawableType = (DrawableType)PWEngine.SelectDrawable(position.X, position.Y);
            }
            else
            {
                if (Selection == SelectionType.Rotate)
                {
                    PWEngine.StartRotating(position.X, position.Y);
                }
                else if (Selection == SelectionType.Scale)
                {
                    float topLeftX = 0, topLeftY = 0, widthSelection = 0, heightSelection = 0;
                    PWEngine.GetSelectionDimensions(ref topLeftX, ref topLeftY, ref widthSelection, ref heightSelection);
                    if (!Double.IsNaN(topLeftX))
                    {
                        PWEngine.StartSelectionScale(
                            initialTouch.X >= topLeftX+widthSelection*0.5f,
                            initialTouch.X < topLeftX+widthSelection*0.5f,
                            initialTouch.Y >= topLeftY+heightSelection*0.5f,
                            initialTouch.Y < topLeftY+heightSelection*0.5f,
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
        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            if (drawableType == DrawableType.None)
            {
                if (currentMode == Mode.None)
                {
                    PWEngine.StartSelectingArea(position.X, position.Y);
                }
                PWEngine.ResizeSelectedArea(position.X, position.Y);
                currentMode = Mode.Resize;
            }
            else if (currentMode != Mode.Resize && drawableType != DrawableType.None)
            {
                if (Selection == SelectionType.Move)
                {
                    PWEngine.DragSelectedDrawables(position.X, position.Y);
                    currentMode = Mode.Move;
                }
                else if (Selection == SelectionType.Rotate)
                {
                    PWEngine.RotateSelected(position.X, position.Y);
                    currentMode = Mode.Rotate;
                }
                else if (Selection == SelectionType.Scale)
                {
                    PWEngine.ScaleSelection(
                                (position.X-anchorX)/(startScaleX-anchorX),
                                (position.Y-anchorY)/(startScaleY-anchorY)
                            );
                    currentMode = Mode.Scale;
                }
            }
        }

        // End drawing the selection area or interacting with the selected drawables.
        private void EndDrawing(Vector2 position, uint touchTime)
        {
            switch (currentMode)
            {
                case Mode.Move :
                    PWEngine.EndDraging();
                    break;
                case Mode.Resize :
                    drawableType = (DrawableType)PWEngine.SelectDrawables();
                    break;
                case Mode.Rotate :
                    PWEngine.EndRotating(position.X, position.Y);
                    break;
                case Mode.Scale :
                    PWEngine.EndRotating(position.X, position.Y);
                    PWEngine.EndSelectionScale(
                                    (position.X-anchorX)/(startScaleX-anchorX),
                                    (position.Y-anchorY)/(startScaleY-anchorY)
                                );
                    break;
                default :
                    PWEngine.DropSelectedDrawables();
                    break;
            }
            isTouchedInsideSelectedArea = false;
            currentMode = Mode.None;
            NotifyActionFinished();
        }

    }
}

