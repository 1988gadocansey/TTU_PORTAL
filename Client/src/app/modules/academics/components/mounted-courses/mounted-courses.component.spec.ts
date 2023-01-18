import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MountedCoursesComponent } from './mounted-courses.component';

describe('MountedCoursesComponent', () => {
  let component: MountedCoursesComponent;
  let fixture: ComponentFixture<MountedCoursesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MountedCoursesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MountedCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
