import { Component, OnInit } from '@angular/core';
import { Item } from '../interfaces/item.interface';
import { UnitOfMeasure } from '../interfaces/unit-of-measure.interface';
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
  item: Item;
  unitsOfMeasure: UnitOfMeasure[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.item = { id: 0, name: '', description: '', unitPrice: undefined, unitCost: undefined, unitOfMeasureCode: undefined };
    this.dataService.getUnitsOfMeasure().subscribe( uoms => {
      this.unitsOfMeasure = uoms;
    });
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.dataService.getItem(+params.get('id')))
    ).subscribe( it => {
      if (it) {
        this.item = it;
      }
    });

  }

  onItemModified() {
    if (this.validate()) {
      this.dataService.newItem(this.item).subscribe( status => {
        if (status.statusOk) {
          if (this.item.id <= 0) {
            this.dataService.getItem(status.newRecordId).subscribe( item => {
              this.item = item;
            });
            this.showSnackBar('Item created successfully');
          } else {
            this.showSnackBar('Item modified successfully');
          }
        } else {
          this.showSnackBar(status.message);
        }
      });
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

  delete() {
    this.dataService.deleteItem(this.item.id).subscribe( status => {
      if (status.statusOk) {
        this.showSnackBar(`Item "${ this.item.name }" has been successfully deleted`);
        this.router.navigate(['/Items']);
      } else {
        this.showSnackBar(status.message);
      }
    });
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
