namespace Tizen.NUI.Binding
{
    internal interface IPageContainer<out T> where T : Xaml.Page
    {
        T CurrentPage { get; }
    }
}