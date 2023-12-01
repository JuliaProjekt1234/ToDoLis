import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseTable } from "src/app/models/table.model";

@Injectable({ providedIn: 'root' })
export class TablesHttpService {
    constructor(private httpClinet: HttpClient) {

    }

    addNewTable(table: BaseTable): Observable<object> {
        return this.httpClinet.put('http://localhost:5129/Tables/AddTable', table)
    }
}