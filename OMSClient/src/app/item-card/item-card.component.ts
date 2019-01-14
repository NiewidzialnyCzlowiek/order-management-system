import { Component, OnInit } from '@angular/core';
import { Item } from '../interfaces/item.interface';
import { UnitOfMeasure } from '../interfaces/unit-of-measure.interface';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from '../data.service';
import { switchMap } from 'rxjs/operators';

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
    private dataService: DataService
  ) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.dataService.getItem(+params.get('id')))
    ).subscribe( it => {
      this.item = it;
    });
    this.dataService.getUnitsOfMeasure().subscribe( uoms => {
      this.unitsOfMeasure = uoms;
      console.log(uoms);
    });

  }

}
