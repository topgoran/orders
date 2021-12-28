import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs';
import { UserDTO } from 'src/app/models/UserDTO';
import { AuthService } from 'src/app/services/auth.service'; 
import { LoadingService } from 'src/app/shared/loading.service';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  username!: string;
  password!: string;
  
  subscription!: Subscription;
  userProfile!: UserDTO;

  loading$ = this.loader.loading$;

constructor(private authService: AuthService, private router: Router, public dialog: MatDialog, public loader: LoadingService) {
}

  ngOnInit(): void {
  }

  onSubmit(f: NgForm) {    
    this.username = f.controls['username'].value;
    this.password = f.controls['password'].value;

    this.authService.logIn(this.username, this.password).subscribe(({ data }) => {
      if(data?.loginUser.token != ""){
        let token = data?.loginUser.token as string;
        let id = data?.loginUser.id as string;
        localStorage.setItem('adminId', id);

        let jwtData = token.split('.')[1]
        let decodedJwtJsonData = window.atob(jwtData)
        let decodedJwtData = JSON.parse(decodedJwtJsonData)
        var role = decodedJwtData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

        localStorage.setItem('token', data?.loginUser.token as string);
        localStorage.setItem('role', role);

        if(role == "Admin"){
          this.router.navigate(['/', 'admin', 'profile'])
        }else if(role == "Member"){
          this.router.navigate([ '/', 'member', 'profile' ]);
        }

      }else if(data?.loginUser.token == ""){
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Login failed",
            dialogContent: "Entered fields were not valid"
          }
        });
      }
    }, (error) => {
      console.log("ERROR", error)
      this.dialog.open(AlertDialogComponent, {
        data: {
          dialogTitle: "Login failed",
          dialogContent: error
        }
      })
    });
  }
}
