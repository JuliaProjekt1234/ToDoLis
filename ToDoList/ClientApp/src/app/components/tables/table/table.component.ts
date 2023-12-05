import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Table } from 'src/app/models/table.model';

@Component({
  selector: 'table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {

  @Input() table: Table = Table.CreateDefault();
  @Output() fetchNewTask = new EventEmitter<number>();
  @Output() deletedTable = new EventEmitter<number>();

  constructor(private router: Router) { }

  fetchTasks() {
    this.fetchNewTask.emit(this.table.id);
  }

  deleteTable() {
    this.deletedTable.emit(this.table.id);
  }

  updateTable() {
    this.router.navigate(['/add_table'], { state: { table: this.table } });
  }
}
