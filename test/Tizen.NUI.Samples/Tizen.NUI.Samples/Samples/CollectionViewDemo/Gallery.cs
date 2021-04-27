using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;


class Gallery : INotifyPropertyChanged
{
    string sourceDir = Tizen.NUI.Samples.CommonResource.GetDaliResourcePath()+"ItemViewDemo/gallery/gallery-medium-";
    private int index;
    private string name;
    private bool selected;

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyyChanged(string propertyName)
    {

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Gallery(int galleryIndex, string galleryName)
    {
        index = galleryIndex;
        name = galleryName;
    }

    public string Name {
        get
        {
            return name;
        }
        set
        {
            name = value;
            OnPropertyyChanged("Name");
            OnPropertyyChanged("ViewLabel");
        }
    }
    public string ViewLabel
    {
        get
        {
            return "[" + index + "] : " + name;
        }
    }

    public string ImageUrl
    {
        get
        {
            return sourceDir+(index%20)+".jpg";
        }
    }

    public bool Selected {
        get
        {
            return selected;
        }
        set
        {
            selected = value;
            OnPropertyyChanged("Selected");
        }
    }
}

class Album : ObservableCollection<Gallery>
{
    private int index;
    private string name;
    private DateTime date;
    private bool selected;

    public Album(int albumIndex, string albumName, DateTime albumDate)
    {
        index = albumIndex;
        name = albumName;
        date = albumDate;
    }

    public string Title
    {
        get
        {
            return "[" + index + "] " + name;
        }
    }

    public string Date
    {
        get
        {
            return date.ToLongDateString();
        }
    }
    public bool Selected {
        get
        {
            return selected;
        }
        set
        {
            selected = value;
        }
    }
}

class GalleryViewModel : ObservableCollection<Gallery>
{
    string[] namePool = {
        "Cat",
        "Boy",
        "Arm muscle",
        "Girl",
        "House",
        "Cafe",
        "Statue",
        "Sea",
        "hosepipe",
        "Police",
        "Rainbow",
        "Icicle",
        "Tower with the Moon",
        "Giraffe",
        "Camel",
        "Zebra",
        "Red Light",
        "Banana",
        "Lion",
        "Espresso",
    };
    public GalleryViewModel(int count)
    {
        CreateData(this, count);
    }

    public ObservableCollection<Gallery> CreateData(ObservableCollection<Gallery> result , int count)
    {
        for (int i = 0; i < count; i++)
        {
            result.Add(new Gallery(i, namePool[i%20]));
        }
        return result;
    }
}

class AlbumViewModel : ObservableCollection<Album>
{
    string[] namePool = {
        "Cat",
        "Boy",
        "Arm muscle",
        "Girl",
        "House",
        "Cafe",
        "Statue",
        "Sea",
        "hosepipe",
        "Police",
        "Rainbow",
        "Icicle",
        "Tower with the Moon",
        "Giraffe",
        "Camel",
        "Zebra",
        "Red Light",
        "Banana",
        "Lion",
        "Espresso",
    };

    (string name, DateTime date)[] titlePool = {
        ("House Move", new DateTime(2021, 2, 26)),
        ("Covid 19", new DateTime(2020, 1, 20)),
        ("Porto Trip", new DateTime(2019, 11, 23)),
        ("Granada Trip", new DateTime(2019, 11, 20)),
        ("Barcelona Trip", new DateTime(2019, 11, 17)),
        ("Developer's Day", new DateTime(2019, 11, 16)),
        ("Tokyo Trip", new DateTime(2019, 7, 5)),
        ("Otaru Trip", new DateTime(2019, 3, 2)),
        ("Sapporo Trip", new DateTime(2019, 2, 28)),
        ("Hakodate Trip", new DateTime(2019, 2, 26)),
        ("Friend's Wedding", new DateTime(2018, 11, 23)),
        ("Grandpa Birthday", new DateTime(2018, 9, 14)),
        ("Family Jeju Trip", new DateTime(2018, 7, 15)),
        ("HongKong Trip", new DateTime(2018, 3, 30)),
        ("Mom's Birthday", new DateTime(2017, 12, 21)),
        ("Buy new Car", new DateTime(2017, 10, 18)),
        ("Graduation", new DateTime(2017, 6, 30)),
    };

    public AlbumViewModel()
    {
        CreateData(this);
    }

    public ObservableCollection<Album> CreateData(ObservableCollection<Album> result)
    {
        for (int i = 0; i < titlePool.Length; i++)
        {
            (string name, DateTime date) = titlePool[i];
            Album cur = new Album(i, name, date);
            for (int j = 0; j < 20; j++)
            {
                cur.Add(new Gallery(j, namePool[j]));
            }
            result.Add(cur);
        }
        return result;
    }

}