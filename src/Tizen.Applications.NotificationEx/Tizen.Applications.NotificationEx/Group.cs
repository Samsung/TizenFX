using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Group : AbstractItem
        {
            private IList<AbstractItem> _children;
            public Group(string id) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.GroupCreate(out handle, id);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Group(IntPtr ptr) : base(ptr)
            {
            }

            public bool IsVertical
            {
                get
                {
                    bool isVertical;
                    Interop.NotificationEx.GroupIsVertical(NativeHandle, out isVertical);
                    return isVertical;
                }
                set
                {
                    Interop.NotificationEx.GroupSetDirection(NativeHandle, value);
                }
            }

            public string AppLabel
            {
                get
                {
                    string label = "";
                    Interop.NotificationEx.GroupGetAppLabel(NativeHandle, out label);                    
                    return label;
                }
            }

            internal override void Serialize()
            {
                base.Serialize();
                if (_children != null)
                    Children = _children;
            }

            public IList<AbstractItem> Children
            {
                get
                {
                    if (_children != null)
                        return _children;

                    _children = new List<AbstractItem>();
                    Interop.NotificationEx.GroupForeachChildCallback callback = (IntPtr handle, IntPtr userData) =>
                    {
                        _children.Add(FactoryManager.CreateItem(handle));
                        return 0;
                    };
                    Interop.NotificationEx.GroupForeachChild(NativeHandle, callback, IntPtr.Zero);
                    return _children;
                }
                set
                {
                    Interop.NotificationEx.GroupRemoveChildren(NativeHandle);
                    for (int i = 0; i < value.Count; i++)
                    {
                        Interop.NotificationEx.GroupAddChild(NativeHandle, value[i].NativeHandle);
                    }
                    _children = value;
                }
            }

            public void AddChild(AbstractItem item)
            {
                if (_children == null)
                    _children = new List<AbstractItem>();
                Interop.NotificationEx.GroupAddChild(NativeHandle, item.NativeHandle);
                _children.Add(item);
            }

            public void RemoveChild(string itemId)
            {
                if (_children == null)
                    _children = new List<AbstractItem>();
                Interop.NotificationEx.GroupRemoveChild(NativeHandle, itemId);
                for (int i = 0; i < _children.Count; i++)
                {
                    if (_children[i].Id == itemId)
                    {
                        _children.Remove(_children[i]);
                        break;
                    }                        
                }
            }
        }
    }
}
