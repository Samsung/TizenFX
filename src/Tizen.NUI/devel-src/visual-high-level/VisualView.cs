/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using Tizen.NUI;

namespace Tizen.NUI
{
public class VisualView : CustomView
{
    //private LinkedList<VisualBase> _visualList = null;
    private Dictionary<int, VisualBase> _visualDictionary = null;

    static CustomView CreateInstance()
    {
      return new VisualView();
    }

    // static constructor registers the control type (only runs once)
    static VisualView()
    {
      // ViewRegistry registers control type with DALi type registery
      // also uses introspection to find any properties that need to be registered with type registry
      ViewRegistry.Instance.Register(CreateInstance, typeof(VisualView) );
    }

    public VisualView() : base(typeof(VisualView).Name, ViewWrapperImpl.CustomViewBehaviour.REQUIRES_KEYBOARD_NAVIGATION_SUPPORT | ViewWrapperImpl.CustomViewBehaviour.DISABLE_STYLE_CHANGE_SIGNALS)
    {
    }

    public override void OnInitialize()
    {
      //Initialize empty
      _visualDictionary = new Dictionary<int, VisualBase>();
    }

    //
    public void AddVisual( VisualBase visual )
    {
        //_visualDictionary.Add( visual );
        string visualViewProperty = "visualViewProperty" + _visualDictionary.Count;
        Console.WriteLine ("--------------visualViewProperty name: "  + visualViewProperty );

        int visualViewPropertyIndex = RegisterProperty( visualViewProperty, new Tizen.NUI.Property.Value(visualViewProperty), Tizen.NUI.Property.AccessMode.READ_WRITE);
        _visualDictionary.Add( visualViewPropertyIndex, visual );

        RegisterVisual( visualViewPropertyIndex, visual );
    }

    public void RemoveVisual( VisualBase visual )
    {
        int foundIndex = -1;

        foreach (var item in _visualDictionary)
        {
            if (item.Value == visual) 
            {
                foundIndex = item.Key;
                EnableVisual(foundIndex, false);
                UnregisterVisual(foundIndex);
                _visualDictionary.Remove(foundIndex);
            }
        }
    }

    public int NumOfVisual()
    {
        return _visualDictionary.Count;
    }

    public void DisposeAllVisual()
    {
        //
    }
}
}