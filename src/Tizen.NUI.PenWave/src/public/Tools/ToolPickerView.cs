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
        private View pickerView;
        private View popupView;
        private PopupManager popupManager;

        public ToolPickerView(ToolManager toolManager)
        {
            this.mToolManager = toolManager;
            EventBus.Subscribe("ToolChanged", OnToolChanged);
            mToolUIs = new Dictionary<ToolBase.ToolType, View>();

            InitializeUI();
        }

        private void InitializeUI()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;

            var rootView = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Layout = new LinearLayout()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                }
            };

            pickerView = new View
            {
                CornerRadius = new Vector4(10, 10, 10, 10),
                BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/menu_bg.png",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
            };

            popupView = new View
            {
                // CornerRadius = new Vector4(10, 10, 10, 10),
                // BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/menu_bg.png",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                }
            };

            this.popupManager = new PopupManager(popupView);

            foreach (var tool in mToolManager.Tools)
            {
                tool.Value.SetPopupManager(popupManager);
                var toolUI = tool.Value.GetUI();
                if (mToolUIs.TryAdd(tool.Key, toolUI))
                {
                    pickerView.Add(toolUI);
                }
            }
            rootView.Add(pickerView);
            this.Add(rootView);
            this.Add(popupView);

            this.TouchEvent += OnTouchEvent;
        }

        private bool OnTouchEvent(object sender, View.TouchEventArgs args)
        {
            popupManager.HidePopup();
            return false;
        }

        public void ShowPopup(View contentView)
        {
            popupManager.ShowPopup(contentView);
        }

        public void HidePopup()
        {
            popupManager.HidePopup();
        }


        private void OnToolChanged(object toolType)
        {
            // object is ToolBase.ToolType
            popupManager.HidePopup();
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
    }
}
