import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseTable, Table } from "src/app/models/table.model";

@Injectable({ providedIn: 'root' })
export class TablesHttpService {
    constructor(private httpClinet: HttpClient) { }

    addNewTable(table: BaseTable){
        return this.httpClinet.put('/api/Tables/AddTable', table)
    }

    getTables(): Observable<Table[]> {
        return this.httpClinet.get('/api/Tables/GetTables') as Observable<Table[]>
    }

    getTable(id: number): Observable<Table> {
        return this.httpClinet.get(`/api/Tables/GetTable/${id}`) as Observable<Table>
    }
}