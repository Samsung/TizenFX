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
    public abstract class ToolBase
    {

        public enum ToolType
        {
            Pencil,
            Eraser,
            Select,
            Scale,
        }

        public abstract ToolBase.ToolType Type { get; }
        public event Action<ToolType> ToolSelected;

        private bool mActivate;
        private View mRootView;

        public bool Activate
        {
            get => mActivate;
            set
            {
                mActivate = value;
                if (!mActivate)
                {
                    Deactivate();
                }
            }
        }

        protected void OnIconSelected()
        {
            ToolSelected?.Invoke(Type);
        }

        public virtual void HandleInput(Touch touch)
        {
            if (!Activate || touch == null || touch.GetPointCount() == 0) return;

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

        public abstract View GetUI();

        protected abstract void StartDrawing(Vector2 position, uint touchTime);
        protected abstract void ContinueDrawing(Vector2 position, uint touchTime);
        protected abstract void EndDrawing();
        protected abstract void Deactivate();
    }
}