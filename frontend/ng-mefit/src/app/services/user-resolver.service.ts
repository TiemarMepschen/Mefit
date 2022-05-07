import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { catchError, of } from "rxjs";
import { ProfileService } from "./profile.service";
import { UserService } from "./user.service";

@Injectable( {
    providedIn: 'root'
})
export class UserResolverService implements Resolve<any> {
    constructor(
      protected readonly userService: UserService,
      protected readonly profileService: ProfileService ){}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) { 
      return this.userService.getAllUsers().pipe(
        catchError(error => {
          return of('No Data');
        })
      )
    }
}