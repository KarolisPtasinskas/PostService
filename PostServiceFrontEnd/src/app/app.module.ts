import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LandingPageComponent } from './Components/landing-page/landing-page.component';
import { ParcelComponent } from './Components/parcel/parcel.component';
import { ParcelListComponent } from './Components/parcel-list/parcel-list.component';
import { ParcelMachineComponent } from './Components/parcel-machine/parcel-machine.component';
import { ParcelMachineListComponent } from './Components/parcel-machine-list/parcel-machine-list.component';
import { AddEditParcelComponent } from './Components/add-edit-parcel/add-edit-parcel.component';
import { AddEditParcelMachineComponent } from './Components/add-edit-parcel-machine/add-edit-parcel-machine.component';

const appRoutes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'parcel-list', component: ParcelListComponent },
  { path: 'parcel-machine-list', component: ParcelMachineListComponent },
  { path: 'add-edit-parcel', component: AddEditParcelComponent },
  { path: 'add-edit-parcel/:id', component: AddEditParcelComponent },
  { path: 'add-edit-parcel-machine', component: AddEditParcelMachineComponent },
  {
    path: 'add-edit-parcel-machine/:id',
    component: AddEditParcelMachineComponent,
  },
];

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    ParcelComponent,
    ParcelListComponent,
    ParcelMachineComponent,
    ParcelMachineListComponent,
    AddEditParcelComponent,
    AddEditParcelMachineComponent,
  ],
  imports: [
    BrowserModule,
    NgbModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
