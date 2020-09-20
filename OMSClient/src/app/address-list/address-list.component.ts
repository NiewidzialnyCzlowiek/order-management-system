import { Component, OnInit, ViewChild } from '@angular/core';
import { AddressRead } from '../interfaces/address.interface';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { MatTableDataSource, MatSort, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.scss']
})
export class AddressListComponent implements OnInit {
  addressData: MatTableDataSource<AddressRead>;
  tableColumns: string[] = ['id', 'country', 'city', 'street', 'buildingNo'];
  constructor(
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar,
    ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getAddresses().subscribe(response => {
      if (response.ok) {
        this.addressData = new MatTableDataSource(response.body);
        this.addressData.sort = this.sort;
      } else {
        this.showSnackBar('Cannot get addresses from database');
      }
    });
  }

  applyFilter(filter: string) {
    this.addressData.filter = filter.trim().toLowerCase();
  }

  goToAddress(address: AddressRead) {
    this.router.navigate(['/Address', address.id]);
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
