import { PhysicalActivityCatalog } from "../Catalogs/PhysicalActivityCatalog";
import { SexCatalog } from "../Catalogs/SexCatalog";
import { Meal } from "./Meal";
import { Target } from "./Target";
import { UserMenu } from "./UserMenu";
import { WeightCondition } from "./WeightContition";

export class User {
    id: string = "";
    userName: string = "";
    email: string = "";

    name: string = "";
    age: number = 0;
    height: number = 0;
    gender: string = "";
    weightConditions: WeightCondition[] = [];
    targets: Target[] = [];
    meals: Meal[] = [];
    userMenu: UserMenu = new UserMenu();
    sex: SexCatalog = new SexCatalog();
    physicalActivity: PhysicalActivityCatalog = new PhysicalActivityCatalog();
}