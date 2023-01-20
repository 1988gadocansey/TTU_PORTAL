import { Component, OnInit } from '@angular/core';
import { MountedCourse } from 'src/app/core/models/academics/mountedCourses';

import { RepositoryService } from '../../../../core/services/repository.service';


@Component({
  selector: 'app-mounted-courses',
  templateUrl: './mounted-courses.component.html',
  styleUrls: ['./mounted-courses.component.scss']
})
export class MountedCoursesComponent {
  courses: MountedCourse[] = [];
  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getCourses();
  }
  getCourses = () => {
    const apiAddress: string = "api/courses";
    this.repository.getMountedCourses(apiAddress)
      .subscribe(data => {
        this.courses = data,
          console.log(this.courses)


      })

  }
}
