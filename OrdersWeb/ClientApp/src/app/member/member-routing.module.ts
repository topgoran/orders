import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from '../shared/components/profile/profile.component';
import { MemberWrapperComponent } from './member-wrapper/member-wrapper.component';

const routes: Routes = [
  { path: '', component: MemberWrapperComponent,
    children: [
      { path: 'profile', component: ProfileComponent}
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
