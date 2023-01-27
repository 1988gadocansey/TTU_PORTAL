import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { TimeTable } from 'src/app/core/models/welcome/timetable.model';

import { RepositoryService } from '../../../../core/services/repository.service';

@Component({
  selector: 'app-upcominglectures',
  templateUrl: './upcominglectures.component.html',
  styleUrls: ['./upcominglectures.component.scss']
})


export class UpcominglecturesComponent {
  @Input() lectures: any;
  constructor(private repository: RepositoryService) { }

}
