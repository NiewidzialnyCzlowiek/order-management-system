import { Injectable } from '@angular/core';
import { CustomerCreate, CustomerRead, CustomerReadFull, CustomerUpdate } from './interfaces/customer.interface';
import { HttpClient } from '@angular/common/http';
import { AddressCreate, AddressRead, AddressReadFull, AddressUpdate } from './interfaces/address.interface';
import { ItemCreate, ItemRead, ItemReadFull, ItemUpdate } from './interfaces/item.interface';
import { UnitOfMeasureCreate, UnitOfMeasureRead, UnitOfMeasureReadFull, UnitOfMeasureUpdate } from './interfaces/unit-of-measure.interface';
// tslint:disable-next-line: max-line-length
import { SalesOrderHeaderCreate, SalesOrderHeaderRead, SalesOrderHeaderReadFull, SalesOrderHeaderUpdate } from './interfaces/sales-order-header.interface';
// tslint:disable-next-line: max-line-length
import { SalesOrderLineCreate, SalesOrderLineRead, SalesOrderLineReadFull, SalesOrderLineUpdate } from './interfaces/sales-order-line.interface';

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
    return this.httpClient.get<CustomerRead[]>(this.customerControllerLink, { observe: 'response' });
  }

  getCustomer(id: number) {
    return this.httpClient.get<CustomerReadFull>(this.customerControllerLink + id.toString(), { observe: 'response' });
  }

  newCustomer(customer: CustomerCreate) {
    return this.httpClient.post<CustomerReadFull>(this.customerControllerLink, customer, { observe: 'response' });
  }

  updateCustomer(id: number, customer: CustomerUpdate) {
    return this.httpClient.put(this.customerControllerLink + id.toString(), customer, { observe: 'response' });
  }

  deleteCustomer(id: number) {
    return this.httpClient.delete(this.customerControllerLink + id.toString(), { observe: 'response' });
  }

  getAddress(id: number) {
    return this.httpClient.get<AddressReadFull>(this.addressControllerLink + id.toString(), { observe: 'response' });
  }

  getAddresses() {
    return this.httpClient.get<AddressRead[]>(this.addressControllerLink, { observe: 'response' });
  }

  getAddressesForCustomer(customerId: number) {
    return this.httpClient.get<AddressRead[]>(this.addressControllerLink + 'forCustomer/' + customerId.toString(), { observe: 'response' });
  }

  newAddress(address: AddressCreate) {
    return this.httpClient.post<AddressReadFull>(this.addressControllerLink, address, { observe: 'response' });
  }

  updateAddress(id: number, address: AddressUpdate) {
    return this.httpClient.put(this.addressControllerLink + id.toString(), address, { observe: 'response' });
  }

  deleteAddress(id: number) {
    return this.httpClient.delete(this.addressControllerLink + id.toString(), { observe: 'response' });
  }

  getItems() {
    return this.httpClient.get<ItemRead[]>(this.itemControllerLink, { observe: 'response' });
  }

  getItem(id: number) {
    return this.httpClient.get<ItemReadFull>(this.itemControllerLink + id.toString(), { observe: 'response' });
  }

  newItem(item: ItemCreate) {
    return this.httpClient.post<ItemReadFull>(this.itemControllerLink, item, { observe: 'response' });
  }

  updateItem(id: number, item: ItemUpdate) {
    return this.httpClient.put(this.itemControllerLink + id.toString(), item, { observe: 'response' });
  }

  deleteItem(id: number) {
    return this.httpClient.delete(this.itemControllerLink + id.toString(), { observe: 'response' });
  }

  getUnitsOfMeasure() {
    return this.httpClient.get<UnitOfMeasureRead[]>(this.unitOfMeasureControllerLink, { observe: 'response' });
  }

  getUnitOfMeasure(code: string) {
    return this.httpClient.get<UnitOfMeasureReadFull>(this.unitOfMeasureControllerLink + code, { observe: 'response' });
  }

  newUnitOfMeasure(uom: UnitOfMeasureCreate) {
    return this.httpClient.post<UnitOfMeasureReadFull>(this.unitOfMeasureControllerLink, uom, { observe: 'response' });
  }

  updateUnitOfMeasure(code: string, uom: UnitOfMeasureUpdate) {
    return this.httpClient.put(this.unitOfMeasureControllerLink + code, uom, { observe: 'response' });
  }

  deleteUnitOfMeasure(code: string) {
    return this.httpClient.delete(this.unitOfMeasureControllerLink + code.toString(), { observe: 'response' });
  }

  getSalesOrders() {
    return this.httpClient.get<SalesOrderHeaderRead[]>(this.salesOrderHeaderControllerLink, { observe: 'response' });
  }

  getSalesOrder(id: number) {
    return this.httpClient.get<SalesOrderHeaderReadFull>(this.salesOrderHeaderControllerLink + id.toString(), { observe: 'response' });
  }

  newSalesOrder(order: SalesOrderHeaderCreate) {
    return this.httpClient.post<SalesOrderHeaderReadFull>(this.salesOrderHeaderControllerLink, order, { observe: 'response' });
  }

  updateSalesOrder(id: number, order: SalesOrderHeaderUpdate) {
    return this.httpClient.put(this.salesOrderHeaderControllerLink + id.toString(), order, { observe: 'response' });
  }

  deleteSalesOrder(id: number) {
    return this.httpClient.delete(this.salesOrderHeaderControllerLink + id.toString(), { observe: 'response' });
  }

  updateSalesOrderProfit(id: number) {
    // tslint:disable-next-line: max-line-length
    return this.httpClient.get<SalesOrderHeaderReadFull>(this.salesOrderHeaderControllerLink + 'profit/' + id.toString(), { observe: 'response' });
  }

  getOrderLines(orderId: number) {
    // tslint:disable-next-line: max-line-length
    return this.httpClient.get<SalesOrderLineRead[]>(`${this.salesOrderLineControllerLink}forHeader/${orderId.toString()}`, { observe: 'response' });
  }

  getOrderLine(id: number) {
    return this.httpClient.get<SalesOrderLineReadFull>(this.salesOrderLineControllerLink + id.toString(), { observe: 'response' });
  }

  newSalesOrderLine(line: SalesOrderLineCreate) {
    return this.httpClient.post<SalesOrderLineReadFull>(this.salesOrderLineControllerLink, line, { observe: 'response' });
  }

  updateSalesOrderLine(id: number, line: SalesOrderLineUpdate) {
    return this.httpClient.put(this.salesOrderLineControllerLink + id.toString(), line, { observe: 'response' });
  }

  deleteSalesOrderLine(id: number) {
    return this.httpClient.delete(this.salesOrderLineControllerLink + id.toString(), { observe: 'response' });
  }
}
