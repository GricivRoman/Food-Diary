import { Meal } from "./Meal";
import { Target } from "./Target";
import { UserMenu } from "./UserMenu";
import { WeightContition } from "./WeightContition";

export class User {
    id: number = 0;
    userName: string = "";
    email: string = "";

    name: string = "";
    age: number = 0;
    gender: string = "";
    weightConditions: WeightContition[] = [];
    targets: Target[] = [];
    meals: Meal[] = [];
    userMenu: UserMenu = new UserMenu();
}