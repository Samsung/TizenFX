using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;
using System;

namespace Tizen.NUI.Samples
{
    public class CollectionViewGridSample : IExample
    {
        CollectionView colView;
        int itemCount = 500;
        ItemSelectionMode selMode;
        ObservableCollection<Gallery> gallerySource;
        Gallery insertMenu = new Gallery(999, "Insert item to 3rd");
        Gallery deleteMenu = new Gallery(999, "Delete item at 3rd");
        Gallery moveMenu = new Gallery(999, "Move last item to 3rd");

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            var myViewModelSource = gallerySource = new GalleryViewModel(itemCount);
            // Add test menu options.
            gallerySource.Insert(0, moveMenu);
            gallerySource.Insert(0, deleteMenu);
            gallerySource.Insert(0, insertMenu);

            selMode = ItemSelectionMode.Multiple;
            DefaultTitleItem myTitle = new DefaultTitleItem();
            myTitle.Text = "Grid Sample Count["+itemCount+"]";
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
                    item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                    item.Label.HorizontalAlignment = HorizontalAlignment.Center;
                    //Decorate Image
                    item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    item.Image.WidthSpecification = 170;
                    item.Image.HeightSpecification = 170;
                    //Decorate Badge checkbox.
                    //[NOTE] This is sample of CheckBox usage in CollectionView.
                    // Checkbox change their selection by IsSelectedProperty bindings with
                    // SelectionChanged event with Mulitple ItemSelectionMode of CollectionView.
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

                        // Check test menu options.
                        if (galItem == insertMenu)
                        {
                            // Insert new item to index 3.
                            Random rand = new Random();
                            int idx = rand.Next(1000);
                            gallerySource.Insert(3, new Gallery(idx, "Inserted Item"));
                        }
                        else if (galItem == deleteMenu)
                        {
                            // Remove item in index 3.
                            gallerySource.RemoveAt(3);
                        }
                        else if (galItem == moveMenu)
                        {
                            // Move last indexed item to index 3.
                            gallerySource.Move(gallerySource.Count - 1, 3);                    
                        }
                    }
                    
                }
                else continue;
            }
            if (colView.Header != null && colView.Header is DefaultTitleItem)
            {
                DefaultTitleItem title = (DefaultTitleItem)colView.Header;
                title.Text = "Grid Sample Count["+gallerySource.Count+"] Selected["+newSel.Count+"]";
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
