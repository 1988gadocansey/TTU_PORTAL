import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TimeTable } from 'src/app/core/models/welcome/timetable.model';

import { RepositoryService } from '../../../../core/services/repository.service';

@Component({
  selector: 'app-upcominglectures',
  templateUrl: './upcominglectures.component.html',
  styleUrls: ['./upcominglectures.component.scss']
})


export class UpcominglecturesComponent {
  lectures: any = [];
  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getLectures();
  }
  getLectures = () => {
    this.repository.getUpcomingLectures2("api/dashboard")
      .subscribe(data => {
        this.lectures = data,
          console.log(this.lectures)


      })

  }
}
