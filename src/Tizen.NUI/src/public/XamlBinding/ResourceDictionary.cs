using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ResourceDictionary : IResourceDictionary, IDictionary<string, object>
    {
        static ConditionalWeakTable<Type, ResourceDictionary> s_instances = new ConditionalWeakTable<Type, ResourceDictionary>();
        readonly Dictionary<string, object> _innerDictionary = new Dictionary<string, object>();
        ResourceDictionary _mergedInstance;
        Type _mergedWith;
        Uri _source;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary()
        {
            DependencyService.Register<IResourcesLoader, ResourcesLoader>();
        }

        /// <summary>
        /// Gets or sets the type of object with which the resource dictionary is merged.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [TypeConverter(typeof(TypeTypeConverter))]
        [Obsolete("Use Source")]
        public Type MergedWith {
            get { return _mergedWith; }
            set {
                if (_mergedWith == value)
                    return;

                if (_source != null)
                    throw new ArgumentException("MergedWith can not be used with Source");

                if (!typeof(ResourceDictionary).GetTypeInfo().IsAssignableFrom(value.GetTypeInfo()))
                    throw new ArgumentException("MergedWith should inherit from ResourceDictionary");

                _mergedWith = value;
                if (_mergedWith == null)
                    return;

                _mergedInstance = s_instances.GetValue(_mergedWith, (key) => (ResourceDictionary)Activator.CreateInstance(key));
                OnValuesChanged(_mergedInstance.ToArray());
            }
        }

        /// <summary>
        /// Gets or sets the URI of the merged resource dictionary.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [TypeConverter(typeof(RDSourceTypeConverter))]
        public Uri Source {
            get { return _source; }
            set {
                if (_source == value)
                    return;
                throw new InvalidOperationException("Source can only be set from XAML."); //through the RDSourceTypeConverter
            }
        }

        /// <summary>
        /// To set and load source.
        /// </summary>
        /// <param name="value">The source.</param>
        /// <param name="resourcePath">The resource path.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="lineInfo">The xml line info.</param>
        /// Used by the XamlC compiled converter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAndLoadSource(Uri value, string resourcePath, Assembly assembly, System.Xml.IXmlLineInfo lineInfo)
        {
            _source = value;
            if (_mergedWith != null)
                throw new ArgumentException("Source can not be used with MergedWith");

            //this will return a type if the RD as an x:Class element, and codebehind
            var type = XamlResourceIdAttribute.GetTypeForPath(assembly, resourcePath);
            if (type != null)
                _mergedInstance = s_instances.GetValue(type, (key) => (ResourceDictionary)Activator.CreateInstance(key));
            else
                _mergedInstance = DependencyService.Get<IResourcesLoader>()?.CreateFromResource<ResourceDictionary>(resourcePath, assembly, lineInfo);
            OnValuesChanged(_mergedInstance.ToArray());
        }

        ICollection<ResourceDictionary> _mergedDictionaries;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICollection<ResourceDictionary> MergedDictionaries {
            get {
                if (_mergedDictionaries == null) {
                    var col = new ObservableCollection<ResourceDictionary>();
                    col.CollectionChanged += MergedDictionaries_CollectionChanged;
                    _mergedDictionaries = col;
                }
                return _mergedDictionaries;
            }
        }

        internal IList<StyleSheets.StyleSheet> StyleSheets { get; set; }

        void StyleSheetsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) {
            case NotifyCollectionChangedAction.Add:
                    ValuesChanged?.Invoke(this, ResourcesChangedEventArgs.StyleSheets);
                break;
            }
        }
        IList<ResourceDictionary> _collectionTrack;

        void MergedDictionaries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Move() isn't exposed by ICollection
            if (e.Action == NotifyCollectionChangedAction.Move)
                return;

            _collectionTrack = _collectionTrack ?? new List<ResourceDictionary>();
            // Collection has been cleared
            if (e.Action == NotifyCollectionChangedAction.Reset) {
                foreach (var dictionary in _collectionTrack)
                    dictionary.ValuesChanged -= Item_ValuesChanged;

                _collectionTrack.Clear();
                return;
            }

            // New Items
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    var rd = (ResourceDictionary)item;
                    _collectionTrack.Add(rd);
                    rd.ValuesChanged += Item_ValuesChanged;
                    OnValuesChanged(rd.ToArray());
                }
            }

            // Old Items
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    var rd = (ResourceDictionary)item;
                    rd.ValuesChanged -= Item_ValuesChanged;
                    _collectionTrack.Remove(rd);
                }
            }
        }

        void Item_ValuesChanged(object sender, ResourcesChangedEventArgs e)
        {
            OnValuesChanged(e.Values.ToArray());
        }

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)_innerDictionary).Add(item);
            OnValuesChanged(item);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            _innerDictionary.Clear();
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_innerDictionary).Contains(item)
                || (_mergedInstance != null && _mergedInstance.Contains(item));
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)_innerDictionary).CopyTo(array, arrayIndex);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count
        {
            get { return _innerDictionary.Count; }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<string, object>>)_innerDictionary).IsReadOnly; }
        }

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_innerDictionary).Remove(item);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(string key, object value)
        {
            if (ContainsKey(key))
                throw new ArgumentException($"A resource with the key '{key}' is already present in the ResourceDictionary.");
            _innerDictionary.Add(key, value);
            OnValueChanged(key, value);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContainsKey(string key)
        {
            return _innerDictionary.ContainsKey(key);
        }

        /// <summary>
        /// Gets or sets the value according to index.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IndexerName("Item")]
        public object this[string index]
        {
            get
            {
                if (_innerDictionary.ContainsKey(index))
                    return _innerDictionary[index];
                if (_mergedInstance != null && _mergedInstance.ContainsKey(index))
                    return _mergedInstance[index];
                if (MergedDictionaries != null)
                    foreach (var dict in MergedDictionaries.Reverse())
                        if (dict.ContainsKey(index))
                            return dict[index];
                throw new KeyNotFoundException($"The resource '{index}' is not present in the dictionary.");
            }
            set
            {
                _innerDictionary[index] = value;
                OnValueChanged(index, value);
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICollection<string> Keys
        {
            get { return _innerDictionary.Keys; }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove(string key)
        {
            return _innerDictionary.Remove(key);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICollection<object> Values
        {
            get { return _innerDictionary.Values; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }

        internal IEnumerable<KeyValuePair<string, object>> MergedResources {
            get {
                if (MergedDictionaries != null)
                    foreach (var r in MergedDictionaries.Reverse().SelectMany(x => x.MergedResources))
                        yield return r;
                if (_mergedInstance != null)
                    foreach (var r in _mergedInstance.MergedResources)
                        yield return r;
                foreach (var r in _innerDictionary)
                    yield return r;
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryGetValue(string key, out object value)
        {
            return _innerDictionary.TryGetValue(key, out value)
                || (_mergedInstance != null && _mergedInstance.TryGetValue(key, out value))
                || (MergedDictionaries != null && TryGetMergedDictionaryValue(key, out value));
        }

        bool TryGetMergedDictionaryValue(string key, out object value)
        {
            foreach (var dictionary in MergedDictionaries.Reverse())
                if (dictionary.TryGetValue(key, out value))
                    return true;

            value = null;
            return false;
        }

        event EventHandler<ResourcesChangedEventArgs> IResourceDictionary.ValuesChanged
        {
            add { ValuesChanged += value; }
            remove { ValuesChanged -= value; }
        }

        internal void Add(Style style)
        {
            if (string.IsNullOrEmpty(style.Class))
                Add(style.TargetType.FullName, style);
            else
            {
                IList<Style> classes;
                object outclasses;
                if (!TryGetValue(Style.StyleClassPrefix + style.Class, out outclasses) || (classes = outclasses as IList<Style>) == null)
                    classes = new List<Style>();
                classes.Add(style);
                this[Style.StyleClassPrefix + style.Class] = classes;
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(ResourceDictionary mergedResourceDictionary)
        {
            MergedDictionaries.Add(mergedResourceDictionary);
        }

        internal void Add(StyleSheets.StyleSheet styleSheet)
        {
            StyleSheets = StyleSheets ?? new List<StyleSheets.StyleSheet>(2);
            StyleSheets.Add(styleSheet);
            ValuesChanged?.Invoke(this, ResourcesChangedEventArgs.StyleSheets);
        }

        void OnValueChanged(string key, object value)
        {
            OnValuesChanged(new KeyValuePair<string, object>(key, value));
        }

        void OnValuesChanged(params KeyValuePair<string, object>[] values)
        {
            if (values == null || values.Length == 0)
                return;
            ValuesChanged?.Invoke(this, new ResourcesChangedEventArgs(values));
        }

        event EventHandler<ResourcesChangedEventArgs> ValuesChanged;

        [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.RDSourceTypeConverter")]
        internal class RDSourceTypeConverter : TypeConverter, IExtendedTypeConverter
        {
            object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
            {
                if (serviceProvider == null)
                    throw new ArgumentNullException(nameof(serviceProvider));

                var targetRD = (serviceProvider.GetService(typeof(Xaml.IProvideValueTarget)) as Xaml.IProvideValueTarget)?.TargetObject as ResourceDictionary;
                if (targetRD == null)
                    return null;

                var rootObjectType = (serviceProvider.GetService(typeof(Xaml.IRootObjectProvider)) as Xaml.IRootObjectProvider)?.RootObject.GetType();
                if (rootObjectType == null)
                    return null;

                var lineInfo = (serviceProvider.GetService(typeof(Xaml.IXmlLineInfoProvider)) as Xaml.IXmlLineInfoProvider)?.XmlLineInfo;
                var rootTargetPath = XamlResourceIdAttribute.GetPathForType(rootObjectType);
                var uri = new Uri(value, UriKind.Relative); //we don't want file:// uris, even if they start with '/'
                var resourcePath = GetResourcePath(uri, rootTargetPath);

                targetRD.SetAndLoadSource(uri, resourcePath, rootObjectType.GetTypeInfo().Assembly, lineInfo);
                return uri;
            }

            internal static string GetResourcePath(Uri uri, string rootTargetPath)
            {
                //need a fake scheme so it's not seen as file:// uri, and the forward slashes are valid on all plats
                var resourceUri = uri.OriginalString.StartsWith("/", StringComparison.Ordinal)
                                     ? new Uri($"pack://{uri.OriginalString}", UriKind.Absolute)
                                     : new Uri($"pack:///{rootTargetPath}/../{uri.OriginalString}", UriKind.Absolute);

                //drop the leading '/'
                return resourceUri.AbsolutePath.Substring(1);
            }

            object IExtendedTypeConverter.ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider)
            {
                throw new NotImplementedException();
            }

            public override object ConvertFromInvariantString(string value)
            {
                throw new NotImplementedException();
            }
        }
    }
}
