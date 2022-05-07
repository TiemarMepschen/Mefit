import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-list',
  templateUrl: './admin-list.component.html',
  styleUrls: ['./admin-list.component.css']
})
export class AdminListComponent implements OnInit {

  @Input() user?: User;

  constructor(
    private readonly userService: UserService) { }

  ngOnInit(): void {

  }

  public handleAdminAcceptButton(id: number) {
    this.userService.updateUserAdminAccepted(id)
    console.log(`User with ID: ${id} has become an admin.`)

    document.getElementById('removeUser')!.remove();
    //location.reload();
  }

  public handleAdminRejectButton(id: number) {
    this.userService.updateUserAdminRejected(id)
    console.log(`User with ID: ${id} has been rejected.`)

    document.getElementById('removeUser')!.remove();
    //location.reload();
  }
}
