import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import MountedCourse from 'src/app/core/models/academics/mountedCourses';

import { RepositoryService } from '../../../../core/services/repository.service';


@Component({
  selector: 'app-mounted-courses',
  templateUrl: './mounted-courses.component.html',
  styleUrls: ['./mounted-courses.component.scss']
})
export class MountedCoursesComponent {

  public courses: MountedCourse[] = [];

  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getCourses();
  }
  getCourses = () => {
    this.repository.getMountedCourses().subscribe((data: MountedCourse[]) => {
      this.courses = data;
      console.log(this.courses);
    })
  }
}
