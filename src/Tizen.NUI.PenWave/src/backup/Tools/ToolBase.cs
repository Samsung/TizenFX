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
//     public abstract class ToolBase
//     {

//         public abstract PenWaveToolType Type { get; }

//         protected IToolActionHandler ActionHandler { get; private set; }

//         public event Action<PenWaveToolType> ToolSelected;

//         // protected List<Icon> Icons { get; } = new List<Icon>();

//         // protected PopupManager PopupManager { get; private set; }

//         public ToolBase(IToolActionHandler actionHandler)
//         {
//             ActionHandler = actionHandler;
//         }

//         // public void SetPopupManager(PopupManager popupManager)
//         // {
//         //     PopupManager = popupManager;
//         // }

//         // protected virtual void OnIconSelected(object sender)
//         // {
//         //     ToolSelected?.Invoke(Type);
//         // }

//         public void Activate()
//         {
//             ActionHandler.Activate();
//         }

//         public void Deactivate()
//         {
//             ActionHandler.Deactivate();
//         }

//         public virtual void HandleInput(Touch touch)
//         {
//             ActionHandler.HandleInput(touch);
//         }

//         // public virtual View GetUI()
//         // {
//         //     var view = new View
//         //     {
//         //         Layout = new LinearLayout()
//         //         {
//         //             // HorizontalAlignment = HorizontalAlignment.Center,
//         //             // VerticalAlignment = VerticalAlignment.Center,
//         //             LinearOrientation = LinearLayout.Orientation.Horizontal,
//         //         }
//         //     };
//         //     foreach (var icon in Icons)
//         //     {
//         //         icon.IconSelected += OnIconSelected;
//         //         view.Add(icon);
//         //     }
//         //     return view;
//         // }

//         // protected void AddIcon(Icon icon) => Icons.Add(icon);
//     }
// }