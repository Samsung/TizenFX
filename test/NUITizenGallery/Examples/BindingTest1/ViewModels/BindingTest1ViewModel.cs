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
    public class BindingTest1ViewModel : INotifyPropertyChanged
    {
        private bool isBoxVisible;
        public ICommand ChangeVisibility { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingTest1ViewModel()
        {
            isBoxVisible = true;
            Tizen.Log.Debug("TEST", $"ctor");
            ChangeVisibility = new Command(() => { IsBoxVisible = !IsBoxVisible; });
        }

        public bool IsBoxVisible 
        { 
            get => isBoxVisible; 
            set
            {
                if (isBoxVisible != value)
                {
                    isBoxVisible = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void ExecuteChangeVisibility()
        {
            Tizen.Log.Debug("TEST", $"{IsBoxVisible}");
 
        }


        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
