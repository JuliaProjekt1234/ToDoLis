import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { TaskHttpService } from 'src/app/services/http-services/tasks-http.service';

@Component({
  selector: 'task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent {
  @Output() deletedTask = new EventEmitter<void>();
  @Input() task: Task = Task.CreateDefault();

  constructor(private taskHttpService: TaskHttpService) { }

  updateCheckedTask(event: any) {
    this.taskHttpService.changeTaskDoneValue(this.task.id).subscribe(
      () => this.task.done = !event.target.checked
    );
  }

  deleteTask() {
    this.taskHttpService.deleteTask(this.task.id).subscribe(
      () => this.deletedTask.emit()
    );
  }
}
