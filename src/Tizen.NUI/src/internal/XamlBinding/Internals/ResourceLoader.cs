/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
        static Func<ResourceLoadingQuery, ResourceLoadingResponse> _resourceProvider = (resourceLoadingQuery) => {
            if (typeof(Theme).Assembly.GetName().FullName != resourceLoadingQuery.AssemblyName.FullName)
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                resourceLoadingQuery.ResourcePath = resource + resourceLoadingQuery.ResourcePath;
            }

            string ret = File.ReadAllText(resourceLoadingQuery.ResourcePath);
            return new ResourceLoadingResponse { ResourceContent = ret };
        };
        public static Func<ResourceLoadingQuery, ResourceLoadingResponse> ResourceProvider
        {
            get => _resourceProvider;
            internal set
            {
                DesignMode.IsDesignModeEnabled = value != null;
                _resourceProvider = value;
            }
        }

        internal static Action<(Exception exception, string filepath)> ExceptionHandler { get; set; }

        public class ResourceLoadingQuery
        {
            public AssemblyName AssemblyName { get; set; }
            public string ResourcePath { get; set; }
            public object Instance { get; set; }
        }

        public class ResourceLoadingResponse
        {
            public string ResourceContent { get; set; }
            public bool UseDesignProperties { get; set; }
        }
    }
}
