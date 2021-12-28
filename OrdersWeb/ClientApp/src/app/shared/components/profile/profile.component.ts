import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UsersCrudService } from 'src/app/services/users-crud.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit, OnDestroy {

  id!: string;
  user!: any;
  loading = true;
  userId!: string;


  subscription!: Subscription;
  subscription2!: Subscription;

  constructor(private router: Router, private userCrudService: UsersCrudService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if(this.id != undefined){
      
    }else{
      this.userId = localStorage.getItem('adminId')!;
      this.getAdmin(this.userId);
    }
  }

  getAdmin(adminId: string){
    this.userCrudService.getUser(adminId).subscribe(( data ) => {
      this.user = data;
    });
  }

  getMember(){
    this.subscription = this.route.params.subscribe(params => {
      this.userId = params['id'];
    });

    this.subscription2 = this.userCrudService.getUser(this.userId).subscribe(( data ) => {
      this.user = data;
    });
  }

  ngOnDestroy(){
    if(this.subscription != undefined){
      this.subscription.unsubscribe();
    }
    if(this.subscription2 != undefined){
      this.subscription2.unsubscribe();
    }
  }

  logOut(){
    localStorage.setItem('token', "");
    localStorage.setItem('role', "");
    this.router.navigateByUrl('');
  }

}
