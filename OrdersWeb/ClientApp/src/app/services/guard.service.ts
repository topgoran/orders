import { Injectable } from '@angular/core';
import {  Router} from '@angular/router'
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(private router: Router) { }

  canActivate(): boolean{
    if(localStorage.getItem('token') != ""){
      return true;
    }
    else{
      this.router.navigate(['']);
      return false;
    }
  }
}
