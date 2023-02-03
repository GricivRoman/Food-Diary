import { DailyRate } from "./DailyRate";

export class Target {
    id: number = 0;
    relevance: boolean = false;
    dateStart: Date = new Date();
    dateFinish: Date = new Date();
    currentBodyWeight: number = 0;
    targetBodyWeight: number = 0;
    dailyRate: DailyRate = new DailyRate();
}