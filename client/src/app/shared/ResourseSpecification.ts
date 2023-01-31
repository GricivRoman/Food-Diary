import { CompositionItem } from "./CompositionItem";
import { DishValue } from "./DishValue";

export class ResourseSpecification {

    id: number = 0;
    composition: CompositionItem[] = [];
    outputDishWeightG: number = 0;
    dishValue: DishValue = new DishValue;
    
}