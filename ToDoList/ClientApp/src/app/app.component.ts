import { Component } from '@angular/core';
import { TablesHttpService } from './services/http-services/tables-http.service';
import { BaseTable } from './models/table.model';
import { ListComponent } from './components/list/list.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ToDoList';

  constructor(private tablesHttpService: TablesHttpService) { }

}
