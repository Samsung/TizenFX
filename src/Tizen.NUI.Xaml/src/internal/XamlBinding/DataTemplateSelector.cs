using System;
using System.Collections.Generic;

namespace Tizen.NUI.XamlBinding
{
    internal abstract class DataTemplateSelector : DataTemplate
    {
        Dictionary<Type, DataTemplate> _dataTemplates = new Dictionary<Type, DataTemplate>();

        public DataTemplate SelectTemplate(object item, BindableObject container)
        {
            DataTemplate dataTemplate = null;

            dataTemplate = OnSelectTemplate(item, container);
            if (dataTemplate is DataTemplateSelector)
                throw new NotSupportedException(
                    "DataTemplateSelector.OnSelectTemplate must not return another DataTemplateSelector");

            return dataTemplate;
        }

        protected abstract DataTemplate OnSelectTemplate(object item, BindableObject container);
    }
}
