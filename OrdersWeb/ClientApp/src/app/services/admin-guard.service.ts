import { Injectable } from '@angular/core';
import { Router} from '@angular/router'

@Injectable({
  providedIn: 'root'
})
export class AdminGuard {

  constructor(private router: Router) { }

  canActivate(): boolean{
    if(localStorage.getItem('role') == "Admin"){
      return true;
    }
    else{
      this.router.navigate(['']);
      return false;
    }
  }
}
