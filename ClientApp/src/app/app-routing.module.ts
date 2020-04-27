import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchoolComponent } from './Components/school/school.component';
import { ClassroomComponent } from './Components/classroom/classroom.component';
import { HomeComponent } from './Components/home/home.component';


const routes: Routes = [ 
  {path: 'classroom', component: ClassroomComponent},
  {path: 'school', component: SchoolComponent},
  {path: '', component: HomeComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
