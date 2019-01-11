import {MatButtonModule, MatCheckboxModule, MatToolbarModule,
        MatListModule, MatDividerModule, MatRippleModule, MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatCardModule} from '@angular/material';
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
            FormsModule],
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
            FormsModule],
})
export class MaterialConstrolsModule { }
