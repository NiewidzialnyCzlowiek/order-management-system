import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { SalesOrderHeaderRead } from '../interfaces/sales-order-header.interface';
import { MatTableDataSource, MatSort, MatSnackBar } from '@angular/material';
import { CustomerRead } from '../interfaces/customer.interface';
import { AddressRead } from '../interfaces/address.interface';

@Component({
  selector: 'app-sales-order-list',
  templateUrl: './sales-order-list.component.html',
  styleUrls: ['./sales-order-list.component.scss']
})
export class SalesOrderListComponent implements OnInit {
  orderData: MatTableDataSource<SalesOrderHeaderRead>;
  tableColumns: string[] = ['id', 'orderDate', 'customerName', 'addressCountry', 'addressCity', 'addressPostCode'];
  emptyCustomer = {} as CustomerRead;
  emptyAddress = {} as AddressRead;
  constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private dataService: DataService
  ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getSalesOrders().subscribe(response => {
      if (response.ok) {
        const orders = response.body;
        orders.forEach(order => {
          if (!order.address) {
            order.address = this.emptyAddress;
          }
          if (!order.customer) {
            order.customer = this.emptyCustomer;
          }
        });
        this.orderData = new MatTableDataSource(orders);
        this.orderData.sort = this.sort;
      } else {
        this.showSnackBar('Cannot get orders from the database');
      }
    });
  }

  applyFilter(filter: string) {
    this.orderData.filter = filter.trim().toLowerCase();
  }

  goToOrder(order: SalesOrderHeaderRead) {
    this.router.navigate(['/SalesOrder', order.id]);
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
