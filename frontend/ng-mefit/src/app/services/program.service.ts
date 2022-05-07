import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Program } from '../models/program.model';

const { API_URL} = environment;

@Injectable({
  providedIn: 'root'
})
export class ProgramService {

  private _programs: Program[] = [];
  private _error: string = '';

  constructor(
    private readonly http: HttpClient
  ) { }

  public get programs(): Program[] | undefined {
    return this._programs;
  }

  // get for error message
  public get error(): string {
    return this._error;
  }

  /**
   * Get all programs from the database
   */
  public getAllPrograms(): void {
    this.http.get<Program[]>(`${API_URL}/Programme`)
    .subscribe({
      next: (programs: any) => {
        this._programs = programs;
      },
      error: (error: HttpErrorResponse) => {
        this._error = error.message;
      }
    })
  }
}
