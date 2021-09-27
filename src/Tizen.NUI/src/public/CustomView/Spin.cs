/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

// A spin control (for continuously changing values when users can easily predict a set of values)
namespace Tizen.NUI
{
    ///<summary>
    ///Spins the CustomView class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Spin : CustomView
    {
        private VisualBase arrowVisual;
        private TextField textField;
        private int arrowVisualPropertyIndex;
        private string arrowImage;
        private int currentValue;
        private int minValue;
        private int maxValue;
        private int singleStep;
        private bool wrappingEnabled;
        private int pointSize;
        private Color textColor;
        private Color textBackgroundColor;
        private int maxTextLength;

        // static constructor registers the control type (only runs once)
        static Spin()
        {
            // ViewRegistry registers control type with DALi type registry
            // also uses introspection to find any properties that need to be registered with type registry
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(Spin));
        }

        /// <summary>
        /// Creates an initialized spin.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Spin() : base(typeof(Spin).FullName, CustomViewBehaviour.RequiresKeyboardNavigationSupport)
        {
        }

        /// <summary>
        /// Value to be set in the spin.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        // GetValue() is in BindableObject. It's different from this Value.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1721: Property names should not match get methods")]
        public int Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                NUILog.Debug("Value set to " + value);
                currentValue = value;

                // Make sure no invalid value is accepted
                if (currentValue < minValue)
                {
                    currentValue = minValue;
                }

                if (currentValue > maxValue)
                {
                    currentValue = maxValue;
                }

                textField.Text = currentValue.ToString();
            }
        }

        /// <summary>
        /// Minimum value of the spin value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
            }
        }

        /// <summary>
        /// Maximum value of the spin value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
            }
        }

        /// <summary>
        /// Increasing, decreasing step of the spin value when up or down keys are pressed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public int Step
        {
            get
            {
                return singleStep;
            }
            set
            {
                singleStep = value;
            }
        }

        /// <summary>
        /// Wrapping enabled status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public bool WrappingEnabled
        {
            get
            {
                return wrappingEnabled;
            }
            set
            {
                wrappingEnabled = value;
            }
        }

        /// <summary>
        /// Text point size of the spin value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public int TextPointSize
        {
            get
            {
                return pointSize;
            }
            set
            {
                pointSize = value;
                textField.PointSize = pointSize;
            }
        }

        /// <summary>
        /// The color of the spin value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                if (value != null)
                {
                    NUILog.Debug("TextColor set to " + value.R + "," + value.G + "," + value.B);
                }

                textColor = value;
                textField.TextColor = textColor;
            }
        }

        /// <summary>
        /// Maximum text length of the spin value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [ScriptableProperty()]
        public int MaxTextLength
        {
            get
            {
                return maxTextLength;
            }
            set
            {
                maxTextLength = value;
                textField.MaxLength = maxTextLength;
            }
        }

        /// <summary>
        /// Reference of TextField of the spin.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextField SpinText
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        /// <summary>
        /// Show indicator image, for example, up or down arrow image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string IndicatorImage
        {
            get
            {
                return arrowImage;
            }
            set
            {
                arrowImage = value;
                var ptMap = new PropertyMap();
                var temp = new PropertyValue((int)Visual.Type.Image);
                ptMap.Add(Visual.Property.Type, temp);
                temp.Dispose();

                temp = new PropertyValue(arrowImage);
                ptMap.Add(ImageVisualProperty.URL, temp);
                temp.Dispose();

                temp = new PropertyValue(150);
                ptMap.Add(ImageVisualProperty.DesiredHeight, temp);
                temp.Dispose();

                temp = new PropertyValue(150);
                ptMap.Add(ImageVisualProperty.DesiredWidth, temp);
                temp.Dispose();

                arrowVisual = VisualFactory.Instance.CreateVisual(ptMap);
                ptMap.Dispose();

                RegisterVisual(arrowVisualPropertyIndex, arrowVisual);
            }
        }

        // Called by DALi Builder if it finds a Spin control in a JSON file
        static CustomView CreateInstance()
        {
            return new Spin();
        }

        /// <summary>
        /// Overrides the method of OnInitialize() for the CustomView class.<br />
        /// This method is called after the control has been initialized.<br />
        /// Derived classes should do any second phase initialization by overriding this method.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public override void OnInitialize()
        {
            // Initialize the propertiesControl
            arrowImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
            textBackgroundColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
            currentValue = 0;
            minValue = 0;
            maxValue = 0;
            singleStep = 1;
            maxTextLength = 0;

            // Create image visual for the arrow keys
            var temp = new PropertyValue(arrowImage);
            arrowVisualPropertyIndex = RegisterProperty("ArrowImage", temp, Tizen.NUI.PropertyAccessMode.ReadWrite);
            temp.Dispose();

            var ptMap = new PropertyMap();
            temp = new PropertyValue((int)Visual.Type.Image);
            ptMap.Add(Visual.Property.Type, temp);
            temp.Dispose();

            temp = new PropertyValue(arrowImage);
            ptMap.Add(ImageVisualProperty.URL, temp);
            temp.Dispose();

            temp = new PropertyValue(150);
            ptMap.Add(ImageVisualProperty.DesiredHeight, temp);
            temp.Dispose();

            temp = new PropertyValue(150);
            ptMap.Add(ImageVisualProperty.DesiredWidth, temp);
            temp.Dispose();

            arrowVisual = VisualFactory.Instance.CreateVisual(ptMap);
            ptMap.Dispose();
            RegisterVisual(arrowVisualPropertyIndex, arrowVisual);

            // Create a text field
            textField = new TextField();
            textField.PivotPoint = Tizen.NUI.PivotPoint.Center;
            textField.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            textField.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            textField.SizeModeFactor = new Vector3(1.0f, 0.45f, 1.0f);
            textField.PlaceholderText = "----";
            textField.BackgroundColor = textBackgroundColor;
            textField.HorizontalAlignment = HorizontalAlignment.Center;
            textField.VerticalAlignment = VerticalAlignment.Center;
            textField.Focusable = (true);
            textField.Name = "_textField";
            textField.Position2D = new Position2D(0, 40);

            this.Add(textField);

            textField.FocusGained += TextFieldKeyInputFocusGained;
            textField.FocusLost += TextFieldKeyInputFocusLost;
        }

        /// <summary>
        /// Overrides the method of GetNaturalSize() for the CustomView class.<br />
        /// Returns the natural size of the actor.<br />
        /// </summary>
        /// <returns> Natural size of this spin itself.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override Size2D GetNaturalSize()
        {
            return new Size2D(150, 150);
        }

        /// <summary>
        /// An event handler is used when the TextField in the spin gets the key focus.<br />
        /// Make sure when the current spin that takes input focus, also takes the keyboard focus.<br />
        /// For example, when you tap the spin directly.<br />
        /// </summary>
        /// <param name="source">Sender of this event.</param>
        /// <param name="e">Event arguments.</param>
        /// <since_tizen> 3 </since_tizen>
        public void TextFieldKeyInputFocusGained(object source, EventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(textField);
        }

        /// <summary>
        /// An event handler when the TextField in the spin looses it's key focus.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        /// <since_tizen> 3 </since_tizen>
        public void TextFieldKeyInputFocusLost(object source, EventArgs e)
        {
            int previousValue = currentValue;

            // If the input value is invalid, change it back to the previous valid value
            if (int.TryParse(textField.Text, out currentValue))
            {
                if (currentValue < minValue || currentValue > maxValue)
                {
                    currentValue = previousValue;
                }
            }
            else
            {
                currentValue = previousValue;
            }

            // Otherwise take the new value
            this.Value = currentValue;
        }

        /// <summary>
        /// Overrides the method of GetNextKeyboardFocusableView() for the CustomView class.<br />
        /// Gets the next key focusable view in this view towards the given direction.<br />
        /// A view needs to override this function in order to support two-dimensional key navigation.<br />
        /// </summary>
        /// <param name="currentFocusedView">The current focused view.</param>
        /// <param name="direction">The direction to move the focus towards.</param>
        /// <param name="loopEnabled">Whether the focus movement should be looped within the control.</param>
        /// <returns>The next keyboard focusable view in this control or an empty handle if no view can be focused.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            // Respond to Up/Down keys to change the value while keeping the current spin focused
            View nextFocusedView = currentFocusedView;
            if (direction == View.FocusDirection.Up)
            {
                this.Value += this.Step;
                nextFocusedView = textField;
            }
            else if (direction == View.FocusDirection.Down)
            {
                this.Value -= this.Step;
                nextFocusedView = textField;
            }
            else
            {
                // Return null
                return null;
            }

            return nextFocusedView;
        }
    }
}
