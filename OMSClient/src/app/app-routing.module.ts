import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerCardComponent } from './customer-card/customer-card.component';
import { AddressListComponent } from './address-list/address-list.component';
import { AddressCardComponent } from './address-card/address-card.component';
import { ItemListComponent } from './item-list/item-list.component';
import { ItemCardComponent } from './item-card/item-card.component';
import { SalesOrderListComponent } from './sales-order-list/sales-order-list.component';
import { SalesOrderCardComponent } from './sales-order-card/sales-order-card.component';
import { UnitOfMeasureListComponent } from './unit-of-measure-list/unit-of-measure-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/SalesOrders',
    pathMatch: 'full'
  },
  {
    path: 'Customers',
    component: CustomerListComponent
  },
  {
    path: 'Customer/:id',
    component: CustomerCardComponent
  },
  {
    path: 'Addresses',
    component: AddressListComponent
  },
  {
    path: 'Address/:id',
    component: AddressCardComponent
  },
  {
    path: 'Items',
    component: ItemListComponent
  },
  {
    path: 'Item/:id',
    component: ItemCardComponent
  },
  {
    path: 'SalesOrders',
    component: SalesOrderListComponent
  },
  {
    path: 'SalesOrder/:id',
    component: SalesOrderCardComponent
  },
  {
    path: 'UnitsOfMeasure',
    component: UnitOfMeasureListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
