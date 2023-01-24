import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LatestpaymentsComponent } from './latestpayments.component';

describe('LatestpaymentsComponent', () => {
  let component: LatestpaymentsComponent;
  let fixture: ComponentFixture<LatestpaymentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LatestpaymentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LatestpaymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
