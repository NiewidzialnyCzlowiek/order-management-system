import { Component, OnInit } from '@angular/core';
import { CustomerReadFull } from '../interfaces/customer.interface';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { AddressReadFull } from '../interfaces/address.interface';
import { MatSnackBar, MatDialog } from '@angular/material';
import { UserConfirmComponent } from '../user-confirm/user-confirm.component';

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.scss']
})
export class CustomerCardComponent implements OnInit {
  customer = {} as CustomerReadFull;
  newCustomer = true;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    const idFromRoute = this.route.snapshot.params.id;
    this.setCustomerFromApi(idFromRoute);
  }

  goToAddress(address: AddressReadFull) {
    this.router.navigate(['/Address', address.id]);
  }

  onCustomerModified() {
    if (!this.validate()) { return; }
    if (this.newCustomer) {
      this.createCustomer();
    } else {
      this.updateCustomer();
    }
  }

  delete() {
    const dialogRef = this.dialog.open(UserConfirmComponent, {
      width: '300px',
      data: 'Are you sure you want to delete the customer with all the addresses?'
    });
    dialogRef.afterClosed().subscribe(res => {
      if (res.answer) {
        this.deleteCustomer();
      } else {
        this.showSnackBar('Deletion aborted');
      }
    });
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }

  setCustomerFromApi(id: number) {
    this.dataService.getCustomer(id).subscribe(response => {
      if (response.ok) {
        this.customer = response.body;
        this.newCustomer = false;
      } else {
        this.showSnackBar(`Cannot fetch customer with id: ${id}`);
      }
    });
  }

  createCustomer() {
    this.dataService.newCustomer(this.customer).subscribe(response => {
      if (response.ok) {
        this.customer = response.body;
        this.newCustomer = false;
        this.showSnackBar('Customer created successfully');
      } else {
        this.showSnackBar('Cannot create the customer');
      }
    });
  }

  updateCustomer() {
    this.dataService.updateCustomer(this.customer.id, this.customer).subscribe(response => {
      if (response.ok) {
        this.showSnackBar('Customer updated successfully');
      } else {
        this.showSnackBar('Cannot update customer');
      }
    });
  }

  deleteCustomer() {
    this.dataService.deleteCustomer(this.customer.id).subscribe(status => {
      this.showSnackBar(`Customer "${this.customer.name}" deleted successfully`);
      this.router.navigate(['/Customers']);
    });
  }

  private validate() {
    let valid = true;
    if (this.customer.name === '') { valid = false; }
    return valid;
  }
}
