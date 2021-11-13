import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ParcelMachine } from 'src/app/Models/parcelMachine';
import { ParcelMachineApiCallsService } from 'src/app/Services/parcel--machine-api-calls.service';
import { ParcelApiCallsService } from 'src/app/Services/parcel-api-calls.service';

@Component({
  selector: 'app-add-edit-parcel',
  templateUrl: './add-edit-parcel.component.html',
  styleUrls: ['./add-edit-parcel.component.css'],
})
export class AddEditParcelComponent implements OnInit {
  parcelMachines: ParcelMachine[] = [];
  sortedPrcelMachines: ParcelMachine[] = [];

  id: string;
  receiverFullName: string;
  weight: string;
  phone: string;
  description: string;
  parcelMachineId: string;

  editActive: boolean = false;

  errorMessages: string[] = [];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private parcelApi: ParcelApiCallsService,
    private parcelMachineApi: ParcelMachineApiCallsService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(
      (param) => (this.id = param.get('id'))
    );

    if (this.id != null) {
      this.parcelApi.getParcelById(this.id).subscribe((data) => {
        this.receiverFullName = data.receiverFullName;
        this.weight = data.weight;
        this.phone = data.phone;
        this.description = data.description;
        this.parcelMachineId = data.parcelMachineId;
      });

      this.editActive = true;
    }

    this.parcelMachineApi.getParcelMachines().subscribe(
      (data) => (
        (this.parcelMachines = data),
        (this.sortedPrcelMachines = this.parcelMachines.sort((n1, n2) => {
          if (n1.town > n2.town) {
            return 1;
          }
          if (n1.town < n2.town) {
            return -1;
          }
          return 0;
        }))
      )
    );
  }

  createParcel() {
    this.errorMessages = [];

    let newParcel = {
      receiverFullName: this.receiverFullName,
      weight: this.weight,
      phone: this.phone,
      description: this.description,
      parcelMachineId: this.parcelMachineId,
    };

    this.parcelApi.addParcel(newParcel).subscribe(
      (response) => {
        this.receiverFullName = '';
        this.weight = '';
        this.phone = '';
        this.description = '';
        this.parcelMachineId = '';
      },
      (error) => {
        Object.entries(error.error.errors).forEach(([key, value]) =>
          this.errorMessages.push(`${value}`)
        );
      }
    );
  }

  updateParcel() {
    this.errorMessages = [];

    let newParcel = {
      id: parseInt(this.id),
      receiverFullName: this.receiverFullName,
      weight: this.weight,
      phone: this.phone,
      description: this.description,
      parcelMachineId: this.parcelMachineId,
    };

    this.parcelApi.updateParcel(newParcel).subscribe(
      (data) => {
        this.router.navigate(['/parcel-list']);
      },
      (error) => {
        Object.entries(error.error.errors).forEach(([key, value]) =>
          this.errorMessages.push(`${value}`)
        );
      }
    );
  }

  deleteParcel() {
    this.errorMessages = [];

    this.parcelApi.deleteParcel(this.id).subscribe(
      (data) => {
        this.router.navigate(['/parcel-list']);
      },
      (error) => {
        this.errorMessages.push(`${error.error}`);
      }
    );
  }
}
