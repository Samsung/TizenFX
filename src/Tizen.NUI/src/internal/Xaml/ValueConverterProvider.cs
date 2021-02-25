using System;
using System.Reflection;

using Tizen.NUI;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml
{
    internal class ValueConverterProvider : IValueConverterProvider
    {
        public object Convert(object value, Type toType, Func<MemberInfo> minfoRetriever, IServiceProvider serviceProvider)
        {
            return value.ConvertTo(toType, minfoRetriever, serviceProvider);
        }
    }
}
