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

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            List<Gallery> myViewModelSource = new GalleryViewModel().CreateData(itemCount);
            selMode = ItemSelectionMode.SingleSelection;
            DefaultTitleItem myTitle = new DefaultTitleItem();
            myTitle.Text = "Linear Sample Count["+itemCount+"]";

            colView = new CollectionView()
            {
                ItemsSource = myViewModelSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    DefaultLinearItem item = new DefaultLinearItem();
                    //Decorate Label
                    item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                    item.Label.HorizontalAlignment = HorizontalAlignment.Begin;
                    //Decorate Icon
                    item.Icon.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    item.Icon.WidthSpecification = 90;
                    item.Icon.HeightSpecification = 90;
                    //Decorate Extra RadioButton.
                    //[NOTE] This is sample of RadioButton usage in CollectionView.
                    // RadioButton change their selection by IsSelectedProperty bindings with
                    // SelectionChanged event with SingleSelection ItemSelectionMode of CollectionView.
                    // be aware of there are no RadioButtonGroup. 
                    item.Extra = new RadioButton();
                    item.Extra.SetBinding(RadioButton.IsSelectedProperty, "Selected");
                    item.Extra.WidthSpecification = 70;
                    item.Extra.HeightSpecification = 70;

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
            if (colView.Header != null && colView.Header is DefaultTitleItem title)
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
