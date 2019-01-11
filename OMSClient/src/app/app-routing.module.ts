import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerCardComponent } from './customer-card/customer-card.component';
import { AddressListComponent } from './address-list/address-list.component';
import { AddressCardComponent } from './address-card/address-card.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/Customers',
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
