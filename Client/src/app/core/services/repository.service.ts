import { Calender } from '../../core/models/calender/calender';
import { Event } from '../../core/models/events/event';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';
import MountedCourse from '../models/academics/mountedCourses';
import { catchError, Observable } from 'rxjs';
import { TimeTable } from '../models/welcome/timetable.model';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getDashboard = (route: string) => {
    return this.http.get<any>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }



  getMountedCourses(): Observable<MountedCourse[]> {
    return this.http.get<MountedCourse[]>(this.createCompleteRoute("api/courses", this.envUrl.urlAddress));

  }
  getUpcomingLectures(): Observable<any[]> {
    return this.http.get<any[]>(this.createCompleteRoute("api/dashboard", this.envUrl.urlAddress));

  }
  getUpcomingLectures2 = (route: string) => {
    return this.http.get<TimeTable>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }




  public getClaims = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}