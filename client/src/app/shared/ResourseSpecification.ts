import { CompositionItem } from "./CompositionItem";
import { DishValue } from "./DishValue";

export class ResourseSpecification {

    composition: CompositionItem[] = [];
    outputDishWeightG: number = 0;
    dishValue: DishValue = new DishValue;
    
}