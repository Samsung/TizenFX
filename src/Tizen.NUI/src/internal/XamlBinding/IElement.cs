using System;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    internal interface IElement
    {
        Element Parent { get; set; }

        //Use these 2 instead of an event to avoid cloning way too much multicastdelegates on mono
        void AddResourcesChangedListener(Action<object, ResourcesChangedEventArgs> onchanged);
        void RemoveResourcesChangedListener(Action<object, ResourcesChangedEventArgs> onchanged);
    }
}