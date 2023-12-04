import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Table } from 'src/app/models/table.model';
import { TablesHttpService } from 'src/app/services/http-services/tables-http.service';

@Component({
  selector: 'table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {

  @Input() table: Table = Table.CreateDefault();
  @Output() fetchNewTask = new EventEmitter<number>();

  fetchTasks() {
    this.fetchNewTask.emit(this.table.id);
  }
}
