import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './public/login/login.component';
import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';
import { RegisterComponent } from './public/register/register.component';
import { AdminGuard } from './services/admin-guard.service';
import { MemberGuard } from './services/member-guard.service';

const routes: Routes = [

  {
    path:'',
    redirectTo:'login',
     pathMatch: 'full' 
  },
  {
    path:'login', component: LoginComponent
  },
  {
    path:'register', component: RegisterComponent
  },
  {
    path: 'member',
    loadChildren: () => import('./member/member.module').then(mod => mod.MemberModule),
    canActivate: [MemberGuard]
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin-profile.module').then(mod => mod.AdminProfileModule),
    canActivate: [AdminGuard]
  },
  { 
    path: '**', pathMatch: 'full', component: PageNotFoundComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
