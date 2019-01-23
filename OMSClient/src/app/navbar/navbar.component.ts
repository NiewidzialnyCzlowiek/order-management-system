import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  newEntityId = -1;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  navigate(link: string) {
    this.router.navigate([link]);
  }

  newSalesOrder() {
    this.router.navigate(['/SalesOrder', this.newEntityId]);
  }

  newCustomer() {
    this.router.navigate(['/Customer', this.newEntityId]);
  }

  newAddress() {
    this.router.navigate(['/Address', this.newEntityId]);
  }

  newItem() {
    this.router.navigate(['/Item', this.newEntityId]);
  }
}
