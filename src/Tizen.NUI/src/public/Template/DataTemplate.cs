using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DataTemplate : ElementTemplate
    {
        /// <summary>
        /// Base constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate()
        {
        }

        /// <summary>
        /// Base constructor with specific Type.
        /// </summary>
        /// <param name="type">The Type of content.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate(Type type) : base(type)
        {
        }

        /// <summary>
        /// Base constructor with loadTemplate function.
        /// </summary>
        /// <param name="loadTemplate">The function of loading templated object.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate(Func<object> loadTemplate) : base(loadTemplate)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<BindableProperty, BindingBase> Bindings { get; } = new Dictionary<BindableProperty, BindingBase>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<BindableProperty, object> Values { get; } = new Dictionary<BindableProperty, object>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBinding(BindableProperty property, BindingBase binding)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (binding == null)
                throw new ArgumentNullException(nameof(binding));

            Values.Remove(property);
            Bindings[property] = binding;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValue(BindableProperty property, object value)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            Bindings.Remove(property);
            Values[property] = value;
        }

        internal override void SetupContent(object item)
        {
            ApplyBindings(item);
            ApplyValues(item);
        }

        void ApplyBindings(object item)
        {
            if (Bindings == null)
                return;

            var bindable = item as BindableObject;
            if (bindable == null)
                return;

            foreach (KeyValuePair<BindableProperty, BindingBase> kvp in Bindings)
            {
                if (Values.ContainsKey(kvp.Key))
                    throw new InvalidOperationException("Binding and Value found for " + kvp.Key.PropertyName);

                bindable.SetBinding(kvp.Key, kvp.Value.Clone());
            }
        }

        void ApplyValues(object item)
        {
            if (Values == null)
                return;

            var bindable = item as BindableObject;
            if (bindable == null)
                return;
            foreach (KeyValuePair<BindableProperty, object> kvp in Values)
                bindable.SetValue(kvp.Key, kvp.Value);
        }
    }
}
