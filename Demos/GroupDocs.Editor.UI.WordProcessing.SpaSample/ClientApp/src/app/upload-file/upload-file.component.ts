import { Component } from '@angular/core';
import {
  PdfService,
  WordProcessingService, WordProcessingStorageInfo
} from "@groupdocs/groupdocs.editor.angular.ui-wordprocessing";
import {PdfStorageInfo} from "@groupdocs/groupdocs.editor.angular.ui-wordprocessing/lib/api/models/pdf-storage-info";

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent {
  file?: File;
  format: "wordProcessing" | "pdf" | undefined;
  documentCode?: string;
  showLoading = false;
  allowAccept = false;
  fileUploading = false;
  constructor(
    private pdfService: PdfService,
    private wordHttpService: WordProcessingService
  ) { }
  onFileChange(event: any) {
    this.file = event.target.files[0]
  }

  upload() {
    if (this.file) {
      this.fileUploading = true;
      this.wordHttpService.uploadWordProcessingPost$Json({body:{
          File: this.file,
          "LoadOptions.Password": '',
        }}).subscribe({
        next: (data: WordProcessingStorageInfo) => {
          if (data) {
            this.format = "wordProcessing";
            this.documentCode = data.documentCode;
            this.showLoading = false;
            this.allowAccept = true;
            this.fileUploading = false;
          }
        },
        error: (error: any) => {
          this.fileUploading = false;
          console.error(error)
        },
      });
    } else {
      alert("Please select a file first")
    }
  }
  uploadPdf() {
    if (this.file) {
      this.fileUploading = true;
      this.pdfService.uploadPdfPost$Json({body:{
          File: this.file,
          "LoadOptions.Password": '',
        }}).subscribe({
        next: (data: PdfStorageInfo) => {
          if (data) {
            this.format = "pdf";
            this.documentCode = data.documentCode;
            this.showLoading = false;
            this.allowAccept = true;
            this.fileUploading = false;
          }
        },
        error: (error: any) => {
          this.fileUploading = false;
          console.error(error)
        },
      });
    } else {
      alert("Please select a file first")
    }
  }
  goToLink(): void {
    let url = `${this.format}/${this.documentCode}`;
    window.open(url, '_blank');
  }
}
