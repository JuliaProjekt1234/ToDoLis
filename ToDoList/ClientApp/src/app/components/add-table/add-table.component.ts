import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AppConstants } from 'src/app/constants/app-constants';
import { BaseTable } from 'src/app/models/table.model';
import { TablesHttpService } from 'src/app/services/http-services/tables-http.service';

@Component({
  selector: 'add-table',
  templateUrl: './add-table.component.html',
  styleUrls: ['./add-table.component.scss']
})
export class AddTableComponent {
  public addTableForm: FormGroup = new FormGroup({});
  public selectedColor: string = AppConstants.ColorsToPicker[0];

  constructor(
    private formBuilder: FormBuilder,
    private tableHttpService: TablesHttpService
  ) {
    this.createForm();
  }

  selectColor(color: string) {
    this.selectedColor = color;
  }

  private createForm() {
    this.addTableForm = this.formBuilder.group({
      name: new FormControl("", [Validators.required]),
      description: new FormControl("", [Validators.required])
    })
  }

  submit() {
    if (this.addTableForm.invalid) return;
    this.tableHttpService.addNewTable(this.createFromForm()).subscribe(p => console.log("jjkk ", p));
  }

  private createFromForm(): BaseTable {
    return new BaseTable(this.addTableForm.controls['name'].value, this.addTableForm.controls['description'].value, this.selectedColor)
  }
}
