import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcominglecturesComponent } from './upcominglectures.component';

describe('UpcominglecturesComponent', () => {
  let component: UpcominglecturesComponent;
  let fixture: ComponentFixture<UpcominglecturesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpcominglecturesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpcominglecturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
