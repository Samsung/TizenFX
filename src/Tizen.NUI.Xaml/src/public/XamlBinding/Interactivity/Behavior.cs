using System;
using System.ComponentModel;
using System.Reflection;

namespace Tizen.NUI.XamlBinding
{
    /// <summary>
    /// The class Behavior.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Behavior : BindableObject, IAttachedObject
    {
        internal Behavior(Type associatedType)
        {
            if (associatedType == null)
                throw new ArgumentNullException("associatedType");
            AssociatedType = associatedType;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Type AssociatedType { get; }

        void IAttachedObject.AttachTo(BindableObject bindable)
        {
            if (bindable == null)
                throw new ArgumentNullException("bindable");
            if (!AssociatedType.IsInstanceOfType(bindable))
                throw new InvalidOperationException("bindable not an instance of AssociatedType");
            OnAttachedTo(bindable);
        }

        void IAttachedObject.DetachFrom(BindableObject bindable)
        {
            OnDetachingFrom(bindable);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnAttachedTo(BindableObject bindable)
        {
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnDetachingFrom(BindableObject bindable)
        {
        }
    }

    internal abstract class Behavior<T> : Behavior where T : BindableObject
    {
        protected Behavior() : base(typeof(T))
        {
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            OnAttachedTo((T)bindable);
        }

        protected virtual void OnAttachedTo(T bindable)
        {
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            OnDetachingFrom((T)bindable);
            base.OnDetachingFrom(bindable);
        }

        protected virtual void OnDetachingFrom(T bindable)
        {
        }
    }
}