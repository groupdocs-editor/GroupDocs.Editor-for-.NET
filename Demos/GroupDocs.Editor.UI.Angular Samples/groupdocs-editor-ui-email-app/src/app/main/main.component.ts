import { Component } from '@angular/core';
import {EmailService, EmailStorageInfo} from "@groupdocs/groupdocs.editor.angular.ui-email";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  file?: File;
  format: "email" | undefined;
  documentCode?: string;
  showLoading = false;
  allowAccept = false;
  fileUploading = false;
  currentPage?: number;

  totalPages?: number;
  constructor(
    private emailService: EmailService
  ) { }
  onFileChange(event: any) {
    this.file = event.target.files[0]
  }

  upload() {
    if (this.file) {
      this.fileUploading = true;
      this.emailService.uploadPost$Json({body:{
          File: this.file,
        }}).subscribe({
        next: (data: EmailStorageInfo) => {
          if (data) {
            this.format = "email";
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
    let url = `${this.format}/${this.documentCode}`;
    window.open(url, '_blank');
  }
}
