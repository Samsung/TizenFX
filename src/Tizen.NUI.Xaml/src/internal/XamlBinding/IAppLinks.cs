using System;

namespace Tizen.NUI.XamlBinding
{
    internal interface IAppLinks
    {
        void DeregisterLink(IAppLinkEntry appLink);
        void DeregisterLink(Uri appLinkUri);
        void RegisterLink(IAppLinkEntry appLink);
    }
}