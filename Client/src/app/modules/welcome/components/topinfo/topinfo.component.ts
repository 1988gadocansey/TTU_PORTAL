import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { RepositoryService } from '../../../../core/services/repository.service';


@Component({
  selector: 'app-topinfo',
  templateUrl: './topinfo.component.html',
  styleUrls: ['./topinfo.component.scss']
})
export class TopinfoComponent {
  public profile: any = [];
  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getProfile();
  }
  getProfile = () => {
    const apiAddress: string = "api/dashboard";
    this.repository.getDashboard(apiAddress)
      .subscribe(data => {
        this.profile = data,
          console.log(this.profile)


      })

  }
}
