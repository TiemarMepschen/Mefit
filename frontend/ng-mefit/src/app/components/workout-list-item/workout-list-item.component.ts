import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Exercise } from 'src/app/models/exercise.model';
import { Set } from 'src/app/models/set.model';
import { Workout } from 'src/app/models/workout.model';
import { WorkoutService } from 'src/app/services/workout.service';

@Component({
  selector: 'app-workout-list-item',
  templateUrl: './workout-list-item.component.html',
  styleUrls: ['./workout-list-item.component.css']
})
export class WorkoutListItemComponent implements OnInit {

  @Input() workoutId: number = 0;

  get workout(): Workout | undefined {
    return this.workoutService.getWorkout(this.workoutId);
  }

  get set(): Set | undefined {
    return this.workoutService.getSet(this.workoutId);
  }

  get exercise(): Exercise | undefined {
    return this.workoutService.getExercise(this.workoutId)
  }

  constructor(
    private readonly workoutService: WorkoutService
  ) { }

  ngOnInit(): void {
    this.workoutService.getWorkoutById(this.workoutId)
    this.workoutService.getSetFromWorkout(this.workoutId)
    this.workoutService.getExerciseFromWorkout(this.workoutId)
  }

}
