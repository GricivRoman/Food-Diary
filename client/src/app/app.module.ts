import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';

import router from './router';
import { LoginPage } from './pages/loginPage/loginPage.component';
import { AuthActivator } from './services/authActivator.servese';
import { FormsModule } from '@angular/forms';
import { Diary } from './services/diary.servise';
import { DiaryPage } from './pages/diaryPage/diaryPage.component';



@NgModule({
  declarations: [
        AppComponent,
        LoginPage,
        DiaryPage
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      router,
      FormsModule
  ],
  providers: [
      Diary,
      AuthActivator
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
