import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';
import { UserPageDAO } from 'src/app/models/UserPageDAO';
import { AlertDialogComponent } from 'src/app/public/alert-dialog/alert-dialog.component';
import { UsersCrudService } from 'src/app/services/users-crud.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {

  public clickedRow!: User;

  columnsToDisplay = ['username', 'email', 'firstname', 'lastname', 'city', 'state', 'address', 'editColumn', 'deleteColumn'];

  users!: UserPageDAO[];
  loading = true;

  postPerPage = 50;
  pageNumber = 1;
  totalItems!: number;

  totalItemsHelp!: number

  filter: string = "";


  @ViewChild('paginator') paginator!: MatPaginator;

  loading$ = this.loader.loading$;


  constructor(private userCrudService: UsersCrudService, private router: Router, public loader: LoadingService, private dialog: MatDialog) { }

  onPaginate(pageEvent: PageEvent) {
    this.postPerPage = pageEvent.pageSize;
    this.pageNumber = pageEvent.pageIndex + 1;

    this.userCrudService.getUsers(this.postPerPage, this.pageNumber, this.filter).subscribe(({ data, loading }) => {
      this.loading = loading;
      this.users = data.usersCustom.users;
    });
  }

  ngOnInit(): void {
    this.getUsers();
  }

  deleteSelectedUser(id: string){
    this.userCrudService.delete(id, this.postPerPage, this.pageNumber).subscribe(({ data }) => {
      this.dialog.open(AlertDialogComponent, {
        data: {
          dialogTitle: "User deleted successfully",
          dialogContent: "Finish"
        }
      })
    }, (error) => {
      this.dialog.open(AlertDialogComponent, {
        data: {
          dialogTitle: "User deletion failed",
          dialogContent: "Try again"
        }
      })
    });
  }

  editSelectedUser(id: string){
    this.router.navigateByUrl('admin/users/update/' + id);
  }

  addNewUser(){
    this.router.navigateByUrl('admin/users/add');
  }

  getUsers(){
    if(this.filter == ""){
      this.postPerPage = 50;
    }

    this.userCrudService.getUsers(this.postPerPage, this.pageNumber, this.filter).subscribe(({ data, loading }) => {
      this.loading = loading;
      this.users = data.usersCustom.users;
      this.totalItems = data.usersCustom.count;
      if(this.users.length < this.postPerPage){
        this.paginator.firstPage();
      }
  });
  }

  valueChange(newValue: string) {
    this.filter = newValue;
    this.getUsers();
  }
}
 