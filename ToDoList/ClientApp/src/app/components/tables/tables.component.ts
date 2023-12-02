import { Component } from '@angular/core';
import { Table } from 'src/app/models/table.model';
import { TablesHttpService } from 'src/app/services/http-services/tables-http.service';


@Component({
  selector: 'tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent {

  public tables: Table[] = []

  constructor(
    private tablesHttpService: TablesHttpService
  ) {
    this.tablesHttpService.getTable().subscribe(tables => {
      console.log(tables, "jjij")
      // this.tables = tables
    },
      (error) => { console.log("kflkflerf ", error) })
  }

}
