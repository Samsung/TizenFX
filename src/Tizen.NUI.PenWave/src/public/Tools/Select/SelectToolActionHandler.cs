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
    public class SelectToolActionHandler : IToolActionHandler
    {
        enum Mode
        {
            Resize,
            Move,
            None
        }

        private bool isTouchedInsideSelectedArea = false;
        private Mode mode = Mode.None;

        public void Activate()
        {
        }

        public void Deactivate()
        {
            mode = Mode.None;
            EndDrawing();
        }

        public void HandleInput(Touch touch)
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
            isTouchedInsideSelectedArea = PWEngine.InsideSelectedArea(position.X, position.Y);
            if (!isTouchedInsideSelectedArea)
            {
                PWEngine.DropSelectedDrawables();
                PWEngine.SelectDrawable(position.X, position.Y);
                PWEngine.StartSelectingArea(position.X, position.Y);
            }
        }

        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            if (isTouchedInsideSelectedArea)
            {
                PWEngine.DragSelectedDrawables(position.X, position.Y);
                mode = Mode.Move;
            }
            else
            {
                PWEngine.ResizeSelectedArea(position.X, position.Y);
                mode = Mode.Resize;

            }
        }

        private void EndDrawing()
        {
            switch (mode)
            {
                case Mode.Move :
                    PWEngine.EndDraging();
                    break;
                case Mode.Resize :
                    PWEngine.SelectDrawables();
                    break;
                default :
                    PWEngine.DropSelectedDrawables();
                    break;
            }
            isTouchedInsideSelectedArea = false;
            mode = Mode.None;
        }

    }
}


