import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { SalesOrderHeaderReadFull, SalesOrderHeaderUpdate } from '../interfaces/sales-order-header.interface';
import { ItemRead } from '../interfaces/item.interface';
import { switchMap, retry } from 'rxjs/operators';
import { AddressRead } from '../interfaces/address.interface';
import { CustomerRead } from '../interfaces/customer.interface';
import { MatTableDataSource, MatSnackBar, MatDialog } from '@angular/material';
import { SalesOrderLineCreate, SalesOrderLineRead } from '../interfaces/sales-order-line.interface';
import { UserConfirmComponent } from '../user-confirm/user-confirm.component';

@Component({
  selector: 'app-sales-order-card',
  templateUrl: './sales-order-card.component.html',
  styleUrls: ['./sales-order-card.component.scss']
})
export class SalesOrderCardComponent implements OnInit {
  order = {} as SalesOrderHeaderReadFull;
  newOrder = false;
  xOrder = {} as SalesOrderHeaderReadFull;
  items = [] as ItemRead[];
  customers = [] as CustomerRead[];
  addresses = [] as AddressRead[];
  linesData: MatTableDataSource<SalesOrderLineRead>;
  newLineItemId = 0;
  newLineQuantity = 0;
  tableColumns: string[] = ['id', 'itemId', 'itemName', 'quantity', 'amount', 'delete'];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
    ) { }

  ngOnInit() {
    const idFromRoute = this.route.snapshot.params.id;
    this.setSalesOrderFromApi(idFromRoute);
    this.dataService.getItems().subscribe( response => {
      this.items = response.body;
    });
    this.dataService.getCustomers().subscribe( response => {
      this.customers = response.body;
    });
  }

  setSalesOrderFromApi(id: number) {
    this.dataService.getSalesOrder(id).subscribe(response => {
      if (response.ok) {
        this.order = response.body;
        this.newOrder = false;
        this.setAddressesForCustomer();
        this.transferOrderFields(this.order, this.xOrder);
        this.linesData = new MatTableDataSource(this.order.lines);
      } else {
        this.showSnackBar(`Cannot fetch order with id: ${id}`);
      }
    });
  }

  setAddressesForCustomer() {
    this.dataService.getAddressesForCustomer(this.order.customerId).subscribe(response => {
      this.addresses = response.body;
    });
  }

  insertNewLine() {
    const salesOrderLineCreate =  {
      quantity: this.newLineQuantity,
      amount: 0,
      itemId: this.newLineItemId,
      salesOrderHeaderId: this.order.id,
    } as SalesOrderLineCreate;
    this.dataService.newSalesOrderLine(salesOrderLineCreate).subscribe(response => {
      if (response.ok) {
        this.newLineQuantity = 0;
        const oldData = this.linesData.data;
        oldData.push(response.body as SalesOrderLineRead);
        this.linesData.data = oldData;
        this.showSnackBar('New line inserted successfully');
      }
    });
  }

  onSalesOrderModified() {
    if (!this.validate()) { return; }
    if (this.newOrder) {
      this.createOrder();
    } else {
      this.updateOrder();
    }
  }

  validate() {
    let valid = true;
    if (this.order.shipmentDate < this.order.orderDate) {
      valid = false;
      this.showSnackBar('Shipment Date is before Order Date. Cannot update the order.');
    }
    if (this.order.customerId !== this.xOrder.customerId) {
      this.setAddressesForCustomer();
      this.order.addressId = 0;
    }
    return valid;
  }

  modified() {
    if (this.xOrder.orderDate !== this.order.orderDate) {
      return true;
    }
    if (this.xOrder.shipmentDate !== this.order.shipmentDate) {
      return true;
    }
    if (this.xOrder.customerId !== this.order.customerId) {
      return true;
    }
    if (this.xOrder.addressId !== this.order.addressId) {
      return true;
    }
    return false;
  }

  createOrder() {
    this.dataService.newSalesOrder(this.order).subscribe(response => {
      if (response.ok) {
        this.order = response.body;
        this.newOrder = false;
        this.transferOrderFields(this.order, this.xOrder);
        this.showSnackBar('Order created successfully');
      } else {
        this.showSnackBar('Cannot create the order');
      }
    });
  }

  updateOrder() {
    this.dataService.updateSalesOrder(this.order.id, this.order as SalesOrderHeaderUpdate).subscribe(response => {
      if (response.ok) {
        this.transferOrderFields(this.order, this.xOrder);
        this.showSnackBar('Order updated successfully');
      } else {
        this.showSnackBar('Cannot update the order');
      }
    });
  }

  delete() {
    const dialogRef = this.dialog.open(UserConfirmComponent, {
      width: '300px',
      data: 'Are you sure you want to delete the Sales Order and all of its lines?'
    });
    dialogRef.afterClosed().subscribe(res => {
      if (res.answer) {
        this.deleteOrder();
      } else {
        this.showSnackBar('Deletion aborted');
      }
    });
  }

  deleteOrder() {
    this.dataService.deleteSalesOrder(this.order.id).subscribe(response => {
      if (response.ok) {
        this.showSnackBar('Order deleted succesfully');
        this.router.navigate(['/SalesOrders']);
      }
    });
  }

  deleteLine(lineId: number) {
    this.dataService.deleteSalesOrderLine(lineId).subscribe( status => {
      this.showSnackBar('Succesfully deleted order line');
      const oldData = this.linesData.data;
      oldData.splice(this.linesData.data.findIndex( line => line.id === lineId), 1);
      this.linesData.data = oldData;
    });
  }

  updateProfit() {
    this.dataService.updateSalesOrderProfit(this.order.id).subscribe( response => {
      if (response.ok) {
        this.order.profit = response.body.profit;
        this.showSnackBar('Profit updated');
      }
    });
  }

  private transferOrderFields(from: SalesOrderHeaderReadFull, to: SalesOrderHeaderReadFull) {
    to.id = from.id;
    to.orderDate = from.orderDate;
    to.shipmentDate = from.shipmentDate;
    to.customerId = from.customerId;
    to.addressId = from.addressId;
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
