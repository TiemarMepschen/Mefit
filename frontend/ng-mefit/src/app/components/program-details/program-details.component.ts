import { Component, Input, OnInit } from '@angular/core';
import { Program } from 'src/app/models/program.model';

@Component({
  selector: 'app-program-details',
  templateUrl: './program-details.component.html',
  styleUrls: ['./program-details.component.css']
})
export class ProgramDetailsComponent implements OnInit {

  @Input() program: Program = {
    id: 0,
    name: '',
    workouts: []
  }

  constructor() { }

  ngOnInit(): void {
  }

}
