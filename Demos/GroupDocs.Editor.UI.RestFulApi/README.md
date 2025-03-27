# Exploring the UI for GroupDocs.Editor for .NET

![Build Packages](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/actions/workflows/build_packages.yml/badge.svg)
![Test ubuntu-latest](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/actions/workflows/Test_linux.yml/badge.svg)
![Test windows-latest](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/actions/workflows/Test_windows-latest.yml/badge.svg)
![Nuget](https://img.shields.io/nuget/v/groupdocs.editor.ui?label=GroupDocs.Editor.UI)
![Nuget](https://img.shields.io/nuget/dt/groupdocs.editor.ui?label=GroupDocs.Editor.UI)

GroupDocs.Editor UI is an essential interface that complements the [GroupDocs.Editor for .NET](https://products.groupdocs.com/editor/net) library, offering a feature-rich platform for displaying a wide range of popular word-processing formats (such as DOC, DOCX, RTF, ODT, and more) directly within a web browser. This article will provide insights into the capabilities and resources offered by the GroupDocs.Editor for .NET UI. You can find the primary repository for this UI interface at [GroupDocs.Editor-for-.NET-UI](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI).

## Overview of GroupDocs.Editor.UI

GroupDocs.Editor UI is designed to seamlessly collaborate with the GroupDocs.Editor for .NET library, extending the document processing capabilities for .NET applications. It delivers an interactive interface, enabling users to view and edit word-processing documents of various formats directly within a web browser.

## Repository Highlights

### 1. Creating a Web API App

The GroupDocs.Editor.UI repository provides the code for creating a Web API app using the NuGet package `GroupDocs.Editor.UI.Api`. You can install this package using the following PowerShell command:

```PowerShell
dotnet add package GroupDocs.Editor.UI.Api
```

To integrate this package into your ASP.NET Core project, add the necessary services and middleware in your `Startup` class, as demonstrated below:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEditorControllers();
builder.Services.AddEditorSwagger();
builder.Services.AddEditor<LocalStorage>(builder.Configuration);
```

## User Interface (UI)

The UI is an Angular application built on top of the [`@groupdocs/groupdocs.editor.angular.ui-wordprocessing`](https://www.npmjs.com/package/@groupdocs/groupdocs.editor.angular.ui-wordprocessing) package. The example can be found here: [GroupDocs.Editor.UI.SpaSample](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/tree/master/samples/GroupDocs.Editor.UI.SpaSample).

## API Integration

The API is a critical component used to serve content, allowing users to open, view, edit, and save word-processing documents. The API can be hosted within the same application or in a separate one. Currently, the following API implementations are available:

- [GroupDocs.Editor.UI.Api](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/tree/master/src/GroupDocs.Editor.UI.Api)

All API implementations are extensions of `IMvcBuilder`.

## Licensing

To use GroupDocs.Editor for .NET without trial limitations, you need a valid license. To request a temporary license and try the GroupDocs.Editor library before buying it, visit the [Get a Temporary License](https://purchase.groupdocs.com/temporary-license) page. 

Here's how you can set a license in the `appsettings.json` file:

```json
"LicenseOptions": {
    "Type": 1,
    "Source": "https://docs.groupdocs.com/editor/net/licensing-and-subscription/"
}
```

The `Type` field corresponds to different license sources, including local path, remote URL, and base64 string.

## Linux Dependencies

When running the API on Linux or in a Docker container, specific packages need to be installed, as shown below:

```bash
RUN apt-get update && apt-get install -y \
 libfontconfig1 \
 libfreetype6 \
 libexpat1 \
 libpng16-16
```

## Amazon S3 Storage

For those who prefer Amazon S3 for file storage, you can configure it by adding the following service in your `Startup` class:

```csharp
builder.Services.AddEditor<AwsS3Storage>(builder.Configuration);
```

In the `appsettings.json`, specify the options for the file storage folder:

```json
"AWS": {
    "Profile": "s3-dotnet-demo",
    "Region": "us-west-2",
    "BucketName": "groupDocs-editor-files"
}
```

## API Storage Providers

If you opt for local storage, use the following code to set up a local file storage provider:

```csharp
builder.Services.AddEditor<LocalStorage>(builder.Configuration);
```

In the `appsettings.json`, you can specify the root folder for file storage and the base URL for reading files:

```json
"LocalStorageOptions": {
    "RootFolder": "pathToStorage",
    "BaseUrl": "https://yourBaseUrl"
}
```

## Contributing

Contributions are encouraged to improve the project by adding new features, making enhancements, or fixing bugs. Here are the key steps to follow when contributing:

1. Familiarize yourself with the [Don't push your pull requests](https://www.igvita.com/2011/12/19/dont-push-your-pull-requests/) guideline.
2. Adhere to the code guidelines and conventions.
3. Ensure that your pull requests are well-documented and describe the changes thoroughly.

With these guidelines in mind, you can actively contribute to the enhancement and development of the GroupDocs.Editor.UI for .NET project.

GroupDocs.Editor UI for .NET enhances document editing capabilities and provides a seamless user experience for developers and end-users alike. Whether you're building web applications, exploring storage options, or extending the capabilities of your .NET application, GroupDocs.Editor.UI offers a rich interface that simplifies document editing and processing tasks.

To learn more about GroupDocs and access additional resources, please visit the following links:

- **Website:** [www.groupdocs.com](http://www.groupdocs.com)
- **Product Home:** [GroupDocs.Editor](https://products.groupdocs.com/editor)
- **Download:** [Download GroupDocs.Editor](http://downloads.groupdocs.com/editor)
- **Free Support Forum:** [GroupDocs.Editor Free Support Forum](https://forum.groupdocs.com/c/editor)
- **Paid Support Helpdesk:** [GroupDocs.Editor Paid Support Helpdesk](https://helpdesk.groupdocs.com)
- **Blog:** [GroupDocs.Editor Blog](https://blog.groupdocs.com/category/groupdocs-editor-product-family/)
