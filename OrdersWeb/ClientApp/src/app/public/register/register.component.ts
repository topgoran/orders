import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/shared/loading.service';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username!: string;
  email!: string;
  firstName!: string;
  lastName!: string;
  password!: string;
  city!: string;
  state!: string;  
  address!: string;

  loading$ = this.loader.loading$;

  constructor(private authService: AuthService, public dialog: MatDialog, private router: Router, private loader: LoadingService) { }

  ngOnInit(): void {  
  }

  onSubmit(f: NgForm) {

    const newUser = {
      userName : f.controls['username'].value,
      password : f.controls['password'].value,
      email : f.controls['email'].value,
      firstName : f.controls['firstname'].value,
      lastName : f.controls['lastname'].value,  
      city : f.controls['city'].value,
      state : f.controls['state'].value,
      address : f.controls['address'].value,
    }


    this.authService.register(newUser)
      .subscribe(({ data }) => {
        console.log("Data", data)

        let success  = data?.registerMember.success;
        console.log("success", success)

        if(!success){
          this.dialog.open(AlertDialogComponent, {
            data: {
              dialogTitle: "Registration failed",
              dialogContent: "Entered fields were not vaild"
            }
          })
        }else{
          let dialogRef = this.dialog.open(AlertDialogComponent, {
            data: {
              dialogTitle: "Registration successfull",
              dialogContent: "Proceed to login"
            }
          })
          
          dialogRef.afterClosed().subscribe(result => {
            this.router.navigate(['/', 'login'])
          })
        }

        //success == "true" ? this.router.navigate(['/', 'login']) : this.dialog.open(RegistrationDialogComponent)
      }, (error) => {
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Registration failed",
            dialogContent: error
          }
        })
     });
  }
}
