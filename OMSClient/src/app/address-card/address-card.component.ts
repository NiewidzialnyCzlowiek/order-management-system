import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { switchMap } from 'rxjs/operators';
import { Address } from '../interfaces/address.interface';
import { Customer } from '../interfaces/customer.interface';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-address-card',
  templateUrl: './address-card.component.html',
  styleUrls: ['./address-card.component.scss']
})
export class AddressCardComponent implements OnInit {
  address: Address;
  customers: Customer[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    public snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.address = { id: 0, country: '', postCode: '',
                     city: '', street: '', buildingNo: '',
                     appartmentNo: '', customerId: 0, customer: undefined };
    this.dataService.getCustomers().subscribe( custs => {
      this.customers = custs;
    });
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.dataService.getAddress(+params.get('id')))
    ).subscribe( addr => {
      if (addr) {
        this.address = addr;
      }
    });
  }

  onAddressModified() {
    if (this.validate()) {
      this.dataService.newAddress(this.address).subscribe( status => {
        if (status.statusOk) {
          if (this.address.id <= 0) {
            this.dataService.getAddress(status.newRecordId).subscribe( addr => {
              this.address = addr;
            });
            this.showSnackBar('Address created successfully');
          } else {
            this.showSnackBar('Address modified successfully');
          }
        } else {
          this.showSnackBar('Couldn\'t modify the address. Check the form again and fix the errors.');
        }
      });
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

  delete() {
    this.dataService.deleteAddress(this.address.id).subscribe( status => {
      if (status.statusOk) {
        this.showSnackBar('Address deleted succesfully');
        this.router.navigate(['/Addresses']);
      } else {
        this.showSnackBar(status.message);
      }
    });
  }

}
