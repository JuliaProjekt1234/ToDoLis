import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'task-buttons',
  templateUrl: './task-buttons.component.html',
  styleUrls: ['./task-buttons.component.scss']
})
export class TaskButtonsComponent {
  @Output() deletedTask = new EventEmitter<void>();

  constructor() { }

  public deleteTask() {
    this.deletedTask.emit();
  }

}
