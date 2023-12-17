import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { FilterModel } from 'src/app/models/filter.model';


@Component({
  selector: 'tables-filter',
  templateUrl: './tables-filter.component.html',
})
export class TablesFilterComponent {
  @Output() clearFilter = new EventEmitter<void>();
  @Output() filterTables = new EventEmitter<FilterModel>();

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

  submit() {
    if (this.filterForm.invalid) return;

    let tableFilter = new FilterModel(
      this.getValueFromControl("tableName"),
      this.getValueFromControl("tableDescription"),
      this.getValueFromControl("taskName"),
      this.getValueFromControl("taskDescription"));
      
    this.filterTables.emit(tableFilter);
  }

  clear() {
    this.setAllControlValuesAsEmpty();
    this.clearFilter.emit();
  }

  private getValueFromControl(controlName: string): string {
    return this.filterForm.controls[controlName].value;
  }

  private setAllControlValuesAsEmpty() {
    Object.entries(this.filterForm.controls).forEach(value => {
      let formControl = Object.values(value)[1] as FormControl;
      this.setControlValue(formControl, "")
      return value
    });
  }

  private setControlValue(control: FormControl, value: string) {
    control.setValue(value);
  }
}
