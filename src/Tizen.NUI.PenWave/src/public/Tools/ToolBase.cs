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
            Canvas,
        }

        public abstract ToolBase.ToolType Type { get; }
        public event Action<ToolType> ToolSelected;

        protected bool Active {get; private set; }
        protected List<Icon> Icons { get; } = new List<Icon>();

        protected PopupManager PopupManager { get; private set; }

        public void SetPopupManager(PopupManager popupManager)
        {
            PopupManager = popupManager;
        }

        protected virtual void OnIconSelected(object sender) => ToolSelected?.Invoke(Type);

        public void Activate()
        {
            Active = true;
            OnActivated();
        }

        public void Deactivate()
        {
            Active = false;
            OnDeactivate();
        }

        protected virtual void OnActivated()
        {

        }

        protected virtual void OnDeactivate()
        {
            EndDrawing();
        }

        public virtual void HandleInput(Touch touch)
        {
            if (!Active || touch == null || touch.GetPointCount() == 0) return;

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

        public virtual View GetUI()
        {
            var view = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };
            foreach (var icon in Icons)
            {
                icon.IconSelected += OnIconSelected;
                view.Add(icon);
            }
            return view;
        }

        protected void AddIcon(Icon icon) => Icons.Add(icon);

        protected abstract void StartDrawing(Vector2 position, uint touchTime);
        protected abstract void ContinueDrawing(Vector2 position, uint touchTime);
        protected abstract void EndDrawing();

    }
}