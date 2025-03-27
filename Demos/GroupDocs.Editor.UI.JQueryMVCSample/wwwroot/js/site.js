Constant = {
    BaseUrl: "https://localhost:7240/WordProcessing/"
}

$(document).ready(function () {
    var documentCode;

    document.getElementById('saveButton').addEventListener('click', function () {
        var editorContent = tinymce.activeEditor.getContent();

        var settings = {
            url: Constant.BaseUrl + "update",
            method: "POST",
            timeout: 0,
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            },
            data: JSON.stringify({
                "documentCode": documentCode,
                "htmlContents": editorContent
            }),
        };

        $.ajax(settings).done(function (response) {
            console.log(response);
        });
    });

    $('#uploadButton').click(function () {
        var fileInput = $('#fileInput')[0];
        if (fileInput.files.length === 0) {
            return;
        }

        var form = new FormData();
        form.append("file", fileInput.files[0]);
        $('#spinner').show(); // Show the spinner

        $.ajax({
            url: Constant.BaseUrl + "upload",
            method: 'POST',
            processData: false,
            contentType: false,
            data: form,
            success: function (response) {
                documentCode = response.documentCode;
                editDocument(documentCode);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#spinner').hide(); // Hide the spinner
                console.error("Error uploading file: " + textStatus, errorThrown);
            }
        });
    });
});
function editDocument(documentCode) {
    // Prepare settings for the second API call
    var settings = {
        url: Constant.BaseUrl + "edit",
        method: 'POST',
        timeout: 0,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'text/plain'
        },
        data: JSON.stringify({
            documentCode: documentCode,
            editOptions: {
                enablePagination: true,
                useInlineStyles: true
            }
        }),
    };
    // Make the second API call
    $.ajax(settings).done(function (response) {
        $('#mytextarea').val(response);
        initEditor(documentCode);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Error editing document: " + textStatus, errorThrown);
    });
}

function initEditor(documentCode) {
    // call for stylesheet
    var settings = {
        "url": Constant.BaseUrl + "stylesheets/" + documentCode,
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Accept": "text/plain"
        },
    };

    $.ajax(settings).done(function (response) {
        var styles = response.map(css => css.fileLink);
        console.log(styles);
        tinymce.init({
            selector: 'textarea',
            plugins: 'anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount checklist mediaembed casechange export formatpainter pageembed linkchecker a11ychecker tinymcespellchecker permanentpen powerpaste advtable advcode editimage advtemplate ai mentions tinycomments tableofcontents footnotes mergetags autocorrect typography inlinecss markdown',
            toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table mergetags | addcomment showcomments | spellcheckdialog a11ycheck typography | align lineheight | checklist numlist bullist indent outdent | emoticons charmap | removeformat',
            tinycomments_mode: 'embedded',
            tinycomments_author: 'Author name',
            mergetags_list: [
                { value: 'First.Name', title: 'First Name' },
                { value: 'Email', title: 'Email' },
            ],
            content_css: styles,
            ai_request: (request, respondWith) => respondWith.string(() => Promise.reject("See docs to implement AI Assistant")),

        });
        $('#spinner').hide();
        $('#editor_form').show();

    });

}