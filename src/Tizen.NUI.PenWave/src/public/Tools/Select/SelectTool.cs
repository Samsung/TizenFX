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
    public class SelectTool : ToolBase
    {
        enum Mode
        {
            Resize,
            Move,
            None
        }

        public override ToolBase.ToolType Type => ToolBase.ToolType.Select;
        private bool isTouchedInsideSelectedArea = false;
        private Mode mode = Mode.None;

        public SelectTool()
        {
            AddIcon(new SelectIcon());
        }

         protected override void StartDrawing(Vector2 position, uint touchTime)
         {
            isTouchedInsideSelectedArea = PWEngine.InsideSelectedArea(position.X, position.Y);
            if (!isTouchedInsideSelectedArea)
            {
                PWEngine.DropSelectedDrawables();
                PWEngine.SelectDrawable(position.X, position.Y);
                PWEngine.StartSelectingArea(position.X, position.Y);
            }
         }

        protected override void ContinueDrawing(Vector2 position, uint touchTime)
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

        protected override void EndDrawing()
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

        protected override void OnDeactivate()
        {
            mode = Mode.None;
            base.OnDeactivate();
        }
    }
}
