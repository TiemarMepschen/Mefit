import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Goal } from '../models/goal.model';
import { Program } from '../models/program.model';
import { Workout } from '../models/workout.model';
import { StorageUtil } from '../utils/storage.util';

const { API_URL } = environment;

@Injectable({
  providedIn: 'root'
})
export class GoalService {

  constructor(
    private readonly http: HttpClient,
    protected readonly keycloak: KeycloakService
  ) { }

  // get goal by id
  public getGoalById(id: number): Observable<Goal> {
    return this.http.get<Goal>(`${API_URL}/Goal/${id}`)
  }

  // get programme for a specific goal (by id)
  public getProgramById(id: number): Observable<Program | any> {
    return this.http.get<Program>(`${API_URL}/Goal/${id}/program`);
  }

  /**
   * Saves a program object to sessionstorage by goal id.
   * @param id Goal id
   */
  public saveProgramById(id: number): void {
    this.http.get<Program>(`${API_URL}/Goal/${id}/program`)
    .subscribe({
      next: (program: Program) => {
        sessionStorage.setItem(`goalObject${id}Program`, JSON.stringify(program))
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }

  /**
   * Gets a program object from the sessionstorage by goal id.
   * @param id Goal id
   * @returns A program object.
   */
   getProgram(id: number): Program | undefined {
    let goalObject = JSON.parse(sessionStorage.getItem(`goalObject${id}Program`)!)
    return goalObject;
  }

  // get all workouts for a specific goal (by id)
  public getWorkoutsById(id: number): Observable<Workout[]> {
    return this.http.get<Workout[]>(`${API_URL}/Goal/${id}/workout`);
  }

  public getWorkoutsToStorage(id: number): void {
    this.http.get<Workout[]>(`${API_URL}/Goal/${id}/workouts`).subscribe({
      next: (workouts: Workout[]) => {
        StorageUtil.storageSave<Workout[]>('workouts', workouts);
      }
    })
  }
  
  // create a new goal
  public createGoal(endDate: Date, programId: number): Observable<any> {
    // create new goal
    const goal: any = {
      EndDate: endDate,
      Completed: false,
      ProgrammeId: programId
    }

    // POST request
    return this.http.post<any>(`${API_URL}/Goal`, goal);
  }
}
