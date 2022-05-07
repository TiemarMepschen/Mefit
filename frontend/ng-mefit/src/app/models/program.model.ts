import { Workout } from "./workout.model";

export interface Program {
    id: number;
    name: string;
    workouts: number[];
}