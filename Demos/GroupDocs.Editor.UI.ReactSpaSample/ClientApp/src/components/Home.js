import React, {Component} from 'react';
import {Box, CircularProgress, IconButton, Input, InputAdornment, Typography} from "@mui/material";
import CloudUploadIcon from '@mui/icons-material/CloudUpload';
import axios from "axios";
import {DocumentEditor} from "./Editor";
import FormControl from '@mui/material/FormControl';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {uploadProgress: false, file: null, documentCode: null};
    }

    handleChange = (event) => {
        if (event.target.files && event.target.files[0]) {
            this.setState({file: event.target.files[0], documentCode: null, uploadProgress: false});
        }
    }

    handleFileUpload = () => {
        const file = this.state.file;
        const formData = new FormData();
        formData.append('File', file);
        formData.append("LoadOptions.Password", "");
        this.setState({uploadProgress: true});

        axios.post("https://localhost:7147/WordProcessing/Upload", formData)
            .then(response => {
                this.setState({file: null});
                console.log(response);

                this.setState({uploadProgress: false, documentCode: response.data.documentCode});

            })
            .catch(error => {
                console.error(error);
                this.setState({uploadProgress: false});
            });
    };

    render() {
        return (
            <div>
                <Typography sx={{mb: "10px"}} align="center" variant="h3">Word Processing document editor with
                    TinyMCE!</Typography>
                <Box component="form" sx={{textAlign: "center", mb: "10px"}}><FormControl variant="filled">
                    <Input
                        type="file" onChange={this.handleChange}
                        endAdornment={
                            <InputAdornment position="end">
                                <IconButton
                                    type="button"
                                    onClick={this.handleFileUpload}
                                    disabled={this.state.file === null}
                                >
                                    {this.state.uploadProgress === false ? <CloudUploadIcon/> :
                                        <CircularProgress size="1rem" color="inherit"/>}
                                </IconButton>

                            </InputAdornment>
                        }
                    />
                </FormControl>
                </Box>


                {this.state.documentCode !== null &&
                    <DocumentEditor documentCode={this.state.documentCode}></DocumentEditor>}
            </div>

        );
    }
}
