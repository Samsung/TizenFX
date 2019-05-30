namespace Tizen.NUI.XamlBinding
{
    internal interface IPageContainer<out T> where T : Xaml.Page
    {
        T CurrentPage { get; }
    }
}