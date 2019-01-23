import { Component, OnInit } from '@angular/core';
import { Customer } from '../interfaces/customer.interface';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { switchMap } from 'rxjs/operators';
import { Address } from '../interfaces/address.interface';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Observable } from 'rxjs';
import { UserConfirmComponent } from '../user-confirm/user-confirm.component';

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.scss']
})
export class CustomerCardComponent implements OnInit {
  customer: Customer;
  newCustomer: boolean;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.customer = { id: 0, name: '', addresses: undefined };
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
          return this.dataService.getCustomer(+params.get('id'));
      })
    ).subscribe( cust => {
      if (cust) {
        this.customer = cust;
      }
      this.dataService.getAddressesForCustomer(this.customer.id).subscribe( addresses => {
        this.customer.addresses = addresses;
      });
    });
  }

  goToAddress(address: Address) {
    this.router.navigate(['/Address', address.id]);
  }

  onCustomerModified() {
    this.dataService.newCustomer(this.customer).subscribe( dbStatus => {
      if (dbStatus.statusOk) {
        if (this.customer.id <= 0) {
          this.dataService.getCustomer(dbStatus.newRecordId).subscribe( cust => {
            this.customer = cust;
            this.dataService.getAddressesForCustomer(this.customer.id).subscribe( addresses => {
              this.customer.addresses = addresses;
            });
            this.showSnackBar('Customer created successfully');
          });
        } else {
          this.showSnackBar('Customer modified successfully');
        }
      } else {
        this.showSnackBar('Couldn\'t modify customer');
      }
    });
  }

  delete() {
    if (this.customer.addresses.length > 0) {
      const dialogRef = this.dialog.open(UserConfirmComponent, {
        width: '300px',
        data: 'There are existing Addresses for the customer. Are you sure you want to delete the customer and all of his addresses?'
      });
      dialogRef.afterClosed().subscribe(res => {
        if (res.answer) {
          this.deleteCustomer(true);
        } else {
          this.showSnackBar('Deletion aborted');
        }
      });
    } else {
      this.deleteCustomer(false);
    }
  }

  deleteCustomer(cascade: boolean) {
    this.dataService.deleteCustomer(this.customer.id, cascade).subscribe(status => {
      if (status.statusOk) {
        this.showSnackBar(`Customer "${this.customer.name}" deleted successfully`);
        this.router.navigate(['/Customers']);
      } else {
        this.showSnackBar(status.message);
      }
    });
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
