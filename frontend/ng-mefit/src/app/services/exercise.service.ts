import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';
import { environment } from 'src/environments/environment';
import { Exercise } from '../models/exercise.model';

const { API_URL} = environment;

@Injectable({
  providedIn: 'root'
})
export class ExerciseService {

  private _exercises: Exercise[] = [];
  private _error: string = '';

  constructor(
    private readonly http: HttpClient
  ) { }

  // get for all exercises
  public get exercises(): Exercise[] | undefined {
    return this._exercises;
  }

  // get for error message
  public get error(): string {
    return this._error;
  }

  // get all exercises
  public getAllExercises(): void {
    this.http.get<Exercise[]>(`${API_URL}/Exercise`)
    .subscribe({
      next: (exercises: any) => {
        console.log(exercises);
        this._exercises = exercises;
      },
      error: (error: HttpErrorResponse) => {
        console.log(error)
        this._error = error.message;
      }
    })
  }


  // get specific exercise
  public getExerciseById(id: number): Exercise | any {
    this.http.get<Exercise[]>(`${API_URL}/Exercise/${id}`)
    .subscribe({
      next: (exercise: any) => {
        return exercise;
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message)
      }
    })
  }
}
