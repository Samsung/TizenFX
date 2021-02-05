using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Samples
{
    public class CollectionViewLinearGroupSample : IExample
    {
        CollectionView colView;
        string selectedItem;
        ItemSelectionMode selMode;
        ObservableCollection<Album> groupSource;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            groupSource = new AlbumViewModel();
            selMode = ItemSelectionMode.SingleSelection;
            DefaultTitleItem myTitle = new DefaultTitleItem();
            //To Bind the Count property changes, need to create custom property for count.
            myTitle.Text = "Linear Sample Group["+ groupSource.Count+"]";
            //Set Width Specification as MatchParent to fit the Item width with parent View.
            myTitle.WidthSpecification = LayoutParamPolicies.MatchParent;

            colView = new CollectionView()
            {
                ItemsSource = groupSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    var rand = new Random();
                    RecyclerViewItem item = new RecyclerViewItem();
                    item.WidthSpecification = LayoutParamPolicies.MatchParent;
                    item.HeightSpecification = 100;
                    item.BackgroundColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), 1);
                    /*
                    DefaultLinearItem item = new DefaultLinearItem();
                    //Set Width Specification as MatchParent to fit the Item width with parent View.
                    item.WidthSpecification = LayoutParamPolicies.MatchParent;
                    //Decorate Label
                    item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                    item.Label.HorizontalAlignment = HorizontalAlignment.Begin;
                    //Decorate Icon
                    item.Icon.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    item.Icon.WidthSpecification = 80;
                    item.Icon.HeightSpecification = 80;
                    //Decorate Extra RadioButton.
                    //[NOTE] This is sample of RadioButton usage in CollectionView.
                    // RadioButton change their selection by IsSelectedProperty bindings with
                    // SelectionChanged event with SingleSelection ItemSelectionMode of CollectionView.
                    // be aware of there are no RadioButtonGroup. 
                    item.Extra = new RadioButton();
                    //FIXME : SetBinding in RadioButton crashed as Sensitive Property is disposed.
                    //item.Extra.SetBinding(RadioButton.IsSelectedProperty, "Selected");
                    item.Extra.WidthSpecification = 80;
                    item.Extra.HeightSpecification = 80;
                    */
                    return item;
                }),
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    var rand = new Random();
                    RecyclerViewItem item = new RecyclerViewItem();
                    item.WidthSpecification = LayoutParamPolicies.MatchParent;
                    item.HeightSpecification = 50;
                    item.BackgroundColor = new Color(0, 0, 0, 1);
                    /*
                    DefaultTitleItem group = new DefaultTitleItem();
                    //Set Width Specification as MatchParent to fit the Item width with parent View.
                    group.WidthSpecification = LayoutParamPolicies.MatchParent;

                    group.Label.SetBinding(TextLabel.TextProperty, "Date");
                    group.Label.HorizontalAlignment = HorizontalAlignment.Begin;
                    */
                    return item;
                }),
                Header = myTitle,
                IsGrouped = true,
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
            //Tizen.Log.Debug("NUI", "LSH :: SelectionEvt called");

            //SingleSelection Only have 1 or nil object in the list.
            foreach (object item in ev.PreviousSelection)
            {
                if (item == null) break;
                Gallery unselItem = (Gallery)item;

                unselItem.Selected = false;
                selectedItem = null;
                //Tizen.Log.Debug("NUI", "LSH :: Unselected: {0}", unselItem.ViewLabel);
            }
            foreach (object item in ev.CurrentSelection)
            {
                if (item == null) break;
                Gallery selItem = (Gallery)item;
                selItem.Selected = true;
                selectedItem = selItem.Name;
                //Tizen.Log.Debug("NUI", "LSH :: Selected: {0}", selItem.ViewLabel);
            }
            if (colView.Header != null && colView.Header is DefaultTitleItem)
            {
                DefaultTitleItem title = (DefaultTitleItem)colView.Header;
                title.Text = "Linear Sample Count[" + groupSource + (selectedItem != null ? "] Selected [" + selectedItem + "]" : "]");
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
