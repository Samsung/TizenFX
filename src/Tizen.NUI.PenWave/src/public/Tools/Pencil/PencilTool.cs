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
    public class PencilTool : ITool
    {
        public ITool.ToolType Type => ITool.ToolType.Pencil;
        private PenInk ink;
        private bool mIsDrawing = false;
        private uint mCurrentShapeId;
        private uint mTouchTime;
        private bool mActivate;
        private View mRootView;

        public PencilTool()
        {
            ink = new PenInk();
        }

        public PencilTool(PenInk penInk)
        {
            ink = penInk ?? new PenInk();
        }


        public bool Activate
        {
            get => mActivate;
            set
            {
                mActivate = value;
                if (!mActivate && mIsDrawing)
                {
                    EndDrawing();
                }
            }
        }

        public void HandleInput(Touch touch)
        {
            if (!mActivate || touch == null || touch.GetPointCount() == 0)
            {
                return;
            }

            uint pointStateIndex = 0;
            mTouchTime = touch.GetTime();

            List<Vector2> touchPositionList = new List<Vector2>();

            for (uint i = 0; i < touch.GetPointCount(); ++i)
            {
                // 멀티 드로잉일 경우 고려할 것
                // if (AppModel.MultidrawActive && args.Touch.GetState(i) != PointStateType.Stationary)
                // {
                //     pointStateIndex = i;
                // }
                touchPositionList.Add(touch.GetLocalPosition(i));
            }

            if (touch.GetPointCount() == 1)
            {
                Vector2 position = touchPositionList[(int)pointStateIndex];
                switch (touch.GetState(pointStateIndex))
                {
                    case PointStateType.Down:
                    {
                        PointStateDown(position, mTouchTime);
                        break;
                    }
                    case PointStateType.Motion:
                    {
                        PointStateMotion(position, (int)pointStateIndex, mTouchTime);
                        break;
                    }
                    case PointStateType.Up:
                    case PointStateType.Leave:
                    default :
                    {
                        PointStateUp(position, mTouchTime);
                        break;
                    }
                }
            }
        }

        private void PointStateDown(Vector2 position, uint touchTime)
        {
            if (!mIsDrawing)
            {
                mIsDrawing = true;
                mCurrentShapeId = PWEngine.BeginShapeDraw(position.X, position.Y, touchTime);
            }
        }

        private void PointStateUp(Vector2 position, uint touchTime)
        {
            if (mIsDrawing)
            {
                PWEngine.EndShapeDraw(mCurrentShapeId, touchTime);
                mIsDrawing = false;
            }
        }

        private void PointStateMotion(Vector2 position, int index, uint touchTime)
        {
            if (mIsDrawing)
            {
                var result = (ErrorShapeAddPointsType)PWEngine.DrawShape(mCurrentShapeId, position.X, position.Y, touchTime);
                if (result == ErrorShapeAddPointsType.overflowShape)
                {
                    //End old shape
                    PWEngine.EndShapeDraw(mCurrentShapeId, touchTime);

                    //Create new shape
                    mCurrentShapeId = PWEngine.BeginShapeDraw(position.X, position.Y, touchTime);
                    PWEngine.DrawShape(mCurrentShapeId, position.X, position.Y, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.drawingCanceled)
                {
                    EndDrawing();
                }
            }
        }

        private void EndDrawing()
        {
            PWEngine.EndShapeDraw(mCurrentShapeId, mTouchTime);
            mIsDrawing = false;
        }

        public virtual View GetUI()
        {
            if (mRootView == null)
            {
                CreateUI();
            }
            return mRootView;
        }

        private void CreateUI()
        {
            mRootView = new View()
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new GridLayout()
                {
                    Columns = 1,
                    RowSpacing = 4,
                    Padding = new Extents(16, 16, 16, 16)
                }
            };

            AddIconsToView(mRootView, ink.Colors, color => new ColorIcon(color));
            AddIconsToView(mRootView, ink.Sizes, size => new SizeIcon(size));
            AddIconsToView(mRootView, ink.BrushTypes, brushType => new BrushIcon(brushType));
        }

        private void AddIconsToView<T>(View rootView, IEnumerable<T>items, Func<T, Icon> iconFactory)
        {
            var view = CreateIconView();
            foreach (var item in items)
            {
                view.Add(iconFactory(item));
            }
            rootView.Add(view);
        }


        private View CreateIconView()
        {
            return new View
            {
                Layout = new GridLayout()
                {
                    Columns = 4,
                    ColumnSpacing = 8,
                    RowSpacing = 8,
                }
            };
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