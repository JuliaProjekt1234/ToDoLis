import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseTable, Table } from "src/app/models/table.model";

@Injectable({ providedIn: 'root' })
export class TablesHttpService {
    constructor(private httpClinet: HttpClient) {

    }

    addNewTable(table: BaseTable): Observable<object> {
        return this.httpClinet.put('/api/Tables/AddTable', table)
    }

    getTable(): Observable<Table[]> {
        return this.httpClinet.get('/api/Tables/GetTables') as Observable<Table[]>
    }
}