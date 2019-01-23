import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';
import { SalesOrderHeader } from '../interfaces/sales-order-header.interface';
import { MatTableDataSource, MatSort } from '@angular/material';
import { Customer } from '../interfaces/customer.interface';
import { Address } from '../interfaces/address.interface';

@Component({
  selector: 'app-sales-order-list',
  templateUrl: './sales-order-list.component.html',
  styleUrls: ['./sales-order-list.component.scss']
})
export class SalesOrderListComponent implements OnInit {
  orderData: MatTableDataSource<SalesOrderHeader>;
  tableColumns: string[] = ['id', 'orderDate', 'customerName', 'addressCountry', 'addressCity', 'addressPostCode'];
  emptyCustomer: Customer = { id: 0, name: '', addresses: undefined };
  emptyAddress: Address = { id: 0, country: '', postCode: '',
                            city: '', street: '', buildingNo: '',
                            appartmentNo: '', customerId: 0, customer: undefined };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getSalesOrders().subscribe(ords => {
      ords.forEach(order => {
        if (!order.address) {
          order.address = this.emptyAddress;
        }
        if (!order.customer) {
          order.customer = this.emptyCustomer;
        }
      });
      this.orderData = new MatTableDataSource(ords);
      this.orderData.sort = this.sort;
    });
  }

  applyFilter(filter: string) {
    this.orderData.filter = filter.trim().toLowerCase();
  }

  goToOrder(order: SalesOrderHeader) {
    this.router.navigate(['/SalesOrder', order.id]);
  }
}
