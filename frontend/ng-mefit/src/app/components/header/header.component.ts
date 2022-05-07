import { Component, OnInit } from '@angular/core';
import { KeycloakService } from 'keycloak-angular';
import { User } from 'src/app/models/user.model';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
    private readonly keycloakService: KeycloakService,
    private readonly profileService: ProfileService
  ) { }

  ngOnInit(): void {
  }

  get username(): string | null {
    return sessionStorage.getItem('user');
  }

  get user(): boolean | undefined {
    if(this.profileService.user?.isAdmin == 1){
      return true
    }
    return false;
  }

  public handleLogout() {
    this.keycloakService.logout()
  }
}
