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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RulerTool : ToolBase
    {

        // The id of the current shape being drawn.
        private uint currentShapeId;
        private float dragStartX = 0;
        private float dragStartY = 0;
        private bool isDrawingCircular = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RulerTool(RulerType typeOfRuler)
        {
            Ruler = typeOfRuler;
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
                currentShapeId = PenWave.Instance.BeginLineDraw(positionX, positionY, touchTime);
                isDrawingCircular = false;
            }
            else if (Ruler == RulerType.Circle)
            {
                if(!isDrawingCircular)
                {
                    dragStartX = positionX;
                    dragStartY = positionY;
                    isDrawingCircular = true;
                }
                else
                {
                    double rad = Math.Sqrt(((dragStartX - positionX) * (dragStartX - positionX)) + ((dragStartY - positionY) * (dragStartY - positionY)));
                    currentShapeId = PenWave.Instance.AddArcPath(dragStartX, dragStartY,(float) rad, positionX, positionY, false );
                    isDrawingCircular = false;
                }
            }
            else if (Ruler == RulerType.Rectangle)
            {
                currentShapeId = PenWave.Instance.AddRectanglePath(positionX, positionY, 400.0f, 400.0f, false);
                isDrawingCircular = false;
            }

            if (currentShapeId > 0)
            {
                NotifyActionStarted();
            }
        }


        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (currentShapeId > 0)
            {
                if (Ruler == RulerType.Line)
                {
                    PenWave.Instance.DrawLine(currentShapeId, positionX, positionY, touchTime);
                }
                else
                {
                    var res = PenWave.Instance.ResizeShapePath(currentShapeId, positionX, positionY);
                    if (res == ErrorShapeAddPointsType.DrawingCanceled)
                    {
                        PenWave.Instance.FinishShapePath(currentShapeId);
                    }
                }
            }
        }

        private void EndDrawing()
        {
            if (currentShapeId > 0)
            {
                if (Ruler == RulerType.Line)
                {
                    PenWave.Instance.EndLineDraw(currentShapeId, 0);
                }
                else
                {
                    PenWave.Instance.FinishShapePath(currentShapeId);
                }
                currentShapeId = 0;
                NotifyActionFinished();
            }
        }

        /// <summary>
        /// Handles input from the user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            return false;
        }

    }
}

