import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParcelMachineListComponent } from './parcel-machine-list.component';

describe('ParcelMachineListComponent', () => {
  let component: ParcelMachineListComponent;
  let fixture: ComponentFixture<ParcelMachineListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParcelMachineListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ParcelMachineListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
