import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BaseTask, Task, TaskToUpdate } from 'src/app/models/task.model';
import { TaskHttpService } from 'src/app/services/http-services/tasks-http.service';

@Component({
  selector: 'task-tools',
  templateUrl: './task-tools.component.html',
  styleUrls: ['./task-tools.component.scss']
})
export class TaskToolsComponent {
  @Input() tableId: number = 0;
  @Input() showAddTaskForm: boolean = false;
  @Input() onToggleTaskForm = () => { this.toggleTaskForm() };
  @Input() set task(value: TaskToUpdate) {
    this.createTaskForm(value);
    this.taskToUpdateId = value.id;
  }
  @Output() addedNewTask = new EventEmitter<void>();
  @Output() updatedTask = new EventEmitter<void>();

  public taskForm: FormGroup = new FormGroup({});
  public taskToUpdateId: number = 0;

  constructor(
    private formBuilder: FormBuilder,
    private taskHttpService: TaskHttpService
  ) {
    this.createTaskForm();
  }

  private createTaskForm(task?: TaskToUpdate): void {
    let formTask = task ? task : TaskToUpdate.CreateDefault();
    this.taskForm = this.formBuilder.group({
      name: new FormControl(formTask.name, Validators.required),
      description: new FormControl(formTask.description, Validators.required)
    })
  }

  public toggleTaskForm(): void {
    this.showAddTaskForm = !this.showAddTaskForm
  }

  public submit(): void {
    if (this.taskForm.invalid) return;

    if (this.taskToUpdateId)
      this.taskHttpService.updateTask(this.createTaskToUpdateFromForm()).subscribe(() => this.updatedTask.emit());
    else
      this.taskHttpService.addNewTask(this.createBaseTaskFromForm()).subscribe(() => this.addedNewTask.emit());
  }

  private createBaseTaskFromForm(): BaseTask {
    return new BaseTask(this.tableId, this.taskForm.controls["name"].value, this.taskForm.controls["description"].value, false)
  }

  private createTaskToUpdateFromForm(): TaskToUpdate {
    return new TaskToUpdate(this.taskToUpdateId, this.taskForm.controls["name"].value, this.taskForm.controls["description"].value)
  }
}


