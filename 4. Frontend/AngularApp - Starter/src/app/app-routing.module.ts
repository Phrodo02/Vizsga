import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home-component/home.component';
import { NewAddComponent } from './components/new-add/new-add.component';
import { TableSiteComponent } from './components/table-site/table-site.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'table-site', component: TableSiteComponent},
  {path:'new-add', component: NewAddComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
