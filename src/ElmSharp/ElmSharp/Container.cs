using System;
using System.Collections.Generic;

namespace ElmSharp
{
    public abstract class Container : Widget
    {
        HashSet<EvasObject> _children = new HashSet<EvasObject>();

        public Container(EvasObject parent) : base(parent)
        {
        }

        internal void AddChild(EvasObject obj)
        {
            _children.Add(obj);
            obj.Deleted += OnChildDeleted;
        }

        internal void RemoveChild(EvasObject obj)
        {
            _children.Remove(obj);
        }

        internal void ClearChildren()
        {
            _children.Clear();
        }

        void OnChildDeleted(object sender, EventArgs a)
        {
            _children.Remove((EvasObject)sender);
        }
    }
}
