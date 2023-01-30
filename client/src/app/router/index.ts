import { RouterModule } from "@angular/router";
import { CreateDish } from "../pages/dishPage/createDish.component";
import { DiaryPage } from "../pages/diaryPage/diaryPage.component";
import { DishPage } from "../pages/dishPage/dishPage.component";
import { LoginPage } from "../pages/loginPage/loginPage.component";
import { CreateProduct } from "../pages/productPage/createProduct.component";
import { ProductPage } from "../pages/productPage/producPage.component";

import { AuthActivator } from "../services/authActivator.servese";
import { AddCompositionItem } from "../pages/dishPage/addCompositionItem/addCompositionItem.component";

const routes = [
    { path: "", component: DiaryPage/*, canActivate: [AuthActivator] */}, 
    { path: "product", component: ProductPage },
    { path: "product/create", component: CreateProduct },
    { path: "dish", component: DishPage },
    { path: "dish/create", component: CreateDish },
    { path: "dish/create/additem", component: AddCompositionItem },
    { path: "login", component: LoginPage },
    { path: "**", redirectTo: "/"}
];

const router = RouterModule.forRoot(routes, {
    useHash: false
    })

export default router;