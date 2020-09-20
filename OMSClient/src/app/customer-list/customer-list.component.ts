import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
import { CustomerRead } from '../interfaces/customer.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource, MatSort, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})

export class CustomerListComponent implements OnInit {

  tableColumns: string[] = ['id', 'name'];
  customerData: MatTableDataSource<CustomerRead>;
  constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private dataService: DataService) {
  }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getCustomers().subscribe(response => {
      if (response.ok) {
        this.customerData = new MatTableDataSource(response.body);
        this.customerData.sort = this.sort;
      } else {
        this.showSnackBar('Cannot get customers from the database');
      }
    });
  }

  applyFilter(filter: string) {
    this.customerData.filter = filter.trim().toLowerCase();
  }

  goToCustomer(customer: CustomerRead) {
    this.router.navigate(['/Customer', customer.id]);
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
