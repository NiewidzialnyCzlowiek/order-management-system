import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
import { UnitOfMeasure } from '../interfaces/unit-of-measure.interface';
import { MatTableDataSource, MatSort, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-unit-of-measure-list',
  templateUrl: './unit-of-measure-list.component.html',
  styleUrls: ['./unit-of-measure-list.component.scss']
})
export class UnitOfMeasureListComponent implements OnInit {
  tableColumns: string[] = ['code', 'name', 'delete'];
  uomData: MatTableDataSource<UnitOfMeasure>;

  constructor(
    private dataService: DataService,
    private snackBar: MatSnackBar
    ) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataService.getUnitsOfMeasure().subscribe(uoms => {
      this.uomData = new MatTableDataSource(uoms);
      this.uomData.sort = this.sort;
    });
  }

  applyFilter(filter: string) {
    this.uomData.filter = filter.trim().toLowerCase();
  }

  delete(code: string) {
    this.dataService.deleteUnitOfMeasure(code).subscribe(status => {
      if (status.statusOk) {
        this.showSnackBar('Unit Of Measure deleted successfully');
        const oldData = this.uomData.data;
        oldData.splice(this.uomData.data.findIndex( uom => uom.code === code), 1);
        this.uomData.data = oldData;
      } else {
        this.showSnackBar(status.message);
      }
    });
  }

  showSnackBar(message: string) {
    this.snackBar.open(message, 'OK', { duration: 3000 });
  }
}
