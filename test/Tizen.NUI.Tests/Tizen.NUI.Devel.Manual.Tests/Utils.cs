/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.NUI.Tests
{

    public class ResultNumber
    {
        public static int Total { get; set; }
        public static int Pass { get; set; }
        public static int Fail { get; set; }
        public static int NotRun { get; set; }
        public static int Block { get; set; }
    }

    public class TestcaseInfo
    {
        private string _tescaseName;
        public string TestcaseName
        {
            get
            {
                return _tescaseName;
            }
            set
            {
                _tescaseName = value;
            }
        }

        private List<string> _preconditions;
        public List<string> Preconditions
        {
            get
            {
                return _preconditions;
            }
            set
            {
                _preconditions = value;
            }
        }

        private List<string> _steps;
        public List<string> Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                _steps = value;
            }
        }

        private List<string> _postconditions;
        public List<string> Postconditions
        {
            get
            {
                return _postconditions;
            }
            set
            {
                _postconditions = value;
            }
        }
    }
    public class ItemData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int No { get; set; }

        public string TCName { get; set; }

        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                if (_result.Equals(StrResult.PASS))
                {
                    ResultColor = Color.Green;
                }
                else if (_result.Equals(StrResult.FAIL))
                {
                    ResultColor = Color.Red;
                }
                else if (_result.Equals(StrResult.BLOCK))
                {
                    ResultColor = Color.Red;
                }
                else
                {
                    ResultColor = Color.Black;
                }
                OnPropertyChanged(this, "Result");
            }
        }

        private Color _resultColor;
        public Color ResultColor
        {
            get { return _resultColor; }
            set
            {
                _resultColor = value;
                OnPropertyChanged(this, "ResultColor");
            }
        }
    }

    public class StrResult
    {
        public static string PASS = "PASS";
        public static string FAIL = "FAIL";
        public static string NOTRUN = "NOT RUN";
        public static string BLOCK = "BLOCK";
    }

    public class RunType
    {
        public static string AUTO = "AUTO";
        public static string MANUAL = "MANUAL";

        public static string Value { get; set; }
    }

    public class ManualTest
    {
        private static bool Confirmed = true;

        public static async Task WaitForConfirm()
        {
            Confirmed = false;
            //ManualTestNUI.GetInstance().UnlockUIButton();

            while (true)
            {
                await Task.Delay(200);
                if (Confirmed)
                    break;
            }

            if (ManualTest.IsWearable())
            {
                WearableManualTestNUI.GetInstance().UnlockUIButton();
            }
            else
            {
                ManualTestNUI.GetInstance().UnlockUIButton();
            }
        }

        public static bool IsConfirmed()
        {
            return Confirmed;
        }

        public static void Confirm()
        {
            Confirmed = true;
        }

        public static bool IsMobile()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            if (result && value.Equals("mobile"))
            {
                return true;
            }

            return false;
        }

        public static bool IsWearable()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            if (result && value.Equals("wearable"))
            {
                return true;
            }

            return false;
        }

        public static bool IsEmulator()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/system/model_name", out value);
            if (result && value.Equals("Emulator"))
            {
                return true;
            }

            return false;
        }

        public static float GetPointSize()
        {
            float retValue = 10.0f; //default
            string value;
            Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            switch (value)
            {
                case "wearable":
                    retValue = 4.0f;
                    break;
                case "mobile":
                    retValue = 5.0f;
                    break;
                case "tv":
                    retValue = 20.0f;
                    break;
            }
            return retValue;
        }

        public static TextLabel CreateLabel(string information)
        {
            TextLabel mLabel = new TextLabel();
            mLabel.TextColor = Color.White;
            mLabel.PointSize = 4.0f;
            mLabel.VerticalAlignment = VerticalAlignment.Center;
            mLabel.HorizontalAlignment = HorizontalAlignment.Begin;
            mLabel.MultiLine = true;
            mLabel.Text = information;
            mLabel.Size2D = new Size2D(300, 50);
            return mLabel;
        }
    }

    enum NavigationButton
    {
        Next,
        Previous,
        Home,
        NA
    }
}
