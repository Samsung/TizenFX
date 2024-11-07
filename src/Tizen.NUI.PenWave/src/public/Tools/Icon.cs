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
    // Abstract class representing an icon that extends ImageView.
    public abstract class Icon : ImageView
    {
        // Enumeration for the Icon states.
        public enum State
        {
            // Icon Normal State
            Normal = 0,
            // Icon Pressed State
            Pressed,
            // Icon Selected State
            Selected,
            // Icon Disabled State
            Disabled
        }

        // Properties to define colors for different states.
        public string IconStateNormalColor { get; set; } = "#17234d";
        public string IconStateSelectedColor { get; set; } = "#FF6200";
        public string IconStatePressedColor { get; set; } = "#FF6200";
        public string IconStateDisabledColor { get; set; } = "#CACACA";

        // Event handler for when the icon is selected.
        public event Action<object> IconSelected;

        // Image views for the default and selected states of the icon.
        public ImageView DefaultImage;
        public ImageView SelectedImage;

        // Default size of the icon.
        private int defaultSize = 48;
        // Current state of the icon.
        private State state;

        // Property to get and set the current state of the icon.
        public State CurrentState
        {
            get => state;
            set
            {
                state = value;
                UpdateIconState(); // Update the icon's appearance based on the new state.
            }
        }

        // Constructor for the Icon class.
        public Icon()
        {
            // Set layout properties to center the icon within its parent.
            Layout = new LinearLayout()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Set the default size of the icon.
            this.Size2D = new Size2D(defaultSize, defaultSize);

            // Attach a touch event handler to handle click events on the icon.
            this.TouchEvent += OnClickIcon;
        }

        // Override the Dispose method to clean up resources.
        protected override void Dispose(DisposeTypes type)
        {
            base.Dispose(type);
            // Dispose of the default and selected image views.
            DefaultImage?.Dispose();
            SelectedImage?.Dispose();
        }

        // Method to initialize the icon with default and selected images.
        protected void InitializeIcon()
        {
            // Create a default image view with the specified properties.
            DefaultImage = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Color = new Color(IconStateNormalColor),
                ResourceUrl = GetDefaultImageUrl() // Get the URL for the default image.
            };
            // Add the default image view to the icon.
            this.Add(DefaultImage);

            // Create a selected image view with the specified properties.
            SelectedImage = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                ResourceUrl = GetSelectedImageUrl() // Get the URL for the selected image.
            };
            // Add the selected image view to the default image view.
            DefaultImage.Add(SelectedImage);
            // Hide the selected image view initially.
            SelectedImage.Hide();
        }

        // Method to update the icon's appearance based on its current state.
        public virtual void UpdateIconState()
        {
            switch (state)
            {
                case State.Normal:
                    // Hide the selected image and set the color of the default image to normal color.
                    SelectedImage.Hide();
                    DefaultImage.Color = new Color(IconStateNormalColor);
                    break;
                case State.Selected:
                    // Show the selected image and set the color of the default image to selected color.
                    SelectedImage.Show();
                    DefaultImage.Color = new Color(IconStateSelectedColor);
                    break;
                case State.Pressed:
                    // Set the color of the default image to pressed color.
                    DefaultImage.Color = new Color(IconStatePressedColor);
                    break;
                case State.Disabled:
                    // Set the color of the default image to disabled color and hide the selected image.
                    DefaultImage.Color = new Color(IconStateDisabledColor);
                    SelectedImage.Hide();
                    break;
                default:
                    break;
            }
        }

        // Method to handle touch events on the icon.
        public virtual bool OnClickIcon(object sender, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                // Set the currently selected icon to this instance and invoke the IconSelected event.
                IconStateManager.Instance.CurrentSelectedIcon = this;
                IconSelected?.Invoke(sender);
                return true;
            }
            return false;
        }

        // Abstract methods to be implemented by derived classes to return the URLs for default and selected images.
        protected abstract string GetDefaultImageUrl();
        protected abstract string GetSelectedImageUrl();
    }
}