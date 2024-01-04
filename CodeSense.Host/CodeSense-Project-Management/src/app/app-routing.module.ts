import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ProjectInputComponent } from './components/project-input/project-input.component';
import { RegisterUserComponent } from './components/user/register-user/register-user.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'register/user', component: RegisterUserComponent },
  { path: 'projects', component: ProjectInputComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
