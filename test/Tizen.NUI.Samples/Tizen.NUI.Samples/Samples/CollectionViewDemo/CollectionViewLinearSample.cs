using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Samples
{
    public class CollectionViewLinearSample : IExample
    {
        CollectionView colView;
        int itemCount = 500;
        string selectedItem;
        ItemSelectionMode selMode;
        ViewItemStyle titleStyle = new ViewItemStyle()
        {
            Name = "titleStyle",
            BackgroundColor = new Selector<Color>()
            {
                Normal = new Color(0.972F, 0.952F, 0.749F, 1),
                Pressed = new Color(0.1F, 0.85F, 0.85F, 1),
                Disabled = new Color(0.70F, 0.70F, 0.70F, 1),
                Selected = new Color(0.701F, 0.898F, 0.937F, 1)
            }
        };
        class SampleLinearTitleItem : OneLineLinearItem
        {
            public SampleLinearTitleItem(ViewItemStyle titleStyle) : base(titleStyle)
            {
                WidthSpecification = LayoutParamPolicies.MatchParent;
                HeightSpecification = 100;
            }
        }

        class SampleLinearItem : OneLineLinearItem
        {
            public SampleLinearItem() : base()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent;
                HeightSpecification = 130;
            }
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            List<Gallery> myViewModelSource = new GalleryViewModel().CreateData(itemCount);
            selMode = ItemSelectionMode.SingleSelection;
            SampleLinearTitleItem myTitle = new SampleLinearTitleItem(titleStyle);
            myTitle.Text = "Linear Sample Count["+itemCount+"]";
            myTitle.Label.PointSize = 9;

            colView = new CollectionView()
            {
                ItemsSource = myViewModelSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    SampleLinearItem item = new SampleLinearItem();
                    //Decorate Label
                    item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                    item.Label.HorizontalAlignment = HorizontalAlignment.Begin;
                    item.LabelPadding = new Extents(10, 10, 10, 10);
                    //Decorate Icon
                    item.Icon.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    item.Icon.WidthSpecification = 90;
                    item.Icon.HeightSpecification = 90;
                    item.IconPadding = new Extents(20, 10, 10, 10);
                    //Decorate Extra RadioButton.
                    //[NOTE] This is sample of RadioButton usage in CollectionView.
                    // RadioButton change their selection by IsSelectedProperty bindings with
                    // SelectionChanged event with SingleSelection ItemSelectionMode of CollectionView.
                    // be aware of there are no RadioButtonGroup. 
                    item.Extra = new RadioButton();
                    item.Extra.SetBinding(RadioButton.IsSelectedProperty, "Selected");
                    item.Extra.WidthSpecification = 70;
                    item.Extra.HeightSpecification = 70;
                    item.ExtraPadding = new Extents(10, 20, 10, 10);

                    return item;
                }),
                Header = myTitle,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
				SelectionMode = selMode
            };
            colView.SelectionChanged += SelectionEvt;

            window.Add(colView);

        }

        public void SelectionEvt(object sender, SelectionChangedEventArgs ev)
        {
            if (ev.PreviousSelection is Gallery unselItem)
            {
                unselItem.Selected = false;
                selectedItem = null;
                Tizen.Log.Debug("Unselected: {0}", unselItem.ViewLabel);
            }
            if (ev.CurrentSelection is Gallery selItem)
            {
                selItem.Selected = true;
                selectedItem = selItem.Name;
                Tizen.Log.Debug("Selected: {0}", selItem.ViewLabel);
            }
            if (colView.Header != null && colView.Header is SampleLinearTitleItem title)
            {
                title.Text = "Linear Sample Count[" + itemCount + (selectedItem != null ? "] Selected [" + selectedItem + "]" : "]");
            }
        }
        public void Deactivate()
        {
            if (colView != null)
            {
                colView.Dispose();
            }
        }
    }
}
