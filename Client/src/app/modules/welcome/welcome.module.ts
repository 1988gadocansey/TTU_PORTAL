import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WelcomeComponent } from './welcome.component';
import { HttpClientModule } from '@angular/common/http';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { NgApexchartsModule } from 'ng-apexcharts';
import { SharedModule } from 'src/app/shared/shared.module';
import { WelcomeRoutingModule } from './welcome-routing.module';
import { InfoComponent } from './pages/info/info.component';
import { TopinfoComponent } from './components/topinfo/topinfo.component';

import { UpcominglecturesComponent } from './components/upcominglectures/upcominglectures.component';
import { IssuesComponent } from './components/issues/issues.component';
import { FeebalanceComponent } from './components/feebalance/feebalance.component';



@NgModule({
  declarations: [
    WelcomeComponent,
    InfoComponent,
    TopinfoComponent,

    UpcominglecturesComponent,
    IssuesComponent,
    FeebalanceComponent

  ],
  imports: [
    CommonModule,
    SharedModule,
    HttpClientModule,
    WelcomeRoutingModule,
    NgApexchartsModule,
    AngularSvgIconModule.forRoot(),
  ]
})
export class WelcomeModule { }
