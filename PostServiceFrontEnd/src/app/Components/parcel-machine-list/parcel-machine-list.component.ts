import { Component, OnInit } from '@angular/core';
import { ParcelMachine } from 'src/app/Models/parcelMachine';
import { ParcelMachineApiCallsService } from 'src/app/Services/parcel--machine-api-calls.service';

@Component({
  selector: 'app-parcel-machine-list',
  templateUrl: './parcel-machine-list.component.html',
  styleUrls: ['./parcel-machine-list.component.css'],
})
export class ParcelMachineListComponent implements OnInit {
  parcelMachines: ParcelMachine[] = [];

  constructor(private parcelMachineApi: ParcelMachineApiCallsService) {}

  ngOnInit(): void {
    this.parcelMachineApi
      .getParcelMachines()
      .subscribe((data) => (this.parcelMachines = data));
  }
}
