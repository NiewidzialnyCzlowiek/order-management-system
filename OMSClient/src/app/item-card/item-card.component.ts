import { Component, OnInit } from '@angular/core';
import { ItemCreate, ItemReadFull, ItemUpdate } from '../interfaces/item.interface';
import { UnitOfMeasureRead } from '../interfaces/unit-of-measure.interface';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { switchMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {
  item = {} as ItemReadFull;
  unitsOfMeasure = [] as UnitOfMeasureRead[];
  newItem = true;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    const idFromRoute = this.route.snapshot.params.id;
    this.setItemFromApi(idFromRoute);
    this.dataService.getUnitsOfMeasure().subscribe( response => {
      this.unitsOfMeasure = response.body;
    });
  }

  onItemModified() {
    if (!this.validate()) { return; }
    if (this.newItem) {
      this.createItem();
    } else {
      this.updateItem();
    }
  }

  validate() {
    let valid = true;
    if (this.item.name === '') {
      valid = false;
    }
    if (!this.item.unitPrice) {
      valid = false;
    }
    if (!this.item.unitCost) {
      valid = false;
    }
    return valid;
  }

  setItemFromApi(id: number) {
    this.dataService.getItem(id).subscribe(response => {
      if (response.ok) {
        this.item = response.body;
        this.newItem = false;
      } else {
        this.showSnackBar(`Cannot fetch item with id: ${id}`);
      }
    });
  }

  deleteItem() {
    this.dataService.deleteItem(this.item.id).subscribe( status => {
      this.showSnackBar(`Item "${ this.item.name }" has been successfully deleted`);
      this.router.navigate(['/Items']);
    });
  }

  createItem() {
    this.dataService.newItem(this.item as ItemCreate).subscribe(response => {
      if (response.ok) {
        this.item = response.body;
        this.newItem = false;
        this.showSnackBar('Item created successfully');
      } else {
        this.showSnackBar('Cannot create item');
      }
    });
  }

  updateItem() {
    this.dataService.updateItem(this.item.id, this.item as ItemUpdate).subscribe(response => {
      if (response.ok) {
        this.showSnackBar('Item updated successfully');
      } else {
        this.showSnackBar('Cannot update the item');
      }
    });
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
