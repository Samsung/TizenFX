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
        public readonly Dictionary<ToolBase.ToolType, ToolBase> Tools;
        private ToolBase mCurrentTool;

        public event Action<ToolBase.ToolType> ToolChanged;

        public ToolManager()
        {
            Tools = new Dictionary<ToolBase.ToolType, ToolBase>();
        }

        public void RegisterTool(ToolBase tool)
        {
            if (Tools.ContainsKey(tool.Type))
            {
                Tizen.Log.Error("NUI", $"Already registered tool type {tool.Type}\n");
            }
            else
            {
                Tools.Add(tool.Type, tool);
                tool.ToolSelected += OnToolSelected;
            }
        }

        public void UnregisterTool(ToolBase tool)
        {
            Tools.Remove(tool.Type);
        }

        public void SelectTool(ToolBase.ToolType toolType)
        {

            if (mCurrentTool != null)
            {
                if (toolType == GetCurrentToolType())
                {
                    return;   // 선택된 툴이 현재 툴과 같다. 할 거 없다.
                }
                mCurrentTool.Activate = false;
            }

            if (Tools.TryGetValue(toolType, out mCurrentTool))
            {
                mCurrentTool.Activate = true;
                ToolChanged?.Invoke(toolType);
            }
        }

        public void HandleInput(Touch touch)
        {
            mCurrentTool?.HandleInput(touch);
        }

        public ToolBase.ToolType GetCurrentToolType() => mCurrentTool?.Type ?? ToolBase.ToolType.Pencil;

        private void OnToolSelected(ToolBase.ToolType toolType)
        {
            Tizen.Log.Info("NUI", $"OnToolSelected {toolType}\n");
            SelectTool(toolType);
        }
    }
}