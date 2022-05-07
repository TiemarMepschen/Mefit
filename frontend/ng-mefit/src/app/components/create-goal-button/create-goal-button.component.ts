import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Program } from 'src/app/models/program.model';
import { GoalService } from 'src/app/services/goal.service';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-create-goal-button',
  templateUrl: './create-goal-button.component.html',
  styleUrls: ['./create-goal-button.component.css']
})
export class CreateGoalButtonComponent implements OnInit {

  @Input() program: Program = {
    id: 0,
    name: '',
    workouts: []
  }

  mininumDate: Date = new Date();
  popup: boolean = false;
  selectedDate: Date = new Date();

  constructor( 
    private readonly goalService: GoalService, 
    private readonly profileService: ProfileService, 
    private readonly modalService: NgbModal 
    ) { }

  ngOnInit(): void {
  }

  handleModalButton(content: any) {
    this.modalService.open(content);
  }

  public handleNewGoal(endDate: Date, programID: number) {
    // adjust time for local timezone
    endDate.setHours(endDate.getHours() + 2);
    // create a new goal
    this.goalService.createGoal(endDate, programID)
    .subscribe({
      next: data => {
        // update profile with new currentGoalId
        this.profileService.updateProfile(data.id);
        alert("A new goal has been created with end date: " + new Date(data.endDate).toLocaleDateString('pt-PT'));
      },
      error: (error: HttpErrorResponse) => {
        confirm(error.message);
        throw new Error(error.message);
      }
    })
  }
}
