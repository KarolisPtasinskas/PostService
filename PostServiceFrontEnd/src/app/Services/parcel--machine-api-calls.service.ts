import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ParcelMachine } from '../Models/parcelMachine';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class ParcelMachineApiCallsService {
  private apiUrl = 'https://localhost:44354/api/ParcelMachines';

  constructor(private http: HttpClient) {}

  getParcelMachines(): Observable<ParcelMachine[]> {
    return this.http.get<ParcelMachine[]>(this.apiUrl);
  }

  getParcelMachineById(id: string): Observable<ParcelMachine> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<ParcelMachine>(url);
  }

  addParcelMachine(newParcelMachine: ParcelMachine): Observable<any> {
    return this.http.post<any>(this.apiUrl, newParcelMachine);
  }

  updateParcelMachine(parcelMachine: ParcelMachine): Observable<any> {
    return this.http.put<any>(this.apiUrl, parcelMachine);
  }

  deleteParcelMachine(id: string): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<any>(url);
  }
}
