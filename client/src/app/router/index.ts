import { RouterModule } from "@angular/router";
import { CreateDish } from "../pages/dishPage/createDish/createDish.component";
import { DiaryPage } from "../pages/diaryPage/diaryPage.component";
import { DishPage } from "../pages/dishPage/dishPage.component";
import { LoginPage } from "../pages/loginPage/loginPage.component";
import { CreateProduct } from "../pages/productPage/createProduct/createProduct.component";
import { ProductPage } from "../pages/productPage/producPage.component";

import { AuthActivator } from "../services/authActivator.servese";
import { AddCompositionItem } from "../pages/dishPage/createDish/addCompositionItem/addCompositionItem.component";
import { UpdateDish } from "../pages/dishPage/updateDish/updateDish.component";
import { UpdateAddCompositionItem } from "../pages/dishPage/updateDish/updateAddCompositionItem/updateAddCompositionItem";
import { CheckInPage } from "../pages/loginPage/checkInPage/checkInPage.component";
import { UserPage } from "../pages/userPage/userPage.component";
import { AddBodyWeight } from "../pages/userPage/addBodyWeight/addBodyWeight.component";

const routes = [
    { path: "", component: DiaryPage}, 
    { path: "product", component: ProductPage },
    { path: "product/create", component: CreateProduct },
    { path: "dish", component: DishPage },
    { path: "dish/create", component: CreateDish },
    { path: "dish/create/additem", component: AddCompositionItem },
    { path: "dish/update", component: UpdateDish },
    { path: "dish/update/additem", component: UpdateAddCompositionItem },
    { path: "login", component: LoginPage },
    { path: "login/checkIn", component: CheckInPage },
    { path: "user", component: UserPage/*, canActivate: [AuthActivator]*/ },
    { path: "user/addbodyweight", component: AddBodyWeight},
    { path: "**", redirectTo: "/"}
];

const router = RouterModule.forRoot(routes, {
    useHash: false
    })

export default router;