![Alt text](https://raw.githubusercontent.com/groupdocs-Editor/groupdocs-Editor.github.io/master/resources/image/banner.png "Document Editor API for .NET WebForms")
# GroupDocs.Editor for .NET WebForms Example
###### version 1.20.0

[![Build status](https://ci.appveyor.com/api/projects/status/qu9h9b6wl177vmmn?svg=true)](https://ci.appveyor.com/project/egorovpavel/groupdocs-editor-for-net-WebForms)  
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/92a01202aa6b45c39febe3fe77d1e6c6)](https://www.codacy.com/app/GroupDocs/GroupDocs.Editor-for-.NET-WebForms?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=groupdocs-editor/GroupDocs.Editor-for-.NET-WebForms&amp;utm_campaign=Badge_Grade)
[![GitHub license](https://img.shields.io/github/license/groupdocs-Editor/GroupDocs.Editor-for-.NET-WebForms.svg)](https://github.com/groupdocs-Editor/GroupDocs.Editor-for-.NET-WebForms/blob/master/LICENSE)

## System Requirements
- .NET Framework 4.5
- Visual Studio 2015


## Document Editor API for .NET WebForms

[GroupDocs.Editor for .NET](https://products.groupdocs.com/Editor/net) is a library that allows you to **edit DOCX, ODT, XLS and other supported formats in form of HTML** and save it back to the original format. With GroupDocs.Editor you can easily edit documents on the web with your favorite WYSIWYG editor without external dependencies.

This web application demonstrates the powerful capabilities of GroupDocs.Editor with a built-in **WYSIWYG document editor** and can be used as a standalone application or can be easily integrated into your project.


**Note:** without a license application will run in trial mode, purchase [GroupDocs.Editor for .NET license](https://purchase.groupdocs.com/order-online-step-1-of-8.aspx) or request [GroupDocs.Editor for .NET temporary license](https://purchase.groupdocs.com/temporary-license).


## Supported document Formats

| Family                      | Formats                                                                                                                            |
| --------------------------- |:---------------------------------------------------------------------------------------------------------------------------------- |
| Microsoft Word              | `DOC`, `DOCM` , `DOCX`, `DOT`, `DOTM`, `DOTX`                                                                                      |
| Microsoft Excel             | `XLS`, `XLSB`, `XLSM`, `XLSX`, `XLT`, `XLTM`, `XLTX`                                                                               |
| OpenDocument Formats        | `ODT`, `ODP`, `ODS`, `OTT`                                                                                                         |
| Plain Text File             | `TXT`                                                                                                                              |
| Comma-Separated Values      | `CSV`                                                                                                                              |
| HyperText Markup Language   | `HTML`, `MHT`, `MHTML`, `SVG`                                                                                                      |
| Extensible Markup Language  | `XML`,`XML`, `XPS`                                                                                                                 |


## Demo Video

<p align="center">
  <a title="Document editor for .NET " href="https://youtu.be/pcqg4y87S8I"> 
    <img src="https://raw.githubusercontent.com/groupdocs-editor/groupdocs-editor.github.io/master/resources/image/editor.gif" width="100%" style="width:100%;">
  </a>
</p>

## Features
- Responsive design
- Cross-browser support (Safari, Chrome, Opera, Firefox)
- Cross-platform support (Windows, Linux, MacOS)
- Clean, modern and intuitive design
- Edit, format documents
- Mobile support (open application on any mobile device)
- Support over 50 documents and image formats including **DOCX**, **ODT**,  **XLS**
- Fully customizable navigation panel
- Open password protected documents
- Download documents
- Upload documents
- Print document


## How to run

You can run this sample by one of following methods

#### Build from source

Download [source code](https://github.com/groupdocs-Editor/GroupDocs.Editor-for-.NET-WebForms/archive/master.zip) from github or clone this repository.

```bash
git clone https://github.com/groupdocs-Editor/GroupDocs.Editor-for-.NET-WebForms
```

Open solution in the VisualStudio.
Update common parameters in `web.config` and example related properties in the `configuration.yml` to meet your requirements.

Open http://localhost:8080/Editor in your favorite browser

#### Docker image
Use [docker](https://www.docker.com/) image.

```bash
mkdir DocumentSamples
mkdir Licenses
docker run -p 8080:8080 --env application.hostAddress=localhost -v `pwd`/DocumentSamples:/home/groupdocs/app/DocumentSamples -v `pwd`/Licenses:/home/groupdocs/app/Licenses groupdocs/Editor
## Open http://localhost:8080/Editor in your favorite browser.
```

### Configuration
For all methods above you can adjust settings in `configuration.yml`. By default in this sample will lookup for license file in `./Licenses` folder, so you can simply put your license file in that folder or specify relative/absolute path by setting `licensePath` value in `configuration.yml`.

#### Editor configuration options

| Option                 | Type    |   Default value   | Description                                                                                                                                  |
| ---------------------- | ------- |:-----------------:|:-------------------------------------------------------------------------------------------------------------------------------------------- |
| **`filesDirectory`**   | String  | `DocumentSamples` | Files directory path. Indicates where uploaded and predefined files are stored. It can be absolute or relative path                          |
| **`fontsDirectory`**   | String  |                   | Path to custom fonts directory.                                                                                                              |
| **`defaultDocument`**  | String  |                   | Absolute path to default document that will be loaded automatically.                                                                          |
| **`createNewFile`**    | String  |                   | Enable / disable new document creation.                                                                                                     |

## License
The MIT License (MIT). 

Please have a look at the LICENSE.md for more details

## GroupDocs Document Editor on other platforms/frameworks

- JAVA DropWizard [Document Editor](https://github.com/groupdocs-Editor/GroupDocs.Editor-for-Java-Dropwizard) 
- JAVA Spring boot [Document Editor](https://github.com/groupdocs-Editor/GroupDocs.Editor-for-Java-Spring)
- .NET MVC [Document Editor](https://github.com/groupdocs-Editor/GroupDocs.Editor-for-.NET-MVC)

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/editor/net) | [Documentation](https://docs.groupdocs.com/editor/net/) | [Demo](https://products.groupdocs.app/editor/family) | [API Reference](https://apireference.groupdocs.com/editor/net) | [Examples](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET) | [Blog](https://blog.groupdocs.com/category/editor/) | [Free Support](https://blog.groupdocs.com/category/editor/) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
