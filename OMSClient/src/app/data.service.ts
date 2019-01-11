import { Injectable } from '@angular/core';
import { Customer } from './interfaces/customer.interface';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Address } from './interfaces/address.interface';
import { Observable } from 'rxjs';

@Injectable()
export class DataService {
  private customerControllerLink = 'https://localhost:5001/api/Customer/';
  private addressControllerLink = 'https://localhost:5001/api/Address/';
  constructor (private httpCilent: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
    return this.httpCilent.get<Customer[]>(this.customerControllerLink);
  }

  getCustomer(id: number): Observable<Customer> {
    return this.httpCilent.get<Customer>(this.customerControllerLink + id.toString());
  }

  getAddresses(): Observable<Address[]> {
    return this.httpCilent.get<Address[]>(this.addressControllerLink);
  }

  getAddressesForCustomer(customerId: number): Observable<Address[]> {
    return this.httpCilent.get<Address[]>(this.addressControllerLink + 'forCustomer/' + customerId.toString());
  }
}
