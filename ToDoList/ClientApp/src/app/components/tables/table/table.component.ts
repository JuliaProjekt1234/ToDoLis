import { Component, Input } from '@angular/core';
import { Table } from 'src/app/models/table.model';

@Component({
  selector: 'table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {

  @Input() table: Table = Table.CreateDefault();

}
