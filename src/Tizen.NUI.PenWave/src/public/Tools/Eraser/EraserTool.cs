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
    /// The EraserTool class provides functionality to erase shapes from the canvas.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EraserTool : ToolBase
    {
        /// <summary>
        /// The type of eraser tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum EraserType
        {
            Partial = 0,
            Full,
        }

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void HandleInput(Touch touch, UnRedoManager unredoManager)
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
                    break;
            }
        }

        // Start drawing at the given position.
        private  void StartDrawing(Vector2 position, uint touchTime)
        {
            PenWave.Instance.EraseShape((int)position.X, (int)position.Y, EraserRadius, (Eraser == EraserType.Partial));
            NotifyActionStarted();
        }

        // Continue drawing at the given position.
        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            PenWave.Instance.EraseShape((int)position.X, (int)position.Y, EraserRadius, (Eraser == EraserType.Partial));
        }

        // End drawing at the given position.
        private void EndDrawing()
        {
            PenWave.Instance.StopErasing();
            NotifyActionFinished();
        }

    }
}

