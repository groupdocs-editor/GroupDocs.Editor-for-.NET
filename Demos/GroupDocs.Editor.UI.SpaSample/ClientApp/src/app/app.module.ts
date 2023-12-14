import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import {UploadFileComponent} from "./upload-file/upload-file.component";
import {environment} from "../environments/environment";
import {
  ApiModule, PdfComponent,
  WordProcessingComponent,
  WordProcessingEditorModule
} from "@groupdocs/groupdocs.editor.angular.ui-wordprocessing";
import {MaterialModule} from "@groupdocs/groupdocs.editor.angular.ui-core";
import {NotifierModule} from "angular-notifier";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UploadFileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    WordProcessingEditorModule.forRoot({rootUrl: environment.apiUrl}),
    ApiModule.forRoot({rootUrl: environment.apiUrl}),
    MaterialModule,
    NotifierModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'wordProcessing/:folderName', component: WordProcessingComponent },
      { path: 'pdf/:folderName', component: PdfComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
