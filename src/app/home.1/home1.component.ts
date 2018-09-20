import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { User } from '../modules/users.model';
import { UserRegisterService } from '../share/user-register.service';

@Component({
  selector: 'app-home1',
  templateUrl: './home1.component.html',
  styleUrls: ['./home1.component.css']
})
export class Home1Component implements OnInit {
  userClaims: User;

  constructor(private router: Router, private rService:UserRegisterService) { }
  getUserName(){
    return localStorage.getItem('name');
}
   
logout(){
    localStorage.removeItem('name');
    this.router.navigateByUrl('/');
}

  ngOnInit() {
    // this.rService.getUserClaims().subscribe((data:any) => {
    //   this.userClaims = data; } )
    //     if(this.rService.roleMatch(['Admin']))
    //     {
    //     return this.userClaims;
    //     }
    }
}
