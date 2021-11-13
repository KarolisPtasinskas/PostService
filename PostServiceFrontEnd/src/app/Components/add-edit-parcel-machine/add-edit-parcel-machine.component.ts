import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ParcelMachineApiCallsService } from 'src/app/Services/parcel--machine-api-calls.service';

@Component({
  selector: 'app-add-edit-parcel-machine',
  templateUrl: './add-edit-parcel-machine.component.html',
  styleUrls: ['./add-edit-parcel-machine.component.css'],
})
export class AddEditParcelMachineComponent implements OnInit {
  id: string;
  town: string;
  address: string;
  capacity: string;
  identificationCode: string;

  editActive: boolean = false;

  errorMessages: string[] = [];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private parcelMachineApi: ParcelMachineApiCallsService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(
      (param) => (this.id = param.get('id'))
    );

    if (this.id != null) {
      this.parcelMachineApi.getParcelMachineById(this.id).subscribe((data) => {
        this.town = data.town;
        this.address = data.address;
        this.capacity = data.capacity;
        this.identificationCode = data.identificationCode;
      });

      this.editActive = true;
    }
  }

  createParcelMachine() {
    this.errorMessages = [];

    let newMachine = {
      town: this.town,
      address: this.address,
      capacity: this.capacity,
      identificationCode: this.identificationCode,
    };

    this.parcelMachineApi.addParcelMachine(newMachine).subscribe(
      (response) => {
        this.town = '';
        this.address = '';
        this.capacity = '';
        this.identificationCode = '';
      },
      (error) => {
        console.log(error.error.errors);
        Object.entries(error.error.errors).forEach(([key, value]) =>
          this.errorMessages.push(`${value}`)
        );
      }
    );
  }

  updateParcelMachine() {
    this.errorMessages = [];

    let newMachine = {
      id: parseInt(this.id),
      town: this.town,
      address: this.address,
      capacity: this.capacity,
      identificationCode: this.identificationCode,
    };

    this.parcelMachineApi.updateParcelMachine(newMachine).subscribe(
      (data) => {
        this.router.navigate(['/parcel-machine-list']);
      },
      (error) => {
        Object.entries(error.error.errors).forEach(([key, value]) =>
          this.errorMessages.push(`${value}`)
        );
      }
    );
  }

  deleteParcelMachine() {
    this.errorMessages = [];

    this.parcelMachineApi.deleteParcelMachine(this.id).subscribe(
      (data) => {
        this.router.navigate(['/parcel-machine-list']);
      },
      (error) => {
        console.log(error);
        this.errorMessages.push(`${error.error}`);
      }
    );
  }
}
