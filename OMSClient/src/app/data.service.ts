import { Injectable } from '@angular/core';
import { Customer } from './interfaces/customer.interface';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {
  private customerControllerLink = 'https://localhost:5001/api/Customer/';
  constructor (private httpCilent: HttpClient) { }

  getCustomers() {
    return this.httpCilent.get<Customer[]>(this.customerControllerLink);
  }
}
