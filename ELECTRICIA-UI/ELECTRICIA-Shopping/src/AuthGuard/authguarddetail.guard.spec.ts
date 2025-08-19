import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { authguarddetailGuard } from './authguarddetail.guard';

describe('authguarddetailGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => authguarddetailGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
