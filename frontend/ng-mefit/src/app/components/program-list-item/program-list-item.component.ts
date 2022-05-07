import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Program } from 'src/app/models/program.model';
import { GoalService } from 'src/app/services/goal.service';

@Component({
  selector: 'app-program-list-item',
  templateUrl: './program-list-item.component.html',
  styleUrls: ['./program-list-item.component.css']
})
export class ProgramListItemComponent implements OnInit {

  @Input() program: Program = {
    id: 0,
    name: '',
    workouts: []
  }
  @Input() showDetails: boolean = false;


  constructor( ) { }

  ngOnInit(): void {
  }

  handleClicked(): void {
    this.showDetails = !this.showDetails
  }
}
