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
    public class ToolPickerView : View
    {
        private ToolManager mToolManager;
        private Dictionary<ToolBase.ToolType, View> mToolUIs;
        // private List<View> mCustomIcons;

        public ToolPickerView(ToolManager toolManager)
        {
            this.mToolManager = toolManager;
            toolManager.ToolChanged += OnUpdateUI;
            mToolUIs = new Dictionary<ToolBase.ToolType, View>();

            InitializeUI();
        }

        private void InitializeUI()
        {
            CornerRadius = new Vector4(10, 10, 10, 10);
            BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/menu_bg.png";
            WidthSpecification = LayoutParamPolicies.WrapContent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
            Layout = new LinearLayout
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            foreach (var tool in mToolManager.Tools)
            {
                var toolUI = tool.Value.GetUI();
                if (mToolUIs.TryAdd(tool.Key, toolUI))
                {
                    this.Add(toolUI);
                }
            }
        }


        private void OnUpdateUI(ToolBase.ToolType toolType)
        {

        }


        public void ShowTool(ToolBase.ToolType type)
        {
            if (mToolUIs.TryGetValue(type, out var toolView))
            {
                this.Add(toolView);
            }
        }

        public void HideTool(ToolBase.ToolType type)
        {
            if (mToolUIs.TryGetValue(type, out var toolView))
            {
                this.Remove(toolView);
            }
        }

        public void CustomizeToolUI(ToolBase.ToolType toolType, View customUI)
        {
            HideTool(toolType);
            if (mToolUIs.TryAdd(toolType, customUI))
            {
                this.Add(customUI);
            }
        }

        // public void AddCustomToolIcon(View view)
        // {
        //     mRootView.Add(view);
        // }

        // public void RemoveCustomToolIcon(View view)
        // {
        //     mRootView.Remove(view);
        // }

        // private void UpdateUI()
        // {
        //     foreach (ITool tool in mToolManager.Tools.Values) {
        //         View toolView = tool.GetUI();
        //         if (mToolIcons.TryAdd(tool.Type, toolView))
        //         {
        //             mRootView.Add(toolView);
        //         }
        //     }
        // }

        // private void OnToolChanged(ToolBase.ToolType toolType, int type)
        // {
        //     // UpdateUI();
        // }


    }
}