using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using Tizen.NUI.XamlBinding.Internals;
using Tizen.NUI;
using Tizen.NUI.Xaml;

namespace Tizen.NUI
{
    /// <summary>
    /// A class to get resources in current application.
    /// </summary>
    /// Deprecated. Do not use.
    public class GetResourcesProvider
    {
        /// <summary>
        /// Get resources in current application.
        /// </summary>
        /// Deprecated. Do not use.
        static public Tizen.NUI.Binding.IResourcesProvider Get()
        {
            return Tizen.NUI.XamlBinding.Application.Current;
        }
    }
}

namespace Tizen.NUI.XamlBinding
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Application : Element, Tizen.NUI.Binding.IResourcesProvider, IElementConfiguration<Application>
    {
        private NUIApplication application;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Run(string[] args)
        {
            application.Run(args);
        }

        static Application s_current;
        Task<IDictionary<string, object>> _propertiesTask;
        readonly Lazy<PlatformConfigurationRegistry<Application>> _platformConfigurationRegistry;

        ReadOnlyCollection<Element> _logicalChildren;

        Page _mainPage;

        static SemaphoreSlim SaveSemaphore = new SemaphoreSlim(1, 1);

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Application()
        {
            application = new NUIApplication();
            application.Created += (object sender, EventArgs e) =>
            {
                Device.PlatformServices = new TizenPlatformServices();
                OnCreate();
            };

            SetCurrentApplication(this);
            _platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<Application>>(() => new PlatformConfigurationRegistry<Application>(this));
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Quit()
        {
            Device.PlatformServices?.QuitApplication();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static void SetCurrentApplication(Application value) => Current = value;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Application Current
        {
            get { return s_current; }
            set
            {
                if (s_current == value)
                    return;
                if (value == null)
                    s_current = null; //Allow to reset current for unittesting
                s_current = value;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page MainPage
        {
            get { return _mainPage; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (_mainPage == value)
                    return;

                OnPropertyChanging();
                if (_mainPage != null)
                {
                    InternalChildren.Remove(_mainPage);
                    _mainPage.Parent = null;
                }

                _mainPage = value;

                if (_mainPage != null)
                {
                    _mainPage.Parent = this;
                    //_mainPage.NavigationProxy.Inner = NavigationProxy;
                    InternalChildren.Add(_mainPage);
                }
                OnPropertyChanged();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> Properties
        {
            get
            {
                if (_propertiesTask == null)
                {
                    _propertiesTask = GetPropertiesAsync();
                }

                return _propertiesTask.Result;
            }
        }

        internal override ReadOnlyCollection<Element> LogicalChildrenInternal
        {
            get { return _logicalChildren ?? (_logicalChildren = new ReadOnlyCollection<Element>(InternalChildren)); }
        }

        internal IResourceDictionary SystemResources { get; }

        ObservableCollection<Element> InternalChildren { get; } = new ObservableCollection<Element>();

        ResourceDictionary _resources;
        bool Tizen.NUI.Binding.IResourcesProvider.IsResourcesCreated => _resources != null;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
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

        async void SaveProperties()
        {
            try
            {
                await SetPropertiesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(nameof(Application), $"Exception while saving Application Properties: {exc}");
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task SavePropertiesAsync()
        {
            if (Device.IsInvokeRequired)
            {
                Device.BeginInvokeOnMainThread(SaveProperties);
            }
            else
            {
                await SetPropertiesAsync();
            }
        }

        // Don't use this unless there really is no better option
        internal void SavePropertiesAsFireAndForget()
        {
            if (Device.IsInvokeRequired)
            {
                Device.BeginInvokeOnMainThread(SaveProperties);
            }
            else
            {
                SaveProperties();
            }
        }

        protected virtual void OnAppLinkRequestReceived(Uri uri)
        {
        }

        protected override void OnParentSet()
        {
            throw new InvalidOperationException("Setting a Parent on Application is invalid.");
        }

        protected virtual void OnResume()
        {
        }

        protected virtual void OnSleep()
        {
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnCreate()
        {

        }

        /// <summary>
        /// Reset current application to null
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ClearCurrent()
        {
            s_current = null;
        }

        /// <summary>
        /// Judge wheather element is a application
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsApplicationOrNull(Element element)
        {
            return element == null || element is Application;
        }

        internal override void OnParentResourcesChanged(IEnumerable<KeyValuePair<string, object>> values)
        {
            if (!((Tizen.NUI.Binding.IResourcesProvider)this).IsResourcesCreated || XamlResources.Count == 0)
            {
                base.OnParentResourcesChanged(values);
                return;
            }

            var innerKeys = new HashSet<string>();
            var changedResources = new List<KeyValuePair<string, object>>();
            foreach (KeyValuePair<string, object> c in XamlResources)
                innerKeys.Add(c.Key);
            foreach (KeyValuePair<string, object> value in values)
            {
                if (innerKeys.Add(value.Key))
                    changedResources.Add(value);
            }
            OnResourcesChanged(changedResources);
        }

        /// <summary>
        /// Send application's link uri.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendOnAppLinkRequestReceived(Uri uri)
        {
            OnAppLinkRequestReceived(uri);
        }

        /// <summary>
        /// Resume
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendResume()
        {
            s_current = this;
            OnResume();
        }

        /// <summary>
        /// Sleep
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendSleep()
        {
            OnSleep();
            SavePropertiesAsFireAndForget();
        }

        /// <summary>
        /// Sleep asyncly
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task SendSleepAsync()
        {
            OnSleep();
            return SavePropertiesAsync();
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendStart()
        {
            OnStart();
        }

        async Task<IDictionary<string, object>> GetPropertiesAsync()
        {
            var deserializer = DependencyService.Get<IDeserializer>();
            if (deserializer == null)
            {
                Console.WriteLine("Startup", "No IDeserialzier was found registered");
                return new Dictionary<string, object>(4);
            }

            IDictionary<string, object> properties = await deserializer.DeserializePropertiesAsync().ConfigureAwait(false);
            if (properties == null)
                properties = new Dictionary<string, object>(4);

            return properties;
        }

        async Task SetPropertiesAsync()
        {
            await SaveSemaphore.WaitAsync();
            try
            {
                await DependencyService.Get<IDeserializer>().SerializePropertiesAsync(Properties);
            }
            finally
            {
                SaveSemaphore.Release();
            }

        }
    }
}