import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
import { Customer } from '../interfaces/customer.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource, MatSort } from '@angular/material';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})

export class CustomerListComponent implements OnInit {

  tableColumns: string[] = ['id', 'name'];
  customerData: MatTableDataSource<Customer>;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService) {
  }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getCustomers().subscribe(c => {
      this.customerData = new MatTableDataSource(c);
      this.customerData.sort = this.sort;
    });
  }

  applyFilter(filter: string) {
    this.customerData.filter = filter.trim().toLowerCase();
  }

  goToCustomer(customer: Customer) {
    this.router.navigate(['/Customer', customer.id]);
  }

}
