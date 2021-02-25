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
using System.IO;
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding.Internals
{
    internal static class ResourceLoader
    {
        static Func<AssemblyName, string, string> resourceProvider = (asmName, path) =>
        {
            if (typeof(Theme).Assembly.GetName().FullName != asmName.FullName)
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                path = resource + path;
            }

            string ret = File.ReadAllText(path);
            return ret;
        };

        //takes a resource path, returns string content
        public static Func<AssemblyName, string, string> ResourceProvider
        {
            get => resourceProvider;
            internal set
            {
                DesignMode.IsDesignModeEnabled = true;
                resourceProvider = value;
            }
        }

        internal static Action<Exception> ExceptionHandler { get; set; }
    }
}
