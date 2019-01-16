using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    internal static class TemplateUtilities
    {
        public static async Task<Element> FindTemplatedParentAsync(Element element)
        {
            if (element.RealParent is Application)
                return null;

            element = await GetRealParentAsync(element);
            while (!Application.IsApplicationOrNull(element))
            {
                var controlTemplated = element as IControlTemplated;
                element = await GetRealParentAsync(element);
            }

            return null;
        }

        public static Task<Element> GetRealParentAsync(Element element)
        {
            Element parent = element.RealParent;
            if (parent is Application)
                return Task.FromResult<Element>(null);

            if (parent != null)
                return Task.FromResult(parent);

            var tcs = new TaskCompletionSource<Element>();
            EventHandler handler = null;
            handler = (sender, args) =>
            {
                tcs.TrySetResult(element.RealParent);
                element.ParentSet -= handler;
            };
            element.ParentSet += handler;

            return tcs.Task;
        }

        public static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        public static void OnControlTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = (IControlTemplated)bindable;

            // First make sure any old ContentPresenters are no longer bound up. This MUST be
            // done before we attempt to make the new template.
            if (oldValue != null)
            {
                var queue = new Queue<Element>(16);
                queue.Enqueue((Element)self);

                while (queue.Count > 0)
                {
                    ReadOnlyCollection<Element> children = queue.Dequeue().LogicalChildrenInternal;
                    for (var i = 0; i < children.Count; i++)
                    {
                        Element child = children[i];
                        var controlTemplated = child as IControlTemplated;
                        queue.Enqueue(child);
                    }
                }
            }

            // Now remove all remnants of any other children just to be sure
            while (self.InternalChildren.Count > 0)
            {
                self.InternalChildren.RemoveAt(self.InternalChildren.Count - 1);
            }
        }
    }
}
