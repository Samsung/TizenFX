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
    /// The pencil tool allows the user to draw shapes on the canvas using a stylus or finger.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PencilTool : ToolBase
    {
        // The id of the current shape being drawn.
        private uint _currentShapeId;

        /// <summary>
        /// Creates a new instance of a PencilTool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PencilTool(BrushType brushType, Color color, float size)
        {
            Brush = brushType;
            BrushColor = color;
            BrushSize = size;
        }

        /// <summary>
        /// The type of brush used to draw.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BrushType Brush { get; set; }

        /// <summary>
        /// The color of the brush used to draw.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BrushColor { get; set; }

        /// <summary>
        /// The size of the brush used to draw.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BrushSize { get; set; }

        // Converts a color to a hex string. Used to pass colors to the native side.
        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        // Sets the brush type and applies the settings for that brush.
        private void SetBrushType(BrushType brushType)
        {
            var brushStragety = BrushStrategyFactory.Instance.GetBrushStrategy(brushType);
            if (brushStragety!= null)
            {
                brushStragety.ApplyBrushSettings();
            }
        }

        /// <summary>
        /// Activates the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Activate()
        {
            SetBrushType(Brush);
            PenWaveRenderer.Instance.SetStrokeColor(ToHex(BrushColor), 1.0f);
            PenWaveRenderer.Instance.SetStrokeSize(BrushSize);
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
                    EndDrawing();
                    break;
            }
            return true;
        }

        // Starts drawing a new shape. This will create a new shape on the canvas.
        private  void StartDrawing(float positionX, float positionY, uint touchTime)
        {
            _currentShapeId = PenWaveRenderer.Instance.BeginShapeDraw(positionX, positionY, touchTime);
            if (_currentShapeId > 0)
            {
                NotifyActionStarted();
            }
        }

        // Continues drawing the current shape.
        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (_currentShapeId > 0)
            {
                var result = PenWaveRenderer.Instance.DrawShape(_currentShapeId, positionX, positionY, touchTime);
                if (result == ErrorShapeAddPointsType.OverflowShape)
                {
                    EndDrawing();
                    StartDrawing(positionX, positionY, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.DrawingCanceled)
                {
                    EndDrawing();
                }
            }
        }

        // Ends drawing the current shape.
        private void EndDrawing()
        {
            if (_currentShapeId > 0)
            {
                PenWaveRenderer.Instance.EndShapeDraw(_currentShapeId, 0);
                _currentShapeId = 0;
                NotifyActionFinished();
            }
        }

        /// <summary>
        /// Handles input from the user.
        /// </summary>
        /// <param name="wheel">The wheel event.</param>
        /// <returns>True if the input was handled, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            return false;
        }

    }
}

