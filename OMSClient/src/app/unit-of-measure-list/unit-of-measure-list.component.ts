import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
import { UnitOfMeasureRead } from '../interfaces/unit-of-measure.interface';
import { MatTableDataSource, MatSort, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-unit-of-measure-list',
  templateUrl: './unit-of-measure-list.component.html',
  styleUrls: ['./unit-of-measure-list.component.scss']
})
export class UnitOfMeasureListComponent implements OnInit {
  tableColumns: string[] = ['code', 'name', 'delete'];
  uomData: MatTableDataSource<UnitOfMeasureRead>;

  constructor(
    private dataService: DataService,
    private snackBar: MatSnackBar
    ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getUnitsOfMeasure().subscribe(response => {
      if (response.ok) {
        this.uomData = new MatTableDataSource(response.body);
        this.uomData.sort = this.sort;
      } else {
        this.showSnackBar('Cannot get units of measure from the database');
      }
    });
  }

  applyFilter(filter: string) {
    this.uomData.filter = filter.trim().toLowerCase();
  }

  delete(code: string) {
    this.dataService.deleteUnitOfMeasure(code).subscribe(response => {
      if (response.ok) {
        const oldData = this.uomData.data;
        oldData.splice(this.uomData.data.findIndex( uom => uom.code === code), 1);
        this.uomData.data = oldData;
        this.showSnackBar('Unit of Measure deleted successfully');
      }
    });
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
