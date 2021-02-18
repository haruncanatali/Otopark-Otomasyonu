import { TestBed } from '@angular/core/testing';

import { AracService } from './arac.service';

describe('AracService', () => {
  let service: AracService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AracService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
