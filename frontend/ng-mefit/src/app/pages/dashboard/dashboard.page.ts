import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { KeycloakService } from 'keycloak-angular';
import { UserService } from 'src/app/services/user.service';
import { Goal } from 'src/app/models/goal.model';
import { Program } from 'src/app/models/program.model';
import { Workout } from 'src/app/models/workout.model';
import { GoalService } from 'src/app/services/goal.service';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.page.html',
  styleUrls: ['./dashboard.page.css'],
})
export class DashboardPage implements OnInit {

  goal: any = "";
  daysTillDeadline: number = 4;
  workouts: Workout[] = [];
  currentGoal: Goal = { id: 0, endDate: new Date(), completed: false, programmeId: 0, completedWorkouts: [] };
  currentProgram: Program = { id: 0, name: "", workouts: [] };
  goalCompleted: boolean = false;
  hasGoal: boolean = false;

  constructor(
    private readonly router: Router,
    private readonly activateRoute: ActivatedRoute,
    private readonly profileService: ProfileService
  ) {}

  ngOnInit(): void {

    this.activateRoute.data.subscribe((response: any) => {
      // check if profile has goalId
      if(response.goal !== 'No data') {
        this.hasGoal = true;

        this.currentGoal = response.goal;
        this.workouts = response.workouts;
        this.currentProgram = response.program;

        console.log(this.currentGoal)
      }
    })
      // calculate days left to reach goal
      this.daysTillDeadline = this.calculateDiff(this.currentGoal.endDate);
    }

  calculateDiff(dateSent: Date) {
    let currentDate = new Date();
    dateSent = new Date(dateSent);

    return Math.floor((Date.UTC(dateSent.getFullYear(), dateSent.getMonth(), dateSent.getDate()) - Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate())) / (1000 * 60 * 60 * 24));
  }

  public handleNewGoalButtonClick() {
    this.router.navigateByUrl('/programs');
  }

  public handleDeleteGoalButtonClick() {
    this.profileService.deleteGoal(this.profileService.profile!.id, this.profileService.profile!.userId);
  }

  public handleUpdateGoalButtonClick() {
    this.router.navigateByUrl('/programs');
  }

  statusChangedHandler(status: boolean) {
    this.goalCompleted = status;
    console.log(this.goalCompleted)
  }
}
