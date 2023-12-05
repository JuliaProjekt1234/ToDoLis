import { Component, EventEmitter, HostListener, Output } from '@angular/core';


@Component({
  selector: 'table-tools',
  templateUrl: './table-tools.component.html',
  styleUrls: ['./table-tools.component.scss']
})
export class TableToolsComponent {
  @Output() deletedTable = new EventEmitter<void>();
  @Output() updatedTable = new EventEmitter<void>();

  public showMenu: boolean = false

  public toggleMenu(event: MouseEvent) {
    this.showMenu = !this.showMenu;
    event.stopPropagation();
  }

  public deleteTable() {
    this.deletedTable.emit();
  }

  public updateTable() {
    this.updatedTable.emit();
  }

  @HostListener('document:click')
  onClick() {
    this.showMenu = false
  }
}
