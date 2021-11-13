import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditParcelComponent } from './add-edit-parcel.component';

describe('AddEditParcelComponent', () => {
  let component: AddEditParcelComponent;
  let fixture: ComponentFixture<AddEditParcelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditParcelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditParcelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
