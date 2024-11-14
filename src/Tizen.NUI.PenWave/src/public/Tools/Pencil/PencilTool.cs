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
        public enum BrushType
        {
            Stroke  = 0,
            VarStroke,
            DotBrush,
            SprayBrush,
            DashedLine,
            Highlighter,
            VarStrokeInc,
            SoftBrush,
            SharpBrush
        }

        private enum ErrorShapeAddPointsType
        {
            NoError,
            OverflowShape,
            NoCanvasSet,
            NoShapesInCanvas,
            BadIdShape,
            DrawableIsNotAShape,
            DrawableIsNotALine,
            DrawingCanceled
        }

        private uint currentShapeId;

        public PencilTool(BrushType brushType, Color color, float size)
        {
            Brush = brushType;
            BrushColor = color;
            BrushSize = size;
        }

        public BrushType Brush { get; set; }

        public Color BrushColor { get; set; }

        public float BrushSize { get; set; }

        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        private void SetBrushType(BrushType brushType)
        {
            var brushStragety = BrushStrategyFactory.Instance.GetBrushStrategy(brushType);
            if (brushStragety!= null)
            {
                brushStragety.ApplyBrushSettings();
            }
        }

        public override void Activate()
        {
            SetBrushType(Brush);
            PWEngine.SetStrokeColor(ToHex(BrushColor), 1.0f);
            PWEngine.SetStrokeSize(BrushSize);
        }

        public override void Deactivate()
        {
            EndDrawing();
        }

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
                    var command = new Command(() => EndDrawing());
                    unredoManager.Execute(command);
                    EndDrawing();
                    break;
            }
        }

        private  void StartDrawing(Vector2 position, uint touchTime)
        {
            currentShapeId = PWEngine.BeginShapeDraw(position.X, position.Y, touchTime);
            NotifyActionStarted();
        }

        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            if (currentShapeId > 0)
            {
                var result = (ErrorShapeAddPointsType)PWEngine.DrawShape(currentShapeId, position.X, position.Y, touchTime);
                if (result == ErrorShapeAddPointsType.OverflowShape)
                {
                    EndDrawing();
                    StartDrawing(position, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.DrawingCanceled)
                {
                    EndDrawing();
                }
            }
        }

        private void EndDrawing()
        {
            PWEngine.EndShapeDraw(currentShapeId, 0);
            currentShapeId = 0;
            NotifyActionFinished();
        }

    }
}

