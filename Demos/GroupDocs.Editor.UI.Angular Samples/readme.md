# Creating Document Editor Angular App

This guide outlines the process of setting up a Document Editor Angular application using Angular CLI and integrating GroupDocs.Editor UI for supported document formats.

## Prerequisites

Ensure you have Node.js and npm installed on your system.

### Install Angular CLI

The Angular CLI is a command-line interface tool that helps in initializing, developing, scaffolding, and maintaining Angular applications.

To install the Angular CLI, run the following command:

```bash
npm install -g @angular/cli@14.2.13
```
> required Angular CLI version 14.2.13 see [Angular CLI npm package](https://www.npmjs.com/package/@angular/cli/v/14.2.13)

## Create the Angular App

Once Angular CLI is installed, you can create a new Angular application. Use the following command:

```bash
ng new groupdocs-editor-ui-wordprocessing-pdf-app
```

Alternatively, if you prefer using the latest Angular CLI version:

```bash
npx -p @angular/cli@14.2.13 ng new editor-ui-email-app
```

## Configure Document Editor for Supported Formats

GroupDocs.Editor UI provides various Angular components for editing different document formats. Depending on your requirements, you can configure the editor for supported formats:

- [Angular Email Editor for GroupDocs.Editor UI](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/wiki/Angular-Email-Editor-for-GroupDocs.Editor-UI)
- [Angular Presentation Editor for GroupDocs.Editor UI](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/wiki/Angular-Presentation-Editor-for-GroupDocs.Editor-UI)
- [Angular Spreadsheet Editor for GroupDocs.Editor UI](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/wiki/Angular-Spreadsheet-Editor-for-GroupDocs.Editor-UI)
- [Angular WordProcessing Editor for GroupDocs.Editor UI](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/wiki/Angular-WordProcessing--Editor-for-GroupDocs.Editor-UI)

Refer to the respective links for detailed configuration instructions.

## Explore Available Samples

To further understand and explore the capabilities of Angular Document Editors, you can refer to the available samples provided by GroupDocs.Editor UI:

- [Angular WordProcessing Editor Sample](https://github.com/groupdocs-editor/GroupDocs.Editor-for-.NET-UI/tree/master/samples/DocumentEditors)
