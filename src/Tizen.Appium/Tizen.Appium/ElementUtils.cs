using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;
using EvasObject = ElmSharp.EvasObject;

namespace Tizen.Appium
{
    internal class ElementUtils
    {
        static IDictionary<string, ElementWrapper> _elements = new Dictionary<string, ElementWrapper>();

        internal static void AddElement(Element element)
        {
            if (!String.IsNullOrEmpty(element.AutomationId))
            {
                _elements[element.AutomationId] = new ElementWrapper(element);
                Log.Debug("[Added] id=" + element.AutomationId + ", element=" + element.GetType() + ", _elements.Count=" + _elements.Count);
            }
        }

        internal static void AddItemContext(ItemContext item)
        {
            if (!String.IsNullOrEmpty(item.Cell.AutomationId))
            {
                _elements[item.Cell.AutomationId] = new ElementWrapper(item);
                Log.Debug("[Added] id=" + item.Cell.AutomationId + ", item.Cell=" + item.Cell.GetType() + ", _elements.Count=" + _elements.Count);
            }
        }

        internal static void RemoveElementById(string id)
        {
            if (_elements.ContainsKey(id))
            {
                _elements.Remove(id);
                Log.Debug("[Removed] id=" + id + ", _elements.Count=" + _elements.Count);
            }
        }

        internal static void RemoveElement(Element element)
        {
            if (!String.IsNullOrEmpty(element.AutomationId) && _elements.ContainsKey(element.AutomationId))
            {
                _elements.Remove(element.AutomationId);
                Log.Debug("[Removed] id=" + element.AutomationId + ", element=" + element.GetType() + ", _elements.Count=" + _elements.Count);
            }
        }

        internal static void RemoveItemContext(ItemContext item)
        {
            RemoveElement(item.Cell);
        }

        internal static void ResetToolbarItems()
        {
            var oldItemKeys = _elements.Where(kv => kv.Value.Element is ToolbarItem).Select(kv => kv.Key).ToList();

            Log.Debug("[Reset toolbar] oldKeys= " + oldItemKeys);

            foreach (var key in oldItemKeys)
            {
                _elements.Remove(key);
            }
            Log.Debug("[Reset toolbar] _elements.Count=" + _elements.Count);
        }

        internal static ElementWrapper GetElementWrapper(string id)
        {
            Log.Debug("[GetElement] _elements.ContainsKey? " + _elements.ContainsKey(id) + ", _elements.Count=" + _elements.Count);

            ElementWrapper value = null;
            _elements.TryGetValue(id, out value);

            return value;
        }

        internal static string GetIdByElement(object element)
        {
            return _elements.FirstOrDefault(kv => kv.Value.Element == element).Key;
        }

        internal class ElementWrapper
        {
            WeakReference _element;
            string _id;

            public Element Element
            {
                get
                {
                    if (_element.IsAlive)
                    {
                        if (_element.Target is VisualElement)
                        {
                            return (VisualElement)_element.Target;
                        }
                        else if (_element.Target is ItemContext)
                        {
                            return ((ItemContext)_element.Target).Cell;
                        }
                    }
                    else
                    {
                        ElementUtils.RemoveElementById(_id);
                    }
                    return null;
                }
            }

            public EvasObject NativeView
            {
                get
                {
                    if (_element.IsAlive)
                    {
                        if (_element.Target is VisualElement)
                        {
                            return Platform.GetOrCreateRenderer((VisualElement)_element.Target).NativeView;
                        }
                        else if (_element.Target is ItemContext)
                        {
                            return ((ItemContext)_element.Target).Item.TrackObject;
                        }
                    }
                    else
                    {
                        ElementUtils.RemoveElementById(_id);
                    }
                    return null;
                }
            }

            public ElementWrapper(object obj)
            {
                _id = (obj as Element)?.AutomationId;
                _element = new WeakReference(obj);
            }
        }
    }
}
