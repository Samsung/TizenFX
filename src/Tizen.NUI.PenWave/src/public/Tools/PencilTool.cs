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

        public PencilTool(Color color, float thickness)
        {
            ink = new PenInk(color, thickness);
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
                    Interop.ExtRenderer.EndShapeDraw(mCurrentShapeId, mTouchTime);
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
                mCurrentShapeId = Interop.ExtRenderer.BeginShapeDraw(touchPosition.X, touchPosition.Y, touchTime);
            }
        }

        private void PointStateUp(Vector2 touchPosition, uint touchTime)
        {
            if (mIsDrawing == true)
            {
                Interop.ExtRenderer.EndShapeDraw(mCurrentShapeId, touchTime);
            }
            mIsDrawing = false;
        }

        private void PointStateMotion(Vector2 touchPosition, int index, uint touchTime)
        {
            if (mIsDrawing == true)
            {
                ErrorShapeAddPointsType result = (ErrorShapeAddPointsType)Interop.ExtRenderer.DrawShape(mCurrentShapeId, touchPosition.X, touchPosition.Y, touchTime);
                if (result == ErrorShapeAddPointsType.overflowShape)
                {
                    //End old shape
                    Interop.ExtRenderer.EndShapeDraw(mCurrentShapeId, touchTime);

                    //Create new shape
                    mCurrentShapeId = Interop.ExtRenderer.BeginShapeDraw(touchPosition.X, touchPosition.Y, touchTime);
                    Interop.ExtRenderer.DrawShape(mCurrentShapeId, touchPosition.X, touchPosition.Y, touchTime);
                }
                else if (result == ErrorShapeAddPointsType.drawingCanceled)
                {
                    Interop.ExtRenderer.EndShapeDraw(mCurrentShapeId, touchTime);
                    mIsDrawing = false;
                }
            }
        }

        public static string[] mBrushColors = {
            "#F7B32C",
            "#FD5703",
            "#DA1727",
            "#FF00A8",
            "#74BFB8",
            "#4087C5",
            "#070044",
            "#0E0E0E"
        };
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