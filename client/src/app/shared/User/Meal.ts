import { MealItem } from "./MealItem";

export class Meal {

    id: number = 0;
    mealTime: Date = new Date();
    mealItems: MealItem[] = [];       
}