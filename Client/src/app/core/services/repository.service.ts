import { Calender } from '../../core/models/calender/calender';
import { Event } from '../../core/models/events/event';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';
import MountedCourse from '../models/academics/mountedCourses';
import { catchError, Observable, throwError } from 'rxjs';
import { TimeTable } from '../models/welcome/timetable.model';
import { MountedCourseDto } from '../models/academics/mountedCourseDto';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getDashboard = (route: string) => {
    return this.http.get<any>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }


  registerCourses(courses: MountedCourseDto): Observable<MountedCourseDto> {
    return this.http.post<MountedCourseDto>(this.createCompleteRoute("api/courses", this.envUrl.urlAddress), JSON.stringify(courses), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
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