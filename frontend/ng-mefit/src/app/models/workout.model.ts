import { Program } from "./program.model";
import { Set } from "./set.model";

export interface Workout {
    id: number;
    name: string;
    completed: boolean;
    setId: number;
    programmes: number[];
}