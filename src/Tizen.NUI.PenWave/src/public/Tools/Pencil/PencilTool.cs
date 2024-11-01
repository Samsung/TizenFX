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
    public class PencilTool : ToolBase
    {
        public override ToolBase.ToolType Type => ToolBase.ToolType.Pencil;
        private PenInk ink;
        private uint mCurrentShapeId;
        private bool mIsDrawing = false;


        public PencilTool()
        {
            ink = new PenInk();
        }

        public PencilTool(PenInk penInk)
        {
            ink = penInk ?? new PenInk();
        }

        protected override void StartDrawing(Vector2 position, uint touchTime)
        {
            mCurrentShapeId = PWEngine.BeginShapeDraw(position.X, position.Y, touchTime);
        }

        protected override void ContinueDrawing(Vector2 position, uint touchTime)
        {
            if (mCurrentShapeId > 0)
            {
                var result = (ErrorShapeAddPointsType)PWEngine.DrawShape(mCurrentShapeId, position.X, position.Y, touchTime);
                if (result == ErrorShapeAddPointsType.overflowShape)
                {
                    EndDrawing();
                    StartDrawing(position, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.drawingCanceled)
                {
                    EndDrawing();
                }
            }
        }

        protected override void EndDrawing()
        {
            PWEngine.EndShapeDraw(mCurrentShapeId, 0);
            mCurrentShapeId = 0;
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

            AddIconsToView(rootView, ink.BrushTypes, brushType => new BrushIcon(brushType));
            AddIconsToView(rootView, ink.Sizes, size => new SizeIcon(size));
            AddIconsToView(rootView, ink.Colors, color => new ColorIcon(color));
            return rootView;
        }

        private void AddIconsToView<T>(View rootView, IEnumerable<T>items, Func<T, Icon> iconFactory)
        {
            var view = new View
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
            foreach (var item in items)
            {
                var icon = iconFactory(item);
                view.Add(icon);
                icon.IconSelected += OnIconSelected;
            }
            rootView.Add(view);
        }
    }

    public enum ErrorShapeAddPointsType
    {
        noError,
        overflowShape,
        noCanvasSet,
        noShapesInCanvas,
        badIdShape,
        drawableIsNotAShape,
        drawableIsNotALine,
        drawingCanceled
    }
}