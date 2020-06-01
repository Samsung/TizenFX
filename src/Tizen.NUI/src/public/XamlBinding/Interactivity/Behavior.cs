
using System.ComponentModel;
using System.Reflection;

namespace Tizen.NUI.Binding
{
    using global::System;

    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Behavior : BindableObject, IAttachedObject
    {
        internal Behavior(Type associatedType)
        {
            if (associatedType == null)
                throw new ArgumentNullException("associatedType");
            AssociatedType = associatedType;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnAttachedTo(BindableObject bindable)
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnDetachingFrom(BindableObject bindable)
        {
        }
    }

    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Behavior<T> : Behavior where T : BindableObject
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Behavior() : base(typeof(T))
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            OnAttachedTo((T)bindable);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnAttachedTo(T bindable)
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            OnDetachingFrom((T)bindable);
            base.OnDetachingFrom(bindable);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnDetachingFrom(T bindable)
        {
        }
    }
}