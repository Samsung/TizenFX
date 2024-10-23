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
        enum SelectMode
        {
            Resize,
            Move,
            None
        }

        enum DrawableType
        {
            None,  //nothing found/selected
            Multi, //more than one drawable selected
            Shape,
            Chart,
            Picture,
            Text
        }

        private bool isTouchedInsideSelectedArea = false;
        private SelectMode mode = SelectMode.None;
        private DrawableType drawableType = DrawableType.None;

        public void Activate()
        {
        }

        public void Deactivate()
        {
            mode = SelectMode.None;
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
                drawableType = (DrawableType)PWEngine.SelectDrawable(position.X, position.Y);
            }
        }

        private void ContinueDrawing(Vector2 position, uint touchTime)
        {
            if (drawableType == DrawableType.None)
            {
                if (mode == SelectMode.None)
                {
                    PWEngine.StartSelectingArea(position.X, position.Y);
                }
                PWEngine.ResizeSelectedArea(position.X, position.Y);
                mode = SelectMode.Resize;
            }
            else if (isTouchedInsideSelectedArea || drawableType != DrawableType.None)
            {
                PWEngine.DragSelectedDrawables(position.X, position.Y);
                mode = SelectMode.Move;
            }
        }

        private void EndDrawing()
        {
            switch (mode)
            {
                case SelectMode.Move :
                    PWEngine.EndDraging();
                    break;
                case SelectMode.Resize :
                    drawableType = (DrawableType)PWEngine.SelectDrawables();
                    break;
                default :
                    PWEngine.DropSelectedDrawables();
                    break;
            }
            isTouchedInsideSelectedArea = false;
            mode = SelectMode.None;
        }

    }
}


