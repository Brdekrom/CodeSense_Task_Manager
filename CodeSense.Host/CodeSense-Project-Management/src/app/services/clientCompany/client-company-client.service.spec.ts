import { TestBed } from '@angular/core/testing';

import { ClientCompanyClientService } from './client-company-client.service';

describe('ClientCompanyClientService', () => {
  let service: ClientCompanyClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientCompanyClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
