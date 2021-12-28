import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberWrapperComponent } from './member-wrapper/member-wrapper.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MemberRoutingModule } from './member-routing.module';

@NgModule({
  declarations: [
    MemberWrapperComponent,
  ],
  imports: [
    MemberRoutingModule,
    CommonModule,
    MatToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    MatCardModule,
  ]
})
export class MemberModule { }
