import { TestBed } from '@angular/core/testing';

import { MarshService } from './marsh.service';

describe('MarshService', () => {
  let service: MarshService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MarshService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
