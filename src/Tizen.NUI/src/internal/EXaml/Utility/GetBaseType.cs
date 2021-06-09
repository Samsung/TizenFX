using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class GetBaseType
    {
        private static List<Type> baseTypes;
        
        internal static Type GetBaseTypeByIndex(int typeIndex)
        {
            if (null == baseTypes)
            {
                baseTypes = new List<Type>();

                baseTypes.Add(typeof(sbyte));
                baseTypes.Add(typeof(Int16));
                baseTypes.Add(typeof(Int32));
                baseTypes.Add(typeof(Int64));
                baseTypes.Add(typeof(byte));
                baseTypes.Add(typeof(UInt16));
                baseTypes.Add(typeof(UInt32));
                baseTypes.Add(typeof(UInt64));
                baseTypes.Add(typeof(bool));
                baseTypes.Add(typeof(string));
                baseTypes.Add(typeof(object));
                baseTypes.Add(typeof(char));
                baseTypes.Add(typeof(decimal));
                baseTypes.Add(typeof(float));
                baseTypes.Add(typeof(double));
                baseTypes.Add(typeof(TimeSpan));
                baseTypes.Add(typeof(Uri));
            }

            var realIndex = typeIndex * -1 - 2;

            if (realIndex >= baseTypes.Count)
            {
                throw new Exception($"Index {typeIndex} is not valid base type index");
            }

            return baseTypes[realIndex];
        }
    }
}
