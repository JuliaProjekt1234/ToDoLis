import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppConstants } from 'src/app/constants/app-constants';
import { BaseTable, Table } from 'src/app/models/table.model';
import { TablesHttpService } from 'src/app/services/http-services/tables-http.service';

@Component({
  selector: 'add-table',
  templateUrl: './add-table.component.html',
  styleUrls: ['./add-table.component.scss']
})
export class AddTableComponent {
  public addTableForm: FormGroup = new FormGroup({});
  public selectedColor: string = AppConstants.ColorsToPicker[0];
  public table: Table = Table.CreateDefault();

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private tableHttpService: TablesHttpService
  ) {
    this.table = history.state.table;
    if (this.table) this.selectColor(this.table.color);
    this.createForm();
  }

  public selectColor(color: string): void {
    this.selectedColor = color;
  }

  public submit(): void {
    if (this.addTableForm.invalid) return;

    let baseTable = this.createFromForm();

    if (this.table) {
      this.tableHttpService.updateTable(Table.CreateFromBaseTable(baseTable, this.table.id)).subscribe(
        () => this.navigateToTableView()
      );
    }
    else
      this.tableHttpService.addNewTable(baseTable).subscribe(
        () => this.navigateToTableView()
      );
  }

  private createForm(): void {
    let table = this.table ? this.table : Table.CreateDefault();
    this.addTableForm = this.formBuilder.group({
      name: new FormControl(table.name, [Validators.required]),
      description: new FormControl(table.description, [Validators.required])
    })
  }

  public navigateToTableView(): void {
    this.router.navigateByUrl("/")
  }

  private createFromForm(): BaseTable {
    return new BaseTable(this.addTableForm.controls['name'].value, this.selectedColor, this.addTableForm.controls['description'].value)
  }
}
