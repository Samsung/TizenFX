# Tizen .NET

Tizen .NET provides a rich set of interfaces allowing you to build compelling TV, mobile and wearable(preview) applications which achieve native performance. The programming environment includes the following:

- .NET Standard API, which implements the .NET Base Class library, allows you to use the well known C# language base class libraries and features, such as collections, threading, file I/O, and LINQ.
- Xamarin.Forms, which allows you to efficiently build a user interface from standard components in C# or XAML.
- TizenFX API, which allows you to access platform-specific features not covered by the generic .NET and Xamarin.Forms features,  such as system information and status, battery status, sensor date, and account and connectivity services.
  For the full specification, see the [TizenFX API Reference.](api/index.md)

## .NET Standard API

One of the major components of .NET Core is the .NET Standard. The .NET APIs provided by Tizen .NET follow the .NET Standard 2.0. The column titled "2.0" in the [official list](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) of supported CoreFX APIs lists all the available .NET APIs.

## Xamarin.Forms

[Xamarin.Forms](https://developer.xamarin.com/guides/xamarin-forms/getting-started/) provides cross-platform APIs, which allow you to create user interfaces that can be shared across platforms. The Tizen.NET Visual Studio extension enables Tizen support for Xamarin.Forms.

You can efficiently build your Tizen .NET application UI and its supporting logic using the Xamarin.Forms APIs. Extended details for these APIs are available on the [Xamarin Web site](https://developer.xamarin.com/api/namespace/Xamarin.Forms/).

The Tizen 4.0 public M2 contains a few limitations on the Xamarin.Forms APIs; these limitations are to be eliminated in future releases. The following classes are not supported:

- `AppLinkEntry`
- `OpenGLView`

A list of limitations is available at [Current Xamarin.Forms limitations](https://developer.tizen.org/development/articles/current-xamarin.forms-limitations).

[!include[TizenFX API](api/index.md)]
