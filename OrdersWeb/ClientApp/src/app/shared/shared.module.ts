import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SidebarModule } from 'ng-sidebar';
import { ProfileComponent } from './components/profile/profile.component';
import { MatCardModule } from '@angular/material/card';


@NgModule({
  declarations: [
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    SidebarModule,
    MatCardModule
  ],
  exports: [
    ProfileComponent
  ]
})
export class SharedModule { }
