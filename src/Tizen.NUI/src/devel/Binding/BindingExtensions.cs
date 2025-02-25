using System;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Provides extension methods for binding properties of a view model to a view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class BindingExtensions
    {
        /// <summary>
        /// Sets the binding for the specified view model property.
        /// </summary>
        /// <typeparam name="T">The type of the view model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view to bind to.</param>
        /// <param name="vm">The view model to bind from.</param>
        /// <param name="set">The action to set the view property.</param>
        /// <param name="path">The path of the view model property.</param>
        /// <returns>The view.</returns>
        public static TView SetBinding<T, TView>(this TView view, BindingSession<T> vm, Action<T, TView> set, string path) where TView : View
        {
            _ = view ?? throw new ArgumentNullException(nameof(view));

            var setter = new Action<T>(vm =>
            {
                set.Invoke(vm, view);
            });
            vm.AddBinding(setter, path);
            return view;
        }

        /// <summary>
        /// Sets the binding for the specified view model property.
        /// </summary>
        /// <typeparam name="T">The type of the view model.</typeparam>
        /// <param name="view">The view to bind to.</param>
        /// <param name="vm">The view model to bind from.</param>
        /// <param name="set">The action to set the view property.</param>
        /// <param name="path">The path of the view model property.</param>
        /// <returns>The view.</returns>
        public static View SetBinding<T>(this View view, BindingSession<T> vm, Action<T> set, string path)
        {
            vm.AddBinding(set, path);
            return view;
        }

        /// <summary>
        /// Sets the binding for the specified view model property.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="view">The view to bind to.</param>
        /// <param name="session">The binding session.</param>
        /// <param name="targetPath">The path of the view property.</param>
        /// <param name="srcPath">The path of the view model property.</param>
        /// <returns>The view.</returns>
        public static View SetBinding<TViewModel>(this View view, BindingSession<TViewModel> session, string targetPath, string srcPath)
        {
            var setter = new Action<TViewModel>(model =>
            {
                if (view.Disposed)
                {
                    return;
                }
                var prop = view.GetType().GetProperty(targetPath, BindingFlags.Public | BindingFlags.Instance);
                prop.SetValue(view, session.GetValue(srcPath));
            });
            session.AddBinding(setter, srcPath);
            return view;
        }

        /// <summary>
        /// Sets the binding for the specified view model property.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TProperty">The type of the view property.</typeparam>
        /// <param name="view">The view to bind to.</param>
        /// <param name="session">The binding session.</param>
        /// <param name="property">The view property.</param>
        /// <param name="path">The path of the view model property.</param>
        /// <returns>The view.</returns>
        public static TView SetBinding<TView, TViewModel, TProperty>(this TView view, BindingSession<TViewModel> session, BindingProperty<TView, TProperty> property, string path) where TView : View
        {
            var setter = new Action<TViewModel>(model =>
            {
                if (view.Disposed)
                {
                    return;
                }

                var value = session.GetValue(path);
                // need to apply convertor if type was not mached
                if (value != null && !typeof(TProperty).IsAssignableFrom(value.GetType()))
                {
                    // only string type convert with ToString()
                    if (typeof(TProperty) == typeof(string))
                    {
                        value = value.ToString();
                    }
                    else
                    {
                        throw new InvalidCastException($"Cannot cast {value.GetType()} to {typeof(TProperty)}");
                    }
                }
                property.Setter(view, (TProperty)value);
            });
            session.AddBinding(setter, path);
            return view;
        }

        /// <summary>
        /// Sets the two-way binding for the specified view model property.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TProperty">The type of the view property.</typeparam>
        /// <param name="view">The view to bind to.</param>
        /// <param name="session">The binding session.</param>
        /// <param name="property">The view property.</param>
        /// <param name="path">The path of the view model property.</param>
        /// <returns>The view.</returns>
        public static View SetTwoWayBinding<TViewModel, TProperty>(this View view, BindingSession<TViewModel> session, TwoWayBindingProperty<View, TProperty> property, string path)
        {
            var regit = new Action<Action>(act =>
            {
                property.AddObserver(view, act);
            });
            var unregit = new Action<Action>(act =>
            {
                property.RemoveObserver(view, act);
            });
            var setter = new Action<TViewModel>(model =>
            {
                if (view.Disposed)
                {
                    return;
                }
                property.Setter(view, (TProperty)session.GetValue(path));
            });
            var getter = new Func<TProperty>(() => property.Getter(view));
            session.AddTwoWayBinding(regit, unregit, setter, getter, path);
            return view;
        }

        /// <summary>
        /// Sets the two-way binding for the specified view model property.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TProperty">The type of the view property.</typeparam>
        /// <param name="view">The to.</param>
        /// <param name="session">The binding session.</param>
        /// <param name="property">The view property.</param>
        /// <param name="path">The path of the view model property.</param>
        /// <returns>The view.</returns>
        public static TView SetTwoWayBinding<TView, TViewModel, TProperty>(this TView view, BindingSession<TViewModel> session, TwoWayBindingProperty<TView, TProperty> property, string path) where TView : View
        {
            var regit = new Action<Action>(act =>
            {
                property.AddObserver(view, act);
            });
            var unregit = new Action<Action>(act =>
            {
                property.RemoveObserver(view, act);
            });
            var setter = new Action<TViewModel>(model =>
            {
                if (view.Disposed)
                {
                    return;
                }
                property.Setter(view, (TProperty)session.GetValue(path));
            });
            var getter = new Func<TProperty>(() => property.Getter(view));
            session.AddTwoWayBinding(regit, unregit, setter, getter, path);
            return view;
        }

        /// <summary>
        /// Gets the binding session for the specified view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="view">The view.</param>
        /// <returns>The binding session.</returns>
        public static BindingSession<TViewModel> BindingSession<TViewModel>(this View view)
        {
            return view.GetAttached<BindingSession<TViewModel>>();
        }

        /// <summary>
        /// Sets the binding session for the specified view.
        /// </summary>
        /// <typeparam name="T">The type of the view model.</typeparam>
        /// <typeparam name="TViewModel">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        /// <param name="session">The binding session.</param>
        /// <returns>The view.</returns>
        public static T BindingSession<T, TViewModel>(this T view, BindingSession<TViewModel> session) where T : View
        {
            view.SetAttached(session);
            return view;
        }
    }
}