import { Component, OnInit } from '@angular/core';
import { Customer } from '../interfaces/customer.interface';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { switchMap } from 'rxjs/operators';
import { Address } from '../interfaces/address.interface';

interface FormFieldSpecs {
  name: string;
  invalid: boolean;
  errorMessage: string;
}

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.scss']
})
export class CustomerCardComponent implements OnInit {
  customer: Customer;
  newCustomer: boolean;
  formSpecs: FormFieldSpecs[] = [
    {
      name: 'name',
      invalid: false,
      errorMessage: ''
    }
  ];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.dataService.getCustomer(+params.get('id')))
    ).subscribe( cust => {
      this.customer = cust;
      this.dataService.getAddressesForCustomer(cust.id).subscribe( addresses => {
        this.customer.addresses = addresses;
      });
    });
  }

  goToAddress(address: Address) {
    this.router.navigate(['/Address', address.id]);
  }

  onCustomerModified() {
    if (this.newCustomer) {
      this.newCustomer = false;
    } else {
      this.dataService.newCustomer(this.customer).subscribe( valid => {
        this.formSpecs[0].invalid = !valid;
        this.formSpecs[0].errorMessage = 'Customer name is invalid';
      });
    }
  }
}
