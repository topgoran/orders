import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PublicComponent } from './wrapper/public/public.component';
import { PublicRoutingModule } from './public-routing.module';
import { MatDialogModule } from '@angular/material/dialog';
import {  MatButtonModule } from '@angular/material/button';
import {  MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AlertDialogComponent } from './alert-dialog/alert-dialog.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    PublicComponent,
    AlertDialogComponent,
    PageNotFoundComponent,
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule,
    MatProgressSpinnerModule
  ]
})
export class PublicModule { }
