import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-profile-menu',
  templateUrl: './profile-menu.component.html',
  styleUrls: ['./profile-menu.component.scss'],
})
export class ProfileMenuComponent implements OnInit {
  public isMenuOpen = false;
  public profilePicture: string | any;
  public name: string | any
  public email: string | any
  public isUserAuthenticated: boolean | any = false;
  constructor(private authService: AuthenticationService, private router: Router) {
    this.authService.authChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      })
  }

  ngOnInit(): void {
    this.authService.authChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      })
    this.name = localStorage.getItem("name");
    this.profilePicture = localStorage.getItem("picture");
    this.email = localStorage.getItem("email");
  }



  public toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }
  public logout = () => {
    this.authService.logout();

    if (this.authService.isExternalAuth)
      this.authService.signOutExternal();

    this.router.navigate(["/"]);
  }
}
