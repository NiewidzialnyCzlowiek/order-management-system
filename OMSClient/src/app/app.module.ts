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

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    CustomerCardComponent,
    AddressListComponent,
    AddressCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialConstrolsModule,
    BrowserAnimationsModule
  ],
  providers: [
    DataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
