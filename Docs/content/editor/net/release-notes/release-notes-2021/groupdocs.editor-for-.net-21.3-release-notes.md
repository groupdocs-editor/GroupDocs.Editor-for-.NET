---
id: groupdocs-editor-for-net-21-3-release-notes
url: editor/net/groupdocs-editor-for-net-21-3-release-notes
title: GroupDocs.Editor for .NET 20.3 Release Notes
weight: 85
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Editor for .NET 21.3{{< /alert >}}

GroupDocs.Editor for .NET version 21.3 delivers one new feature, one significant improvement and a lot of bugfixes in different parts of the product, mainly in WordProcessing and Presentation processing.

## New feature

Version 21.3 of GroupDocs.Editor contains anew feature — utility class ResourceTypeDetector. This class contains 2 static method, which can help customers to process the HTML resources. There is a special article "[Working with HTML resources](https://docs.groupdocs.com/editor/net/working-with-html-resources/)", which describes this in detail.

## Improvement

Version 21.3 also contain one significant improvement — now lists and list items, paragraphs and spans (runs) of text are binded with stylesheets only through class attributes in HTML markup and corresponding class selectors in CSS resources. There are no more ID attributes and selectors in these entities, only class-related binding. This was done in order to improve editability of document content in WYSIWYG-editors, mostly in scenarios, which imply copying some parts of content.

## Bugs

GroupDocs.Editor version 21.3 contains big amount of bugfixes, which address different exceptions in different modules of GroupDocs.Editor, including WordProcessing, Presentation, and HTML processing.

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| EDITORNET-2024 | Develop universal HTML resource type detector and parser | New feature |
| EDITORNET-2028 | Switch binding between HTML elements and CSS rulesets from ID to class attributes and selectors | Improvement |
| EDITORNET-1941 | Unknown Wingding char in list bullet format | Bug |
| EDITORNET-1984 | Markdown to docx converter was lost image | Bug |
| EDITORNET-2009 | Cannot access a disposed object. Object name: 'RasterImageResourceBase'. | Bug |
| EDITORNET-2013 | Exception when saving Word document | Bug |
| EDITORNET-2015 | Image is not JPEG for PowerPoint | Bug |
| EDITORNET-2020 | Internal error - cannot properly parse a string '22504648845' to the Integer number | Bug |
| EDITORNET-2021 | Red cross is displaying instead of valid image | Bug |
| EDITORNET-2032 | Unable to translate Unicode character \uD81A at index 161 to specified code page. | Bug |
| EDITORNET-2033 | Fix bug in selector parser | Bug |
| EDITORNET-2035 | Fix bug in HTML attribute parser | Bug |

## Public API and Backward Incompatible Changes

New public class [GroupDocs.Editor.HtmlCss.Resources.ResourceTypeDetector](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources/resourcetypedetector) is present with 2 public members: methods [DetectTypeFromFilename](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources/resourcetypedetector/methods/detecttypefromfilename) and [TryDetectResource](https://apireference.groupdocs.com/editor/net/groupdocs.editor.htmlcss.resources/resourcetypedetector/methods/trydetectresource).

No existing types or their members were modified or removed.
