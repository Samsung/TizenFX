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
        enum Mode
        {
            Partial,
            Full
        }

        public override ToolBase.ToolType Type => ToolBase.ToolType.Eraser;
        private float radiusEraser = 48; // 지우개 사이즈 설정 가능해야 함
        private Mode mode = Mode.Partial;

        public EraserTool()
        {

        }

        protected override void StartDrawing(Vector2 position, uint touchTime)
        {
            PWEngine.EraseShape((int)position.X, (int)position.Y, radiusEraser, (mode == Mode.Partial));
        }

        protected override void ContinueDrawing(Vector2 position, uint touchTime)
        {
            PWEngine.EraseShape((int)position.X, (int)position.Y, radiusEraser, (mode == Mode.Partial));
        }

        protected override void EndDrawing()
        {
             PWEngine.StopErasing();
        }

        protected override void Deactivate()
        {
            EndDrawing();
        }

        public override View GetUI()
        {
            View rootView = new View
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
            var icon = new EraserIcon();
            rootView.Add(icon);
            icon.IconSelected += OnIconSelected;
            return rootView;
        }
    }
}
