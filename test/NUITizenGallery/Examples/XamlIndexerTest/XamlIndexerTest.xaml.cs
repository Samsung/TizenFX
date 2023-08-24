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
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Xaml;

namespace NUITizenGallery
{
    public partial class XamlIndexerTestPage : ContentPage
    {
        public XamlIndexerTestPage()
        {
            InitializeComponent();
        }
    }

    public class MyIndexer
    {
        public Size this[string index]
        {
            get
            {
                switch (index)
                {
                    case "0":
                    default:
                        return new Size(0, 0, 0);
                        break;
                    case "1":
                        return new Size(100, 100, 0);
                        break;
                    case "2":
                        return new Size(200, 200, 0);
                        break;

                }
            }
        }
        static private MyIndexer instance;

        static public MyIndexer Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new MyIndexer();
                }
                return instance;
            }
        }
    }

    internal class MyIndexerExtension : IMarkupExtension<Size>
    {
        public string Key
        {
            get;
            set;
        }
        
        //used for XamlC, in csproj <NeedInjection>True</NeedInjection>
        public Size ProvideValue(IServiceProvider serviceProvider)
        {
            //should be same implementation with IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) below.
            return MyIndexer.Instance[Key];
        }
        
        //used for EXaml, in csproj <NeedInjection>False</NeedInjection>
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            //should be same implementation with ProvideValue(IServiceProvider serviceProvider) above.
            return MyIndexer.Instance[Key];
        }
    }
}
