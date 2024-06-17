import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [
    UserListComponent
  ],
    imports: [
        CommonModule,
        BrowserModule,
        TranslateModule
    ]
})
export class UsersModule { }
