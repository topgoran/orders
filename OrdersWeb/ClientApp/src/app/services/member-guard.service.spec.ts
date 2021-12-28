import { TestBed } from '@angular/core/testing';

import { MemberGuardService } from './member-guard.service';

describe('MemberGuardService', () => {
  let service: MemberGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MemberGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
