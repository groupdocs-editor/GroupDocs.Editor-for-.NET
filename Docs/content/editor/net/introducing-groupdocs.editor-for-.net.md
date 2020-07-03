---
id: introducing-groupdocs-editor-for-net
url: editor/net/introducing-groupdocs-editor-for-net
title: Introducing GroupDocs.Editor for .NET
weight: 1
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
## What Is GroupDocs.Editor?

GroupDocs.Editor is a powerful and lightweight library which allows you to edit most popular document formats using 3rd party front-end WYSIWYG HTML-editors without any additional applications. No Open Office or MS Office is required to edit a WordProcessing, Spreadsheet, text or other document of supportable format.

## How GroupDocs.Editor Works?

GroupDocs.Editor is a .NET class library (DLL), that is designed to allow users to load their documents of different format, open them for editing, edit, and save the edited version to some format, which may be the exactly same as input, or may differ. The most basic thing is that GroupDocs.Editor is GUI-less, it has no GUI, but only a public API, so it should be used within end-user environment, but not as the standalone application. Despite GroupDocs.Editor can be used anywhere, where .NET Framework is installed, it is intended to be used in web applications. Main and most common GroupDocs.Editor usage scenario implies that GroupDocs.Editor is used in a web-application and is located on the server-side. Server-based code invokes GroupDocs.Editor methods, passes input documents and different parameters, and obtains results, that are transmitted to the client-side into the WYSIWYG HTML-editor, like CKEditor or TinyMCE. When user has edited the document in the browser and is sending back the edited content to the server, server-based code again invokes GroupDocs.Editor, passes edited content and obtains edited document in desired format.

## Why Use GroupDocs.Editor as a Developer?

*   Translate document to HTML/CSS markup with resources, that is compatible with HTML WYSIWYG editors;    
*   Save edited HTML/CSS to source document format;    
*   Export edited document to PDF format;    
*   Plenty of additional options to customize editing process - edit password protected documents, extract document fonts, export document language information (useful for spell-checkers), specify document encoding or write-protection during saving etc.    
*   Document information extraction - page count, size, encrypted flag etc.
