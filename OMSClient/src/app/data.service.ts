import { Injectable } from '@angular/core';
import { Customer } from './interfaces/customer.interface';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Address } from './interfaces/address.interface';
import { DatabaseOperationStatus } from './interfaces/database-operation-status.interface';
import { Item } from './interfaces/item.interface';
import { UnitOfMeasure } from './interfaces/unit-of-measure.interface';
import { SalesOrderHeader } from './interfaces/sales-order-header.interface';
import { SalesOrderLine } from './interfaces/sales-order-line.interface';

@Injectable()
export class DataService {
  private customerControllerLink = 'https://localhost:5001/api/Customer/';
  private addressControllerLink = 'https://localhost:5001/api/Address/';
  private itemControllerLink = 'https://localhost:5001/api/Item/';
  private salesOrderHeaderControllerLink = 'https://localhost:5001/api/SalesOrderHeader/';
  private salesOrderLineControllerLink = 'https://localhost:5001/api/SalesOrderLine/';
  private unitOfMeasureControllerLink = 'https://localhost:5001/api/UnitOfMeasure/';
  constructor (private httpClient: HttpClient) { }

  getCustomers() {
    return this.httpClient.get<Customer[]>(this.customerControllerLink);
  }

  getCustomer(id: number) {
    return this.httpClient.get<Customer>(this.customerControllerLink + id.toString());
  }

  newCustomer(customer: Customer) {
    return this.httpClient.post<DatabaseOperationStatus>(this.customerControllerLink, customer);
  }

  deleteCustomer(id: number, cascade: boolean) {
    return this.httpClient.post<DatabaseOperationStatus>(this.customerControllerLink + 'delete', { intPk: id, cascade: cascade });
  }

  getAddress(id: number) {
    return this.httpClient.get<Address>(this.addressControllerLink + id.toString());
  }

  getAddresses() {
    return this.httpClient.get<Address[]>(this.addressControllerLink);
  }

  getAddressesForCustomer(customerId: number) {
    return this.httpClient.get<Address[]>(this.addressControllerLink + 'forCustomer/' + customerId.toString());
  }

  newAddress(address: Address) {
    return this.httpClient.post<DatabaseOperationStatus>(this.addressControllerLink, address);
  }

  deleteAddress(id: number) {
    return this.httpClient.post<DatabaseOperationStatus>(this.addressControllerLink + 'delete', { intPk: id });
  }

  getItems() {
    return this.httpClient.get<Item[]>(this.itemControllerLink);
  }

  getItem(id: number) {
    return this.httpClient.get<Item>(this.itemControllerLink + id.toString());
  }

  newItem(item: Item) {
    return this.httpClient.post<DatabaseOperationStatus>(this.itemControllerLink, item);
  }

  deleteItem(id: number) {
    return this.httpClient.post<DatabaseOperationStatus>(this.itemControllerLink + 'delete', { intPk: id });
  }

  getUnitsOfMeasure() {
    return this.httpClient.get<UnitOfMeasure[]>(this.unitOfMeasureControllerLink);
  }

  getUnitOfMeasure(code: string) {
    return this.httpClient.get<UnitOfMeasure>(this.unitOfMeasureControllerLink + code);
  }

  getSalesOrders() {
    return this.httpClient.get<SalesOrderHeader[]>(this.salesOrderHeaderControllerLink);
  }

  getSalesOrder(id: number) {
    return this.httpClient.get<SalesOrderHeader>(this.salesOrderHeaderControllerLink + id.toString());
  }

  newSalesOrder(order: SalesOrderHeader) {
    return this.httpClient.post<DatabaseOperationStatus>(this.salesOrderHeaderControllerLink, order);
  }

  deleteSalesOrder(id: number) {
    return this.httpClient.post<DatabaseOperationStatus>(this.salesOrderHeaderControllerLink + 'delete', { intPk: id });
  }

  getOrderLines(orderId: number) {
    return this.httpClient.get<SalesOrderLine[]>(this.salesOrderLineControllerLink + 'forHeader/' + orderId.toString());
  }

  getOrderLine(id: number) {
    return this.httpClient.get<SalesOrderLine>(this.salesOrderLineControllerLink + id.toString());
  }

  newSalesOrderLine(line: SalesOrderLine) {
    return this.httpClient.post<DatabaseOperationStatus>(this.salesOrderLineControllerLink, line);
  }

  deleteSalesOrderLine(id: number) {
    return this.httpClient.post<DatabaseOperationStatus>(this.salesOrderLineControllerLink + 'delete', { intPk: id });
  }
}
