export interface Goal {
    id: number;
    endDate: Date;
    completed: boolean;
    programmeId: number;
    completedWorkouts: number[];
}