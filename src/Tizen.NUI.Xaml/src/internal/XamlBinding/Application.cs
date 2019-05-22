using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    public class Application : Element, IResourcesProvider, IElementConfiguration<Application>
    {
        private NUIApplication application;

        public void Run(string[] args)
        {
            application.Run(args);
        }

        static Application s_current;
        Task<IDictionary<string, object>> _propertiesTask;
        readonly Lazy<PlatformConfigurationRegistry<Application>> _platformConfigurationRegistry;

        IAppIndexingProvider _appIndexProvider;

        ReadOnlyCollection<Element> _logicalChildren;

        Page _mainPage;

        static SemaphoreSlim SaveSemaphore = new SemaphoreSlim(1, 1);

        public Application()
        {
            // var f = false;
            // if (f)
            // 	Loader.Load();
            application = new NUIApplication();
            application.Created += (object sender, EventArgs e) =>
            {
                Device.PlatformServices = new TizenPlatformServices();
                OnCreate();
            };

            SetCurrentApplication(this);

            //SystemResources = DependencyService.Get<ISystemResourcesProvider>().GetSystemResources();
            //SystemResources.ValuesChanged += OnParentResourcesChanged;
            _platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<Application>>(() => new PlatformConfigurationRegistry<Application>(this));
        }

        public void Quit()
        {
            Device.PlatformServices?.QuitApplication();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetCurrentApplication(Application value) => Current = value;

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
        bool IResourcesProvider.IsResourcesCreated => _resources != null;

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ClearCurrent()
        {
            s_current = null;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsApplicationOrNull(Element element)
        {
            return element == null || element is Application;
        }

        internal override void OnParentResourcesChanged(IEnumerable<KeyValuePair<string, object>> values)
        {
            if (!((IResourcesProvider)this).IsResourcesCreated || XamlResources.Count == 0)
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

        internal event EventHandler PopCanceled;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendOnAppLinkRequestReceived(Uri uri)
        {
            OnAppLinkRequestReceived(uri);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendResume()
        {
            s_current = this;
            OnResume();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendSleep()
        {
            OnSleep();
            SavePropertiesAsFireAndForget();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task SendSleepAsync()
        {
            OnSleep();
            return SavePropertiesAsync();
        }

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