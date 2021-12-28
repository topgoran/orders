import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminProfileRoutingModule } from './admin-profile-routing.module';
import { SidebarModule } from 'ng-sidebar';
import { AdminWrapperComponent } from './admin-wrapper/admin-wrapper.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersTableComponent } from './users-table/users-table.component';

import { MatTableModule } from '@angular/material/table'  
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { AddUpdateUserComponent } from './add-update-user/add-update-user.component';
import {MatListModule} from '@angular/material/list';
import { ArticlesTableComponent } from './articles-table/articles-table.component'; 
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { AddUpdateArticleComponent } from './add-update-article/add-update-article.component';
import {  MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    AdminWrapperComponent,
    UsersTableComponent,
    AddUpdateUserComponent,
    ArticlesTableComponent,
    AddUpdateArticleComponent,
  ],
  imports: [
    CommonModule,
    AdminProfileRoutingModule,
    SidebarModule,
    MatSidenavModule,
    MatToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    FormsModule,
    MatCardModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatSelectModule,
    MatProgressSpinnerModule
  ]
})
export class AdminProfileModule { }
