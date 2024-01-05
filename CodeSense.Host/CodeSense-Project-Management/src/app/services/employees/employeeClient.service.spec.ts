import { TestBed } from '@angular/core/testing';

import { EmployeeClientService } from './employeeClient.service';

describe('EmployeeService', () => {
  let service: EmployeeClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
