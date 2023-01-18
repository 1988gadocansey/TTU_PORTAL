import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcademicsComponent } from './academics.component';
import { AcademicsRoutingModule } from './academics.routing.module';
import { MountedCoursesComponent } from './components/mounted-courses/mounted-courses.component';
import { CourseRegistrationComponent } from './pages/course-registration/course-registration.component';



@NgModule({
  declarations: [
    AcademicsComponent,
    MountedCoursesComponent,
    CourseRegistrationComponent
  ],
  imports: [
    CommonModule,
    AcademicsRoutingModule
  ]
})
export class AcademicsModule { }
