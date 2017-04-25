/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace DatePickerUsingJson
{
    // A spin control (for continously changing values when users can easily predict a set of values)

    class Example : NUIApplication
    {
        private Spin _spinYear;  // spin control for year
        private Spin _spinMonth; // spin control for month
        private Spin _spinDay;   // spin control for day
        private Builder _builder; // DALi Builder

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

            // load date JSON template...

            _builder = new Builder ();

            // Optional constant to see logging information coming out
            // of DALi JSON parser (builder)
            PropertyMap constants = new  PropertyMap();
            constants.Insert( "CONFIG_SCRIPT_LOG_LEVEL",  new PropertyValue( "Verbose") );
            _builder.AddConstants( constants );

            _builder.LoadFromFile("/home/owner/apps_rw/NUISamples.TizenTV/res/json/date-picker-template.json" );

            // create the date-picker from the template in the json file
            BaseHandle handle =  _builder.Create( "date-picker");

            Actor actorTree =  Actor.DownCast( handle );

            stage.GetDefaultLayer().Add( actorTree );

            Actor year  = actorTree.FindChildByName("Year");
            Actor month  =  actorTree.FindChildByName("Month" );
            Actor day  = actorTree.FindChildByName("Day");

            // need to get the actual C# Spin object associated with the actor,
            _spinYear = View.DownCast<Spin>( year );
            _spinMonth = View.DownCast<Spin>( month );
            _spinDay = View.DownCast<Spin>( day );

            _spinYear.Value = 2099;
            _spinMonth.Value = 5;
            _spinDay.Value = 23;

            _spinYear.Focusable = (true);
            _spinMonth.Focusable = (true);
            _spinDay.Focusable = (true);

            FocusManager keyboardFocusManager = FocusManager.Instance;
            keyboardFocusManager.PreFocusChange += OnKeyboardPreFocusChange;
            keyboardFocusManager.FocusedViewEnterKeyPressed += OnFocusedViewEnterKeyPressed;

            StyleManager.Get().ApplyTheme("/home/owner/apps_rw/NUISamples.TizenTV/res/json/date-picker-theme.json");
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
