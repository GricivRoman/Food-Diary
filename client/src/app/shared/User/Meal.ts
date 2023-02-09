import { MealItem } from "./MealItem";
import { MealValue } from "./MealValue";

export class Meal {

    id: number = 0;
    mealTime: Date = new Date();
    mealItems: MealItem[] = [];       
    mealValue: MealValue = new MealValue();
}