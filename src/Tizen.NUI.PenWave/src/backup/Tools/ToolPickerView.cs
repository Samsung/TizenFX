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
//     public class ToolPickerView : View
//     {
//         private ToolManager _toolManager;
//         private Dictionary<PenWaveToolType, View> _toolUIs;
//         private PopupManager _popupManager;

//         public ToolPickerView(PWCanvasView canvasView)
//         {
//             _toolManager = canvasView.ToolManager;
//             EventBus.Subscribe("ToolChanged", OnToolChanged);
//             _toolUIs = new Dictionary<PenWaveToolType, View>();

//             InitializeUI();
//         }

//         private void InitializeUI()
//         {
//             WidthResizePolicy = ResizePolicyType.FillToParent;
//             HeightResizePolicy = ResizePolicyType.FillToParent;

//             var rootView = new View
//             {
//                 WidthResizePolicy = ResizePolicyType.FillToParent,
//                 HeightResizePolicy = ResizePolicyType.FillToParent,
//                 Layout = new LinearLayout()
//                 {
//                     HorizontalAlignment = HorizontalAlignment.Center,
//                     VerticalAlignment = VerticalAlignment.Top,
//                     LinearOrientation = LinearLayout.Orientation.Vertical,
//                 }
//             };

//             var pickerView = new View
//             {
//                 CornerRadius = new Vector4(10, 10, 10, 10),
//                 BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/menu_bg.png",
//                 WidthSpecification = LayoutParamPolicies.WrapContent,
//                 HeightSpecification = LayoutParamPolicies.WrapContent,
//                 Layout = new LinearLayout
//                 {
//                     VerticalAlignment = VerticalAlignment.Center,
//                     HorizontalAlignment = HorizontalAlignment.Center
//                 },
//             };

//             var popupView = new View
//             {
//                 WidthSpecification = LayoutParamPolicies.WrapContent,
//                 HeightSpecification = LayoutParamPolicies.WrapContent,
//                 Layout = new LinearLayout
//                 {
//                     VerticalAlignment = VerticalAlignment.Center,
//                     HorizontalAlignment = HorizontalAlignment.Center
//                 }
//             };

//             _popupManager = new PopupManager(popupView);

//             foreach (var tool in _toolManager.Tools)
//             {
//                 tool.Value.SetPopupManager(_popupManager);
//                 var toolUI = tool.Value.GetUI();
//                 if (_toolUIs.TryAdd(tool.Key, toolUI))
//                 {
//                     pickerView.Add(toolUI);
//                 }
//             }
//             rootView.Add(pickerView);
//             Add(rootView);
//             Add(popupView);

//             TouchEvent += OnTouchEvent;
//         }

//         private bool OnTouchEvent(object sender, View.TouchEventArgs args)
//         {
//             IconStateManager.Instance.CurrentPressedIcon = null;
//             _popupManager.HidePopup();
//             return false;
//         }

//         public void ShowPopup(View contentView, Position2D position)
//         {
//             _popupManager.ShowPopup(contentView, position);
//         }

//         public void HidePopup()
//         {
//             _popupManager.HidePopup();
//         }


//         private void OnToolChanged(object toolType)
//         {
//             Tizen.Log.Info("NUI", $"OnToolChanged {toolType}\n");
//             _popupManager.HidePopup();
//         }


//         public void ShowTool(PenWaveToolType type)
//         {
//             if (_toolUIs.TryGetValue(type, out var toolView))
//             {
//                 Add(toolView);
//             }
//         }

//         public void HideTool(PenWaveToolType type)
//         {
//             if (_toolUIs.TryGetValue(type, out var toolView))
//             {
//                 Remove(toolView);
//             }
//         }

//         public void CustomizeToolUI(PenWaveToolType toolType, View customUI)
//         {
//             HideTool(toolType);
//             if (_toolUIs.TryAdd(toolType, customUI))
//             {
//                 Add(customUI);
//             }
//         }
//     }
// }
