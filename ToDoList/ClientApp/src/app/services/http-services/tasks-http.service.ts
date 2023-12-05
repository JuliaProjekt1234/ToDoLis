import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseTask, TaskToUpdate } from "src/app/models/task.model";

@Injectable({ providedIn: 'root' })
export class TaskHttpService {
    constructor(private httpClinet: HttpClient) { }

    addNewTask(task: BaseTask): Observable<object> {
        return this.httpClinet.post('/api/Tasks/AddTask', task)
    }

    changeTaskDoneValue(taskId: number){
        return this.httpClinet.get(`/api/Tasks/ChangeTaskDoneValue/${taskId}`)
    }

    deleteTask(taskId:number){
        return this.httpClinet.delete(`/api/Tasks/DeleteTask/${taskId}`)
    }

    updateTask(taskToUpdate: TaskToUpdate){
        return this.httpClinet.put(`/api/Tasks/UpdateTask`, taskToUpdate)
    }
}