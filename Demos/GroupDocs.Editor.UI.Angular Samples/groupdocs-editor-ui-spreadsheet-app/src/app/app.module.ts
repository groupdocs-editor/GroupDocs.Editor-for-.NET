import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {NotifierModule, NotifierOptions} from "angular-notifier";
import { MainComponent } from './main/main.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {
  ApiModule,
  NewDocumentComponent, SpreadsheetComponent,
  SpreadsheetEditorModule
} from "@groupdocs/groupdocs.editor.angular.ui-spreadsheet";
import {environment} from "../environments/environment";
import {MaterialModule} from "@groupdocs/groupdocs.editor.angular.ui-core";
import {RouterModule} from "@angular/router";
const customNotifierOptions: NotifierOptions = {
  position: {
    horizontal: {
      position: 'right',
      distance: 12
    },
    vertical: {
      position: 'bottom',
      distance: 12,
      gap: 10
    }
  },
  theme: 'material',
  behaviour: {
    autoHide: 5000,
    onClick: 'hide',
    onMouseover: 'pauseAutoHide',
    showDismissButton: true,
    stacking: 4
  },
  animations: {
    enabled: true,
    show: {
      preset: 'slide',
      speed: 300,
      easing: 'ease'
    },
    hide: {
      preset: 'fade',
      speed: 300,
      easing: 'ease',
      offset: 50
    },
    shift: {
      speed: 300,
      easing: 'ease'
    },
    overlap: 150
  }
};

@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    SpreadsheetEditorModule.forRoot({rootUrl: environment.apiUrl}),
    ApiModule.forRoot({rootUrl: environment.apiUrl}),
    MaterialModule,
    NotifierModule.withConfig(customNotifierOptions),
    RouterModule.forRoot([
      { path: '', component: MainComponent, pathMatch: 'full' },
      { path: 'spreadsheet/new', component: NewDocumentComponent },
      { path: 'spreadsheet/:folderName/:page/:pages', component: SpreadsheetComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
