import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'tables-filter',
  templateUrl: './tables-filter.component.html',
})
export class TablesFilterComponent {
  public filterForm: FormGroup = new FormGroup({});

  constructor(
    private formBuilder: FormBuilder
  ) {
    this.createForm();
  }

  private createForm() {
    this.filterForm = this.formBuilder.group({
      tableName: new FormControl(""),
      tableDescription: new FormControl(""),
      taskName: new FormControl(""),
      taskDescription: new FormControl(""),
    });
  }
}
