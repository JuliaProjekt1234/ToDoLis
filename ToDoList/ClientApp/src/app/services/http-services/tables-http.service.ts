import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseTable, Table } from "src/app/models/table.model";
const headers = {
    'Content-Type': 'application/json; charset=UTF-8',
    'Access-Control-Allow-Origin': '*'
};


const options = { headers: headers };
@Injectable({ providedIn: 'root' })
export class TablesHttpService {
    constructor(private httpClinet: HttpClient) {

    }

    addNewTable(table: BaseTable): Observable<object> {
        return this.httpClinet.put('/api/Tables/AddTable', table)
    }

    getTable(): Observable<object[]> {
        return this.httpClinet.get('/api/Tables/GetTables') as Observable<object[]>
    }
}