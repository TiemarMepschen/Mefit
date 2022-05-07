import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profile, User } from '../models/user.model';

const { API_URL } = environment;

@Injectable({
  providedIn: 'root',
})
export class ProfileService {

  constructor(private readonly http: HttpClient) {}

  // get user
  get user(): User | undefined{
    let userObject = JSON.parse(sessionStorage.getItem('userObject')!)
    return userObject
  }

  // get profile
  get profile(): Profile | undefined{
    let profileObject = JSON.parse(sessionStorage.getItem('profileObject')!)
    return profileObject;
  }
  
  public updateProfile(currentGoalId: number): any {

    let profileObject = JSON.parse(sessionStorage.getItem('profileObject')!)
    profileObject.currentGoalId = currentGoalId;

    this.http.put<Profile>(`${API_URL}/Profile/${profileObject.id}`, profileObject)
    .subscribe({
      next: (profile: Profile) => {
        this.getProfileById(profileObject.id);
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      }
    })
  }

  // get profile by id
  public getProfileById(id: number): any{
    this.http.get<Profile>(`${API_URL}/Profile/${id}`)
    .subscribe({
      next: (profile: Profile) => {
          sessionStorage.setItem('profileObject', JSON.stringify(profile));
      },
      error: (error: HttpErrorResponse) => {
        throw new Error(error.message);
      },
    });
  }

  public deleteGoal(id: number, userId: number): any {
    const body = {
      id: id,
      currentGoalId: null,
      goalId: null,
      userId: userId
    }
    this.http.put(`${API_URL}/Profile/${id}`, body).subscribe({});
  }
}
