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
    public class ToolManager
    {
        public Dictionary<ITool.ToolType, ITool> Tools;
        private ITool currentTool;
        private PWCanvasView canvasView;

        public event Action<ITool.ToolType, int> ToolChanged;

        public ToolManager(PWCanvasView canvasView)
        {
            Tools = new Dictionary<ITool.ToolType, ITool>();
            this.canvasView = canvasView;
        }

        public void RegisterTool(ITool tool)
        {
            if (Tools.ContainsKey(tool.Type))
            {
                Tizen.Log.Error("NUI", $"Already register tool type {tool.Type}\n");
            }
            else
            {
                Tools.Add(tool.Type, tool);
            }
        }

        public void UnregisterTool(ITool tool)
        {
            Tools.Remove(tool.Type);
        }

        public void SelectTool(ITool.ToolType toolType)
        {
            // 현재 도구 비활성화
            if (currentTool != null)
            {
                currentTool.Activate = false;
            }

            // 새 도구 활성화
            if (Tools.TryGetValue(toolType, out currentTool))
            {
                currentTool.Activate = true;
                ToolChanged?.Invoke(toolType, 0);
            }
        }

        public void HandleInput(Touch touch)
        {
            currentTool?.HandleInput(touch);
        }

        public ITool.ToolType GetCurrentToolType()
        {
            return currentTool?.Type ?? ITool.ToolType.Pencil; // 기본값 펜슬
        }

        public ITool GetCurrentTool()
        {
            return currentTool;
        }

        public PWCanvasView GetCurrentView()
        {
            return canvasView;
        }
    }
}