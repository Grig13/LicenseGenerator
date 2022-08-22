import { Injectable } from '@angular/core';
import { Customer } from '../models/customer';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private url = "Customer";

  constructor(private http: HttpClient) { }

  public getCustomers() : Observable<Customer[]> {
    return this.http.get<Customer[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createCustomer(customer: Customer): Observable<Customer[]>{
    return this.http.post<Customer[]>(`${environment.apiUrl}/${this.url}`, customer);
  }

  public deleteCustomer(customer: Customer): Observable<Customer[]>{
    return this.http.delete<Customer[]>(`${environment.apiUrl}/${this.url}/${customer.id}`);
  }
}
