import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './home/home.component';
import { ErrorHandlerService } from './core/services/error-handler.service';
import { SpinnerComponent } from './spinner/spinner.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { RouterModule } from '@angular/router';
import { AuthenticationModule } from './authentication/authentication.module';
import { AuthenticationComponent } from './authentication/authentication.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}


@NgModule({

  declarations: [AppComponent, HomeComponent, SpinnerComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, SharedModule, SocialLoginModule, AngularSvgIconModule.forRoot(), FormsModule,
    ReactiveFormsModule, RouterModule,

    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    }),

  ],

  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true,


    },
    /*  {
       provide: HTTP_INTERCEPTORS,
       useClass: LoadingInterceptor,
       multi: true,
 
 
     }, */
    {
      provide: 'SocialAuthServiceConfig',

      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '523793815073-jauafvqbh9cd3ncge3gvfiqv6e03td0b.apps.googleusercontent.com'
            ),
          },


        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig,
    },
  ],

  bootstrap: [AppComponent],
})
export class AppModule { }
