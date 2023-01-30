import { NgModule } from '@angular/core';
import { RouterModule } from "@angular/router";
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';

import router from './router';
import { LoginPage } from './pages/loginPage/loginPage.component';
import { AuthActivator } from './services/authActivator.servese';
import { FormsModule } from '@angular/forms';
import { Login } from './services/login.servise';
import { DiaryPage } from './pages/diaryPage/diaryPage.component';
import { ProductPage } from './pages/productPage/producPage.component';
import { LibraryService } from './services/library.service';
import { CreateProduct } from './pages/productPage/createProduct.component';
import { DishPage } from './pages/dishPage/dishPage.component';
import { CreateDish } from './pages/dishPage/createDish.component';
import { AddCompositionItem } from './pages/dishPage/addCompositionItem/addCompositionItem.component';





@NgModule({
  declarations: [
        AppComponent,
        LoginPage,
        DiaryPage,
        ProductPage,
        CreateProduct,
        DishPage,
        CreateDish,
        AddCompositionItem
        
        
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      router,
      FormsModule
  ],
    providers: [
      { provide: LocationStrategy, useClass: HashLocationStrategy },
      Login,
      AuthActivator,
      LibraryService
      
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
