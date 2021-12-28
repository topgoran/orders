import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersCrudService } from 'src/app/services/users-crud.service';

@Component({
  selector: 'app-member-wrapper',
  templateUrl: './member-wrapper.component.html',
  styleUrls: ['./member-wrapper.component.css']
})
export class MemberWrapperComponent implements OnInit {

  user!: any;
  loading = true;
  adminId!: string;


  constructor(fb: FormBuilder, private router: Router, private userCrudService: UsersCrudService) {
    
  }
  
  ngOnInit(): void {
    this.adminId = localStorage.getItem('adminId')!;
    this.getAdmin(this.adminId);
  }

  getAdmin(adminId: string){
    this.userCrudService.getUser(adminId).subscribe(( data ) => {
      this.user = data;
    });
  }

  logOut(){
    localStorage.setItem('token', "");
    localStorage.setItem('role', "");
    this.router.navigateByUrl('');
  }

}
