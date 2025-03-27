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

import {MaterialModule} from "@groupdocs/groupdocs.editor.angular.ui-core";
import {NotifierModule} from "angular-notifier";
import {
  ApiModule,
  NewDocumentComponent,
  SpreadsheetComponent, SpreadsheetEditorModule
} from "@groupdocs/groupdocs.editor.angular.ui-spreadsheet";

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
    SpreadsheetEditorModule.forRoot({rootUrl: environment.apiUrl}),
    ApiModule.forRoot({rootUrl: environment.apiUrl}),
    MaterialModule,
    NotifierModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'spreadsheet/new', component: NewDocumentComponent },
      { path: 'spreadsheet/:folderName/:page/:pages', component: SpreadsheetComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
