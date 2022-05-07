import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { catchError, Observable, of } from 'rxjs';
import { GoalService } from './goal.service';
import { ProfileService } from './profile.service';

@Injectable({
  providedIn: 'root',
})
export class GoalResolverService implements Resolve<any> {
  constructor(
    private readonly goalService: GoalService,
    private readonly router: Router,
    private readonly profileService: ProfileService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    if (this.profileService.profile?.currentGoalId) {
        return this.goalService.getGoalById(this.profileService.profile.currentGoalId).pipe(
            catchError((error) => {
              return of('No data');
            })
          );
    }
    else {
        return of('No data')
    }
  }
}
