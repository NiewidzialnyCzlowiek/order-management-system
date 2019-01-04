import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Customer } from '../interfaces/customer.interface';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})

export class CustomerListComponent implements OnInit {

  customers: Customer[];
  customerCount: number;
  constructor(private dataService: DataService) {
  }

  ngOnInit() {
    this.dataService.getCustomers().subscribe(c => this.customers = c);
  }

}
