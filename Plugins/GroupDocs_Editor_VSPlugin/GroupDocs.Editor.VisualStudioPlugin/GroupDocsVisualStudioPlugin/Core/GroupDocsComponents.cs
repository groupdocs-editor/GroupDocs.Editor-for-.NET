// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsEditorVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsEditor = new GroupDocsComponent();
            groupdocsEditor.set_downloadUrl("");
            groupdocsEditor.set_downloadFileName("groupdocs.Editor.zip");
            groupdocsEditor.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsEditor.set_remoteExamplesRepository("https://github.com/groupdocs-Editor/GroupDocs.Editor-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsEditor);
        }
    }
}
