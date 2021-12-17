using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Components;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using System.Linq;


namespace Tizen.NUI.Samples
{
    public class CollectionViewSample : IExample
    {
        private View root;


        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            root = new View();
            root.Layout = new AbsoluteLayout();
            root.Size = new Size(300, 800);

            List<string> items = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                items.Add($"Item {i}");
            }

            var collectionview = new CollectionView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                ItemsLayouter = new LinearLayouter(),
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                ItemsSource = items,
                ItemTemplate = new DataTemplate(() =>
                {
                    //var itemView = new MyItemView();

                    //itemView.Clicked += (s, e) =>
                    //{
                    //    Console.WriteLine($"Item Clicked {itemView.BindingContext}");
                    //};
                    //return itemView;

                    var view = new View
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                    };
                    //view.BackgroundColor = Color.Yellow;

                    view.Add(new TextLabel
                    {
                        Text = $"Text for........"
                    });

                    view.BindingContextChanged += (s, e) =>
                    {
                        (view.Children[0] as TextLabel).Text = $"{view.BindingContext}";
                    };

                    var itemView = new RecyclerViewItem
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        SizeHeight = 100,
                    };
                    itemView.Focusable = true;
                    itemView.FocusableInTouch = true;
                    itemView.Add(view);
                    itemView.FocusGained += (s, e) => itemView.BackgroundColor = Color.Yellow;
                    itemView.FocusLost += (s, e) => itemView.BackgroundColor = Color.Transparent;
                    return itemView;

                })
            };
            root.Add(collectionview);

            collectionview.SelectionChanged += (s, e) =>
            {
                Console.WriteLine($"Item Selected : {collectionview.SelectedItem}");
            };
            window.Add(root);
        }


        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
