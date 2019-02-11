using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    [ContentProperty("Children")]
    internal abstract class Layout<T> : Layout, IViewContainer<T> where T : View
    {
        readonly ElementCollection<T> _children;

        protected Layout()
        {
            _children = new ElementCollection<T>(InternalChildren);
        }

        public new IList<T> Children
        {
            get { return _children; }
        }

        protected virtual void OnAdded(T view)
        {
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            var typedChild = child as T;
            if (typedChild != null)
                OnAdded(typedChild);
        }

        protected override void OnChildRemoved(Element child)
        {
            base.OnChildRemoved(child);

            var typedChild = child as T;
            if (typedChild != null)
                OnRemoved(typedChild);
        }

        protected virtual void OnRemoved(T view)
        {
        }
    }

    internal abstract class Layout : View, ILayout, ILayoutController, IPaddingElement
    {
        public static readonly BindableProperty IsClippedToBoundsProperty = BindableProperty.Create("IsClippedToBounds", typeof(bool), typeof(Layout), false);

        public static readonly BindableProperty CascadeInputTransparentProperty = BindableProperty.Create(
            nameof(CascadeInputTransparent), typeof(bool), typeof(Layout), true);

        public new static readonly BindableProperty PaddingProperty = PaddingElement.PaddingProperty;

        static IList<KeyValuePair<Layout, int>> s_resolutionList = new List<KeyValuePair<Layout, int>>();
        static bool s_relayoutInProgress;

        bool _hasDoneLayout;
        Size _lastLayoutSize = new Size(-1, -1, 0);

        ReadOnlyCollection<Element> _logicalChildren;

        protected Layout()
        {
            //if things were added in base ctor (through implicit styles), the items added aren't properly parented
            if (InternalChildren.Count > 0)
                InternalChildrenOnCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, InternalChildren));

            InternalChildren.CollectionChanged += InternalChildrenOnCollectionChanged;
        }

        public bool IsClippedToBounds
        {
            get { return (bool)GetValue(IsClippedToBoundsProperty); }
            set { SetValue(IsClippedToBoundsProperty, value); }
        }

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingElement.PaddingProperty); }
            set { SetValue(PaddingElement.PaddingProperty, value); }
        }

        public bool CascadeInputTransparent
        {
            get { return (bool)GetValue(CascadeInputTransparentProperty); }
            set { SetValue(CascadeInputTransparentProperty, value); }
        }

        Thickness IPaddingElement.PaddingDefaultValueCreator()
        {
            return default(Thickness);
        }

        void IPaddingElement.OnPaddingPropertyChanged(Thickness oldValue, Thickness newValue)
        {
            UpdateChildrenLayout();
        }

        internal ObservableCollection<Element> InternalChildren { get; } = new ObservableCollection<Element>();

        internal override ReadOnlyCollection<Element> LogicalChildrenInternal
        {
            get { return _logicalChildren ?? (_logicalChildren = new ReadOnlyCollection<Element>(InternalChildren)); }
        }

        /// <summary>
        /// Raised when the layout of the Page has changed.
        /// </summary>
        public event EventHandler LayoutChanged;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IReadOnlyList<Element> Children
        {
            get { return InternalChildren; }
        }

        public void ForceLayout()
        {
        }


        public static void LayoutChildIntoBoundingRegion(BaseHandle child, Rectangle region)
        {
            var view = child as View;
            if (view == null)
            {
                return;
            }
        }

        public void LowerChild(View view)
        {
            if (!InternalChildren.Contains(view) || (InternalChildren.First() as BaseHandle) == view)
                return;

            InternalChildren.Move(InternalChildren.IndexOf(view), 0);
        }

        public void RaiseChild(View view)
        {
            if (!InternalChildren.Contains(view) || (InternalChildren.Last() as BaseHandle) == view)
                return;

            InternalChildren.Move(InternalChildren.IndexOf(view), InternalChildren.Count - 1);
        }

        protected virtual void InvalidateLayout()
        {
            _hasDoneLayout = false;
            if (!_hasDoneLayout)
                ForceLayout();
        }

        protected abstract void LayoutChildren(double x, double y, double width, double height);

        protected void OnChildMeasureInvalidated(object sender, EventArgs e)
        {
            InvalidationTrigger trigger = (e as InvalidationEventArgs)?.Trigger ?? InvalidationTrigger.Undefined;
            OnChildMeasureInvalidated((BaseHandle)sender, trigger);
            OnChildMeasureInvalidated();
        }

        protected virtual void OnChildMeasureInvalidated()
        {
        }

        protected virtual bool ShouldInvalidateOnChildAdded(View child)
        {
            return true;
        }

        protected virtual bool ShouldInvalidateOnChildRemoved(View child)
        {
            return true;
        }

        protected void UpdateChildrenLayout()
        {
            _hasDoneLayout = true;

            if (!ShouldLayoutChildren())
                return;

            LayoutChanged?.Invoke(this, EventArgs.Empty);
        }

        internal static void LayoutChildIntoBoundingRegion(View child, Rectangle region, SizeRequest childSizeRequest)
        {
        }

        internal virtual void OnChildMeasureInvalidated(BaseHandle child, InvalidationTrigger trigger)
        {
            ReadOnlyCollection<Element> children = LogicalChildrenInternal;
            int count = children.Count;
            for (var index = 0; index < count; index++)
            {
                var v = LogicalChildrenInternal[index] as BaseHandle;
                if (v != null)
                {
                    return;
                }
            }

            var view = child as View;
            if (view != null)
            {
                //we can ignore the request if we are either fully constrained or when the size request changes and we were already fully constrainted
                 if ((trigger == InvalidationTrigger.MeasureChanged) ||
                     (trigger == InvalidationTrigger.SizeRequestChanged))
                {
                    return;
                }
            }

            s_resolutionList.Add(new KeyValuePair<Layout, int>(this, GetElementDepth(this)));
            if (!s_relayoutInProgress)
            {
                s_relayoutInProgress = true;
                Device.BeginInvokeOnMainThread(() =>
                {
                    // if thread safety mattered we would need to lock this and compareexchange above
                    IList<KeyValuePair<Layout, int>> copy = s_resolutionList;
                    s_resolutionList = new List<KeyValuePair<Layout, int>>();
                    s_relayoutInProgress = false;
                });
            }
        }

        static int GetElementDepth(Element view)
        {
            var result = 0;
            while (view.Parent != null)
            {
                result++;
                view = view.Parent;
            }
            return result;
        }

        void InternalChildrenOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                return;
            }

            if (e.OldItems != null)
            {
                foreach (object item in e.OldItems)
                {
                    var v = item as View;
                    if (v == null)
                        continue;

                    OnInternalRemoved(v);
                }
            }

            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    var v = item as View;
                    if (v == null)
                        continue;

                    if ((item as BaseHandle) == this)
                        throw new InvalidOperationException("Can not add self to own child collection.");

                    OnInternalAdded(v);
                }
            }
        }

        void OnInternalAdded(View view)
        {
            var parent = view.GetParent() as Layout;
            parent?.InternalChildren.Remove(view);

            OnChildAdded(view);
            if (ShouldInvalidateOnChildAdded(view))
                InvalidateLayout();
        }

        void OnInternalRemoved(View view)
        {
            OnChildRemoved(view);
            if (ShouldInvalidateOnChildRemoved(view))
                InvalidateLayout();
        }

        bool ShouldLayoutChildren()
        {
            if ( !LogicalChildrenInternal.Any() )
            {
                return false;
            }

            foreach (Element element in VisibleDescendants())
            {
                var visual = element as BaseHandle;
                if (visual == null)
                {
                    continue;
                }
            }
            return true;
        }
    }
}
