import { TestBed } from '@angular/core/testing';

import { ProjectClientService } from './project-Client.service';

describe('ProjectService', () => {
  let service: ProjectClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProjectClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
