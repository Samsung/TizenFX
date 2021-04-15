using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Samples
{
    public class CollectionViewGridGroupSample : IExample
    {
        CollectionView colView;
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

            selMode = ItemSelectionMode.Multiple;
            DefaultTitleItem myTitle = new DefaultTitleItem();
            myTitle.Text = "Grid Sample Count["+ albumSource.Count+"]";
            //Set Width Specification as MatchParent to fit the Item width with parent View.
            myTitle.WidthSpecification = LayoutParamPolicies.MatchParent;

            colView = new CollectionView()
            {
                ItemsSource = albumSource,
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
                        // Tizen.Log.Debug("Unselected: {0}", galItem.ViewLabel);
                    }
                }
                else if (item is Album selAlbum)
                {
                    if (!(newSel.Contains(selAlbum)))
                    {
                        selAlbum.Selected = false;
                        // Tizen.Log.Debug("Unselected Group: {0}", selAlbum.Title);
                        if (selAlbum == insertDeleteGroup)
                        {
                            albumSource.RemoveAt(2);
                        }
                    }
                }
            }
            foreach (object item in newSel)
            {
                if (item != null && item is Gallery)
                {
                    Gallery galItem = (Gallery)item;
                    if (!(oldSel.Contains(item)))
                    {
                        galItem.Selected = true;
                        // Tizen.Log.Debug("Selected: {0}", galItem.ViewLabel);
                        
                        if (galItem == insertMenu)
                        {
                            // Insert new item to index 3.
                            Random rand = new Random();
                            int idx = rand.Next(1000);
                            albumSource[2].Insert(3, new Gallery(idx, "Inserted Item"));
                        }
                        else if (galItem == deleteMenu)
                        {
                            // Remove item in index 3.
                            albumSource[2].RemoveAt(0);
                        }
                        else if (galItem == moveMenu)
                        {
                            // Move last indexed item to index 3.
                            albumSource[2].Move(albumSource[2].Count - 1, 0);                   
                        }
                    }
                }
                else if (item is Album selAlbum)
                {
                    if (!(oldSel.Contains(selAlbum)))
                    {
                        selAlbum.Selected = true;
                        // Tizen.Log.Debug("Selected Group: {0}", selAlbum.Title);
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
            }
            if (colView.Header != null && colView.Header is DefaultTitleItem)
            {
                DefaultTitleItem title = (DefaultTitleItem)colView.Header;
                title.Text = "Grid Sample Count["+ albumSource.Count + "] Selected["+newSel.Count+"]";
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
