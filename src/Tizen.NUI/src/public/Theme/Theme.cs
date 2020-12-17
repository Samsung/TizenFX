/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    /// The main purpose of providing Theme is to separate style details from the structure.
    /// Managing style separately makes it easier to customize the look of application by user context.
    /// Also since a Theme can be created from xaml file, it can be treated as a resource.
    /// This enables sharing styles with other applications.
    /// </para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Theme : BindableObject, IResourcesProvider
    {
        private readonly Dictionary<string, ViewStyle> map;
        private string baseTheme;
        private string resource;
        private string xamlFile;

        /// <summary>
        /// The resource file path that is used in the theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Resource
        {
            get => resource;
            set
            {
                if (resource == value) return;
                resource = value;

                Reload();
            }
        }

        /// <summary>Create an empty theme.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Theme()
        {
            map = new Dictionary<string, ViewStyle>();
        }

        /// <summary>Create a new theme from the xaml file.</summary>
        /// <param name="xamlFile">An absolute path to the xaml file.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given xamlFile is null or empty string.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when there are file IO problems.</exception>
        /// <exception cref="Exception">Thrown when the content of the xaml file is not valid xaml form.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Theme(string xamlFile) : this()
        {
            if (string.IsNullOrEmpty(xamlFile))
            {
                throw new ArgumentNullException(nameof(xamlFile), "The xaml file path cannot be null or empty string");
            }

            LoadFromXaml(xamlFile);
        }

        /// <summary>
        /// Create a new theme from the xaml file with theme resource.
        /// </summary>
        /// <param name="xamlFile">An absolute path to the xaml file.</param>
        /// <param name="themeResource">An absolute path to the theme resource file.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given xamlFile or themeResource is null or empty string.</exception>
        /// <exception cref="System.IO.IOException">Thrown when there are file IO problems.</exception>
        /// <exception cref="Exception">Thrown when the content of the xaml file is not valid xaml form.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Theme(string xamlFile, string themeResource) : this()
        {
            if (string.IsNullOrEmpty(xamlFile))
                throw new ArgumentNullException(nameof(xamlFile), "The xaml file path cannot be null or empty string");
            if (string.IsNullOrEmpty(themeResource))
                throw new ArgumentNullException(nameof(themeResource), "The theme resource file path cannot be null or empty string");

            resource = themeResource;
            XamlResources.SetAndLoadSource(new Uri(themeResource), themeResource, Assembly.GetAssembly(GetType()), null);

            LoadFromXaml(xamlFile);
        }

        /// <summary>
        /// The string key to identify the Theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id { get; set; }

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

                var baseThemeInstance = ThemeManager.GetBuiltinTheme(baseTheme);

                if (baseThemeInstance != null)
                {
                    foreach (var item in baseThemeInstance)
                    {
                        var baseStyle = item.Value?.Clone();
                        if (map.ContainsKey(item.Key))
                        {
                            baseStyle.Merge(map[item.Key]);
                        }
                        map[item.Key] = baseStyle;
                    }
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsResourcesCreated { get; } = true;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources { get; set; } = new ResourceDictionary();

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
                    style.Merge(value);
                }
                else
                {
                    map[styleName] = value;
                }
            }
        }

        internal int Count => map.Count;

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
        /// <returns>Founded style instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetStyle(string styleName) => map.ContainsKey(styleName) ? map[styleName] : null;

        /// <summary>
        /// Gets a style of given view type.
        /// </summary>
        /// <param name="viewType">The type of View.</param>
        /// <returns>Founded style instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given viewType is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddStyle(string styleName, ViewStyle value) => map[styleName] = value?.Clone();


        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone()
        {
            var result = new Theme()
            {
                Id = this.Id,
            };

            foreach (var item in this)
            {
                result.AddStyle(item.Key, item.Value);
            }
            return result;
        }

        /// <summary>Merge other Theme into this.</summary>
        /// <param name="xamlFile">An absolute path to the xaml file of the theme.</param>
        /// <exception cref="ArgumentException">Thrown when the given xamlFile is null or empty string.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when there are file IO problems.</exception>
        /// <exception cref="XamlParseException">Thrown when the content of the xaml file is not valid xaml form.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Merge(string xamlFile)
        {
            MergeWithoutClone(new Theme(xamlFile));
        }

        /// <summary>Merge other Theme into this.</summary>
        /// <param name="theme">The Theme.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Merge(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme));

            this.xamlFile = theme.xamlFile;

            if (Id == null) Id = theme.Id;

            foreach (var item in theme)
            {
                if (item.Value == null)
                {
                    map[item.Key] = null;
                }
                else if (map.ContainsKey(item.Key) && !item.Value.SolidNull)
                {
                    map[item.Key].Merge(item.Value);
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

            if (Id == null) Id = theme.Id;

            foreach (var item in theme)
            {
                if (item.Value == null)
                {
                    map[item.Key] = null;
                }
                else if (map.ContainsKey(item.Key) && !item.Value.SolidNull)
                {
                    map[item.Key].Merge(item.Value);
                }
                else
                {
                    map[item.Key] = item.Value;
                }
            }
        }

        /// <summary>
        /// Internal use only.
        /// </summary>
        internal void AddStyleWithoutClone(string styleName, ViewStyle value) => map[styleName] = value;

        internal void Reload()
        {
            if (xamlFile == null)
                throw new InvalidOperationException("Cannot reload without xaml file.");

            map.Clear();
            if (Resource != null)
            {
                XamlResources.Clear();
                XamlResources.SetAndLoadSource(new Uri(Resource), Resource, Assembly.GetAssembly(GetType()), null);
            }

            LoadFromXaml(xamlFile);
        }

        private void LoadFromXaml(string xamlFile)
        {
            try
            {
                using (var reader = XmlReader.Create(xamlFile))
                {
                    this.xamlFile = xamlFile;
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
    }
}
