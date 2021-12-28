import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersCrudService } from 'src/app/services/users-crud.service';

@Component({
  selector: 'app-admin-wrapper',
  templateUrl: './admin-wrapper.component.html',
  styleUrls: ['./admin-wrapper.component.css']
})
export class AdminWrapperComponent implements OnInit {

  options: FormGroup;
  user!: any;
  loading = true;
  adminId!: string;

  constructor(fb: FormBuilder, private router: Router, private userCrudService: UsersCrudService) {
    this.options = fb.group({
      bottom: 0,
      fixed: false,
      top: 0
    });
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
