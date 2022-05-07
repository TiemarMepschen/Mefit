import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Exercise } from '../models/exercise.model';
import { Set } from '../models/set.model';
import { Workout } from '../models/workout.model';

const { API_URL} = environment;

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {

  private _workouts: Workout[] = [];
  private _error: string = '';

  constructor(
    private readonly http: HttpClient
  ) { }

  // get for all workouts
  public get workouts(): Workout[] | undefined {
    return this._workouts;
  }

  // get for error message
  public get error(): string {
    return this._error;
  }

  // get all workouts
  public getAllWorkouts(): void {
    this.http.get<Workout[]>(`${API_URL}/Workout`)
    .subscribe({
      next: (workouts: any) => {
        this._workouts = workouts;
      },
      error: (error: HttpErrorResponse) => {
        this._error = error.message;
      }
    })
  }

  /**
   * Gets a workout object from the sessionstorage by id.
   * @param id Workout id
   * @returns A workout object.
   */
  getWorkout(id: number): Workout | undefined {
    let workoutObject = JSON.parse(sessionStorage.getItem(`workoutObject${id}`)!)
    return workoutObject;
  }

  /**
   * Gets the set associated to the workout by ID.
   * @param workoutId Workout id
   * @returns A set object.
   */
  getSet(workoutId: number): Set | undefined {
    let setObject = JSON.parse(sessionStorage.getItem(`workoutObject${workoutId}set`)!)
    return setObject
  }

  /**
   * Gets the exercise associated to the workout by ID.
   * @param workoutId Workout id
   * @returns An exercise object.
   */
   getExercise(workoutId: number): Exercise | undefined {
    let exerciseObject = JSON.parse(sessionStorage.getItem(`workoutObject${workoutId}exercise`)!)
    return exerciseObject
  }

  /**
   * Saves a workout to the session storage by id
   * @param id Workout id
   */
  public getWorkoutById(id: number): any {
    // Get the workout
    this.http.get<Workout>(`${API_URL}/Workout/${id}`)
    .subscribe({
      next: (workout: Workout) => {
        sessionStorage.setItem(`workoutObject${id}`, JSON.stringify(workout))
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }

  /**
   * Saves the set associated to a workout to the session storage by id
   * @param id Workout id
   */
  public getSetFromWorkout(id: number): any {
    // Get the set
    this.http.get<Set>(`${API_URL}/Workout/${id}/set`)
    .subscribe({
      next: (set: Set) => {
        sessionStorage.setItem(`workoutObject${id}set`, JSON.stringify(set))
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }

  /**
   * Saves the exercise associated to a workout to the session storage by id
   * @param id Workout id
   */
  public getExerciseFromWorkout(id: number): any {
    // Get the exercise
    this.http.get<Exercise>(`${API_URL}/Workout/${id}/exercise`)
    .subscribe({
      next: (exercise: Exercise) => {
        sessionStorage.setItem(`workoutObject${id}exercise`, JSON.stringify(exercise))
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }
}
