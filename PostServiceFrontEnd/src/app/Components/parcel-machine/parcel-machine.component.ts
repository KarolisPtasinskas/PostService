import { Component, Input, OnInit } from '@angular/core';
import { ParcelMachine } from 'src/app/Models/parcelMachine';

@Component({
  selector: 'app-parcel-machine',
  templateUrl: './parcel-machine.component.html',
  styleUrls: ['./parcel-machine.component.css'],
})
export class ParcelMachineComponent implements OnInit {
  @Input() parcelMachine: ParcelMachine;

  constructor() {}

  ngOnInit(): void {}
}
