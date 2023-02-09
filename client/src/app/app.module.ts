import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import router from './router';
import { LoginPage } from './pages/loginPage/loginPage.component';
import { AuthActivator } from './services/authActivator.servese';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Login } from './services/login.servise';
import { DiaryPage } from './pages/diaryPage/diaryPage.component';
import { ProductPage } from './pages/productPage/producPage.component';
import { LibraryService } from './services/library.service';
import { CreateProduct } from './pages/productPage/createProduct/createProduct.component';
import { DishPage } from './pages/dishPage/dishPage.component';
import { CreateDish } from './pages/dishPage/createDish/createDish.component';
import { AddCompositionItem } from './pages/dishPage/createDish/addCompositionItem/addCompositionItem.component';
import { UpdateDish } from './pages/dishPage/updateDish/updateDish.component';
import { UpdateAddCompositionItem } from './pages/dishPage/updateDish/updateAddCompositionItem/updateAddCompositionItem';
import { CheckInPage } from './pages/loginPage/checkInPage/checkInPage.component';
import { UserPage } from './pages/userPage/userPage.component';
import { AddBodyWeight } from './pages/userPage/addBodyWeight/addBodyWeight.component';
import { AddTarget } from './pages/userPage/addTarget/addTarget.component';
import { CatalogService } from './services/catalog.service';
import { PersonalDishPage } from './pages/perfonalDishPage/personalDishPage.component';
import { AddMeal } from './pages/diaryPage/addMeal/addMeal.component';


@NgModule({
  declarations: [
        AppComponent,
        DiaryPage,
        ProductPage,
        CreateProduct,
        DishPage,
        CreateDish,
        AddCompositionItem,
        UpdateDish,
        UpdateAddCompositionItem,
        LoginPage,
        CheckInPage,
        UserPage,
        AddBodyWeight,
        AddTarget,
        PersonalDishPage,
        AddMeal
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
      LibraryService,
      CatalogService      
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
