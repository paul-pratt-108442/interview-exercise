import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { StudentsComponent } from './students/students.component';
import { StaffComponent } from './staff/staff.component';
const routes: Routes = [
  { path: '', component: HomeComponent, data: { title: 'Home' } },
  { path: 'students', component: StudentsComponent, data: { title: 'Students' } },
  { path: 'students/:id', component: StudentsComponent, data: { title: 'Students' } },
  { path: 'staff', component: StaffComponent, data: { title: 'Staff' } },
  { path: 'staff/:id', component: StaffComponent, data: { title: 'Staff' } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
