import { Calender } from '../../core/models/calender/calender';
import { Event } from '../../core/models/events/event';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }


  public getLogs = (route: string) => {
    return this.http.get<Event[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public getDashboard = (route: string) => {
    return this.http.get<any>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getClaims = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}