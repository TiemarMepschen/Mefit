import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Goal } from 'src/app/models/goal.model';
import { Workout } from 'src/app/models/workout.model';
import { StorageUtil } from 'src/app/utils/storage.util';
import { environment } from 'src/environments/environment';

const { API_URL } = environment;

@Component({
  selector: 'app-progress-form',
  templateUrl: './progress-form.component.html',
  styleUrls: ['./progress-form.component.css']
})

export class ProgressFormComponent implements OnInit {

  @Input() workouts: Workout[] = [];

  @Input() currentGoal: Goal = { id: 0, endDate: new Date(), completed: false, programmeId: 0, completedWorkouts: [] };

  @Output() statusChanged: EventEmitter<boolean> = new EventEmitter();

  totalComplete : number = 0;
  totalWorkouts : number = 0;
  completedWorkoutArray: number[] = []
  status: boolean = true;
  addWorkoutArray: boolean = false;
  
  constructor(private readonly http: HttpClient) { }

  ngOnInit(): void {
    // calculate nr of completed workouts
    this.workouts.forEach(workout => {
      this.totalWorkouts++;
      this.totalComplete = this.currentGoal.completedWorkouts.length;
    })
    if (this.totalComplete === this.totalWorkouts) {
      this.statusChanged.emit(true);
    }

    // load all completed workouts
    this.completedWorkoutArray = this.currentGoal.completedWorkouts
  }

  ngOnDestroy() {
  }

  public updateTotalComplete(checkboxSelect: number, completedWorkout: Workout) {
    if(!this.addWorkoutArray){
      console.log("Test")
      this.completedWorkoutArray = this.currentGoal.completedWorkouts
      this.addWorkoutArray = true;
    }
    this.isChecked();

    if (checkboxSelect == completedWorkout.id && !this.completedWorkoutArray.includes(checkboxSelect)) {
      this.completedWorkoutArray.push(completedWorkout.id)

      this.updateCompletedWorkout(this.currentGoal.id, this.completedWorkoutArray)

      this.totalComplete++;
      
      if (this.totalComplete === this.totalWorkouts) {
        this.statusChanged.emit(true);
      }
    }
    else {
      this.completedWorkoutArray = this.completedWorkoutArray.filter(item => item !== completedWorkout.id);

      this.updateCompletedWorkout(this.currentGoal.id, this.completedWorkoutArray)

      if (this.totalComplete === this.totalWorkouts) {
        this.statusChanged.emit(false);
      }
      this.totalComplete--;
    }

    console.log(this.completedWorkoutArray)
  }

  public updateCompletedWorkout(id: number, workoutArray: number[]){
    this.http.put(`${API_URL}/Goal/${id}`, workoutArray)
    .subscribe({
      next: () => {
        console.log("Completed workouts have been updated.")
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }

  isChecked(){
    this.status = true;
  }
}
