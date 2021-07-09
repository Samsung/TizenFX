using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;

public class TestItem : INotifyPropertyChanged
{
    int index;
    string name;
    Color color;
    bool isSelected;
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    public TestItem(int itemIndex, string itemName, Color itemColor) {  Index = itemIndex; Name = itemName; BgColor = itemColor; IsSelected=false; }
    public int Index
    {
        get => index;
        set { index = value; OnPropertyChanged("Index"); }
    }
    public string Name
    {
        get => name;
        set { name = value; OnPropertyChanged("Name"); }
    }
    public Color BgColor
    {
        get => color;
        set { color = value; OnPropertyChanged("BgColor"); }
    }
    public bool IsSelected
    {
        get => isSelected;
        set { isSelected = value; OnPropertyChanged("IsSelected");}
    }
}

public class GroupItem : ObservableCollection<TestItem>
{
    int groupIndex;
    string groupName;
    private void OnPropertyChanged(string propertyName) { OnPropertyChanged( new PropertyChangedEventArgs(propertyName)); }
    public GroupItem(int itemIndex, string itemName) {  GroupIndex = itemIndex; GroupName = itemName; }
    public int GroupIndex
    {
        get => groupIndex;
        set { groupIndex = value; OnPropertyChanged("GroupIndex"); }
    }
    public string GroupName
    {
        get => groupName;
        set { groupName = value; OnPropertyChanged("GroupName"); }
    }
}

public class TestSourceModel
{
    public ObservableCollection<TestItem> TestSource {get; private set; } = new ObservableCollection<TestItem>();

    public TestSourceModel(int count = 50)
    {
        CreateTestSource(count);
    }

    public void CreateTestSource(int count)
    {
        var Rand = new Random();

        for (int i = 0; i < count; i++)
            TestSource.Add(new TestItem(i, $"Test Item [{i}]", new Color(((float)(Rand.Next(255))/255), ((float)(Rand.Next(255))/255), ((float)(Rand.Next(255))/255), 1)));
    }
}

public class GroupTestSourceModel
{    public ObservableCollection<GroupItem> TestSource {get; private set; } = new ObservableCollection<GroupItem>();
    public GroupTestSourceModel(int groupCount = 10, int childCount = 10)
    {
        CreateGroupTestSource(groupCount, childCount);
    }
    public void CreateGroupTestSource(int groupCount, int chlidCount)
    {
        var Rand = new Random();

        for (int i = 0; i < groupCount; i++)
        {
            var group = new GroupItem(i, $"Test Group [{i}]");
            for (int j = 0; j < chlidCount; j++)
            {
                group.Add(new TestItem(j, $"Test Item [{i}, {j}]", new Color(((float)(Rand.Next(255))/255), ((float)(Rand.Next(255))/255), ((float)(Rand.Next(255))/255), 1)));
            }
            TestSource.Add(group);
        }
    }
}