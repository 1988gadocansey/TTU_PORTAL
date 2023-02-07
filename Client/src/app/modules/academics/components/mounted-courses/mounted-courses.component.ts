import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import MountedCourse from 'src/app/core/models/academics/mountedCourses';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RepositoryService } from '../../../../core/services/repository.service';
import { FormArray, FormBuilder } from '@angular/forms';
import { MountedCourseDto } from 'src/app/core/models/academics/mountedCourseDto';

@Component({
  selector: 'app-mounted-courses',
  templateUrl: './mounted-courses.component.html',
  styleUrls: ['./mounted-courses.component.scss']
})
export class MountedCoursesComponent {
  public courseRegistrationForm: FormGroup;
  submitted = false;
  public id: Number = 0;
  public mountedCourseToServer: MountedCourseDto[] = []
  public courses: MountedCourse[] = [];
  totalCredit: any;

  constructor(private repository: RepositoryService, private fb: FormBuilder) {

    this.courseRegistrationForm = this.fb.group({
      courseCode: [],
      courseId: [],
      courseLecturer: [],
      courseCredit: [],
      courseLevel: [],
      totalCredit: [],
      electiveCourses: [],
      coreCourses: [],

    });
    // Set Values
    this.courseRegistrationForm.controls["coreCourses"].setValue(1);
  }

  ngOnInit(): void {
    this.getCourses();
  }
  getCourses = () => {
    this.repository.getMountedCourses().subscribe((data: MountedCourse[]) => {
      this.courses = data;
      console.log(this.courses);
    })
  }


  /*  resetForm() {
     this.personForm.controls["firstName"].setValue(this.person.firstName);
     this.personForm.controls["lastName"].setValue(this.person.lastName);
   }
  */

  saveForm() {
    console.warn(this.courseRegistrationForm.value);

    this.repository.registerCourses(this.courseRegistrationForm.value).subscribe((res: any) => {
      console.log('course registered successfully!');
      // this.router.navigateByUrl('post/index');
    })
  }
}
