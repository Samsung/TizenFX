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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public class HslViewModel : INotifyPropertyChanged
    {
        private float hue, saturation, luminosity;
        private Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        public float Hue
        {
            set
            {
                if (hue != value)
                {
                    hue = value;
                    OnPropertyChanged("Hue");
                    SetNewColor();
                }
            }
            get => hue;
        }

        public float Saturation
        {
            set
            {
                if (saturation != value)
                {
                    saturation = value;
                    OnPropertyChanged("Saturation");
                    SetNewColor();
                }
            }
            get => saturation;
        }

        public float Luminosity
        {
            set
            {
                if (luminosity != value)
                {
                    luminosity = value;
                    OnPropertyChanged("Luminosity");
                    SetNewColor();
                }
            }
            get => luminosity;
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");

                    Hue = value.R;
                    Saturation = value.G;
                    Luminosity = value.B;
                }
            }
            get => color;
        }

        private void SetNewColor()
        {
            Color = new Color(Hue, Saturation, Luminosity, 1.0f);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class HslColorScrollView : View
    {

        public HslColorScrollView()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(HslColorScrollView));
#pragma warning restore Reflection // The code contains reflection
        }
    }
}