import {MatButtonModule, MatCheckboxModule, MatToolbarModule,
        MatListModule, MatDividerModule, MatRippleModule, MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatCardModule,
        MatSelectModule} from '@angular/material';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [MatButtonModule,
            MatCheckboxModule,
            MatToolbarModule,
            MatListModule,
            MatDividerModule,
            MatRippleModule,
            MatTableModule,
            MatSortModule,
            MatFormFieldModule,
            MatInputModule,
            MatCardModule,
            FormsModule,
            MatSelectModule],
  exports: [MatButtonModule,
            MatCheckboxModule,
            MatToolbarModule,
            MatListModule,
            MatDividerModule,
            MatRippleModule,
            MatTableModule,
            MatSortModule,
            MatFormFieldModule,
            MatInputModule,
            MatCardModule,
            FormsModule,
            MatSelectModule],
})
export class MaterialConstrolsModule { }
