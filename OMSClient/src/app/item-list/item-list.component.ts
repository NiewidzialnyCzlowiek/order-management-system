import { Component, OnInit, ViewChild } from '@angular/core';
import { ItemRead } from '../interfaces/item.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';
import { MatSnackBar, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
  itemData: MatTableDataSource<ItemRead>;
  tableColumns: string[] = ['id', 'name', 'unitOfMeasure'];
  constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private dataService: DataService
  ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getItems().subscribe(response => {
      if (response.ok) {
        this.itemData = new MatTableDataSource(response.body);
        this.itemData.sort = this.sort;
      } else {
        this.showSnackBar('Cannot get items from the database');
      }
    });
  }

  applyFilter(filter: string) {
    this.itemData.filter = filter.trim().toLowerCase();
  }

  goToItem(item: ItemRead) {
    this.router.navigate(['/Item', item.id]);
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
