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
        private View mRootView;
        private Dictionary<ToolBase.ToolType, View> mToolUIs;
        // private List<View> mCustomIcons;

        public ToolPickerView(ToolManager toolManager, View rootView = null)
        {
            this.mToolManager = toolManager;
            this.mRootView = mRootView ?? CreateDefaultRootView();
            this.Add(mRootView);
            mToolUIs = new Dictionary<ToolBase.ToolType, View>();

            InitializeUI();
        }

        private View CreateDefaultRootView()
        {
            return new View
            {
                CornerRadius = new Vector4(10, 10, 10, 10),
                BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/toolbox_bg.png",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                }
                // Layout = new GridLayout()
        //             {
        //                 Columns = 1,
        //                 RowSpacing = 4,
        //                 Padding = new Extents(16, 16, 16, 16)
        //             },
            };
        }

        private void InitializeUI()
        {
            foreach (var tool in mToolManager.Tools)
            {
                var toolUI = tool.Value.GetUI();
                if (mToolUIs.TryAdd(tool.Key, toolUI))
                {
                    mRootView.Add(toolUI);
                }
            }
        }


        public void ShowTool(ToolBase.ToolType type)
        {
            if (mToolUIs.TryGetValue(type, out var toolView))
            {
                mRootView.Add(toolView);
            }
        }

        public void HideTool(ToolBase.ToolType type)
        {
            if (mToolUIs.TryGetValue(type, out var toolView))
            {
                mRootView.Remove(toolView);
            }
        }

        public void CustomizeToolUI(ToolBase.ToolType toolType, View customUI)
        {
            HideTool(toolType);
            if (mToolUIs.TryAdd(toolType, customUI))
            {
                mRootView.Add(customUI);
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