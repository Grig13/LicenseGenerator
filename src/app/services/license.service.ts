import { Injectable } from '@angular/core';
import { License } from '../models/licence';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LicenseService {

  private url = "License";

  constructor(private http: HttpClient) { }

  public getLicense() : Observable<License[]> {
    return this.http.get<License[]>(`${environment.apiUrl}/${this.url}`);
  }
  public createLicense(license: License): Observable<License[]> {
    return this.http.post<License[]>(`${environment.apiUrl}/${this.url}`, license);
  }
  public deleteLicense(license: License): Observable<License[]>{
    return this.http.delete<License[]>(`${environment.apiUrl}/${this.url}/${license.id}`);
  }
}
