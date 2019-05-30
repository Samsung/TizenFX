using System;
using System.ComponentModel;

namespace Tizen.NUI.XamlBinding
{
    /// <summary>
    /// The class TriggerAction.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TriggerAction
    {
        internal TriggerAction(Type associatedType)
        {
            if (associatedType == null)
                throw new ArgumentNullException("associatedType");
            AssociatedType = associatedType;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Type AssociatedType { get; private set; }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected abstract void Invoke(object sender);

        internal virtual void DoInvoke(object sender)
        {
            Invoke(sender);
        }
    }

    internal abstract class TriggerAction<T> : TriggerAction where T : BindableObject
    {
        protected TriggerAction() : base(typeof(T))
        {
        }

        protected override void Invoke(object sender)
        {
            Invoke((T)sender);
        }

        protected abstract void Invoke(T sender);
    }
}