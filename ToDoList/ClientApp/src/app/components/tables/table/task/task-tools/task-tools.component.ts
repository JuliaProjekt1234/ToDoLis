import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseTask, Task } from 'src/app/models/task.model';
import { TaskHttpService } from 'src/app/services/http-services/tasks-http.service';

@Component({
  selector: 'task-tools',
  templateUrl: './task-tools.component.html',
  styleUrls: ['./task-tools.component.scss']
})
export class TaskToolsComponent {
  @Input() tableId: number = 0;
  @Output() addedNewTask = new EventEmitter<void>();

  public taskForm: FormGroup = new FormGroup({});
  public showAddTaskForm: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private taskHttpService: TaskHttpService
  ) {
    this.createTaskForm();
  }

  private createTaskForm(): void {
    this.taskForm = this.formBuilder.group({
      name: new FormControl("", Validators.required),
      description: new FormControl("", Validators.required)
    })
  }

  public toggleTaskForm(): void {
    this.showAddTaskForm = !this.showAddTaskForm
  }

  public submit(): void {
    if (this.taskForm.invalid) return;
    var task = this.createFromForm();
    this.taskHttpService.addNewTask(task).subscribe(()=>this.addedNewTask.emit());
  }

  private createFromForm(): BaseTask {
    return new BaseTask(this.tableId, this.taskForm.controls["name"].value, this.taskForm.controls["description"].value, false)
  }
}


