import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectInputComponent } from './project-input.component';

describe('ProjectInputComponent', () => {
  let component: ProjectInputComponent;
  let fixture: ComponentFixture<ProjectInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProjectInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
