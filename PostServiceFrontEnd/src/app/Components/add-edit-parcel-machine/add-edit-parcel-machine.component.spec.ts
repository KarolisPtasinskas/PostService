import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditParcelMachineComponent } from './add-edit-parcel-machine.component';

describe('AddEditParcelMachineComponent', () => {
  let component: AddEditParcelMachineComponent;
  let fixture: ComponentFixture<AddEditParcelMachineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditParcelMachineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditParcelMachineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
