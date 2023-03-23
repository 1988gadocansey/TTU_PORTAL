import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForgotPasswordComponent } from './authentication/forgot-password/forgot-password.component';
import { RegisterUserComponent } from './authentication/register-user/register-user.component';
import { ResetPasswordComponent } from './authentication/reset-password/reset-password.component';
import { TwoStepVerificationComponent } from './authentication/two-step-verification/two-step-verification.component';
import { BiodataComponent } from './biodata/biodata.component';
import { AuthGuard } from './core/guards/auth.guard';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'authentication/register', component: RegisterUserComponent },
  { path: 'authentication/forgotpassword', component: ForgotPasswordComponent },
  { path: 'authentication/resetpassword', component: ResetPasswordComponent },
  { path: 'authentication/twostepverification', component: TwoStepVerificationComponent },
  { path: 'biodata', component: BiodataComponent, canActivate: [AuthGuard] },
  { path: '404', component: NotFoundComponent },

  {
    path: '',
    loadChildren: () => import('./modules/layout/layout.module').then((m) => m.LayoutModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  //{ path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },

  //{ path: '**', redirectTo: 'error/404' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
