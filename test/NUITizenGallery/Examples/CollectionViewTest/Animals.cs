/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;

public class Animal : INotifyPropertyChanged
{
    private string _name;
    private string _scientificName;
    private string _imageUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/animals/";

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }


    public Animal(string name, string scientificName)
    {
        _name = name;
        _scientificName = scientificName;
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged("Name");
        }
    }

    public string ScientificName
    {
        get => _scientificName;
        set
        {
            _scientificName = value;
            OnPropertyChanged("ScientificName");
        }
    }

    public string ImagePath
    {
        get
        {
            string filename = _name.Replace(" ", "");
            filename = filename.ToLower() + ".jpg";
            return _imageUrl + filename;
        }
    }
}


public class Animals
{
    (string Name,string ScientificName)[] namePool = {
    ("Bald Eagle", "Haliaeetus leucocephalus"),
    ("Bear", "Ursidae"),
    ("Cat", "Felis catus"),
    ("Chicken", "Gallus gallus domesticus"),
    ("Cow", "Bos taurus"),
    ("Deer", "Cervidae"),
    ("Dog", "Canis lupus familiaris"),
    ("Duck", "Anatidae"),
    ("Elephant", "Elephantidae"),
    ("Emperor Penguin", "Aptenodytes forsteri"),
    ("Giraffe", "Giraffa"),
    ("Horse", "Equus ferus"),
    ("Leopard", "Panthera pardus"),
    ("Lion", "Panthera leo"),
    ("Panda", "Ailuropoda melanoleuca"),
    ("Peacock", "Pavo cristatus"),
    ("Pig", "Sus scrofa domesticus"),
    ("Pigeon", "Columba livia"),
    ("Red Fox", "Vulpes vulpes"),
    ("Seagull", "Larus canus"),
    ("Squirrel", "Sciurus vulgaris"),
    ("Tiger", "Panthera tigris"),
    ("Wolf", "Canis lupus"),
    ("Zebra", "Hippotigris"),
};
    public ObservableCollection<Animal> Source {get; private set; } = new ObservableCollection<Animal>();

    public Animals()
    {
        for (int i = 0; i < namePool.Length; i++)
            Source.Add(new Animal(namePool[i].Name, namePool[i].ScientificName));
    }
}
