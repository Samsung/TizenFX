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
        private string[] mBrushColors = {
            "#F7B32C",
            "#FD5703",
            "#DA1727",
            "#FF00A8",
            "#74BFB8",
            "#4087C5",
            "#070044",
            "#0E0E0E"
        };

        private float[] mBrushSize = {
            3.0f,
            6.5f,
            12.0f
        };

        public PencilTool()
        {
            List<Color> colorList = new List<Color>();
            foreach (var item in mBrushColors)
            {
                colorList.Add(new Tizen.NUI.Color(item));
            }
            List<float> sizeList = new List<float>();

            foreach (var item in mBrushSize)
            {
                sizeList.Add(item);
            }
            ink = new PenInk(colorList, sizeList);
        }

        public PencilTool(PenInk penInk) : base()
        {
            ink = penInk;
        }

        public bool Activate
        {
            get
            {
                return mActivate;
            }
            set
            {
                mActivate = value;
                if (mActivate == false && mIsDrawing == true)
                {
                    PWEngine.EndShapeDraw(mCurrentShapeId, mTouchTime);
                    mIsDrawing = false;
                }
            }
        }

        public void HandleInput(Touch touch)
        {
            if (mActivate == false)
            {
                return;
            }

            uint count = touch == null ? 0 : touch.GetPointCount();
            if (count == 0)
            {
                return;
            }

            List<Vector2> touchPositionList = new List<Vector2>();
            uint pointStateIndex = 0;
            mTouchTime = touch.GetTime();

            for (uint i = 0; i < count; ++i)
            {
                // 멀티 드로잉일 경우 고려할 것
                // if (AppModel.MultidrawActive && args.Touch.GetState(i) != PointStateType.Stationary)
                // {
                //     pointStateIndex = i;
                // }
                touchPositionList.Add(touch.GetLocalPosition(i));
            }

            if (count == 1)
            {
                switch (touch.GetState(pointStateIndex))
                {
                    case PointStateType.Down:
                    {
                        PointStateDown(touchPositionList[(int)pointStateIndex], touch.GetTime());
                        break;
                    }
                    case PointStateType.Motion:
                    {
                        PointStateMotion(touchPositionList[(int)pointStateIndex], (int)pointStateIndex, touch.GetTime());
                        break;
                    }
                    case PointStateType.Up:
                    case PointStateType.Leave:
                    default :
                    {
                        PointStateUp(touchPositionList[(int)pointStateIndex], touch.GetTime());
                        break;
                    }
                }
            }
        }

        private void PointStateDown(Vector2 touchPosition, uint touchTime)
        {
            if (mIsDrawing == false)
            {
                mIsDrawing = true;
                mCurrentShapeId = PWEngine.BeginShapeDraw(touchPosition.X, touchPosition.Y, touchTime);
            }
        }

        private void PointStateUp(Vector2 touchPosition, uint touchTime)
        {
            if (mIsDrawing == true)
            {
                PWEngine.EndShapeDraw(mCurrentShapeId, touchTime);
            }
            mIsDrawing = false;
        }

        private void PointStateMotion(Vector2 touchPosition, int index, uint touchTime)
        {
            if (mIsDrawing == true)
            {
                ErrorShapeAddPointsType result = (ErrorShapeAddPointsType)PWEngine.DrawShape(mCurrentShapeId, touchPosition.X, touchPosition.Y, touchTime);
                if (result == ErrorShapeAddPointsType.overflowShape)
                {
                    //End old shape
                    PWEngine.EndShapeDraw(mCurrentShapeId, touchTime);

                    //Create new shape
                    mCurrentShapeId = PWEngine.BeginShapeDraw(touchPosition.X, touchPosition.Y, touchTime);
                    PWEngine.DrawShape(mCurrentShapeId, touchPosition.X, touchPosition.Y, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.drawingCanceled)
                {
                    PWEngine.EndShapeDraw(mCurrentShapeId, touchTime);
                    mIsDrawing = false;
                }
            }
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

            var viewBrushColors = CreateView();
            foreach (var item in ink.GetColors())
            {
                ColorIcon i = new ColorIcon(item);
                viewBrushColors.Add(i);
            }
            mRootView.Add(viewBrushColors);

            var viewBrushSize = CreateView();
            foreach (var item in ink.GetSizes())
            {
                Icon i = new SizeIcon(item);
                viewBrushSize.Add(i);
            }
            mRootView.Add(viewBrushSize);

            var viewBrushType = CreateView();
            foreach (var item in ink.GetBrushTypes())
            {
                Icon i = new BrushIcon(item);
                viewBrushType.Add(i);
            }
            mRootView.Add(viewBrushType);
        }

        public virtual View GetUI()
        {
            CreateUI();
            return mRootView;
        }

        protected View CreateView()
        {
            var row = new View()
            {
                Layout = new GridLayout()
                {
                    Columns = 4,
                    ColumnSpacing = 8,
                    RowSpacing = 8,
                    Padding = new Extents(0, 0, 0, 0)
                },
            };

            return row;
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