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
using Tizen.NUI;

namespace DatePickerTest
{
    // A spin control (for continously changing values when users can easily predict a set of values)

    class Example : NUIApplication
    {
        private FlexContainer _container;   // Flex container to hold spin controls
        private Spin _spinYear;  // spin control for year
        private Spin _spinMonth; // spin control for month
        private Spin _spinDay;   // spin control for day

        public Example() : base()
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {

            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;

            // Create a container for the spins
            _container = new FlexContainer();

            _container.ParentOrigin = ParentOrigin.Center;
            _container.AnchorPoint = AnchorPoint.Center;
            _container.FlexDirection = FlexContainer.FlexDirectionType.Row;
            _container.Size = new Vector3(480.0f, 150.0f, 0.0f);

            stage.GetDefaultLayer().Add(_container);

            // Create a Spin control for year
            _spinYear = new Spin();
            _spinYear.ParentOrigin = ParentOrigin.Center;
            _spinYear.AnchorPoint = AnchorPoint.Center;
            _spinYear.Flex = 0.3f;
            _spinYear.FlexMargin = new Vector4(5.0f, 0.0f, 5.0f, 0.0f);
            _container.Add(_spinYear);

            _spinYear.MinValue = 1900;
            _spinYear.MaxValue = 2100;
            _spinYear.Value = 2016;
            _spinYear.Step = 1;
            _spinYear.MaxTextLength = 4;
            _spinYear.TextPointSize = 15;
            _spinYear.TextColor = Color.Red;
            _spinYear.Focusable = (true);
            _spinYear.Name = "_spinYear";

            // Create a Spin control for month
            _spinMonth = new Spin();
            _spinMonth.ParentOrigin = ParentOrigin.Center;
            _spinMonth.AnchorPoint = AnchorPoint.Center;
            _spinMonth.Flex = 0.3f;
            _spinMonth.FlexMargin = new Vector4(5.0f, 0.0f, 5.0f, 0.0f);
            _container.Add(_spinMonth);

            _spinMonth.MinValue = 1;
            _spinMonth.MaxValue = 12;
            _spinMonth.Value = 10;
            _spinMonth.Step = 1;
            _spinMonth.MaxTextLength = 2;
            _spinMonth.TextPointSize = 15;
            _spinMonth.TextColor = Color.Green;
            _spinMonth.Focusable = (true);
            _spinMonth.Name = "_spinMonth";

            // Create a Spin control for day
            _spinDay = new Spin();
            _spinDay.ParentOrigin = ParentOrigin.Center;
            _spinDay.AnchorPoint = AnchorPoint.Center;
            _spinDay.Flex = 0.3f;
            _spinDay.FlexMargin = new Vector4(5.0f, 0.0f, 5.0f, 0.0f);
            _container.Add(_spinDay);

            _spinDay.MinValue = 1;
            _spinDay.MaxValue = 31;
            _spinDay.Value = 26;
            _spinDay.Step = 1;
            _spinDay.MaxTextLength = 2;
            _spinDay.TextPointSize = 15;
            _spinDay.TextColor = Color.Blue;
            _spinDay.Focusable = (true);
            _spinDay.Name = "_spinDay";

            FocusManager keyboardFocusManager = FocusManager.Instance;
            keyboardFocusManager.PreFocusChange += OnKeyboardPreFocusChange;
            keyboardFocusManager.FocusedViewEnterKeyPressed += OnFocusedActorEnterKeyPressed;

        }

        private View OnKeyboardPreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            View nextFocusView = e.ProposedView;

            // When nothing has been focused initially, focus the text field in the first spin
            if (!e.CurrentView && !e.ProposedView)
            {
                nextFocusView = _spinYear.SpinText;
            }
            else if(e.Direction == View.FocusDirection.Left)
            {
                // Move the focus to the spin in the left of the current focused spin
                if(e.CurrentView == _spinMonth.SpinText)
                {
                    nextFocusView = _spinYear.SpinText;
                }
                else if(e.CurrentView == _spinDay.SpinText)
                {
                    nextFocusView = _spinMonth.SpinText;
                }
            }
            else if(e.Direction == View.FocusDirection.Right)
            {
                // Move the focus to the spin in the right of the current focused spin
                if(e.CurrentView == _spinYear.SpinText)
                {
                    nextFocusView = _spinMonth.SpinText;
                }
                else if(e.CurrentView == _spinMonth.SpinText)
                {
                    nextFocusView = _spinDay.SpinText;
                }
            }

            return nextFocusView;
        }

        private void OnFocusedActorEnterKeyPressed(object source, FocusManager.FocusedViewEnterKeyEventArgs e)
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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
