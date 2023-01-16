import { Component, ElementRef, NgModule, OnInit, ViewChild } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthResponseDto } from '../core/models/response/authResponseDto.model';
import { UserForAuthenticationDto } from '../core/models/user/userForAuthenticationDto.model';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../core/services/authentication.service'
import { ViewEncapsulation } from '@angular/core'
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ExternalAuthDto } from '../core/models/externalAuth/externalAuthDto.model'
import { NONE_TYPE } from '@angular/compiler';
import { SocialUser } from '@abacritt/angularx-social-login/entities/social-user';
import { GoogleLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';

@Component({

  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

})
export class HomeComponent implements OnInit {
  //public title: string = "";
  private returnUrl: string = "";
  socialUser!: SocialUser;
  GoogleLoginProvider = GoogleLoginProvider;
  isLoggedin?: boolean;
  private accessToken: string = "";
  currentUrl: string = ""
  loginForm: FormGroup | any;
  errorMessage: string = '';
  showError: boolean = false;
  title: string = 'loginGoogle';
  auth2: any;
  @ViewChild('loginRef', { static: true }) loginElement!: ElementRef;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }
  ngOnInit() {

    this.googleAuthSDK();
  }


  externalLogin = () => {
    this.showError = false;
    this.authService.signInWithGoogle();
    this.authService.extAuthChanged.subscribe(user => {
      const externalAuth: ExternalAuthDto = {
        provider: user.provider,
        idToken: user.idToken
      }

      this.validateExternalAuth(externalAuth);
      //  console.log("login success");
    })
  }

  private validateExternalAuth(externalAuth: ExternalAuthDto) {
    this.authService.externalLogin('api/accounts/externallogin', externalAuth)
      .subscribe({
        next: (res) => {
          localStorage.setItem("token", res.token);
          console.log("from server", res.isAuthSuccessful);
          this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
          // this.router.navigate(["/biodata"]);
        },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.message;
          this.showError = true;
          this.authService.signOutExternal();
        }
      });
  }
  /**
   * Write code on Method
   *
   * @return response()
   */
  callLoginButton() {

    this.auth2.attachClickHandler(this.loginElement.nativeElement, {},
      (googleAuthUser: any) => {
        const profile = googleAuthUser.getBasicProfile();

        const externalAuth: ExternalAuthDto = {
          provider: 'Google',
          idToken: googleAuthUser.getAuthResponse().id_token,
        }
        this.authService.externalLogin('api/accounts/externallogin', externalAuth)
          .subscribe({
            next: (res) => {
              localStorage.setItem("token", res.token);
              localStorage.setItem("name", profile.getName());
              localStorage.setItem("email", profile.getEmail());
              localStorage.setItem("picture", profile.getImageUrl());
              this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
              this.router.navigate(["/welcome/live"]);
            },
            error: (err: HttpErrorResponse) => {
              this.errorMessage = err.message;
              console.log("error: ", err.message);
              this.showError = true;
              this.authService.signOutExternal();
            }
          });
        //localStorage.setItem("token", googleAuthUser.getAuthResponse().id_token);
        // this.authService.sendAuthStateChangeNotification(true);

        /* Write Your Code Here */
        // this.externalLogin();

      }, (error: any) => {
        alert(JSON.stringify(error, undefined, 2));
      });

  }
  /**
   * Write code on Method
   *
   * @return response()
   */
  googleAuthSDK() {

    (<any>window)['googleSDKLoaded'] = () => {
      (<any>window)['gapi'].load('auth2', () => {
        this.auth2 = (<any>window)['gapi'].auth2.init({
          client_id: '523793815073-jauafvqbh9cd3ncge3gvfiqv6e03td0b.apps.googleusercontent.com',
          cookiepolicy: 'single_host_origin',
          plugin_name: 'put anything here',
          scope: 'profile email'
        });
        this.callLoginButton();
      });
    }

    (function (d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) { return; }
      js = d.createElement('script');
      js.id = id;
      js.src = "https://apis.google.com/js/platform.js?onload=googleSDKLoaded";
      fjs?.parentNode?.insertBefore(js, fjs);
    }(document, 'script', 'google-jssdk'));

  }


}


