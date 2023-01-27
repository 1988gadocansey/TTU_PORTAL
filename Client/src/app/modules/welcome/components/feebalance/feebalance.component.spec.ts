import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeebalanceComponent } from './feebalance.component';

describe('FeebalanceComponent', () => {
  let component: FeebalanceComponent;
  let fixture: ComponentFixture<FeebalanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeebalanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeebalanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
