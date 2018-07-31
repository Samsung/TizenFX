using System;

namespace Tizen.NUI.Binding
{
    internal abstract class TriggerAction
    {
        internal TriggerAction(Type associatedType)
        {
            if (associatedType == null)
                throw new ArgumentNullException("associatedType");
            AssociatedType = associatedType;
        }

        protected Type AssociatedType { get; private set; }

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