using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// The class EventTrigger.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Actions")]
    public sealed class EventTrigger : TriggerBase
    {
        static readonly MethodInfo s_handlerinfo = typeof(EventTrigger).GetRuntimeMethods().Single(mi => mi.Name == "OnEventTriggered" && mi.IsPublic == false);
        readonly List<BindableObject> _associatedObjects = new List<BindableObject>();

        EventInfo _eventinfo;

        string _eventname;
        Delegate _handlerdelegate;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EventTrigger() : base(typeof(BindableObject))
        {
            Actions = new SealedList<TriggerAction>();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<TriggerAction> Actions { get; }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Event
        {
            get { return _eventname; }
            set
            {
                if (_eventname == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Event cannot be changed once the Trigger has been applied");
                OnPropertyChanging();
                _eventname = value;
                OnPropertyChanged();
            }
        }

        internal override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            if (!string.IsNullOrEmpty(Event))
                AttachHandlerTo(bindable);
            _associatedObjects.Add(bindable);
        }

        internal override void OnDetachingFrom(BindableObject bindable)
        {
            _associatedObjects.Remove(bindable);
            DetachHandlerFrom(bindable);
            base.OnDetachingFrom(bindable);
        }

        internal override void OnSeal()
        {
            base.OnSeal();
            ((SealedList<TriggerAction>)Actions).IsReadOnly = true;
        }

        void AttachHandlerTo(BindableObject bindable)
        {
            try
            {
                _eventinfo = bindable.GetType().GetRuntimeEvent(Event);
                _handlerdelegate = s_handlerinfo.CreateDelegate(_eventinfo?.EventHandlerType, this);
            }
            catch (Exception)
            {
                Console.WriteLine("EventTrigger", "Can not attach EventTrigger to {0}.{1}. Check if the handler exists and if the signature is right.", bindable.GetType(), Event);
            }
            if (_eventinfo != null && _handlerdelegate != null)
                _eventinfo.AddEventHandler(bindable, _handlerdelegate);
        }

        void DetachHandlerFrom(BindableObject bindable)
        {
            if (_eventinfo != null && _handlerdelegate != null)
                _eventinfo.RemoveEventHandler(bindable, _handlerdelegate);
        }

        // [Preserve]
        void OnEventTriggered(object sender, EventArgs e)
        {
            var bindable = (BindableObject)sender;
            foreach (TriggerAction action in Actions)
                action.DoInvoke(bindable);
        }
    }
}