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
    public class PencilTool : ToolBase
    {
        public override PWToolType Type => PWToolType.Pencil;

        private enum ErrorShapeAddPointsType
        {
            noError,
            overflowShape,
            noCanvasSet,
            noShapesInCanvas,
            badIdShape,
            drawableIsNotAShape,
            drawableIsNotALine,
            drawingCanceled
        }

        private PWBrushType currentBrushType;
        private Color currentColor;
        private float currentSize;
        private uint currentShapeId;

        public PWBrushType BrushType
        {
            get => currentBrushType;
            set
            {
                currentBrushType = value;
                SetBrushType(currentBrushType);
            }
        }

        public Color BrushColor
        {
            get => currentColor;
            set
            {
                currentColor = value;
                PWEngine.SetStrokeColor(ToHex(currentColor), 1.0f);
            }
        }

        public float BrushSize
        {
            get => currentSize;
            set
            {
                currentSize = value;
                PWEngine.SetStrokeSize(currentSize);
            }
        }

        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        private void SetBrushType(PWBrushType brushType)
        {
            var brushStragety = BrushStrategyFactory.Instance.GetBrushStrategy(brushType);
            if (brushStragety!= null)
            {
                brushStragety.ApplyBrushSettings();
            }
        }

        public override void Activate()
        {

        }

        public override void Deactivate()
        {
            EndDrawing();
        }

        public override void HandleInput(Touch touch)
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
                    EndDrawing();
                    break;
            }
        }

        private  void StartDrawing(Vector2 position, uint touchTime)
        {
            currentShapeId = PWEngine.BeginShapeDraw(position.X, position.Y, touchTime);
        }

        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            if (currentShapeId > 0)
            {
                var result = (ErrorShapeAddPointsType)PWEngine.DrawShape(currentShapeId, position.X, position.Y, touchTime);
                if (result == ErrorShapeAddPointsType.overflowShape)
                {
                    EndDrawing();
                    StartDrawing(position, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.drawingCanceled)
                {
                    EndDrawing();
                }
            }
        }

        private void EndDrawing()
        {
            PWEngine.EndShapeDraw(currentShapeId, 0);
            currentShapeId = 0;
        }

    }
}

