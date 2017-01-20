/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using NUI;

namespace MyCSharpExample
{
    // A spin control (for continously changing values when users can easily predict a set of values)
    class Spin : CustomView
    {
        private VisualBase _arrowVisual;
        private TextField _textField;
        private int _arrowVisualPropertyIndex;
        private string _arrowImage;
        private int _currentValue;
        private int _minValue;
        private int _maxValue;
        private int _singleStep;
        private bool _wrappingEnabled;
        private string _fontFamily;
        private string _fontStyle;
        private int _pointSize;
        private Color _textColor;
        private Color _textBackgroundColor;
        private int _maxTextLength;

        public Spin() : base(ViewWrapperImpl.CustomViewBehaviour.REQUIRES_KEYBOARD_NAVIGATION_SUPPORT | ViewWrapperImpl.CustomViewBehaviour.DISABLE_STYLE_CHANGE_SIGNALS)
        {
        }

        public override void OnInitialize()
        {
            // Initialize the properties
            _arrowImage = "/home/owner/apps_rw/NUISamples.Tizen/res/images/arrow.png";
            _textBackgroundColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
            _currentValue = 0;
            _minValue = 0;
            _maxValue = 0;
            _singleStep = 1;
            _maxTextLength = 0;

            // Create image visual for the arrow keys
            _arrowVisualPropertyIndex = RegisterProperty("ArrowImage", new NUI.Property.Value(_arrowImage), NUI.Property.AccessMode.READ_WRITE);
            _arrowVisual =  VisualFactory.Get().CreateVisual( _arrowImage, new Uint16Pair(150, 150) );
            RegisterVisual( _arrowVisualPropertyIndex, _arrowVisual );

            // Create a text field
            _textField = new TextField();
            _textField.ParentOrigin = NDalic.ParentOriginCenter;
            _textField.AnchorPoint = NDalic.AnchorPointCenter;
            _textField.WidthResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            _textField.HeightResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            _textField.SizeModeFactor = new Vector3( 1.0f, 0.45f, 1.0f );
            _textField.PlaceholderText = "----";
            _textField.BackgroundColor = _textBackgroundColor;
            _textField.HorizontalAlignment = "Center";
            _textField.VerticalAlignment = "Center";
            _textField.SetKeyboardFocusable(true);
            _textField.Name = "_textField";

            this.Add(_textField);

            _textField.KeyInputFocusGained += TextFieldKeyInputFocusGained;
            _textField.KeyInputFocusLost += TextFieldKeyInputFocusLost;
        }

        public override Vector3 GetNaturalSize()
        {
            return new Vector3(150.0f, 150.0f, 0.0f);
        }

        public void TextFieldKeyInputFocusGained(object source, EventArgs e)
        {
            // Make sure when the current spin that takes input focus also takes the keyboard focus
            // For example, when you tap the spin directly
            FocusManager.Instance.SetCurrentFocusView(_textField);
        }

        public void TextFieldKeyInputFocusLost(object source, EventArgs e)
        {
            int previousValue = _currentValue;

            // If the input value is invalid, change it back to the previous valid value
            if(int.TryParse(_textField.Text, out _currentValue))
            {
                if (_currentValue < _minValue || _currentValue > _maxValue)
                {
                    _currentValue = previousValue;
                }
            }
            else
            {
                _currentValue = previousValue;
            }

            // Otherwise take the new value
            this.Value = _currentValue;
        }

        public override Actor GetNextKeyboardFocusableActor(Actor currentFocusedActor, View.KeyboardFocus.Direction direction, bool loopEnabled)
        {
            // Respond to Up/Down keys to change the value while keeping the current spin focused
            Actor nextFocusedActor = currentFocusedActor;
            if (direction == View.KeyboardFocus.Direction.UP)
            {
                this.Value += this.Step;
                nextFocusedActor = _textField;
            }
            else if (direction == View.KeyboardFocus.Direction.DOWN)
            {
                this.Value -= this.Step;
                nextFocusedActor = _textField;
            }
            else
            {
                // Return a native empty handle as nothing can be focused in the left or right
                nextFocusedActor = new Actor();
                nextFocusedActor.Reset();
            }

            return nextFocusedActor;
        }

        // Value property of type int:
        public int Value
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;

                // Make sure no invalid value is accepted
                if (_currentValue < _minValue)
                {
                    _currentValue = _minValue;
                }

                if (_currentValue > _maxValue)
                {
                    _currentValue = _maxValue;
                }

                _textField.Text = _currentValue.ToString();
            }
        }

        // MinValue property of type int:
        public int MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
              _minValue = value;
            }
        }

        // MaxValue property of type int:
        public int MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
              _maxValue = value;
            }
        }

        // Step property of type int:
        public int Step
        {
            get
            {
                return _singleStep;
            }
            set
            {
              _singleStep = value;
            }
        }

        // WrappingEnabled property of type bool:
        public bool WrappingEnabled
        {
            get
            {
                return _wrappingEnabled;
            }
            set
            {
              _wrappingEnabled = value;
            }
        }

        // TextPointSize property of type int:
        public int TextPointSize
        {
            get
            {
                return _pointSize;
            }
            set
            {
              _pointSize = value;
              _textField.PointSize = _pointSize;
            }
        }

        // TextColor property of type Color:
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
              _textColor = value;
              _textField.TextColor = _textColor;
            }
        }

        // MaxTextLength property of type int:
        public int MaxTextLength
        {
            get
            {
                return _maxTextLength;
            }
            set
            {
                _maxTextLength = value;
                _textField.MaxLength = _maxTextLength;
            }
        }

        public TextField SpinText
        {
            get
            {
                return _textField;
            }
            set
            {
                _textField = value;
            }
        }

        // Indicator property of type string:
        public string IndicatorImage
        {
            get
            {
                return _arrowImage;
            }
            set
            {
              _arrowImage = value;
              _arrowVisual =  VisualFactory.Get().CreateVisual( _arrowImage, new Uint16Pair(150, 150) );
              RegisterVisual( _arrowVisualPropertyIndex, _arrowVisual );
            }
        }
    }

    class Example
    {
        private NUI.Application _application;
        private FlexContainer _container;
        private Spin _spinYear;
        private Spin _spinMonth;
        private Spin _spinDay;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CallbackDelegate();

        public Example(NUI.Application application)
        {
            _application = application;
            _application.Initialized += Initialize;
        }

        public void Initialize(object source, EventArgs e)
        {
            Stage stage = Stage.GetCurrent();
            stage.BackgroundColor = Color.White;

            // Create a container for the spins
            _container = new FlexContainer();

            _container.ParentOrigin = NDalic.ParentOriginCenter;
            _container.AnchorPoint = NDalic.AnchorPointCenter;
            _container.FlexDirection = (int)FlexContainer.FlexDirectionType.ROW;
            _container.Size = new Vector3(480.0f, 150.0f, 0.0f);

            stage.Add(_container);

            // Create a Spin control for year
            _spinYear = new Spin();
            _spinYear.ParentOrigin = NDalic.ParentOriginCenter;
            _spinYear.AnchorPoint = NDalic.AnchorPointCenter;
            _spinYear.Flex = 0.3f;
            _spinYear.FlexMargin = new Vector4(5.0f, 0.0f, 5.0f, 0.0f);
            _container.Add(_spinYear);

            _spinYear.MinValue = 1900;
            _spinYear.MaxValue = 2100;
            _spinYear.Value = 2016;
            _spinYear.Step = 1;
            _spinYear.MaxTextLength = 4;
            _spinYear.TextPointSize = 26;
            _spinYear.TextColor = Color.White;
            _spinYear.SetKeyboardFocusable(true);
            _spinYear.Name = "_spinYear";

            // Create a Spin control for month
            _spinMonth = new Spin();
            _spinMonth.ParentOrigin = NDalic.ParentOriginCenter;
            _spinMonth.AnchorPoint = NDalic.AnchorPointCenter;
            _spinMonth.Flex = 0.3f;
            _spinMonth.FlexMargin = new Vector4(5.0f, 0.0f, 5.0f, 0.0f);
            _container.Add(_spinMonth);

            _spinMonth.MinValue = 1;
            _spinMonth.MaxValue = 12;
            _spinMonth.Value = 10;
            _spinMonth.Step = 1;
            _spinMonth.MaxTextLength = 2;
            _spinMonth.TextPointSize = 26;
            _spinMonth.TextColor = Color.White;
            _spinMonth.SetKeyboardFocusable(true);
            _spinMonth.Name = "_spinMonth";

            // Create a Spin control for day
            _spinDay = new Spin();
            _spinDay.ParentOrigin = NDalic.ParentOriginCenter;
            _spinDay.AnchorPoint = NDalic.AnchorPointCenter;
            _spinDay.Flex = 0.3f;
            _spinDay.FlexMargin = new Vector4(5.0f, 0.0f, 5.0f, 0.0f);
            _container.Add(_spinDay);

            _spinDay.MinValue = 1;
            _spinDay.MaxValue = 31;
            _spinDay.Value = 26;
            _spinDay.Step = 1;
            _spinDay.MaxTextLength = 2;
            _spinDay.TextPointSize = 26;
            _spinDay.TextColor = Color.White;
            _spinDay.SetKeyboardFocusable(true);
            _spinDay.Name = "_spinDay";

            FocusManager keyboardFocusManager = FocusManager.Instance;
            keyboardFocusManager.PreFocusChange += OnKeyboardPreFocusChange;
            keyboardFocusManager.FocusedViewEnterKeyPressed += OnFocusedViewEnterKeyPressed;

        }

        private View OnKeyboardPreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            View nextFocusActor = e.Proposed;

            // When nothing has been focused initially, focus the text field in the first spin
            if (!e.Current && !e.Proposed)
            {
                nextFocusActor = _spinYear.SpinText;
            }
            else if(e.Direction == View.KeyboardFocus.Direction.LEFT)
            {
                // Move the focus to the spin in the left of the current focused spin
                if(e.Current == _spinMonth.SpinText)
                {
                    nextFocusActor = _spinYear.SpinText;
                }
                else if(e.Current == _spinDay.SpinText)
                {
                    nextFocusActor = _spinMonth.SpinText;
                }
            }
            else if(e.Direction == View.KeyboardFocus.Direction.RIGHT)
            {
                // Move the focus to the spin in the right of the current focused spin
                if(e.Current == _spinYear.SpinText)
                {
                    nextFocusActor = _spinMonth.SpinText;
                }
                else if(e.Current == _spinMonth.SpinText)
                {
                    nextFocusActor = _spinDay.SpinText;
                }
            }

            return nextFocusActor;
        }

        private void OnFocusedViewEnterKeyPressed(object source, FocusManager.FocusedViewEnterKeyEventArgs e)
        {
            // Make the text field in the current focused spin to take the key input
            KeyInputFocusManager manager = KeyInputFocusManager.Get();

            if (e.View == _spinYear.SpinText)
            {
                if (manager.GetCurrentFocusControl() != _spinYear.SpinText)
                {
                    manager.SetFocus(_spinYear.SpinText);
                }
            }
            else if (e.View == _spinMonth.SpinText)
            {
                if (manager.GetCurrentFocusControl() != _spinMonth.SpinText)
                {
                    manager.SetFocus(_spinMonth.SpinText);
                }
            }
            else if (e.View == _spinDay.SpinText)
            {
                if (manager.GetCurrentFocusControl() != _spinDay.SpinText)
                {
                    manager.SetFocus(_spinDay.SpinText);
                }
            }
        }

        public void MainLoop()
        {
            _application.MainLoop ();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example(Application.NewApplication());
            example.MainLoop ();
        }
    }
}
