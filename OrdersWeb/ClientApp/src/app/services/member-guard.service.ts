import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MemberGuard {

  constructor(private router: Router) { }

  canActivate(): boolean{
    if(localStorage.getItem('role') == "Member"){
      return true;
    }
    else{
      this.router.navigate(['']);
      return false;
    }
  }
}
