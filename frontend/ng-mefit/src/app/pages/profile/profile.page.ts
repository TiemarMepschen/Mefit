import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Program } from 'src/app/models/program.model';
import { Profile, User } from 'src/app/models/user.model';
import { GoalService } from 'src/app/services/goal.service';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.css']
})
export class ProfilePage implements OnInit {

  get AdminType(): string | undefined{
    if(this.user?.isAdmin === 1){
      return "Yes"
    }
    else if(this.user?.isAdmin === 2){
      return "Pending"
    }
    else{
      return "No"
    }
  }

  get user(): User | undefined{
    return this.profileService.user;
  }

  get profile(): Profile | undefined{
    return this.profileService.profile;
  }

  get program(): Program | undefined {
    return this.goalService.getProgram(this.profileService.profile!.currentGoalId)
  }

  constructor(
    private readonly profileService: ProfileService,
    private readonly goalService: GoalService
  ) {}

  ngOnInit(): void {
    if (this.profile?.currentGoalId !== null) {
      this.goalService.saveProgramById(this.profileService.profile!.currentGoalId)
    }
  }
}
