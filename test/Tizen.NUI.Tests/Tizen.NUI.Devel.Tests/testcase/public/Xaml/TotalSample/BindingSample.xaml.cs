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
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public class FloatToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (float)value != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0;
        }
    }

    public class BoolToObjectConverter<T> : IValueConverter
    {
        public T TrueObject { set; get; }

        public T FalseObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueObject : FalseObject;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((T)value).Equals(TrueObject);
        }
    }

    public class FloatToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)Math.Round((float)value * GetParameter(parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value / GetParameter(parameter);
        }

        float GetParameter(object parameter)
        {
            if (parameter is float)
                return (float)parameter;

            else if (parameter is int)
                return (int)parameter;

            else if (parameter is string)
                return float.Parse((string)parameter);

            return 1;
        }
    }

    public class RgbColorViewModel : INotifyPropertyChanged
    {
        Color color;
        string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public float Red
        {
            set
            {
                if (color.R != value)
                {
                    Color = new Color(value, color.G, color.B, 1.0f);
                }
            }
            get
            {
                return color.R;
            }
        }


        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Red"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

                    Name = "Red";
                }
            }
            get
            {
                return color;
            }
        }

        public string Name
        {
            private set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
            get
            {
                return name;
            }
        }
    }

    public partial class BindingSample : View
    {
        public BindingSample()
        {
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BindingSample));
        }
    }
}