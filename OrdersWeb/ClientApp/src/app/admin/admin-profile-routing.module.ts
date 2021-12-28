import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from '../shared/components/profile/profile.component';
import { AddUpdateArticleComponent } from './add-update-article/add-update-article.component';
import { AddUpdateUserComponent } from './add-update-user/add-update-user.component';
import { AdminWrapperComponent } from './admin-wrapper/admin-wrapper.component';
import { ArticlesTableComponent } from './articles-table/articles-table.component';
import { UsersTableComponent } from './users-table/users-table.component';

const routes: Routes = [
  { path: '', component: AdminWrapperComponent,
    children:[
      { path: 'profile', component: ProfileComponent},
      { path: 'users', children: [
        { path: 'list',  component: UsersTableComponent},
        { path: 'add', component: AddUpdateUserComponent},
        { path: 'update', children: [
          { path: ':id', component: AddUpdateUserComponent}
        ]}
      ]},
      { path: 'articles', children: [
        { path: 'list', component: ArticlesTableComponent },
        { path: 'add', component: AddUpdateArticleComponent},
        { path: 'update', children: [
          { path: ':id', component: AddUpdateArticleComponent }
        ]}
      ]}
    ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminProfileRoutingModule { }
