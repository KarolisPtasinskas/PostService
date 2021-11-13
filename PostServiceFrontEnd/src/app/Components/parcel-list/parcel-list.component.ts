import { Component, OnInit } from '@angular/core';
import { Parcel } from 'src/app/Models/parcel';
import { ParcelMachine } from 'src/app/Models/parcelMachine';
import { ParcelMachineApiCallsService } from 'src/app/Services/parcel--machine-api-calls.service';
import { ParcelApiCallsService } from 'src/app/Services/parcel-api-calls.service';

@Component({
  selector: 'app-parcel-list',
  templateUrl: './parcel-list.component.html',
  styleUrls: ['./parcel-list.component.css'],
})
export class ParcelListComponent implements OnInit {
  parcels: Parcel[] = [];
  parcelMachines: ParcelMachine[] = [];

  constructor(
    private parcelApi: ParcelApiCallsService,
    private parcelMachineApi: ParcelMachineApiCallsService
  ) {}

  ngOnInit(): void {
    this.parcelApi.getParcels().subscribe((data) => (this.parcels = data));

    this.parcelMachineApi.getParcelMachines().subscribe((data) => {
      data.forEach((element) => {
        this.parcelMachines.push(element);
      });
    });
  }

  onFilterChange(value: string) {
    this.parcelApi
      .getFilteredParcels(value)
      .subscribe((data) => (this.parcels = data));
  }
}
