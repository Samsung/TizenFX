using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class DataTemplateSelector : DataTemplate
    {
        Dictionary<Type, DataTemplate> _dataTemplates = new Dictionary<Type, DataTemplate>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate SelectTemplate(object item, BindableObject container)
        {
            DataTemplate dataTemplate = null;
            if (_dataTemplates.TryGetValue(item.GetType(), out dataTemplate))
            {
                return dataTemplate;
            }

            dataTemplate = OnSelectTemplate(item, container);
            if (dataTemplate is DataTemplateSelector)
                throw new NotSupportedException(
                    "DataTemplateSelector.OnSelectTemplate must not return another DataTemplateSelector");

            return dataTemplate;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected abstract DataTemplate OnSelectTemplate(object item, BindableObject container);
    }
}
