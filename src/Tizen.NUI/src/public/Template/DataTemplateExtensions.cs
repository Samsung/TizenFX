using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class DataTemplateExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataTemplate SelectDataTemplate(this DataTemplate self, object item, BindableObject container)
        {
            var selector = self as DataTemplateSelector;
            if (selector == null)
                return self;

            return selector.SelectTemplate(item, container);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static object CreateContent(this DataTemplate self, object item, BindableObject container)
        {
            return self.SelectDataTemplate(item, container).CreateContent();
        }
    }
}
