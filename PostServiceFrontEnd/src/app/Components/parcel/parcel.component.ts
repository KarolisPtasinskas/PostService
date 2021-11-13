import { Component, Input, OnInit } from '@angular/core';
import { Parcel } from 'src/app/Models/parcel';

@Component({
  selector: 'app-parcel',
  templateUrl: './parcel.component.html',
  styleUrls: ['./parcel.component.css'],
})
export class ParcelComponent implements OnInit {
  @Input() parcel: Parcel;

  constructor() {}

  ngOnInit(): void {}
}
