import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import MountedCourse from 'src/app/core/models/academics/mountedCourses';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RepositoryService } from '../../../../core/services/repository.service';
import { FormArray, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-mounted-courses',
  templateUrl: './mounted-courses.component.html',
  styleUrls: ['./mounted-courses.component.scss']
})
export class MountedCoursesComponent {
  public courseRegistrationForm: FormGroup;

  submitted = false;
  sample: number = 10;

  public courses: MountedCourse[] = [];

  constructor(private repository: RepositoryService, private fb: FormBuilder) {

    this.courseRegistrationForm = this.fb.group({
      //firstName: ['', Validators.required],
      courseCode: [],
      courseId: [],
      level: [],
      yearGroup: [],
      courseCredit: [],
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
    alert("registering course");
    console.log("dssdksjdksd");
  }
}
