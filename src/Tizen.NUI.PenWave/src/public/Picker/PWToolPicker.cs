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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.PenWave
{
    public class PWToolPicker : View
    {
        private static readonly string ResourcePath = FrameworkInformation.ResourcePath + "images/light/";

        // 도구별 아이콘 및 색상 매핑
        private static readonly Dictionary<PencilTool.BrushType, string> BrushIconMap = new Dictionary<PencilTool.BrushType, string>
        {
            { PencilTool.BrushType.Stroke, "icon_pencil.png" },
            { PencilTool.BrushType.VarStroke, "icon_varstroke_dec.png" },
            { PencilTool.BrushType.VarStrokeInc, "icon_varstroke_inc.png" },
            { PencilTool.BrushType.SprayBrush, "icon_spray.png" },
            { PencilTool.BrushType.DotBrush, "icon_dot.png" },
            { PencilTool.BrushType.DashedLine, "icon_dashed_line.png" },
            { PencilTool.BrushType.Highlighter, "icon_highlighter.png" },
            { PencilTool.BrushType.SoftBrush, "icon_soft_brush.png" },
            { PencilTool.BrushType.SharpBrush, "icon_sharp_brush.png" },
        };

        private static readonly List<Color> BrushColorMap = new List<Color>
        {
            new Color("#F7B32C"), new Color("#FD5703"), new Color("#DA1727"),
            new Color("#FF00A8"), new Color("#74BFB8"), new Color("#4087C5"),
            new Color("#070044"), new Color("#0E0E0E")
        };

        private static readonly Dictionary<EraserTool.EraserType, string> EraserIconMap = new Dictionary<EraserTool.EraserType, string>
        {
            { EraserTool.EraserType.Partial, "icon_eraser.png" },
            { EraserTool.EraserType.Full, "icon_full_eraser.png" },
        };


        private static readonly List<Color> CanvasColor = new List<Color>
        {
            new Color("#F0F0F0"), new Color("#B7B7B7"), new Color("#E3F2FF"),
            new Color("#202022"), new Color("#515151"), new Color("#17234D"),
        };

        private static readonly Dictionary<GridDensityType, string> GridIconMap = new Dictionary<GridDensityType, string>
        {
            { GridDensityType.Small, "icon_small_grid_density.png" },
            { GridDensityType.Medium, "icon_medium_grid_density.png" },
            { GridDensityType.Large, "icon_large_grid_density.png" },
        };

        private readonly PWCanvasView canvasView;
        private readonly Dictionary<Type, ToolBase> tools;

        private View rootView;
        private ImageView selectedButton;
        private ImageView undoButton;
        private ImageView redoButton;

        // UI 상태 색상 정의
        private const string IconStateNormalColor = "#17234d";
        private const string IconStateSelectedColor = "#FF6200";
        private const string IconStateDisabledColor = "#CACACA";


        public View PickerView { get; private set; }
        public View PopupView { get; private set; }
        public event Action<ToolBase> ToolChanged;

        public PWToolPicker(PWCanvasView canvasView)
        {
            this.canvasView = canvasView;
            tools = new Dictionary<Type, ToolBase>();

            canvasView.ActionFinished += OnFinished;
        }

        private void OnFinished(object sender, EventArgs e)
        {
            UpdateUI();
        }

        public void Initialize()
        {
            InitializeUI();
            InitializeCanvasTools();
            InitializeTools();
            UpdateUI();
        }

        private void InitializeUI()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;

            // Root View 구성
            rootView = new View
            {
                Layout = new LinearLayout
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            // Picker View 구성
            PickerView = new View
            {
                CornerRadius = new Vector4(10, 10, 10, 10),
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                BackgroundImage = ResourcePath + "menu_bg.png",
            };
            PickerView.TouchEvent += (s, e) => { return true; }; // Prevent touch events from propagating to the canvas view

            // Popup View 구성
            PopupView = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                BackgroundImage = ResourcePath + "canvas_popup_bg.png",
                Padding = new Extents(20, 20, 20, 20),
            };
            PopupView.Hide();
            PopupView.TouchEvent += (s, e) => { return true; }; // Prevent touch events from propagating to the canvas view
            canvasView.TouchEvent += (s, e) => { ClearPopupView(); return false; }; // Hide popup when touching outside it

            rootView.Add(PickerView);
            rootView.Add(PopupView);
            Add(rootView);
            canvasView.Add(this);
        }

        private void InitializeCanvasTools()
        {
            var backgroundColorButton = CreateToolButton(ResourcePath + "icon_color_palette.png", () =>
            {
              ShowPaletteSetting();
            });
            PickerView.Add(backgroundColorButton);

            var gridButton = CreateToolButton(ResourcePath + "icon_medium_grid_density.png", () =>
            {
              ShowGridSetting();
            });
            PickerView.Add(gridButton);

            undoButton = CreateToolButton(ResourcePath + "icon_undo.png", () =>
            {
                canvasView.Undo();
                UpdateUI();
            });
            PickerView.Add(undoButton);

            redoButton = CreateToolButton(ResourcePath + "icon_redo.png", () =>
            {
                canvasView.Redo();
                UpdateUI();
            });
            PickerView.Add(redoButton);

            var clearButton = CreateToolButton(ResourcePath + "icon_clear.png", () =>
            {
                canvasView.ClearCanvas();
                UpdateUI();
            });
            PickerView.Add(clearButton);
        }

        private void ShowPaletteSetting()
        {
            ClearPopupView();

            PopupView.Show();

            var colorPicker = new View
            {
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };

            foreach (var color in CanvasColor)
            {
                var button = new ImageView
                {
                    Size2D = new Size2D(48, 48),
                    Color = color,
                    ResourceUrl = ResourcePath + "/color_icon_base.png",
                };
                button.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        canvasView.SetCanvasColor(color);
                    }
                    return true;
                };

                colorPicker.Add(button);
            }

            PopupView.Add(colorPicker);
        }

        private void ShowGridSetting()
        {
            ClearPopupView();

            PopupView.Show();

             var gridPicker = new View
            {
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };

            foreach (var icon in GridIconMap)
            {
                var button = CreateToolButton(ResourcePath + icon.Value, () =>
                {
                    canvasView.ToggleGrid(icon.Key);
                });
                gridPicker.Add(button);
            }

            PopupView.Add(gridPicker);
        }

        private void InitializeTools()
        {
            var pencilToll = new PencilTool(PencilTool.BrushType.Stroke, Color.Black, 3.0f);
            var eraserTool = new EraserTool(EraserTool.EraserType.Partial, 48.0f);
            var selectionTool = new SelectionTool(SelectionTool.SelectionType.Move);
            AddTool(pencilToll, "icon_pencil.png");
            AddTool(eraserTool, "icon_eraser.png");
            AddTool(selectionTool, "icon_select.png");

            canvasView.Tool = pencilToll; // 기본 도구 설정
        }

        private void AddTool(ToolBase tool, string icon)
        {
            tools[tool.GetType()] = tool;

            var toolButton = CreateToolButton(ResourcePath + icon, () =>
            {
                SetTool(tool);
            });
            PickerView.Add(toolButton);

        }

        public void SetTool(ToolBase tool)
        {
            if (tools.ContainsKey(tool.GetType()))
            {
                canvasView.Tool = tool;
                ShowToolSettings(tool);
                ToolChanged?.Invoke(tool);
            }
        }

        private void ShowToolSettings(ToolBase tool)
        {
            ClearPopupView();

            if (tool is PencilTool pencilTool)
                ShowPencilToolSettings(pencilTool);
            else if (tool is EraserTool eraserTool)
                ShowEraserToolSettings(eraserTool);
            else if (tool is SelectionTool selectionTool)
                ShowSelectionToolSettings(selectionTool);

            PopupView.Show();
        }

        private void ShowPencilToolSettings(PencilTool pencilTool)
        {
            AddBrushPicker(pencilTool);
            AddColorPicker(pencilTool);
            AddSizeSlider(pencilTool);
        }

        private void ShowEraserToolSettings(EraserTool eraserTool)
        {
            AddEraserTypePicker(eraserTool);
            AddSizeSlider(eraserTool);
        }

        private void ShowSelectionToolSettings(SelectionTool selectionTool)
        {
            AddSelectionTypePicker(selectionTool);
        }

        private void AddBrushPicker(PencilTool pencilTool)
        {
            var brushPicker = new View
            {
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };

            foreach (var icon in BrushIconMap)
            {
                var button = CreateToolButton(ResourcePath + icon.Value, () =>
                {
                    pencilTool.Brush = icon.Key;
                    pencilTool.Activate();
                });
                brushPicker.Add(button);
            }

            PopupView.Add(brushPicker);
        }

        private void AddColorPicker(PencilTool pencilTool)
        {
            var colorPicker = new View
            {
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };

            foreach (var color in BrushColorMap)
            {
                var button = new ImageView
                {
                    Size2D = new Size2D(48, 48),
                    Color = color,
                    ResourceUrl = ResourcePath + "/color_icon_base.png",
                };
                button.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        pencilTool.BrushColor = color;
                        pencilTool.Activate();
                    }
                    return true;
                };

                colorPicker.Add(button);
            }

            PopupView.Add(colorPicker);
        }

        private void AddSizeSlider(ToolBase tool)
        {

            var slider = new Slider
            {
                WidthSpecification = 300
            };
            if (tool is PencilTool pencilTool)
            {
                slider.MinValue = 1;
                slider.MaxValue = 20;
                slider.CurrentValue = pencilTool.BrushSize;
            }
            else if (tool is EraserTool eraserTool)
            {
                slider.MinValue = 10;
                slider.MaxValue = 100;
                slider.CurrentValue = eraserTool.EraserRadius;
            }

            slider.ValueChanged += (s, e) =>
            {
                if (tool is PencilTool pencilTool)
                {
                    pencilTool.BrushSize = e.CurrentValue;
                }
                else if (tool is EraserTool eraserTool)
                {
                    eraserTool.EraserRadius = e.CurrentValue;
                }

                tool.Activate();
            };

            PopupView.Add(slider);
        }

        private void AddEraserTypePicker(EraserTool eraserTool)
        {
            var eraserPicker = new View
            {
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };

            foreach (var icon in EraserIconMap)
            {
                var button = CreateToolButton(ResourcePath + icon.Value, () =>
                {
                    eraserTool.Eraser = eraserTool.Eraser == EraserTool.EraserType.Partial
                        ? EraserTool.EraserType.Full
                        : EraserTool.EraserType.Partial;
                    eraserTool.Activate();
                });
                eraserPicker.Add(button);
            }
            PopupView.Add(eraserPicker);
        }

        private void AddSelectionTypePicker(SelectionTool selectionTool)
        {
            var picker = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal
                }
            };

            var types = Enum.GetValues(typeof(SelectionTool.SelectionType));
            foreach (SelectionTool.SelectionType type in types)
            {
                var button = CreateToolButton(ResourcePath + $"icon_{type.ToString().ToLower()}.png", () =>
                {
                    selectionTool.Selection = type;
                });
                picker.Add(button);
            }

            PopupView.Add(picker);
        }

        public ImageView CreateToolButton(string iconPath, Action OnClick)
        {
            var button = new ImageView
            {
                Size2D = new Size2D(48, 48),
                ResourceUrl = iconPath,
                Color = new Color(IconStateNormalColor),
            };

            button.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    if (selectedButton != null)
                    {
                        selectedButton.Color = new Color(IconStateNormalColor);
                    }
                    selectedButton = button;
                    button.Color = new Color(IconStateSelectedColor);
                    OnClick?.Invoke();
                }
                return true;
            };

            return button;
        }

        private void UpdateUI()
        {
            ClearPopupView();
            // Update undo/redo buttons state and colors
            if (undoButton != null)
            {
                undoButton.Color = canvasView.CanUndo ? new Color(IconStateNormalColor) : new Color(IconStateDisabledColor);
            }

            if (redoButton != null)
            {
                redoButton.Color = canvasView.CanRedo ? new Color(IconStateNormalColor) : new Color(IconStateDisabledColor);
            }

        }

        public void ClearPopupView()
        {
            int childNum = (int)PopupView.ChildCount;
            for (int i = childNum - 1; i >= 0; i--)
            {
                PopupView.Remove(PopupView.GetChildAt((uint)i));
            }
            PopupView.Hide();
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed) return;
            canvasView.ActionFinished -= OnFinished;;
            base.Dispose(type);
        }
    }
}
