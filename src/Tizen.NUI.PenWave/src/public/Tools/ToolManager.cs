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
        internal Dictionary<PWToolType, ToolBase> Tools { get; } = new();
        private ToolBase currentTool;

        public ToolManager()
        {
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
            }
        }

        public void UnregisterTool(ToolBase tool)
        {
            Tools.Remove(tool.Type);
        }

        public ToolBase GetTool(PWToolType toolType)
        {
            ToolBase tool = null;
            Tools.TryGetValue(toolType, out tool);
            return tool;
        }

        public void SelectTool(PWToolType toolType)
        {
            Tizen.Log.Error("NUI", $"SelectTool {toolType}\n");
            currentTool?.Deactivate();
            if (Tools.TryGetValue(toolType, out currentTool))
            {
                Tizen.Log.Error("NUI", $"SelectTool Activate {toolType}\n");
                currentTool.Activate();
            }
        }

        public void HandleInput(Touch touch)
        {
            currentTool?.HandleInput(touch);
        }

    }
}
