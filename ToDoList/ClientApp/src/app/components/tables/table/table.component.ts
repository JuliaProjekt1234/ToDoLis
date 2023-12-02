import { Component } from '@angular/core';
import { Table } from 'src/app/models/table.model';
import { TablesHttpService } from 'src/app/services/http-services/tables-http.service';


@Component({
  selector: 'table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {

  public table: Table = Table.CreateDefault();

}
