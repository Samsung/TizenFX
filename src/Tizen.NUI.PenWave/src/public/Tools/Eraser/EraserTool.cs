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
    /// The EraserTool class provides functionality to erase shapes from the canvas.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EraserTool : ToolBase
    {
        /// The current state of the tool.
        private bool _isActive = false;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EraserTool(EraserType eraserType, float radius)
        {
            Eraser = eraserType;
            EraserRadius = radius;
        }

        /// <summary>
        /// The type of eraser tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EraserType Eraser { get; set; }

        /// <summary>
        /// The radius of the eraser tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float EraserRadius { get; set; }

        /// <summary>
        /// Activate the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Activate()
        {
        }

        /// <summary>
        /// Deactivate the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Deactivate()
        {
            EndDrawing();
        }

        /// <summary>
        /// Handle input events.
        /// </summary>
        /// <param name="touch">The touch event data.</param>
        /// <returns>true if the event was handled, otherwise false</returns>
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

        // Start drawing at the given position.
        private  void StartDrawing(float positionX, float positionY, uint touchTime)
        {
            _isActive = true;
            PenWaveRenderer.Instance.EraseShape((int)positionX, (int)positionY, EraserRadius, (Eraser == EraserType.Partial));
            NotifyActionStarted();
        }

        // Continue drawing at the given position.
        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            PenWaveRenderer.Instance.EraseShape((int)positionX, (int)positionY, EraserRadius, (Eraser == EraserType.Partial));
        }

        // End drawing at the given position.
        private void EndDrawing()
        {
            if (_isActive)
            {
                PenWaveRenderer.Instance.StopErasing();
                NotifyActionFinished();
                _isActive = false;
            }
        }

        /// <summary>
        /// Handle input events. (Wheel)
        /// </summary>
        /// <param name="wheel">The wheel event data.</param>
        /// <returns>true if the event was handled, otherwise false</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            return false;
        }
    }
}

