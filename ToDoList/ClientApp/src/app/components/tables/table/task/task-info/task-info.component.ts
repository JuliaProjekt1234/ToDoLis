import { Component, Input } from '@angular/core';
import { Task } from 'src/app/models/task.model';

@Component({
  selector: 'task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent {
  @Input() task: Task = Task.CreateDefault();

}
