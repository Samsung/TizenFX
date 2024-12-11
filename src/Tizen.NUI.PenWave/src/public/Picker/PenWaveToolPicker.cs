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
using Tizen.NUI.Components;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// PenWaveToolPicker class provides a user interface for selecting and configuring various drawing tools in the PenWave application.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PenWaveToolPicker : View
    {
        private static readonly string ResourcePath = FrameworkInformation.ResourcePath + "images/light/";

        // the icons for different brush types
        private static readonly Dictionary<BrushType, string> BrushIconMap = new Dictionary<BrushType, string>
        {
            { BrushType.Stroke, "icon_pencil.png" },
            { BrushType.VarStroke, "icon_varstroke_dec.png" },
            { BrushType.VarStrokeInc, "icon_varstroke_inc.png" },
            { BrushType.SprayBrush, "icon_spray.png" },
            { BrushType.DotBrush, "icon_dot.png" },
            { BrushType.DashedLine, "icon_dashed_line.png" },
            { BrushType.Highlighter, "icon_highlighter.png" },
            { BrushType.SoftBrush, "icon_soft_brush.png" },
            { BrushType.SharpBrush, "icon_sharp_brush.png" },
        };

        // the color palette for brushes
        private static readonly List<Color> BrushColorMap = new List<Color>
        {
            new Color("#F7B32C"), new Color("#FD5703"), new Color("#DA1727"),
            new Color("#FF00A8"), new Color("#74BFB8"), new Color("#4087C5"),
            new Color("#070044"), new Color("#0E0E0E")
        };

        // the icons for different eraser types
        private static readonly Dictionary<EraserType, string> EraserIconMap = new Dictionary<EraserType, string>
        {
            { EraserType.Partial, "icon_eraser.png" },
            { EraserType.Full, "icon_full_eraser.png" },
        };

        // the color palette for canvas background color
        private static readonly List<Color> CanvasColor = new List<Color>
        {
            new Color("#F0F0F0"), new Color("#B7B7B7"), new Color("#E3F2FF"),
            new Color("#202022"), new Color("#515151"), new Color("#17234D"),
        };

        // the icons for different grid density types
        private static readonly Dictionary<GridDensityType, string> GridIconMap = new Dictionary<GridDensityType, string>
        {
            { GridDensityType.Small, "icon_small_grid_density.png" },
            { GridDensityType.Medium, "icon_medium_grid_density.png" },
            { GridDensityType.Large, "icon_large_grid_density.png" },
        };

        private readonly PenWaveCanvas canvasView;
        private readonly Dictionary<Type, ToolBase> tools;

        private ImageView selectedButton;
        private ImageView undoButton;
        private ImageView redoButton;


        private const string IconStateNormalColor = "#17234d";
        private const string IconStateSelectedColor = "#FF6200";
        private const string IconStateDisabledColor = "#CACACA";


        /// <summary>
        /// The PickerView property. It contains the view that holds the tool buttons.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View PickerView { get; private set; }

        /// <summary>
        /// The PopupView property. It contains the view that holds the tool settings.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View PopupView { get; private set; }

        /// <summary>
        /// The ToolChanged event. It is triggered when the selected tool changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ToolChanged;

        /// <summary>
        /// Creates a new instance of PenWaveToolPicker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PenWaveToolPicker(PenWaveCanvas canvasView)
        {
            this.canvasView = canvasView;
            tools = new Dictionary<Type, ToolBase>();

            canvasView.ActionFinished += OnFinished;
            Initialize();
        }

        // Update UI when action finished. This method is called when the current action is finished.
        private void OnFinished(object sender, EventArgs e)
        {
            UpdateUI();
        }

        // Initialize the tool picker and its components.
        private void Initialize()
        {
            InitializeUI();
            InitializeCanvasTools();
            InitializeTools();
            UpdateUI();
        }

        // Initialize the UI components of the tool picker.
        private void InitializeUI()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            Layout = new LinearLayout
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                LinearOrientation = LinearLayout.Orientation.Vertical,
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

            Add(PickerView);
            Add(PopupView);
            canvasView.Add(this);
        }

        // Initialize the canvas tools and their corresponding buttons.
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

        // Show the color palette setting for the canvas background color.
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

        // Show the grid density setting for the canvas grid.
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

        // Initialize the tools and add them to the tool picker. Each tool has its own settings and behavior.
        private void InitializeTools()
        {
            var pencilTool = new PencilTool(BrushType.Stroke, Color.Black, 3.0f);
            AddTool(pencilTool, "icon_pencil.png");

            var eraserTool = new EraserTool(EraserType.Partial, 48.0f);
            AddTool(eraserTool, "icon_eraser.png");

            var selectionTool = new SelectionTool(SelectionType.Move);
            AddTool(selectionTool, "icon_select.png");

            var rulerTool = new RulerTool(RulerType.Line);
            AddTool(rulerTool, "icon_shape.png");

            canvasView.CurrentTool = pencilTool;
        }

        // Add a tool to the tool picker and create a button for it. The button will be used to select the tool and show its settings.
        private void AddTool(ToolBase tool, string icon)
        {
            tools[tool.GetType()] = tool;

            var toolButton = CreateToolButton(ResourcePath + icon, () =>
            {
                SetTool(tool);
            });
            PickerView.Add(toolButton);

        }

        // Set the current tool of the canvas view and show its settings.
        private void SetTool(ToolBase tool)
        {
            if (tools.ContainsKey(tool.GetType()))
            {
                canvasView.CurrentTool = tool;
                ShowToolSettings(tool);
                ToolChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        // Show the settings for the given tool in the popup view. Each tool has its own settings and behavior.
        private void ShowToolSettings(ToolBase tool)
        {
            ClearPopupView();

            if (tool is PencilTool pencilTool)
                ShowPencilToolSettings(pencilTool);
            else if (tool is EraserTool eraserTool)
                ShowEraserToolSettings(eraserTool);
            else if (tool is SelectionTool selectionTool)
                ShowSelectionToolSettings(selectionTool);
            else if (tool is RulerTool rulerTool)
                ShowRulerToolSettings(rulerTool);

            PopupView.Show();
        }

        // Show the settings for the pencil tool in the popup view. The pencil tool has brush type, color, and size settings.
        private void ShowPencilToolSettings(PencilTool pencilTool)
        {
            AddBrushPicker(pencilTool);
            AddColorPicker(pencilTool);
            AddSizeSlider(pencilTool);
        }

        // Show the settings for the eraser tool in the popup view. The eraser tool has eraser type and size settings.
        private void ShowEraserToolSettings(EraserTool eraserTool)
        {
            AddEraserTypePicker(eraserTool);
            AddSizeSlider(eraserTool);
        }

        // Show the settings for the selection tool in the popup view. The selection tool has selection type settings.
        private void ShowSelectionToolSettings(SelectionTool selectionTool)
        {
            AddSelectionTypePicker(selectionTool);
        }

        private void ShowRulerToolSettings(RulerTool rulerTool)
        {
            AddRulerTypePicker(rulerTool);
        }

        // Create a button for the given tool and add it to the popup view.
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

        // Create a button for the given color and add it to the popup view.
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

        // Create a slider for the given tool and add it to the popup view. The slider controls the size of the tool.
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

        // Create a button for the given eraser type and add it to the popup view. The button toggles between partial and full eraser modes.
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
                    eraserTool.Eraser = eraserTool.Eraser == EraserType.Partial
                        ? EraserType.Full
                        : EraserType.Partial;
                    eraserTool.Activate();
                });
                eraserPicker.Add(button);
            }
            PopupView.Add(eraserPicker);
        }

        // Create a button for the given selection type and add it to the popup view. The button toggles between move, resize, and rotate modes.
        private void AddSelectionTypePicker(SelectionTool selectionTool)
        {
            var picker = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal
                }
            };

            var types = Enum.GetValues(typeof(SelectionType));
            foreach (SelectionType type in types)
            {
                var button = CreateToolButton(ResourcePath + $"icon_{type.ToString().ToLower()}.png", () =>
                {
                    selectionTool.Selection = type;
                });
                picker.Add(button);
            }

            PopupView.Add(picker);
        }

        // Create a button for the given ruler type and add it to the popup view. The button toggles between line, rectangle, and circular ruler modes.
        private void AddRulerTypePicker(RulerTool rulerTool)
        {
            var picker = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal
                }
            };

            var types = Enum.GetValues(typeof(RulerType));
            foreach (RulerType type in types)
            {
                var button = CreateToolButton(ResourcePath + $"icon_{type.ToString().ToLower()}.png", () =>
                {
                    rulerTool.Ruler = type;
                });
                picker.Add(button);
            }

            PopupView.Add(picker);
        }

        /// <summary>
        /// Add a button to the picker view with the given icon path and click action.
        /// </summary>
        /// <param name="iconPath"></param>
        /// <param name="OnClick"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddButtonToPickerView(string iconPath, Action OnClick)
        {
            var button = CreateToolButton(iconPath, OnClick);
            PickerView.Add(button);
        }

        /// <summary>
        /// Add a button to the picker view with the given view.
        /// </summary>
        /// <param name="view"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddViewToPickerView(View view)
        {
            PickerView.Add(view);
        }

        /// <summary>
        /// Add a button to the popup view with the given icon path and click action.
        /// </summary>
        /// <param name="iconPath"></param>
        /// <param name="OnClick"></param>
        public void AddButtonToPopupView(string iconPath, Action OnClick)
        {
            var button = CreateToolButton(iconPath, OnClick);
            PopupView.Add(button);
        }

        /// <summary>
        /// Add a button to the popup view with the given icon path and click action.
        /// </summary>
        /// <param name="iconPath"></param>
        /// <param name="OnClick"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddViewToPopupView(View view)
        {
            PopupView.Add(view);
        }

        /// <summary>
        /// Create a tool button with the given icon path and click action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private ImageView CreateToolButton(string iconPath, Action OnClick)
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

        // Update the UI based on the current state of the canvas view. This includes updating the selected tool, the undo/redo buttons, and the tool settings.
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

        /// <summary>
        /// Clear the popup view and hide it.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearPopupView()
        {
            int childNum = (int)PopupView.ChildCount;
            for (int i = childNum - 1; i >= 0; i--)
            {
                PopupView.Remove(PopupView.GetChildAt((uint)i));
            }
            PopupView.Hide();
        }

        /// <summary>
        /// Show the popup view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ShowPopupView()
        {
            PopupView.Show();
        }

        // Dispose the tool picker and its components.
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed) return;
            canvasView.ActionFinished -= OnFinished;;
            base.Dispose(type);
        }
    }
}
