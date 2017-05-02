using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Dali
{
  /// <summary>
  /// Helper class for calculating what property indexes should be assigned to C# View (view) classes.
  /// </summary>
  public class PropertyRangeManager
  {
    private Dictionary<String, PropertyRange > _propertyRange;

    /// <summary>
    /// Initializes a new instance of the <see cref="Dali.PropertyRangeManager"/> class.
    /// </summary>
    public PropertyRangeManager ()
    {
      _propertyRange = new Dictionary<String, PropertyRange > ();
    }

    /// <summary>
    /// Only called if a View has scriptable properties
    /// </summary>
    private PropertyRange RegisterView( string viewName, System.Type viewType )
    {
      PropertyRange range;

      if ( _propertyRange.TryGetValue (viewName, out range) )
      {
        // already registered
        return range;
      }

      // Find out the event and animatable start indexes for the type
      range = new PropertyRange();

      GetPropertyStartRange( viewType, ref range);

      // add it to our dictionary
      _propertyRange.Add( viewName, range );

      return range;

     }

    /// <summary>
    /// Gets the index of the property.
    /// Each property has to have unique index for this view type
    /// </summary>
    /// <returns>The property index.</returns>
    /// <param name="viewName">View name</param>
    /// <param name="viewType">View type</param>
    /// <param name="type">Type.</param>
    public int GetPropertyIndex( string viewName, System.Type viewType, ScriptableProperty.ScriptableType type )
    {

      PropertyRange range;

      if (!  _propertyRange.TryGetValue (viewName, out range) )
      {
         // view not found, register it now
          range = RegisterView( viewName, viewType);
      }

      int index =  range.GetNextFreePropertyIndex ( type );

      // update the dictionary
      _propertyRange[viewName]=range;

      return index;

    }

    ///<summary>
    /// We calculate the start property indices, based on the type and it's class  heirachy, e.g. DateView (70,000)- > Spin (60,000) -> View (50,000)
    /// </summary>
    private void GetPropertyStartRange( System.Type viewType, ref PropertyRange range )
    {
      const int maxCountPerDerivation = 1000; // For child and animtable properties we use a gap of 1000 between each
      // views property range in the heirachy

      // custom views start there property index, at view_PROPERTY_END_INDEX
      // we add 1000, just incase View class (our C# custom view base) starts using scriptable properties
      int startEventPropertyIndex = (int)View.PropertyRange.CONTROL_PROPERTY_END_INDEX+maxCountPerDerivation;

      // for animatable properties current range starts at ANIMATABLE_PROPERTY_REGISTRATION_START_INDEX,
      // we add 1000, just incase View class starts using animatable properties
      int startAnimatablePropertyIndex = (int)Dali.PropertyRanges.ANIMATABLE_PROPERTY_REGISTRATION_START_INDEX +maxCountPerDerivation;

      while ( viewType.BaseType.Name != "CustomView" )   // custom view is our C# view base class. we don't go any deeper.
      {
        // for every base class increase property start index
        startEventPropertyIndex += (int)Dali.PropertyRanges.DEFAULT_PROPERTY_MAX_COUNT_PER_DERIVATION; // DALi uses 10,000
        startAnimatablePropertyIndex += maxCountPerDerivation;

        //Console.WriteLine ("getStartPropertyIndex =  " + viewType.Name +"current index " + startEventPropertyIndex);
        viewType = viewType.BaseType;
      }

      range.startEventIndex = startEventPropertyIndex;
      range.lastUsedEventIndex = startEventPropertyIndex;

      range.startAnimationIndex = startAnimatablePropertyIndex;
      range.lastUsedAnimationIndex = startAnimatablePropertyIndex;

    }


    public struct PropertyRange
    {

      public int GetNextFreePropertyIndex( ScriptableProperty.ScriptableType type)
      {
        if ( type == ScriptableProperty.ScriptableType.Default )
        {
           lastUsedEventIndex++;
           return lastUsedEventIndex;
        }
        else
        {
          lastUsedAnimationIndex++;
          return lastUsedAnimationIndex ;
        }
      }


      public int startEventIndex;    /// start of the property range
      public int lastUsedEventIndex;    /// last used of the property index

      public int startAnimationIndex;  /// start of the property range
      public int lastUsedAnimationIndex; /// last used of the property index
    };



}
}
