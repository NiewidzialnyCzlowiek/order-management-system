import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { switchMap } from 'rxjs/operators';
import { Address } from '../interfaces/address.interface';
import { Customer } from '../interfaces/customer.interface';

@Component({
  selector: 'app-address-card',
  templateUrl: './address-card.component.html',
  styleUrls: ['./address-card.component.scss']
})
export class AddressCardComponent implements OnInit {
  address: Address;
  customers: Customer[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.dataService.getAddress(+params.get('id')))
    ).subscribe( addr => {
      this.address = addr;
      this.dataService.getCustomers().subscribe( custs => {
        this.customers = custs;
      });
    });
  }

}
