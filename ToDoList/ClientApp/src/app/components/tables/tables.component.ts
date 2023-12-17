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
    private tableHttpService: TablesHttpService,
    private tablesHttpService: TablesHttpService
  ) {
    this.tablesHttpService.getTables().subscribe(tables => {
      this.tables = tables;
    });
  }

  refreshTable(tableId: number) {
    this.tableHttpService.getTable(tableId).subscribe((changedTable) => {
      this.tables[this.findIndexInTablesById(changedTable.id)] = changedTable;
    });
  }

  deleteTable(tableId: number) {
    this.tableHttpService.deleteTable(tableId).subscribe(() => {
      this.tables.splice(this.findIndexInTablesById(tableId), 1)
    })
  }

  private findIndexInTablesById(id: number): number {
    return this.tables.findIndex(table => table.id === id);
  }
}
