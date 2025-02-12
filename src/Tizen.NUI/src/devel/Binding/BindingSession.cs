using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// BindingSession class provides a mechanism for binding properties of a view model to a view.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BindingSession<TViewModel> : INotifyPropertyChanged, IDisposable
    {
        private List<Action> _bindingActions = new List<Action>();
        private List<PropertyChangedEventHandler> _changedAction = new List<PropertyChangedEventHandler>();
        private Dictionary<Action, Action<Action>> _observers = new Dictionary<Action, Action<Action>>();
        private TViewModel _viewmodel;
        private bool _disposed;

        /// <summary>
        /// Represents an event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public TViewModel ViewModel
        {
            get => _viewmodel;
            set
            {
                if (_viewmodel != null && _viewmodel is INotifyPropertyChanged noti)
                {
                    noti.PropertyChanged -= OnPropertyChanged;
                }
                _viewmodel = value;

                if (_viewmodel != null && _viewmodel is INotifyPropertyChanged newobj)
                {
                    newobj.PropertyChanged += OnPropertyChanged;
                }

                UpdateViewModel();
            }
        }

        /// <summary>
        /// Updates the view model.
        /// </summary>
        /// <param name="vm">The view model to update.</param>
        public void UpdateViewModel(TViewModel vm)
        {
            ViewModel = vm;
        }

        /// <summary>
        /// Updates the view model.
        /// </summary>
        public void UpdateViewModel()
        {
            foreach (var action in _bindingActions)
            {
                action.Invoke();
            }
        }

        /// <summary>
        /// Adds a binding between a property of the view model and a property of the view.
        /// </summary>
        /// <param name="setter">The setter method of the view.</param>
        /// <param name="path">The path of the property to bind.</param>
        public void AddBinding(Action<TViewModel> setter, string path)
        {
            var action = new Action(() =>
            {
                if (ViewModel != null)
                    setter(ViewModel);
            });
            _bindingActions.Add(action);
            PropertyChangedEventHandler handler = (s, e) =>
            {
                if (path == "*" || e.PropertyName == path || e.PropertyName == "*")
                {
                    action();
                }
            };
            _changedAction.Add(handler);
            PropertyChanged += handler;
            action.Invoke();
        }

        /// <summary>
        /// Adds a two-way binding between a property of the view model and a property of the view.
        /// </summary>
        /// <typeparam name="T">The type of the property to bind.</typeparam>
        /// <param name="register">The registration method of the observer.</param>
        /// <param name="unregister">The unregistration method of the observer.</param>
        /// <param name="setter">The setter method of the view.</param>
        /// <param name="getter">The getter method of the view.</param>
        /// <param name="path">The path of the property to bind.</param>
        public void AddTwoWayBinding<T>(Action<Action> register, Action<Action> unregister, Action<TViewModel> setter, Func<T> getter, string path)
        {
            var action = new Action(() =>
            {
                if (ViewModel != null)
                    SetValue(getter(), path);
            });
            _observers[action] = unregister;
            register(action);
            AddBinding(setter, path);
        }

        /// <summary>
        /// Clears all bindings.
        /// </summary>
        public void ClearBinding()
        {
            foreach (var evtHandler in _changedAction)
            {
                PropertyChanged -= evtHandler;
            }
            foreach (var observer in _observers)
            {
                observer.Value.Invoke(observer.Key);
            }
            _observers.Clear();
            _changedAction.Clear();
            _bindingActions.Clear();
        }

        /// <summary>
        /// Gets the value of a property of the view model.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public object GetValue(string name)
        {
            if (name == ".")
                return ViewModel;

            var prop = ViewModel.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
            {
                Log.Error("NUI", $"Binding : Property {name} not found");
            }
            return prop?.GetValue(ViewModel) ?? null;
        }

        /// <summary>
        /// Sets the value of a property of the view model.
        /// </summary>
        /// <param name="obj">The value to set.</param>
        /// <param name="name">The name of the property.</param>
        public void SetValue(object obj, string name)
        {
            var prop = ViewModel.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
            prop?.SetValue(ViewModel, obj);
        }

        /// <summary>
        /// Releases all resources used by the current instance of the BindingSession class.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Provides a mechanism for releasing unmanaged resources used by the BindingSession class.
        /// </summary>
        /// <param name="disposing">True if the method is called from Dispose, false if it is called from the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ClearBinding();
                }
                _disposed = true;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}