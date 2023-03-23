import { Component, ElementRef, NgModule, OnInit, ViewChild } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthResponseDto } from '../../core/models/response/authResponseDto.model';
import { UserForAuthenticationDto } from '../../core/models/user/userForAuthenticationDto.model';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../core/services/authentication.service'
import { ViewEncapsulation } from '@angular/core'
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ExternalAuthDto } from '../../core/models/externalAuth/externalAuthDto.model'
import { NONE_TYPE } from '@angular/compiler';
import { SocialUser } from '@abacritt/angularx-social-login/entities/social-user';
import { GoogleLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';
import { UserForRegistrationDto } from 'src/app/core/models/user/userForRegistrationDto.model';
import { PasswordConfirmationValidatorService } from 'src/app/core/password-confirmation-validator.service';
@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  registerForm: FormGroup | any;
  errorMessage: string = '';
  showError: boolean = true;

  constructor(private authService: AuthenticationService,
    private passConfValidator: PasswordConfirmationValidatorService, private router: Router) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });
    this.registerForm.get('confirm').setValidators([Validators.required,
    this.passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }

  public validateControl = (controlName: string) => {
    return this.registerForm.get(controlName).invalid && this.registerForm.get(controlName).touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName).hasError(errorName)
  }

  public registerUser = (registerFormValue: any) => {
    this.showError = false;
    const formValues = { ...registerFormValue };

    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
      clientURI: 'http://localhost:4200/authentication/emailconfirmation'
    };

    this.authService.registerUser("api/accounts/registration", user)
      .subscribe({
        next: (_: any) => this.router.navigate(["/authentication/login"]),
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.message;
          this.showError = true;
        }
      })
  }
}
