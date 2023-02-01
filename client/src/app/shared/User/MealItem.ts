import { Dish } from "../Dish";

export class MealItem {
    id: number = 0;
    mealId: number = 0;
    dish: Dish = new Dish();
    dishId: number = 0;
    dishWeightG: number = 0;
}