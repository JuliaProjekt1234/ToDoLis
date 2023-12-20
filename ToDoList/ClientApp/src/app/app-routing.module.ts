import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTableComponent } from './components/add-table/add-table.component';
import { TablesComponent } from './components/tables/tables.component';
import { RegistrationComponent } from './components/autentyfication/registration/registration.component';
import { LoginComponent } from './components/autentyfication/login/login.component';

const routes: Routes = [
  { path: "", component: TablesComponent },
  { path: "login", component: LoginComponent },
  { path: "add_table", component: AddTableComponent },
  { path: "registration", component: RegistrationComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
