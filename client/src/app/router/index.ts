import { RouterModule } from "@angular/router";
import { DiaryPage } from "../pages/diaryPage/diaryPage.component";
import { LoginPage } from "../pages/loginPage/loginPage.component";
import { CreateProduct } from "../pages/productPage/createProduct.component";
import { ProductPage } from "../pages/productPage/producPage.component";

import { AuthActivator } from "../services/authActivator.servese";

const routes = [
    { path: "", component: DiaryPage/*, canActivate: [AuthActivator] */}, 
    { path: "product", component: ProductPage },
    { path: "product/create", component: CreateProduct},
    { path: "login", component: LoginPage },
    { path: "**", redirectTo: "/"}
];

const router = RouterModule.forRoot(routes, {
    useHash: false
    })

export default router;