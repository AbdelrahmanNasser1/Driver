import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Driver } from 'src/Model/Driver';

@Injectable({
  providedIn: 'root'
})
export class DriverService {
  private apiUrl = 'https://localhost:44363/api/Drivers';
  constructor(private http: HttpClient) { }

  getDrivers():Observable<Driver[]>{
    return this.http.get<Driver[]>(this.apiUrl);
  }

  getDriver(id: number): Observable<Driver> {
    return this.http.get<Driver>(`${this.apiUrl}/${id}`);
  }

  createDriver(driver: Driver): Observable<Driver> {
    return this.http.post<Driver>(this.apiUrl, driver);
  }

  updateDriver(id: number, driver: Driver): Observable<Driver> {
    return this.http.put<Driver>(`${this.apiUrl}/${id}`, driver);
  }

  deleteDriver(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
