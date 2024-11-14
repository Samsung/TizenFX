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
    public class EraserTool : ToolBase
    {
        public enum EraserType
        {
            Partial = 0,
            Full,
        }

        public EraserTool(EraserType eraserType, float radius)
        {
            Eraser = eraserType;
            EraserRadius = radius; // default value is 48.0f;  // TODO: need to check the range of radius. 0.0f ~ 100.0f? or more?
        }

        public EraserType Eraser { get; set; }

        public float EraserRadius { get; set; }

        public override void Activate()
        {

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
                    break;
            }
        }

        private  void StartDrawing(Vector2 position, uint touchTime)
        {
            PWEngine.EraseShape((int)position.X, (int)position.Y, EraserRadius, (Eraser == EraserType.Partial));
        }

        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            PWEngine.EraseShape((int)position.X, (int)position.Y, EraserRadius, (Eraser == EraserType.Partial));
        }

        private void EndDrawing()
        {
            PWEngine.StopErasing();
        }

    }
}

