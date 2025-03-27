import { Component } from '@angular/core';
import {SpreadsheetService, SpreadsheetStorageInfo} from "@groupdocs/groupdocs.editor.angular.ui-spreadsheet";


@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent {
  file?: File;
  format: "spreadsheet" | undefined;
  documentCode?: string;
  showLoading = false;
  allowAccept = false;
  fileUploading = false;
  currentPage?: number;
  totalPages?: number;
  constructor(
    private spreadsheetService: SpreadsheetService
  ) { }
  onFileChange(event: any) {
    this.file = event.target.files[0]
  }

  upload() {
    if (this.file) {
      this.fileUploading = true;
      this.spreadsheetService.uploadPost$Json({body:{
          File: this.file,
          "LoadOptions.Password": '',
        }}).subscribe({
        next: (data: SpreadsheetStorageInfo) => {
          if (data) {
            this.format = "spreadsheet";
            this.documentCode = data.documentCode;
            this.showLoading = false;
            this.allowAccept = true;
            this.fileUploading = false;
            this.currentPage = 1;
            this.totalPages = data.documentInfo?.pageCount
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
    let url = `${this.format}/${this.documentCode}/${this.currentPage}/${this.totalPages}`;
    window.open(url, '_blank');
  }
}
