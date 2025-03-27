import { Component, OnInit } from '@angular/core';
import {PresentationService, PresentationStorageInfo} from "@groupdocs/groupdocs.editor.angular.ui-presentation";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  file?: File;
  format: "presentation" | undefined;
  documentCode?: string;
  showLoading = false;
  allowAccept = false;
  fileUploading = false;
  currentPage?: number;
  totalPages?: number;
  constructor(
    private presentationService: PresentationService
  ) { }
  onFileChange(event: any) {
    this.file = event.target.files[0]
  }

  upload() {
    if (this.file) {
      this.fileUploading = true;
      this.presentationService.uploadPost$Json({body:{
          File: this.file,
          "LoadOptions.Password": '',
        }}).subscribe({
        next: (data: PresentationStorageInfo) => {
          if (data) {
            this.format = "presentation";
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

