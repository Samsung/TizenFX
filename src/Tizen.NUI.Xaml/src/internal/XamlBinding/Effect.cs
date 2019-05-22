using System;
using System.ComponentModel;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// A collection of styles and properties that can be added to an element at run time.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract class Effect
    {
        internal Effect()
        {
        }

        /// <summary>
        /// Gets the element to which the style is attached.
        /// </summary>
        public Element Element { get; internal set; }

        /// <summary>
        /// Gets a value that tells whether the effect is attached to an element.
        /// </summary>
        public bool IsAttached { get; private set; }

        /// <summary>
        /// Gets the ID that is used to resolve this effect at runtime.
        /// </summary>
        public string ResolveId { get; internal set; }

        #region Statics
        /// <summary>
        /// Returns an Effect for the specified name, which is of the form ResolutionGroupName.ExportEffect.
        /// </summary>
        /// <param name="name">The name of the effect to get.</param>
        /// <returns>The uniquely identified effect.</returns>
        public static Effect Resolve(string name)
        {
            Effect result = null;
            if (Tizen.NUI.Binding.Internals.Registrar.Effects.TryGetValue(name, out Type effectType))
            {
                result = (Effect)DependencyResolver.ResolveOrCreate(effectType);
            }

            if (result == null)
                result = new NullEffect();
            result.ResolveId = name;
            return result;
        }

        #endregion

        /// <summary>
        /// Method that is called after the effect is attached and made valid.
        /// </summary>
        protected abstract void OnAttached();

        /// <summary>
        /// Method that is called after the effect is detached and invalidated.
        /// </summary>
        protected abstract void OnDetached();

        internal virtual void ClearEffect()
        {
            if (IsAttached)
                SendDetached();
            Element = null;
        }

        internal virtual void SendAttached()
        {
            if (IsAttached)
                return;
            OnAttached();
            IsAttached = true;
        }

        internal virtual void SendDetached()
        {
            if (!IsAttached)
                return;
            OnDetached();
            IsAttached = false;
        }

        internal virtual void SendOnElementPropertyChanged(PropertyChangedEventArgs args)
        {
        }
    }
}
