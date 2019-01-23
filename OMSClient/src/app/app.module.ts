import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { DataService } from './data.service';
import { HttpClientModule } from '@angular/common/http';
import { CustomerCardComponent } from './customer-card/customer-card.component';
import { MaterialConstrolsModule } from './material-controls.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddressListComponent } from './address-list/address-list.component';
import { AddressCardComponent } from './address-card/address-card.component';
import { ItemListComponent } from './item-list/item-list.component';
import { ItemCardComponent } from './item-card/item-card.component';
import { UnitOfMeasureListComponent } from './unit-of-measure-list/unit-of-measure-list.component';
import { UnitOfMeasureCardComponent } from './unit-of-measure-card/unit-of-measure-card.component';
import { SalesOrderListComponent } from './sales-order-list/sales-order-list.component';
import { SalesOrderCardComponent } from './sales-order-card/sales-order-card.component';
import { MatNativeDateModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';
import { NavbarComponent } from './navbar/navbar.component';
import { UserConfirmComponent } from './user-confirm/user-confirm.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    CustomerCardComponent,
    AddressListComponent,
    AddressCardComponent,
    ItemListComponent,
    ItemCardComponent,
    UnitOfMeasureListComponent,
    UnitOfMeasureCardComponent,
    SalesOrderListComponent,
    SalesOrderCardComponent,
    NavbarComponent,
    UserConfirmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialConstrolsModule,
    BrowserAnimationsModule,
    MatNativeDateModule
  ],
  providers: [
    DataService,
  ],
  entryComponents: [
    UserConfirmComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
