import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Parcel } from '../Models/parcel';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class ParcelApiCallsService {
  private apiUrl = 'https://localhost:44354/api/Parcels';

  constructor(private http: HttpClient) {}

  getParcels(): Observable<Parcel[]> {
    return this.http.get<Parcel[]>(this.apiUrl);
  }

  getFilteredParcels(value: string): Observable<Parcel[]> {
    let url = `${this.apiUrl}/?ParcelMachineId=${value}`;
    return this.http.get<Parcel[]>(url);
  }

  getParcelById(id: string): Observable<Parcel> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Parcel>(url);
  }

  addParcel(newParcel: Parcel): Observable<any> {
    return this.http.post<any>(this.apiUrl, newParcel);
  }

  updateParcel(parcel: Parcel): Observable<any> {
    return this.http.put<any>(this.apiUrl, parcel);
  }

  deleteParcel(id: string): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<any>(url);
  }
}
