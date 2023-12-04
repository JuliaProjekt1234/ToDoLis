import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'task-tools-button',
  templateUrl: './task-tools-button.component.html',
  styleUrls: ['./task-tools-button.component.scss']
})
export class TaskToolsButtonComponent {

  @Input() showAddTaskForm: boolean = false;
  @Output() toggledTaskForm = new EventEmitter<void>();
  @Output() savedTask = new EventEmitter<void>();

  public toggleTaskForm(): void {
    this.toggledTaskForm.emit();
  }

  public saveTask(): void {
    this.savedTask.emit();
  }
}
