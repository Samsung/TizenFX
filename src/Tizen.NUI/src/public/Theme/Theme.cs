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
using System.Reflection;
using System.Xml;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI
{
    /// <summary>
    /// <para>
    /// Basically, the Theme is a dictionary of <seealso cref="ViewStyle"/>s that can decorate NUI <seealso cref="View"/>s.
    /// Each ViewStyle item is identified by a string key that can be matched the <seealso cref="View.StyleName"/>.
    /// </para>
    /// <para>
    /// The main purpose of providing theme is to separate style details from the structure.
    /// Managing style separately makes it easier to customize the look of application by user context.
    /// Also since a theme can be created from xaml file, it can be treated as a resource.
    /// This enables sharing styles with other applications.
    /// </para>
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Theme : BindableObject
    {
        private readonly Dictionary<string, ViewStyle> map;
        private IEnumerable<KeyValuePair<string, string>> changedResources = null;
        private string baseTheme;
        ResourceDictionary resources;

        /// <summary>
        /// Create an empty theme.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Theme()
        {
            map = new Dictionary<string, ViewStyle>();
        }

        /// <summary>
        /// Create a new theme from the xaml file.
        /// </summary>
        /// <param name="xamlFile">An absolute path to the xaml file.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given xamlFile is null or empty string.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when there are file IO problems.</exception>
        /// <exception cref="Exception">Thrown when the content of the xaml file is not valid xaml form.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Theme(string xamlFile) : this()
        {
            if (string.IsNullOrEmpty(xamlFile))
            {
                throw new ArgumentNullException(nameof(xamlFile), "The xaml file path cannot be null or empty string");
            }

            try
            {
                using (var reader = XmlReader.Create(xamlFile))
                {
                    XamlLoader.Load(this, reader);
                }
            }
            catch (System.IO.IOException)
            {
                Tizen.Log.Error("NUI", $"Could not load \"{xamlFile}\".\n");
                throw;
            }
            catch (Exception)
            {
                Tizen.Log.Error("NUI", $"Could not parse \"{xamlFile}\".\n");
                Tizen.Log.Error("NUI", "Make sure the all used assemblies (e.g. Tizen.NUI.Components) are included in the application project.\n");
                Tizen.Log.Error("NUI", "Make sure the type and namespace are correct.\n");
                throw;
            }
        }

        /// <summary>
        /// The string key to identify the Theme.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Id { get; set; }

        /// <summary>
        /// The version of the Theme.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Version { get; set; } = null;

        /// <summary>
        /// For Xaml use only.
        /// The bulit-in theme id that will be used as base of this.
        /// View styles with same key are merged.
        /// </summary>
        internal string BasedOn
        {
            get => baseTheme;
            set
            {
                baseTheme = value;

                if (string.IsNullOrEmpty(baseTheme)) return;

                var baseThemeInstance = (Theme)ThemeManager.GetBuiltinTheme(baseTheme)?.Clone();

                if (baseThemeInstance != null)
                {
                    foreach (var item in baseThemeInstance)
                    {
                        var baseStyle = item.Value?.Clone();
                        if (map.ContainsKey(item.Key))
                        {
                            baseStyle.MergeDirectly(map[item.Key]);
                        }
                        map[item.Key] = baseStyle;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsResourcesCreated => resources != null;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ResourceDictionary Resources
        {
            get
            {
                if (resources != null)
                    return resources;
                resources = new ResourceDictionary();
                ((IResourceDictionary)resources).ValuesChanged += OnThemeResourcesChanged;
                return resources;
            }
            set
            {
                if (resources == value)
                    return;

                if (resources != null)
                {
                    ((IResourceDictionary)resources).ValuesChanged -= OnThemeResourcesChanged;
                }
                resources = value;
                if (resources != null)
                {
                    // This callback will be removed when Resource.Source is assigned.
                    ((IResourceDictionary)resources).ValuesChanged += OnThemeResourcesChanged;
                }
            }
        }

        /// <summary>
        /// For Xaml use only.
        /// Note that it is not a normal indexer.
        /// Setter will merge the new value with existing item.
        /// </summary>
        internal ViewStyle this[string styleName]
        {
            get => map[styleName];
            set
            {
                if (value == null)
                {
                    map.Remove(styleName);
                    return;
                }

                if (map.TryGetValue(styleName, out ViewStyle style) && style != null && style.GetType() == value.GetType())
                {
                    style.MergeDirectly(value);
                }
                else
                {
                    map[styleName] = value;
                }
            }
        }

        internal int Count => map.Count;

        internal int PackageCount { get; set; } = 0;

        /// <summary>
        /// Get an enumerator of the theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerator<KeyValuePair<string, ViewStyle>> GetEnumerator() => map.GetEnumerator();

        /// <summary>
        /// Removes all styles in the theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear() => map.Clear();

        /// <summary>
        /// Determines whether the theme contains the specified style name.
        /// </summary>
        /// <exception cref="ArgumentNullException">The given style name is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasStyle(string styleName) => map.ContainsKey(styleName);

        /// <summary>
        /// Removes the style with the specified style name.
        /// </summary>
        /// <exception cref="ArgumentNullException">The given style name is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveStyle(string styleName) => map.Remove(styleName);

        /// <summary>
        /// Gets a style of given style name.
        /// </summary>
        /// <param name="styleName">The string key to find a ViewStyle.</param>
        /// <returns>Found style instance if the style name has been found, otherwise null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given styleName is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public ViewStyle GetStyle(string styleName)
        {
            map.TryGetValue(styleName ?? throw new ArgumentNullException(nameof(styleName)), out ViewStyle result);
            return result;
        }

        /// <summary>
        /// Gets a style of given view type.
        /// </summary>
        /// <param name="viewType">The type of View.</param>
        /// <returns>Found style instance if the view type is found, otherwise null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given viewType is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public ViewStyle GetStyle(Type viewType)
        {
            var currentType = viewType ?? throw new ArgumentNullException(nameof(viewType));
            ViewStyle resultStyle = null;

            do
            {
                if (currentType.Equals(typeof(View))) break;
                resultStyle = GetStyle(currentType.FullName);
                currentType = currentType.BaseType;
            }
            while (resultStyle == null && currentType != null);

            return resultStyle;
        }

        /// <summary>
        /// Adds the specified style name and value to the theme.
        /// This replace existing value if the theme already has a style with given name.
        /// </summary>
        /// <param name="styleName">The style name to add.</param>
        /// <param name="value">The style instance to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given styleName is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void AddStyle(string styleName, ViewStyle value)
        {
            if (styleName == null)
            {
                throw new ArgumentNullException(nameof(styleName));
            }
            map[styleName] = value?.Clone();
        }

        /// <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        public object Clone()
        {
            var result = new Theme()
            {
                Id = this.Id,
                Resources = Resources
            };

            foreach (var item in this)
            {
                result.AddStyle(item.Key, item.Value);
            }
            return result;
        }

        /// <summary>Merge other theme into this.</summary>
        /// <param name="xamlFile">An absolute path to the xaml file of the theme.</param>
        /// <exception cref="ArgumentException">Thrown when the given xamlFile is null or empty string.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when there are file IO problems.</exception>
        /// <exception cref="XamlParseException">Thrown when the content of the xaml file is not valid xaml form.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Merge(string xamlFile)
        {
            MergeWithoutClone(new Theme(xamlFile));
        }

        /// <summary>Merge other theme into this.</summary>
        /// <param name="theme">The theme to be merged with this theme.</param>
        /// <since_tizen> 9 </since_tizen>
        public void Merge(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme));

            if (Id == null) Id = theme.Id;

            foreach (var item in theme)
            {
                if (item.Value == null)
                {
                    map[item.Key] = null;
                }
                else if (map.ContainsKey(item.Key) && !item.Value.SolidNull)
                {
                    map[item.Key].MergeDirectly(item.Value);
                }
                else
                {
                    map[item.Key] = item.Value.Clone();
                }
            }
        }

        internal void MergeWithoutClone(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme));

            if (Id == null)
            {
                Id = theme.Id;
            }

            if (Version == null)
            {
                Version = theme.Version;
            }

            foreach (var item in theme)
            {
                if (item.Value == null)
                {
                    map[item.Key] = null;
                }
                else if (map.ContainsKey(item.Key) && !item.Value.SolidNull)
                {
                    map[item.Key].MergeDirectly(item.Value);
                }
                else
                {
                    map[item.Key] = item.Value;
                }
            }

            if (theme.resources != null)
            {
                foreach (var res in theme.resources)
                {
                    Resources[res.Key] = res.Value;
                }
            }
        }

        /// <summary>
        /// Internal use only.
        /// </summary>
        internal void AddStyleWithoutClone(string styleName, ViewStyle value) => map[styleName] = value;

        internal void ApplyExternalTheme(IExternalTheme externalTheme, HashSet<ExternalThemeKeyList> keyListSet)
        {
            Id = externalTheme.Id;
            Version = externalTheme.Version;

            if (keyListSet == null)
            {
                // Nothing to apply
                return;
            }

            foreach (var keyList in keyListSet)
            {
                keyList?.ApplyKeyActions(externalTheme, this);
            }
        }

        internal bool HasSameIdAndVersion(IExternalTheme externalTheme)
        {
            if (externalTheme == null)
            {
                return false;
            }

            return string.Equals(Id, externalTheme.Id, StringComparison.OrdinalIgnoreCase) && string.Equals(Version, externalTheme.Version, StringComparison.OrdinalIgnoreCase);
        }

        internal void SetChangedResources(IEnumerable<KeyValuePair<string, string>> changedResources)
        {
            this.changedResources = changedResources;
        }

        internal void OnThemeResourcesChanged(object sender, ResourcesChangedEventArgs e) => OnThemeResourcesChanged();

        internal void OnThemeResourcesChanged()
        {
            if (changedResources != null)
            {
                // To avoid loop in infinite, remove OnThemeResourcesChanged callback.
                ((IResourceDictionary)resources).ValuesChanged -= OnThemeResourcesChanged;
                foreach (var changedResource in changedResources)
                {
                    if (resources.TryGetValue(changedResource.Key, out object resourceValue))
                    {
                        string changedValue = changedResource.Value;

                        // check NUIResourcePath
                        string[] changedValues = changedValue.Split('/');
                        if (changedValues[0] == "NUIResourcePath")
                        {
                            changedValue = changedValues[1];
                        }

                        Type toType = resourceValue.GetType();
                        resources[changedResource.Key] = changedValue.ConvertTo(toType, () => toType.GetTypeInfo(), null);
                    }
                }
            }
        }
    }
}
