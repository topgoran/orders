import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, LoadChildren, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AlertDialogComponent } from 'src/app/public/alert-dialog/alert-dialog.component';
import { UsersCrudService } from 'src/app/services/users-crud.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-add-update-user',
  templateUrl: './add-update-user.component.html',
  styleUrls: ['./add-update-user.component.css']
})
export class AddUpdateUserComponent implements OnInit, OnDestroy {

  isAddMode!: boolean;
  userToEdit!: any;
  userId!: string;
  subscription!: Subscription;

  profileForm = new FormGroup({
    userName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormControl(''),
    state: new FormControl(''),
    city: new FormControl('')
  });

  loading$ = this.loader.loading$;


  constructor(private usersCrudService: UsersCrudService, private route: ActivatedRoute, private router: Router, public loader: LoadingService, public dialog: MatDialog) {
    
   }

  ngOnInit(): void {
    this.isAddMode = !this.route.snapshot.params['id'];

    if(!this.isAddMode){
      this.subscription = this.route.params.subscribe(params => {
        this.userId = params['id'];
      });

      this.usersCrudService.getUser(this.userId).subscribe(( data ) => {
        this.userToEdit = data;
        this.profileForm.patchValue({
          userName: this.userToEdit.userName,
          email: this.userToEdit.email,
          firstName: this.userToEdit.firstName,
          lastName: this.userToEdit.lastName,
          address: this.userToEdit.address,
          state: this.userToEdit.state,
          city: this.userToEdit.city

        })
      });
    }
  }

  ngOnDestroy(){
    if(!this.isAddMode){
      this.subscription.unsubscribe;
    }
  }

  onSubmit() {
    const newUser = {
      userName : this.profileForm.get("userName")?.value,
      password : this.profileForm.get("password")?.value,
      email : this.profileForm.get("email")?.value,
      firstName : this.profileForm.get("firstName")?.value,
      lastName : this.profileForm.get("lastName")?.value,  
      city : this.profileForm.get("city")?.value,
      state : this.profileForm.get("state")?.value,
      address : this.profileForm.get("address")?.value,
    }


    if(this.isAddMode){
      this.usersCrudService.create(newUser)
        .subscribe(({ data }) => {
          if(data?.registerMember.success){

            let dialogRef = this.dialog.open(AlertDialogComponent, {
              data: {
                dialogTitle: "Adding successful",
                dialogContent: "Go back"
              }
            })
            
            dialogRef.afterClosed().subscribe(result => {
              this.router.navigateByUrl('/admin/users/list')
            })
          }else{
            let dialogRef = this.dialog.open(AlertDialogComponent, {
              data: {
                dialogTitle: "Adding failed",
                dialogContent: "Go back"
              }
            })
            
            dialogRef.afterClosed().subscribe(result => {
              this.router.navigateByUrl('/admin/users/list')
            })
          }
        }, (error) => {
          console.log('there was an error sending the query', error);
       });
      }
    else{
      this.usersCrudService.update(newUser, this.userId).subscribe(({ data }) => {
        let dialogRef = this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Editing successful",
            dialogContent: "Go back"
          }
        })
        
        dialogRef.afterClosed().subscribe(result => {
          this.router.navigateByUrl('/admin/users/list')
        })
      }, (error) => {
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Editing failed",
            dialogContent: "Try again"
          }
        })
     });
    }
  }
}
