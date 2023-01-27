import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-latestpayments',
  templateUrl: './latestpayments.component.html',
  styleUrls: ['./latestpayments.component.scss']
})
export class LatestpaymentsComponent {

  @Input() payments: any;

}
