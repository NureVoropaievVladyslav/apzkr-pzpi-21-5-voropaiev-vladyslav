import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserListComponent } from './users/user-list.component';
import { AuthComponent } from './auth/auth.component';
import { PondListComponent } from './ponds/pond-list.component';

const routes: Routes = [
  { path: 'users', component: UserListComponent },
  { path: 'login', component: AuthComponent },
  { path: 'ponds', component: PondListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
