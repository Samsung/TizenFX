// /*
//  * Copyright(c) 2024 Samsung Electronics Co., Ltd.
//  *
//  * Licensed under the Apache License, Version 2.0 (the "License");
//  * you may not use this file except in compliance with the License.
//  * You may obtain a copy of the License at
//  *
//  * http://www.apache.org/licenses/LICENSE-2.0
//  *
//  * Unless required by applicable law or agreed to in writing, software
//  * distributed under the License is distributed on an "AS IS" BASIS,
//  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  * See the License for the specific language governing permissions and
//  * limitations under the License.
//  *
//  */

// using System;
// using System.ComponentModel;
// using System.Collections.Generic;
// using Tizen.NUI;
// using Tizen.NUI.BaseComponents;

// namespace Tizen.NUI.PenWave
// {
//     public class ToolManager
//     {
//         public Dictionary<PenWaveToolType, ToolBase> Tools { get; } = new();
//         private ToolBase currentTool;

//         public ToolManager() {}

//         public void RegisterTool(ToolBase tool)
//         {
//             if (Tools.ContainsKey(tool.Type))
//             {
//                 Tizen.Log.Error("NUI", $"Already registered tool type {tool.Type}\n");
//             }
//             else
//             {
//                 Tools.Add(tool.Type, tool);
//                 tool.ToolSelected += OnToolSelected;
//             }
//         }

//         public void UnregisterTool(ToolBase tool)
//         {
//             Tools.Remove(tool.Type);
//         }

//         public void SelectTool(PenWaveToolType toolType)
//         {
//             currentTool?.Deactivate();
//             if (Tools.TryGetValue(toolType, out currentTool))
//             {
//                 currentTool.Activate();
//                 // EventBus.Publish("ToolChanged", toolType);
//             }
//         }

//         public void HandleInput(Touch touch)
//         {
//             currentTool?.HandleInput(touch);
//         }

//         private void OnToolSelected(PenWaveToolType toolType)
//         {
//             Tizen.Log.Info("NUI", $"OnToolSelected {toolType}\n");
//             SelectTool(toolType);
//         }

//         public PenWaveToolType GetCurrentToolType() => currentTool?.Type ?? PenWaveToolType.Pencil;
//     }
// }