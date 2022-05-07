import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { ProfileService } from 'src/app/services/profile.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.page.html',
  styleUrls: ['./admin.page.css']
})
export class AdminPage implements OnInit {

  users: User[] = []
  isAdmin: number = 0;

  constructor(
    private readonly router: Router,
    private readonly profileService: ProfileService,
    private readonly userService: UserService,
    private readonly activatedRoute: ActivatedRoute) { }

    
  ngOnInit(): void {
    this.activatedRoute.data.subscribe((response: any) => {
      this.isAdmin = response.admin.isAdmin;
      this.users = response.user;
    })

    this.users = this.users.filter(t => t.isAdmin === 2)

    if(this.isAdmin != 1){
      this.router.navigateByUrl('/dashboard');
    }

    //setTimeout(() => { this.ngOnInit() }, 1000 * 10)

    // console.log(this.profileService.user?.isAdmin)
    // if(this.profileService.user?.isAdmin != 1){
    //   this.router.navigateByUrl('/dashboard');
    // }
  }
}
