import { Component, EventEmitter, Output } from '@angular/core';


@Component({
  selector: 'table-tools',
  templateUrl: './table-tools.component.html',
  styleUrls: ['./table-tools.component.scss']
})
export class TableToolsComponent {
  @Output() deletedTable = new EventEmitter<void>();
  public showMenu: boolean = false

  public toggleMenu() {
    this.showMenu = !this.showMenu
  }
  deleteTable() {
    this.deletedTable.emit();
  }
}
