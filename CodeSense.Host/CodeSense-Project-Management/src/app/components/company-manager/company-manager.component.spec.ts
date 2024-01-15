import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyManagerComponent } from './company-manager.component';

describe('CompanyManagerComponent', () => {
  let component: CompanyManagerComponent;
  let fixture: ComponentFixture<CompanyManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyManagerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanyManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
