/*
 *  Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using NUnitLite.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Tests
{

    public class App : Tizen.NUI.NUIApplication
    {
        protected override void OnCreate()
        {
            Window window = Window.Instance;
            if(ManualTest.IsWearable())
            {
                WearableManualTestNUI.GetInstance();
            }
            else
            {
                ManualTestNUI.GetInstance();
            }
        }

        static void Main(string[] args)
        {
            Tizen.Log.Fatal("NUI", "Manual TCT for NUI start!");
            App example = new App();
            example.Run(args);
        }
    };

}
