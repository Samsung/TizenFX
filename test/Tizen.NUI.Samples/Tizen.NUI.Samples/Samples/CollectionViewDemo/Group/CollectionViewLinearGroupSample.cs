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
        ObservableCollection<Album> albumSource;
        Album insertDeleteGroup = new Album(999, "Insert / Delete Groups", new DateTime(1999, 12, 31));
        Gallery insertMenu = new Gallery(999, "Insert item to first of 3rd Group");
        Gallery deleteMenu = new Gallery(999, "Delete first item in 3rd Group");
        Album moveGroup = new Album(999, "move Groups", new DateTime(1999, 12, 31));
        Gallery moveMenu = new Gallery(999, "Move last item to first in 3rd group");

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            albumSource = new AlbumViewModel();
            // Add test menu options.
            moveGroup.Add(moveMenu);
            albumSource.Insert(0, moveGroup);
            insertDeleteGroup.Add(insertMenu);
            insertDeleteGroup.Add(deleteMenu);
            albumSource.Insert(0, insertDeleteGroup);

            selMode = ItemSelectionMode.Single;
            DefaultTitleItem myTitle = new DefaultTitleItem();
            //To Bind the Count property changes, need to create custom property for count.
            myTitle.Text = "Linear Sample Group["+ albumSource.Count+"]";
            //Set Width Specification as MatchParent to fit the Item width with parent View.
            myTitle.WidthSpecification = LayoutParamPolicies.MatchParent;

            colView = new CollectionView()
            {
                ItemsSource = albumSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
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
                    // SelectionChanged event with Single ItemSelectionMode of CollectionView.
                    // be aware of there are no RadioButtonGroup. 
                    item.Extra = new RadioButton();
                    //FIXME : SetBinding in RadioButton crashed as Sensitive Property is disposed.
                    //item.Extra.SetBinding(RadioButton.IsSelectedProperty, "Selected");
                    item.Extra.WidthSpecification = 80;
                    item.Extra.HeightSpecification = 80;

                    return item;
                }),
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                    DefaultTitleItem group = new DefaultTitleItem();
                    //Set Width Specification as MatchParent to fit the Item width with parent View.
                    group.WidthSpecification = LayoutParamPolicies.MatchParent;

                    group.Label.SetBinding(TextLabel.TextProperty, "Date");
                    group.Label.HorizontalAlignment = HorizontalAlignment.Begin;

                    return group;
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
                if (item is Gallery unselItem)
                {
                    unselItem.Selected = false;
                    selectedItem = null;
                    //Tizen.Log.Debug("NUI", "LSH :: Unselected: {0}", unselItem.ViewLabel);
                }
                else if (item is Album selAlbum)
                {
                    selectedItem = selAlbum.Title;
                    selAlbum.Selected = false;
                    if (selAlbum == insertDeleteGroup)
                    {
                        albumSource.RemoveAt(2);
                    }
                }
                
            }
            foreach (object item in ev.CurrentSelection)
            {
                if (item == null) break;
                if (item is Gallery selItem)
                {
                    selItem.Selected = true;
                    selectedItem = selItem.Name;
                    //Tizen.Log.Debug("NUI", "LSH :: Selected: {0}", selItem.ViewLabel);

                    // Check test menu options.
                    if (selItem == insertMenu)
                    {
                        // Insert new item to index 3.
                        Random rand = new Random();
                        int idx = rand.Next(1000);
                        albumSource[2].Insert(0, new Gallery(idx, "Inserted Item"));
                    }
                    else if (selItem == deleteMenu)
                    {
                        // Remove item in index 3.
                        albumSource[2].RemoveAt(0);
                    }
                    else if (selItem == moveMenu)
                    {
                        // Move last indexed item to index 3.
                        albumSource[2].Move(albumSource[2].Count - 1, 0);                   
                    }
                }
                else if (item is Album selAlbum)
                {
                    selectedItem = selAlbum.Title;
                    selAlbum.Selected = true;
                    if (selAlbum == insertDeleteGroup)
                    {
                        Random rand = new Random();
                        int groupIdx = rand.Next(1000);
                        Album insertAlbum = new Album(groupIdx, "Inserted group", new DateTime(1999, 12, 31));
                        int idx = rand.Next(1000);
                        insertAlbum.Add(new Gallery(idx, "Inserted Item 1"));
                        idx = rand.Next(1000);
                        insertAlbum.Add(new Gallery(idx, "Inserted Item 2"));
                        idx = rand.Next(1000);
                        insertAlbum.Add(new Gallery(idx, "Inserted Item 3"));
                        albumSource.Insert(2, insertAlbum);
                    }
                    else if (selAlbum == moveGroup)
                    {
                        albumSource.Move(albumSource.Count - 1, 2);

                    }
                }
            }
            if (colView.Header != null && colView.Header is DefaultTitleItem)
            {
                DefaultTitleItem title = (DefaultTitleItem)colView.Header;
                title.Text = "Linear Sample Count[" + albumSource.Count + (selectedItem != null ? "] Selected [" + selectedItem + "]" : "]");
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
