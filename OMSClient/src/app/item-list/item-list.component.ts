import { Component, OnInit, ViewChild } from '@angular/core';
import { Item } from '../interfaces/item.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';
import { MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
  itemData: MatTableDataSource<Item>;
  tableColumns: string[] = ['id', 'name', 'unitOfMeasure'];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: DataService
  ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getItems().subscribe(items => {
      this.itemData = new MatTableDataSource(items);
      this.itemData.sort = this.sort;
    });
  }

  applyFilter(filter: string) {
    this.itemData.filter = filter.trim().toLowerCase();
  }

  goToItem(item: Item) {
    this.router.navigate(['/Item', item.id]);
  }

}
