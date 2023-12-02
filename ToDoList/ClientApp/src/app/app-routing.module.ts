import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTableComponent } from './components/add-table/add-table.component';
import { TablesComponent } from './components/tables/tables.component';

const routes: Routes = [
  { path: "", component: TablesComponent },
  { path: "add_table", component: AddTableComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
