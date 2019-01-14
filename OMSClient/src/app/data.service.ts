import { Injectable } from '@angular/core';
import { Customer } from './interfaces/customer.interface';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Address } from './interfaces/address.interface';
import { DatabaseOperationStatus } from './interfaces/database-operation-status.interface';
import { Item } from './interfaces/item.interface';
import { UnitOfMeasure } from './interfaces/unit-of-measure.interface';

@Injectable()
export class DataService {
  private customerControllerLink = 'https://localhost:5001/api/Customer/';
  private addressControllerLink = 'https://localhost:5001/api/Address/';
  private itemControllerLink = 'https://localhost:5001/api/Item/';
  private salesOrderHeaderControllerLink = 'https://localhost:5001/api/SalesOrderHeader/';
  private salesOrderLineControllerLink = 'https://localhost:5001/api/SalesOrderLine/';
  private unitOfMeasureControllerLink = 'https://localhost:5001/api/UnitOfMeasure/';
  constructor (private httpCilent: HttpClient) { }

  getCustomers() {
    return this.httpCilent.get<Customer[]>(this.customerControllerLink);
  }

  getCustomer(id: number) {
    return this.httpCilent.get<Customer>(this.customerControllerLink + id.toString());
  }

  newCustomer(customer: Customer) {
    return this.httpCilent.post<DatabaseOperationStatus>(this.customerControllerLink, customer);
  }

  getAddress(id: number) {
    return this.httpCilent.get<Address>(this.addressControllerLink + id.toString());
  }

  getAddresses() {
    return this.httpCilent.get<Address[]>(this.addressControllerLink);
  }

  getAddressesForCustomer(customerId: number) {
    return this.httpCilent.get<Address[]>(this.addressControllerLink + 'forCustomer/' + customerId.toString());
  }

  getItems() {
    return this.httpCilent.get<Item[]>(this.itemControllerLink);
  }

  getItem(id: number) {
    return this.httpCilent.get<Item>(this.itemControllerLink + id.toString());
  }

  getUnitsOfMeasure() {
    return this.httpCilent.get<UnitOfMeasure[]>(this.unitOfMeasureControllerLink);
  }

  getUnitOfMeasure(code: string) {
    return this.httpCilent.get<UnitOfMeasure>(this.unitOfMeasureControllerLink + code);
  }
}
