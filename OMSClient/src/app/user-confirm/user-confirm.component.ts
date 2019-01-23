import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-user-confirm',
  templateUrl: './user-confirm.component.html',
  styleUrls: ['./user-confirm.component.scss']
})
export class UserConfirmComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<UserConfirmComponent>,
              @Inject(MAT_DIALOG_DATA) public question: string) { }

  ngOnInit() {
  }

  closeYes() {
    this.dialogRef.close({ answer: true });
  }

  closeNo() {
    this.dialogRef.close({ answer: false });
  }
}
