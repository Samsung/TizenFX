using System;
using EventDictionary = System.Collections.Generic.Dictionary<(System.IntPtr desc, object evtDelegate), (System.IntPtr evtCallerPtr, UIKit.EventCb evtCaller)>;

namespace UIKit
{

namespace Wrapper
{

/// <summary>Observe the ownership state  of an Eo wrapper and control its life-cycle.</summary>
public class WrapperSupervisor
{
    private System.WeakReference weakRef;
#pragma warning disable CS0414
    private UIKit.Wrapper.IWrapper sharedRef;
#pragma warning restore CS0414
    private EventDictionary eoEvents;

    /// <summary>Create a new supervisor for the given.</summary>
    /// <param name="obj">UIKit object to be supervised.</param>
    public WrapperSupervisor(UIKit.Wrapper.IWrapper obj)
    {
        weakRef = new WeakReference(obj);
        sharedRef = null;
        eoEvents = new EventDictionary();
    }

    /// <summary>UIKit object being supervised.</summary>
    public UIKit.Wrapper.IWrapper Target
    {
        get
        {
            return (UIKit.Wrapper.IWrapper) weakRef.Target;
        }
    }

    /// <summary>Dictionary that holds the events related with the supervised object.</summary>
    public EventDictionary EoEvents
    {
        get
        {
            return eoEvents;
        }
    }

    /// <summary>To be called when the object is uniquely owned by C#, removing its strong reference and making it available to garbage collection.</summary>
    public void MakeUnique()
    {
        sharedRef = null;
    }

    /// <summary>To be called when the object is owned in the native library too, adding a strong reference to it and making it unavailable for garbage collection.</summary>
    public void MakeShared()
    {
        if (this.Target == null)
            throw new InvalidOperationException("Tried to make a null reference shared.");
        sharedRef = this.Target;
    }
}

}

}

