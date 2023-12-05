import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Task, TaskToUpdate } from 'src/app/models/task.model';
import { TaskHttpService } from 'src/app/services/http-services/tasks-http.service';

@Component({
  selector: 'task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent {
  @Output() fetchTasks = new EventEmitter<void>();

  @Input() task: Task = Task.CreateDefault();

  public showTaskForm: boolean = false;
  public taskToUpdate: TaskToUpdate = TaskToUpdate.CreateDefault();

  constructor(private taskHttpService: TaskHttpService) { }

  ngAfterViewInit() {
    this.taskToUpdate = TaskToUpdate.CreateFromTask(this.task);
  }

  public updateCheckedTask(event: any) {
    this.taskHttpService.changeTaskDoneValue(this.task.id).subscribe(
      () => this.task.done = event.target.checked
    );
  }

  public deleteTask() {
    this.taskHttpService.deleteTask(this.task.id).subscribe(
      () => this.fetchTasks.emit()
    );
  }

  public toggleEditTaskForm() {
    this.showTaskForm = !this.showTaskForm;
  }

  public toggle = () => {
    this.toggleEditTaskForm();
  }

  updateTask() {
    this.fetchTasks.emit();
  }
}
