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
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding
{
    internal class Application : Element, IResourcesProvider
    {
        static Application s_current;

        public delegate void resChangeCb(object sender, ResourcesChangedEventArgs e);

        static private Dictionary<object, Dictionary<resChangeCb, int>> resourceChangeCallbackDict = new Dictionary<object, Dictionary<resChangeCb, int>>();

        static public void AddResourceChangedCallback(object handle, resChangeCb cb)
        {
            Dictionary<resChangeCb, int> cbDict;
            resourceChangeCallbackDict.TryGetValue(handle, out cbDict);

            if (null == cbDict)
            {
                cbDict = new Dictionary<resChangeCb, int>();
                resourceChangeCallbackDict.Add(handle, cbDict);
            }

            if (false == cbDict.ContainsKey(cb))
            {
                cbDict.Add(cb, 0);
            }
        }

        public Application()
        {
            SystemResources = DependencyService.Get<ISystemResourcesProvider>().GetSystemResources();
            SystemResources.ValuesChanged += OnParentResourcesChanged;
        }

        public static bool IsApplicationOrNull(Element element)
        {
            return element == null || element is Application;
        }

        internal virtual void OnParentResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            // if (e == ResourcesChangedEventArgs.StyleSheets)
            //     ApplyStyleSheetsOnParentSet();
            // else
            //     OnParentResourcesChanged(e.Values);
        }

        internal IResourceDictionary SystemResources { get; }

        public static Application Current
        {
            get
            {
                if (null == s_current)
                {
                    s_current = new Application();
                }

                return s_current;
            }

            set
            {
                if (s_current == value)
                    return;
                if (value == null)
                    s_current = null; //Allow to reset current for unittesting
                s_current = value;
            }
        }

        ResourceDictionary _resources;
        bool IResourcesProvider.IsResourcesCreated => _resources != null;

        public ResourceDictionary Resources
        {
            get
            {
                if (_resources != null)
                    return _resources;

                _resources = new ResourceDictionary();
                ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                return _resources;
            }
            set
            {
                if (_resources == value)
                    return;
                OnPropertyChanging();
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged -= OnResourcesChanged;
                _resources = value;
                OnResourcesChanged(value);
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                OnPropertyChanged();
            }
        }

        internal virtual void OnResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            OnResourcesChanged(e.Values);
        }
    }
    internal static class ResourcesExtensions
    {
        public static IEnumerable<KeyValuePair<string, object>> GetMergedResources(this IElement element)
        {
            Dictionary<string, object> resources = null;
            while (element != null)
            {
                var ve = element as IResourcesProvider;
                if (ve != null && ve.IsResourcesCreated)
                {
                    resources = resources ?? new Dictionary<string, object>();
                    foreach (KeyValuePair<string, object> res in ve.Resources.MergedResources)
                        if (!resources.ContainsKey(res.Key))
                            resources.Add(res.Key, res.Value);
                        else if (res.Key.StartsWith(Style.StyleClassPrefix, StringComparison.Ordinal))
                        {
                            var mergedClassStyles = new List<Style>(resources[res.Key] as List<Style>);
                            mergedClassStyles.AddRange(res.Value as List<Style>);
                            resources[res.Key] = mergedClassStyles;
                        }
                }
                var app = element as Application;
                if (app != null && app.SystemResources != null)
                {
                    resources = resources ?? new Dictionary<string, object>(8);
                    foreach (KeyValuePair<string, object> res in app.SystemResources)
                        if (!resources.ContainsKey(res.Key))
                            resources.Add(res.Key, res.Value);
                        else if (res.Key.StartsWith(Style.StyleClassPrefix, StringComparison.Ordinal))
                        {
                            var mergedClassStyles = new List<Style>(resources[res.Key] as List<Style>);
                            mergedClassStyles.AddRange(res.Value as List<Style>);
                            resources[res.Key] = mergedClassStyles;
                        }
                }
                element = element.Parent;
            }
            return resources;
        }

        public static bool TryGetResource(this IElement element, string key, out object value)
        {
            while (element != null)
            {
                var ve = element as IResourcesProvider;
                if (ve != null && ve.IsResourcesCreated && ve.Resources.TryGetValue(key, out value))
                    return true;
                var app = element as Application;
                if (app != null && app.SystemResources != null && app.SystemResources.TryGetValue(key, out value))
                    return true;
                element = element.Parent;
            }

            //Fallback for the XF previewer
            if (Application.Current != null && ((IResourcesProvider)Application.Current).IsResourcesCreated && Application.Current.Resources.TryGetValue(key, out value))
                return true;

            value = null;
            return false;
        }
    }
}
 
