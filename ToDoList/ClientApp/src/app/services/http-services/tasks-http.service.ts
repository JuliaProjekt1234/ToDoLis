import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseTask, Task } from "src/app/models/task.model";

@Injectable({ providedIn: 'root' })
export class TaskHttpService {
    constructor(private httpClinet: HttpClient) { }

    addNewTask(task: BaseTask): Observable<object> {
        return this.httpClinet.put('/api/Tasks/AddTask', task)
    }
}