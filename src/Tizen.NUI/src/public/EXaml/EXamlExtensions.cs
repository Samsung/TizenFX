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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace Tizen.NUI.EXaml
{
    /// Internal used, will never be opened.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EXamlExtensions
    {
        /// Internal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TXaml LoadFromEXamlPath<TXaml>(this TXaml view, string path)
        {
            MainAssembly = view.GetType().Assembly;
            //This EXaml file will be converted by Tizen.NUI.XamlBuild from the .xaml
            string xamlScript = GetXamlFromPath(path);
            LoadEXaml.Load(view, xamlScript);
            return view;
        }

        /// Internal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T LoadFromEXamlPath<T>(this T view, Type callingType)
        {
            if (null == callingType)
            {
                return view;
            }

            MainAssembly = view.GetType().Assembly;

            string resourceName = callingType.Name + ".examl";
            string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            Tizen.Log.Fatal("NUI", "the resource path: " + resource);
            int windowWidth = NUIApplication.GetDefaultWindow().Size.Width;
            int windowHeight = NUIApplication.GetDefaultWindow().Size.Height;

            string likelyResourcePath = resource + "layout/" + windowWidth.ToString() + "x" + windowHeight.ToString() + "/" + resourceName;
            Tizen.Log.Fatal("NUI", "the resource path: " + likelyResourcePath);

            if (!File.Exists(likelyResourcePath))
            {
                likelyResourcePath = resource + "layout/" + resourceName;
            }

            //Find the xaml file in the layout folder
            if (File.Exists(likelyResourcePath))
            {
                StreamReader reader = new StreamReader(likelyResourcePath);
                var xaml = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();

                LoadEXaml.Load(view, xaml);
            }
                
            return view;
        }

        /// Used for TCT and TC coverage, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T LoadFromEXaml<T>(this T view, string eXamlStr)
        {
            if (null == eXamlStr)
            {
                return view;
            }

            MainAssembly = view.GetType().Assembly;

            LoadEXaml.Load(view, eXamlStr);

            return view;
        }

        /// Internal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Assembly MainAssembly
        {
            get;
            set;
        }

        private static string GetXamlFromPath(string path)
        {
            string xaml;

            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                xaml = reader.ReadToEnd();
                reader.Dispose();
                return xaml;
            }
            return null;
        }
    }
}
