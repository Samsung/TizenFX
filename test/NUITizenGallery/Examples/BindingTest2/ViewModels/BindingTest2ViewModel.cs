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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tizen.NUI.Binding;

namespace NUITizenGallery.ViewModels
{
    public class BindingTest2ViewModel : INotifyPropertyChanged
    {
        private int boxSize;
        private string boxSizeText;

        public BindingTest2ViewModel()
        {
            BoxSize = 100;
        }

        public int BoxSize 
        { 
            get => boxSize;
            set
            {
                if (value != boxSize)
                {
                    boxSize = value;
                    BoxSizeText = $"Width: {(float)boxSize:F3}\nHeight: {(float)boxSize:F3}";
                    RaisePropertyChanged();
                }
            } 
        }

        public string BoxSizeText 
        { 
            get => boxSizeText; 
            set
            {
                boxSizeText = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
