import { TestBed } from '@angular/core/testing';

import { UserSysService } from './user-sys.service';

describe('UserSysService', () => {
  let service: UserSysService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserSysService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
