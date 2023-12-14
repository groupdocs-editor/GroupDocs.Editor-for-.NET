import React, {Component, createRef} from 'react';
import {Editor} from "@tinymce/tinymce-react";
import axios from "axios";

export class DocumentEditor extends Component {
    static displayName = DocumentEditor.name;
    editorRef = createRef();

    constructor(props) {
        super(props);
        this.state = {currentCount: 0, editor: null, content: "", documentCode: props.documentCode, content_css: null};
        axios.post("https://localhost:7147/WordProcessing/Stylesheets", {
            "documentCode": props.documentCode,
            "subIndex": "0"
        })
            .then(response => {
                const styles = response.data.map(a => a.fileLink);
                console.log(styles);
                this.setState({content_css: styles});

            })
            .catch(error => {
                console.error(error);
            });
        axios.post("https://localhost:7147/WordProcessing/ConvertedContent", {
            "documentCode": props.documentCode,
            "subIndex": "0"
        })
            .then(response => {
                console.log(response);
                this.setState({content: response.data});

            })
            .catch(error => {
                console.error(error);
            });
    }

    save = () => {
        if (this.state.editor) {
            console.log(this.state.editor.getContent());
        }
    };

    render() {
        return (
            <>
                <Editor
                    onInit={(evt, editor) => this.setState({editor: editor})}
                    initialValue={this.state.content}
                    init={{
                        height: 750,
                        menubar: false,
                        content_css: this.state.content_css,
                        plugins: [
                            'advlist autolink lists link image charmap print preview anchor',
                            'searchreplace visualblocks code fullscreen',
                            'insertdatetime media table paste code help wordcount'
                        ],
                        toolbar: 'undo redo | formatselect | ' +
                            'bold italic backcolor | alignleft aligncenter ' +
                            'alignright alignjustify | bullist numlist outdent indent | ' +
                            'removeformat | help',
                    }}
                />
                <button onClick={this.save}>Save editor content</button>
            </>
        );
    }
}
