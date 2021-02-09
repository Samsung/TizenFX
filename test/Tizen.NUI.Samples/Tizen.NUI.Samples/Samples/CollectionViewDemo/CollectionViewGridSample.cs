using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Samples
{
    public class CollectionViewGridSample : IExample
    {
        CollectionView colView;
        int itemCount = 500;
        int selectedCount;
        ItemSelectionMode selMode;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            var myViewModelSource = new GalleryViewModel(itemCount);
            selMode = ItemSelectionMode.MultipleSelections;
            DefaultTitleItem myTitle = new DefaultTitleItem();
            myTitle.Text = "Grid Sample Count["+itemCount+"] Selected["+selectedCount+"]";
            //Set Width Specification as MatchParent to fit the Item width with parent View.
            myTitle.WidthSpecification = LayoutParamPolicies.MatchParent;

            colView = new CollectionView()
            {
                ItemsSource = myViewModelSource,
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    DefaultGridItem item = new DefaultGridItem();
                    item.WidthSpecification = 180;
                    item.HeightSpecification = 240;
                    //Decorate Label
                    item.Caption.SetBinding(TextLabel.TextProperty, "ViewLabel");
                    item.Caption.HorizontalAlignment = HorizontalAlignment.Center;
                    //Decorate Image
                    item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    item.Image.WidthSpecification = 170;
                    item.Image.HeightSpecification = 170;
                    //Decorate Badge checkbox.
                    //[NOTE] This is sample of CheckBox usage in CollectionView.
                    // Checkbox change their selection by IsSelectedProperty bindings with
                    // SelectionChanged event with MulitpleSelections ItemSelectionMode of CollectionView.
                    item.Badge = new CheckBox();
                    //FIXME : SetBinding in RadioButton crashed as Sensitive Property is disposed.
                    //item.Badge.SetBinding(CheckBox.IsSelectedProperty, "Selected");
                    item.Badge.WidthSpecification = 30;
                    item.Badge.HeightSpecification = 30;

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
            List<object> oldSel = new List<object>(ev.PreviousSelection);
            List<object> newSel = new List<object>(ev.CurrentSelection);

            foreach (object item in oldSel)
            {
                if (item != null && item is Gallery)
                {
                    Gallery galItem = (Gallery)item;
                    if (!(newSel.Contains(item)))
                    {
                        galItem.Selected = false;
                        Tizen.Log.Debug("Unselected: {0}", galItem.ViewLabel);
                        selectedCount--;
                    }
                }
                else continue;
            }
            foreach (object item in newSel)
            {
                if (item != null && item is Gallery)
                {
                    Gallery galItem = (Gallery)item;
                    if (!(oldSel.Contains(item)))
                    {
                        galItem.Selected = true;
                        Tizen.Log.Debug("Selected: {0}", galItem.ViewLabel);
                        selectedCount++;
                    }
                }
                else continue;
            }
            if (colView.Header != null && colView.Header is DefaultTitleItem)
            {
                DefaultTitleItem title = (DefaultTitleItem)colView.Header;
                title.Text = "Grid Sample Count["+itemCount+"] Selected["+selectedCount+"]";
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
