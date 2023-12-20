import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AddTableComponent } from './components/add-table/add-table.component';
import { ColorPickerComponent } from './components/add-table/color-picker/color-picker.component';
import { ColorPickerButtonComponent } from './components/add-table/color-picker/color-picker-button/color-picker-button.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TablesComponent } from './components/tables/tables.component';
import { TableComponent } from './components/tables/table/table.component';
import { TaskToolsComponent } from './components/tables/table/task/task-tools/task-tools.component';
import { TaskToolsButtonComponent } from './components/tables/table/task/task-tools/add-task-form/task-tools-button.component';
import { TaskInfoComponent } from './components/tables/table/task/task-info/task-info.component';
import { TableToolsComponent } from './components/tables/table/table-tools/table-tools.component';
import { TaskButtonsComponent } from './components/tables/table/task/task-info/task-buttons/task-buttons.component';
import { TablesFilterComponent } from './components/tables/tables-filter/tables-filter.component';
import { RegistrationComponent } from './components/autentyfication/registration/registration.component';
import { LoginComponent } from './components/autentyfication/login/login.component';
import { ErrorInterceptor } from './services/interceptors/error-interceptor';
import { AuthInterceptor } from './services/interceptors/auth-interceptor';



@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    LoginComponent,
    TablesComponent,
    AddTableComponent,
    TaskInfoComponent,
    TaskToolsComponent,
    TableToolsComponent,
    ColorPickerComponent,
    TaskButtonsComponent,
    RegistrationComponent,
    TablesFilterComponent,
    TaskToolsButtonComponent,
    ColorPickerButtonComponent,
  ],
  imports: [
    FormsModule, 
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
