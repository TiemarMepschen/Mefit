import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { KeycloakService } from 'keycloak-angular';
import { catchError, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';
import { ProfileService } from './profile.service';

const { API_URL } = environment;

@Injectable({
  providedIn: 'root',
})

export class UserService {
  constructor(
    private readonly http: HttpClient,
    protected readonly keycloak: KeycloakService,
    protected readonly router: Router,
    private readonly profileService: ProfileService
  ) {}

  private _users: User[] = [];
  private _error: string = '';

  // get for all users
  public get users(): User[] | undefined {
    return this._users;
  }

  // get for error message
  public get error(): string {
    return this._error;
  }

  // get keycloak token
  getKeycloak() {
    this.keycloak
      .getToken()
      .then((data) => localStorage.setItem('token', data));
  }

  // get keycloakId
  public setKeyCloakId() {
    this.keycloak.loadUserProfile().then((data) => {
      sessionStorage.setItem('keycloakId', data.id!)
    })
  }

  //get user and post user if user doesn't exist
  public user() {
    this.getKeycloak();
    let authToken = localStorage.getItem('token');
    let getHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + authToken,
    });

    this.keycloak.loadUserProfile().then((data) => {
      let keycloakUserObject = {
        firstName: data.firstName,
        lastName: data.lastName,
        keycloakId: data.id,
        isAdmin: 0,
        profile: {
          goalId: null,
          currentGoalId: null
        }
      };

      this.http
      .get<User>(`${API_URL}/User`, {
        headers: getHeaders,
      })
      .subscribe((result) => {
        if(Object.values(result).some(x => x.keycloakId == keycloakUserObject.keycloakId)){
          this.http.get<User>(`${API_URL}/User/${data.id}/keycloakId`, { headers: getHeaders })
          .subscribe((result) => {
            sessionStorage.setItem('userId', result.id.toString())
            sessionStorage.setItem('userObject', JSON.stringify(result))
            this.profileService.getProfileById(result.id);
          });
        }
        else{
          this.http.post<User>(`${API_URL}/User`, keycloakUserObject, {
            headers: getHeaders 
           })
           .subscribe((result) => {
            sessionStorage.setItem('userObject', JSON.stringify(result))
           });
        }
      });
    });
  }

  // update isAdmin value in user
  public updateUserAdminRequest(id: number): any{
    let userObject = JSON.parse(sessionStorage.getItem('userObject')!)

    userObject.isAdmin = 2;

    console.log(userObject)

    this.http.put<User>(`${API_URL}/User/${id}`, userObject)
    .subscribe({
      next: (user: User) => {
        console.log(user)
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }

  // update isAdmin if Admin accepted 'become admin' request
  public updateUserAdminAccepted(id: number): any{
    this.getUserById(id).subscribe({
      next: (user: User) => {
        console.log(user)
        user.isAdmin = 1;
    
        this.http.put<User>(`${API_URL}/User/${id}`, user)
        .subscribe({
          next: (user: User) => {
            console.log(user)
          },
          error: (error: HttpErrorResponse) => {
            throw new Error(error.message);
          }
        })
      },
    })
  }

   // update isAdmin if Admin rejected 'become admin' request
   public updateUserAdminRejected(id: number): any{
    this.getUserById(id).subscribe({
      next: (user: User) => {
        console.log(user)
        user.isAdmin = 0;
    
        this.http.put<User>(`${API_URL}/User/${id}`, user)
        .subscribe({
          next: (user: User) => {
            console.log(user)
          },
          error: (error: HttpErrorResponse) => {
            throw new Error(error.message);
          }
        })
      },
    })
  }

  // get user by user ID
  public getUserById(id: number): Observable<User>{
    return this.http.get<User>(`${API_URL}/User/${id}/userId`)
  }

  // get user by keycloak ID
  public getUserByKeycloakId(id: string): Observable<User>{
    return this.http.get<User>(`${API_URL}/User/${id}/keycloakId`)
  }

  // get all users
  public getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${API_URL}/User`)
  }
}
