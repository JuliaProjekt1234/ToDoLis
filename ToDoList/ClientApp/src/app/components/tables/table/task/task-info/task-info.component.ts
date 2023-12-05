import { Component, Input } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { TaskHttpService } from 'src/app/services/http-services/tasks-http.service';

@Component({
  selector: 'task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent {
  @Input() task: Task = Task.CreateDefault();

  constructor(private taskHttpService: TaskHttpService) { }

  updateCheckedTask(event: any) {
    this.taskHttpService.changeTaskDoneValue(this.task.id).subscribe(
      () => this.task.done = !event.target.checked
    )
  }
}
