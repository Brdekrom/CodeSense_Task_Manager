import { TestBed } from '@angular/core/testing';

import { UserClientService } from './user-Client.service';

describe('UserService', () => {
  let service: UserClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
