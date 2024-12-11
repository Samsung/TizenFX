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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CanvasTool : ToolBase
    {
        private float mInitialTouchX;
        private float mInitialTouchY;
        private bool mIsCanvasMoving = false;
        private PenWaveCanvas canvasView;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CanvasTool(PenWaveCanvas canvasView)
        {
            this.canvasView = canvasView;
        }

        /// <summary>
        /// Activates the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Activate()
        {
        }

        /// <summary>
        /// Deactivates the tool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Deactivate()
        {
            EndDrawing();
        }

        /// <summary>
        /// Handles input from the user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Touch touch)
        {
            if (touch == null || touch.GetPointCount() == 0) return false;

            uint pointStateIndex = 0;
            uint touchTime = touch.GetTime();

            List<Vector2> touchPositionList = new List<Vector2>();
            for (uint i = 0; i < touch.GetPointCount(); ++i)
            {
                touchPositionList.Add(touch.GetScreenPosition(i));
            }

            Vector2 position = touchPositionList[(int)pointStateIndex];
            if (touch.GetMouseButton(0) == MouseButton.Secondary)
            {
                mIsCanvasMoving = true;
            }
            switch (touch.GetState(pointStateIndex))
            {
                case PointStateType.Down:
                    StartDrawing(position.X, position.Y, touchTime);
                    break;
                case PointStateType.Motion:
                    ContinueDrawing(position.X, position.Y, touchTime);
                    break;
                case PointStateType.Up:
                case PointStateType.Leave:
                    EndDrawing();
                    break;
            }
            return mIsCanvasMoving;
        }

        private  void StartDrawing(float positionX, float positionY, uint touchTime)
        {
            if (mIsCanvasMoving)
            {
                mInitialTouchX = positionX;
                mInitialTouchY = positionY;
                canvasView.MoveBegin();
            }
        }

        private void ContinueDrawing(float positionX, float positionY, uint touchTime)
        {
            if (mIsCanvasMoving)
            {
                canvasView.MoveUpdate((int)(positionX - mInitialTouchX), (int)(positionY - mInitialTouchY));
            }
        }

        private void EndDrawing()
        {
            if (mIsCanvasMoving)
            {
                canvasView.MoveEnd();
                mIsCanvasMoving = false;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HandleInput(Wheel wheel)
        {
            Vector2 point = wheel.Point;
            float zoom = 1.0f - ((float)wheel.Z * 0.05f);
            canvasView.ZoomBegin();
            canvasView.ZoomUpdate(point.X, point.Y, zoom, 0, 0);
            canvasView.ZoomEnd();
            return true;
        }

    }
}

