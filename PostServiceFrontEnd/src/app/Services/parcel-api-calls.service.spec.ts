import { TestBed } from '@angular/core/testing';

import { ParcelApiCallsService } from './parcel-api-calls.service';

describe('ParcelApiCallsService', () => {
  let service: ParcelApiCallsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParcelApiCallsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
