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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class KeyboardTest1Page : ContentPage
    {
        public KeyboardTest1Page()
        {
            InitializeComponent();
            dateTimeKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Datetime));
            emailKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Email));
            emoticonKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Emoticon));
            hexKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.HEX));
            ipLayoutKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.IP));
            monthKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Month));
            normalKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Normal));
            numberKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Number));
            numberOnlyKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.NumberOnly));
            passworKeyboarddButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Password));
            phoneNumberKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.PhoneNumber));
            terminalKeyboardButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.Terminal));
            urlKeyboarddButton.Command = new Command(() => SetOutputMethod(InputMethod.PanelLayoutType.URL));
        }

        private void SetOutputMethod(InputMethod.PanelLayoutType inputLayoutType)
        {
            InputMethod im = new InputMethod();
            im.PanelLayout = inputLayoutType;
            textField.InputMethodSettings = im.OutputMap;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                RemoveAllChildren(true);
            }

            base.Dispose(type);
        }

        private void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(this, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }

            int maxChild = (int)parent.ChildCount;
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }
                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }
    }
}
