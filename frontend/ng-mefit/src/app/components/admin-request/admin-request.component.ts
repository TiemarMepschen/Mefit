import { Component, Input, OnInit } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';
import { User } from 'src/app/models/user.model';
import { ProfileService } from 'src/app/services/profile.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-request',
  templateUrl: './admin-request.component.html',
  styleUrls: ['./admin-request.component.css']
})
export class AdminRequestComponent implements OnInit {

  constructor(
    private readonly userService: UserService,
    private readonly profileService: ProfileService,
    private readonly keycloak: KeycloakService
    ) { }

  get isAdmin(): boolean | undefined {
    if(this.profileService.user?.isAdmin === 1 || this.profileService.user?.isAdmin === 2){
      return true
    }
    return false;
  }

  ngOnInit(): void {
  }

  public handleAdminRequestButton() {    
    let userId = sessionStorage.getItem('userId')
    this.userService.updateUserAdminRequest(Number.parseInt(userId!))
    console.log(`User with ID: ${userId} has made a request to become an admin.`)
    document.getElementById('removeAdminButton')!.remove();
    document.getElementById('Admin')!.innerText = "Admin: Pending"
  }

  public handleChangePasswordButton(){
    this.keycloak.login({
      action: "UPDATE_PASSWORD",
    })
  }

}
