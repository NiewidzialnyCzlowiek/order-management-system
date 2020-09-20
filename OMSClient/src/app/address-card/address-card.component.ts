import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';
import { MatSnackBar } from '@angular/material';
import { CustomerRead } from '../interfaces/customer.interface';
import { AddressReadFull } from '../interfaces/address.interface';

@Component({
  selector: 'app-address-card',
  templateUrl: './address-card.component.html',
  styleUrls: ['./address-card.component.scss']
})
export class AddressCardComponent implements OnInit {
  address = {} as AddressReadFull;
  customers = [] as CustomerRead[];
  newAddress = true;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    public snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    const idFromRoute = this.route.snapshot.params.id;
    this.setAddressFromApi(idFromRoute);
    this.dataService.getCustomers().subscribe(response => {
      if (response.ok) {
        this.customers = response.body;
      }
    });
  }

  onAddressModified() {
    if (!this.validate()) { return; }
    if (this.newAddress) {
      this.createAddress();
    } else {
      this.updateAddress();
    }
  }

  validate() {
    let valid = true;
    if (this.address.country === '') {
      valid = false;
    }
    if (this.address.postCode === '') {
      valid = false;
    }
    if (this.address.street === '') {
      valid = false;
    }
    if (this.address.buildingNo === '') {
      valid = false;
    }
    return valid;
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }

  setAddressFromApi(idFromRoute: number) {
    this.dataService.getAddress(idFromRoute).subscribe(response => {
      if (response.ok) {
        this.address = response.body;
        this.newAddress = false;
      } else {
        this.showSnackBar(`Cannot fetch customer with id: ${idFromRoute}`);
      }
    });
  }

  createAddress() {
    this.dataService.newAddress(this.address).subscribe( response => {
      if (response.ok) {
        this.address = response.body;
        this.newAddress = false;
        this.showSnackBar('Address created successfully');
      } else {
        this.showSnackBar('Cannot create address');
      }
    });
  }

  updateAddress() {
    this.dataService.updateAddress(this.address.id, this.address).subscribe(response => {
      if (response.ok) {
        this.showSnackBar('Address updated successfully');
      } else {
        this.showSnackBar('Cannot update address');
      }
    });
  }

  deleteAddress() {
    this.dataService.deleteAddress(this.address.id).subscribe( status => {
      this.showSnackBar('Address deleted succesfully');
      this.router.navigate(['/Addresses']);
    });
  }
}
