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
using System.Collections.Generic;

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace NUITizenGallery
{
    public partial class ProgressbarTest1Page : View
    {
        List<Color> colorlist = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow, };
        int colorIndex = 0;
        Timer AnimationTimer = new Timer(50);

        public ProgressbarTest1Page()
        {
            InitializeComponent();

            ChangeColorButton.Clicked += OnChangeColorButtonClicked;
            AnimateButton.Clicked += OnAnimateButtonClicked;

            TestSlider.ValueChanged += OnValueChanged;
            TestSlider.CurrentValue = 50.0f;
            TestProgress.CurrentValue = 50.0f;
        }

        private void OnChangeColorButtonClicked(object sender, ClickedEventArgs args)
        {
            TestProgress.ProgressColor = colorlist[colorIndex++ % 4];
        }

        private void OnAnimateButtonClicked(object sender, ClickedEventArgs args)
        {
            TestProgress.CurrentValue = 0.0f;
            AnimationTimer.Tick += OnTimerTick;
            AnimationTimer.Start();
        }

        private bool OnTimerTick(object sender, Timer.TickEventArgs args)
        {
            TestProgress.CurrentValue += 1.0f;

            if (TestProgress.CurrentValue >= 99.9f)
            {
                AnimationTimer.Stop();
                return false;
            }

            return true;
        }

        private void OnValueChanged(object sender, SliderValueChangedEventArgs args)
        {
            TestProgress.CurrentValue = args.CurrentValue;
        }

        protected override void Dispose(DisposeTypes type)
        {
            AnimationTimer.Stop();
            base.Dispose(type);
        }
    }
}
