import { Component, OnInit, ViewChild } from '@angular/core';
import { Address } from '../interfaces/address.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';
import { MatTableDataSource, MatSort } from '@angular/material';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.scss']
})
export class AddressListComponent implements OnInit {
  addressData: MatTableDataSource<Address>;
  tableColumns: string[] = ['id', 'country', 'city', 'street', 'buildingNo'];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getAddresses().subscribe(addr => {
      this.addressData = new MatTableDataSource(addr);
      this.addressData.sort = this.sort;
    });
  }

  applyFilter(filter: string) {
    this.addressData.filter = filter.trim().toLowerCase();
  }

  goToAddress(address: Address) {
    this.router.navigate(['/Address', address.id]);
  }

}
