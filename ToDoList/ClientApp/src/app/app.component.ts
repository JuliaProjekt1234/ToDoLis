import { Component } from '@angular/core';
import { TablesHttpService } from './services/http-services/tables-http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ToDoList';
}
