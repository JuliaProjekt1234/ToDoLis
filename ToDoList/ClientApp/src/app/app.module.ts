import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ListComponent } from './components/list/list.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AddTableComponent } from './components/add-table/add-table.component';
import { ColorPickerComponent } from './components/add-table/color-picker/color-picker.component';
import { ColorPickerButtonComponent } from './components/add-table/color-picker/color-picker-button/color-picker-button.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TablesComponent } from './components/tables/tables.component';
import { TableComponent } from './components/tables/table/table.component';


@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    TableComponent,
    TablesComponent,
    AddTableComponent,
    ColorPickerComponent,
    ColorPickerButtonComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
