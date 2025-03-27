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
  ApiModule, NewDocumentComponent,
  PresentationComponent,
  PresentationEditorModule
} from "@groupdocs/groupdocs.editor.angular.ui-presentation";

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
    PresentationEditorModule.forRoot({rootUrl: environment.apiUrl}),
    ApiModule.forRoot({rootUrl: environment.apiUrl}),
    MaterialModule,
    NotifierModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'presentation/new', component: NewDocumentComponent },
      { path: 'presentation/:folderName/:page/:pages', component: PresentationComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
