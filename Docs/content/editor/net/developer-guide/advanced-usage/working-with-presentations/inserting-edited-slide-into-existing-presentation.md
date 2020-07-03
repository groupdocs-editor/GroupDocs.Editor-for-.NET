---
id: inserting-edited-slide-into-existing-presentation
url: editor/net/inserting-edited-slide-into-existing-presentation
title: Inserting edited slide into existing presentation
weight: 1
description: ""
keywords: 
productName: GroupDocs.Editor for .NET
hideChildren: False
---
By default the full presentation editing pipeline (cycle) is the next:

1.  Load presentation in a form of a file or stream into constructor of the [Editor](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editor) class.
2.  Select a specific slide to edit and specify its index in the [SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationeditoptions/properties/slidenumber) property of [PresentationEditOptions](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationeditoptions) class.
3.  Open presentation for editing by calling [Editor.Edit()](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editor/methods/edit) method, passing [PresentationEditOptions](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationeditoptions) instance with selected slide into it, and obtaining [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) instance from this method.
4.  Emitting HTML and CSS markup, which represents a content of an edited document, from [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) instance, using different methods like [GetContent()](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument/methods/getcontent).
5.  Passing this HTML and CSS markup into the WYSIWYG editor, which is located on client-side and is running in the browser.
6.  End-user edits the document content in the WYSIWYG editor.
7.  Edited document content, in form of HTML and CSS markup, is passed back to the server-side.
8.  Then this content is passed into the [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) class, by using the [FromFile](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument/methods/fromfile), [FromMarkup](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument/methods/frommarkup), or [FromBodyMarkupAndResourceFolder](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument/methods/frombodymarkupandresourcefolder) static methods.
9.  Created [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) instance, which holds an edited document content, is passed into the [Editor.Save](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editor/methods/save) method.
10.  [Editor.Save](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editor/methods/save) method generates a new presentation, which contains only one single slide — those slide, that was edited on the client-side and which content was passed via [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) class into this method.

Before GroupDocs.Editor version 20.4 this was the only pipeline, accessible for the customer.

Starting from version 20.4, the 10th step of described pipeline can be altered — edited slide can be inserted into original presentation, which was loaded on the 1st step.

[PresentationSaveOptions](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions) class now contains two new properties: integer [SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) and boolean flag [InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide). Both of them have "usual" default values: [SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) has '0' and [InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide) is set to 'false'.

```csharp
public int SlideNumber { get; set; }
public bool InsertAsNewSlide { get; set; }
```

By default, when these properties are not touched or at least [SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) has a default value '0', GroupDocs.Editor will generate new single-slide presentation, as in previous versions. However, if [SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) property contains number, distinct from '0', and valid presentation is loaded into [Editor](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editor) class (it is expected to be the original presentation, which was edited, but it actually can be any presentation, even those, which has no relation to the original), then edited slide will be **inserted** into given presentation.

### SlideNumber property

[SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) property, if it is not zero, defines, *where*, at *which exact position* in the given presentation the new edited slide should be inserted. `InsertAsNewSlide` parameter, which is a boolean flag, determines, *how* this slide should be inserted: should it *replace* the existing slide, that is located on specified position ('`false'`, default value), or it should be *injected between* existing slides, without rewriting them, and thus increasing the total amount of slides in the given presentation by one.

Because default '`0`' value of `SlideNumber` parameter is reserved, actual slide numbering starts from `1`. This is different from widely used 0-based indexing, however, makes sense, thus it is not an *index* of a slide, but rather *number* of a slide, the same as MS PowerPoint uses, for instance. This means that, for example, for given presentation, that consists of 5 slides, 1st one has a '`1`' slide number, and 5th — '`5`'. If user has specified a slide number, which exceeds the total amount of slides in presentation, this number will be automatically adjusted to the latest. This means that if, for example, for the same 5-slide presentation user will specify a '`6`', '`7`' or even '`Int32.MaxValue`', it will be internally set a '`5`' — number of the latest slide.

Along with positive slide numbers, the `SlideNumber` property also supports negative numbering, which implies count from the end of presentation. In this case, '-1' is treated as the last slide, '-2' — the last but one, and so on. Again, like with positive numbering, in case when number exceeds the amount of slides, it will be adjusted to the closest — first slide for negative numbers.

Part of source code below explains this numbering system:

```csharp
PresentationSaveOptions saveOptions = new PresentationSaveOptions(Formats.PresentationFormats.Pptx)

//let's say we have presentation with 5 slides

saveOptions.SlideNumber = 0;  // default value, given presentation will be ignored

//positive numbering
saveOptions.SlideNumber =  1;  // first slide
saveOptions.SlideNumber =  2;  // second slide 
saveOptions.SlideNumber =  3;  // third slide 
saveOptions.SlideNumber =  4;  // fourth slide 
saveOptions.SlideNumber =  5;  // fifth slide 
saveOptions.SlideNumber =  6;  // fifth slide, because value '6' exceeds the slides amount '5' and thus is adjusted to the closest

//negative numbering
saveOptions.SlideNumber = -1;  // fifth slide, which is first from end (last)
saveOptions.SlideNumber = -2;  // fourth slide, which is second from end (last but one)
saveOptions.SlideNumber = -3;  // third slide, which is third from end
saveOptions.SlideNumber = -4;  // second slide, which is fourth from end
saveOptions.SlideNumber = -5;  // first slide, which is fifth from end
saveOptions.SlideNumber = -6;  // first slide, because value '-6' exceeds the slides amount '5' and thus is adjusted to the closest
```

### InsertAsNewSlide property

[InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide) property complements the previously described [SlideNumber](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/slidenumber) property and is ignored, when `SlideNumber` is set to '`0`'. If `SlideNumber` points on the slide of specific number,  [InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide) determines how to treat this slide number and how to insert the slide:

*   If  [InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide)  property has default '`false`' value, the existing slide in given presentation will be completely erased, and the content of the new slide (which is located in the [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) instance) will be putted on this place. As a result, presentation will preserve the same untouched amount of slides, but one of its slides (specified by the `SlideNumber`) will be replaced onto new one.
*   If [InsertAsNewSlide](https://apireference.groupdocs.com/editor/net/groupdocs.editor.options/presentationsaveoptions/properties/insertasnewslide) property has '`true`' value, the edited slide, obtained from [EditableDocument](https://apireference.groupdocs.com/editor/net/groupdocs.editor/editabledocument) instance, will be injected among existing slides in given presentation, so its amount of slides will be incremented by one. New slide is inserted at position, specified by `SlideNumber`, and all subsequent slides (following or preceding) will be shifted to the end or to the beginning accordingly, depending on positive or negative numbering.

Source code below shows, how slide number is treated when `InsertAsNewSlide` property is enabled:

```csharp
PresentationSaveOptions saveOptions = new PresentationSaveOptions(Formats.PresentationFormats.Pptx)

//let's say we have presentation with 5 slides
saveOptions.SlideNumber = 0;  // default value, given presentation will be ignored, as well as InsertAsNewSlide
saveOptions.InsertAsNewSlide = true;//

//positive numbering
saveOptions.SlideNumber =  1;  // new slide is injected as first, while all following (including 'old' 1st) are shifting to the end
saveOptions.SlideNumber =  2;  // new slide is injected as second, while 2nd, 3rh, 4th and 5th are shifting to the end
saveOptions.SlideNumber =  3;  // new slide is injected as third, while 3rh, 4th and 5th are shifting to the end
saveOptions.SlideNumber =  4;  // new slide is injected as fourth, while 4th and 5th are shifting to the end
saveOptions.SlideNumber =  5;  // new slide is injected as fifth, while 5th is shifting to the end and becomes 6th
saveOptions.SlideNumber =  6;  // new slide is injected as sixth, it already becomes the latest, none of existing slides are shifthing to the end
saveOptions.SlideNumber =  7;  // same as previous

//negative numbering
saveOptions.SlideNumber = -1;  // new slide is inject as first from end (it becomes sixth if starting from beginning), none of existing slides are shifthing to the end
saveOptions.SlideNumber = -2;  // new slide is inject as second from end (it becomes fifth if starting from beginning), following single slide is shifting to the end
saveOptions.SlideNumber = -3;  // new slide is inject as third from end (it becomes fourth if starting from beginning), two following slides are shifting to the end
saveOptions.SlideNumber = -4;  // new slide is inject as fourth from end (it becomes third if starting from beginning), three following slides are shifting to the end
saveOptions.SlideNumber = -5;  // new slide is inject as fifth from end (it becomes second if starting from beginning), four following slides are shifting to the end
saveOptions.SlideNumber = -6;  // new slide is inject as sixth from end (it becomes first if starting from beginning), five following slides are shifting to the end
saveOptions.SlideNumber = -7;  // same as previous
```
