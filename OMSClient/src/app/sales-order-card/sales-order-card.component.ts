import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { SalesOrderHeader } from '../interfaces/sales-order-header.interface';
import { Item } from '../interfaces/item.interface';
import { switchMap, retry } from 'rxjs/operators';
import { Address } from '../interfaces/address.interface';
import { Customer } from '../interfaces/customer.interface';
import { MatTableDataSource, MatSnackBar, MatDialog } from '@angular/material';
import { SalesOrderLine } from '../interfaces/sales-order-line.interface';
import { UserConfirmComponent } from '../user-confirm/user-confirm.component';

@Component({
  selector: 'app-sales-order-card',
  templateUrl: './sales-order-card.component.html',
  styleUrls: ['./sales-order-card.component.scss']
})
export class SalesOrderCardComponent implements OnInit {
  order: SalesOrderHeader;
  xOrder: SalesOrderHeader;
  items: Item[];
  customers: Customer[];
  addresses: Address[];
  linesData: MatTableDataSource<SalesOrderLine>;
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
    this.order = { id: 0, orderDate: undefined, shipmentDate: undefined,
                   profit: 0, customerId: 0, customer: undefined,
                   addressId: 0, address: undefined, lines: undefined };
    this.xOrder = { id: 0, orderDate: undefined, shipmentDate: undefined,
                    profit: 0, customerId: 0, customer: undefined,
                    addressId: 0, address: undefined, lines: undefined };
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.dataService.getSalesOrder(+params.get('id')))
    ).subscribe( o => {
      if (o) {
        this.order = o;
        this.transferOrderFields(this.order, this.xOrder);
        this.dataService.getOrderLines(this.order.id).subscribe( lines => {
          this.linesData = new MatTableDataSource(lines);
        });
        this.dataService.getAddressesForCustomer(this.order.customerId).subscribe( addr => {
          this.addresses = addr;
        });
      }
    });
    this.dataService.getItems().subscribe( items => {
      this.items = items;
    });
    this.dataService.getCustomers().subscribe( custs => {
      this.customers = custs;
    });
  }

  insertNewLine() {
    this.dataService.newSalesOrderLine( { id: 0, itemId: this.newLineItemId,
        quantity: this.newLineQuantity, salesOrderHeaderId: this.order.id,
        amount: 0, salesOrderHeader: undefined, item: undefined
      }).subscribe( status => {
        if (status.statusOk) {
          this.showSnackBar('New line inserted successfully');
          this.newLineQuantity = 0;
          this.dataService.getOrderLine(status.newRecordId).subscribe( line => {
            const oldData = this.linesData.data;
            oldData.push(line);
            this.linesData.data = oldData;
          });
        } else {
          this.showSnackBar(status.message);
        }
      });
  }

  onSalesOrderModified() {
    if (this.modified()) {
      if (this.validate()) {
        this.dataService.newSalesOrder(this.order).subscribe(status => {
          if (status.statusOk) {
            if (this.xOrder.id === 0) {
              this.dataService.getSalesOrder(status.newRecordId).subscribe(newOrder => {
                this.order = newOrder;
              });
              this.showSnackBar('Order created successfully');
            }
            this.showSnackBar('Order modified successfully');
            this.transferOrderFields(this.order, this.xOrder);
          } else {
            this.showSnackBar(status.message);
          }
        });
      }
    }
  }

  validate() {
    let valid = true;
    if (this.order.shipmentDate < this.order.orderDate) {
      valid = false;
      this.showSnackBar('Shipment Date is before Order Date. Cannot update the order.');
    }
    if (this.order.customerId !== this.xOrder.customerId) {
      this.dataService.getAddressesForCustomer(this.order.customerId).subscribe( addr => {
        this.addresses = addr;
      });
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
    this.dataService.deleteSalesOrder(this.order.id).subscribe(status => {
      if (status.statusOk) {
        this.showSnackBar('Order deleted succesfully');
        this.router.navigate(['/SalesOrders']);
      } else {
        this.showSnackBar(status.message);
      }
    });
  }

  deleteLine(lineId: number) {
    this.dataService.deleteSalesOrderLine(lineId).subscribe( status => {
      if (status.statusOk) {
        this.showSnackBar('Succesfully deleted order line');
        const oldData = this.linesData.data;
        oldData.splice(this.linesData.data.findIndex( line => line.id === lineId), 1);
        this.linesData.data = oldData;
      } else {
        this.showSnackBar(status.message);
      }
    });
  }

  private transferOrderFields(from: SalesOrderHeader, to: SalesOrderHeader) {
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
