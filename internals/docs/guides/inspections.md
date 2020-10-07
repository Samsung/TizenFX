## Tizen.Inspections Guide

`Tizen.Inspections` is used to collect data from applications and services. This API allows you to receive inspection events as well as request inspection data on demand (ex. receive crash reports if a process in the system crashes).

## Prerequisites

Follow [get started](https://docs.tizen.org/application/dotnet/get-started/overview/) page to setup Visual Studio for .NET development.

To enable your application to use `Tizen.Inspections`:

1. To use `Tizen.Inspections` to collect inspectable data, the application must be signed with a platform level distributor certificate. Refer this [guide](https://docs.tizen.org/application/dotnet/tutorials/certificates/getting-the-certificates/) on how to sign an application with the custom certificate.

2. To use the methods and properties of the `Tizen.Inspections` namespace, include the namespace in your application::

    ```c#
    Using Tizen.Inspections
    ```

## Receive inspection events

`Tizen.Inspections` allows to receive status notification published by the platform (at future, Tizen inpsections will support to receive status notification published by manufacturer's applications).

In order to receive such notification, subscribe to the `EventReceived` event:

```c#
void callback(object sender, EventReceivedEventArgs e)
{
    ...
}

void getInspectableDataFromEvents()
{
    Inspector.EventReceived += callback;
}
```

When a new event arrives, callback is called. To read the inspection data out of the inspection context use `GetInspectableData()`:

```c#
void callback(object sender, EventReceivedEventArgs e)
{
    if (e.Context.ModuleID == "org.tizen.system.crash")
    {
        string[] parameters = {"cs_info_json"};
        InspectionData data = e.Context.GetInspectableData(parameters);
    }

    ...
}
```

Use the `parameters` argument to specify which data to read from the inspection context. Available parameters depend on the module that provides the context.

In case of `"org.tizen.system.crash"` module, the proper values are:

-   `"cs_info_json"`: JSON report is returned, which contains information about crashed process such as callstack, mapped memory regions, and so on.
-   `"cs_full"`: Full crash report ZIP archive is collected.

The obtained data is associated with the `data` Inspections handler. To read the data content, use `Read()` method:

```c#
void callback(object sender, EventReceivedEventArgs e)
{
    if (e.Context.ModuleID == "org.tizen.system.crash")
    {
        string[] parameters = {"cs_info_json"};
        InspectionData data = e.Context.GetInspectableData(parameters);

        byte[] buf = new byte[100];
        while (true)
        {
            // Read data and check for EOF
            if (data.Read(buf, 0, buf.Length) == 0)
                break;

            // Log received data
            Log.Info("InspectionsExample", System.Text.Encoding.UTF8.GetString(buf));
        }
    }
}
```

## Request diagnostic data

`Tizen.Inspections` can also request diagnostic data from other modules (applications or services).

For this purpose, call `RequestInspectableData()`. The `moduleId` parameter must be the id of the module that supports `Tizen.Inspections` requests:

```c#

void requestInspectableData()
{
    string moduleId = "org.tizen.some_service";
    string[] parameters = {"custom_parameter"};

    InspectionData data = Inspector.RequestInspectableData(moduleId, parameters);

    byte[] buf = new byte[100];
    while (true)
    {
        // Read data and check for EOF
        if (data.Read(buf, 0, buf.Length) == 0)
            break;

        // Log received data
        Log.Info("InspectionsExample", System.Text.Encoding.UTF8.GetString(buf));
    }
}
```

As in above example, after successful request, data may be read with `Read()` method.

## Related information
- Dependencies
  - Tizen 6.0 and Higher