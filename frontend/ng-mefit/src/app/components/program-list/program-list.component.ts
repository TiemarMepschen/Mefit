import { Component, Input, OnInit } from '@angular/core';
import { Program } from 'src/app/models/program.model';
import { ProgramService } from 'src/app/services/program.service';

@Component({
  selector: 'app-program-list',
  templateUrl: './program-list.component.html',
  styleUrls: ['./program-list.component.css']
})
export class ProgramListComponent implements OnInit {

  get programList(): Program[] | undefined {
    return this.programService.programs;
  }

  constructor(
    private readonly programService: ProgramService
  ) { }

  ngOnInit(): void {
    this.programService.getAllPrograms();
  }

}
