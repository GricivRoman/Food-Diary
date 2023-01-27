import { NgModule } from '@angular/core';
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
import { ProductService } from './services/product.service';
import { CreateProduct } from './pages/productPage/createProduct.component';




@NgModule({
  declarations: [
        AppComponent,
        LoginPage,
        DiaryPage,
        ProductPage,
        CreateProduct
        
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
      ProductService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
