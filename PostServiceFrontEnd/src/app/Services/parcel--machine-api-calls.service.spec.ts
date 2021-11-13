import { TestBed } from '@angular/core/testing';

import { ParcelMachineApiCallsService } from './parcel--machine-api-calls.service';

describe('ParcelMachineApiCallsService', () => {
  let service: ParcelMachineApiCallsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ParcelMachineApiCallsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
